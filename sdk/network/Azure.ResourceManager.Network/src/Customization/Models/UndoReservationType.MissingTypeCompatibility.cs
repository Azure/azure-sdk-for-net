// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> A compatibility type for the former undo reservation values. </summary>
    public readonly partial struct UndoReservationType : IEquatable<UndoReservationType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="UndoReservationType"/>. </summary>
        /// <param name="value"> The value. </param>
        public UndoReservationType(string value)
        {
            _value = value;
        }

        /// <summary> False. </summary>
        public static UndoReservationType False { get; } = new UndoReservationType("False");

        /// <summary> True. </summary>
        public static UndoReservationType True { get; } = new UndoReservationType("True");

        /// <inheritdoc/>
        public bool Equals(UndoReservationType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is UndoReservationType other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <summary> Compares two <see cref="UndoReservationType"/> values for equality. </summary>
        public static bool operator ==(UndoReservationType left, UndoReservationType right) => left.Equals(right);

        /// <summary> Converts a string to a <see cref="UndoReservationType"/>. </summary>
        public static implicit operator UndoReservationType(string value) => new UndoReservationType(value);

        /// <summary> Compares two <see cref="UndoReservationType"/> values for inequality. </summary>
        public static bool operator !=(UndoReservationType left, UndoReservationType right) => !left.Equals(right);

        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
}
