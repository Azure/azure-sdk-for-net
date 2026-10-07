// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.OperationalInsights;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    // Backward-compatibility shim for the type name shipped in version 1.3.2.
    /// <summary> SummaryRules rule type: User. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future release. Use OperationalInsightsSummaryLogsRuleType instead.", false)]
    public readonly partial struct OperationalInsightsNetworkSecurityPerimeterRuleType : IEquatable<OperationalInsightsNetworkSecurityPerimeterRuleType>
    {
        private readonly string _value;
        private const string UserValue = "User";

        /// <summary> Initializes a new instance of <see cref="OperationalInsightsNetworkSecurityPerimeterRuleType"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public OperationalInsightsNetworkSecurityPerimeterRuleType(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
        }

        /// <summary> User defined summary rule. This is the definition for rules created and defined by users. </summary>
        public static OperationalInsightsNetworkSecurityPerimeterRuleType User { get; } = new(UserValue);

        /// <summary> Converts a string to an <see cref="OperationalInsightsNetworkSecurityPerimeterRuleType"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator OperationalInsightsNetworkSecurityPerimeterRuleType(string value) => new(value);

        /// <summary> Converts a string to a nullable <see cref="OperationalInsightsNetworkSecurityPerimeterRuleType"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator OperationalInsightsNetworkSecurityPerimeterRuleType?(string value) => value is null ? null : new(value);

        /// <summary> Converts an <see cref="OperationalInsightsNetworkSecurityPerimeterRuleType"/> to an <see cref="OperationalInsightsSummaryLogsRuleType"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator OperationalInsightsSummaryLogsRuleType(OperationalInsightsNetworkSecurityPerimeterRuleType value) => value._value is null ? default : new(value._value);

        /// <summary> Converts an <see cref="OperationalInsightsSummaryLogsRuleType"/> to an <see cref="OperationalInsightsNetworkSecurityPerimeterRuleType"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator OperationalInsightsNetworkSecurityPerimeterRuleType(OperationalInsightsSummaryLogsRuleType value) => value.ToString() is string stringValue ? new(stringValue) : default;

        /// <inheritdoc/>
        public bool Equals(OperationalInsightsNetworkSecurityPerimeterRuleType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OperationalInsightsNetworkSecurityPerimeterRuleType other && Equals(other);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value is null ? 0 : StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);

        /// <inheritdoc/>
        public override string ToString() => _value;

        /// <summary> Determines if two <see cref="OperationalInsightsNetworkSecurityPerimeterRuleType"/> values are the same. </summary>
        public static bool operator ==(OperationalInsightsNetworkSecurityPerimeterRuleType left, OperationalInsightsNetworkSecurityPerimeterRuleType right) => left.Equals(right);

        /// <summary> Determines if two <see cref="OperationalInsightsNetworkSecurityPerimeterRuleType"/> values are not the same. </summary>
        public static bool operator !=(OperationalInsightsNetworkSecurityPerimeterRuleType left, OperationalInsightsNetworkSecurityPerimeterRuleType right) => !left.Equals(right);
    }
}
