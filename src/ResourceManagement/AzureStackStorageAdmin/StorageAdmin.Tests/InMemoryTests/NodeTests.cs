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
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;
using Xunit;

namespace Microsoft.AzureStack.AzureConsistentStorage.Tests
{
    public class NodeTests : TestBase
    {
        private const string GetUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/nodes/{4}?"
            + Constants.ApiVersionParameter;

        private const string ListUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/nodes?"
            + Constants.ApiVersionParameter;

        private const string LocationUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/nodes/{4}/operationresults/{5}?"
            + Constants.ApiVersionParameter;

        [Fact]
        public void GetNode()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.NodeGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.Nodes.Get(
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.NodeId);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                GetUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.NodeId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            CompareExpectedResult(result.Node);
        }

        [Fact]
        public void ListNodes()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.NodeListResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            NodeListResponse result = client.Nodes.List(
                Constants.ResourceGroupName,
                Constants.FarmId);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                ListUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            CompareExpectedResult(result.Nodes[0]);
        }

        [Fact]
        public void EnableNode()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);

            var subscriptionId = Guid.NewGuid().ToString();
            string locationUri = string.Format(
                LocationUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
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
            var result = client.Nodes.Enable(
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.NodeId
                );
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            Assert.Equal(locationUri, handler.Uri.AbsoluteUri);
        }

        [Fact]
        public void DisableNode()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);

            var subscriptionId = Guid.NewGuid().ToString();
            string locationUri = string.Format(
                LocationUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
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
            var result = client.Nodes.Disable(
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.NodeId
                );
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            Assert.Equal(locationUri, handler.Uri.AbsoluteUri);
        }


        private void CompareExpectedResult(NodeModel node)
        {
            // Validate response 
            Assert.Equal("3.0.1414.9492", node.Properties.CodeVersion);

            Assert.Equal("1.0", node.Properties.ConfigVersion);

            Assert.Equal("fd:/woss-node-1", node.Properties.FaultDomain.AbsoluteUri);

            Assert.Equal(HealthStatus.Healthy, node.Properties.HealthState);
            Assert.Equal("woss-node-1", node.Properties.IpAddressOrFqdn);
            Assert.Equal(true, node.Properties.IsSeedNode);
            Assert.Equal("c8e6bfe487b4b8eceb5dc36ff6a2452", node.Properties.NodeId);

            Assert.Equal("woss-node-1", node.Properties.NodeName);
            Assert.Equal(NodeStatus.Up, node.Properties.NodeStatus);
            Assert.Equal("Common", node.Properties.NodeType);
            Assert.Equal(TimeSpan.FromHours(1), node.Properties.NodeUpTime);
            Assert.Equal("WOSS_U1", node.Properties.UpgradeDomain);

            var expectedInstanceUris = new string[]
            {
                "subscriptions/serviceAdmin/resourcegroups/system/providers/Microsoft.Storage.Admin/farms/WEST_US_1/tableserverinstances/woss-node-1",
                "subscriptions/serviceAdmin/resourcegroups/system/providers/Microsoft.Storage.Admin/farms/WEST_US_1/accountcontainerserverinstances/woss-node-1"
            };
            Assert.True(node.Properties.RunningInstanceUris.SequenceEqual(expectedInstanceUris));
        }
    }
}