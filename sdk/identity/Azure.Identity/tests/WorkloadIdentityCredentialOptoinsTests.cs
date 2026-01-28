// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class WorkloadIdentityCredentialOptoinsTests
    {
        [Test]
        [NonParallelizable]
        public void VerifyOptionsDefaultToEnvironmentValues([Values] bool specifyTenantId, [Values] bool specifyClientId, [Values] bool specifyTokenFilePath)
        {
            string expTenantId = specifyTenantId ? Guid.NewGuid().ToString() : null;
            string expClientId = specifyClientId ? Guid.NewGuid().ToString() : null;
            string expTokenFilePath = specifyTokenFilePath ? Guid.NewGuid().ToString() : null;

            using (new TestEnvVar(
                new()
                {
                    { "AZURE_CLIENT_ID", expClientId },
                    { "AZURE_TENANT_ID", expTenantId },
                    { "AZURE_FEDERATED_TOKEN_FILE", expTokenFilePath },
                }))
            {
                var options = new WorkloadIdentityCredentialOptions();

                Assert.That(options.TenantId, Is.EqualTo(expTenantId));
                Assert.That(options.ClientId, Is.EqualTo(expClientId));
                Assert.That(options.TokenFilePath, Is.EqualTo(expTokenFilePath));
            }
        }
    }
}
