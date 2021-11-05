// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Globalization;

namespace StreamAnalytics.Tests
{
    public static class TestHelper
    {
        public const string DefaultLocation = "West US";

        public const string ResourceIdFormat =
            "/subscriptions/{0}/resourceGroups/{1}/providers/" + ResourceProviderNamespace + "/{2}/{3}";
        public const string RestOnlyResourceIdFormat = ResourceIdFormat + "/{4}/{5}";
        public static readonly string StreamingJobFullResourceType = string.Format(CultureInfo.InvariantCulture, "{0}/{1}",
            ResourceProviderNamespace, StreamingJobResourceType);
        public static readonly string ClusterFullResourceType = string.Format(CultureInfo.InvariantCulture, "{0}/{1}",
            ResourceProviderNamespace, ClusterResourceType);
        public static readonly string PrivateEndpointFullResourceType = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}",
            ResourceProviderNamespace, ClusterResourceType, PrivateEndpointResourceType);
        public static readonly string RestOnlyResourceTypeFormat = StreamingJobFullResourceType + "/{0}";
        public const string ResourceProviderNamespace = "Microsoft.StreamAnalytics";
        public const string StreamingJobResourceType = "streamingjobs";
        public const string ClusterResourceType = "clusters";
        public const string PrivateEndpointResourceType = "privateEndpoints";
        public const string InputsResourceType = "inputs";
        public const string TransformationResourceType = "transformations";
        public const string FunctionsResourceType = "functions";
        public const string OutputsResourceType = "outputs";

        // Azure Storage account example values
        public const string AccountName = "$testAccountName$";
        public const string AccountKey = @"$testStorageAccountKey$";
        public const string Container = "state";
        public const string AzureTableName = "samples";

        // Event Hub/Service Bus example values
        public const string EventHubName = "sdkeventhub";
        public const string ServiceBusNamespace = "sdktest";
        public const string SharedAccessPolicyName = "RootManageSharedAccessKey";
        public const string SharedAccessPolicyKey = @"$testSharedAccessPolicyKey$";
        public const string QueueName = "sdkqueue";
        public const string TopicName = "sdktopic";

        // IoT Hub example values
        public const string IoTHubNamespace = "$testIoTHubNamespace$";
        public const string IoTSharedAccessPolicyName = "owner";
        public const string IoTHubSharedAccessPolicyKey = @"$testIoTHubSharedAccessPolicyKey$";

        // DocumentDB example values
        public const string DocDbAccountId = "$testDocDbAccountId$";
        public const string DocDbAccountKey = @"$testDocDbAccountKey$";
        public const string DocDbDatabase = "db01";

        // SQL Azure example values
        public const string Server = "$testSqlServer$";
        public const string Database = "$testSqlDatabase$";
        public const string User = "$testSqlUser$";
        public const string Password = @"$testSqlPassword$";
        public const string SqlTableName = "$testSqlTable$";

        // Function example values
        public const string ExecuteEndpoint = "$testExecuteEndpoint$";
        public const string ApiKey = "$testApiKey$";

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static ResourceManagementClient GetResourceManagementClient(this TestBase testBase, MockContext context)
        {
            var client = context.GetServiceClient<ResourceManagementClient>();
            return client;
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A Stream Analytics management client, created from the current context (environment variables)</returns>
        public static StreamAnalyticsManagementClient GetStreamAnalyticsManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<StreamAnalyticsManagementClient>();
        }

        public static string GetJobResourceId(string subscriptionId, string resourceGroupName, string resourceName)
        {
            return string.Format(CultureInfo.InvariantCulture, ResourceIdFormat, subscriptionId, resourceGroupName, StreamingJobResourceType, resourceName);
        }

        public static string GetClusterResourceId(string subscriptionId, string resourceGroupName, string resourceName)
        {
            return string.Format(CultureInfo.InvariantCulture, ResourceIdFormat, subscriptionId, resourceGroupName, ClusterResourceType, resourceName);
        }

        public static string GetPrivateEndpointResourceId(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointName)
        {
            return string.Format(CultureInfo.InvariantCulture, ResourceIdFormat, subscriptionId, resourceGroupName, ClusterResourceType, resourceName, PrivateEndpointResourceType, privateEndpointName);
        }

        public static string GetRestOnlyResourceId(string subscriptionId, string resourceGroupName, string resourceName, string resourceType,
            string restOnlyResourceName)
        {
            return string.Format(CultureInfo.InvariantCulture, RestOnlyResourceIdFormat, subscriptionId, resourceGroupName, StreamingJobResourceType, resourceName,
                resourceType, restOnlyResourceName);
        }

        public static string GetFullRestOnlyResourceType(string resourceType)
        {
            return string.Format(CultureInfo.InvariantCulture, RestOnlyResourceTypeFormat, resourceType);
        }

        public static StreamingJob GetDefaultStreamingJob()
        {
            return new StreamingJob()
            {
                Tags = new Dictionary<string, string>()
                    {
                        { "key1", "value1" },
                        { "randomKey", "randomValue" },
                        { "key3", "value3" }
                    },
                Location = TestHelper.DefaultLocation,
                Sku = new StreamingJobSku()
                {
                    Name = StreamingJobSkuName.Standard
                }
            };
        }
    }
}
