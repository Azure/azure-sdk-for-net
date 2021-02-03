// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Media.Analytics.Edge.Models;
using Microsoft.Azure.Devices;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Azure.Core;
using System.Linq;

namespace Azure.Media.Analytics.Edge.Samples
{
    public class LiveVideoAnalyticsSample
    {
        private ServiceClient _serviceClient;
        private String _deviceId = "deviceId";
        private String _moduleId = "moduleId";

        public LiveVideoAnalyticsSample()
        {
            #region Snippet:Azure_MediaServices_Samples_ConnectionString
            var connectionString = "connectionString";
            this._serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
            #endregion Snippet:Azure_MediaServices_Samples_ConnectionString

        }

        [Test]
        public async Task SendGraphRequests()
        {
            try
            {
                // create a graph topology and graph instance
                var graphTopology = BuildGraphTopology();
                var graphInstance = BuildGraphInstance(graphTopology.Name);

                //set graph topology without using helper function
                #region Snippet:Azure_MediaServices_Samples_InvokeDirectMethod
                var setGraphRequest = new MediaGraphTopologySetRequest(graphTopology);

                var directMethod = new CloudToDeviceMethod(setGraphRequest.MethodName);
                directMethod.SetPayloadJson(setGraphRequest.GetPayloadAsJson());

                var setGraphResponse = await _serviceClient.InvokeDeviceMethodAsync(_deviceId, _moduleId, directMethod);
                #endregion Snippet:Azure_MediaServices_Samples_InvokeDirectMethod

                // get a graph topology using helper function
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
                var getGraphInstanceResult = MediaGraphInstance.Deserialize(getGraphInstanceResponse.GetPayloadAsJson());

                // list all graph instance
                var listGraphInstanceResponse = await InvokeDirectMethodHelper(new MediaGraphInstanceListRequest());
                var listGraphInstanceResult = MediaGraphInstanceCollection.Deserialize(listGraphInstanceResponse.GetPayloadAsJson());

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
            directMethod.SetPayloadJson(bc.GetPayloadAsJson());

            return await _serviceClient.InvokeDeviceMethodAsync(_deviceId, _moduleId, directMethod);
        }

        #region Snippet:Azure_MediaServices_Samples_BuildInstance
        private MediaGraphInstance BuildGraphInstance(string graphTopologyName)
        {
            var graphInstanceProperties = new MediaGraphInstanceProperties
            {
                Description = "Sample graph description",
                TopologyName = graphTopologyName,
            };

            graphInstanceProperties.Parameters.Add(new MediaGraphParameterDefinition("rtspUrl", "rtsp://sample.com"));

            return new MediaGraphInstance("graphInstance")
            {
                Properties = graphInstanceProperties
            };
        }
        #endregion Snippet:Azure_MediaServices_Samples_BuildInstance

        #region Snippet:Azure_MediaServices_Samples_BuildTopology
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
        #endregion Snippet:Azure_MediaServices_Samples_BuildTopology

        #region Snippet:Azure_MediaServices_Samples_SetParameters
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
        #endregion Snippet:Azure_MediaServices_Samples_SetParameters

        #region Snippet:Azure_MediaServices_Samples_SetSourcesSinks
        // Add sources to Topology
        private void SetSources(MediaGraphTopologyProperties graphProperties)
        {
            graphProperties.Sources.Add(new MediaGraphRtspSource("rtspSource", new MediaGraphUnsecuredEndpoint("${rtspUrl}")
                {
                    Credentials = new MediaGraphUsernamePasswordCredentials("${rtspUserName}", "${rtspPassword}")
                })
            );
        }

        // Add sinks to Topology
        private void SetSinks(MediaGraphTopologyProperties graphProperties)
        {
            var graphNodeInput = new List<MediaGraphNodeInput>
            {
                new MediaGraphNodeInput("rtspSource")
            };
            var cachePath = "/var/lib/azuremediaservices/tmp/";
            var cacheMaxSize = "2048";
            graphProperties.Sinks.Add(new MediaGraphAssetSink("assetSink", graphNodeInput, "sampleAsset-${System.GraphTopologyName}-${System.GraphInstanceName}", cachePath, cacheMaxSize)
            {
                SegmentLength = System.Xml.XmlConvert.ToString(TimeSpan.FromSeconds(30)),
            });
        }
        #endregion Snippet:Azure_MediaServices_Samples_SetSourcesSinks
    }
}
