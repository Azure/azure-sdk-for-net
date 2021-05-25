// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Media.VideoAnalyzer.Edge.Models;
using Microsoft.Azure.Devices;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Azure.Core;
using System.Linq;

namespace Azure.Media.VideoAnalyzer.Edge.Samples
{
    public class LiveVideoAnalyzerSample
    {
        private ServiceClient serviceClient;
        private String deviceId = "lva-sample-device";
        private String moduleId = "mediaEdge";

        public LiveVideoAnalyzerSample()
        {
            #region Snippet:Azure_VideoAnalyzerSamples_ConnectionString
            String connectionString = "connectionString";
            ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
            #endregion Snippet:Azure_VideoAnalyzerSamples_ConnectionString
            this.serviceClient = serviceClient;
        }

        [Test]
        public async Task SendPipelineRequests()
        {
            try
            {
                // create a pipeline topology and live pipeline
                var pipelineTopology = BuildPipelineTopology();
                var livePipeline = BuildLivePipeline(pipelineTopology.Name);

                //set topology without using helper function
                #region Snippet:Azure_VideoAnalyzerSamples_InvokeDirectMethod
                var setPipelineTopRequest = new PipelineTopologySetRequest(pipelineTopology);

                var directMethod = new CloudToDeviceMethod(setPipelineTopRequest.MethodName);
                directMethod.SetPayloadJson(setPipelineTopRequest.GetPayloadAsJson());

                var setPipelineTopResponse = await serviceClient.InvokeDeviceMethodAsync(deviceId, moduleId, directMethod);
                #endregion Snippet:Azure_VideoAnalyzerSamples_InvokeDirectMethod

                // get a topology using helper function
                var getPipelineTopRequest = await InvokeDirectMethodHelper(new PipelineTopologyGetRequest(pipelineTopology.Name));
                var getPipelineTopResponse = PipelineTopology.Deserialize(getPipelineTopRequest.GetPayloadAsJson());

                // list all  topologies
                var listPipelineTopRequest = await InvokeDirectMethodHelper(new PipelineTopologyListRequest());
                var listPipelineTopResponse = PipelineTopologyCollection.Deserialize(listPipelineTopRequest.GetPayloadAsJson());

                //set live pipeline
                var setLivePipelineRequest = await InvokeDirectMethodHelper(new LivePipelineSetRequest(livePipeline));

                //activate live pipeline
                var activateLivePipelineRequest = await InvokeDirectMethodHelper(new LivePipelineActivateRequest(livePipeline.Name));

                //get live pipeline
                var getLivePipelineRequest = await InvokeDirectMethodHelper(new LivePipelineGetRequest(livePipeline.Name));
                var getLivePipelineResponse = LivePipeline.Deserialize(getLivePipelineRequest.GetPayloadAsJson());

                // list all live pipeline
                var listLivePipelineRequest = await InvokeDirectMethodHelper(new LivePipelineListRequest());
                var listLivePipelineResponse = LivePipelineCollection.Deserialize(listLivePipelineRequest.GetPayloadAsJson());

                //getlive pipeline
                var deactiveLivePipeline = await InvokeDirectMethodHelper(new LivePipelineDeactivateRequest(livePipeline.Name));

                var deleteLivePipeline = await InvokeDirectMethodHelper(new LivePipelineDeleteRequest(livePipeline.Name));

                //delete live pipeline
                var deletePipelineTopology = await InvokeDirectMethodHelper(new PipelineTopologyDeleteRequest(pipelineTopology.Name));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.Fail();
            }
        }

        private async Task<CloudToDeviceMethodResult> InvokeDirectMethodHelper(MethodRequest bc)
        {
            var directMethod = new CloudToDeviceMethod(bc.MethodName);
            directMethod.SetPayloadJson(bc.GetPayloadAsJson());

            return await serviceClient.InvokeDeviceMethodAsync(deviceId, moduleId, directMethod);
        }

        private LivePipeline BuildLivePipeline(string topologyName)
        {
        #region Snippet:Azure_VideoAnalyzerSamples_BuildLivePipeline
            var livePipelineProps = new LivePipelineProperties
            {
                Description = "Sample description",
                TopologyName = topologyName,
            };

            livePipelineProps.Parameters.Add(new ParameterDefinition("rtspUrl", "rtsp://sample.com"));

            return new LivePipeline("livePIpeline")
            {
                Properties = livePipelineProps
            };
        #endregion Snippet:Azure_VideoAnalyzerSamples_BuildLivePipeline
        }

        private PipelineTopology BuildPipelineTopology()
        {
        #region Snippet:Azure_VideoAnalyzerSamples_BuildPipelineTopology
            var pipelineTopologyProps = new PipelineTopologyProperties
            {
                Description = "Continuous video recording to a Video Analyzer video",
            };
            SetParameters(pipelineTopologyProps);
            SetSources(pipelineTopologyProps);
            SetSinks(pipelineTopologyProps);
            return new PipelineTopology("ContinuousRecording")
            {
                Properties = pipelineTopologyProps
            };
            #endregion Snippet:Azure_VideoAnalyzerSamples_BuildPipelineTopology
        }

        // Add parameters to Topology
        private void SetParameters(PipelineTopologyProperties pipelineTopologyProperties)
        {
            #region Snippet:Azure_VideoAnalyzerSamples_SetParameters
            pipelineTopologyProperties.Parameters.Add(new ParameterDeclaration("rtspUserName", ParameterType.String)
            {
                Description = "rtsp source user name.",
                Default = "exampleUserName"
            });
            pipelineTopologyProperties.Parameters.Add(new ParameterDeclaration("rtspPassword", ParameterType.SecretString)
            {
                Description = "rtsp source password.",
                Default = "examplePassword"
            });
            pipelineTopologyProperties.Parameters.Add(new ParameterDeclaration("rtspUrl", ParameterType.String)
            {
                Description = "rtsp Url"
            });
            pipelineTopologyProperties.Parameters.Add(new ParameterDeclaration("hubSinkOutputName", ParameterType.String)
            {
                Description = "hub sink output"
            });
            #endregion Snippet:Azure_VideoAnalyzerSamples_SetParameters
        }

        // Add sources to Topology
        private void SetSources(PipelineTopologyProperties pipelineTopologyProps)
        {
            #region Snippet:Azure_VideoAnalyzerSamples_SetSourcesSinks1
            pipelineTopologyProps.Sources.Add(new RtspSource("rtspSource", new UnsecuredEndpoint("${rtspUrl}")
            {
                Credentials = new UsernamePasswordCredentials("${rtspUserName}", "${rtspPassword}")
            })
            );
            #endregion Snippet:Azure_VideoAnalyzerSamples_SetSourcesSinks1
        }

        // Add sinks to Topology
        private void SetSinks(PipelineTopologyProperties pipelineTopologyProps)
        {
            #region Snippet:Azure_VideoAnalyzerSamples_SetSourcesSinks2
            var nodeInput = new List<NodeInput>
            {
                new NodeInput("rtspSource")
            };
            pipelineTopologyProps.Sinks.Add(new IotHubMessageSink("msgSink", nodeInput, "${hubSinkOutputName}"));
            #endregion Snippet:Azure_VideoAnalyzerSamples_SetSourcesSinks2
        }
    }
}
