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
        private ServiceClient _serviceClient;
        private RegistryManager _registryManager;
        private string _deviceId = System.Environment.GetEnvironmentVariable("iothub_deviceid", EnvironmentVariableTarget.User);
        private string _moduleId = System.Environment.GetEnvironmentVariable("iothub_moduleid", EnvironmentVariableTarget.User);

        public LiveVideoAnalyzerSample()
        {
            #region Snippet:Azure_VideoAnalyzerSamples_ConnectionString
            string connectionString = System.Environment.GetEnvironmentVariable("iothub_connectionstring", EnvironmentVariableTarget.User);
            var serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
            #endregion Snippet:Azure_VideoAnalyzerSamples_ConnectionString

            _serviceClient = serviceClient;
            _registryManager = RegistryManager.CreateFromConnectionString(connectionString);
        }

        [Test]
        public async Task SendRequests()
        {
            try
            {
                //create a pipeline topology and live pipeline
                var pipelineTopology = BuildPipelineTopology();
                var livePipeline = BuildLivePipeline(pipelineTopology.Name);

                //set topology without using helper function
                #region Snippet:Azure_VideoAnalyzerSamples_InvokeDirectMethod
                var setPipelineTopRequest = new PipelineTopologySetRequest(pipelineTopology);

                var directMethod = new CloudToDeviceMethod(setPipelineTopRequest.MethodName);
                directMethod.SetPayloadJson(setPipelineTopRequest.GetPayloadAsJson());

                var setPipelineTopResponse = await _serviceClient.InvokeDeviceMethodAsync(_deviceId, _moduleId, directMethod);
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

                //get an onvif device
                var onvifDeviceGetRequest = await InvokeDirectMethodHelper(new OnvifDeviceGetRequest(new UnsecuredEndpoint("rtsp://camerasimulator:8554")));
                var onvifDeviceGetResponse = OnvifDevice.Deserialize(onvifDeviceGetRequest.GetPayloadAsJson());

                //get all onvif devices on the network
                var onvifDiscoverRequest = await InvokeDirectMethodHelper(new OnvifDeviceDiscoverRequest());
                var onvifDiscoverResponse = DiscoveredOnvifDeviceCollection.Deserialize(onvifDiscoverRequest.GetPayloadAsJson());

                // create a remote device adapter and send a set request for it
                var iotDeviceName = "iotDeviceSample";
                var remoteDeviceName = "remoteDeviceSample";
                var iotDevice = await GetOrAddIoTDeviceAsync(iotDeviceName);
                var remoteDeviceAdapter = CreateRemoteDeviceAdapter(remoteDeviceName, iotDeviceName, iotDevice.Authentication.SymmetricKey.PrimaryKey);
                var remoteDeviceAdapterSetRequest = await InvokeDirectMethodHelper(new RemoteDeviceAdapterSetRequest(remoteDeviceAdapter));
                var remoteDeviceAdapterSetResponse = RemoteDeviceAdapter.Deserialize(remoteDeviceAdapterSetRequest.GetPayloadAsJson());

                //get a remote device adapter
                var remoteDeviceAdapterGetRequest = await InvokeDirectMethodHelper(new RemoteDeviceAdapterGetRequest(remoteDeviceName));
                var remoteDeviceAdapterGetResponse = RemoteDeviceAdapter.Deserialize(remoteDeviceAdapterGetRequest.GetPayloadAsJson());

                //list all remote device adapters
                var remoteDeviceAdapterListRequest = await InvokeDirectMethodHelper(new RemoteDeviceAdapterListRequest());
                var remoteDeviceAdapterListResponse = RemoteDeviceAdapterCollection.Deserialize(remoteDeviceAdapterListRequest.GetPayloadAsJson());

                //delete a remote device adapater
                var remoteDeviceAdapterDeleteRequest = await InvokeDirectMethodHelper(new RemoteDeviceAdapterDeleteRequest(remoteDeviceName));
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

            return await _serviceClient.InvokeDeviceMethodAsync(_deviceId, _moduleId, directMethod);
        }

        protected async Task<Device> GetOrAddIoTDeviceAsync(string iotDeviceName)
        {
            var iotDevice = await _registryManager.GetDeviceAsync(iotDeviceName);
            if (iotDevice == null)
            {
                iotDevice = await _registryManager.AddDeviceAsync(new Device(iotDeviceName));
            }

            return iotDevice;
        }

        private RemoteDeviceAdapter CreateRemoteDeviceAdapter(string deviceProxyName, string iotDeviceName, string symmetricKey)
        {
            var targetHost = new Uri("rtsp://camerasimulator:8554").Host;

            return new RemoteDeviceAdapter(deviceProxyName)
            {
                Properties = new RemoteDeviceAdapterProperties(
                    new RemoteDeviceAdapterTarget(targetHost),
                    new IotHubDeviceConnection(iotDeviceName)
                    {
                        Credentials = new SymmetricKeyCredentials(symmetricKey),
                    })
                {
                    Description = "description",
                },
            };
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
            pipelineTopologyProps.Sinks.Add(new VideoSink("videoSink", nodeInput, "video", "/var/lib/videoanalyzer/tmp/", "1024"));
            #endregion Snippet:Azure_VideoAnalyzerSamples_SetSourcesSinks2
        }
    }
}
