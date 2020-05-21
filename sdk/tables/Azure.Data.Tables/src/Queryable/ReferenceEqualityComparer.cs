// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;

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
}
