// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Agents.Persistent.Tests
{
    public class AIAgentsTestEnvironment : TestEnvironment
    {
        public string PROJECT_ENDPOINT => GetRecordedVariable("PROJECT_ENDPOINT");
        public string PROJECT_CONNECTION_STRING => GetRecordedVariable("PROJECT_CONNECTION_STRING");
        public string BINGCONNECTIONNAME => GetRecordedVariable("BING_CONNECTION_NAME");
        public string MODELDEPLOYMENTNAME => GetRecordedVariable("MODEL_DEPLOYMENT_NAME");
        public string EMBEDDINGMODELDEPLOYMENTNAME => GetRecordedVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME");
        public string STORAGE_QUEUE_URI => GetRecordedVariable("STORAGE_QUEUE_URI");
        public string AZURE_BLOB_URI => GetRecordedVariable("AZURE_BLOB_URI");

        public string AI_SEARCH_CONNECTION_ID => GetRecordedVariable("AZURE_AI_CONNECTION_ID");
        public string BING_CONECTION_ID => GetRecordedVariable("AZURE_BING_CONECTION_ID");
    }
}
