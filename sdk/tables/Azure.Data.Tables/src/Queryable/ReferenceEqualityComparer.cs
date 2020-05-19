// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Data.Tables.Queryable
{
    internal class ReferenceEqualityComparer : IEqualityComparer
    {
        protected ReferenceEqualityComparer()
        {
        }

        bool IEqualityComparer.Equals(object x, object y)
        {
            return object.ReferenceEquals(x, y);
        }

        int IEqualityComparer.GetHashCode(object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            return obj.GetHashCode();
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal sealed class ReferenceEqualityComparer<T> : ReferenceEqualityComparer, IEqualityComparer<T>
#pragma warning restore SA1402 // File may only contain a single type
    {
        private static ReferenceEqualityComparer<T> instance;

        private ReferenceEqualityComparer()
            : base()
        {
        }

        internal static ReferenceEqualityComparer<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    Debug.Assert(!typeof(T).IsValueType, "!typeof(T).IsValueType -- can't use reference equality in a meaningful way with value types");
                    ReferenceEqualityComparer<T> newInstance = new ReferenceEqualityComparer<T>();
                    System.Threading.Interlocked.CompareExchange(ref instance, newInstance, null);
                }

                return instance;
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
