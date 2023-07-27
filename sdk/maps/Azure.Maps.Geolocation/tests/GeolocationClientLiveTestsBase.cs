// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Maps.Geolocation.Tests
{
    public class GeolocationClientLiveTestsBase : RecordedTestBase<GeolocationClientTestEnvironment>
    {
        public GeolocationClientLiveTestsBase(bool isAsync) : base(isAsync)
        {
        }

        protected MapsGeolocationClient CreateClient()
        {
            return InstrumentClient(new MapsGeolocationClient(
                credential: TestEnvironment.Credential,
                clientId: TestEnvironment.MapAccountClientId,
                options: InstrumentClientOptions(new MapsGeolocationClientOptions())
            ));
        }
    }
}
