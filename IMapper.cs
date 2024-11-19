using Picorm.Common.Data;
using Picorm.Common.Mapping;
using System;
using System.Collections.Generic;

namespace Picorm.Common
{
    public interface IMapper
    {
        IDBInterface DBInterface { get; }

        int Delete<Entity>(Entity e) where Entity : class;
        int DeleteWhere<Entity, Filter>(Filter f)
            where Entity : class
            where Filter : class;
        int DeleteWhere<Entity>(Entity e) where Entity : class;
        IEnumerable<Result> GetAll<Result>(Func<Result> ctor) where Result : class;
        IEntityMapper<Result> GetMapper<Result>() where Result : class;
        IEnumerable<Result> GetWhere<Result, Parameter>(Func<Result> ctor, Parameter parameter)
            where Result : class
            where Parameter : class;
        int Insert<Entity>(Entity e) where Entity : class;
        int Update<Entity>(Entity e) where Entity : class;
        int UpdateWhere<Entity, Filter>(Entity e, Filter f)
            where Entity : class
            where Filter : class;
    }
}