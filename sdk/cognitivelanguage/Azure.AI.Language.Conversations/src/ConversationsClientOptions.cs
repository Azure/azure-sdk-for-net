// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

[assembly: CodeGenSuppressType("ConversationsClientOptions")]

namespace Azure.AI.Language.Conversations
{
    /// <summary> Client options for Conversations library clients. </summary>
    public partial class ConversationsClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2023_04_01;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary> Service version "2022-05-01". </summary>
            V2022_05_01 = 1,

            /// <summary> Service version "2023-04-01. </summary>
            V2023_04_01 = 2,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets or sets the audience to use for authentication with Azure Active Directory (AAD). The audience is not considered when using a shared key.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="ConversationsAudience.AzurePublicCloud" /> will be assumed.</value>
        internal ConversationsAudience? Audience { get; set; }

        internal string Version { get; }

        /// <summary> Initializes new instance of ConversationsClientOptions. </summary>
        public ConversationsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2022_05_01 => "2022-05-01",
                ServiceVersion.V2023_04_01 => "2023-04-01",
                _ => throw new NotSupportedException()
            };
        }
    }
}
