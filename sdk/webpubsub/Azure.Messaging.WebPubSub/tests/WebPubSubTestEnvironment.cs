// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Rest.WebPubSub.Tests
{
    public class WebPubSubTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("WEBPUBSUB_ENDPOINT");
        public string Key => GetRecordedVariable("WEBPUBSUB_KEY", options => options.IsSecret());
        public string ConnectionString => $"Endpoint={Endpoint};AccessKey={Key};Version=1.0;";
    }
}
