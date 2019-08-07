// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Sql.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sql.Tests
{
    public static class TestEnvironmentUtilities
    {
        private const string _environmentVariableName = "TEST_CSM_ORGID_AUTHENTICATION";

        private static readonly TestEnvironment _environment =
            new TestEnvironment(Environment.GetEnvironmentVariable(_environmentVariableName));

        // We now load default locations from environment variable.
        // Tests were recorded with this appended to DefaultLocationId=japaneast;DefaultLocation=Japan East;DefaultSecondaryLocationId=centralus;DefaultSecondaryLocation=Central US;DefaultStagePrimaryLocation=North Europe;DefaultStageSecondaryLocation=SouthEast Asia;DefaultEuapPrimaryLocation=East US 2 EUAP;DefaultEuapPrimaryLocationId=eastus2euap
        public static string DefaultLocation
        {
            get
            {
                return GetValueFromEnvironment("DefaultLocation");
            }
        }
        public static string DefaultLocationId
        {
            get
            {
                return GetValueFromEnvironment("DefaultLocationId");
            }
        }

        public static string DefaultSecondaryLocationId
        {
            get
            {
                return GetValueFromEnvironment("DefaultSecondaryLocationId");
            }
        }

        public static string DefaultSecondaryLocation
        {
            get
            {
                return GetValueFromEnvironment("DefaultSecondaryLocation");
            }
        }
        public static string DefaultStagePrimaryLocation
        {
            get
            {
                return GetValueFromEnvironment("DefaultStagePrimaryLocation", DefaultLocation);
            }
        }

        public static string DefaultStageSecondaryLocation
        {
            get
            {
                return GetValueFromEnvironment("DefaultStageSecondaryLocation", DefaultSecondaryLocation);
            }
        }

        public static string DefaultEuapPrimaryLocation
        {
            get
            {
                return GetValueFromEnvironment("DefaultEuapPrimaryLocation", DefaultLocation);
            }
        }

        public static string DefaultEuapPrimaryLocationId
        {
            get
            {
                return GetValueFromEnvironment("DefaultEuapPrimaryLocationId", DefaultLocationId);
            }
        }

        public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            TestEnvironment testEnvironment = TestEnvironmentFactory.GetTestEnvironment();

            var context = new AuthenticationContext(authority);
            string authClientId = testEnvironment.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey];
            string authSecret = testEnvironment.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalSecretKey];
            var clientCredential = new ClientCredential(authClientId, authSecret);
            var result = await context.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);

            return result.AccessToken;
        }

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
                    string objectId;
                    if (_environment.ConnectionString.KeyValuePairs.TryGetValue(objectIdKey, out objectId))
                    {
                        return objectId;
                    }
                    else
                    {
                        string servicePrincipal = _environment.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey];

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
                    return _environment.Tenant;
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

        /// <summary>
        /// Gets values from the loaded environment
        /// </summary>
        private static string GetValueFromEnvironment(string key, string backupValue = null)
        {
            return GetOrAddVariable(key, () =>
            {
                string value;
                bool successful = _environment.ConnectionString.KeyValuePairs.TryGetValue(key, out value);

                if (!successful)
                {
                    // For variables that may default to other locations (i.e. stage location, if not provided, should default to default production location),
                    // Check if the backup value is not null and return that if the the environment variable is not found.
                    if(backupValue != null)
                    {
                        return backupValue;
                    }

                    throw new KeyNotFoundException(
                        string.Format("Value for key '{0}' was not found in environment variable '{1}'.  Ensure this value is included in the environment variable.",
                            key, _environmentVariableName));
                }

                return value;
            });
        }

        public static KeyVaultClient GetKeyVaultClient()
        {
            DelegatingHandler mockServer = HttpMockServer.CreateInstance();
            return new KeyVaultClient(new TestKeyVaultCredential(GetAccessToken), handlers: mockServer);
        }
    }
}
