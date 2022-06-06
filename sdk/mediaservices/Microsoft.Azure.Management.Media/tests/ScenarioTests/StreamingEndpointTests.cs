// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Threading;
using Xunit;

namespace Media.Tests.ScenarioTests
{
    public class StreamingEndpointTests : MediaScenarioTestBase
    {
        [Fact]
        public void CustomStreamingEndpointTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                try
                {
                    CreateMediaServicesAccount();

                    Thread.Sleep(3000);

                    string defaultStreamingEndpointName = "default";

                    // List StreamingEndpoints, which should contain the automatically created default endpoint
                    var streamingEndpoints = MediaClient.StreamingEndpoints.List(ResourceGroup, AccountName);
                    Assert.Single(streamingEndpoints);
                    Assert.Equal(defaultStreamingEndpointName, streamingEndpoints.First().Name);

                    string endpointName = TestUtilities.GenerateName("streamingendpoint");
                    string endpointDescription = "A test streaming endpoint";
                    string location = Helpers.MediaManagementTestUtilities.DefaultLocation;

                    // Get StreamingEndpoint, which should not exist
                    Assert.Equal(System.Net.HttpStatusCode.NotFound, Assert.Throws<ErrorResponseException>(() => MediaClient.StreamingEndpoints.Get(ResourceGroup, AccountName, endpointName)).Response.StatusCode);

                    // Create a new StreamingEndpoint
                    StreamingEndpoint parameters = new StreamingEndpoint(location: location, description: endpointDescription, scaleUnits: 0);
                    StreamingEndpoint createdEndpoint = MediaClient.StreamingEndpoints.Create(ResourceGroup, AccountName, endpointName, parameters, autoStart: true);
                    ValidateStreamingEndpoint(createdEndpoint, endpointName, endpointDescription, location, StreamingEndpointResourceState.Running);

                    // List the StreamingEndpoints and validate the created endpoint shows up
                    streamingEndpoints = MediaClient.StreamingEndpoints.List(ResourceGroup, AccountName);
                    Assert.Equal(2, streamingEndpoints.Count());
                    StreamingEndpoint streamingEndpoint = streamingEndpoints.Where(s => s.Name != defaultStreamingEndpointName).Single();
                    ValidateStreamingEndpoint(streamingEndpoint, endpointName, endpointDescription, location, StreamingEndpointResourceState.Running);

                    // Get the newly created StreamingEndpoint
                    streamingEndpoint = MediaClient.StreamingEndpoints.Get(ResourceGroup, AccountName, endpointName);
                    Assert.NotNull(streamingEndpoint);
                    ValidateStreamingEndpoint(streamingEndpoint, endpointName, endpointDescription, location, StreamingEndpointResourceState.Running);
                    Assert.Equal("Standard", streamingEndpoint.Sku.Name);

                    var skus = MediaClient.StreamingEndpoints.Skus(ResourceGroup, AccountName, endpointName);
                    Assert.Equal(1, skus.Value.Count);

                    // Stop the StreamingEndpoint
                    MediaClient.StreamingEndpoints.Stop(ResourceGroup, AccountName, endpointName); 

                    // List the StreamingEndpoints and validate the endpoint is stopped
                    streamingEndpoints = MediaClient.StreamingEndpoints.List(ResourceGroup, AccountName);
                    Assert.Equal(2, streamingEndpoints.Count());
                    streamingEndpoint = streamingEndpoints.Where(s => s.Name != defaultStreamingEndpointName).Single();
                    ValidateStreamingEndpoint(streamingEndpoint, endpointName, endpointDescription, location, StreamingEndpointResourceState.Stopped);

                    // Get the stopped StreamingEndpoint
                    streamingEndpoint = MediaClient.StreamingEndpoints.Get(ResourceGroup, AccountName, endpointName);
                    Assert.NotNull(streamingEndpoint);
                    ValidateStreamingEndpoint(streamingEndpoint, endpointName, endpointDescription, location, StreamingEndpointResourceState.Stopped);

                    // Delete the StreamingEndpoint
                    MediaClient.StreamingEndpoints.Delete(ResourceGroup, AccountName, endpointName);

                    // List StreamingEndpoints, which should should just contain the default again
                    streamingEndpoints = MediaClient.StreamingEndpoints.List(ResourceGroup, AccountName);
                    Assert.Single(streamingEndpoints);

                    // Get StreamingEndpoint, which should not exist
                    Assert.Equal(System.Net.HttpStatusCode.NotFound, Assert.Throws<ErrorResponseException>(() => MediaClient.StreamingEndpoints.Get(ResourceGroup, AccountName, endpointName)).Response.StatusCode);
                }
                finally
                {
                    DeleteMediaServicesAccount();
                }
            }
        }

        internal static void ValidateStreamingEndpoint(StreamingEndpoint streamingEndpoint, string expectedName, string expectedDescription, string expectedLocation, StreamingEndpointResourceState expectedResourceState)
        {
            Assert.Equal(expectedName, streamingEndpoint.Name);
            Assert.Equal(expectedDescription, streamingEndpoint.Description);
            Assert.Equal(expectedLocation, streamingEndpoint.Location);
            Assert.Equal(expectedResourceState, streamingEndpoint.ResourceState);
            Assert.False(string.IsNullOrEmpty(streamingEndpoint.Id));
            Assert.False(string.IsNullOrEmpty(streamingEndpoint.HostName));
        }
    }
}


