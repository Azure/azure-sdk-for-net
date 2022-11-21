// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The add participants operation options.
    /// </summary>
    /// <summary> The type of transport to be used for media streaming, eg. Websocket. </summary>
    public readonly partial struct NluRecognizer : IEquatable<NluRecognizer>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NluRecognizer"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public NluRecognizer(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NuanceValue = "nuance";
        private const string LuisValue = "luis";

        /// <summary> nuance. </summary>
        public static NluRecognizer Nuance { get; } = new NluRecognizer(NuanceValue);
        /// <summary> luis. </summary>
        public static NluRecognizer Luis { get; } = new NluRecognizer(LuisValue);
        /// <summary> Determines if two <see cref="NluRecognizer"/> values are the same. </summary>
        public static bool operator ==(NluRecognizer left, NluRecognizer right) => left.Equals(right);
        /// <summary> Determines if two <see cref="NluRecognizer"/> values are not the same. </summary>
        public static bool operator !=(NluRecognizer left, NluRecognizer right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="NluRecognizer"/>. </summary>
        public static implicit operator NluRecognizer(string value) => new NluRecognizer(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NluRecognizer other && Equals(other);
        /// <inheritdoc />
        public bool Equals(NluRecognizer other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
