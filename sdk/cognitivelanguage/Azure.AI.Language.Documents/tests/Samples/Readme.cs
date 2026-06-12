// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

#region Snippet:DocumentsServiceClient_Namespaces
using Azure.Core;
using Azure.Core.Serialization;
using Azure.AI.Language.Documents;
#endregion

#region Snippet:Conversation_Identity_Namespace
using Azure.Identity;
#endregion

namespace Azure.AI.Language.Documents.Tests.Samples
{
    public partial class DocumentsServiceClientSamples : DocumentServiceTestBase<DocumentsServiceClient>
    {
        public void CreateConversationClient()
        {
            #region Snippet:DocumentsServiceClient_Create
            Uri endpoint = new Uri("{endpoint}");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

            DocumentsServiceClient client = new DocumentsServiceClient(endpoint, credential);
            #endregion
        }

        public void CreateConversationClientWithSpecificApiVersion()
        {
            #region Snippet:CreateDocumentsServiceClientForSpecificApiVersion
            Uri endpoint = new Uri("{endpoint}");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
            DocumentsServiceClientOptions options = new DocumentsServiceClientOptions(DocumentsServiceClientOptions.ServiceVersion.V2026_05_15_Preview);
            DocumentsServiceClient client = new DocumentsServiceClient(endpoint, credential, options);
            #endregion
        }

        public void CreateConversationClientWithDefaultAzureCredential()
        {
            #region Snippet:DocumentsServiceClient_CreateWithDefaultAzureCredential
            Uri endpoint = new Uri("{endpoint}");
            DefaultAzureCredential credential = new DefaultAzureCredential();

            DocumentsServiceClient client = new DocumentsServiceClient(endpoint, credential);
            #endregion
        }
    }
}
