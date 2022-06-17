// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// Client options for <see cref="ConversationAnalysisClient"/>.
    /// </summary>
    [CodeGenModel("ConversationAuthoringClientOptions")]
    public partial class ConversationAnalysisClientOptions : ClientOptions
    {
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
    }
}
