using System.Collections.Generic;
using System.Data;

namespace Picorm.Common.Data
{
    public interface IDBInterface
    {
        IDataReader SelectAll(string tableName);
        IDataReader SelectWhere(string tableName, IEnumerable<QueryParameter> parameters);
        int Insert(string tableName, IEnumerable<QueryParameter> parameters);
        int Update(string tableName, IEnumerable<QueryParameter> updates, IEnumerable<QueryParameter> where);
        int Delete(string tableName, IEnumerable<QueryParameter> where);
    }
}