// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.Synapse.Tests
{
    /// <summary>
    /// Test utilities 
    /// </summary>
    public static class SynapseManagementTestUtilities
    {
        /// <summary>
        /// Determine whether the current test mode is record mode
        /// </summary>
        /// <returns></returns>
        public static bool IsRecordMode()
        {
            return HttpMockServer.Mode == HttpRecorderMode.Record;
        }

        /// <summary>
        /// Determine whether the current test mode is playback mode
        /// </summary>
        /// <returns></returns>
        public static bool IsPlaybackMode()
        {
            return HttpMockServer.Mode == HttpRecorderMode.Playback;
        }

        /// <summary>
        /// Get current subscription Id from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetSubscriptionId()
        {
            string subscriptionId = null;
            if (IsRecordMode())
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.SubscriptionIdKey] = environment.SubscriptionId;
                subscriptionId = environment.SubscriptionId;
            }
            else if (IsPlaybackMode())
            {
                subscriptionId = HttpMockServer.Variables[ConnectionStringKeys.SubscriptionIdKey];
            }

            return subscriptionId;
        }

        /// <summary>
        /// Get current tenant Id from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetTenantId()
        {
            string tenantId = null;
            if (IsRecordMode())
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.AADTenantKey] = environment.Tenant;
                tenantId = environment.Tenant;
            }
            else if (IsPlaybackMode())
            {
                tenantId = HttpMockServer.Variables[ConnectionStringKeys.AADTenantKey];
            }
            return tenantId;
        }

        /// <summary>
        /// Get service principal Id from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetServicePrincipalId()
        {
            string servicePrincipalId = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey] = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.ServicePrincipalKey);
                servicePrincipalId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                servicePrincipalId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];
            }
            return servicePrincipalId;
        }

        /// <summary>
        /// Get service principal secret from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetServicePrincipalSecret()
        {
            string servicePrincipalSecret = null;
            if (IsRecordMode())
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                servicePrincipalSecret = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.ServicePrincipalSecretKey);
            }
            else if (IsPlaybackMode())
            {
                servicePrincipalSecret = "xyz";
            }
            return servicePrincipalSecret;
        }

        /// <summary>
        /// Get service principal object id from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetServicePrincipalObjectId()
        {
            string servicePrincipalObjectId = null;
            if (IsRecordMode())
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.AADClientIdKey] = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.AADClientIdKey);
                servicePrincipalObjectId = HttpMockServer.Variables[ConnectionStringKeys.AADClientIdKey];
            }
            else if (IsPlaybackMode())
            {
                servicePrincipalObjectId = HttpMockServer.Variables[ConnectionStringKeys.AADClientIdKey];
            }
            return servicePrincipalObjectId;
        }

        /// <summary>
        /// Get access token
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            string accessToken = null;
            if (IsRecordMode())
            {
                var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
                string authClientId = GetServicePrincipalId();
                string authSecret = GetServicePrincipalSecret();
                var clientCredential = new ClientCredential(authClientId, authSecret);
                var result = await context.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);
                accessToken = result.AccessToken;
            }
            else if (IsPlaybackMode())
            {
                accessToken = "fake-token";
            }

            return accessToken;
        }

        /// <summary>
        /// Get delegating handlers
        /// </summary>
        /// <returns></returns>
        public static DelegatingHandler[] GetHandlers()
        {
            HttpMockServer server = HttpMockServer.CreateInstance();
            return new DelegatingHandler[] { server };
        }

        /// <summary>
        /// Create workspace create parameters.
        /// </summary>
        /// <param name="commonData"></param>
        /// <returns></returns>
        public static Workspace PrepareWorkspaceCreateParams(this CommonTestFixture commonData)
        {
            return new Workspace
            {
                Location = commonData.Location,
                Identity = new ManagedIdentity
                {
                    Type = ResourceIdentityType.SystemAssigned
                },
                DefaultDataLakeStorage = new DataLakeStorageAccountDetails
                {
                    AccountUrl = commonData.DefaultDataLakeStorageAccountUrl,
                    Filesystem = commonData.DefaultDataLakeStorageFilesystem
                },
                SqlAdministratorLogin = commonData.SshUsername,
                SqlAdministratorLoginPassword = commonData.SshPassword
            };
        }

        /// <summary>
        /// Create sqlpool create parameters.
        /// </summary>
        /// <param name="commonData"></param>
        /// <returns></returns>
        public static SqlPool PrepareSqlpoolCreateParams(this CommonTestFixture commonData)
        {
            return new SqlPool
            {
                Location = commonData.Location,
                Sku = new Sku
                {
                    Name = commonData.PerformanceLevel
                }
            };
        }

        /// <summary>
        /// Create spark create parameters.
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="enableAutoScale"></param>
        /// <param name="enableAutoPause"></param>
        /// <returns></returns>
        public static BigDataPoolResourceInfo PrepareSparkpoolCreateParams(this CommonTestFixture commonData, bool enableAutoScale, bool enableAutoPause)
        {
            return new BigDataPoolResourceInfo
            {
                Location = commonData.Location,
                NodeCount = enableAutoScale ? (int?)null : commonData.NodeCount,
                NodeSizeFamily = NodeSizeFamily.MemoryOptimized,
                NodeSize = commonData.NodeSize,
                AutoScale = !enableAutoScale ? null : new AutoScaleProperties
                {
                    Enabled = enableAutoScale,
                    MinNodeCount = commonData.AutoScaleMinNodeCount,
                    MaxNodeCount = commonData.AutoScaleMaxNodeCount
                },
                AutoPause = !enableAutoPause ? null : new AutoPauseProperties
                {
                    Enabled = enableAutoPause,
                    DelayInMinutes = commonData.AutoPauseDelayInMinute
                },
                SparkVersion = commonData.SparkVersion
            };
        }

        /// <summary>
        /// Create fire wall rule create parameters.
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="startIpAddress"></param>
        /// <param name="endIpAddress"></param>
        /// <returns></returns>
        public static IpFirewallRuleInfo PrepareFirewallRuleParams(this CommonTestFixture commonData, string startIpAddress, string endIpAddress)
        {
            return new IpFirewallRuleInfo
            {
                StartIpAddress = startIpAddress,
                EndIpAddress = endIpAddress
            };
        }

        /// <summary>
        /// List resources from IPage to List.
        /// </summary>
        /// <param name="firstPage"></param>
        /// <param name="listNext"></param>
        /// <returns></returns>
        public static List<T> ListResources<T>(IPage<T> firstPage, Func<string, IPage<T>> listNext)
        {
            var resourceList = new List<T>();
            var response = firstPage;
            resourceList.AddRange(response);

            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = listNext(response.NextPageLink);
                resourceList.AddRange(response);
            }

            return resourceList;
        }
    }
}
