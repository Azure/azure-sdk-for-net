// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Maps.TimeZone;

namespace Azure.Maps.TimeZone.Tests
{
    public class TimeZoneClientLiveTestsBase : RecordedTestBase
    {
        public TimeZoneClientLiveTestsBase(bool isAsync) : base(isAsync)
        {
        }

        protected MapsTimeZoneClient CreateClient()
        {
            return InstrumentClient(new MapsTimeZoneClient(
                credential: new AzureKeyCredential("<My Subscription Key>"),
                options: InstrumentClientOptions(new MapsTimeZoneClientOptions())
             ));
        }
    }
}
