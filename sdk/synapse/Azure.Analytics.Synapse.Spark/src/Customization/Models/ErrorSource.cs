// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;

namespace Azure.Analytics.Synapse.Spark.Models
{
    /// <summary> The ErrorSource. </summary>
    [CodeGenModel("SparkErrorSource")]
    public readonly partial struct SparkErrorSource : IEquatable<SparkErrorSource>
    {
        /// <summary> Determines if two <see cref="SparkErrorSource"/> values are the same. </summary>
        public SparkErrorSource(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SystemValue = "System";
        private const string UserValue = "User";
        private const string UnknownValue = "Unknown";
        private const string DependencyValue = "Dependency";

        /// <summary> System. </summary>
        [CodeGenMember("System")]
        public static SparkErrorSource SystemError { get; } = new SparkErrorSource(SystemValue);
        /// <summary> User. </summary>
        [CodeGenMember("User")]
        public static SparkErrorSource UserError { get; } = new SparkErrorSource(UserValue);
        /// <summary> Unknown. </summary>
        [CodeGenMember("Unknown")]
        public static SparkErrorSource UnknownError { get; } = new SparkErrorSource(UnknownValue);
        /// <summary> Dependency. </summary>
        [CodeGenMember("Dependency")]
        public static SparkErrorSource DependencyError { get; } = new SparkErrorSource(DependencyValue);

        /// <inheritdoc />
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SparkErrorSource other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SparkErrorSource other) => string.Equals(_value, other._value, System.StringComparison.Ordinal);

        /// <inheritdoc />
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
