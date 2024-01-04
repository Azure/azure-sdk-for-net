// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Translator.Document.Tests
{
    public class DocumentClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Document_ENDPOINT");

        // Add other client paramters here as above.
    }
}
