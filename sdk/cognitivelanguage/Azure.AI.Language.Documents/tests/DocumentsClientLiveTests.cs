// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Language.Documents;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace Azure.AI.Language.Documents.Tests
{
    public class DocumentsClientLiveTests : DocumentServiceTestBase<DocumentsServiceClient>
    {
        public DocumentsClientLiveTests(bool isAsync, DocumentsServiceClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task AnalyzeConversation()
        {
            var data = new
            {
                AnalysisInput = new
                {
                    ConversationItem = new
                    {
                        Text = "Send an email to Carol about the tomorrow's demo",
                        Id = "1",
                        ParticipantId = "1",
                    }
                },
                Parameters = new
                {
                    ProjectName = TestEnvironment.ProjectName,
                    DeploymentName = TestEnvironment.DeploymentName,
                },
                Kind = "Conversation",
            };

            Response response = await Client.AnalyzeConversationAsync(RequestContent.Create(data, JsonPropertyNames.CamelCase));

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            dynamic conversationalTaskResult = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual("Conversation", (string)conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("SendEmail", (string)conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            dynamic conversationPrediction = conversationalTaskResult.Result.Prediction;
            Assert.IsNotNull(conversationPrediction);

            // assert - not empty
            Assert.IsNotEmpty((IEnumerable)conversationPrediction.Intents);
        }
    }
}
