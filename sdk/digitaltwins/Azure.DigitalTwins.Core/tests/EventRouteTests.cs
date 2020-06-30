// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// Tests for DigitalTwinServiceClient methods dealing with Digital Twin operations
    /// </summary>
    public class EventRouteTests : E2eTestBase
    {
        public EventRouteTests(bool isAsync)
            : base(isAsync)
        {
        }

        // Infrastructure setup script uses this hardcoded value when linking the test eventhub to the test digital twins instance
        private const string EndpointName = "someEventHubEndpoint";

        [Test]
        public async Task EventRoutes_Lifecycle()
        {
            // arrange

            DigitalTwinsClient client = GetClient();

            // Ensure unique eventRouteId and endpointName
            string eventRouteId = $"someEventRouteId-{GetRandom()}";
            string filter = "$eventType = 'DigitalTwinTelemetryMessages' or $eventType = 'DigitalTwinLifecycleNotification'";
            var eventRoute = new EventRoute(EndpointName)
            {
                Filter = filter
            };

            // Test CreateEventRoute
            Response createEventRouteResponse = await client.CreateEventRouteAsync(eventRouteId, eventRoute).ConfigureAwait(false);
            createEventRouteResponse.Status.Should().Be((int)HttpStatusCode.NoContent);

            // Test GetEventRoute
            EventRoute getEventRouteResult = await client.GetEventRouteAsync(eventRouteId);
            eventRoute.EndpointName.Should().Be(getEventRouteResult.EndpointName);
            eventRoute.Filter.Should().Be(getEventRouteResult.Filter);
            eventRouteId.Should().Be(getEventRouteResult.Id);

            // Test GetEventRoutes
            var eventRoutesListOptions = new EventRoutesListOptions();
            AsyncPageable<EventRoute> eventRouteList = client.GetEventRoutesAsync(eventRoutesListOptions);
            bool eventRouteFoundInList = false;
            await foreach (EventRoute eventRouteListEntry in eventRouteList)
            {
                if (StringComparer.Ordinal.Equals(eventRouteListEntry.Id, eventRouteId))
                {
                    eventRouteFoundInList = true;
                    eventRoute.EndpointName.Should().Be(getEventRouteResult.EndpointName);
                    eventRoute.Filter.Should().Be(getEventRouteResult.Filter);
                    break;
                }
            }

            eventRouteFoundInList.Should().BeTrue("Newly created event route should have been present when listing all event routes");

            // Test DeleteEventRoute
            Response deleteEventRouteResponse = await client.DeleteEventRouteAsync(eventRouteId).ConfigureAwait(false);
            deleteEventRouteResponse.Status.Should().Be((int)HttpStatusCode.NoContent);

            // Verify event route was deleted by trying to get it again

            // act
            Func<Task> act = async () => await client.GetEventRouteAsync(eventRouteId).ConfigureAwait(false);

            // assert
            act.Should().Throw<RequestFailedException>()
                .And.Status.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Test]
        public void EventRoutes_EventRouteNotExist_ThrowsNotFoundException()
        {
            // arrange
            DigitalTwinsClient client = GetClient();

            // act
            Func<Task> act = async () => await client.GetEventRouteAsync("someNonExistantEventRoute").ConfigureAwait(false);

            // assert
            act.Should().Throw<RequestFailedException>()
                .And.Status.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Test]
        public void EventRoutes_MalformedEventRouteFilter_ThrowsBadRequestException()
        {
            // arrange

            DigitalTwinsClient client = GetClient();

            // Ensure unique eventRouteId and endpointName
            string eventRouteId = $"someEventRouteId-{GetRandom()}";
            string filter = "this is not a valid filter string";
            var eventRoute = new EventRoute(EndpointName)
            {
                Filter = filter
            };

            // Test CreateEventRoute
            Func<Task> act = async () => await client.CreateEventRouteAsync(eventRouteId, eventRoute).ConfigureAwait(false);
            act.Should().Throw<RequestFailedException>()
                .And.Status.Should().Be((int)HttpStatusCode.BadRequest);
        }
    }
}
