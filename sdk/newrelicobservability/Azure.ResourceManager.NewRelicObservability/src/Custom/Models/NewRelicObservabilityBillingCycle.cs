// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NewRelicObservability.Models
{
    /// <summary> Different usage type like YEARLY/MONTHLY. </summary>
    public readonly partial struct NewRelicObservabilityBillingCycle : IEquatable<NewRelicObservabilityBillingCycle>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NewRelicObservabilityBillingCycle"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public NewRelicObservabilityBillingCycle(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string YearlyValue = "YEARLY";
        private const string MonthlyValue = "MONTHLY";
        private const string WeeklyValue = "WEEKLY";

        /// <summary> Billing cycle is YEARLY. </summary>
        public static NewRelicObservabilityBillingCycle Yearly { get; } = new NewRelicObservabilityBillingCycle(YearlyValue);
        /// <summary> Billing cycle is MONTHLY. </summary>
        public static NewRelicObservabilityBillingCycle Monthly { get; } = new NewRelicObservabilityBillingCycle(MonthlyValue);
        /// <summary> Billing cycle is WEEKLY. </summary>
        public static NewRelicObservabilityBillingCycle Weekly { get; } = new NewRelicObservabilityBillingCycle(WeeklyValue);
        /// <summary> Determines if two <see cref="NewRelicObservabilityBillingCycle"/> values are the same. </summary>
        public static bool operator ==(NewRelicObservabilityBillingCycle left, NewRelicObservabilityBillingCycle right) => left.Equals(right);
        /// <summary> Determines if two <see cref="NewRelicObservabilityBillingCycle"/> values are not the same. </summary>
        public static bool operator !=(NewRelicObservabilityBillingCycle left, NewRelicObservabilityBillingCycle right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="NewRelicObservabilityBillingCycle"/>. </summary>
        public static implicit operator NewRelicObservabilityBillingCycle(string value) => new NewRelicObservabilityBillingCycle(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NewRelicObservabilityBillingCycle other && Equals(other);
        /// <inheritdoc />
        public bool Equals(NewRelicObservabilityBillingCycle other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
