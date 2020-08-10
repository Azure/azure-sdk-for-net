// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow to configure the management of the request sent to the service.
    /// </summary>
    public class TextAnalyticsClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V3_1_Preview_1;

        /// <summary>
        /// The versions of the Text Analytics service supported by this client library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Version 3.0
            /// </summary>
            V3_0 = 1,

            /// <summary>
            /// Version 3.1-preview.1
            /// </summary>
            V3_1_Preview_1 = 2,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        internal ServiceVersion Version { get; }

        /// <summary>
        /// Default country hint value to use in all client calls.
        /// If no value is specified, "us" is set as default.
        /// To remove this behavior, set to <see cref="DetectLanguageInput.None"/>.
        /// </summary>
        public string DefaultCountryHint { get; set; } = "us";

        /// <summary>
        /// Default language value to use in all client calls.
        /// If no value is specified, "en" is set as default.
        /// </summary>
        public string DefaultLanguage { get; set; } = "en";

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAnalyticsClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public TextAnalyticsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
            this.ConfigureLogging();
        }

        internal string GetVersionString()
        {
            return Version switch
            {
                ServiceVersion.V3_0 => "v3.0",
                ServiceVersion.V3_1_Preview_1 => "v3.1-preview.1",

                _ => throw new ArgumentException($"Version {Version.ToString()} not supported."),
            };
        }
    }
}
