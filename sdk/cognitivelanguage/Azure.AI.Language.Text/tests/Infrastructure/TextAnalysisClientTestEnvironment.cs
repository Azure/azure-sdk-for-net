// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.Text.Tests
{
    public class TextAnalysisClientTestEnvironment : TestEnvironment
    {
        public Uri Endpoint => new(GetRecordedVariable("AZURE_TEXT_ENDPOINT"));

        // Add other client paramters here as above.
        public string ApiKey => GetRecordedVariable("AZURE_TEXT_KEY", options => options.IsSecret());

        public string CTProjectName => GetRecordedVariable("AZURE_TEXT_CUSTOM_NER_PROJECT");

        public string CTDeploymentName => GetRecordedVariable("AZURE_TEXT_CUSTOM_NER_DEPLOYMENT");

        public string CSCProjectName => GetRecordedVariable("AZURE_TEXT_CUSTOM_SINGLE_CLASSIFICATION_PROJECT");

        public string CSCDeploymentName => GetRecordedVariable("AZURE_TEXT_CUSTOM_SINGLE_CLASSIFICATION_DEPLOYMENT");

        public string CMCProjectName => GetRecordedVariable("AZURE_TEXT_CUSTOM_MULTI_CLASSIFICATION_PROJECT");

        public string CMCDeploymentName => GetRecordedVariable("AZURE_TEXT_CUSTOM_MULTI_CLASSIFICATION_DEPLOYMENT");
    }
}
