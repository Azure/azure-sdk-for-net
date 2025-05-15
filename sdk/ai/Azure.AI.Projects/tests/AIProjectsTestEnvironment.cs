// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Projects.Tests
{
    public class AIProjectsTestEnvironment : TestEnvironment
    {
        public string AzureAICONNECTIONSTRING => GetRecordedVariable("PROJECT_CONNECTION_STRING");
        public string PROJECTENDPOINT => GetRecordedVariable("PROJECT_ENDPOINT");
        public string DATASETNAME => GetRecordedVariable("DATASET_NAME");
        public string BINGCONNECTIONNAME => GetRecordedVariable("BING_CONNECTION_NAME");
        public string MODELDEPLOYMENTNAME => GetRecordedVariable("MODEL_DEPLOYMENT_NAME");
        public string EMBEDDINGSMODELDEPLOYMENTNAME => GetRecordedVariable("EMBEDDINGS_MODEL_DEPLOYMENT_NAME");
        public string MODELPUBLISHER => GetRecordedVariable("MODEL_PUBLISHER");
        public string EMBEDDINGMODELDEPLOYMENTNAME => GetRecordedVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME");
        public string STORAGE_QUEUE_URI => GetRecordedVariable("STORAGE_QUEUE_URI");
        public string AZURE_BLOB_URI => GetRecordedVariable("AZURE_BLOB_URI");
        public string FABRICCONNECTIONNAME => GetRecordedVariable("FABRIC_CONNECTION_NAME");
        public string SHAREPOINTCONNECTIONNAME => GetRecordedVariable("SHAREPOINT_CONNECTION_NAME");
        public string INDEXNAME => GetRecordedVariable("INDEX_NAME");
        public string INDEXVERSION => GetRecordedVariable("INDEX_VERSION");
        public string AISEARCHCONNECTIONNAME => GetRecordedVariable("AI_SEARCH_CONNECTION_NAME");
        public string AISEARCHINDEXNAME => GetRecordedVariable("AI_SEARCH_INDEX_NAME");
        public string CONNECTIONNAME => GetRecordedVariable("CONNECTION_NAME");
        public string TESTIMAGEPNGINPUTPATH => GetRecordedVariable("TEST_IMAGE_PNG_INPUT_PATH");
    }
}
