﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.MediaComposition.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.MediaComposition.Tests.samples
{
    /// <summary>
    /// Basic Azure Communication.MediaComposition samples.
    /// </summary>
    public partial class Sample1_MediaCompositionClient : MediaCompositionClientLiveTestBase
    {
        private const string mediaCompositionId = "2x2Grid";

        public Sample1_MediaCompositionClient(bool isAsync) : base(isAsync)
        {
        }

        public void AuthenticateMediaCompositionClient()
        {
            #region Snippet:CreateMediaCompositionClient
            var connectionString = "<connection_string>";
            var client = new MediaCompositionClient(connectionString);
            #endregion Snippet:CreateMediaCompositionClient

            #region Snippet:CreateMediaCompositionClientFromAccessKey
            var endpoint = new Uri("https://my-resource.communication.azure.com");
            //@@var accessKey = "<access_key>";
            //@@var client= new MediaCompositionClient(endpoint, new AzureKeyCredential(accessKey));
            #endregion Snippet:CreateMediaCompositionClientFromAccessKey

            #region Snippet:CreateMediaCompositionClientFromToken
            var resourceEndpoint = new Uri("https://my-resource.communication.azure.com");
            TokenCredential tokenCredential = new DefaultAzureCredential();
            //@@var client = new MediaCompositionClient(endpoint, tokenCredential);
            #endregion Snippet:CreateMediaCompositionClientFromToken
        }

        [Test]
        public async Task CreateMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateClient();
            var response = await CreateMediaCompositionHelper(mediaCompositionClient);
            Assert.AreEqual(response.Value.Id, mediaCompositionId);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task GetMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            #region Snippet:GetMediaComposition
            var gridMediaCompositionResponse = await mediaCompositionClient.GetAsync(mediaCompositionId);
            #endregion Snippet:GetMediaComposition
            Assert.AreEqual(gridMediaCompositionResponse.Value.Id, mediaCompositionId);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task UpdateLayoutMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            #region Snippet:UpdateLayout
            var layout = new MediaCompositionLayout()
            {
                Resolution = new(720, 480),
                Presenter = new("jill", "jack")
                {
                    SupportPosition = SupportPosition.BottomRight,
                    SupportAspectRatio = 3 / 2
                }
            };
            var response = await mediaCompositionClient.UpdateLayoutAsync(mediaCompositionId, layout);
            #endregion Snippet:UpdateLayout
            Assert.AreEqual(response.Value.Id, mediaCompositionId);
            Assert.AreEqual(response.Value.Layout.Resolution.Width, 720);
            Assert.AreEqual(response.Value.Layout.Resolution.Height, 480);
            Assert.IsNotNull(response.Value.Layout.Presenter);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task UpsertInputsMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            #region Snippet:UpsertInputs
            var inputsToUpsert = new Dictionary<string, MediaInput>()
            {
                ["james"] = new()
                {
                    Participant = new(
                        id: new() { MicrosoftTeamsUser = new("f3ba9014-6dca-4456-8ec0-fa03cfa2b70p") },
                        call: "teamsMeeting")
                    {
                        PlaceholderImageUri = "https://imageendpoint"
                    }
                }
            };
            var response = await mediaCompositionClient.UpsertInputsAsync(mediaCompositionId, inputsToUpsert);
            #endregion Snippet:UpsertInputs
            Assert.AreEqual(response.Value.Id, mediaCompositionId);
            response.Value.Inputs.TryGetValue("james", out var james);
            Assert.IsNotNull(james);
            response.Value.Inputs.TryGetValue("jack", out var jack);
            Assert.IsNotNull(jack);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task RemoveInputsMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            var layout = new MediaCompositionLayout()
            {
                Resolution = new(720, 480),
                Presenter = new("jill", "jack")
                {
                    SupportPosition = SupportPosition.BottomRight,
                    SupportAspectRatio = 3 / 2
                }
            };
            await mediaCompositionClient.UpdateLayoutAsync(mediaCompositionId, layout);
            #region Snippet:RemoveInputs
            var inputIdsToRemove = new List<string>()
            {
                "jane", "jerry"
            };
            var response = await mediaCompositionClient.RemoveInputsAsync(mediaCompositionId, inputIdsToRemove);
            #endregion Snippet:RemoveInputs
            Assert.AreEqual(response.Value.Id, mediaCompositionId);
            response.Value.Inputs.TryGetValue("jane", out var jane);
            Assert.IsNull(jane);
            response.Value.Inputs.TryGetValue("jerry", out var jerry);
            Assert.IsNull(jerry);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task UpsertOutputsMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            #region Snippet:UpsertOutputs
            var outputsToUpsert = new Dictionary<string, MediaOutput>()
            {
                {
                    "youtube",
                    new()
                    {
                        Rtmp = new("key", new(1920, 1080), "rtmp://a.rtmp.youtube.com/live2")
                    }
                }
            };
            var response = await mediaCompositionClient.UpsertOutputsAsync(mediaCompositionId, outputsToUpsert);
            #endregion Snippet:UpsertOutputs
            Assert.AreEqual(response.Value.Id, mediaCompositionId);
            response.Value.Outputs.TryGetValue("youtube", out var youtube);
            Assert.IsNotNull(youtube);
            response.Value.Outputs.TryGetValue("acsGroupCall", out var acsGroupCall);
            Assert.IsNotNull(acsGroupCall);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task RemoveOutputsMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            #region Snippet:RemoveOutputs
            var outputIdsToRemove = new List<string>()
            {
                "acsGroupCall"
            };
            var response = await mediaCompositionClient.RemoveOutputsAsync(mediaCompositionId, outputIdsToRemove);
            #endregion Snippet:RemoveOutputs
            Assert.AreEqual(response.Value.Id, mediaCompositionId);
            response.Value.Outputs.TryGetValue("acsGroupCall", out var acsGroupCall);
            Assert.IsNull(acsGroupCall);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task StartMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            #region Snippet:StartMediaComposition
            var compositionSteamState = await mediaCompositionClient.StartAsync(mediaCompositionId);
            #endregion Snippet:StartMediaComposition
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task StopMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            #region Snippet:StopMediaComposition
            var compositionSteamState = await mediaCompositionClient.StopAsync(mediaCompositionId);
            #endregion Snippet:StopMediaComposition
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task DeleteMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            #region Snippet:DeleteMediaComposition
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
            #endregion Snippet:DeleteMediaComposition
        }

        private async Task<Response<MediaCompositionBody>> CreateMediaCompositionHelper(MediaCompositionClient mediaCompositionClient)
        {
            #region Snippet:CreateMediaComposition
            var gridLayoutOptions = new GridLayoutOptions(2, 2);
            gridLayoutOptions.InputIds.Add(new List<string> { "jill", "jack" });
            gridLayoutOptions.InputIds.Add(new List<string> { "jane", "jerry" });
            var layout = new MediaCompositionLayout()
            {
                Resolution = new(1920, 1080),
                Grid = gridLayoutOptions
            };

            var inputs = new Dictionary<string, MediaInput>()
            {
                ["jill"] = new()
                {
                    Participant = new(
                        id: new() { MicrosoftTeamsUser = new("f3ba9014-6dca-4456-8ec0-fa03cfa2b7b7") },
                        call: "teamsMeeting")
                    {
                        PlaceholderImageUri = "https://imageendpoint"
                    }
                },
                ["jack"] = new()
                {
                    Participant = new(
                        id: new() { MicrosoftTeamsUser = new("fa4337b5-f13a-41c5-a34f-f2aa46699b61") },
                        call: "teamsMeeting")
                    {
                        PlaceholderImageUri = "https://imageendpoint"
                    }
                },
                ["jane"] = new()
                {
                    Participant = new(
                        id: new() { MicrosoftTeamsUser = new("2dd69470-dc25-49cf-b5c3-f562f08bf3b2") },
                        call: "teamsMeeting")
                    {
                        PlaceholderImageUri = "https://imageendpoint"
                    }
                },
                ["jerry"] = new()
                {
                    Participant = new(
                        id: new() { MicrosoftTeamsUser = new("30e29fde-ac1c-448f-bb34-0f3448d5a677") },
                        call: "teamsMeeting")
                    {
                        PlaceholderImageUri = "https://imageendpoint"
                    }
                },
                ["teamsMeeting"] = new()
                {
                    TeamsMeeting = new("https://teamsJoinUrl")
                }
            };

            var outputs = new Dictionary<string, MediaOutput>()
            {
                {
                    "acsGroupCall",
                    new()
                    {
                        GroupCall = new("d12d2277-ffec-4e22-9979-8c0d8c13d193")
                    }
                }
            };
            var response = await mediaCompositionClient.CreateAsync(mediaCompositionId, layout, inputs, outputs);
            #endregion Snippet:CreateMediaComposition
            return response;
        }
    }
}
