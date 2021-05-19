// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Iot.Hub.Service.Tests
{
    // This class contains the configurations required to be set to run tests against the CI pipeline.
    public class IotHubServiceTestEnvironment : TestEnvironment
    {
        public string IotHubConnectionString => GetRecordedVariable(TestSettings.IotHubConnectionString,
            options => options
                .HasSecretConnectionStringParameter("SharedAccessKey", SanitizedValue.Base64)
                .HasSecretConnectionStringParameter("HostName", CustomRequestSanitizer.FakeHost));

        public Uri StorageSasToken => new Uri(GetRecordedVariable(TestSettings.StorageSasToken,
            options => options.IsSecret(CustomRequestSanitizer.FakeStorageUri)));
    }
}
