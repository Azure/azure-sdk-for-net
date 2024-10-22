// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.ContentSafety
{
    /// <summary> ContentSafety client options. </summary>
    [CodeGenModel("AzureAIContentSafetyClientOptions")]
    public partial class ContentSafetyClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2023_10_01;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2023-10-01". </summary>
            V2023_10_01 = 1,
        }

        internal string Version { get; }

        private string[] _authorizationScopes;
        /// <summary> Gets or sets the authorization scopes. </summary>
        public string[] AuthorizationScopes
        {
            get => _authorizationScopes;
            set => _authorizationScopes = value ?? new string[] { "https://cognitiveservices.azure.com/.default" };
        }

        /// <summary> Initializes new instance of ContentSafetyClientOptions. </summary>
        public ContentSafetyClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2023_10_01 => "2023-10-01",
                _ => throw new NotSupportedException()
            };
        }
    }
}
