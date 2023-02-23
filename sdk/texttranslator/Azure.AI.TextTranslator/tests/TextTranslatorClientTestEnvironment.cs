// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.TextTranslator.Tests
{
    public class TextTranslatorClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("TextTranslator_ENDPOINT");

        // Add other client paramters here as above.
    }
}
