// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Template.Contoso.Tests
{
    public class ContosoClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Contoso_ENDPOINT");

        // Add other client paramters here as above.
    }
}
