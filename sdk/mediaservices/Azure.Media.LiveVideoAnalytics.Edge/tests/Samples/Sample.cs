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
        private ServiceClient _serviceClient;
        private String _deviceId = "<Enter the device Id>">;
        private String _moduleId = "<Enter the module Id>";

        public Sample()
        {
            var connectionString = "<Enter the connection string>";
            this._serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
        }
        [Test]
        public async Task GettingASecret()
        {
            try
            {
                // create a graph
                var graphTopology = Build();
                var result = await InvokeDirectMethodHelper(new MediaGraphTopologySetRequest(graphTopology));

                // get all graphs
                var getAllResult = await InvokeDirectMethodHelper(new MediaGraphTopologyListRequest());
                var getAllGraphs = MediaGraphTopologyCollection.Deserialize(getAllResult.GetPayloadAsJson());

                // get a graph
                var getResult = await InvokeDirectMethodHelper(new MediaGraphTopologyGetRequest(graphTopology.Name));
                var resultGraph = MediaGraphTopology.Deserialize(getResult.GetPayloadAsJson());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task<CloudToDeviceMethodResult> InvokeDirectMethodHelper(OperationBase bc)
        {
            var directMethod = new CloudToDeviceMethod(bc.MethodName);
            directMethod.SetPayloadJson(bc.GetPayloadAsJSON());
            return await _serviceClient.InvokeDeviceMethodAsync(_deviceId, _moduleId, directMethod);
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
