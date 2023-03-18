// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    [ClientTestFixture(
    DocumentAnalysisClientOptions.ServiceVersion.V2022_08_31)]
    public class DocumentAnalysisLiveTestBase : RecordedTestBase<DocumentAnalysisTestEnvironment>
    {
        /// <summary>
        /// The version of the REST API to test against.  This will be passed
        /// to the .ctor via ClientTestFixture's values.
        /// </summary>
        private readonly DocumentAnalysisClientOptions.ServiceVersion _serviceVersion;

        public DocumentAnalysisLiveTestBase(bool isAsync, DocumentAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync)
        {
            _serviceVersion = serviceVersion;
            JsonPathSanitizers.Add("$..accessToken");
            JsonPathSanitizers.Add("$..containerUrl");
            SanitizedHeaders.Add(Constants.AuthorizationHeader);
        }

        /// <summary>
        /// Creates a <see cref="DocumentAnalysisClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="DocumentAnalysisTestEnvironment.ApiKey"/>.</param>
        /// <returns>The instrumented <see cref="DocumentAnalysisClient" />.</returns>
        protected DocumentAnalysisClient CreateDocumentAnalysisClient(bool useTokenCredential = false, string apiKey = default) => CreateDocumentAnalysisClient(out _, useTokenCredential, apiKey);

        /// <summary>
        /// Creates a <see cref="DocumentAnalysisClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="nonInstrumentedClient">The non-instrumented version of the client to be used to resume LROs.</param>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="DocumentAnalysisTestEnvironment.ApiKey"/>.</param>
        /// <returns>The instrumented <see cref="DocumentAnalysisClient" />.</returns>
        protected DocumentAnalysisClient CreateDocumentAnalysisClient(out DocumentAnalysisClient nonInstrumentedClient, bool useTokenCredential = false, string apiKey = default)
        {
            if (useTokenCredential)
            {
                Assert.Ignore();
            }

            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = InstrumentClientOptions(new DocumentAnalysisClientOptions(_serviceVersion));

            if (useTokenCredential)
            {
                nonInstrumentedClient = new DocumentAnalysisClient(endpoint, TestEnvironment.Credential, options);
            }
            else
            {
                var credential = new AzureKeyCredential(apiKey ?? TestEnvironment.ApiKey);
                nonInstrumentedClient = new DocumentAnalysisClient(endpoint, credential, options);
            }

            return InstrumentClient(nonInstrumentedClient);
        }

        /// <summary>
        /// Creates a <see cref="DocumentModelAdministrationClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="DocumentAnalysisTestEnvironment.ApiKey"/>.</param>
        /// <returns>The instrumented <see cref="DocumentModelAdministrationClient" />.</returns>
        protected DocumentModelAdministrationClient CreateDocumentModelAdministrationClient(bool useTokenCredential = false, string apiKey = default) => CreateDocumentModelAdministrationClient(out _, useTokenCredential, apiKey);

        /// <summary>
        /// Creates a <see cref="DocumentModelAdministrationClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="nonInstrumentedClient">The non-instrumented version of the client to be used to resume LROs.</param>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="DocumentAnalysisTestEnvironment.ApiKey"/>.</param>
        /// <returns>The instrumented <see cref="DocumentModelAdministrationClient" />.</returns>
        protected DocumentModelAdministrationClient CreateDocumentModelAdministrationClient(out DocumentModelAdministrationClient nonInstrumentedClient, bool useTokenCredential = false, string apiKey = default)
        {
            if (useTokenCredential)
            {
                Assert.Ignore();
            }

            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = InstrumentClientOptions(new DocumentAnalysisClientOptions(_serviceVersion));

            if (useTokenCredential)
            {
                nonInstrumentedClient = new DocumentModelAdministrationClient(endpoint, TestEnvironment.Credential, options);
            }
            else
            {
                var credential = new AzureKeyCredential(apiKey ?? TestEnvironment.ApiKey);
                nonInstrumentedClient = new DocumentModelAdministrationClient(endpoint, credential, options);
            }

            return InstrumentClient(nonInstrumentedClient);
        }

        /// <summary>
        /// Builds a model and returns the associated <see cref="DisposableBuildModel"/> instance. Upon disposal, the model will be deleted.
        /// </summary>
        /// <param name="modelId">Model Id.</param>
        /// <param name="containerType">Type of container to use to execute training.</param>
        /// <param name="buildMode">The technique to use to build the model. Defaults to <see cref="DocumentBuildMode.Template"/>.</param>
        /// <returns>A <see cref="DisposableBuildModel"/> instance from which the trained model ID can be obtained.</returns>
        protected async Task<DisposableBuildModel> CreateDisposableBuildModelAsync(string modelId, ContainerType containerType = default, DocumentBuildMode buildMode = default)
        {
            var adminClient = CreateDocumentModelAdministrationClient();

            string trainingFiles = containerType switch
            {
                ContainerType.Singleforms => TestEnvironment.BlobContainerSasUrl,
                ContainerType.MultipageFiles => TestEnvironment.MultipageBlobContainerSasUrl,
                ContainerType.SelectionMarks => TestEnvironment.SelectionMarkBlobContainerSasUrl,
                ContainerType.TableVariableRows => TestEnvironment.TableDynamicRowsContainerSasUrl,
                ContainerType.TableFixedRows => TestEnvironment.TableFixedRowsContainerSasUrl,
                _ => TestEnvironment.BlobContainerSasUrl,
            };
            var trainingFilesUri = new Uri(trainingFiles);

            buildMode = (buildMode == default)
                ? DocumentBuildMode.Template
                : buildMode;

            return await DisposableBuildModel.BuildModelAsync(adminClient, trainingFilesUri, buildMode, modelId);
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
