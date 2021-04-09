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
    public sealed class RecognizeCustomFormsWithoutLabels: FormRecognizerTest<PerfOptions>
    {
        private readonly FormRecognizerClient _client;

        private readonly FormTrainingClient _trainingClient;

        private string _modelId;

        public RecognizeCustomFormsWithoutLabels(PerfOptions options) : base(options)
        {
            _client = new FormRecognizerClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));
            _trainingClient = new FormTrainingClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            var trainingClient = new FormTrainingClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));
            var op = await trainingClient.StartTrainingAsync(new Uri(TestEnvironment.BlobContainerSasUrl), useTrainingLabels: false);

            CustomFormModel model = await op.WaitForCompletionAsync();
            _modelId = model.ModelId;
        }

        public override async Task GlobalCleanupAsync()
        {
            await _trainingClient.DeleteModelAsync(_modelId);
            await base.GlobalCleanupAsync();
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
