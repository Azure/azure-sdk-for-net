// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System.Net.Http;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public static class SearchServiceFixtureExtensions
    {
        public static SearchServiceClient GetSearchServiceClient(
            this SearchServiceFixture fixture, 
            params DelegatingHandler[] handlers)
        {
            TestEnvironment currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();

            SearchServiceClient client =
                fixture.MockContext.GetServiceClientWithCredentials<SearchServiceClient>(
                    currentEnvironment,
                    new SearchCredentials(fixture.PrimaryApiKey),
                    internalBaseUri: true,
                    handlers: handlers);

            client.SearchServiceName = fixture.SearchServiceName;
            client.SearchDnsSuffix = currentEnvironment.GetSearchDnsSuffix(fixture.SearchServiceName);
            return client;
        }
    }
}
