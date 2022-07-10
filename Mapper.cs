using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Picorm.Common.Data;
using Picorm.Common.Mapping;
using Picorm.Enums;

namespace Picorm.Common
{
    public class Mapper : IMapper
    {
        static readonly List<object> cache = new List<object>();
        public Mapper(IDBInterface dBInterface)
        {
            DBInterface = dBInterface;
        }
        public IDBInterface DBInterface { get; }

        public StandardMapper<Result> GetMapper<Result>() where Result : class
        {
            lock (cache)
            {
                StandardMapper<Result>? mapper = cache.FirstOrDefault(c => c is StandardMapper<Result>) as StandardMapper<Result>;
                if (mapper == null)
                {
                    mapper = new StandardMapper<Result>();
                    cache.Add(mapper);
                }
                return mapper;
            }
        }

        public IEnumerable<Result> GetAll<Result>(Func<Result> ctor) where Result : class
        {
            StandardMapper<Result> mapper = GetMapper<Result>();
            using IDataReader reader = DBInterface.SelectAll(mapper.EntityName);
            foreach (Result result in mapper.Map(reader, ctor))
            {
                yield return result;
            }
        }

        public IEnumerable<Result> GetWhere<Result, Parameter>(Func<Result> ctor, Parameter parameter) where Result : class where Parameter : class
        {
            StandardMapper<Result> mapper = GetMapper<Result>();
            StandardMapper<Parameter> parameterMapper = GetMapper<Parameter>();
            using IDataReader reader = DBInterface.SelectWhere(
                mapper.EntityName,
                parameterMapper.GetParameters(parameter)
            );
            foreach (Result result in mapper.Map(reader, ctor))
            {
                yield return result;
            }
        }

        public int Insert<Entity>(Entity e) where Entity : class
        {
            var mapper = GetMapper<Entity>();
            var parameters = mapper.GetParameters(e, FieldDirection.Write);
            string tableName = mapper.EntityName;
            return DBInterface.Insert(tableName, parameters);
        }

        public int Update<Entity>(Entity e) where Entity : class
        {
            var mapper = GetMapper<Entity>();
            return DBInterface.Update(
                    mapper.EntityName,
                    mapper.GetParameters(e, FieldDirection.Write),
                    mapper.GetParameters(e, FieldDirection.Key)
                );
        }

        public int UpdateWhere<Entity, Filter>(Entity e, Filter f) where Entity : class where Filter : class
        {
            var mapper = GetMapper<Entity>();

            return DBInterface.Update(
                    mapper.EntityName,
                    mapper.GetParameters(e, FieldDirection.Write),
                    GetMapper<Filter>().GetParameters(f, FieldDirection.Filter)
                );
        }

        public int Delete<Entity>(Entity e) where Entity : class
        {
            var mapper = GetMapper<Entity>();
            return DBInterface.Delete(
                    mapper.EntityName,
                    mapper.GetParameters(e, FieldDirection.Key)
                );
        }

        public int DeleteWhere<Entity>(Entity e) where Entity : class
        {
            return DBInterface.Delete(
                    GetMapper<Entity>().EntityName,
                    GetMapper<Entity>().GetParameters(e, FieldDirection.Write)
                );
        }

        public int DeleteWhere<Entity, Filter>(Filter f) where Entity : class where Filter : class
        {
            return DBInterface.Delete(
                    GetMapper<Entity>().EntityName,
                    GetMapper<Filter>().GetParameters(f, FieldDirection.Write)
                );
        }
    }
}