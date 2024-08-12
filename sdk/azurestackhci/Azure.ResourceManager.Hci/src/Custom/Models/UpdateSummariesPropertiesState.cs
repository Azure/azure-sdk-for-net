// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary> Overall update state of the stamp. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateState` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct UpdateSummariesPropertiesState : IEquatable<UpdateSummariesPropertiesState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="UpdateSummariesPropertiesState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public UpdateSummariesPropertiesState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UnknownValue = "Unknown";
        private const string AppliedSuccessfullyValue = "AppliedSuccessfully";
        private const string UpdateAvailableValue = "UpdateAvailable";
        private const string UpdateInProgressValue = "UpdateInProgress";
        private const string UpdateFailedValue = "UpdateFailed";
        private const string NeedsAttentionValue = "NeedsAttention";
        private const string PreparationInProgressValue = "PreparationInProgress";
        private const string PreparationFailedValue = "PreparationFailed";

        /// <summary> Unknown. </summary>
        public static UpdateSummariesPropertiesState Unknown { get; } = new UpdateSummariesPropertiesState(UnknownValue);
        /// <summary> AppliedSuccessfully. </summary>
        public static UpdateSummariesPropertiesState AppliedSuccessfully { get; } = new UpdateSummariesPropertiesState(AppliedSuccessfullyValue);
        /// <summary> UpdateAvailable. </summary>
        public static UpdateSummariesPropertiesState UpdateAvailable { get; } = new UpdateSummariesPropertiesState(UpdateAvailableValue);
        /// <summary> UpdateInProgress. </summary>
        public static UpdateSummariesPropertiesState UpdateInProgress { get; } = new UpdateSummariesPropertiesState(UpdateInProgressValue);
        /// <summary> UpdateFailed. </summary>
        public static UpdateSummariesPropertiesState UpdateFailed { get; } = new UpdateSummariesPropertiesState(UpdateFailedValue);
        /// <summary> NeedsAttention. </summary>
        public static UpdateSummariesPropertiesState NeedsAttention { get; } = new UpdateSummariesPropertiesState(NeedsAttentionValue);
        /// <summary> PreparationInProgress. </summary>
        public static UpdateSummariesPropertiesState PreparationInProgress { get; } = new UpdateSummariesPropertiesState(PreparationInProgressValue);
        /// <summary> PreparationFailed. </summary>
        public static UpdateSummariesPropertiesState PreparationFailed { get; } = new UpdateSummariesPropertiesState(PreparationFailedValue);
        /// <summary> Determines if two <see cref="UpdateSummariesPropertiesState"/> values are the same. </summary>
        public static bool operator ==(UpdateSummariesPropertiesState left, UpdateSummariesPropertiesState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="UpdateSummariesPropertiesState"/> values are not the same. </summary>
        public static bool operator !=(UpdateSummariesPropertiesState left, UpdateSummariesPropertiesState right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="UpdateSummariesPropertiesState"/>. </summary>
        public static implicit operator UpdateSummariesPropertiesState(string value) => new UpdateSummariesPropertiesState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is UpdateSummariesPropertiesState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(UpdateSummariesPropertiesState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
