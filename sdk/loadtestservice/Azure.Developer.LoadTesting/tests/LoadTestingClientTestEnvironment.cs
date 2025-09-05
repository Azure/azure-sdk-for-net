// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Developer.LoadTesting.Tests
{
    public class LoadTestingClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("LOADTESTSERVICE_ENDPOINT");

        public string ResourceId => GetRecordedVariable("LOADTESTSERVICE_RESOURCE_ID");

        public string TargetResourceId => GetRecordedVariable("LOADTESTSERVICE_TARGET_RESOURCE_ID");
    }
}
