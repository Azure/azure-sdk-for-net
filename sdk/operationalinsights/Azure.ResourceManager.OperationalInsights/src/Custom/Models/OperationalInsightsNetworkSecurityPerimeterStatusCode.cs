// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.OperationalInsights;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    // Backward-compatibility shim for the type name shipped in version 1.3.2.
    /// <summary> Indicates the reason for rule deactivation. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future release. Use OperationalInsightsSummaryLogsStatusCode instead.", false)]
    public readonly partial struct OperationalInsightsNetworkSecurityPerimeterStatusCode : IEquatable<OperationalInsightsNetworkSecurityPerimeterStatusCode>
    {
        private readonly string _value;
        private const string UserActionValue = "UserAction";
        private const string DataPlaneErrorValue = "DataPlaneError";

        /// <summary> Initializes a new instance of <see cref="OperationalInsightsNetworkSecurityPerimeterStatusCode"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public OperationalInsightsNetworkSecurityPerimeterStatusCode(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
        }

        /// <summary> Summary rule stop originated from a user action (Stop was called). </summary>
        public static OperationalInsightsNetworkSecurityPerimeterStatusCode UserAction { get; } = new(UserActionValue);

        /// <summary> Summary rule stop was caused due to data plane related error. </summary>
        public static OperationalInsightsNetworkSecurityPerimeterStatusCode DataPlaneError { get; } = new(DataPlaneErrorValue);

        /// <summary> Converts a string to an <see cref="OperationalInsightsNetworkSecurityPerimeterStatusCode"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator OperationalInsightsNetworkSecurityPerimeterStatusCode(string value) => new(value);

        /// <summary> Converts a string to a nullable <see cref="OperationalInsightsNetworkSecurityPerimeterStatusCode"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator OperationalInsightsNetworkSecurityPerimeterStatusCode?(string value) => value is null ? null : new(value);

        /// <summary> Converts an <see cref="OperationalInsightsNetworkSecurityPerimeterStatusCode"/> to an <see cref="OperationalInsightsSummaryLogsStatusCode"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator OperationalInsightsSummaryLogsStatusCode(OperationalInsightsNetworkSecurityPerimeterStatusCode value) => value._value is null ? default : new(value._value);

        /// <summary> Converts an <see cref="OperationalInsightsSummaryLogsStatusCode"/> to an <see cref="OperationalInsightsNetworkSecurityPerimeterStatusCode"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator OperationalInsightsNetworkSecurityPerimeterStatusCode(OperationalInsightsSummaryLogsStatusCode value) => value.ToString() is string stringValue ? new(stringValue) : default;

        /// <inheritdoc/>
        public bool Equals(OperationalInsightsNetworkSecurityPerimeterStatusCode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OperationalInsightsNetworkSecurityPerimeterStatusCode other && Equals(other);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value is null ? 0 : StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);

        /// <inheritdoc/>
        public override string ToString() => _value;

        /// <summary> Determines if two <see cref="OperationalInsightsNetworkSecurityPerimeterStatusCode"/> values are the same. </summary>
        public static bool operator ==(OperationalInsightsNetworkSecurityPerimeterStatusCode left, OperationalInsightsNetworkSecurityPerimeterStatusCode right) => left.Equals(right);

        /// <summary> Determines if two <see cref="OperationalInsightsNetworkSecurityPerimeterStatusCode"/> values are not the same. </summary>
        public static bool operator !=(OperationalInsightsNetworkSecurityPerimeterStatusCode left, OperationalInsightsNetworkSecurityPerimeterStatusCode right) => !left.Equals(right);
    }
}
