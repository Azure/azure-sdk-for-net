// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventGrid.Mocking
{
    public partial class MockableEventGridArmClient : ArmResource
    {
        private ClientDiagnostics _eventGridTopicTopicsClientDiagnostics;
        private TopicsRestOperations _eventGridTopicTopicsRestClient;
        private ClientDiagnostics EventGridTopicTopicsClientDiagnostics => _eventGridTopicTopicsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.EventGrid", EventGridTopicResource.ResourceType.Namespace, Diagnostics);
        private TopicsRestOperations EventGridTopicTopicsRestClient => _eventGridTopicTopicsRestClient ??= new TopicsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(EventGridTopicResource.ResourceType));

        /// <summary>
        /// List event types for a topic.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerNamespace}/{resourceTypeName}/{resourceName}/providers/Microsoft.EventGrid/eventTypes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Topics_ListEventTypes</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The resource identifier that the event types will be listed on. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        /// <returns> An async collection of <see cref="EventTypeUnderTopic" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<EventTypeUnderTopic> GetEventTypesAsync(ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(scope, nameof(scope));

            var parentPart = scope.Parent.SubstringAfterProviderNamespace();
            var resourceTypeName = (string.IsNullOrEmpty(parentPart) ? string.Empty : $"{parentPart}/") + scope.ResourceType.GetLastType();

            HttpMessage FirstPageRequest(int? pageSizeHint) => EventGridTopicTopicsRestClient.CreateListEventTypesRequest(Id.SubscriptionId, Id.ResourceGroupName, scope.ResourceType.Namespace, resourceTypeName, scope.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => EventTypeUnderTopic.DeserializeEventTypeUnderTopic(e), EventGridTopicTopicsClientDiagnostics, Pipeline, "EventGridResourceGroupMockingExtension.GetEventTypes", "value", null, cancellationToken);
        }

        /// <summary>
        /// List event types for a topic.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerNamespace}/{resourceTypeName}/{resourceName}/providers/Microsoft.EventGrid/eventTypes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Topics_ListEventTypes</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The resource identifier that the event types will be listed on. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        /// <returns> An async collection of <see cref="EventTypeUnderTopic" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<EventTypeUnderTopic> GetEventTypes(ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(scope, nameof(scope));

            var parentPart = scope.Parent.SubstringAfterProviderNamespace();
            var resourceTypeName = (string.IsNullOrEmpty(parentPart) ? string.Empty : $"{parentPart}/") + scope.ResourceType.GetLastType();

            HttpMessage FirstPageRequest(int? pageSizeHint) => EventGridTopicTopicsRestClient.CreateListEventTypesRequest(Id.SubscriptionId, Id.ResourceGroupName, scope.ResourceType.Namespace, resourceTypeName, scope.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => EventTypeUnderTopic.DeserializeEventTypeUnderTopic(e), EventGridTopicTopicsClientDiagnostics, Pipeline, "EventGridResourceGroupMockingExtension.GetEventTypes", "value", null, cancellationToken);
        }
    }
}
