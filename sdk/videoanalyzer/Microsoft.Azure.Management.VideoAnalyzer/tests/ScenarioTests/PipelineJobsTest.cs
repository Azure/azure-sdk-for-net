// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.VideoAnalyzer;
using Microsoft.Azure.Management.VideoAnalyzer.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;
using System.Threading;

namespace VideoAnalyzer.Tests.ScenarioTests
{
    public class PipelineJobsTest : VideoAnalyzerTestBase
    {

        private const string RtspUserNameParameterName = "rtspUserNameParameter";
        private const string RtspPasswordParameterName = "rtspPasswordParameter";
        private const string VideoNameParameterName = "videoNameParameter";
        private const string RtspUrlParameterName = "rtspUrlParameter";
        private const string VideoNameParameter = "videoNameParameter";
        private const string VideoSourceVideoNameParameter = "videoSourceVideoNameParameter";
        private const string VideoSourceTimeSequenceParameter = "videoSourceTimeSequenceParameter";

        [Fact]
        public void PipelineJobLifeCycleTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                try
                {
                    CreateVideoAnalyzerAccount();

                    var topologyName = TestUtilities.GenerateName("pt");

                    VideoAnalyzerClient.PipelineTopologies.CreateOrUpdate(ResourceGroup, AccountName, topologyName, new PipelineTopology(
                        name: topologyName,
                        kind: Kind.Batch,
                        sku: new Sku
                        {
                            Name = "Batch_S1",
                        },
                        description: "The pipeline topology with video source, encoder processor and video sink.",
                        parameters: new List<ParameterDeclaration>
                        {
                            new ParameterDeclaration
                            {
                                Name = VideoNameParameter,
                                Type = "String",
                                Description = "video name",
                            },
                            new ParameterDeclaration
                            {
                                Name = VideoSourceTimeSequenceParameter,
                                Type = "String",
                                Description = "video source time sequence parameter",
                            },
                            new ParameterDeclaration
                            {
                                Name = VideoSourceVideoNameParameter,
                                Type = "String",
                                Description = "video source video name parameter",
                            },
                        },
                        sources: new List<SourceNodeBase>
                        {
                            new VideoSource
                            {
                                Name = "videoSource",
                                VideoName = "${" + VideoSourceVideoNameParameter + "}",
                                TimeSequences = new VideoSequenceAbsoluteTimeMarkers
                                {
                                    Ranges = "${" + VideoSourceTimeSequenceParameter + "}",
                                },
                            },
                        },
                        processors: new List<ProcessorNodeBase>
                        {
                            new EncoderProcessor
                            {
                                 Name = "encoderProcessor",
                                 Preset = new EncoderSystemPreset
                                 {
                                     Name = EncoderSystemPresetType.SingleLayer1080pH264AAC,
                                 },
                                 Inputs = new List<NodeInput>
                                 {
                                     new NodeInput("videoSource"),
                                 },
                            },
                        },
                        sinks: new List<SinkNodeBase>
                        {
                            new VideoSink
                            {
                                Name = "videoSink",
                                VideoName = "${" + VideoNameParameter + "}",
                                Inputs = new List<NodeInput>
                                {
                                    new NodeInput("encoderProcessor"),
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

                    var pipelineJobName = TestUtilities.GenerateName("pj");

                                        var pipeline = new PipelineJob(
                        name: pipelineJobName,
                        description: "test job description",
                        topologyName: topologyName,
                        parameters: new List<ParameterDefinition>
                        {
                            new ParameterDefinition(VideoSourceVideoNameParameter, VideoSourceVideoNameParameter),
                            new ParameterDefinition(VideoSourceTimeSequenceParameter, "[[\"2020-10-05T03:30:00Z\", \"2020-10-05T04:30:00Z\"]]"),
                            new ParameterDefinition(VideoNameParameter, TestUtilities.GenerateName("ve")),
                        });

                    var pipelineJobs = VideoAnalyzerClient.PipelineJobs.List(ResourceGroup, AccountName);
                    Assert.Empty(pipelineJobs);

                    VideoAnalyzerClient.PipelineJobs.CreateOrUpdate(ResourceGroup, AccountName, pipelineJobName, pipeline);

                    var pipelineJob = VideoAnalyzerClient.PipelineJobs.Get(ResourceGroup, AccountName, pipelineJobName);
                    Assert.NotNull(pipelineJob);
                    Assert.Equal(pipelineJobName, pipelineJob.Name);

                    pipelineJobs = VideoAnalyzerClient.PipelineJobs.List(ResourceGroup, AccountName);
                    Assert.NotNull(pipelineJobs);
                    Assert.Single(pipelineJobs);

                    VideoAnalyzerClient.PipelineJobs.Delete(ResourceGroup, AccountName, pipelineJobName);

                    pipelineJobs = VideoAnalyzerClient.PipelineJobs.List(ResourceGroup, AccountName);
                    Assert.Empty(pipelineJobs);

                    VideoAnalyzerClient.PipelineTopologies.Delete(ResourceGroup, AccountName, pipelineJobName);

                }
                finally
                {
                    DeleteVideoAnalyzerAccount();
                }
            }
        }
    }
}

