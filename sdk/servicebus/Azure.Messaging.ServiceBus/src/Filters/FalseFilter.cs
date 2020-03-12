// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Filters
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

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is FalseFilter;
        }

        /// <inheritdoc/>
        public override bool Equals(Filter other)
        {
            return other is FalseFilter;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static bool operator ==(FalseFilter o1, FalseFilter o2)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static bool operator !=(FalseFilter o1, FalseFilter o2)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return !(o1 == o2);
        }
    }
}
