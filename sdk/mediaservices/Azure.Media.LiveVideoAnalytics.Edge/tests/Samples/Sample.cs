// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Media.LiveVideoAnalytics.Edge.Models;
using Microsoft.Azure.Devices;
using NUnit.Framework;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Azure.Core;
using System.Linq;

namespace Azure.Template.Tests.Samples
{
    public class Sample
    {
        [Test]
        public async Task GettingASecret()
        {
            var deviceId = "etshea-rainier";
            var moduleId = "lvaEdge";
            var connectionString = "HostName=amsuswe1iotmediadev11.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=c73AqBWTLodtcf+oj0tXrXGpLFHkoSlF1dbjz/wUtG0=";

            try
            {
                // create a graph
                var serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
                var graphTopology = this.Build();

                var graphCreateRequest = new MediaGraphTopologySetRequest(graphTopology);
                var directMethod = new CloudToDeviceMethod(graphCreateRequest.MethodName);
                directMethod.SetPayloadJson(graphCreateRequest.GetPayloadAsJSON());
                var result = await serviceClient.InvokeDeviceMethodAsync(deviceId, moduleId, directMethod);

                var getAllRequest = new MediaGraphTopologyListRequest();
                var getAllMethod = new CloudToDeviceMethod(getAllRequest.MethodName);
                getAllMethod.SetPayloadJson(getAllRequest.GetPayloadAsJSON());
                var getAllResult = await serviceClient.InvokeDeviceMethodAsync(deviceId, moduleId, getAllMethod);
                var getAllGraphs = MediaGraphTopologyCollection.Deserialize(getAllResult.GetPayloadAsJson());


                // get a graph
                var graphGetRequest = new MediaGraphTopologyGetRequest(graphTopology.Name);
                var getDirectMethod = new CloudToDeviceMethod(graphGetRequest.MethodName);
                getDirectMethod.SetPayloadJson(graphGetRequest.GetPayloadAsJSON());
                var getResult = await serviceClient.InvokeDeviceMethodAsync(deviceId, moduleId, getDirectMethod);
                var resultGraph = MediaGraphTopology.Deserialize(getResult.GetPayloadAsJson());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private MediaGraphTopology Build()
        {
            var graphProperties = new MediaGraphTopologyProperties
            {
                Description = "Continuous video recording to an Azure Media Services Asset",
            };
            SetParameters(graphProperties);
            SetSources(graphProperties);
            SetSinks(graphProperties);
            return new MediaGraphTopology("ContinuousRecording")
            {
                Properties = graphProperties
            };
        }

        // Add parameters to Topology
        private void SetParameters(MediaGraphTopologyProperties graphProperties)
        {
            graphProperties.Parameters.Add(new MediaGraphParameterDeclaration("rtspUserName", MediaGraphParameterType.String) {
                Description = "rtsp source user name.",
                Default = "dummyUserName"
            });
            graphProperties.Parameters.Add(new MediaGraphParameterDeclaration("rtspPassword", MediaGraphParameterType.SecretString) {
                Description = "rtsp source password.",
                Default = "dummyPassword"
            });
            graphProperties.Parameters.Add(new MediaGraphParameterDeclaration("rtspUrl", MediaGraphParameterType.String) {
                Description = "rtsp Url"
            });
        }

        // Add sources to Topology
        private void SetSources(MediaGraphTopologyProperties graphProperties)
        {
            graphProperties.Sources.Add(new MediaGraphRtspSource("rtspSource", new MediaGraphUnsecuredEndpoint("${rtspUrl}")
                {
                        Credentials = new MediaGraphUsernamePasswordCredentials("${rtspUserName}")
                        {
                            Password = "${rtspPassword}"
                        }
                })
                );
        }

        // Add sinks to Topology
        private void SetSinks(MediaGraphTopologyProperties graphProperties)
        {
            graphProperties.Sinks.Add(new MediaGraphAssetSink("assetSink", new List<MediaGraphNodeInput> {
                        { new MediaGraphNodeInput{NodeName = "rtspSource" } }
                    })
            {
                AssetNamePattern = "sampleAsset-${System.GraphTopologyName}-${System.GraphInstanceName}",
                SegmentLength = TimeSpan.FromSeconds(30),
                LocalMediaCacheMaximumSizeMiB = "2048",
                LocalMediaCachePath = "/var/lib/azuremediaservices/tmp/",
            });
        }
    }
}
