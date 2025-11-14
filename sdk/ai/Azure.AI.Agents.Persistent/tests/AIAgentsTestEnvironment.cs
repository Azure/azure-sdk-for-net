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
        public string BING_CONNECTION_ID => GetRecordedVariable("AZURE_BING_CONNECTION_ID");
        public string SHAREPOINT_CONNECTION_ID => GetRecordedVariable("AZURE_SHAREPOINT_CONNECTION_ID");
        public string FABRIC_CONNECTION_ID => GetRecordedVariable("AZURE_FABRIC_CONNECTION_ID");
        public string BING_CUSTOM_CONNECTION_ID => GetRecordedVariable("AZURE_BING_CUSTOM_CONNECTION_ID");
        public string DEEP_RESEARCH_MODEL_DEPLOYMENT_NAME => GetRecordedOptionalVariable("DEEP_RESEARCH_MODEL_DEPLOYMENT_NAME");
        public string BING_CONFIGURATION_NAME => GetRecordedOptionalVariable("BING_CONFIGURATION_NAME");
        public string PLAYWRIGHT_CONNECTION_ID => GetRecordedOptionalVariable("AZURE_PLAYWRIGHT_CONNECTION_ID");
        public string UPLOADED_IMAGE_ID => GetRecordedOptionalVariable("UPLOADED_IMAGE_ID");
    }
}
