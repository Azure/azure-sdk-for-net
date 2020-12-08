// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Media.LiveVideoAnalytics.Edge.Models;
using Microsoft.Azure.Devices;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Azure.Core;
using System.Linq;

namespace Azure.Media.LiveVideoAnalytics.Tests.Samples
{
    public class LiveVideoAnalyticsSample
    {
        private ServiceClient _serviceClient;
        private String _deviceId = "enter-your-device-name";
        private String _moduleId = "enter-your-module-name";

        public LiveVideoAnalyticsSample()
        {
            var connectionString = "enter-your-connection-string";
            this._serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
        }
        [Test]
        public async Task SendGraphRequests()
        {
            try
            {
                // create a graph topology and graph instance
                var graphTopology = BuildGraphTopology();
                var graphInstance = BuildGraphInstance(graphTopology.Name);

                //set graph topology
                var setGraphResult = await InvokeDirectMethodHelper(new MediaGraphTopologySetRequest(graphTopology));

                // get a graph topology
                var getGraphResponse = await InvokeDirectMethodHelper(new MediaGraphTopologyGetRequest(graphTopology.Name));
                var getGraphResult = MediaGraphTopology.Deserialize(getGraphResponse.GetPayloadAsJson());

                // list all graph topologies
                var listGraphResponse = await InvokeDirectMethodHelper(new MediaGraphTopologyListRequest());
                var listGraphResult = MediaGraphTopologyCollection.Deserialize(listGraphResponse.GetPayloadAsJson());

                //set graph instance
                var setGraphInstanceResult = await InvokeDirectMethodHelper(new MediaGraphInstanceSetRequest(graphInstance));

                //activate graph instance
                var activateGraphResponse = await InvokeDirectMethodHelper(new MediaGraphInstanceActivateRequest(graphInstance.Name));

                //get instance
                var getGraphInstanceResponse = await InvokeDirectMethodHelper(new MediaGraphInstanceGetRequest(graphInstance.Name));
                var getGraphInstaceResult = MediaGraphInstance.Deserialize(getGraphInstanceResponse.GetPayloadAsJson());

                //get deactive graph
                var deactiveGraphInstance = await InvokeDirectMethodHelper(new MediaGraphInstanceDeActivateRequest(graphInstance.Name));

                //delete graph
                var deleteGraphTopology = await InvokeDirectMethodHelper(new MediaGraphTopologyDeleteRequest(graphTopology.Name));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task<CloudToDeviceMethodResult> InvokeDirectMethodHelper(MethodRequest bc)
        {
            var directMethod = new CloudToDeviceMethod(bc.MethodName);
            directMethod.SetPayloadJson(bc.GetPayloadAsJSON());

            return await _serviceClient.InvokeDeviceMethodAsync(_deviceId, _moduleId, directMethod);
        }

        private MediaGraphInstance BuildGraphInstance(string graphTopologyName)
        {
            var graphInstanceProperties = new MediaGraphInstanceProperties
            {
                Description = "Sample graph description",
                TopologyName = graphTopologyName,
            };

            graphInstanceProperties.Parameters.Add(new MediaGraphParameterDefinition("rtspUrl", "rtsp://sample.com"));

            return new MediaGraphInstance("graphInstance1")
            {
                Properties = graphInstanceProperties
            };
        }

        private MediaGraphTopology BuildGraphTopology()
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
            graphProperties.Parameters.Add(new MediaGraphParameterDeclaration("rtspUserName", MediaGraphParameterType.String)
            {
                Description = "rtsp source user name.",
                Default = "dummyUserName"
            });
            graphProperties.Parameters.Add(new MediaGraphParameterDeclaration("rtspPassword", MediaGraphParameterType.SecretString)
            {
                Description = "rtsp source password.",
                Default = "dummyPassword"
            });
            graphProperties.Parameters.Add(new MediaGraphParameterDeclaration("rtspUrl", MediaGraphParameterType.String)
            {
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
                    }, "sampleAsset-${System.GraphTopologyName}-${System.GraphInstanceName}", "/var/lib/azuremediaservices/tmp/", "2048")
            {
                SegmentLength = System.Xml.XmlConvert.ToString(TimeSpan.FromSeconds(30)),
            });
        }
    }
}
