using Picorm.Attributes;
using System;

namespace Picorm.Common.Mapping
{
    public class FieldBridge
    {
        public FieldBridge(Field field, Action<object, object?> setter, Func<object, object?> getter, string name)
        {
            Field = field;
            Setter = setter;
            Getter = getter;
            Name = name;
        }
        public Field Field { get; set; }
        public Action<object, object?> Setter { get; set; }
        public Func<object, object?> Getter { get; set; }
        public string Name { get; set; }

    }
}