// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Maps.TimeZones;

namespace Azure.Maps.TimeZones.Tests
{
    public class TimeZoneClientLiveTestsBase : RecordedTestBase<TimeZoneClientTestEnvironment>
    {
        public TimeZoneClientLiveTestsBase(bool isAsync) : base(isAsync)
        {
        }

        protected MapsTimeZoneClient CreateClient()
        {
            return InstrumentClient(new MapsTimeZoneClient(
                credential: TestEnvironment.Credential,
                clientId: TestEnvironment.MapAccountClientId,
                options: InstrumentClientOptions(new MapsTimeZoneClientOptions())
             ));
        }
    }
}
