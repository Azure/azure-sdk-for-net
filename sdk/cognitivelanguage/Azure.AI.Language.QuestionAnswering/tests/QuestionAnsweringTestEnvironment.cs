// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    /// <summary>
    /// Test environment settings for the Question Answering SDK.
    /// </summary>
    public class QuestionAnsweringTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the master API key.
        /// </summary>
        public string ApiKey => GetRecordedVariable("QNAMAKER_API_KEY");

        /// <summary>
        /// Gets the endpoint.
        /// </summary>
        public Uri Endpoint => new Uri(GetRecordedVariable("QNAMAKER_URI"), UriKind.Absolute);
    }
}
