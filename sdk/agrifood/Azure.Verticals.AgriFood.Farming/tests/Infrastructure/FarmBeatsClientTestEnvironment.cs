// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Verticals.AgriFood.Farming.Tests
{
    public class FarmBeatsClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("FARMBEATS_ENDPOINT");
    }
}
