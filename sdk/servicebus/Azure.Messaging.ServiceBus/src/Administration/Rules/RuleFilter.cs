// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    /// Describes a filter expression that is evaluated against a Message.
    /// </summary>
    /// <remarks>
    /// Filter is an abstract class with the following concrete implementations:
    /// <list type="bullet">
    /// <item><description><b>SqlRuleFilter</b> that represents a filter using SQL syntax.</description></item>
    /// <item><description><b>CorrelationRuleFilter</b> that provides an optimization for correlation equality expressions.</description></item>
    /// </list>
    /// </remarks>
    /// <seealso cref="SqlRuleFilter"/>
    /// <seealso cref="TrueRuleFilter"/>
    /// <seealso cref="CorrelationRuleFilter "/>
    /// <seealso cref="FalseRuleFilter"/>
    public abstract class RuleFilter : IEquatable<RuleFilter>
    {
        internal RuleFilter()
        {
            // This is intentionally left blank. This constructor exists
            // only to prevent external assemblies inheriting from it.
        }

        internal abstract RuleFilter Clone();

        /// <inheritdoc/>
        public abstract bool Equals(RuleFilter other);

        /// <inheritdoc/>
        public abstract override bool Equals(object obj);

        /// <inheritdoc/>
        public override int GetHashCode() =>
            base.GetHashCode();
    }
}
