// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    /// Matches none the messages arriving to be selected for the subscription.
    /// </summary>
    public sealed class FalseRuleFilter : SqlRuleFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FalseRuleFilter" /> class.
        /// </summary>
        public FalseRuleFilter()
            : base("1=0")
        {
        }

        internal override RuleFilter Clone() =>
            new FalseRuleFilter();

        /// <summary>
        /// Converts the current instance to its string representation.
        /// </summary>
        /// <returns>A string representation of the current instance.</returns>
        public override string ToString()
        {
            return "FalseRuleFilter";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is FalseRuleFilter;
        }

        /// <inheritdoc/>
        public override bool Equals(RuleFilter other)
        {
            return other is FalseRuleFilter;
        }

        /// <summary>Compares two <see cref="FalseRuleFilter"/> values for equality.</summary>
        public static bool operator ==(FalseRuleFilter left, FalseRuleFilter right)
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

        /// <summary>Compares two <see cref="FalseRuleFilter"/> values for inequality.</summary>
        public static bool operator !=(FalseRuleFilter left, FalseRuleFilter right)
        {
            return !(left == right);
        }
    }
}
