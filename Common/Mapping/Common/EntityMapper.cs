using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Picorm.Enums;
using Picorm.Common.Data;
using Picorm.Attributes;
using System.Reflection;

namespace Picorm.Common.Mapping.Common
{
    public class EntityMapper<T> : BaseMapper<T>, IEntityMapper<T> where T : class
    {
        public string EntityName { get; private set; }

        public EntityMapper()
        {
            EntityName = typeof(T).GetCustomAttribute<Entity>()?.Name ?? string.Empty;
        }

        public T Fill(DataRow row, Func<T> ctor)
        {
            T result = ctor();
            foreach (var adapter in GetFieldsWithDirection(FieldDirection.Read))
            {
                if (row.Table.Columns.Contains(adapter.Field.Name))
                {
                    object value = row[adapter.Field.Name];
                    if (value != null || adapter.Field.ReadsNulls)
                    {
                        adapter.Setter(result, value);
                    }
                }
            }
            return result;
        }

        public IEnumerable<T> Map(IDataReader dataReader, Func<T> ctor)
        {
            List<FieldBridge> fields = GetFieldsWithDirection(FieldDirection.Read).ToList();
            Dictionary<int, FieldBridge> map = Enumerable
                .Range(0, dataReader.FieldCount)
                .Where(i => fields.Any(f => dataReader.GetName(i).ToUpper() == f.Field.Name.ToUpper()))
                .ToDictionary(i => i, i => fields.First(f => dataReader.GetName(i).ToUpper() == f.Field.Name.ToUpper()));

            while (dataReader.Read())
            {
                T result = ctor();
                foreach (var m in map)
                {
                    object value = dataReader.GetValue(m.Key);
                    if (value != null || m.Value.Field.ReadsNulls)
                    {
                        m.Value.Setter(result, value);
                    }
                }
                yield return result;
            }
        }

        public IEnumerable<QueryParameter> GetParameters(T entity, FieldDirection fieldDirection = FieldDirection.Filter)
        {
            foreach (var field in GetFieldsWithDirection(fieldDirection))
            {
                object? value = field.Getter(entity);
                if (value != null || field.Field.WritesDefaults && !field.Field.IsKey)
                {
                    yield return new QueryParameter(field.Field.Name, value);
                }
            }
        }
    }
}