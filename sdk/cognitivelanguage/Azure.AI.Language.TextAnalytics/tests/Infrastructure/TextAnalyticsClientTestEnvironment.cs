// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.TextAnalytics.Tests
{
    public class TextAnalyticsClientTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the master API key.
        /// </summary>
        public string ApiKey => GetRecordedVariable("AZURE_TEXT_KEY", options => options.IsSecret());

        /// <summary>
        /// Gets the endpoint for the Text Analytics service.
        /// </summary>
        public Uri Endpoint => new(GetRecordedVariable("AZURE_TEXT_ENDPOINT"), UriKind.Absolute);

        /// <summary>
        /// Gets the Custom NER project name.
        /// </summary>
        public string CTProjectName => GetRecordedVariable("AZURE_TEXT_CUSTOM_NER_PROJECT");

        /// <summary>
        /// Gets the Custom NER name.
        /// </summary>
        public string CTDeploymentName => GetRecordedVariable("AZURE_TEXT_CUSTOM_NER_DEPLOYMENT");

        /// <summary>
        /// Gets the Custom NER project name.
        /// </summary>
        public string CSCProjectName => GetRecordedVariable("AZURE_TEXT_CUSTOM_SINGLE_CLASSIFICATION_PROJECT");

        /// <summary>
        /// Gets the Custom NER name.
        /// </summary>
        public string CSCDeploymentName => GetRecordedVariable("AZURE_TEXT_CUSTOM_SINGLE_CLASSIFICATION_DEPLOYMENT");

        /// <summary>
        /// Gets the Custom NER project name.
        /// </summary>
        public string CMCProjectName => GetRecordedVariable("AZURE_TEXT_CUSTOM_MULTI_CLASSIFICATION_PROJECT");

        /// <summary>
        /// Gets the Custom NER name.
        /// </summary>
        public string CMCDeploymentName => GetRecordedVariable("AZURE_TEXT_CUSTOM_MULTI_CLASSIFICATION_DEPLOYMENT");
    }
}
