// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.BillingBenefits.Tests
{
    public class BillingBenefitsManagementTestEnvironment : TestEnvironment
    {
        public BillingBenefitsManagementTestEnvironment() : base()
        {
            Environment.SetEnvironmentVariable("CLIENT_ID", "3810c0dd-a10e-4865-99e2-47efa7250739");
            Environment.SetEnvironmentVariable("CLIENT_SECRET", "n6a8Q~m41wU6fAW1Q9AoOYqIark9zewFPgz2vc1t");
            Environment.SetEnvironmentVariable("SUBSCRIPTION_ID", "eef82110-c91b-4395-9420-fcfcbefc5a47");
            Environment.SetEnvironmentVariable("TENANT_ID", "ba5ed788-ddc6-429c-a6a2-0277f01dbee7");
            Environment.SetEnvironmentVariable("AZURE_AUTHORITY_HOST", "https://login.microsoftonline.com/");
        }
    }
}
