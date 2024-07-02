// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Rest.WebPubSub.Tests
{
    public class WebPubSubTestEnvironment : TestEnvironment
    {
        public string ConnectionString => GetRecordedVariable("WEBPUBSUB_CONNECTIONSTRING", options => options.HasSecretConnectionStringParameter("accessKey", SanitizedValue.Base64));
    }
}
