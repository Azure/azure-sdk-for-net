// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.MediaComposition.Models;
using Azure.Core;
using Azure.Identity;

namespace Azure.Communication.MediaComposition.Tests.samples
{
    /// <summary>
    /// Basic Azure Communication.MediaComposition samples.
    /// </summary>
    public partial class Sample1_MediaCompositionClient
    {
        // TODO: Update the samples to tests when the E2E flow is working
        private const string mediaCompositionId = "2x2Grid";

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

        public async Task CreateMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateMediaCompositionClient();

            #region Snippet:CreateMediaComposition
            var layout = new MediaCompositionLayout()
            {
                Resolution = new(1920, 1080),
                Grid = new(
                    rows: 2,
                    columns: 2,
                    new List<List<string>>
                    {
                        new List<string>
                        {
                            "jill", "jack"
                        },
                        new List<string>
                        {
                            "jane", "jerry"
                        }
                    })
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
                        GroupCall = new("d12d2277-ffec-4e22-9979-8c0d8c13d191")
                    }
                }
            };
            await mediaCompositionClient.CreateAsync(mediaCompositionId, layout, inputs, outputs);
            #endregion Snippet:CreateMediaComposition

        }

        public async Task GetMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateMediaCompositionClient();
            #region Snippet:GetMediaComposition
            var gridMediaComposition = await mediaCompositionClient.GetAsync(mediaCompositionId);
            #endregion Snippet:GetMediaComposition
        }

        public async Task UpdateLayoutMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateMediaCompositionClient();
            #region Snippet:UpdateMediaComposition
            var layout = new MediaCompositionLayout()
            {
                Resolution = new(720, 480),
                Presenter = new("jill", "jack")
                {
                    SupportPosition = SupportPosition.BottomRight,
                    SupportAspectRatio = 3 / 2
                }
            };
            await mediaCompositionClient.UpdateAsync(mediaCompositionId, layout);
            #endregion Snippet:UpdateMediaComposition
        }

        public async Task StartMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateMediaCompositionClient();
            #region Snippet:StartMediaComposition
            var compositionSteamState = await mediaCompositionClient.StartAsync(mediaCompositionId);
            #endregion Snippet:StartMediaComposition

        }

        public async Task StopMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateMediaCompositionClient();
            #region Snippet:StopMediaComposition
            var compositionSteamState = await mediaCompositionClient.StopAsync(mediaCompositionId);
            #endregion Snippet:StopMediaComposition
        }

        public async Task DeleteMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateMediaCompositionClient();
            #region Snippet:DeleteMediaComposition
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
            #endregion Snippet:DeleteMediaComposition

        }

        /// <summary>
        /// Creates a <see cref="MediaCompositionClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="MediaCompositionClient" />.</returns>
        protected MediaCompositionClient CreateMediaCompositionClient()
            => new MediaCompositionClient(
                    "REPLACE_WITH_CONNECTION_STRING",
                    new MediaCompositionClientOptions(MediaCompositionClientOptions.ServiceVersion.V2022_06_26_Preview));
    }
}
