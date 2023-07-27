// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Search.Documents
{
    /// <summary> Cloud audiences available for Search. </summary>
    public readonly partial struct SearchAudience : IEquatable<SearchAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchAudience"/> object.
        /// </summary>
        /// <param name="value">The Azure Active Directory audience to use when forming authorization scopes.For the Language service, this value corresponds to a URL that identifies the Azure cloud where the resource is located.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Please use one of the constant members over creating a custom value unless you have special needs for doing so.</remarks>
        public SearchAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://search.azure.cn";
        private const string AzureGovernmentValue = "https://search.azure.us";
        private const string AzurePublicCloudValue = "https://search.azure.com";

        /// <summary> Azure China. </summary>
        public static SearchAudience AzureChina { get; } = new SearchAudience(AzureChinaValue);

        /// <summary> Azure Government. </summary>
        public static SearchAudience AzureGovernment { get; } = new SearchAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static SearchAudience AzurePublicCloud { get; } = new SearchAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="SearchAudience"/> values are the same. </summary>
        public static bool operator ==(SearchAudience left, SearchAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SearchAudience"/> values are not the same. </summary>
        public static bool operator !=(SearchAudience left, SearchAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SearchAudience"/>. </summary>
        public static implicit operator SearchAudience(string value) => new SearchAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SearchAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SearchAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
