// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Tests;
using Azure.AI.FormRecognizer.Training;
using Azure.Test.Perf;

namespace Azure.AI.FormRecognizer.Perf
{
    public class RecognizeCustomFormsWithoutLabelsTest : FormRecognizerTest<PerfOptions>
    {
        private readonly FormRecognizerClient _client;

        private readonly FormTrainingClient _trainingClient;

        private string _modelId;

        public RecognizeCustomFormsWithoutLabelsTest(PerfOptions options) : base(options)
        {
            _client = new FormRecognizerClient(new Uri(Endpoint), new AzureKeyCredential(ApiKey));
            _trainingClient = new FormTrainingClient(new Uri(Endpoint), new AzureKeyCredential(ApiKey));
        }

        public override async Task SetupAsync()
        {
            var trainingClient = new FormTrainingClient(new Uri(Endpoint), new AzureKeyCredential(ApiKey));
            var op = await trainingClient.StartTrainingAsync(new Uri(BlobContainerSasUrl), useTrainingLabels: false);

            CustomFormModel model = await op.WaitForCompletionAsync();
            _modelId = model.ModelId;
        }

        public override async Task CleanupAsync()
        {
            await _trainingClient.DeleteModelAsync(_modelId);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            var op = await _client.StartRecognizeCustomFormsFromUriAsync(_modelId, CreateUri(TestFile.Form1), cancellationToken: cancellationToken);
            await op.WaitForCompletionAsync(cancellationToken);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            var op = _client.StartRecognizeCustomFormsFromUri(_modelId, CreateUri(TestFile.Form1), cancellationToken: cancellationToken);

            while (!op.HasCompleted)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                op.UpdateStatus(cancellationToken);
            }
        }
    }
}
