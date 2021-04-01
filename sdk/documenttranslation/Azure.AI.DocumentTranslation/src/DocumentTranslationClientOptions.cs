// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Translator.DocumentTranslation
{
    /// <summary>
    /// Options that allow to configure the management of the request sent to the service.
    /// </summary>
    public class DocumentTranslationClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V1_0_preview_1;

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when making requests
        /// </summary>
        internal ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTranslationClientOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when making requests.
        /// </param>
        public DocumentTranslationClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
        }

        internal string GetVersionString()
        {
            return Version switch
            {
                ServiceVersion.V1_0_preview_1 => "1.0-preview.1",
                _ => throw new ArgumentException(Version.ToString()),
            };
        }

        /// <summary>
        /// The versions of the Translator service supported by this client library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Version 1.0-preview.1
            /// </summary>
            V1_0_preview_1 = 1
        }
    }
}
