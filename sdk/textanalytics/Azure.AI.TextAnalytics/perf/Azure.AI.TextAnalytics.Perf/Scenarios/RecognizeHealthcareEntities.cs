// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.AI.TextAnalytics.Perf
{
    public sealed class RecognizeHealthcareEntities: TextAnalyticsTest<PerfOptions>
    {
        private readonly TextAnalyticsClient _client;

        // temp file input -> figure out how to pass input data
        private List<TextDocumentInput> _batchDocuments = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "Subject is taking 100mg of ibuprofen twice daily")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure.")
                {
                     Language = "en",
                }
            };

        public RecognizeHealthcareEntities(PerfOptions options) : base(options)
        {
            _client = new TextAnalyticsClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            var operation = await _client.StartAnalyzeHealthcareEntitiesAsync(_batchDocuments, cancellationToken: cancellationToken);
            await operation.WaitForCompletionAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            //var operation = _client.StartAnalyzeHealthcareEntities();
            //operation.WaitForCompletionAsync();
        }
    }
}
