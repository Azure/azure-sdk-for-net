// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Perf
{
    public sealed class DetectLanguagePerf

        : TextAnalyticsTest<TextAnalyticsCountOptions>
    {
        private readonly TextAnalyticsClient _client;

        private List<string> _batchDocuments;

        public DetectLanguagePerf(TextAnalyticsCountOptions options) : base(options)
        {
            // create client
            _client = new TextAnalyticsClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            // create input docs
            var documentCount = options.Count;
            _batchDocuments = new List<string> { };
            for (int i = 1; i <= documentCount; i++)
            {
                _batchDocuments.Add("Detta är ett dokument skrivet på engelska.");
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _client.DetectLanguageBatchAsync(_batchDocuments, cancellationToken: cancellationToken);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            _client.DetectLanguageBatch(_batchDocuments, cancellationToken: cancellationToken);
        }
    }
}
