// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Quota.Models;
using Microsoft.Azure.Management.Quota.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.Management.Quota.Tests.ScenarioTests
{
    public class QuotaTests : TestBase
    {
        const string scope = 
            "subscriptions/9f6cce51-6baf-4de5-a3c4-6f58b85315b9/providers/Microsoft.Network/locations/westus";
        const string resourceName = "PublicIPAddresses";

        [Fact]
        public void Test_ListQuotaRequest()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var quotaExtensionClient = QuotaTestUtilities.GetAzureQuotaExtensionAPIClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var quotaRequests = quotaExtensionClient.QuotaRequestStatus.List(scope);

                Assert.True(quotaRequests.All(x =>
                    string.Equals(x.Type, "Microsoft.Quota/QuotaRequests", StringComparison.OrdinalIgnoreCase)
                ));
            }
        }

        [Fact]
        public void Test_ListQuotaRequestWithFilter()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            int top = 5;
            string filter = "provisioningState eq 'Failed'";
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var quotaExtensionClient = QuotaTestUtilities.GetAzureQuotaExtensionAPIClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var quotaRequests = quotaExtensionClient.QuotaRequestStatus.List(scope, filter: filter, top: top);

                Assert.True(quotaRequests.Count() == top);

                Assert.True(quotaRequests.All(x =>
                    string.Equals(x.ProvisioningState, "Failed", StringComparison.OrdinalIgnoreCase)
                ));
            }
        }

        [Fact]
        public void Test_GetQuotaRequest()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            string requestId = "2c3d0274-10b6-44ae-82ed-a0647057d696";
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var quotaExtensionClient = QuotaTestUtilities.GetAzureQuotaExtensionAPIClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var quotaRequests = quotaExtensionClient.QuotaRequestStatus.Get(requestId, scope);

                Assert.Equal(quotaRequests.Name, requestId, ignoreCase: true);
            }
        }

        [Fact]
        public void Test_GetQuota()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var quotaExtensionClient = QuotaTestUtilities.GetAzureQuotaExtensionAPIClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var quota = quotaExtensionClient.Quota.Get(resourceName, scope);

                Assert.Equal(quota.Name, resourceName, ignoreCase: true);
            }
        }

        [Fact]
        public void Test_ListQuota()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var quotaExtensionClient = QuotaTestUtilities.GetAzureQuotaExtensionAPIClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var quotas = quotaExtensionClient.Quota.List(scope);

                Assert.True(quotas.All(x =>
                    string.Equals(x.Type, "Microsoft.Quota/Quotas", StringComparison.OrdinalIgnoreCase)
                ));
            }
        }

        [Fact]
        public void Test_GetUsage()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var quotaExtensionClient = QuotaTestUtilities.GetAzureQuotaExtensionAPIClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var usage = quotaExtensionClient.Usages.Get(resourceName, scope);

                Assert.Equal(usage.Name, resourceName, ignoreCase: true);
            }
        }

        [Fact]
        public void Test_ListUsage()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var quotaExtensionClient = QuotaTestUtilities.GetAzureQuotaExtensionAPIClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var usages = quotaExtensionClient.Usages.List(scope);

                Assert.True(usages.All(x =>
                    string.Equals(x.Type, "Microsoft.Quota/Usages", StringComparison.OrdinalIgnoreCase)
                ));
            }
        }

        [Fact]
        public void Test_SetQuota()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var quotaExtensionClient = QuotaTestUtilities.GetAzureQuotaExtensionAPIClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var newQuotaLimit =  new QuotaProperties()
                    {
                        Limit = new LimitObject()
                        {
                            Value = 1005
                        },
                        Name = new ResourceName()
                        {
                            Value = resourceName
                        }
                    };

                var quotaRequest = quotaExtensionClient.Quota.BeginCreateOrUpdate(resourceName, scope, newQuotaLimit);

                // 202 response has no response body
                Assert.True(quotaRequest == null);
            }
        }

        [Fact]
        public void Test_SetQuotaInvalidResourceName()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            try
            {
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    var quotaExtensionClient = QuotaTestUtilities.GetAzureQuotaExtensionAPIClient(
                        context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                    var newQuotaLimit = new QuotaProperties()
                    {
                        Limit = new LimitObject()
                        {
                            Value = 1005
                        },
                        Name = new ResourceName()
                        {
                            Value = "PublicIPAddress"
                        }
                    };

                    var quotaRequest = quotaExtensionClient.Quota.BeginCreateOrUpdate(
                        "PublicIPAddress", scope, newQuotaLimit);

                    Assert.True(quotaRequest == null);
                }
            }
            catch (ExceptionResponseException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
                Assert.Contains("InvalidResourceName", ex.ToString());
            }
        }

        static bool IsRecordMode()
        {
            return Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record";
        }

        static string GetSessionsDirectoryPath()
        {
            if (!IsRecordMode())
            {
                Type something = typeof(QuotaTests);
                string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
                return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
            }
            return Environment.GetEnvironmentVariable("OutputDirectory");
        }
    }
}
