// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Maps.Weather;

namespace Azure.Maps.Weather.Tests
{
    public class WeatherClientLiveTestsBase : RecordedTestBase<WeatherClientTestEnvironment>
    {
        public WeatherClientLiveTestsBase(bool isAsync) : base(isAsync)
        {
        }

        protected MapsWeatherClient CreateClient()
        {
            return InstrumentClient(new MapsWeatherClient(
                credential: TestEnvironment.Credential,
                clientId: TestEnvironment.MapAccountClientId,
                options: InstrumentClientOptions(new MapsWeatherClientOptions())
            ));
        }
    }
}
