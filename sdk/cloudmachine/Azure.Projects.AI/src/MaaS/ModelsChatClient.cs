// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using OpenAI.Chat;
using System;
using System.ClientModel;

namespace Azure.AI.Models
{
    internal class ModelsChatClient : ChatClient
    {
        public ModelsChatClient(string model, Uri endpoint, ApiKeyCredential credential)
            : base(model, credential, MaaSClientHelpers.CreateOptions(endpoint))
        {
        }

        public ModelsChatClient(string model, Uri endpoint, TokenCredential credential)
            : base(MaaSClientHelpers.CreatePipeline(credential), model, MaaSClientHelpers.CreateOptions(endpoint))
        {
        }
    }
}
