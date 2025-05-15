// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Analytics.OnlineExperimentation.Tests
{
    public class OnlineExperimentationClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("ENDPOINT");
    }
}
