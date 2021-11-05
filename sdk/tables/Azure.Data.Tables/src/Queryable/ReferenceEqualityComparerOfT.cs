// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Data.Tables.Queryable
{
#pragma warning disable SA1649 // File name should match first type name
    internal sealed class ReferenceEqualityComparer<T> : ReferenceEqualityComparer, IEqualityComparer<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private static ReferenceEqualityComparer<T> s_instance;

        private ReferenceEqualityComparer()
            : base()
        {
        }

        internal static ReferenceEqualityComparer<T> Instance
        {
            get
            {
                if (s_instance == null)
                {
                    Debug.Assert(!typeof(T).IsValueType, "!typeof(T).IsValueType -- can't use reference equality in a meaningful way with value types");
                    ReferenceEqualityComparer<T> newInstance = new ReferenceEqualityComparer<T>();
                    System.Threading.Interlocked.CompareExchange(ref s_instance, newInstance, null);
                }

                return s_instance;
            }
        }

        public bool Equals(T x, T y)
        {
            return object.ReferenceEquals(x, y);
        }

        public int GetHashCode(T obj)
        {
            if (obj == null)
            {
                return 0;
            }

            return obj.GetHashCode();
        }
    }
}
