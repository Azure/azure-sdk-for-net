// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.MediaComposition.Models;
using Azure.Communication.Tests;
using NUnit.Framework;

namespace Azure.Communication.MediaComposition.Tests
{
    public class MediaCompositionClientLiveTests : MediaCompositionClientLiveTestBase
    {
        private const string mediaCompositionId = "presenter";
        private static readonly Dictionary<string, MediaInput> _presenterInputs = new()
        {
            ["presenter"] = new ParticipantInput(
                    id: new() { MicrosoftTeamsUser = new("f3ba9014-6dca-4456-8ec0-fa03cfa2b7b7") },
                    call: "teamsMeeting")
            {
                PlaceholderImageUri = "https://imageendpoint"
            },
            ["support"] = new ParticipantInput(
                    id: new() { MicrosoftTeamsUser = new("fa4337b5-f13a-41c5-a34f-f2aa46699b61") },
                    call: "teamsMeeting")
            {
                PlaceholderImageUri = "https://imageendpoint"
            },
            ["teamsMeeting"] = new TeamsMeetingInput("https://teamsJoinUrl")
        };

        private static readonly MediaCompositionLayout _presenterLayout = new PresenterLayout(presenterId: "presenter", supportId: "support")
        {
            SupportPosition = SupportPosition.TopLeft,
            SupportAspectRatio = 3 / 2,
            Resolution = new(1920, 1080)
        };

        private static readonly Dictionary<string, MediaOutput> _presenterOutputs = new()
        {
            ["acsGroupCall"] = new GroupCallOutput("d12d2277-ffec-4e22-9979-8c0d8c13d193")
        };

