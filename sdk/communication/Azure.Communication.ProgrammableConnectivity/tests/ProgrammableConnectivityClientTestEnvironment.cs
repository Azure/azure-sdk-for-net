// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Communication.ProgrammableConnectivity.Tests
{
    public class ProgrammableConnectivityClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("ProgrammableConnectivity_ENDPOINT");
    }
}
