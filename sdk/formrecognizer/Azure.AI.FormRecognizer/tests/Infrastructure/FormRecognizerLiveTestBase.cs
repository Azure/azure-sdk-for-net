// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Training;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.Tests
{
    [ClientTestFixture(
    FormRecognizerClientOptions.ServiceVersion.V2_0,
    FormRecognizerClientOptions.ServiceVersion.V2_1_Preview_3)]
    public class FormRecognizerLiveTestBase : RecordedTestBase<FormRecognizerTestEnvironment>
    {
        /// <summary>
        /// The version of the REST API to test against.  This will be passed
        /// to the .ctor via ClientTestFixture's values.
        /// </summary>
        private readonly FormRecognizerClientOptions.ServiceVersion _serviceVersion;

        public FormRecognizerLiveTestBase(bool isAsync, FormRecognizerClientOptions.ServiceVersion serviceVersion)
            : base(isAsync)
        {
            _serviceVersion = serviceVersion;
            Sanitizer = new FormRecognizerRecordedTestSanitizer();
        }

        /// <summary>
        /// Creates a <see cref="FormRecognizerClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="FormRecognizerTestEnvironment.ApiKey"/>.</param>
        /// <param name="skipInstrumenting">Whether or not instrumenting should be skipped. Avoid skipping it as much as possible.</param>
        /// <returns>The instrumented <see cref="FormRecognizerClient" />.</returns>
        protected FormRecognizerClient CreateFormRecognizerClient(bool useTokenCredential = false, string apiKey = default) => CreateFormRecognizerClient(out _, useTokenCredential, apiKey);

        /// <summary>
        /// Creates a <see cref="FormRecognizerClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="nonInstrumentedClient">The non-instrumented version of the client to be used to resume LROs.</param>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="FormRecognizerTestEnvironment.ApiKey"/>.</param>
        /// <param name="skipInstrumenting">Whether or not instrumenting should be skipped. Avoid skipping it as much as possible.</param>
        /// <returns>The instrumented <see cref="FormRecognizerClient" />.</returns>
        protected FormRecognizerClient CreateFormRecognizerClient(out FormRecognizerClient nonInstrumentedClient, bool useTokenCredential = false, string apiKey = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = InstrumentClientOptions(new FormRecognizerClientOptions(_serviceVersion));

            if (useTokenCredential)
            {
                nonInstrumentedClient = new FormRecognizerClient(endpoint, TestEnvironment.Credential, options);
            }
            else
            {
                var credential = new AzureKeyCredential(apiKey ?? TestEnvironment.ApiKey);
                nonInstrumentedClient = new FormRecognizerClient(endpoint, credential, options);
            }

            return InstrumentClient(nonInstrumentedClient);
        }

        /// <summary>
        /// Creates a <see cref="FormTrainingClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="nonInstrumentedClient">The non-instrumented version of the client to be used to resume LROs.</param>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="FormRecognizerTestEnvironment.ApiKey"/>.</param>
        /// <param name="skipInstrumenting">Whether or not instrumenting should be skipped. Avoid skipping it as much as possible.</param>
        /// <returns>The instrumented <see cref="FormTrainingClient" />.</returns>
        protected FormTrainingClient CreateFormTrainingClient(bool useTokenCredential = false, string apiKey = default) => CreateFormTrainingClient(out _, useTokenCredential, apiKey);

        /// <summary>
        /// Creates a <see cref="FormTrainingClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="nonInstrumentedClient">The non-instrumented version of the client to be used to resume LROs.</param>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="FormRecognizerTestEnvironment.ApiKey"/>.</param>
        /// <param name="skipInstrumenting">Whether or not instrumenting should be skipped. Avoid skipping it as much as possible.</param>
        /// <returns>The instrumented <see cref="FormTrainingClient" />.</returns>
        protected FormTrainingClient CreateFormTrainingClient(out FormTrainingClient nonInstrumentedClient, bool useTokenCredential = false, string apiKey = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = InstrumentClientOptions(new FormRecognizerClientOptions(_serviceVersion));

            if (useTokenCredential)
            {
                nonInstrumentedClient = new FormTrainingClient(endpoint, TestEnvironment.Credential, options);
            }
            else
            {
                var credential = new AzureKeyCredential(apiKey ?? TestEnvironment.ApiKey);
                nonInstrumentedClient = new FormTrainingClient(endpoint, credential, options);
            }

            return InstrumentClient(nonInstrumentedClient);
        }

        /// <summary>
        /// Trains a model and returns the associated <see cref="DisposableTrainedModel"/> instance, from which
        /// the model ID can be obtained. Upon disposal, the model will be deleted.
        /// </summary>
        /// <param name="useTrainingLabels">If <c>true</c>, use a label file created in the &lt;link-to-label-tool-doc&gt; to provide training-time labels for training a model. If <c>false</c>, the model will be trained from forms only.</param>
        /// <param name="containerType">Type of container to use to execute training.</param>
        /// <param name="modelName">Optional model name.</param>
        /// <returns>A <see cref="DisposableTrainedModel"/> instance from which the trained model ID can be obtained.</returns>
        protected async Task<DisposableTrainedModel> CreateDisposableTrainedModelAsync(bool useTrainingLabels, ContainerType containerType = default, string modelName = default)
        {
            var trainingClient = CreateFormTrainingClient();

            string trainingFiles = containerType switch
            {
                ContainerType.Singleforms => TestEnvironment.BlobContainerSasUrl,
                ContainerType.MultipageFiles => TestEnvironment.MultipageBlobContainerSasUrl,
                ContainerType.SelectionMarks => TestEnvironment.SelectionMarkBlobContainerSasUrl,
                ContainerType.TableVariableRows => TestEnvironment.TableVariableRowsContainerSasUrl,
                ContainerType.TableFixedRows => TestEnvironment.TableFixedRowsContainerSasUrl,
                _ => TestEnvironment.BlobContainerSasUrl,
            };
            var trainingFilesUri = new Uri(trainingFiles);

            return await DisposableTrainedModel.TrainModelAsync(trainingClient, trainingFilesUri, useTrainingLabels, modelName);
        }

        protected enum ContainerType
        {
            Singleforms,
            MultipageFiles,
            SelectionMarks,
            TableVariableRows,
            TableFixedRows
        }
    }
}
