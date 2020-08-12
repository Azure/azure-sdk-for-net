// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Reservations.Tests.ScenarioTests
{
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;

    using Reservations.Tests.Helpers;
    using Microsoft.Azure.Management.Reservations;
    using Microsoft.Azure.Management.Reservations.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;
    using Microsoft.Rest.Azure;
    public class QotaTests : TestBase
    {
        // ##############
        //  SETUP
        // ##############
        // 0- For recording data from localhost, change RunMe.cmd as follows:
        // :Record
        // set TEST_CONNECTION_STRING=ManagementCertificate=1D13973C7D99A2E6AD10561BB72E6C2661A96D9F;QuotaSubscriptionId=9f6cce51-6baf-4de5-a3c4-6f58b85315b9;BaseUri=http://localhost:443

        // Note: Make sure whatever cert thumprint you used above is installed in you Cert *User* Store

        #region Test consts
        public static readonly string QuotaSubscriptionId = "9f6cce51-6baf-4de5-a3c4-6f58b85315b9";
        private const string ComputeProviderId = "Microsoft.Compute";
        private const string BatchMLProviderId = "Microsoft.MachineLearningServices";
        private const string LocationWUS = "westus";
        private const string LocationEUS = "eastus";
        private const string version = "2019-07-19-preview";
        private const string SKUName = "standardFSv2Family";
        private const string QuotaRequestId = "011e1463-c8d7-4a5e-ae35-f15c1f3226b4";
        #endregion

        #region Tests
        #region Positive Test case
        [Fact]
        public void Test_ComputeSkusGetRequest()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(
                    context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var quotas = reservationsClient.Quota.List(QuotaSubscriptionId, ComputeProviderId, LocationWUS);

                Assert.True(quotas.All(x =>
                    x.Properties.Limit != null &&
                    x.Properties.Name != null &&
                    x.Properties.CurrentValue != null
                ));
            }
        }

        [Fact]
        public void Test_BatchMLSkusGetRequest()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(
                    context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var quotas = reservationsClient.Quota.List(QuotaSubscriptionId, BatchMLProviderId, LocationWUS);

                Assert.True(quotas.All(x =>
                    x.Properties.Limit != null &&
                    x.Properties.Name != null &&
                    x.Properties.CurrentValue != null
                ));
            }
        }

        [Fact]
        public void Test_ComputeOneSkusGetRequest()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(
                    context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var quota = reservationsClient.Quota.Get(QuotaSubscriptionId, ComputeProviderId, LocationWUS, SKUName);

                Assert.True(quota.Properties.Limit != null &&
                    quota.Properties.Name != null &&
                    quota.Properties.CurrentValue != null
                );
            }
        }

        [Fact]
        public void Test_ComputeQuotaRequestsHistory()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(
                    context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var quotaRequests = reservationsClient.QuotaRequestStatus.List(QuotaSubscriptionId, ComputeProviderId, LocationWUS);

                Assert.True(quotaRequests.All(x =>
                    x.ProvisioningState != null &&
                    x.Name != null &&
                    x.Id != null &&
                    x.RequestSubmitTime != null
                ));
            }
        }

        [Fact]
        public void Test_ComputeQuotaRequestsHistoryWithFilter()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            int noOfItemsRequested = 3;
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(
                    context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var quotaRequests = reservationsClient.QuotaRequestStatus.List(QuotaSubscriptionId, ComputeProviderId, LocationWUS, top: noOfItemsRequested);

                Assert.True(quotaRequests.Count() == noOfItemsRequested);

                Assert.True(quotaRequests.All(x =>
                    x.ProvisioningState != null &&
                    x.Name != null &&
                    x.Id != null &&
                    x.RequestSubmitTime != null
                ));
            }
        }

        [Fact]
        public void Test_ComputeQuotaRequestsById()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(
                    context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var quotaRequest = reservationsClient.QuotaRequestStatus.Get(QuotaSubscriptionId, ComputeProviderId, LocationWUS, QuotaRequestId);

                Assert.True(quotaRequest.ProvisioningState != null &&
                   quotaRequest.Name != null &&
                   quotaRequest.Id != null &&
                    quotaRequest.RequestSubmitTime != null
                );
            }
        }

        [Fact]
        public void Test_GetAQMProperties()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(
                    context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var aqiProperties = reservationsClient.AutoQuotaIncrease.GetProperties(QuotaSubscriptionId);

                Assert.True(aqiProperties.Id != null &&
                   aqiProperties.Name != null &&
                   aqiProperties.Settings.AutoQuotaIncreaseState != null
                );
            }
        }

        [Fact]
        public void Test_AQMPutRequestDisabled()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            var newQAqi = new AutoQuotaIncreaseDetail()
            {
                Settings = new AqiSettings() { AutoQuotaIncreaseState = "Disabled" }
            };

            try
            {
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(
                        context,
                        new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                    var response = reservationsClient.AutoQuotaIncrease.Create(QuotaSubscriptionId, newQAqi);

                    Assert.True(response.Settings.AutoQuotaIncreaseState.ToString() == "Disabled");
                }
            }
            catch (CloudException ex)
            {
                Assert.False(false, $"Not excpected {ex.ToString()}");
            }
        }

        #endregion
        #region Neagtive Test Cases
        [Fact]
        public void Test_ComputeSkusPutRequestFailedDueToQuotaReduction()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            var newQuotaLimit = new CurrentQuotaLimitBase()
            {
                Properties = new QuotaProperties()
                {
                    Limit = 2,
                    Name = new ResourceName() { Value = SKUName }
                }
            };

            try
            {
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(
                        context,
                        new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.Created });
                    var quotaResponse = reservationsClient.Quota.CreateOrUpdate(QuotaSubscriptionId, ComputeProviderId, LocationWUS, newQuotaLimit.Properties.Name.Value, newQuotaLimit);
                }
            }
            catch (CloudException ex)
            {
                Assert.Contains("Quota reduction is not supported", ex.ToString());
            }
        }
        
        [Fact]
        public void Test_ComputeSkusPatchRequestFailedDueToQuotaReduction()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            var newQuotaLimit = new CurrentQuotaLimitBase()
            {
                Properties = new QuotaProperties()
                {
                    Limit = 2,
                    Name = new ResourceName() { Value = SKUName }
                }
            };

            try
            {
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(
                        context,
                        new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.Created });
                    var quotaResponse = reservationsClient.Quota.Update(QuotaSubscriptionId, ComputeProviderId, LocationWUS, newQuotaLimit.Properties.Name.Value, newQuotaLimit);
                }
            }
            catch (CloudException ex)
            {
                Assert.Contains("Quota reduction is not supported", ex.ToString());
            }
        }

        [Fact]
        public void Test_BatchMLTotalLowPriorityCoresPutRequestFailedDueToQuotaReduction()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            var newQuotaLimit = new CurrentQuotaLimitBase()
            {
                Properties = new QuotaProperties()
                {
                    Limit = 2,
                    Name = new ResourceName() { Value = "TotalLowPriorityCores" },
                    ResourceType = "lowPriority"
                }
            };

            try
            {
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(
                        context,
                        new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.Created });
                    var quotaResponse = reservationsClient.Quota.CreateOrUpdate(QuotaSubscriptionId, BatchMLProviderId, LocationWUS, newQuotaLimit.Properties.Name.Value, newQuotaLimit);
                }
            }
            catch (CloudException ex)
            {
                Assert.Contains("Quota reduction is not supported", ex.ToString());
            }
        }

        [Fact]
        public void Test_BatchMLBadLocationPutRequestFailed()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            var badLocation = "badLocation";
            var newQuotaLimit = new CurrentQuotaLimitBase()
            {
                Properties = new QuotaProperties()
                {
                    Limit = 2000,
                    Name = new ResourceName() { Value = "TotalLowPriorityCores" },
                    ResourceType = "lowPriority"
                }
            };

            try
            {
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(
                        context,
                        new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.BadRequest });
                    var quotaResponse = reservationsClient.Quota.CreateOrUpdate(QuotaSubscriptionId, BatchMLProviderId, badLocation, newQuotaLimit.Properties.Name.Value, newQuotaLimit);
                }
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
                Assert.Contains("BadRequest", ex.ToString());
            }
            catch (ExceptionResponseException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public void Test_BatchMLBadResourceIdPutRequestFailed()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            var badResourceId = "badResId";
            var newQuotaLimit = new CurrentQuotaLimitBase()
            {
                Properties = new QuotaProperties()
                {
                    Limit = 2000,
                    Name = new ResourceName() { Value = badResourceId },
                    ResourceType = "lowPriority"
                }
            };

            try
            {
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(
                        context,
                        new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.BadRequest });
                    var quotaResponse = reservationsClient.Quota.CreateOrUpdate(QuotaSubscriptionId, BatchMLProviderId, LocationWUS, newQuotaLimit.Properties.Name.Value, newQuotaLimit);
                }
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
                Assert.Contains("BadRequest", ex.ToString());
            }
            catch (ExceptionResponseException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
            }
        }

        #endregion

        #endregion

        #region private Methods
        private static string GetSessionsDirectoryPath()
        {
            System.Type something = typeof(Reservations.Tests.ScenarioTests.ReservationTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
        #endregion
    }
}