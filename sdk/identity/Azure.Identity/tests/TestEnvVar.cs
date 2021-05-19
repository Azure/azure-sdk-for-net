// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Identity.Tests
{
    internal class TestEnvVar : IDisposable
    {
        private static SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        private readonly Dictionary<string, string> _originalValues = new Dictionary<string, string>()
        {
            { "AZURE_USERNAME", EnvironmentVariables.Username},
            { "AZURE_PASSWORD", EnvironmentVariables.Password},
            { "AZURE_TENANT_ID", EnvironmentVariables.TenantId},
            { "AZURE_CLIENT_ID", EnvironmentVariables.ClientId},
            { "AZURE_CLIENT_SECRET", EnvironmentVariables.ClientSecret},
            { "AZURE_CLIENT_CERTIFICATE_PATH", EnvironmentVariables.ClientCertificatePath},
            { "IDENTITY_ENDPOINT", EnvironmentVariables.IdentityEndpoint},
            { "IDENTITY_HEADER", EnvironmentVariables.IdentityHeader},
            { "MSI_ENDPOINT", EnvironmentVariables.MsiEndpoint},
            { "MSI_SECRET", EnvironmentVariables.MsiSecret},
            { "IMDS_ENDPOINT", EnvironmentVariables.ImdsEndpoint},
            { "IDENTITY_SERVER_THUMBPRINT", EnvironmentVariables.IdentityServerThumbprint},
        };

        public TestEnvVar(string name, string value)
        {
            var acquired = _lock.Wait(TimeSpan.Zero);
            if (!acquired)
            {
                throw new Exception($"Concurrent use of {nameof(TestEnvVar)}. Consider marking these tests as NonParallelizable.");
            }

            _originalValues[name] = Environment.GetEnvironmentVariable(name);

            CleanExistingEnvironmentVariables();

            Environment.SetEnvironmentVariable(name, value);
        }

        public TestEnvVar(Dictionary<string, string> environmentVariables)
        {
            var acquired = _lock.Wait(TimeSpan.Zero);
            if (!acquired)
            {
                throw new Exception($"Concurrent use of {nameof(TestEnvVar)}. Consider marking these tests as NonParallelizable.");
            }

            foreach (var kvp in environmentVariables)
            {
                _originalValues[kvp.Key] = kvp.Value;
            }

            CleanExistingEnvironmentVariables();

            foreach (var kvp in environmentVariables)
            {
                Environment.SetEnvironmentVariable(kvp.Key, kvp.Value);
            }
        }

        public void Dispose()
        {
            foreach (var kvp in _originalValues)
            {
                Environment.SetEnvironmentVariable(kvp.Key, kvp.Value);
            }
            _lock.Release();
        }

        // clear the existing values so that the test needs only set up the values relevant to it.
        private void CleanExistingEnvironmentVariables()
        {
            foreach (var kvp in _originalValues)
            {
                Environment.SetEnvironmentVariable(kvp.Key, null);
            }
        }
    }
}