        public MediaCompositionClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [TestCase(AuthMethod.ConnectionString, TestName = "CreateMediaCompositionWithConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "CreateMediaCompositionWithKeyCredential")]
        // TODO: AAD authentication for tests not supported in INT environment. Uncomment the line below once we have ppe/prod deployment
        // [TestCase(AuthMethod.TokenCredential, TestName = "CreateMediaCompositionWithTokenCredential")]
        public async Task CreatePresenterMediaComposition(AuthMethod authMethod)
        {
            var mediaCompositionClient = CreateClient(authMethod);
            var response = await CreateMediaCompositionHelper(mediaCompositionClient);
            Assert.IsInstanceOf(response.Value.Layout.GetType(), typeof(PresenterLayout));
            Assert.AreEqual(response.Value.Inputs.Count, 3);
            Assert.AreEqual(response.Value.Outputs.Count, 1);
            Assert.AreEqual(response.Value.StreamState, CompositionStreamState.NotStarted);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task CreateMediaCompositionNullInputsShouldThrow()
        {
            try
            {
                var mediaCompositionClient = CreateClient();
                await mediaCompositionClient.CreateAsync(mediaCompositionId, _presenterLayout, null, _presenterOutputs);
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.AreEqual(ex.Status, 400);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown trying to create a media composition with null inputs.");
        }

        [Test]
        public async Task CreateMediaCompositionNullOutputsShouldThrow()
        {
            try
            {
                var mediaCompositionClient = CreateClient();
                await mediaCompositionClient.CreateAsync(mediaCompositionId, _presenterLayout, _presenterInputs, null);
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.AreEqual(ex.Status, 400);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown trying to create a media composition with null outputs.");
        }

        [Test]
        public async Task CreateMediaCompositionInvalidInputIdsShouldThrow()
        {
            try
            {
                var mediaCompositionClient = CreateClient();
                var layout = new GridLayout(rows: 2, columns: 2, inputIds: new List<List<string>>() { new List<string>() { "invalidId" }});
                var inputs = new Dictionary<string, MediaInput>()
                {
                    ["teamsMeeting"] = new TeamsMeetingInput("https://teamsJoinUrl")
                };
                await mediaCompositionClient.CreateAsync(mediaCompositionId, layout, _presenterInputs, _presenterOutputs);
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.AreEqual(ex.Status, 400);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown trying to create a media composition with invalid inputIds.");
        }

        [Test]
        public async Task CreateMediaCompositionNullLayoutShouldThrow()
        {
            try
            {
                var mediaCompositionClient = CreateClient();
                await mediaCompositionClient.CreateAsync(mediaCompositionId, null, _presenterInputs, _presenterOutputs);
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.AreEqual(ex.Status, 400);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown trying to create a media composition with null layout.");
        }

        [Test]
        public async Task GetCreatedMediaComposition()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            var response = await mediaCompositionClient.GetAsync(mediaCompositionId);
            Assert.AreEqual(response.Value.Id, mediaCompositionId);
            Assert.IsInstanceOf(response.Value.Layout.GetType(), typeof(PresenterLayout));
            Assert.AreEqual(response.Value.Inputs.Count, 3);
            Assert.AreEqual(response.Value.Outputs.Count, 1);
            Assert.AreEqual(response.Value.StreamState, CompositionStreamState.NotStarted);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task GetNonExistentMediaCompositionShouldThrow()
        {
            try
            {
                var mediaCompositionClient = CreateClient();
                var response = await mediaCompositionClient.GetAsync("nonexistentMediaCompositionId");
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.AreEqual(ex.Status, 404);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown trying to get a non-existent media composition..");
        }

        [Test]
        public async Task StartCreatedMediaComposition()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            var response = await mediaCompositionClient.StartAsync(mediaCompositionId);
            Assert.AreEqual(response.Value, CompositionStreamState.Running);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task StartNonExistentMediaCompositionShouldThrow()
        {
            try
            {
                var mediaCompositionClient = CreateClient();
                var response = await mediaCompositionClient.StartAsync("nonexistentMediaCompositionId");
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.AreEqual(ex.Status, 404);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown trying to start a non-existent media composition.");
        }

        [Test]
        public async Task StopCreatedMediaComposition()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            var response = await mediaCompositionClient.StopAsync(mediaCompositionId);
            Assert.AreEqual(response.Value, CompositionStreamState.NotStarted);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task StopStartedMediaComposition()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            var startResponse = await mediaCompositionClient.StartAsync(mediaCompositionId);
            Assert.AreEqual(startResponse.Value, CompositionStreamState.Running);
            var stopResponse = await mediaCompositionClient.StopAsync(mediaCompositionId);
            Assert.AreEqual(stopResponse.Value, CompositionStreamState.Stopped);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task StopNonExistentMediaCompositionShouldThrow()
        {
            try
            {
                var mediaCompositionClient = CreateClient();
                var response = await mediaCompositionClient.StartAsync("nonexistentMediaCompositionId");
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.AreEqual(ex.Status, 404);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown trying to stop a non-existent media composition.");
        }

        [Test]
        public async Task UpdateLayoutInCreatedMediaComposition()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            var updatedLayout = new GridLayout(rows: 2, columns: 2, new List<List<string>> { new List<string>() { "teamsMeeting" } })
            {
                Resolution = new(1920, 1080)
            };
            var response = await mediaCompositionClient.UpdateLayoutAsync(mediaCompositionId, updatedLayout);
            Assert.AreEqual(response.Value.Layout.Grid.Columns, updatedLayout.Grid.Columns);
            Assert.AreEqual(response.Value.Layout.Grid.Rows, updatedLayout.Grid.Rows);
            Assert.AreEqual(response.Value.Layout.Grid.InputIds.Count, 1);
            Assert.IsNull(response.Value.Layout.Presenter);

            // Inputs and Outputs set to null by default and should not change
            Assert.AreEqual(response.Value.Inputs.Count, 3);
            Assert.AreEqual(response.Value.Outputs.Count, 1);

            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task UpdateNonExistentMediaCompositionShouldThrow()
        {
            try
            {
                var mediaCompositionClient = CreateClient();
                var response = await mediaCompositionClient.UpdateLayoutAsync("nonexistentMediaCompositionId", null);
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.AreEqual(ex.Status, 404);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown trying to update a non-existent media composition.");
        }

        [Test]
        public async Task AddInputsMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            var inputsToAdd = new Dictionary<string, MediaInput>()
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
            var response = await mediaCompositionClient.AddInputsAsync(mediaCompositionId, inputsToAdd);
            Assert.AreEqual(response.Value.Id, mediaCompositionId);
            response.Value.Inputs.TryGetValue("james", out var james);
            Assert.IsNotNull(james);
            response.Value.Inputs.TryGetValue("presenter", out var presenter);
            Assert.IsNotNull(presenter);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task RemoveInputsMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            var gridLayoutOptions = new GridLayoutOptions(2, 2);
            gridLayoutOptions.InputIds.Add(new List<string> { "teamsMeeting" });
            var updatedLayout = new MediaCompositionLayout()
            {
                Resolution = new(1920, 1080),
                Grid = gridLayoutOptions
            };
            await mediaCompositionClient.UpdateLayoutAsync(mediaCompositionId, updatedLayout);
            var inputIdsToRemove = new List<string>()
            {
                "presenter", "support"
            };
            var response = await mediaCompositionClient.RemoveInputsAsync(mediaCompositionId, inputIdsToRemove);
            Assert.AreEqual(response.Value.Id, mediaCompositionId);
            response.Value.Inputs.TryGetValue("presenter", out var presenter);
            Assert.IsNull(presenter);
            response.Value.Inputs.TryGetValue("support", out var support);
            Assert.IsNull(support);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task RemoveTeamsMeetingInputShouldThrow()
        {
            try
            {
                var mediaCompositionClient = CreateClient();
                await CreateMediaCompositionHelper(mediaCompositionClient);
                var inputIdsToRemove = new List<string>()
                {
                    "teamsMeeting"
                };
                var response = await mediaCompositionClient.RemoveInputsAsync(mediaCompositionId, inputIdsToRemove);
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.AreEqual(ex.Status, 400);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown trying to update a non-existent media composition.");
        }

        [Test]
        public async Task AddInputsForNonExistentMediaCompositionShouldThrow()
        {
            try
            {
                var mediaCompositionClient = CreateClient();
                var inputsToAdd = new Dictionary<string, MediaInput>()
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
                var response = await mediaCompositionClient.AddInputsAsync("nonexistentMediaCompositionId", inputsToAdd);
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.AreEqual(ex.Status, 404);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown trying to add inputs to a non-existent media composition.");
        }

        [Test]
        public async Task AddOutputsMediaCompositionAsync()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            var outputsToAdd = new Dictionary<string, MediaOutput>()
            {
                {
                    "youtube",
                    new()
                    {
                        Rtmp = new("key", new(1920, 1080), "rtmp://a.rtmp.youtube.com/live2")
                    }
                }
            };
            var response = await mediaCompositionClient.AddOutputsAsync(mediaCompositionId, outputsToAdd);
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
            var outputIdsToRemove = new List<string>()
            {
                "acsGroupCall"
            };
            var response = await mediaCompositionClient.RemoveOutputsAsync(mediaCompositionId, outputIdsToRemove);
            Assert.AreEqual(response.Value.Id, mediaCompositionId);
            response.Value.Outputs.TryGetValue("acsGroupCall", out var acsGroupCall);
            Assert.IsNull(acsGroupCall);
            await mediaCompositionClient.DeleteAsync(mediaCompositionId);
        }

        [Test]
        public async Task RemoveOutputsForNonExistentMediaCompositionShouldThrow()
        {
            try
            {
                var mediaCompositionClient = CreateClient();
                var outputIdsToRemove = new List<string>()
                {
                    "acsGroupCall"
                };
                var response = await mediaCompositionClient.RemoveOutputsAsync("nonexistentMediaCompositionId", outputIdsToRemove);
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.AreEqual(ex.Status, 404);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown trying to remove outputs from a non-existent media composition.");
        }

        [Test]
        public async Task DeleteExistingMediaComposition()
        {
            var mediaCompositionClient = CreateClient();
            await CreateMediaCompositionHelper(mediaCompositionClient);
            var deleteResponse = await mediaCompositionClient.DeleteAsync(mediaCompositionId);
            Assert.AreEqual(deleteResponse.Status, 204);
            try
            {
                var getResponse = await mediaCompositionClient.GetAsync(mediaCompositionId);
            }
            catch (RequestFailedException ex)
            {
                Assert.NotNull(ex.Message);
                Assert.AreEqual(ex.Status, 404);
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail("An exception should have been thrown trying to get a media composition that has been deleted.");
        }

        [Test]
        public async Task DeleteNonExistingMediaComposition()
        {
            var mediaCompositionClient = CreateClient();
            var deleteResponse = await mediaCompositionClient.DeleteAsync(mediaCompositionId);
            Assert.AreEqual(deleteResponse.Status, 204);
        }

        private async Task<Response<MediaCompositionBody>> CreateMediaCompositionHelper(MediaCompositionClient mediaCompositionClient)
        {
            return await mediaCompositionClient.CreateAsync(mediaCompositionId, _presenterLayout, _presenterInputs, _presenterOutputs);
        }
    }
}
