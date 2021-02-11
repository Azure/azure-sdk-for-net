// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Iot.ModelsRepository
{
    /// <summary>
    /// Options that allow configuration of requests sent to the ModelRepositoryService.
    /// </summary>
    public class ResolverClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2021_02_11;

        /// <summary>
        /// The versions of Azure Digital Twins supported by this client
        /// library.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// 2021_02_11
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
            V2021_02_11 = 1
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResolverClientOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        /// <param name="resolutionOption">The dependency processing options.</param>
        public ResolverClientOptions(ServiceVersion version = LatestVersion, DependencyResolutionOption resolutionOption = DependencyResolutionOption.Enabled)
        {
            DependencyResolution = resolutionOption;
            Version = version;
        }

        /// <summary>
        /// The dependency processing options.
        /// </summary>
        public DependencyResolutionOption DependencyResolution { get; }
    }

    /// <summary>
    /// The dependency processing options.
    /// </summary>
    public enum DependencyResolutionOption
    {
        /// <summary>
        /// Do not process external dependencies.
        /// </summary>
        Disabled,
        /// <summary>
        /// Enable external dependencies.
        /// </summary>
        Enabled,
        /// <summary>
        /// Try to get external dependencies using .expanded.json.
        /// </summary>
        TryFromExpanded
    }
}
