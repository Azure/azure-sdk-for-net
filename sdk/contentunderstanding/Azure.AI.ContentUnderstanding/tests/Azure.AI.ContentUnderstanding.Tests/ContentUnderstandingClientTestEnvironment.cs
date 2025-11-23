// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    public class ContentUnderstandingClientTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the endpoint URL for the Content Understanding service.
        /// </summary>
        /// <remarks>
        /// This value is read from the environment variable: CONTENTUNDERSTANDING_ENDPOINT
        /// In Playback mode, a fake endpoint is used: https://fake_contentunderstanding_endpoint.services.ai.azure.com/
        /// </remarks>
        /// <summary>
        /// Gets the endpoint URL for the Content Understanding service.
        /// </summary>
        public string Endpoint => GetRecordedVariable("CONTENTUNDERSTANDING_ENDPOINT");

        /// <summary>
        /// Gets the API key for authenticating with the Content Understanding service.
        /// </summary>
        public string ApiKey => GetRecordedOptionalVariable("AZURE_CONTENT_UNDERSTANDING_KEY");
    }
}
