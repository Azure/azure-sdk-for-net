// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Maps.GeoLocation.Tests
{
    public class GeoLocationClientLiveTestsBase : RecordedTestBase<GeoLocationClientTestEnvironment>
    {
        public GeoLocationClientLiveTestsBase(bool isAsync) : base(isAsync)
        {
        }

        protected MapsGeoLocationClient CreateClient()
        {
            return InstrumentClient(new MapsGeoLocationClient(
                credential: TestEnvironment.Credential,
                clientId: TestEnvironment.MapAccountClientId,
                options: InstrumentClientOptions(new MapsGeoLocationClientOptions())
            ));
        }
    }
}
