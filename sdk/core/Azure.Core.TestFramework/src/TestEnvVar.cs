// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Core.TestFramework
{
    public class TestEnvVar : DisposableConfig
    {
        private static SemaphoreSlim _lock = new(1, 1);
        public TestEnvVar(string name, string value) : base(name, value, _lock) { }
        public TestEnvVar(Dictionary<string, string> values) : base(values, _lock) { }

        internal override void SetValue(string name, string value)
        {
            _originalValues[name] = Environment.GetEnvironmentVariable(name);

            CleanExistingEnvironmentVariables();

            Environment.SetEnvironmentVariable(name, value as string);
        }

        internal override void SetValues(Dictionary<string, string> values)
        {
            foreach (var kvp in values)
            {
                _originalValues[kvp.Key] = kvp.Value;
            }

            CleanExistingEnvironmentVariables();

            foreach (var kvp in values)
            {
                Environment.SetEnvironmentVariable(kvp.Key, kvp.Value as string);
            }
        }

        internal override void InitValues()
        {
            // Common environment variables to be saved off for tests. Add more as needed
            _originalValues["AZURE_USERNAME"] = Environment.GetEnvironmentVariable("AZURE_USERNAME");
            _originalValues["AZURE_PASSWORD"] = Environment.GetEnvironmentVariable("AZURE_PASSWORD");
            _originalValues["AZURE_TENANT_ID"] = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
            _originalValues["AZURE_CLIENT_ID"] = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
            _originalValues["AZURE_CLIENT_SECRET"] = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");
            _originalValues["AZURE_CLIENT_CERTIFICATE_PATH"] = Environment.GetEnvironmentVariable("AZURE_CLIENT_CERTIFICATE_PATH");
            _originalValues["IDENTITY_ENDPOINT"] = Environment.GetEnvironmentVariable("IDENTITY_ENDPOINT");
            _originalValues["IDENTITY_HEADER"] = Environment.GetEnvironmentVariable("IDENTITY_HEADER");
            _originalValues["MSI_ENDPOINT"] = Environment.GetEnvironmentVariable("MSI_ENDPOINT");
            _originalValues["MSI_SECRET"] = Environment.GetEnvironmentVariable("MSI_SECRET");
            _originalValues["IMDS_ENDPOINT"] = Environment.GetEnvironmentVariable("IMDS_ENDPOINT");
            _originalValues["IDENTITY_SERVER_THUMBPRINT"] = Environment.GetEnvironmentVariable("IDENTITY_SERVER_THUMBPRINT");
        }

        // clear the existing values so that the test needs only set up the values relevant to it.
        private void CleanExistingEnvironmentVariables()
        {
            foreach (var kvp in _originalValues)
            {
                Environment.SetEnvironmentVariable(kvp.Key, null);
            }
        }
        internal override void Cleanup()
        {
            foreach (var kvp in _originalValues)
            {
                Environment.SetEnvironmentVariable(kvp.Key, kvp.Value as string);
            }
        }
    }
}
