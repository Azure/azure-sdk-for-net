// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Projects.Tests
{
    public class AIProjectsTestEnvironment : TestEnvironment
    {
        public string PROJECTENDPOINT => GetRecordedVariable("PROJECT_ENDPOINT", options => options.IsSecret("https://sanitized-host.services.ai.azure.com/api/projects/sanitized-project"));
        public string DATASETNAME => GetRecordedVariable("DATASET_NAME");
        public string DATASETVERSION1 => GetRecordedVariable("DATASET_VERSION_1");
        public string DATASETVERSION2 => GetRecordedVariable("DATASET_VERSION_2");
        public string MODELDEPLOYMENTNAME => GetRecordedVariable("MODEL_DEPLOYMENT_NAME");
        public string EMBEDDINGSMODELDEPLOYMENTNAME => GetRecordedVariable("EMBEDDINGS_MODEL_DEPLOYMENT_NAME");
        public string TEXTEMBEDDINGSMODELDEPLOYMENTNAME => GetRecordedVariable("TEXT_EMBEDDINGS_MODEL_DEPLOYMENT_NAME");
        public string MODELPUBLISHER => GetRecordedVariable("MODEL_PUBLISHER");
        public string INDEX_NAME => GetRecordedVariable("INDEX_NAME");
        public string INDEX_VERSION => GetRecordedVariable("INDEX_VERSION");
        public string AI_SEARCH_CONNECTION_NAME => GetRecordedVariable("AI_SEARCH_CONNECTION_NAME");
        public string AI_SEARCH_INDEX_NAME => GetRecordedVariable("AI_SEARCH_INDEX_NAME");
        public string STORAGECONNECTIONNAME => GetRecordedVariable("STORAGE_CONNECTION_NAME");
        public string STORAGECONNECTIONTYPE => GetRecordedVariable("STORAGE_CONNECTION_TYPE");
        public string AOAI_CONNECTION_NAME => GetRecordedVariable("AOAI_CONNECTION_NAME");
        public string TESTIMAGEPNGINPUTPATH => GetRecordedVariable("TEST_IMAGE_PNG_INPUT_PATH");
        public string SAMPLEFILEPATH => GetRecordedVariable("SAMPLE_FILE_PATH");
        public string SAMPLEFOLDERPATH => GetRecordedVariable("SAMPLE_FOLDER_PATH");
        public string MODEL_ENDPOINT => GetRecordedVariable("MODEL_ENDPOINT");
        public string MODEL_API_KEY => GetRecordedVariable("MODEL_API_KEY");
    }
}
