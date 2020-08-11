// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    using System;

    public static class TestEnvironmentFactory
    {
        /// <summary>
        /// This is provided for existing testcase
        /// TODO: Find a way to replace this call from all test cases.
        /// We want to eliminate this Factory class
        /// </summary>
        /// <returns></returns>
        public static TestEnvironment GetTestEnvironment()
        {
            string envStr = Environment.GetEnvironmentVariable(TestCSMOrgIdConnectionStringKey);
            return new TestEnvironment(envStr);
        }

        /// <summary>
        /// The environment variable name for CSM OrgId authentication
        /// 
        /// Sample Value 1 - Get token from user and password:
        /// TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId={subscription-id};BaseUri=https://api-next.resources.windows-int.net/;UserId={user-id};Password={password}       
        /// 
        /// Sample Value 2 - Prompt for login credentials:
        /// TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId={subscription-id};AADAuthEndpoint=https://login.windows-ppe.net/;BaseUri=https://api-next.resources.windows-int.net/
        /// </summary>
        internal const string TestCSMOrgIdConnectionStringKey = "TEST_CSM_ORGID_AUTHENTICATION";
    }
}
