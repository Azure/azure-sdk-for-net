// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Filters
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

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is TrueFilter;
        }

        /// <inheritdoc/>
        public override bool Equals(Filter other)
        {
            return other is TrueFilter;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static bool operator ==(TrueFilter o1, TrueFilter o2)
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
        public static bool operator !=(TrueFilter o1, TrueFilter o2)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return !(o1 == o2);
        }
    }
}
