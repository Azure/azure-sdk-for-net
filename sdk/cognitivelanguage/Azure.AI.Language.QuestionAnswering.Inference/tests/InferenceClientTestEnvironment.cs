// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Inference.Tests
{
    public class InferenceClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Inference_ENDPOINT");

        // Add other client paramters here as above.
    }
}
