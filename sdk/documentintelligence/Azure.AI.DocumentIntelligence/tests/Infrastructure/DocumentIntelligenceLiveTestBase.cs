﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class DocumentIntelligenceLiveTestBase : RecordedTestBase<DocumentIntelligenceTestEnvironment>
    {
        public DocumentIntelligenceLiveTestBase(bool isAsync, RecordedTestMode? mode = null)
            : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$..accessToken");
            BodyKeySanitizers.Add(new BodyKeySanitizer("https://sanitized.blob.core.windows.net") { JsonPath = "$..containerUrl" });
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
        }

        protected string ServiceVersionString { get; } = "2023-10-31-preview";

        protected DocumentAnalysisClient CreateDocumentAnalysisClient()
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var credential = new AzureKeyCredential(TestEnvironment.ApiKey);

            var nonInstrumentedClient = new DocumentAnalysisClient(endpoint, credential);

            return InstrumentClient(nonInstrumentedClient);
        }

        protected DocumentModelAdministrationClient CreateDocumentModelAdministrationClient()
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var credential = new AzureKeyCredential(TestEnvironment.ApiKey);

            var nonInstrumentedClient = new DocumentModelAdministrationClient(endpoint, credential);

            return InstrumentClient(nonInstrumentedClient);
        }

        protected async Task<DisposableDocumentModel> BuildDisposableDocumentModelAsync(string containerUrlString, string description = null, IReadOnlyDictionary<string, string> tags = null)
        {
            var client = CreateDocumentModelAdministrationClient();
            var modelId = Recording.GenerateId();
            var containerUrl = new Uri(containerUrlString);
            var source = new AzureBlobContentSource(containerUrl);

            var request = new BuildDocumentModelRequest(modelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = source,
                Description = description
            };

            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    request.Tags.Add(tag);
                }
            }

            return await DisposableDocumentModel.BuildAsync(client, request);
        }

        protected async Task<DisposableDocumentClassifier> BuildDisposableDocumentClassifierAsync(string description = null)
        {
            var client = CreateDocumentModelAdministrationClient();
            var classifierId = Recording.GenerateId();
            var containerUrl = new Uri(TestEnvironment.ClassifierTrainingSasUrl);
            var sourceA = new AzureBlobContentSource(containerUrl) { Prefix = "IRS-1040-A/train" };
            var sourceB = new AzureBlobContentSource(containerUrl) { Prefix = "IRS-1040-B/train" };
            var sourceC = new AzureBlobContentSource(containerUrl) { Prefix = "IRS-1040-C/train" };
            var sourceD = new AzureBlobContentSource(containerUrl) { Prefix = "IRS-1040-D/train" };
            var sourceE = new AzureBlobContentSource(containerUrl) { Prefix = "IRS-1040-E/train" };
            var docTypeA = new ClassifierDocumentTypeDetails() { AzureBlobSource = sourceA };
            var docTypeB = new ClassifierDocumentTypeDetails() { AzureBlobSource = sourceB };
            var docTypeC = new ClassifierDocumentTypeDetails() { AzureBlobSource = sourceC };
            var docTypeD = new ClassifierDocumentTypeDetails() { AzureBlobSource = sourceD };
            var docTypeE = new ClassifierDocumentTypeDetails() { AzureBlobSource = sourceE };
            var docTypes = new Dictionary<string, ClassifierDocumentTypeDetails>()
            {
                { "IRS-1040-A", docTypeA },
                { "IRS-1040-B", docTypeB },
                { "IRS-1040-C", docTypeC },
                { "IRS-1040-D", docTypeD },
                { "IRS-1040-E", docTypeE }
            };

            var request = new BuildDocumentClassifierRequest(classifierId, docTypes)
            {
                Description = description
            };

            return await DisposableDocumentClassifier.BuildAsync(client, request);
        }
    }
}
