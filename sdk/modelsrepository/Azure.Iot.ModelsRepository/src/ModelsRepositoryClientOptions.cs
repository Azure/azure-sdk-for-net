// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.Core;

namespace Azure.Iot.ModelsRepository
{
    /// <summary>
    /// Options that allow configuration of requests sent to the ModelRepositoryService.
    /// </summary>
    public class ModelsRepositoryClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2021_02_11;

        /// <summary>
        /// The versions of Azure IoT Models Repository service supported by this client.
        /// library.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// 2021_02_11
            /// </summary>
            [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
            V2021_02_11 = 1
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelsRepositoryClientOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        /// <param name="dependencyResolution">The model dependency processing options.</param>
        public ModelsRepositoryClientOptions(
            ServiceVersion version = LatestVersion,
            ModelDependencyResolution dependencyResolution = ModelDependencyResolution.Enabled)
        {
            DependencyResolution = dependencyResolution;
            Version = version;
        }

        /// <summary>
        /// The model dependency processing options.
        /// </summary>
        public ModelDependencyResolution DependencyResolution { get; }
    }
}
