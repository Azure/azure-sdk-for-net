// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// The options for <see cref="ContainerRegistryClient"/>
    /// </summary>
    public partial class ContainerRegistryClientOptions : ClientOptions
    {
        internal string Version { get; }

        /// <summary>
        /// </summary>
        /// <param name="version"></param>
        public ContainerRegistryClientOptions(ServiceVersion version = ServiceVersion.V2019_08_15_preview)
        {
            Version = version switch
            {
                ServiceVersion.V2019_08_15_preview => "V2019_08_15_preview",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };
            AddHeadersAndQueryParameters();
        }

        /// <summary>
        /// Add headers and query parameters in <see cref="DiagnosticsOptions.LoggedHeaderNames"/> and <see cref="DiagnosticsOptions.LoggedQueryParameters"/>
        /// </summary>
        private void AddHeadersAndQueryParameters()
        {
            Diagnostics.LoggedQueryParameters.Add("orderby");
            Diagnostics.LoggedQueryParameters.Add("n");
            Diagnostics.LoggedQueryParameters.Add("last");
            Diagnostics.LoggedQueryParameters.Add("digest");
        }

//        /// <summary>
//        /// </summary>
//        public enum ServiceVersion
//        {
//            /// <summary>
//            /// </summary>
//#pragma warning disable CA1707 // Remove the underscores from member name
//            V1_0 = 1
//#pragma warning restore
//        }
    }
}
