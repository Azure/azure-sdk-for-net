// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Filter expression for use with a <see cref="FilteringBindingProvider{TAttribute}"/> (at runtime)
    /// and <see cref="BindingRule"/> (at design time)
    /// </summary>
    internal abstract class FilterNode
    {
        // Evalute if the filter is true against the given attribute.
        public abstract bool Eval(Attribute attribute);
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            this.ToString(sb);
            return sb.ToString();
        }

        protected abstract void ToString(StringBuilder sb);

#region Builder methods 

        public static FilterNode And(IEnumerable<FilterNode> children)
        {
            return new AndFilterNode(children);
        }

        public static FilterNode And(params FilterNode[] children)
        {
            return new AndFilterNode(children);
        }

        public static FilterNode NotNull(PropertyInfo property)
        {
            return new IsNotNullNode { _propertyInfo = property };
        }

        public static FilterNode Null(PropertyInfo property)
        {
            return new IsNullNode { _propertyInfo = property };
        }

        public static FilterNode IsEqual<TValue>(PropertyInfo property, TValue value)
        {
            return new PropertyEqualsNode<TValue>(property, value, true);
        }

        public static FilterNode IsNotEqual<TValue>(PropertyInfo property, TValue value)
        {
            return new PropertyEqualsNode<TValue>(property, value, false);
        }
#endregion 

        private class AndFilterNode : FilterNode
        {
            private readonly FilterNode[] _children;

            public AndFilterNode(IEnumerable<FilterNode> children)
            {
                _children = children.Where(x => x != null).ToArray();
            }

            public override bool Eval(Attribute attribute)
            {
                foreach (var child in this._children)
                {
                    if (!child.Eval(attribute))
                    {
                        return false;
                    }
                }
                return true;
            }

            protected override void ToString(StringBuilder sb)
            {
                bool first = true;
                foreach (var child in this._children)
                {
                    if (!first)
                    {
                        sb.Append(" && ");
                    }
                    first = false;
                    child.ToString(sb);
                }
            }
        }

        private abstract class PropertyNode : FilterNode
        {
            public PropertyInfo _propertyInfo;

            protected object GetProperyValue(Attribute attribute)
            {
                var attributeType = attribute.GetType();

                var val = _propertyInfo.GetValue(attribute); // actual value in the attribute
                return val;
            }

            protected string PropertyName => _propertyInfo.Name;
        }

        private class PropertyEqualsNode<TValue> : PropertyNode
        {
            private readonly TValue _value;
            private readonly bool _opEquals; // True for ==, false for !=

            public PropertyEqualsNode(PropertyInfo property, TValue expected, bool opEquals)
            {
                var propType = property.PropertyType;
                if (!propType.IsAssignableFrom(typeof(TValue))) // Handles nullable
                {
                    throw new InvalidOperationException(
                        $"Type mismatch. Property '{property.Name}' is of type '{TypeUtility.GetFriendlyName(propType)}'. " +
                        $"Can't compare to a value of type '{TypeUtility.GetFriendlyName(typeof(TValue))}");
                }

                this._value = expected;
                this._propertyInfo = property;
                this._opEquals = opEquals;
            }

            public override bool Eval(Attribute attribute)
            {
                var actualValue = this.GetProperyValue(attribute);

                bool isEqual = false;
                if (actualValue is TValue val) // Handles nullable
                {
                    isEqual = val.Equals(_value);
                }

                return isEqual == _opEquals;
            }

            protected override void ToString(StringBuilder sb)
            {
                sb.AppendFormat("({0} {1} {2})", this.PropertyName, _opEquals ? "==" : "!=", this._value);
            }
        }

        private class IsNullNode : PropertyNode
        {
            public override bool Eval(Attribute attribute)
            {
                var val = this.GetProperyValue(attribute);
                return val == null;
            }

            protected override void ToString(StringBuilder sb)
            {
                sb.AppendFormat("({0} == null)", this.PropertyName);
            }
        }

        private class IsNotNullNode : PropertyNode
        {
            public override bool Eval(Attribute attribute)
            {
                var val = this.GetProperyValue(attribute);
                return val != null;
            }


            protected override void ToString(StringBuilder sb)
            {
                sb.AppendFormat("({0} != null)", this.PropertyName);
            }
        }
    }
}
