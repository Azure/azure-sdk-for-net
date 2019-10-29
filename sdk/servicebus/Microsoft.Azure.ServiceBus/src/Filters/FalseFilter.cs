// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    /// <summary>
    /// Matches none the messages arriving to be selected for the subscription.
    /// </summary>
    public sealed class FalseFilter : SqlFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FalseFilter" /> class.
        /// </summary>
        public FalseFilter()
            : base("1=0")
        {
        }

        /// <summary>
        /// Converts the current instance to its string representation.
        /// </summary>
        /// <returns>A string representation of the current instance.</returns>
        public override string ToString()
        {
            return "FalseFilter";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is FalseFilter;
        }

        public override bool Equals(Filter other)
        {
            return other is FalseFilter;
        }

        public static bool operator ==(FalseFilter o1, FalseFilter o2)
        {
            if (ReferenceEquals(o1, o2))
            {
                return true;
            }

            if (ReferenceEquals(o1, null) || ReferenceEquals(o2, null))
            {
                return false;
            }

            return o1.Equals(o2);
        }

        public static bool operator !=(FalseFilter o1, FalseFilter o2)
        {
            return !(o1 == o2);
        }
    }
}