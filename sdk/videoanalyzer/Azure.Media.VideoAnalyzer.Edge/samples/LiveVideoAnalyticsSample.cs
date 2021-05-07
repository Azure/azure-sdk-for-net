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
    public class LiveVideoAnalyticsSample
    {
        private ServiceClient _serviceClient;
        private String _deviceId = "lva-sample-device";
        private String _moduleId = "mediaEdge";

        public LiveVideoAnalyticsSample()
        {
            #region Snippet:Azure_VideoAnalyzer_Samples_ConnectionString
            var connectionString = "connectionString";
            this._serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
            #endregion Snippet:Azure_VideoAnalyzer_Samples_ConnectionString

        }

        [Test]
        public async Task SendGraphRequests()
        {
            try
            {
                // create a graph topology and graph instance
                var pipelineTopology = BuildPipelineTopology();
                var livePipeline = BuildLivePipeline(pipelineTopology.Name);

                //set graph topology without using helper function
                #region Snippet:Azure_VideoAnalyzeramples_InvokeDirectMethod
                var setPipelineTopRequest = new PipelineTopologySetRequest(pipelineTopology);

                var directMethod = new CloudToDeviceMethod(setPipelineTopRequest.MethodName);
                directMethod.SetPayloadJson(setPipelineTopRequest.GetPayloadAsJson());

                var setPipelineTopResponse = await _serviceClient.InvokeDeviceMethodAsync(_deviceId, _moduleId, directMethod);
                #endregion Snippet:Azure_VideoAnalyzeramples_InvokeDirectMethod

                // get a graph topology using helper function
                var getPipelineTopRequest = await InvokeDirectMethodHelper(new PipelineTopologyGetRequest(pipelineTopology.Name));
                var getPipelineTopResponse = PipelineTopology.Deserialize(getPipelineTopRequest.GetPayloadAsJson());

                // list all graph topologies
                var listPipelineTopRequest = await InvokeDirectMethodHelper(new PipelineTopologyListRequest());
                var listPipelineTopResponse = PipelineTopologyCollection.Deserialize(listPipelineTopRequest.GetPayloadAsJson());

                //set graph instance
                var setLivePipelineRequest = await InvokeDirectMethodHelper(new LivePipelineSetRequest(livePipeline));

                //activate graph instance
                var activateLivePipelineRequest = await InvokeDirectMethodHelper(new LivePipelineActivateRequest(livePipeline.Name));

                //get instance
                var getLivePipelineRequest = await InvokeDirectMethodHelper(new LivePipelineGetRequest(livePipeline.Name));
                var getLivePipelineResponse = LivePipeline.Deserialize(getLivePipelineRequest.GetPayloadAsJson());

                // list all graph instance
                var listLivePipelineRequest = await InvokeDirectMethodHelper(new LivePipelineListRequest());
                var listLivePipelineResponse = LivePipelineCollection.Deserialize(listLivePipelineRequest.GetPayloadAsJson());

                //get deactive graph
                var deactiveLivePipeline = await InvokeDirectMethodHelper(new LivePipelineDeactivateRequest(livePipeline.Name));

                var deleteLivePipeline = await InvokeDirectMethodHelper(new LivePipelineDeleteRequest(livePipeline.Name));

                //delete graph
                var deletePipelineTopology = await InvokeDirectMethodHelper(new PipelineTopologyDeleteRequest(pipelineTopology.Name));
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

        #region Snippet:Azure_VideoAnalyzerSamples_BuildLivePipeline
        private LivePipeline BuildLivePipeline(string graphTopologyName)
        {
            var livePipelineProps = new LivePipelineProperties
            {
                Description = "Sample graph description",
                TopologyName = graphTopologyName,
            };

            livePipelineProps.Parameters.Add(new ParameterDefinition("rtspUrl", "rtsp://sample.com"));

            return new LivePipeline("graphInstance")
            {
                Properties = livePipelineProps
            };
        }
        #endregion Snippet:Azure_VideoAnalyzerSamples_BuildLivePipeline

        #region Snippet:Azure_VideoAnalyzerles_BuildPipelineTopology
        private PipelineTopology BuildPipelineTopology()
        {
            var pipelineTopologyProps = new PipelineTopologyProperties
            {
                Description = "Continuous video recording to an Azure Media Services Asset",
            };
            SetParameters(pipelineTopologyProps);
            SetSources(pipelineTopologyProps);
            SetSinks(pipelineTopologyProps);
            return new PipelineTopology("ContinuousRecording")
            {
                Properties = pipelineTopologyProps
            };
        }
        #endregion Snippet:Azure_VideoAnalyzerles_BuildPipelineTopology

        #region Snippet:Azure_VideoAnalyzerces_Samples_SetParameters
        // Add parameters to Topology
        private void SetParameters(PipelineTopologyProperties pipelineTopologyProperties)
        {
            pipelineTopologyProperties.Parameters.Add(new ParameterDeclaration("rtspUserName", ParameterType.String)
            {
                Description = "rtsp source user name.",
                Default = "dummyUserName"
            });
            pipelineTopologyProperties.Parameters.Add(new ParameterDeclaration("rtspPassword", ParameterType.SecretString)
            {
                Description = "rtsp source password.",
                Default = "dummyPassword"
            });
            pipelineTopologyProperties.Parameters.Add(new ParameterDeclaration("rtspUrl", ParameterType.String)
            {
                Description = "rtsp Url"
            });
            pipelineTopologyProperties.Parameters.Add(new ParameterDeclaration("hubSinkOutputName", ParameterType.String)
            {
                Description = "hub sink output"
            });
        }
        #endregion Snippet:Azure_VideoAnalyzerces_Samples_SetParameters

        #region Snippet:Azure_VideoAnalyzers_Samples_SetSourcesSinks
        // Add sources to Topology
        private void SetSources(PipelineTopologyProperties pipelineTopologyProps)
        {
            pipelineTopologyProps.Sources.Add(new RtspSource("rtspSource", new UnsecuredEndpoint("${rtspUrl}")
            {
                Credentials = new UsernamePasswordCredentials("${rtspUserName}", "${rtspPassword}")
            })
            );
        }

        // Add sinks to Topology
        private void SetSinks(PipelineTopologyProperties pipelineTopologyProps)
        {
            var nodeInput = new List<NodeInput>
            {
                new NodeInput("rtspSource")
            };
            pipelineTopologyProps.Sinks.Add(new IotHubMessageSink("msgSink", nodeInput, "${hubSinkOutputName}"));
        }
        #endregion Snippet:Azure_VideoAnalyzers_Samples_SetSourcesSinks
    }
}
