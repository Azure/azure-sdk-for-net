// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Template
{
    /// <summary>
    /// The options for <see cref="MiniSecretClient"/>
    /// </summary>
    public class MiniSecretsClientOptions : ClientOptions
    {
        internal string Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MiniSecretsClientOptions"/>.
        /// </summary>
        public MiniSecretsClientOptions(ServiceVersion version = ServiceVersion.V7_0)
        {
            Version = version switch
            {
                ServiceVersion.V7_0 => "7.0",
                _ => throw new NotSupportedException("Unsupported service version.")
            };
        }

        /// <summary>
        /// The template service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The 7.0 of the secret service.
            /// </summary>
#pragma warning disable CA1707 // Remove the underscores from member name
            V7_0 = 1
#pragma warning restore
        }
    }
}