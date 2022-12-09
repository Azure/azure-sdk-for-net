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
        private const ServiceVersion LatestVersion = ServiceVersion.V2022_10_01_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary> Service version "2022-05-01". </summary>
            V2022_05_01 = 1,

            /// <summary> Service version "2022-05-15-preview". </summary>
            V2022_05_15_Preview = 2,

            /// <summary> Service version "2022-10-01-preview. </summary>
            V2022_10_01_Preview = 3,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets or sets the audience to use for authentication with Azure Active Directory (AAD). The audience is not considered when using a shared key.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="ConversationsAudience.AzurePublicCloud" /> will be assumed.</value>
        public ConversationsAudience? Audience { get; set; }

        internal string Version { get; }

        /// <summary> Initializes new instance of ConversationsClientOptions. </summary>
        public ConversationsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2022_05_01 => "2022-05-01",
                ServiceVersion.V2022_05_15_Preview => "2022-05-15-preview",
                ServiceVersion.V2022_10_01_Preview => "2022-10-01-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
