// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    /// <summary> Client options for OpenAIClient. </summary>
    public partial class OpenAIClientOptions : ClientOptions
    {
        public enum ClientType
        {
            AzureOpenAI = 1,
            PublicOpenAI = 2,
        }

        public ClientType EndpointType { get; set; }
    }
}
