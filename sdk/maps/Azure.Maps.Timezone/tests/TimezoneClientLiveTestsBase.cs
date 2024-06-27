// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Maps.Timezone.Tests
{
    public class TimezoneClientLiveTestsBase : RecordedTestBase
    {
        public TimezoneClientLiveTestsBase(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }

        protected MapsTimezoneClient CreateClient()
        {
            return InstrumentClient(new MapsTimezoneClient(
                credential: new AzureKeyCredential("<My Subscription Key>"),
                options: InstrumentClientOptions(new MapsTimezoneClientOptions())
             ));
        }
    }
}
