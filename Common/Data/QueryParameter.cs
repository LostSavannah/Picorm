namespace Picorm.Common.Data
{
    public class QueryParameter
    {
        public QueryParameter(string name, object? value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; } = string.Empty;
        public object? Value { get; set; }
    }
}