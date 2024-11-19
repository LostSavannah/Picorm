using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Picorm.Attributes;
using Picorm.Enums;

namespace Picorm.Common.Mapping.Common
{
    public class BaseMapper<T> where T : class
    {
        private Dictionary<FieldDirection, ICollection<FieldBridge>> cache
            = new Dictionary<FieldDirection, ICollection<FieldBridge>>();

        protected ICollection<FieldBridge> GetFieldsWhere(Func<Field, bool> filter)
        {
            List<FieldBridge> fields = new List<FieldBridge>();
            fields.AddRange(
                    typeof(T).GetFields()
                    .Where(p => p.GetCustomAttribute<Field>() != null)
                    .Select(p => new FieldBridge(
                        p.GetCustomAttribute<Field>() ?? new Field(""),
                        p.SetValue,
                        p.GetValue,
                        p.Name
                        )
                    ).ToList()
                );
            fields.AddRange(
                    typeof(T).GetProperties()
                    .Where(p => p.GetCustomAttribute<Field>() != null)
                    .Select(p => new FieldBridge(
                        p.GetCustomAttribute<Field>() ?? new Field(""),
                        p.SetValue,
                        p.GetValue,
                        p.Name
                        )
                    ).ToList()
                );
            return fields.Where(f => filter(f.Field)).ToList();
        }

        protected ICollection<FieldBridge> GetFieldsWithDirection(FieldDirection direction)
        {
            lock (cache)
            {
                if (cache.ContainsKey(direction)) return cache[direction];
                ICollection<FieldBridge> fields = GetFieldsWhere(f => (f.FieldDirection & direction) == direction);
                cache[direction] = fields;
                return fields;
            }
        }
    }
}