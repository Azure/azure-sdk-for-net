// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    public class PlanetaryComputerClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("PlanetaryComputer_ENDPOINT");

        // Add other client paramters here as above.
    }
}
