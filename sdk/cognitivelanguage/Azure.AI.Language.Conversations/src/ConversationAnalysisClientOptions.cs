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
        private const ServiceVersion LatestVersion = ServiceVersion.V2022_05_01;

        /// <summary>
        /// The version of the service to use.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Service version "2022-05-01".
            /// </summary>
            V2022_05_01 = 1,
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
                ServiceVersion.V2022_05_01 => "2022-05-01",
                _ => throw new NotSupportedException()
            };

            this.ConfigureLogging();
        }

        /// <summary>
        /// Gets the method used to interpret string offsets, which is always <see cref="StringIndexType.Utf16CodeUnit"/> for .NET.
        /// </summary>
        internal static StringIndexType DefaultStringIndexType { get; } = StringIndexType.Utf16CodeUnit;
    }
}
