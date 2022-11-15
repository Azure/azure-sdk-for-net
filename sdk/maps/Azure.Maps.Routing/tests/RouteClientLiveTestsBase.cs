// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Maps.Routing.Tests
{
    public class RouteClientLiveTestsBase : RecordedTestBase<RouteClientTestEnvironment>
    {
        public RouteClientLiveTestsBase(bool isAsync) : base(isAsync)
        {
        }

        protected MapsRoutingClient CreateClient()
        {
            return InstrumentClient(new MapsRoutingClient(
                credential: TestEnvironment.Credential,
                clientId: TestEnvironment.MapAccountClientId,
                options: InstrumentClientOptions(new MapsRoutingClientOptions())
            ));
        }
    }
}
