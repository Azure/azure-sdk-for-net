// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Template.Generated.Tests
{
    public class TemplateServiceTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Template_ENDPOINT");
    }
}
