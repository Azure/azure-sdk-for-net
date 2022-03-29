// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// Client options for <see cref="ConversationAnalysisClient"/>.
    /// </summary>
    public partial class ConversationAnalysisClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2021_11_01_Preview;

        /// <summary>
        /// The version of the service to use.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Service version "2021-11-01-preview".
            /// </summary>
            V2021_11_01_Preview = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        internal string Version { get; }

        /// <summary>
        /// Initializes new instance of <see cref="ConversationAnalysisClientOptions"/>.
        /// </summary>
        public ConversationAnalysisClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2021_11_01_Preview => "2021-11-01-preview",
                _ => throw new NotSupportedException()
            };

            this.ConfigureLogging();
        }
    }
}
