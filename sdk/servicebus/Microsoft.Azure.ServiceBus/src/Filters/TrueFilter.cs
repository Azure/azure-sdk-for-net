// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    /// <summary>
    /// Matches all the messages arriving to be selected for the subscription.
    /// </summary>
    public sealed class TrueFilter : SqlFilter
    {
        internal static readonly TrueFilter Default = new TrueFilter();

        /// <summary>
        /// Initializes a new instance of the <see cref="TrueFilter" /> class.
        /// </summary>
        public TrueFilter()
            : base("1=1")
        {
        }

        /// <summary>
        /// Converts the value of the current instance to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the current instance.</returns>
        public override string ToString()
        {
            return "TrueFilter";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is TrueFilter;
        }

        public override bool Equals(Filter other)
        {
            return other is TrueFilter;
        }

        public static bool operator ==(TrueFilter o1, TrueFilter o2)
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

        public static bool operator !=(TrueFilter o1, TrueFilter o2)
        {
            return !(o1 == o2);
        }
    }
}