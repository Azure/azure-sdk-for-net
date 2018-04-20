// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace Media.Tests.ScenarioTests
{
    public class LiveEventTests : MediaScenarioTestBase
    {
        [Fact]
        public void LiveEventComboTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType().FullName))
            {
                try
                {
                    CreateMediaServicesAccount();

                    // List LiveEvents, which should be empty
                    var liveEvents = MediaClient.LiveEvents.List(ResourceGroup, AccountName);
                    Assert.Empty(liveEvents);

                    string eventName = TestUtilities.GenerateName("liveevent");
                    string liveEventDescription = "A test live event";

                    // Get the LiveEvent, which should not exist
                    LiveEvent liveEvent = MediaClient.LiveEvents.Get(ResourceGroup, AccountName, eventName);
                    Assert.Null(liveEvent);

                    // Create the LiveEvent
                    string expectedProtocol = LiveEventInputProtocol.FragmentedMP4.ToString();
                    LiveEvent parameters = new LiveEvent(location: Helpers.MediaManagementTestUtilities.DefaultLocation, input: new LiveEventInput(LiveEventInputProtocol.FragmentedMP4), description: liveEventDescription);
                    LiveEvent createdLiveEvent = MediaClient.LiveEvents.Create(ResourceGroup, AccountName, eventName, parameters, autoStart: true);
                    ValidateLiveEvent(createdLiveEvent, eventName, liveEventDescription, LiveEventResourceState.Running, expectedProtocol);

                    // List LiveEvents and validate the created LiveEvent shows up
                    liveEvents = MediaClient.LiveEvents.List(ResourceGroup, AccountName);
                    Assert.Single(liveEvents);
                    ValidateLiveEvent(liveEvents.First(), eventName, liveEventDescription, LiveEventResourceState.Running, expectedProtocol);

                    // Get the newly created LiveEvent
                    liveEvent = MediaClient.LiveEvents.Get(ResourceGroup, AccountName, eventName);
                    ValidateLiveEvent(liveEvent, eventName, liveEventDescription, LiveEventResourceState.Running, expectedProtocol);
                    Assert.NotNull(liveEvent);

                    // Stop the LiveEvent
                    MediaClient.LiveEvents.Stop(ResourceGroup, AccountName, eventName);

                    // Validate that the live event is stopped
                    liveEvent = MediaClient.LiveEvents.Get(ResourceGroup, AccountName, eventName);
                    Assert.NotNull(liveEvent);
                    ValidateLiveEvent(liveEvent, eventName, liveEventDescription, LiveEventResourceState.Stopped, null);

                    // Delete the LiveEvent
                    MediaClient.LiveEvents.Delete(ResourceGroup, AccountName, eventName);

                    // List LiveEvent, which should be empty again
                    liveEvents = MediaClient.LiveEvents.List(ResourceGroup, AccountName);
                    Assert.Empty(liveEvents);

                    // Get LiveEvent, which should not exist
                    liveEvent = MediaClient.LiveEvents.Get(ResourceGroup, AccountName, eventName);
                    Assert.Null(liveEvent);
                }
                finally
                {
                    DeleteMediaServicesAccount();
                }
            }
        }

        internal static void ValidateLiveEvent(LiveEvent liveEvent, string expectedName, string expectedDescription, LiveEventResourceState expectedResourceState, string expectedProtocol)
        {
            Assert.Equal(expectedName, liveEvent.Name);
            Assert.Equal(expectedDescription, liveEvent.Description);
            Assert.False(string.IsNullOrEmpty(liveEvent.Id));
            Assert.Equal(expectedResourceState, liveEvent.ResourceState);

            if (liveEvent.ResourceState == LiveEventResourceState.Running)
            {
                Assert.False(string.IsNullOrEmpty(liveEvent.Input.AccessToken));
                Assert.NotEmpty(liveEvent.Input.Endpoints);

                foreach (var endpoint in liveEvent.Input.Endpoints)
                {
                    Assert.False(string.IsNullOrEmpty(endpoint.Url));
                    Assert.Equal(expectedProtocol, endpoint.Protocol);
                }
            }
            else if (liveEvent.ResourceState == LiveEventResourceState.Stopped)
            {
                Assert.Empty(liveEvent.Input.Endpoints);
            }
        }
    }
}

