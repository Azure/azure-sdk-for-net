// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> format for the workspace connection value. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct MachineLearningValueFormat : IEquatable<MachineLearningValueFormat>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MachineLearningValueFormat"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MachineLearningValueFormat(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string JsonValue = "JSON";

        /// <summary> JSON. </summary>
        public static MachineLearningValueFormat Json { get; } = new MachineLearningValueFormat(JsonValue);
        /// <summary> Determines if two <see cref="MachineLearningValueFormat"/> values are the same. </summary>
        public static bool operator ==(MachineLearningValueFormat left, MachineLearningValueFormat right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MachineLearningValueFormat"/> values are not the same. </summary>
        public static bool operator !=(MachineLearningValueFormat left, MachineLearningValueFormat right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MachineLearningValueFormat"/>. </summary>
        public static implicit operator MachineLearningValueFormat(string value) => new MachineLearningValueFormat(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MachineLearningValueFormat other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MachineLearningValueFormat other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
