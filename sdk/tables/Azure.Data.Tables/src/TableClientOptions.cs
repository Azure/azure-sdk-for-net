// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Data.Tables
{
    /// <summary>
    /// Options to configure the requests to the Table service.
    /// </summary>
    public class TableClientOptions : ClientOptions
    {
        /// <summary>
        /// The versions of Azure Tables supported by this client
        /// library.
        /// </summary>
        private const ServiceVersion Latest = ServiceVersion.V2020_12_06;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClientOptions"/> class.
        /// class.
        /// </summary>
        /// <param name="serviceVersion">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public TableClientOptions(ServiceVersion serviceVersion = Latest)
        {
            VersionString = serviceVersion switch
            {
                ServiceVersion.V2019_02_02 => "2019-02-02",
                ServiceVersion.V2020_12_06 => "2020-12-06",
                _ => throw new ArgumentOutOfRangeException(nameof(serviceVersion))
            };
        }

        /// <summary>
        ///  Enables tenant discovery through the authorization challenge when the client is configured to use a TokenCredential.
        /// When <c>true</c>, the client will attempt an initial un-authorized request to prompt an OAuth challenge in order to discover the correct tenant for the resource.
        /// </summary>
        public bool EnableTenantDiscovery { get; set; }

        internal string VersionString { get; }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when making requests.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The Tables API version 2019-02-02.
            /// </summary>
            V2019_02_02 = 1,

            /// <summary>
            /// The Tables API version 2020-12-06.
            /// </summary>
            V2020_12_06 = 2
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets or sets the Audience to use for authentication with Microsoft Entra.
        /// The audience is not considered when using a shared key or connection string.
        /// </summary>
        public TableAudience? Audience { get; set; }

        internal static TableClientOptions DefaultOptions => new()
        {
            Diagnostics =
            {
                LoggedHeaderNames = { "x-ms-request-id", "DataServiceVersion" },
                LoggedQueryParameters = { "api-version", "$format", "$filter", "$top", "$select" },
            }
        };
    }
}
