// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;

namespace Sql.Tests
{
    public static class TestEnvironmentUtilities
    {
        /// <summary>
        /// Gets the AAD user object id.
        /// </summary>
        /// <remarks>
        /// This could potentially be determined at runtime by requesting the service principal's object id
        /// from Azure AD graph API. However in practice this was difficult because the AAD graph client
        /// (Microsoft.Azure.ActiveDirectory.GraphClient) does not support .NET Core, and Microsoft graph client
        /// (Microsoft.Graph) does not yet support AAD Application API.
        /// </remarks>
        public static string GetUserObjectId()
        {
            const string objectIdKey = "ObjectId";

            return GetOrAddVariable(
                objectIdKey,
                () =>
                {
                    TestEnvironment testEnvironment = TestEnvironmentFactory.GetTestEnvironment();
                    string objectId;
                    if (testEnvironment.ConnectionString.KeyValuePairs.TryGetValue(objectIdKey, out objectId))
                    {
                        return objectId;
                    }
                    else
                    {
                        string servicePrincipal = testEnvironment.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey];

                        throw new KeyNotFoundException(
                            string.Format(
                                "Connection string key {0} not found. You can determine the correct value by running this in PowerShell:" +
                                " `Get-AzureRmADServicePrincipal -ServicePrincipalName {1}`, then add `ObjectId=<that object id>` to your" +
                                " TEST_CSM_ORGID_AUTHENTICATION connection string.",
                                objectIdKey,
                                servicePrincipal));
                    }
                });
        }

        /// <summary>
        /// Gets the AAD tenant id from the test environment.
        /// </summary>
        public static string GetTenantId()
        {
            const string tenantIdKey = "TenantId";

            return GetOrAddVariable(
                tenantIdKey,
                () =>
                {
                    TestEnvironment testEnvironment = TestEnvironmentFactory.GetTestEnvironment();
                    return testEnvironment.Tenant;
                });
        }

        /// <summary>
        /// Gets a variable from HTTP recording (when test is in playback mode) or writes a variable to HTTP recording
        /// (when test is in recording mode).
        /// </summary>
        /// <param name="key">Key that the variable value is stored under in HTTP recording file.</param>
        /// <param name="generateValueFunc">Function that generates the variable value if necessary.</param>
        /// <returns>The variable value.</returns>
        private static string GetOrAddVariable(string key, Func<string> generateValueFunc)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                string value = generateValueFunc();
                HttpMockServer.Variables[key] = value;
                return value;
            }
            else
            {
                return HttpMockServer.Variables[key];
            }
        }
    }
}
