// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Testing
{
    public partial class TestEnvironment
    {
        private readonly string _prefix;

        public TestEnvironment(string serviceName)
        {
            _prefix = serviceName.ToUpperInvariant() + "_";
        }

        partial void GetRecordedValue(string name, ref string value, ref bool isPlayback);
        partial void SetRecordedValue(string name, string value);

        protected string GetRecordedOptionalVariable(string name)
        {
            var prefixedName = _prefix + name;

            string value = null;
            bool isPlayback = false;

            GetRecordedValue(name, ref value, ref isPlayback);
            if (isPlayback)
            {
                return value;
            }

            value = Environment.GetEnvironmentVariable(prefixedName) ??
                   Environment.GetEnvironmentVariable(name);

            SetRecordedValue(name, value);

            return value;
        }

        protected string GetRecordedVariable(string name)
        {
            var value = GetRecordedOptionalVariable(name);
            if (value == null)
            {
                var prefixedName = _prefix + name;
                throw new InvalidOperationException(
                    $"Unable to find environment variable {prefixedName} or {name} required by test." + Environment.NewLine +
                    "Make sure the test environment was initialized using eng/common/TestResources/New-TestResources.ps1 script.");
            }

            return value;
        }
        protected string GetOptionalVariable(string name)
        {
            var prefixedName = _prefix + name;

            var value = Environment.GetEnvironmentVariable(prefixedName) ??
                        Environment.GetEnvironmentVariable(name);

            return value;
        }

        protected string GetVariable(string name)
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

        public string SubscriptionId => GetRecordedVariable("SUBSCRIPTION_ID");
        public string ResourceGroup => GetRecordedVariable("RESOURCE_GROUP");
        public string Location => GetRecordedVariable("LOCATION");
        public string AzureEnvironment => GetRecordedVariable("ENVIRONMENT");
        public string TenantId => GetRecordedVariable("TENANT_ID");
        public string ClientId => GetVariable("CLIENT_ID");
        public string ClientSecret => GetVariable("CLIENT_SECRET");
    }
}