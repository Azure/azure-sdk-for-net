// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Template.Tests
{
    public class TemplateClientTestEnvironment : TestEnvironment
    {
        // TODO: Update these properties to match your service's test environment variables
        public string Endpoint => GetRecordedVariable("SERVICE_ENDPOINT");

        // You can sanitize secrets from recorded variables e.g., principal secrets.
        // See https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework#test-environment-and-live-test-resources for variables,
        // and https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework#sanitizing for sanitizing responses.

        // Example of a secret variable:
        // public string ApiKey => GetRecordedVariable("API_KEY", options => options.IsSecret());
    }
}
