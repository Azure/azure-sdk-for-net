// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary>
    /// Backward-compat type alias. Old name was UpdateSummariesPropertiesState, renamed to HciClusterUpdateState.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateState` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct UpdateSummariesPropertiesState : IEquatable<UpdateSummariesPropertiesState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="UpdateSummariesPropertiesState"/>. </summary>
        public UpdateSummariesPropertiesState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary> Unknown. </summary>
        public static UpdateSummariesPropertiesState Unknown { get; } = new UpdateSummariesPropertiesState("Unknown");
        /// <summary> AppliedSuccessfully. </summary>
        public static UpdateSummariesPropertiesState AppliedSuccessfully { get; } = new UpdateSummariesPropertiesState("AppliedSuccessfully");
        /// <summary> UpdateAvailable. </summary>
        public static UpdateSummariesPropertiesState UpdateAvailable { get; } = new UpdateSummariesPropertiesState("UpdateAvailable");
        /// <summary> UpdateInProgress. </summary>
        public static UpdateSummariesPropertiesState UpdateInProgress { get; } = new UpdateSummariesPropertiesState("UpdateInProgress");
        /// <summary> UpdateFailed. </summary>
        public static UpdateSummariesPropertiesState UpdateFailed { get; } = new UpdateSummariesPropertiesState("UpdateFailed");
        /// <summary> NeedsAttention. </summary>
        public static UpdateSummariesPropertiesState NeedsAttention { get; } = new UpdateSummariesPropertiesState("NeedsAttention");
        /// <summary> PreparationInProgress. </summary>
        public static UpdateSummariesPropertiesState PreparationInProgress { get; } = new UpdateSummariesPropertiesState("PreparationInProgress");
        /// <summary> PreparationFailed. </summary>
        public static UpdateSummariesPropertiesState PreparationFailed { get; } = new UpdateSummariesPropertiesState("PreparationFailed");

        /// <summary> Converts a string to <see cref="UpdateSummariesPropertiesState"/>. </summary>
        public static implicit operator UpdateSummariesPropertiesState(string value) => new UpdateSummariesPropertiesState(value);

        /// <summary> Converts to HciClusterUpdateState. </summary>
        public static implicit operator HciClusterUpdateState(UpdateSummariesPropertiesState value) => new HciClusterUpdateState(value._value);

        /// <summary> Converts from HciClusterUpdateState. </summary>
        public static implicit operator UpdateSummariesPropertiesState(HciClusterUpdateState value) => new UpdateSummariesPropertiesState(value.ToString());

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

        /// <summary> Equality operator. </summary>
        public static bool operator ==(UpdateSummariesPropertiesState left, UpdateSummariesPropertiesState right) => left.Equals(right);

        /// <summary> Inequality operator. </summary>
        public static bool operator !=(UpdateSummariesPropertiesState left, UpdateSummariesPropertiesState right) => !left.Equals(right);
    }
}
