// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> Legacy VM Insights onboarding status. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public readonly partial struct OnboardingStatus : IEquatable<OnboardingStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="OnboardingStatus"/>. </summary>
        public OnboardingStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary> Onboarded. </summary>
        public static OnboardingStatus Onboarded { get; } = new OnboardingStatus("Onboarded");

        /// <summary> NotOnboarded. </summary>
        public static OnboardingStatus NotOnboarded { get; } = new OnboardingStatus("NotOnboarded");

        /// <summary> Unknown. </summary>
        public static OnboardingStatus Unknown { get; } = new OnboardingStatus("Unknown");

        /// <inheritdoc/>
        public bool Equals(OnboardingStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is OnboardingStatus other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;

        /// <summary> Converts a string to <see cref="OnboardingStatus"/>. </summary>
        public static implicit operator OnboardingStatus(string value) => new OnboardingStatus(value);

        /// <summary> Determines if two values are equal. </summary>
        public static bool operator ==(OnboardingStatus left, OnboardingStatus right) => left.Equals(right);

        /// <summary> Determines if two values are not equal. </summary>
        public static bool operator !=(OnboardingStatus left, OnboardingStatus right) => !left.Equals(right);
    }
}