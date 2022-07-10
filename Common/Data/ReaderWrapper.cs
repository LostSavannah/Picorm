using System;
using System.Data;

namespace Picorm.Common.Data
{
    public class ReaderWrapper : IDataReader
    {
        public ReaderWrapper(IDbConnection connection, IDataReader dataReader)
        {
            Connection = connection;
            DataReader = dataReader;
        }
        private IDbConnection Connection { get; }
        public IDataReader DataReader { get; }

        public int Depth => DataReader.Depth;

        public bool IsClosed => DataReader.IsClosed;

        public int RecordsAffected => DataReader.RecordsAffected;

        public int FieldCount => DataReader.FieldCount;

        public object this[string name] => DataReader[name];

        public object this[int i] => DataReader[i];

        public void Dispose()
        {
            Connection.Close();
            DataReader.Dispose();
        }

        public void Close() => DataReader.Close();

        public DataTable? GetSchemaTable() => DataReader.GetSchemaTable();

        public bool NextResult() => DataReader.NextResult();

        public bool Read() => DataReader.Read();

        public bool GetBoolean(int i) => DataReader.GetBoolean(i);

        public byte GetByte(int i) => DataReader.GetByte(i);

        public long GetBytes(int i, long fieldOffset, byte[]? buffer, int bufferoffset, int length) =>
            DataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);

        public char GetChar(int i) => DataReader.GetChar(i);

        public long GetChars(int i, long fieldoffset, char[]? buffer, int bufferoffset, int length) =>
            DataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);

        public IDataReader GetData(int i) => DataReader.GetData(i);

        public string GetDataTypeName(int i) => DataReader.GetDataTypeName(i);

        public DateTime GetDateTime(int i) => DataReader.GetDateTime(i);

        public decimal GetDecimal(int i) => DataReader.GetDecimal(i);

        public double GetDouble(int i) => DataReader.GetDouble(i);

        public Type GetFieldType(int i) => DataReader.GetFieldType(i);

        public float GetFloat(int i) => DataReader.GetFloat(i);

        public Guid GetGuid(int i) => DataReader.GetGuid(i);

        public short GetInt16(int i) => DataReader.GetInt16(i);

        public int GetInt32(int i) => DataReader.GetInt32(i);

        public long GetInt64(int i) => DataReader.GetInt64(i);

        public string GetName(int i) => DataReader.GetName(i);

        public int GetOrdinal(string name) => DataReader.GetOrdinal(name);

        public string GetString(int i) => DataReader.GetString(i);

        public object GetValue(int i) => DataReader.GetValue(i);

        public int GetValues(object[] values) => DataReader.GetValues(values);

        public bool IsDBNull(int i) => DataReader.IsDBNull(i);
    }
}