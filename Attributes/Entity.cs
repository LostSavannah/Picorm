using System;

namespace Picorm.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class Entity : Attribute
    {
        public Entity(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }
}