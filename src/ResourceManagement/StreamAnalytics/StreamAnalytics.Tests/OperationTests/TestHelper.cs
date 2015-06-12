﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Net.Http;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.WindowsAzure.Management;
using Microsoft.Azure.Test;

namespace StreamAnalytics.Tests.OperationTests
{
    class TestHelper
    {
        // Azure Storage secrets
        public const string AccountName = "$EncryptedStringForTesting";
        public const string AccountKey = "$EncryptedStringForTesting";

        // Event Hub secrets
        public const string SharedAccessPolicyName = "$EncryptedStringForTesting";
        public const string SharedAccessPolicyKey = "$EncryptedStringForTesting";

        // SQL Azure secrets
        public const string Server = "$EncryptedStringForTesting";
        public const string Database = "$EncryptedStringForTesting";
        public const string User = "$EncryptedStringForTesting";
        public const string Password = "$EncryptedStringForTesting";

        /// <summary>
        /// Generate a Resource Management client from the test base to use for managing resource groups.
        /// </summary>
        /// <returns>Resource Management client</returns>
        public static ResourceManagementClient GetResourceClient(DelegatingHandler handler)
        {
            CSMTestEnvironmentFactory factory = new CSMTestEnvironmentFactory();
            return TestBase.GetServiceClient<ResourceManagementClient>(factory).WithHandler(handler);
        }

        public static StreamAnalyticsManagementClient GetStreamAnalyticsManagementClient(DelegatingHandler handler)
        {
            CSMTestEnvironmentFactory factory = new CSMTestEnvironmentFactory();
            return TestBase.GetServiceClient<StreamAnalyticsManagementClient>(factory).WithHandler(handler);
        }

        public static string GetDefaultLocation()
        {
            ManagementClient managementClient = TestBase.GetServiceClient<ManagementClient>();

            var serviceLocations = managementClient.Locations.ListAsync()
                    .Result.ToList();

            return serviceLocations.Any(l => l.Name.Equals("West US"))
                ? "West US"
                : serviceLocations.FirstOrDefault().Name;
        }
    }
}