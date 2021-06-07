// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// The options for <see cref="ContainerRegistryClient"/>
    /// </summary>
    public class ContainerRegistryClientOptions : ClientOptions
    {
        internal string Version { get; }

        /// <summary>
        /// Gets or sets the authentication scope to use for authentication with AAD.
        /// This defaults to the Azure Resource Manager "Azure Global" scope.  To
        /// connect to a different cloud, set this value to "&lt;resource-id&gt;/.default",
        /// where &lt;resource-id&gt; is one of the Resource IDs listed at
        /// https://docs.microsoft.com/azure/active-directory/managed-identities-azure-resources/services-support-managed-identities#azure-resource-manager.
        /// For example, to connect to the Azure Germany cloud, create a client with
        /// <see cref="AuthenticationScope"/> set to "https://management.microsoftazure.de/.default".
        /// </summary>
        public string AuthenticationScope { get; set; } = "https://management.azure.com/.default";

        /// <summary>
        /// </summary>
        /// <param name="version"></param>
        public ContainerRegistryClientOptions(ServiceVersion version = ServiceVersion.V1_0)
        {
            Version = version switch
            {
                ServiceVersion.V1_0 => "1.0",
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

        /// <summary>
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// </summary>
#pragma warning disable CA1707 // Remove the underscores from member name
            V1_0 = 1
#pragma warning restore
        }
    }
}
