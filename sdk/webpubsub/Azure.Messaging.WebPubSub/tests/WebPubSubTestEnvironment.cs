// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Rest.WebPubSub.Tests
{
    public class WebPubSubTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("WPS_ENDPOINT");
        public string Key => GetRecordedVariable("WPS_KEY");
        public string ConnectionString => $"Endpoint={Endpoint};AccessKey={Key};Version=1.0;";
    }
}
