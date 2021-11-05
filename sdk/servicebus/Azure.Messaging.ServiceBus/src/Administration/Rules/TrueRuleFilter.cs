// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    /// Matches all the messages arriving to be selected for the subscription.
    /// </summary>
    public sealed class TrueRuleFilter : SqlRuleFilter
    {
        internal static readonly TrueRuleFilter Default = new TrueRuleFilter();

        /// <summary>
        /// Initializes a new instance of the <see cref="TrueRuleFilter" /> class.
        /// </summary>
        public TrueRuleFilter()
            : base("1=1")
        {
        }

        internal override RuleFilter Clone() =>
            new TrueRuleFilter();

        /// <summary>
        /// Converts the value of the current instance to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the current instance.</returns>
        public override string ToString()
        {
            return "TrueRuleFilter";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is TrueRuleFilter;
        }

        /// <inheritdoc/>
        public override bool Equals(RuleFilter other)
        {
            return other is TrueRuleFilter;
        }

        /// <summary>Compares two <see cref="TrueRuleFilter"/> values for equality.</summary>
        public static bool operator ==(TrueRuleFilter left, TrueRuleFilter right)
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

        /// <summary>Compares two <see cref="TrueRuleFilter"/> values for inequality.</summary>
        public static bool operator !=(TrueRuleFilter left, TrueRuleFilter right)
        {
            return !(left == right);
        }
    }
}
