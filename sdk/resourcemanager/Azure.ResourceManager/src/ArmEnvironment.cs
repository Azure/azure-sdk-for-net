// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager
{
    /// <summary>
    /// ArmEnvrionment represents the information of an Azure Cloud environment.
    /// </summary>
    public readonly struct ArmEnvironment : IEquatable<ArmEnvironment>
    {
        private static readonly Uri _defaultBaseUri = new Uri("https://management.azure.com");
        private const string _defaultAudience = "https://management.azure.com/";

        // name after the `name` property of returned audience from https://management.azure.com/metadata/endpoints?api-version=2019-11-01
        /// <summary> Azure Public Cloud. </summary>
        public static readonly ArmEnvironment AzureCloud = new(_defaultBaseUri, _defaultAudience);

        /// <summary> Azure China Cloud. </summary>
        public static readonly ArmEnvironment AzureChinaCloud = new(new Uri("https://management.chinacloudapi.cn"), "https://management.chinacloudapi.cn");

        /// <summary> Azure US Government. </summary>
        public static readonly ArmEnvironment AzureUSGovernment = new(new Uri("https://management.usgovcloudapi.net"), "https://management.usgovcloudapi.net");

        /// <summary> Azure German Cloud. </summary>
        public static readonly ArmEnvironment AzureGermanCloud = new(new Uri("https://management.microsoftazure.de"), "https://management.microsoftazure.de");

        /// <summary>
        /// Base URI of the management API endpoint.
        /// </summary>
        public readonly Uri BaseUri { get => _baseUri ?? _defaultBaseUri; }
        /// <summary>
        /// Authentication audience.
        /// </summary>
        public readonly string Audience { get => _audience ?? _defaultAudience; }
        /// <summary>
        /// Default authentication scope.
        /// </summary>
        public string DefaultScope => GetScope(".default");

        private readonly Uri _baseUri;
        private readonly string _audience;

        /// <summary>
        /// Construct an <see cref="ArmEnvironment"/> using the given value.
        /// </summary>
        /// <param name="baseUri">Management API endpoint base URI.</param>
        /// <param name="audience">Authentication audience.</param>
        public ArmEnvironment(Uri baseUri, string audience)
        {
            Argument.AssertNotNull(baseUri, nameof(baseUri));
            Argument.AssertNotNullOrWhiteSpace(audience, nameof(audience));

            _baseUri = baseUri;
            _audience = audience;
        }

        private string GetScope(string permission)
        {
            return $"{Audience}/{permission}";
        }

        /// <summary> Determines if two <see cref="ArmEnvironment"/> values are the same. </summary>
        public static bool operator ==(ArmEnvironment left, ArmEnvironment right) => left.Equals(right);

        /// <summary> Determines if two <see cref="ArmEnvironment"/> values are not the same. </summary>internal
        public static bool operator !=(ArmEnvironment left, ArmEnvironment right) => !left.Equals(right);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ArmEnvironment other && Equals(other);

        /// <inheritdoc />
        public bool Equals(ArmEnvironment other) => string.Equals(Audience, other.Audience, StringComparison.Ordinal) && BaseUri.Equals(other.BaseUri);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + BaseUri.GetHashCode();
            hash = hash * 23 + Audience.GetHashCode();
            return hash;
        }

        /// <inheritdoc />
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
