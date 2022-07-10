using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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