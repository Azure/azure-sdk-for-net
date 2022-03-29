// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Verticals.AgriFood.Farming.Tests
{
    public class FarmBeatsClientLiveTestBase : RecordedTestBase<FarmBeatsClientTestEnvironment>
    {
        public FarmBeatsClientLiveTestBase(bool isAsync) : base(isAsync)
        {
        }

        public FarmersClient GetFarmersClient(FarmBeatsClientOptions options = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            options ??= new FarmBeatsClientOptions();

            return InstrumentClient(new FarmersClient(endpoint, TestEnvironment.Credential, InstrumentClientOptions(options)));
        }
    }
}
