// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Maps.Weather;

namespace Azure.Maps.Weather.Tests
{
    public class WeatherClientLiveTestsBase : RecordedTestBase
    {
        public WeatherClientLiveTestsBase(bool isAsync) : base(isAsync)
        {
        }

        protected MapsWeatherClient CreateClient()
        {
            return InstrumentClient(new MapsWeatherClient(
                credential: new AzureKeyCredential("<My Subscription Key>"),
                options: InstrumentClientOptions(new MapsWeatherClientOptions())
            ));
        }
    }
}
