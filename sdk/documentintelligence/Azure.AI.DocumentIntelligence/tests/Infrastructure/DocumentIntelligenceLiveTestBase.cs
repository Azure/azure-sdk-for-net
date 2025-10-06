// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private const string SanitizedContainerUri = "https://sanitized.blob.core.windows.net";

        public DocumentIntelligenceLiveTestBase(bool isAsync, RecordedTestMode? mode = null)
            : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$..accessToken");
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..containerUrl") { Value = SanitizedContainerUri });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..resultContainerUrl") { Value = SanitizedContainerUri });
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
        }

        protected string ServiceVersionString { get; } = "2024-11-30";

        protected DocumentIntelligenceClient CreateDocumentIntelligenceClient(bool useApiKey = false)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = InstrumentClientOptions(new DocumentIntelligenceClientOptions());

            DocumentIntelligenceClient nonInstrumentedClient;

            if (useApiKey)
            {
                var credential = new AzureKeyCredential(TestEnvironment.ApiKey);
                nonInstrumentedClient = new DocumentIntelligenceClient(endpoint, credential, options);
            }
            else
            {
                nonInstrumentedClient = new DocumentIntelligenceClient(endpoint, TestEnvironment.Credential, options);
            }

            return InstrumentClient(nonInstrumentedClient);
        }

        protected DocumentIntelligenceAdministrationClient CreateDocumentIntelligenceAdministrationClient(bool useApiKey = false)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = InstrumentClientOptions(new DocumentIntelligenceClientOptions());

            DocumentIntelligenceAdministrationClient nonInstrumentedClient;

            if (useApiKey)
            {
                var credential = new AzureKeyCredential(TestEnvironment.ApiKey);
                nonInstrumentedClient = new DocumentIntelligenceAdministrationClient(endpoint, credential, options);
            }
            else
            {
                nonInstrumentedClient = new DocumentIntelligenceAdministrationClient(endpoint, TestEnvironment.Credential, options);
            }

            return InstrumentClient(nonInstrumentedClient);
        }

        protected async Task<DisposableDocumentModel> BuildDisposableDocumentModelAsync(string containerUrlString, string description = null, IReadOnlyDictionary<string, string> tags = null)
        {
            var client = CreateDocumentIntelligenceAdministrationClient();
            var modelId = Recording.GenerateId();
            var containerUrl = new Uri(containerUrlString);
            var source = new BlobContentSource(containerUrl);

            var options = new BuildDocumentModelOptions(modelId, DocumentBuildMode.Template, source)
            {
                Description = description
            };

            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    options.Tags.Add(tag);
                }
            }

            return await DisposableDocumentModel.BuildAsync(client, options);
        }

        protected async Task<DisposableDocumentClassifier> BuildDisposableDocumentClassifierAsync(string description = null)
        {
            var client = CreateDocumentIntelligenceAdministrationClient();
            var classifierId = Recording.GenerateId();
            var containerUrl = new Uri(TestEnvironment.ClassifierTrainingSasUrl);
            var sourceA = new BlobContentSource(containerUrl) { Prefix = "IRS-1040-A/train" };
            var sourceB = new BlobContentSource(containerUrl) { Prefix = "IRS-1040-B/train" };
            var sourceC = new BlobContentSource(containerUrl) { Prefix = "IRS-1040-C/train" };
            var sourceD = new BlobContentSource(containerUrl) { Prefix = "IRS-1040-D/train" };
            var sourceE = new BlobContentSource(containerUrl) { Prefix = "IRS-1040-E/train" };
            var docTypeA = new ClassifierDocumentTypeDetails(sourceA);
            var docTypeB = new ClassifierDocumentTypeDetails(sourceB);
            var docTypeC = new ClassifierDocumentTypeDetails(sourceC);
            var docTypeD = new ClassifierDocumentTypeDetails(sourceD);
            var docTypeE = new ClassifierDocumentTypeDetails(sourceE);
            var docTypes = new Dictionary<string, ClassifierDocumentTypeDetails>()
            {
                { "IRS-1040-A", docTypeA },
                { "IRS-1040-B", docTypeB },
                { "IRS-1040-C", docTypeC },
                { "IRS-1040-D", docTypeD },
                { "IRS-1040-E", docTypeE }
            };

            var options = new BuildClassifierOptions(classifierId, docTypes)
            {
                Description = description
            };

            return await DisposableDocumentClassifier.BuildAsync(client, options);
        }
    }
}
