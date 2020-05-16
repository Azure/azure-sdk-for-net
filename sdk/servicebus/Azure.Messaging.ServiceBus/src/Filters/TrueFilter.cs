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

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(TrueFilter left, TrueFilter right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(TrueFilter left, TrueFilter right)
        {
            return !(left == right);
        }
    }
}
