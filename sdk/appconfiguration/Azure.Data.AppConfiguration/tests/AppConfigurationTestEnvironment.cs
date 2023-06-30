// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Data.AppConfiguration
{
    public class AppConfigurationTestEnvironment : TestEnvironment
    {
        public string ConnectionString => GetRecordedVariable("APPCONFIGURATION_CONNECTION_STRING", options => options.HasSecretConnectionStringParameter("secret", SanitizedValue.Base64));
        public string Endpoint => GetRecordedVariable("APPCONFIGURATION_ENDPOINT_STRING");
        public string SecretId => GetRecordedVariable("KEYVAULT_SECRET_URL");

        /// <summary>
        /// Get a random name so we won't have any conflicts when creating resources.
        /// </summary>
        /// <param name="prefix">Optional prefix for the random name.</param>
        /// <returns>A random name.</returns>
        public string Randomize(string prefix = "sample") =>
            $"{prefix}-{Guid.NewGuid()}";
    }
}
