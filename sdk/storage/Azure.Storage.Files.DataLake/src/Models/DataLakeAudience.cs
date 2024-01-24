// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Audiences available for Blobs
    /// </summary>
    public readonly partial struct DataLakeAudience : IEquatable<DataLakeAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Intializes new instance of <see cref="DataLakeAudience"/>.
        /// </summary>
        /// <param name="value">
        /// The Azure Active Directory audience to use when forming authorization scopes.
        /// For the Language service, this value corresponds to a URL that identifies the Azure cloud where the resource is located.
        /// For more information: <see href="https://learn.microsoft.com/en-us/azure/storage/blobs/authorize-access-azure-active-directory" />.
        /// </param>
        /// <remarks>Please use one of the static constant members over creating a custom value unless you have specific scenario for doing so.</remarks>
        public DataLakeAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string _defaultAudience = "https://storage.azure.com/";

        /// <summary>
        /// Default Audience. Use to acquire a token for authorizing requests to any Azure Storage account
        ///
        /// Resource ID: &quot;https://storage.azure.com/ &quot;.
        ///
        /// If no audience is specified, this is the default value.
        /// </summary>
        public static DataLakeAudience DefaultAudience { get; } = new(_defaultAudience);

        /// <summary>
        /// The service endpoint for a given storage account.
        /// Use this method to acquire a token for authorizing requests to that specific Azure Storage account and service only.
        /// </summary>
        /// <param name="storageAccountName">
        /// The storage account name used to populate the service endpoint.
        /// </param>
        /// <returns></returns>
        public static DataLakeAudience CreateDataLakeServiceAccountAudience(string storageAccountName) => new($"https://{storageAccountName}.blob.core.windows.net/");

        /// <summary> Determines if two <see cref="DataLakeAudience"/> values are the same. </summary>
        public static bool operator ==(DataLakeAudience left, DataLakeAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DataLakeAudience"/> values are not the same. </summary>
        public static bool operator !=(DataLakeAudience left, DataLakeAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DataLakeAudience"/>. </summary>
        public static implicit operator DataLakeAudience(string value) => new DataLakeAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DataLakeAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DataLakeAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;

        /// <summary>
        /// Creates a scope with the respective audience and the default scope.
        /// </summary>
        /// <returns></returns>
        internal string CreateDefaultScope()
        {
            if (_value.EndsWith("/", StringComparison.InvariantCultureIgnoreCase))
            {
                return $"{(_value)}{Constants.DefaultScope}";
            }
            return $"{(_value)}/{Constants.DefaultScope}";
        }
    }
}
