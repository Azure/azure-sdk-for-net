// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Template
{
    /// <summary>
    /// The options for <see cref="MiniSecretClient"/>
    /// </summary>
    public class MiniSecretsClientOptions : ClientOptions
    {
        private readonly ServiceVersion _version;

        /// <summary>
        /// Initializes a new instance of the <see cref="MiniSecretsClientOptions"/>.
        /// </summary>
        public MiniSecretsClientOptions(ServiceVersion version = ServiceVersion.V1)
        {
            _version = version;
        }

        /// <summary>
        /// The template service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the template service.
            /// </summary>
            V1 = 1
        }
    }
}