using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AlphaX.FluentExtensions
{
    public abstract class Map<T>
    {
        protected List<Mapping> _mappings;

        public Map()
        {
            _mappings = new List<Mapping>();
        }

        protected Mapping MapProperty(Expression<Func<T, object>> action)
        {
            MemberExpression memberExpression;

            if (action.Body is UnaryExpression unaryExpression)
            {
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else
            {
                memberExpression = (MemberExpression)action.Body;
            }

            var mapping = new Mapping((PropertyInfo)memberExpression.Member);
            mapping.WithIndex(_mappings.Count);
            _mappings.Add(mapping);
            return mapping;
        }

        internal IEnumerable<Mapping> GetMappings()
        {
            return _mappings.OrderBy(x => x.Index);
        }
    }
}
