// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering
{
    /// <summary>
    /// Client options for <see cref="QuestionAnsweringClient"/>.
    /// </summary>
    public partial class QuestionAnsweringClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2021_05_01_preview;

        /// <summary>
        /// The version of the service to use.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Service version "2021-05-01-preview".
            /// </summary>
            V2021_05_01_preview = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        internal string Version { get; }

        /// <summary>
        /// Initializes new instance of QuestionAnsweringClientOptions.
        /// </summary>
        public QuestionAnsweringClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2021_05_01_preview => "2021-05-01-preview",
                _ => throw new NotSupportedException()
            };

            this.ConfigureLogging();
        }
    }
}
