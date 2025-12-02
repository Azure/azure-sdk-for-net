// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;

namespace Azure.AI.Projects.Tests
{
    public class FineTuningTestEnvironment : TestEnvironment
    {
        public string PROJECTENDPOINT => GetRecordedVariable("PROJECT_ENDPOINT");
        public string DATASETNAME => GetRecordedVariable("DATASET_NAME");
        public string DATASETVERSION1 => GetRecordedVariable("DATASET_VERSION_1");
        public string DATASETVERSION2 => GetRecordedVariable("DATASET_VERSION_2");
        public string MODELDEPLOYMENTNAME => GetRecordedVariable("MODEL_DEPLOYMENT_NAME");
        public string EMBEDDINGSMODELDEPLOYMENTNAME => GetRecordedVariable("EMBEDDINGS_MODEL_DEPLOYMENT_NAME");
        public string TEXTEMBEDDINGSMODELDEPLOYMENTNAME => GetRecordedVariable("TEXT_EMBEDDINGS_MODEL_DEPLOYMENT_NAME");
        public string MODELPUBLISHER => GetRecordedVariable("MODEL_PUBLISHER");
        public string INDEXNAME => GetRecordedVariable("INDEX_NAME");
        public string INDEXVERSION => GetRecordedVariable("INDEX_VERSION");
        public string AISEARCHCONNECTIONNAME => GetRecordedVariable("AI_SEARCH_CONNECTION_NAME");
        public string AISEARCHINDEXNAME => GetRecordedVariable("AI_SEARCH_INDEX_NAME");
        public string STORAGECONNECTIONNAME => GetRecordedVariable("STORAGE_CONNECTION_NAME");
        public string STORAGECONNECTIONTYPE => GetRecordedVariable("STORAGE_CONNECTION_TYPE");
        public string AOAICONNECTIONNAME => GetRecordedVariable("AOAI_CONNECTION_NAME");
        public string TESTIMAGEPNGINPUTPATH => GetRecordedVariable("TEST_IMAGE_PNG_INPUT_PATH");
        public string SAMPLEFILEPATH => GetRecordedVariable("SAMPLE_FILE_PATH");
        public string SAMPLEFOLDERPATH => GetRecordedVariable("SAMPLE_FOLDER_PATH");

        public override Dictionary<string, string> ParseEnvironmentFile() => new()
        {
            { "OPEN-API-KEY", Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "api-key" }
        };

        public override Task WaitForEnvironmentAsync()
        {
            return Task.CompletedTask;
        }

        public override AuthenticationTokenProvider Credential => Mode switch
        {
            RecordedTestMode.Live or RecordedTestMode.Record => new DefaultAzureCredential(),
            _ => base.Credential
        };
    }
}
