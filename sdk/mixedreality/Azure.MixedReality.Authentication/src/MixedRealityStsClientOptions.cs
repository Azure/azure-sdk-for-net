// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
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
        public MixedRealityStsClientOptions(ServiceVersion version = ServiceVersion.V2019_02_28_Preview)
        {
            Version = version switch
            {
                ServiceVersion.V2019_02_28_Preview => "2019-02-28-preview",
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
#pragma warning disable AZC0016 // Invalid ServiceVersion member name.
            [EditorBrowsable(EditorBrowsableState.Never)]
            V2019_02_28_preview = 1,
#pragma warning restore AZC0016 // Invalid ServiceVersion member name.
            /// <summary>
            /// Version 2019-02-28-preview of the Mixed Reality STS service.
            /// </summary>
#pragma warning disable CA1069 // Enums values should not be duplicated
            V2019_02_28_Preview = 1,
#pragma warning restore CA1069 // Enums values should not be duplicated
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
