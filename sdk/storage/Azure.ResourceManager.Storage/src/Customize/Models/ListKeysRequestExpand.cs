// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: New extensible enum with implicit conversions to/from old
// StorageListKeyExpand type. Bridges the type rename from prior GA.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct ListKeysRequestExpand
    {
        // Workaround for a regression in @typespec/http-client-csharp 1.0.0-alpha.20260506.3
        // (introduced by https://github.com/microsoft/typespec/pull/10584,
        // tracked by https://github.com/microsoft/typespec/issues/10649,
        // picked up here via https://github.com/Azure/azure-sdk-for-net/pull/59170):
        // anonymous inline-union operation-parameter enums are emitted twice in tspCodeModel.json,
        // causing the C# generator to drop the struct body partial
        // (field/ctor/named values/Equals/GetHashCode/ToString) and emit only the
        // operators/conversions partial, breaking the build. Re-declare the missing members
        // here. Remove once the upstream fix lands in a new mgmt-emitter alpha.
        private readonly string _value;
        private const string KerbValue = "kerb";

        /// <summary> Initializes a new instance of <see cref="ListKeysRequestExpand"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ListKeysRequestExpand(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary> Gets the Kerb. </summary>
        public static ListKeysRequestExpand Kerb { get; } = new ListKeysRequestExpand(KerbValue);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ListKeysRequestExpand other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ListKeysRequestExpand other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;

        // Backward-compatible: Converts to StorageListKeyExpand.
        public static implicit operator StorageListKeyExpand(ListKeysRequestExpand value) => new StorageListKeyExpand(value._value);
        // Backward-compatible: Converts from StorageListKeyExpand.
        public static implicit operator ListKeysRequestExpand(StorageListKeyExpand value) => new ListKeysRequestExpand(value.ToString());
    }

    // Backward-compatible alias for ListKeysRequestExpand.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct StorageListKeyExpand : IEquatable<StorageListKeyExpand>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StorageListKeyExpand"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StorageListKeyExpand(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string KerbValue = "kerb";

        /// <summary> kerb. </summary>
        public static StorageListKeyExpand Kerb { get; } = new StorageListKeyExpand(KerbValue);

        /// <summary> Determines if two <see cref="StorageListKeyExpand"/> values are the same. </summary>
        public static bool operator ==(StorageListKeyExpand left, StorageListKeyExpand right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StorageListKeyExpand"/> values are not the same. </summary>
        public static bool operator !=(StorageListKeyExpand left, StorageListKeyExpand right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="StorageListKeyExpand"/>. </summary>
        public static implicit operator StorageListKeyExpand(string value) => new StorageListKeyExpand(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StorageListKeyExpand other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StorageListKeyExpand other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
