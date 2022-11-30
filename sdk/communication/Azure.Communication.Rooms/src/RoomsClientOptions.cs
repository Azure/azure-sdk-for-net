// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Rooms
{
    /// <summary>
    /// The options for communication <see cref="RoomsClient"/>.
    /// </summary>
    public class RoomsClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2022_02_01_Preview;
        internal const ServiceVersion LastVersion = ServiceVersion.V2021_04_07_Preview;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClientOptions"/> class.
        /// </summary>
        /// <param name="version"></param>
        public RoomsClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_04_07_Preview => "2021-04-07",
                ServiceVersion.V2022_02_01_Preview => "2022-02-01",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }
        /// <summary>
        /// The Room Service Version.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The First Room Service Version.
            /// </summary>
            V2021_04_07_Preview = 1,
            /// <summary>
            /// The Second Room Service Version with Prebuilt RBAC support.
            /// </summary>
            V2022_02_01_Preview = 2,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
