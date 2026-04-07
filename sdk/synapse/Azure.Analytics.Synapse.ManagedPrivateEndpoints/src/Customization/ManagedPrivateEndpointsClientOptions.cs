// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

[assembly: Azure.Core.CodeGenSuppressTypeAttribute("ManagedPrivateEndpointsClientOptions")]

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Analytics.Synapse.ManagedPrivateEndpoints
{
    /// <summary> Provides the client configuration options for connecting to Azure Synapse Managed Private Endpoints service. </summary>
    public partial class ManagedPrivateEndpointsClientOptions : ClientOptions
    {
        /// <summary>
        /// The versions of Azure Synapse supported by this client library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The 2020_12_01 version of the Azure Synapse Managed Private Endpoints service.
            /// </summary>
            V2020_12_01 = 1
#pragma warning restore CA1707
        }

        /// <summary>
        /// The Latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2020_12_01;

        /// <summary>
        /// Gets the version of the service API used when making requests.
        /// </summary>
        internal string Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedPrivateEndpointsClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// An optional <see cref="ServiceVersion"/> to specify the version of
        /// the REST API to use.
        /// If not provided, the <paramref name="version"/> will default to the
        /// latest supported by this client library.  It is recommended that
        /// application authors allow the version to float to the latest and
        /// library authors pin to a specific version.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="version"/> is not supported by this
        /// client library.
        /// </exception>
        public ManagedPrivateEndpointsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version.Validate().ToVersionString();
        }
    }

    /// <summary>
    /// Synapse Artifacts extension methods.
    /// </summary>
    internal static partial class SynapseArtifactsExtensions
    {
        /// <summary>
        /// Validate a <see cref="ManagedPrivateEndpointsClientOptions.ServiceVersion"/>.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ManagedPrivateEndpointsClientOptions.ServiceVersion"/> to validate.
        /// </param>
        /// <returns>
        /// The validated version.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="version"/> is not supported by this
        /// client library.
        /// </exception>
        public static ManagedPrivateEndpointsClientOptions.ServiceVersion Validate(this ManagedPrivateEndpointsClientOptions.ServiceVersion version) =>
            version switch
            {
                ManagedPrivateEndpointsClientOptions.ServiceVersion.V2020_12_01 => version,
                _ => throw CreateInvalidVersionException(version)
            };

        /// <summary>
        /// Get a version string, like "2020-06-30", corresponding to a given
        /// <see cref="ManagedPrivateEndpointsClientOptions.ServiceVersion"/> value.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ManagedPrivateEndpointsClientOptions.ServiceVersion"/> value to
        /// convert into a version string.
        /// </param>
        /// <returns>
        /// The version string.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="version"/> is not supported by this
        /// client library.
        /// </exception>
        public static string ToVersionString(this ManagedPrivateEndpointsClientOptions.ServiceVersion version) =>
            version switch
            {
                ManagedPrivateEndpointsClientOptions.ServiceVersion.V2020_12_01 => "2020-12-01",
                _ => throw CreateInvalidVersionException(version)
            };

        /// <summary>
        /// Create an <see cref="ArgumentOutOfRangeException"/> to throw when
        /// an invalid <see cref="ManagedPrivateEndpointsClientOptions.ServiceVersion"/> value
        /// is provided.
        /// </summary>
        /// <param name="version">The invalid version value.</param>
        /// <returns>An exception to throw.</returns>
        private static ArgumentOutOfRangeException CreateInvalidVersionException(ManagedPrivateEndpointsClientOptions.ServiceVersion version) =>
            new ArgumentOutOfRangeException(
                nameof(version),
                version,
                $"The {nameof(ManagedPrivateEndpointsClientOptions)}.{nameof(ManagedPrivateEndpointsClientOptions.ServiceVersion)} specified is not supported by this library.");
    }
}
