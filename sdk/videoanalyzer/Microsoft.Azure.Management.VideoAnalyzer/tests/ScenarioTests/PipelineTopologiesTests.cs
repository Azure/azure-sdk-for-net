// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using VideoAnalyzer.Tests.Helpers;
using Microsoft.Azure.Management.VideoAnalyzer;
using Microsoft.Azure.Management.VideoAnalyzer.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace VideoAnalyzer.Tests.ScenarioTests
{
    public class PipelineTopologiesTests : VideoAnalyzerTestBase
    {

        private const string RtspUserNameParameterName = "rtspUserNameParameter";
        private const string RtspPasswordParameterName = "rtspPasswordParameter";
        private const string VideoNameParameterName = "videoNameParameter";
        private const string RtspUrlParameterName = "rtspUrlParameter";

        [Fact]
        public void PipelineTopologyLifeCycleTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                try
                {
                    CreateVideoAnalyzerAccount();

                    var topologies = VideoAnalyzerClient.PipelineTopologies.List(ResourceGroup, AccountName);
                    Assert.Empty(topologies);

                    var topologyName = TestUtilities.GenerateName("pt");

                    VideoAnalyzerClient.PipelineTopologies.CreateOrUpdate(ResourceGroup, AccountName, topologyName, new PipelineTopology(
                        description: "The pipeline topology with rtsp source and video sink.",
                        kind: Kind.Live,
                        sku: new Sku(SkuName.LiveS1),
                        parameters: new List<ParameterDeclaration>
                        {
                            new ParameterDeclaration
                            {
                                Name = RtspUserNameParameterName,
                                Type = "SecretString",
                                Description = "rtsp user name parameter",
                            },
                            new ParameterDeclaration
                            {
                                Name = RtspPasswordParameterName,
                                Type = "SecretString",
                            },
                            new ParameterDeclaration
                            {
                                Name = RtspUrlParameterName,
                                Type = "String",
                            },
                            new ParameterDeclaration
                            {
                                Name = VideoNameParameterName,
                                Type = "String",
                            },
                        },
                        sources: new List<SourceNodeBase>
                        {
                            new RtspSource
                            {
                                Name = "rtspSource",
                                Transport = "tcp",
                                Endpoint = new UnsecuredEndpoint
                                {
                                    Url = $"${{{RtspUrlParameterName}}}",
                                    Credentials = new UsernamePasswordCredentials
                                    {
                                        Username = $"${{{RtspUserNameParameterName}}}",
                                        Password = $"${{{RtspPasswordParameterName}}}",
                                    },
                                },
                            },
                        },
                        sinks: new List<SinkNodeBase>
                        {
                            new VideoSink
                            {
                                Name = "videoSink",
                                VideoName =  $"${{{VideoNameParameterName}}}",
                                Inputs = new List<NodeInput>
                                {
                                    new NodeInput("rtspSource"),
                                },
                                VideoCreationProperties = new VideoCreationProperties
                                {
                                    Title = "Parking Lot (Camera 1)",
                                    Description = "Parking lot south entrance",
                                },
                            },
                        }));

                    var topology = VideoAnalyzerClient.PipelineTopologies.Get(ResourceGroup, AccountName, topologyName);
                    Assert.NotNull(topology);
                    Assert.Equal(topologyName, topology.Name);

                    topologies = VideoAnalyzerClient.PipelineTopologies.List(ResourceGroup, AccountName);
                    Assert.NotNull(topologies);
                    Assert.Single(topologies);

                    VideoAnalyzerClient.PipelineTopologies.Delete(ResourceGroup, AccountName, topologyName);

                    topologies = VideoAnalyzerClient.PipelineTopologies.List(ResourceGroup, AccountName);
                    Assert.Empty(topologies);
                }
                finally
                {
                    DeleteVideoAnalyzerAccount();
                }
            }
        }
    }
}

