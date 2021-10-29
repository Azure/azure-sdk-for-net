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
    public class VideosTest : VideoAnalyzerTestBase
    {
        [Fact]
        public void VideosLifeCycleTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                try
                {
                    CreateVideoAnalyzerAccount();

                    var videos = VideoAnalyzerClient.Videos.List(ResourceGroup, AccountName);
                    Assert.Empty(videos);

                    var videoName = TestUtilities.GenerateName("video");
                    VideoAnalyzerClient.Videos.CreateOrUpdate(ResourceGroup, AccountName, videoName, new VideoEntity(){ Title= "video title", Description= "video description"});

                    var video = VideoAnalyzerClient.Videos.Get(ResourceGroup, AccountName, videoName);
                    Assert.NotNull(video);
                    Assert.Equal(videoName, video.Name);

                    videos = VideoAnalyzerClient.Videos.List(ResourceGroup, AccountName);
                    Assert.NotNull(videos);
                    Assert.Single(videos);

                    VideoAnalyzerClient.Videos.Delete(ResourceGroup, AccountName, videoName);

                    videos = VideoAnalyzerClient.Videos.List(ResourceGroup, AccountName);
                    Assert.Empty(videos);
                }
                finally
                {
                    DeleteVideoAnalyzerAccount();
                }
            }
        }
    }
}

