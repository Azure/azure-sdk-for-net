// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{

    /// <summary>
    /// Base implementation for expandable, single string enums.
    /// </summary>
    public abstract class ExpandableStringEnum<T> where T : ExpandableStringEnum<T>, new()
    {
        private static Dictionary<string, T> values = null;
        internal string value;

        protected ExpandableStringEnum()
        {
        }

        public string Value
        {
            get { return value; }
            protected set
            {
                this.value = value;
                if (values == null)
                {
                    values = new Dictionary<string, T>();
                }
                values.Add(value.ToLower(), (T)this);
            }
        }

        public override string ToString()
        {
            return value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(ExpandableStringEnum<T> lhs, T rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ExpandableStringEnum<T> lhs, T rhs)
        {
            return !(lhs == rhs);
        }

        public static T Parse(string value)
        {
            if (value == null)
            {
                return null;
            }

            T v;
            if (values.TryGetValue(value.ToLower(), out v))
            {
                return v;
            }
            else
            {
                return new T() { Value = value };
            }
        }

        public bool Equals(string value)
        {
            if (value == null)
            {
                return null == this.value;
            }
            else
            {
                return value.ToLower().Equals(this.value.ToLower());
            }
        }

        public override bool Equals(object obj)
        {
            string value = ToString();
            if (!(obj is T))
            {
                return false;
            }
            else if (ReferenceEquals(obj, this))
            {
                return true;
            }

            T rhs = (T)obj;
            if (value == null)
            {
                return rhs.value == null;
            }
            return value.Equals(rhs.value, StringComparison.OrdinalIgnoreCase);
        }
    }
}
