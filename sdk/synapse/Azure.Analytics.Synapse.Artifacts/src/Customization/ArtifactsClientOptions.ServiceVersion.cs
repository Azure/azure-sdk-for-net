// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//using System;
//using Azure.Core;

//#pragma warning disable SA1402 // File may only contain a single type

//namespace Azure.Analytics.Synapse.Artifacts
//{
//    /// <summary> Provides the client configuration options for connecting to Azure WebPubSub service. </summary>
//    public partial class ArtifactsClientOptions : ClientOptions
//    {
//        /// <summary>
//        /// The versions of Azure Synapse supported by this client library.
//        /// </summary>
//        public enum ServiceVersion
//        {
//#pragma warning disable CA1707 // Identifiers should not contain underscores
//            /// <summary>
//            /// The 2020_12_01 version of the Azure Synapse Artifacts service.
//            /// </summary>
//            V2020_12_01 = 1,

//            /// <summary>
//            /// The 2021_06_01_Preview version of the Azure Synapse Artifacts service.
//            /// </summary>
//            V2021_06_01_Preview = 2,
//#pragma warning restore CA1707
//        }

//        /// <summary>
//        /// The Latest service version supported by this client library.
//        /// </summary>
//        internal const ServiceVersion LatestVersion = ServiceVersion.V2021_06_01_Preview;

//        /// <summary>
//        /// Gets the version of the service API used when making requests.
//        /// </summary>
//        public ServiceVersion Version { get; }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="ArtifactsClientOptions"/>
//        /// class.
//        /// </summary>
//        /// <param name="version">
//        /// An optional <see cref="ServiceVersion"/> to specify the version of
//        /// the REST API to use.
//        /// If not provided, the <paramref name="version"/> will default to the
//        /// latest supported by this client library.  It is recommended that
//        /// application authors allow the version to float to the latest and
//        /// library authors pin to a specific version.
//        /// </param>
//        /// <exception cref="ArgumentOutOfRangeException">
//        /// Thrown when the <paramref name="version"/> is not supported by this
//        /// client library.
//        /// </exception>
//        public ArtifactsClientOptions(ServiceVersion version = LatestVersion)
//        {
//            Version = version.Validate();
//        }
//    }

//    /// <summary>
//    /// Synapse Artifacts extension methods.
//    /// </summary>
//    internal static partial class SynapseArtifactsExtensions
//    {
//        /// <summary>
//        /// Validate a <see cref="ArtifactsClientOptions.ServiceVersion"/>.
//        /// </summary>
//        /// <param name="version">
//        /// The <see cref="ArtifactsClientOptions.ServiceVersion"/> to validate.
//        /// </param>
//        /// <returns>
//        /// The validated version.
//        /// </returns>
//        /// <exception cref="ArgumentOutOfRangeException">
//        /// Thrown when the <paramref name="version"/> is not supported by this
//        /// client library.
//        /// </exception>
//        public static ArtifactsClientOptions.ServiceVersion Validate(this ArtifactsClientOptions.ServiceVersion version) =>
//            version switch
//            {
//                ArtifactsClientOptions.ServiceVersion.V2020_12_01 => version,
//                ArtifactsClientOptions.ServiceVersion.V2021_06_01_Preview => version,
//                _ => throw CreateInvalidVersionException(version)
//            };

//        /// <summary>
//        /// Get a version string, like "2020-06-30", corresponding to a given
//        /// <see cref="ArtifactsClientOptions.ServiceVersion"/> value.
//        /// </summary>
//        /// <param name="version">
//        /// The <see cref="ArtifactsClientOptions.ServiceVersion"/> value to
//        /// convert into a version string.
//        /// </param>
//        /// <returns>
//        /// The version string.
//        /// </returns>
//        /// <exception cref="ArgumentOutOfRangeException">
//        /// Thrown when the <paramref name="version"/> is not supported by this
//        /// client library.
//        /// </exception>
//        public static string ToVersionString(this ArtifactsClientOptions.ServiceVersion version) =>
//            version switch
//            {
//                ArtifactsClientOptions.ServiceVersion.V2020_12_01 => "2020-12-01",
//                ArtifactsClientOptions.ServiceVersion.V2021_06_01_Preview => "2021-06-01-preview",
//                _ => throw CreateInvalidVersionException(version)
//            };

//        /// <summary>
//        /// Create an <see cref="ArgumentOutOfRangeException"/> to throw when
//        /// an invalid <see cref="ArtifactsClientOptions.ServiceVersion"/> value
//        /// is provided.
//        /// </summary>
//        /// <param name="version">The invalid version value.</param>
//        /// <returns>An exception to throw.</returns>
//        private static ArgumentOutOfRangeException CreateInvalidVersionException(ArtifactsClientOptions.ServiceVersion version) =>
//            new ArgumentOutOfRangeException(
//                nameof(version),
//                version,
//                $"The {nameof(ArtifactsClientOptions)}.{nameof(ArtifactsClientOptions.ServiceVersion)} specified is not supported by this library.");
//    }
//}
