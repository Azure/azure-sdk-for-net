// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Azure.Core;

[assembly: CodeGenSuppressType("WebPubSubServiceClientOptions")]

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Messaging.WebPubSub
{
    /// <summary> Provides the client configuration options for connecting to Azure WebPubSub service. </summary>
    public partial class WebPubSubServiceClientOptions : ClientOptions
    {
        /// <summary>
        /// The name of the scope to authenticate for when creating a <see cref="Azure.Core.Pipeline.BearerTokenAuthenticationPolicy"/>
        /// </summary>
        internal const string CredentialScopeName = "https://webpubsub.azure.com/.default";

        /// <summary>
        /// The versions of Azure WebPubSub supported by this client library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary> The 2021_10_01_stable version of the Azure WebPubSub service. </summary>
            V2021_10_01 = 1,
            /// <summary>
            /// The 2024_01_01_stable version of the Azure WebPubSub service.
            /// </summary>
            V2024_01_01 = 2,
            /// <summary>
            /// The 2024_12_01_stable version of the Azure WebPubSub service.
            /// </summary>
            V2024_12_01 = 3,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// The Latest <see cref="ServiceVersion"/> supported by this client library.
        /// </summary>
        private const ServiceVersion LatestVersion = ServiceVersion.V2024_12_01;

        /// <summary>
        /// Gets the version of the service API used when making requests.
        /// </summary>
        internal string Version { get; }

        /// <summary>
        /// Gets the version enum of the service API used when making requests.
        /// </summary>
        internal ServiceVersion VersionEnum { get; }

        /// <summary> Initializes a new instance of the <see cref="WebPubSubServiceClientOptions"/>. </summary>
        /// <param name="version">
        /// An optional <see cref="ServiceVersion"/> to specify the version of the REST API to use.
        /// If not provided, the <paramref name="version"/> will default to the latest supported by this client library.
        /// It is recommended that application authors allow the version to float to the latest and
        /// library authors pin to a specific version.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="version"/> is not supported by this client library.
        /// </exception>
        public WebPubSubServiceClientOptions(ServiceVersion version = LatestVersion)
        {
            VersionEnum = version;
            Version = version.ToVersionString();
        }
    }

    /// <summary>
    /// WebPubSub extension methods.
    /// </summary>
    internal static partial class WebPubSubExtensions
    {
        /// <summary>
        /// Gets a version string, like "2021-05-01-preview", corresponding to a given <see cref="WebPubSubServiceClientOptions.ServiceVersion"/> value.
        /// </summary>
        /// <param name="version">
        /// The <see cref="WebPubSubServiceClientOptions.ServiceVersion"/> value to convert into a version string.
        /// </param>
        /// <returns> The version string. </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="version"/> is not supported by this client library.
        /// </exception>
        public static string ToVersionString(this WebPubSubServiceClientOptions.ServiceVersion version) =>
            version switch
            {
                WebPubSubServiceClientOptions.ServiceVersion.V2021_10_01 => "2021-10-01",
                WebPubSubServiceClientOptions.ServiceVersion.V2024_01_01 => "2024-01-01",
                WebPubSubServiceClientOptions.ServiceVersion.V2024_12_01 => "2024-12-01",
                _ => throw CreateInvalidVersionException(version)
            };

        /// <summary>
        /// Creates an <see cref="ArgumentOutOfRangeException"/> to throw when
        /// an invalid <see cref="WebPubSubServiceClientOptions.ServiceVersion"/> value is provided.
        /// </summary>
        /// <param name="version">The invalid version value.</param>
        /// <returns>An exception to throw.</returns>
        private static ArgumentOutOfRangeException CreateInvalidVersionException(WebPubSubServiceClientOptions.ServiceVersion version) =>
            new ArgumentOutOfRangeException(
                nameof(version),
                version,
                $"The {nameof(WebPubSubServiceClientOptions)}.{nameof(WebPubSubServiceClientOptions.ServiceVersion)} specified is not supported by this library.");
    }
}
