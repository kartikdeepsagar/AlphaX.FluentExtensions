using System.Reflection;

namespace AlphaX.FluentExtensions
{
    public class Mapping
    {
        public PropertyInfo Property { get; }
        public string Name { get; private set; }
        public int Index { get; private set; }

        public Mapping(PropertyInfo property)
        {
            Property = property;
            Name = property.Name;
        }

        public Mapping WithName(string name)
        {
            Name = name;
            return this;
        }

        public Mapping WithIndex(int index)
        {
            Index = index;
            return this;
        }
    }
}
