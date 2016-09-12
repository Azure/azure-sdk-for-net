// ----------------------------------------------------------------------------------
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

using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using Microsoft.Azure;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;
using Xunit;

namespace Microsoft.AzureStack.AzureConsistentStorage.Tests.InMemoryTests
{
    public class FaultTests : TestBase
    {
        public const string FaultsBaseTemplate =
          "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/faults";

        private const string FaultListWithoutFilterUriTemplate =
            FaultsBaseTemplate
            + "?" + Constants.ApiVersionParameter;

        private const string FaultListUriTemplate =
            FaultListWithoutFilterUriTemplate
            + "&$filter=";

        private const string CurrentFaultFilterUriTemplate =
            "resourceUri eq '{0}'";

        private const string HistoryFaultFilterUriTemplate =
            "startTime eq '{0}' and endTime eq '{1}' and resourceUri eq '{2}'";

        private const string FaultGetUriTemplate =
            FaultsBaseTemplate
            + "/{4}"
            + "?" + Constants.ApiVersionParameter;

        private const string FaultDismissUriTemplate =
            FaultsBaseTemplate
            + "/{4}/dismiss"
            + "?" + Constants.ApiVersionParameter;
     

        [Fact]
        public void ListHistoryActiveFaults()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.HistoryActiveFaultListResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);
            var startTime = new DateTime(2015, 3, 18);
            var endTime = new DateTime(2015, 3, 18);
            var ResourceUri = "/subscriptions/serviceAdmin/resourceGroups/system/providers/Microsoft.Storage.Admin/farms/WEST_US_1/tableserverinstances/woss-node1";

            var result = client.Faults.ListHistoryFaults(
                Constants.ResourceGroupName,
                Constants.FarmId,
                startTime.ToString("o"),
                endTime.ToString("o"),
                ResourceUri);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                FaultListUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId);

            var expectedFilterUri = string.Format(
                HistoryFaultFilterUriTemplate,
                Uri.EscapeDataString(startTime.ToString("o")),
                Uri.EscapeDataString(endTime.ToString("o")),
                Uri.EscapeDataString(ResourceUri));

            expectedUri = string.Concat(expectedUri, expectedFilterUri);
            expectedUri = expectedUri.Replace(" ", "%20");

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            Assert.True(result.Faults.Count > 1);
            CompareExpectedResult(result.Faults[0], false);
        }

        [Fact]
        public void ListCurrentActiveFaults()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.CurrentActiveFaultListResponse)
            };
            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };
            var ResourceUri =
                "/subscriptions/serviceAdmin/resourceGroups/system/providers/Microsoft.Storage.Admin/farms/WEST_US_1/tableserverinstances/woss-node1";
            var subscriptionId = Guid.NewGuid().ToString();
            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);
            var result = client.Faults.ListCurrentFaults(
                Constants.ResourceGroupName,
                Constants.FarmId,
                ResourceUri);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                    FaultListUriTemplate,
                    Constants.BaseUri,
                    subscriptionId,
                    Constants.ResourceGroupName,
                    Constants.FarmId);
            
            var expectedFilterUri = string.Format(
                CurrentFaultFilterUriTemplate,
                Uri.EscapeDataString(ResourceUri));

            expectedUri = string.Concat(expectedUri, expectedFilterUri);
            expectedUri = expectedUri.Replace(" ", "%20");

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            Assert.True(result.Faults.Count > 1);
            CompareExpectedResult(result.Faults[0], true);
        }

        [Fact]
        public void GetFault()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.FaultGetResponse)
            };
            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };
            var subscriptionId = Guid.NewGuid().ToString();
            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);
            var result = client.Faults.Get(
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.FaultId
                );

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                FaultGetUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.FaultId);
            
            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);
            CompareExpectedResult(result.Fault, true);
        }

        [Fact]
        public void DismissFaults()
        {
            var handler = new RecordedDelegatingHandler
            {
                StatusCodeToReturn = HttpStatusCode.NoContent
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            client.Faults.Dismiss(
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.FaultId
                );

            Assert.Equal(handler.Method, HttpMethod.Post);

            var expectedUri = string.Format(
                FaultDismissUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.FaultId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);
        }

        private void CompareExpectedResult(FaultModel result, bool isCurrentActive)
        {
            // Validate response 
            Assert.Equal(result.Properties.FaultId, Guid.Parse("c8e6bfe487b4b8eceb5dc36ff6a24521"));
            Assert.Equal(result.Properties.ActivatedTime, DateTime.Parse("2015-05-18T18:02:00Z", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.RoundtripKind));
            Assert.Equal(result.Properties.Description, "TBD");
            Assert.Equal(result.Properties.FaultRuleName, "faultRule1");
            Assert.Equal(result.Properties.ResolutionText, "TBD");
            if (isCurrentActive)
                Assert.Equal(result.Properties.ResolvedTime, null);
            else
                Assert.Equal(result.Properties.ResolvedTime, DateTime.Parse("2015-05-18T18:04:00Z", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.RoundtripKind));
            Assert.Equal(result.Properties.ResourceUri, "/subscriptions/serviceAdmin/resourceGroups/system/providers/Microsoft.Storage.Admin/farms/WEST_US_1/tableserverinstances/woss-node1");
            Assert.Equal(result.Properties.Severity, Severity.Critical);
            if (isCurrentActive)
            {
                Assert.Equal(result.Properties.AssociatedDataType, AssociatedDataType.Metrics);
                Assert.Equal(result.Properties.AssociatedMetricsName, "MetricsName");
            }
            else
            {
                Assert.Equal(result.Properties.AssociatedDataType, AssociatedDataType.Event);
                var eventQuery = result.Properties.AssociatedEventQuery;
                EventQueryResultValidator.ValidateGetEventQueryResult(eventQuery);
            }
        }
    }
}
