// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity;

namespace Azure.Core.Testing
{
    public class TestEnvironment
    {
        private readonly string _prefix;

        public TestEnvironment(string serviceName)
        {
            _prefix = serviceName.ToUpperInvariant() + "_";
        }

        public string GetOptionalVariable(string name)
        {
            var prefixedName = _prefix + name;
            return Environment.GetEnvironmentVariable(prefixedName) ??
                   Environment.GetEnvironmentVariable(name);
        }

        public string GetVariable(string name)
        {
            var value = GetOptionalVariable(name);
            if (value == null)
            {
                var prefixedName = _prefix + name;
                throw new InvalidOperationException(
                    $"Unable to find environment variable {prefixedName} or {name} required by test." + Environment.NewLine +
                    "Make sure the test environment was initialized using eng/common/TestResources/New-TestResources.ps1 script.");
            }

            return value;
        }

        public TokenCredential Credential => new ClientSecretCredential(
            GetVariable("TENANT_ID"),
            GetVariable("CLIENT_ID"),
            GetVariable("CLIENT_SECRET")
            );

        public string SubscriptionId => GetVariable("SUBSCRIPTION_ID");
        public string ResourceGroup => GetVariable("RESOURCE_GROUP");
        public string Location => GetVariable("LOCATION");
        public string AzureEnvironment => GetVariable("ENVIRONMENT");
    }
}