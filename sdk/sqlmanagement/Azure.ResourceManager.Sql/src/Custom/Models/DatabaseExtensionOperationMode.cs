// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct DatabaseExtensionOperationMode : IEquatable<DatabaseExtensionOperationMode>
    {
        private readonly string _value;

        public DatabaseExtensionOperationMode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PolybaseImportValue = "PolybaseImport";
        private const string ImportValue = "Import";
        private const string ExportValue = "Export";

        public static DatabaseExtensionOperationMode PolybaseImport { get; } = new DatabaseExtensionOperationMode(PolybaseImportValue);
        public static DatabaseExtensionOperationMode Import { get; } = new DatabaseExtensionOperationMode(ImportValue);
        public static DatabaseExtensionOperationMode Export { get; } = new DatabaseExtensionOperationMode(ExportValue);

        public static bool operator ==(DatabaseExtensionOperationMode left, DatabaseExtensionOperationMode right) => left.Equals(right);
        public static bool operator !=(DatabaseExtensionOperationMode left, DatabaseExtensionOperationMode right) => !left.Equals(right);
        public static implicit operator DatabaseExtensionOperationMode(string value) => new DatabaseExtensionOperationMode(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DatabaseExtensionOperationMode other && Equals(other);

        public bool Equals(DatabaseExtensionOperationMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        public override string ToString() => _value;
    }
}
