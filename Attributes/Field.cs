using System;

using Picorm.Enums;

namespace Picorm.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class Field : Attribute
    {
        public Field(
            string name,
            FieldDirection fieldDirection = FieldDirection.ReadWrite,
            bool isKey = false,
            bool required = false,
            bool writesDefaults = true,
            bool readsNulls = false)
        {
            Name = name;
            FieldDirection = fieldDirection;
            Required = required;
            WritesDefaults = writesDefaults;
            ReadsNulls = readsNulls;
            if (isKey)
            {
                FieldDirection |= FieldDirection.Key;
            }
        }

        public string Name { get; }
        public FieldDirection FieldDirection { get; }
        public bool IsKey { get => (FieldDirection & FieldDirection.Key) == FieldDirection.Key; }
        public bool Required { get; }
        public bool WritesDefaults { get; }
        public bool ReadsNulls { get; }
    }
}