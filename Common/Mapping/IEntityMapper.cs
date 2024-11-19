using Picorm.Common.Data;
using Picorm.Enums;
using System;
using System.Collections.Generic;
using System.Data;

namespace Picorm.Common.Mapping
{
    public interface IEntityMapper<T> where T : class
    {
        public string EntityName { get; }
        T Fill(DataRow row, Func<T> ctor);
        IEnumerable<QueryParameter> GetParameters(T entity, FieldDirection fieldDirection = FieldDirection.Filter);
        IEnumerable<T> Map(IDataReader dataReader, Func<T> ctor);
    }
}