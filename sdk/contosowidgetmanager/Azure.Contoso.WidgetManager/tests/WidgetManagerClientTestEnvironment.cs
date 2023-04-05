// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Contoso.WidgetManager.Tests
{
    public class WidgetManagerClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("WidgetManager_ENDPOINT");

        // Add other client paramters here as above.
    }
}
