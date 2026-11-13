// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.OperationalInsights;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    // Backward-compatibility shim for the type name shipped in version 1.3.2.
    /// <summary> The provisioning state of a Summary Logs rule. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future release. Use OperationalInsightsSummaryLogsProvisioningState instead.", false)]
    public readonly partial struct OperationalInsightsNetworkSecurityPerimeterProvisioningState : IEquatable<OperationalInsightsNetworkSecurityPerimeterProvisioningState>
    {
        private readonly string _value;
        private const string UpdatingValue = "Updating";
        private const string SucceededValue = "Succeeded";
        private const string DeletingValue = "Deleting";
        private const string FailedValue = "Failed";
        private const string CanceledValue = "Canceled";

        /// <summary> Initializes a new instance of <see cref="OperationalInsightsNetworkSecurityPerimeterProvisioningState"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public OperationalInsightsNetworkSecurityPerimeterProvisioningState(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
        }

        /// <summary> The Summary Logs rule is updating. </summary>
        public static OperationalInsightsNetworkSecurityPerimeterProvisioningState Updating { get; } = new(UpdatingValue);

        /// <summary> The Summary Logs rule provisioning succeeded. </summary>
        public static OperationalInsightsNetworkSecurityPerimeterProvisioningState Succeeded { get; } = new(SucceededValue);

        /// <summary> The Summary Logs rule is deleting. </summary>
        public static OperationalInsightsNetworkSecurityPerimeterProvisioningState Deleting { get; } = new(DeletingValue);

        /// <summary> The Summary Logs rule provisioning failed. </summary>
        public static OperationalInsightsNetworkSecurityPerimeterProvisioningState Failed { get; } = new(FailedValue);

        /// <summary> The Summary Logs rule provisioning was canceled. </summary>
        public static OperationalInsightsNetworkSecurityPerimeterProvisioningState Canceled { get; } = new(CanceledValue);

        /// <summary> Converts a string to an <see cref="OperationalInsightsNetworkSecurityPerimeterProvisioningState"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator OperationalInsightsNetworkSecurityPerimeterProvisioningState(string value) => new(value);

        /// <summary> Converts a string to a nullable <see cref="OperationalInsightsNetworkSecurityPerimeterProvisioningState"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator OperationalInsightsNetworkSecurityPerimeterProvisioningState?(string value) => value is null ? null : new(value);

        /// <summary> Converts an <see cref="OperationalInsightsNetworkSecurityPerimeterProvisioningState"/> to an <see cref="OperationalInsightsSummaryLogsProvisioningState"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator OperationalInsightsSummaryLogsProvisioningState(OperationalInsightsNetworkSecurityPerimeterProvisioningState value) => value._value is null ? default : new(value._value);

        /// <summary> Converts an <see cref="OperationalInsightsSummaryLogsProvisioningState"/> to an <see cref="OperationalInsightsNetworkSecurityPerimeterProvisioningState"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator OperationalInsightsNetworkSecurityPerimeterProvisioningState(OperationalInsightsSummaryLogsProvisioningState value) => value.ToString() is string stringValue ? new(stringValue) : default;

        /// <inheritdoc/>
        public bool Equals(OperationalInsightsNetworkSecurityPerimeterProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OperationalInsightsNetworkSecurityPerimeterProvisioningState other && Equals(other);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value is null ? 0 : StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);

        /// <inheritdoc/>
        public override string ToString() => _value;

        /// <summary> Determines if two <see cref="OperationalInsightsNetworkSecurityPerimeterProvisioningState"/> values are the same. </summary>
        public static bool operator ==(OperationalInsightsNetworkSecurityPerimeterProvisioningState left, OperationalInsightsNetworkSecurityPerimeterProvisioningState right) => left.Equals(right);

        /// <summary> Determines if two <see cref="OperationalInsightsNetworkSecurityPerimeterProvisioningState"/> values are not the same. </summary>
        public static bool operator !=(OperationalInsightsNetworkSecurityPerimeterProvisioningState left, OperationalInsightsNetworkSecurityPerimeterProvisioningState right) => !left.Equals(right);
    }
}
