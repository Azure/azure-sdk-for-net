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
        private const ServiceVersion Latest = ServiceVersion.V2019_02_02;
        internal static TableClientOptions Default { get; } = new TableClientOptions();

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
                _ => throw new ArgumentOutOfRangeException(nameof(serviceVersion))
            };
        }

        internal string VersionString { get; }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when making requests.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The Tables API version 20019-02-02
            /// </summary>
            V2019_02_02 = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
