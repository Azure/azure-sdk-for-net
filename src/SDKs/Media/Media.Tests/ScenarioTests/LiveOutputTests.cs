// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Media.Tests.ScenarioTests
{
    public class LiveOutputTests : MediaScenarioTestBase
    {
        [Fact]
        public void LiveOutputComboTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType().FullName))
            {
                try
                {
                    CreateMediaServicesAccount();

                    // Create the LiveEvent
                    string eventName = TestUtilities.GenerateName("liveevent");
                    LiveEvent eventParameters = new LiveEvent(location: Helpers.MediaManagementTestUtilities.DefaultLocation, input: new LiveEventInput(LiveEventInputProtocol.FragmentedMP4));
                    LiveEvent liveEvent = MediaClient.LiveEvents.Create(ResourceGroup, AccountName, eventName, eventParameters, autoStart: true);

                    // List liveOutputs, which should be empty
                    var liveOutputs = MediaClient.LiveOutputs.List(ResourceGroup, AccountName, eventName);
                    Assert.Empty(liveOutputs);

                    string liveOutputName = TestUtilities.GenerateName("liveOutput");
                    string liveOutputDescription = "A test liveOutput";

                    // Try to get the live output, which should not exist
                    LiveOutput liveOutput = MediaClient.LiveOutputs.Get(ResourceGroup, AccountName, eventName, liveOutputName);
                    Assert.Null(liveOutput);

                    // Create an Asset for the LiveOutput to use
                    string assetName = TestUtilities.GenerateName("asset");
                    Asset asset = MediaClient.Assets.CreateOrUpdate(ResourceGroup, AccountName, assetName, new Asset());

                    // Create a liveOutput
                    string manifestName = "output";
                    LiveOutput parameters = new LiveOutput(assetName: asset.AssetId.ToString(), description: liveOutputDescription, manifestName: manifestName, archiveWindowLength: TimeSpan.FromMinutes(10));
                    LiveOutput createdLiveOutput = MediaClient.LiveOutputs.Create(ResourceGroup, AccountName, eventName, liveOutputName, parameters);
                    ValidateLiveOutput(createdLiveOutput, liveOutputName, liveOutputDescription, manifestName, LiveOutputResourceState.Running);

                    // List liveOutputs and validate the created liveOutput shows up
                    liveOutputs = MediaClient.LiveOutputs.List(ResourceGroup, AccountName, eventName);
                    Assert.Single(liveOutputs);
                    ValidateLiveOutput(liveOutputs.First(), liveOutputName, liveOutputDescription, manifestName, LiveOutputResourceState.Running);

                    // Get the newly created liveOutput
                    liveOutput = MediaClient.LiveOutputs.Get(ResourceGroup, AccountName, eventName, liveOutputName);
                    Assert.NotNull(liveOutput);
                    ValidateLiveOutput(liveOutput, liveOutputName, liveOutputDescription, manifestName, LiveOutputResourceState.Running);

                    // Delete the liveOutput
                    MediaClient.LiveOutputs.Delete(ResourceGroup, AccountName, eventName, liveOutputName);

                    // List liveOutputs, which should be empty again
                    liveOutputs = MediaClient.LiveOutputs.List(ResourceGroup, AccountName, eventName);
                    Assert.Empty(liveOutputs);

                    // Get tranform, which should not exist
                    liveOutput = MediaClient.LiveOutputs.Get(ResourceGroup, AccountName, eventName, liveOutputName);
                    Assert.Null(liveOutput);

                    // Stop the LiveEvent
                    MediaClient.LiveEvents.Stop(ResourceGroup, AccountName, eventName);

                    // Delete the LiveEvent
                    MediaClient.LiveEvents.Delete(ResourceGroup, AccountName, eventName);

                    // Delete the Asset
                    MediaClient.Assets.Delete(ResourceGroup, AccountName, assetName);
                }
                finally
                {
                    DeleteMediaServicesAccount();
                }
            }
        }

        internal static void ValidateLiveOutput(LiveOutput liveOutput, string expectedName, string expectedDescription, string expectedManifestName, LiveOutputResourceState expectedResourceState)
        {
            Assert.Equal(expectedDescription, liveOutput.Description);
            Assert.Equal(expectedName, liveOutput.Name);
            Assert.Equal(expectedDescription, liveOutput.Description);
            Assert.Equal(expectedManifestName, liveOutput.ManifestName);
            Assert.Equal(expectedResourceState, liveOutput.ResourceState);
            Assert.False(string.IsNullOrEmpty(liveOutput.Id));
        }
    }
}

