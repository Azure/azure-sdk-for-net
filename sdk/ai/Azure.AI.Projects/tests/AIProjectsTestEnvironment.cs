// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Projects.Tests
{
    public class AIProjectsTestEnvironment : TestEnvironment
    {
        public string AzureAICONNECTIONSTRING => GetRecordedVariable("AZURE_AI_CONNECTION_STRING");
        public string BINGCONNECTIONNAME => GetRecordedVariable("BING_CONNECTION_NAME");
    }
}
