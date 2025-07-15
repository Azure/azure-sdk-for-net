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
        // name after the `name` property of returned audience from https://management.azure.com/metadata/endpoints?api-version=2019-11-01
        /// <summary> Azure Public Cloud. </summary>
        public static readonly ArmEnvironment AzurePublicCloud = new(new Uri("https://management.azure.com"), "https://management.azure.com/");

        /// <summary> Azure China Cloud. </summary>
        public static readonly ArmEnvironment AzureChina = new(new Uri("https://management.chinacloudapi.cn"), "https://management.chinacloudapi.cn");

        /// <summary> Azure US Government. </summary>
        public static readonly ArmEnvironment AzureGovernment = new(new Uri("https://management.usgovcloudapi.net"), "https://management.usgovcloudapi.net");

        /// <summary> Azure German Cloud. </summary>
        public static readonly ArmEnvironment AzureGermany = new(new Uri("https://management.microsoftazure.de"), "https://management.microsoftazure.de");

        /// <summary>
        /// Gets base URI of the management API endpoint.
        /// </summary>
        public readonly Uri Endpoint { get; }

        /// <summary>
        /// Gets authentication audience.
        /// </summary>
        public readonly string Audience { get; }

        /// <summary>
        /// Gets default authentication scope.
        /// </summary>
        public string DefaultScope { get; }

        /// <summary>
        /// Construct an <see cref="ArmEnvironment"/> using the given value.
        /// </summary>
        /// <param name="endpoint">Management API endpoint base URI.</param>
        /// <param name="audience">Authentication audience.</param>
        public ArmEnvironment(Uri endpoint, string audience)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrWhiteSpace(audience, nameof(audience));

            Endpoint = endpoint;
            Audience = audience;
            DefaultScope = $"{Audience}/.default";
        }

        /// <summary> Determines if two <see cref="ArmEnvironment"/> values are the same. </summary>
        public static bool operator ==(ArmEnvironment left, ArmEnvironment right) => left.Equals(right);

        /// <summary> Determines if two <see cref="ArmEnvironment"/> values are not the same. </summary>internal
        public static bool operator !=(ArmEnvironment left, ArmEnvironment right) => !left.Equals(right);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ArmEnvironment other && Equals(other);

        /// <inheritdoc />
        public bool Equals(ArmEnvironment other) => string.Equals(Audience, other.Audience, StringComparison.Ordinal) && Endpoint.Equals(other.Endpoint);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return HashCodeBuilder.Combine(Endpoint, Audience);
        }

        /// <inheritdoc />
        public override string ToString() => JsonSerializer.Serialize(this, ArmEnvironmentJsonContext.Default.ArmEnvironment);
    }
}
