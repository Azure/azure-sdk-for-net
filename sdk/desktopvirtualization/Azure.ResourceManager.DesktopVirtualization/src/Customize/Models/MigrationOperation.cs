// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    /// <summary> The type of operation for migration. </summary>
    [Obsolete("This struct is obsolete and will be removed in a future release", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct MigrationOperation : IEquatable<MigrationOperation>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MigrationOperation"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MigrationOperation(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string StartValue = "Start";
        private const string RevokeValue = "Revoke";
        private const string CompleteValue = "Complete";
        private const string HideValue = "Hide";
        private const string UnhideValue = "Unhide";

        /// <summary> Start the migration. </summary>
        public static MigrationOperation Start { get; } = new MigrationOperation(StartValue);
        /// <summary> Revoke the migration. </summary>
        public static MigrationOperation Revoke { get; } = new MigrationOperation(RevokeValue);
        /// <summary> Complete the migration. </summary>
        public static MigrationOperation Complete { get; } = new MigrationOperation(CompleteValue);
        /// <summary> Hide the hostpool. </summary>
        public static MigrationOperation Hide { get; } = new MigrationOperation(HideValue);
        /// <summary> Unhide the hostpool. </summary>
        public static MigrationOperation Unhide { get; } = new MigrationOperation(UnhideValue);
        /// <summary> Determines if two <see cref="MigrationOperation"/> values are the same. </summary>
        public static bool operator ==(MigrationOperation left, MigrationOperation right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MigrationOperation"/> values are not the same. </summary>
        public static bool operator !=(MigrationOperation left, MigrationOperation right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MigrationOperation"/>. </summary>
        public static implicit operator MigrationOperation(string value) => new MigrationOperation(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MigrationOperation other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MigrationOperation other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
