// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Maps.Route.Tests
{
    public class RouteClientLiveTestsBase : RecordedTestBase<RouteClientTestEnvironment>
    {
        public RouteClientLiveTestsBase(bool isAsync) : base(isAsync)
        {
        }

        protected MapsRouteClient CreateClient()
        {
            return InstrumentClient(new MapsRouteClient(
                credential: TestEnvironment.Credential,
                clientId: TestEnvironment.MapAccountClientId,
                options: InstrumentClientOptions(new MapsRouteClientOptions())
            ));
        }
    }
}
