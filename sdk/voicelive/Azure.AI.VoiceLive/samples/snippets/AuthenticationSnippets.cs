// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.VoiceLive;
using Azure.Core;
using Azure.Identity;

namespace Azure.AI.VoiceLive.Samples.Snippets
{
    /// <summary>
    /// Basic code snippets demonstrating how to authenticate and configure the VoiceLive client.
    /// </summary>
    public partial class AuthenticationSnippets
    {
        /// <summary>
        /// Demonstrates creating a VoiceLive client with Microsoft Entra ID authentication.
        /// </summary>
        public void CreateVoiceLiveClientWithTokenCredential()
        {
            #region Snippet:CreateVoiceLiveClientWithTokenCredential
            Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
            DefaultAzureCredential credential = new DefaultAzureCredential();
            VoiceLiveClient client = new VoiceLiveClient(endpoint, credential);
            #endregion
        }

        /// <summary>
        /// Demonstrates creating a VoiceLive client with API key authentication.
        /// </summary>
        public void CreateVoiceLiveClientWithApiKey()
        {
            #region Snippet:CreateVoiceLiveClientWithApiKey
            Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            VoiceLiveClient client = new VoiceLiveClient(endpoint, credential);
            #endregion
        }

        /// <summary>
        /// Demonstrates creating a VoiceLive client for a specific API version.
        /// </summary>
        public void CreateVoiceLiveClientForSpecificApiVersion()
        {
            #region Snippet:CreateVoiceLiveClientForSpecificApiVersion
            Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
            DefaultAzureCredential credential = new DefaultAzureCredential();
            VoiceLiveClientOptions options = new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2025_10_01);
            VoiceLiveClient client = new VoiceLiveClient(endpoint, credential, options);
            #endregion
        }
    }
}
