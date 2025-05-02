// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Inference
{
    /// <summary> Client options for Azure.AI.Inference library clients. </summary>
    public partial class AzureAIInferenceClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2025_05_01;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2024-05-01-preview". </summary>
            V2024_05_01_Preview = 1,
            /// <summary> Service version "2025-05-01". </summary>
            V2025_05_01 = 2,
        }

        internal string Version { get; }
        public string[] Audience { get; set; }

        /// <summary> Initializes new instance of AzureAIInferenceClientOptions. </summary>
        public AzureAIInferenceClientOptions(ServiceVersion version = LatestVersion, string[] audience = null)
        {
            Version = version switch
            {
                ServiceVersion.V2024_05_01_Preview => "2024-05-01-preview",
                ServiceVersion.V2025_05_01 => "2025-05-01",
                _ => throw new NotSupportedException()
            };
            Audience = audience;
        }
    }
}
