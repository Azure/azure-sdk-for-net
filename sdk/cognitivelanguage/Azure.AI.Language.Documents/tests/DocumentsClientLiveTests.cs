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
using Azure.Identity;
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
        public async Task SubmitJob()
        {
            MultiLanguageDocumentCollection documents = new MultiLanguageDocumentCollection();
            documents.Documents.Add(
                new MultiLanguageInput(
                    "1",
                    new AzureBlobDocumentLocation(TestEnvironment.SourceLocation),
                    new AzureContainerFolderDocumentLocation(TestEnvironment.TargetLocation))
                {
                    Language = "en",
                });

            PiiEntityRecognitionAction piiAction = new PiiEntityRecognitionAction
            {
                Parameters = DocumentsServiceModelFactory.PiiActionContent(
                    redactionPolicies: new[]
                    {
                        new EntityMaskRedactionPolicy
                        {
                            PolicyName = "defaultPolicy",
                            IsDefault = true,
                        },
                    }),
            };

            AnalyzeDocumentsOperationInput request = new AnalyzeDocumentsOperationInput(
                documents,
                new AnalyzeDocumentsOperationAction[] { piiAction })
            {
                DisplayName = "Document Analysis.",
            };

            Operation operation = await Client.AnalyzeDocumentsSubmitOperationAsync(
                WaitUntil.Started,
                request);

            Assert.IsNotNull(operation);
            Assert.IsNotNull(operation.GetRawResponse());
        }
    }
}
