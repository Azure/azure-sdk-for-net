// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.MixedReality.Authentication
{
    /// <summary>
    /// The <see cref="MixedRealityStsClientOptions"/>.
    /// Implements the <see cref="Azure.Core.ClientOptions" />.
    /// </summary>
    /// <seealso cref="Azure.Core.ClientOptions" />
    public class MixedRealityStsClientOptions : ClientOptions
    {
        internal string Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityStsClientOptions"/> class.
        /// </summary>
        /// <param name="version">The version.</param>
        public MixedRealityStsClientOptions(ServiceVersion version = ServiceVersion.V2019_02_28_preview)
        {
            Version = version switch
            {
                ServiceVersion.V2019_02_28_preview => "2019-02-28-preview",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };
        }

        /// <summary>
        /// The Mixed Reality STS service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// Version 2019-02-28-preview of the Mixed Reality STS service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2019_02_28_preview = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
