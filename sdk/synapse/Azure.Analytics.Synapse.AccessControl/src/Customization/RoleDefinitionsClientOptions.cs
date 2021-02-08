// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;

namespace Azure.Analytics.Synapse.AccessControl
{
    /// <summary>
    /// The options for <see cref="RoleDefinitionsClient"/>.
    /// </summary>
    public class RoleDefinitionsClientOptions : ClientOptions
    {
        private const ServiceVersion Latest = ServiceVersion.V2020_08_01_preview;

        internal static RoleDefinitionsClientOptions Default { get; } = new RoleDefinitionsClientOptions();

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleDefinitionsClientOptions"/>.
        /// </summary>
        public RoleDefinitionsClientOptions(ServiceVersion serviceVersion = Latest)
        {
            VersionString = serviceVersion switch
            {
                ServiceVersion.V2020_08_01_preview => "2020-08-01-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(serviceVersion))
            };
        }

        /// <summary>
        /// API version for Azure Synapse Access Control service.
        /// </summary>
        internal string VersionString { get; }

        /// <summary>
        /// The Synapse service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The 2020-08-01-preview of the template service.
            /// </summary>
#pragma warning disable CA1707
            V2020_08_01_preview = 1
#pragma warning restore CA1707
        }
    }
}
