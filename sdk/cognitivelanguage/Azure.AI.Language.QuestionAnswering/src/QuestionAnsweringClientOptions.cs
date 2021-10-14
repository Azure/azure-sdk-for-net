// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Language.QuestionAnswering.Models;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering
{
    /// <summary>
    /// Client options for <see cref="QuestionAnsweringClient"/>.
    /// </summary>
    public partial class QuestionAnsweringClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2021_07_15_Preview;

        /// <summary>
        /// The version of the service to use.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Service version "2021-05-01-preview".
            /// </summary>
#pragma warning disable AZC0016 // Invalid ServiceVersion member name.
            V2021_05_01_preview = 1,
#pragma warning restore AZC0016 // Invalid ServiceVersion member name.

            /// <summary>
            /// Service version "2021-07-15-preview".
            /// </summary>
            V2021_07_15_Preview = 2,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the method used to interpret string offsets, which is always <see cref="StringIndexType.Utf16CodeUnit"/> for .NET.
        /// </summary>
        internal static StringIndexType DefaultStringIndexType { get; } = StringIndexType.Utf16CodeUnit;

        /// <summary>
        /// Gets or sets the default language to use in some client methods.
        /// This is the BCP-47 representation of a language. For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, the service default, "en" for English, is used.
        /// </summary>
        public string DefaultLanguage { get; set; } = "en";

        internal string Version { get; }

        /// <summary>
        /// Initializes new instance of QuestionAnsweringClientOptions.
        /// </summary>
        public QuestionAnsweringClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2021_05_01_preview => "2021-05-01-preview",
                ServiceVersion.V2021_07_15_Preview => "2021-07-15-preview",
                _ => throw new NotSupportedException()
            };

            this.ConfigureLogging();
        }
    }
}
