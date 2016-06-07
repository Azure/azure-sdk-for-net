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
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure;
using Microsoft.AzureStack.AzureConsistentStorage.Models;
using Xunit;

namespace Microsoft.AzureStack.AzureConsistentStorage.Tests
{
    public class RoleInstanceTests : TestBase
    {
        private const string GetUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/{4}instances/{5}?"
            + Constants.ApiVersionParameter;

        private const string ListUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/{4}instances?"
            + Constants.ApiVersionParameter;

        private const string LocationUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/{4}instances/{5}/operationresults/{6}?"
            + Constants.ApiVersionParameter;

        [Fact]
        public void ListRoleInstance()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.RoleInstanceListResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.TableMasterInstances.List(Constants.ResourceGroupName, Constants.FarmId).ToList();

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                ListUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.TableMasterRole);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            CompareExpectedResult(result[0]);

            //TODO: deployment information?
        }

        [Fact]
        public void GetRoleInstance()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.RoleInstanceResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.TableMasterInstances.Get(Constants.ResourceGroupName, Constants.FarmId, Constants.RoleInstanceId);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                GetUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId, 
                Constants.TableMasterRole,
                Constants.RoleInstanceId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            CompareExpectedResult(result.RoleInstance);
        }
       
        [Fact]
        public void RestartRoleInstance()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);

            var subscriptionId = Guid.NewGuid().ToString();
            string locationUri = string.Format(
                LocationUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.TableMasterRole,
                Constants.NodeId,
                Guid.NewGuid()
                );
            response.Headers.Add("Location", locationUri);

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.Accepted,
                SubsequentStatusCodeToReturn = HttpStatusCode.OK
            };

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);
            var result = client.TableMasterInstances.Restart(
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.NodeId
                );
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            Assert.Equal(locationUri, handler.Uri.AbsoluteUri);
        }

        [Fact]
        public void StartBlobServerRoleInstance()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);

            var subscriptionId = Guid.NewGuid().ToString();
            string locationUri = string.Format(
                LocationUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.TableMasterRole,
                Constants.NodeId,
                Guid.NewGuid()
                );
            response.Headers.Add("Location", locationUri);

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.Accepted,
                SubsequentStatusCodeToReturn = HttpStatusCode.OK
            };

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);
            var result = client.BlobServerInstances.Start(
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.NodeId
                );
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            Assert.Equal(locationUri, handler.Uri.AbsoluteUri);
        }

        [Fact]
        public void StopBlobServerRoleInstance()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);

            var subscriptionId = Guid.NewGuid().ToString();
            string locationUri = string.Format(
                LocationUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.TableMasterRole,
                Constants.NodeId,
                Guid.NewGuid()
                );
            response.Headers.Add("Location", locationUri);

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.Accepted,
                SubsequentStatusCodeToReturn = HttpStatusCode.OK
            };

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);
            var result = client.BlobServerInstances.Stop(
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.NodeId
                );
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            Assert.Equal(locationUri, handler.Uri.AbsoluteUri);
        }

        private void CompareExpectedResult(TableMasterRoleInstanceModel result)
        {
            // Validate response 
            Assert.Equal(result.Properties.HealthStatus, HealthStatus.Healthy);

            Assert.Equal(result.Properties.Version, "3/18/2015");

            Assert.Equal(result.Properties.NodeUri, "/subscriptions/EA5E931C-89FB-4A74-8EE5-65B7959882D1/resourceGroups/resourceGroupNameX/providers/Microsoft.Storage.Admin/farms/default/nodes/woss-node-1");
            Assert.Equal(result.Properties.RoleIdentifier, "woss-node-1");

            Assert.Equal((result.Properties.HistoryInfos.Count()), 1);

            var startTime = new DateTime(635779620700757296, DateTimeKind.Utc);
            var endtime = new DateTime(635779656700757296, DateTimeKind.Utc);
            var history = result.Properties.HistoryInfos[0];
            Assert.Equal(history.Duration, TimeSpan.FromHours(1));
            Assert.Equal(history.RoleIdentifier, "woss-node-1");
            Assert.Equal(history.StartTime, startTime);
            Assert.Equal(history.EndTime, endtime);
        }
    }
}