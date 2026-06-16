// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid.Mocking
{
    public partial class MockableEventGridResourceGroupResource
    {
        /// <summary> List global event subscriptions under a resource group for a topic type. </summary>
        public virtual AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicTypeName, nameof(topicTypeName));

            async Task<Page<EventGridSubscriptionData>> FirstPageFunc(int? pageSizeHint)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = EventSubscriptionsResourceGroupScopeRestClient.CreateGetGlobalEventSubscriptionsDataForTopicTypeRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, topicTypeName, filter, top, context);
                using DiagnosticScope scope = EventSubscriptionsResourceGroupScopeClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetGlobalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    Response response = await EventSubscriptionsResourceGroupScopeRestClient.Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    EventSubscriptionsListResult result = EventSubscriptionsListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.OriginalString, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<EventGridSubscriptionData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = EventSubscriptionsResourceGroupScopeRestClient.CreateNextGetGlobalEventSubscriptionsDataForTopicTypeRequest(new Uri(nextLink), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, topicTypeName, filter, top, context);
                using DiagnosticScope scope = EventSubscriptionsResourceGroupScopeClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetGlobalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    Response response = await EventSubscriptionsResourceGroupScopeRestClient.Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    EventSubscriptionsListResult result = EventSubscriptionsListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.OriginalString, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> List global event subscriptions under a resource group for a topic type. </summary>
        public virtual Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicTypeName, nameof(topicTypeName));

            Page<EventGridSubscriptionData> FirstPageFunc(int? pageSizeHint)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = EventSubscriptionsResourceGroupScopeRestClient.CreateGetGlobalEventSubscriptionsDataForTopicTypeRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, topicTypeName, filter, top, context);
                using DiagnosticScope scope = EventSubscriptionsResourceGroupScopeClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetGlobalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    Response response = EventSubscriptionsResourceGroupScopeRestClient.Pipeline.ProcessMessage(message, context);
                    EventSubscriptionsListResult result = EventSubscriptionsListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.OriginalString, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<EventGridSubscriptionData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = EventSubscriptionsResourceGroupScopeRestClient.CreateNextGetGlobalEventSubscriptionsDataForTopicTypeRequest(new Uri(nextLink), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, topicTypeName, filter, top, context);
                using DiagnosticScope scope = EventSubscriptionsResourceGroupScopeClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetGlobalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    Response response = EventSubscriptionsResourceGroupScopeRestClient.Pipeline.ProcessMessage(message, context);
                    EventSubscriptionsListResult result = EventSubscriptionsListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.OriginalString, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> List regional event subscriptions under a resource group. </summary>
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(AzureLocation location, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<EventGridSubscriptionData>> FirstPageFunc(int? pageSizeHint)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = EventSubscriptionsResourceGroupScopeRestClient.CreateGetRegionalEventSubscriptionsDataRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, location, filter, top, context);
                using DiagnosticScope scope = EventSubscriptionsResourceGroupScopeClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsData");
                scope.Start();
                try
                {
                    Response response = await EventSubscriptionsResourceGroupScopeRestClient.Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    EventSubscriptionsListResult result = EventSubscriptionsListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.OriginalString, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<EventGridSubscriptionData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = EventSubscriptionsResourceGroupScopeRestClient.CreateNextGetRegionalEventSubscriptionsDataRequest(new Uri(nextLink), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, location, filter, top, context);
                using DiagnosticScope scope = EventSubscriptionsResourceGroupScopeClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsData");
                scope.Start();
                try
                {
                    Response response = await EventSubscriptionsResourceGroupScopeRestClient.Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    EventSubscriptionsListResult result = EventSubscriptionsListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.OriginalString, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> List regional event subscriptions under a resource group. </summary>
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(AzureLocation location, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<EventGridSubscriptionData> FirstPageFunc(int? pageSizeHint)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = EventSubscriptionsResourceGroupScopeRestClient.CreateGetRegionalEventSubscriptionsDataRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, location, filter, top, context);
                using DiagnosticScope scope = EventSubscriptionsResourceGroupScopeClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsData");
                scope.Start();
                try
                {
                    Response response = EventSubscriptionsResourceGroupScopeRestClient.Pipeline.ProcessMessage(message, context);
                    EventSubscriptionsListResult result = EventSubscriptionsListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.OriginalString, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<EventGridSubscriptionData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = EventSubscriptionsResourceGroupScopeRestClient.CreateNextGetRegionalEventSubscriptionsDataRequest(new Uri(nextLink), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, location, filter, top, context);
                using DiagnosticScope scope = EventSubscriptionsResourceGroupScopeClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsData");
                scope.Start();
                try
                {
                    Response response = EventSubscriptionsResourceGroupScopeRestClient.Pipeline.ProcessMessage(message, context);
                    EventSubscriptionsListResult result = EventSubscriptionsListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.OriginalString, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> List regional event subscriptions under a resource group for a topic type. </summary>
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(AzureLocation location, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicTypeName, nameof(topicTypeName));

            async Task<Page<EventGridSubscriptionData>> FirstPageFunc(int? pageSizeHint)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = EventSubscriptionsResourceGroupScopeRestClient.CreateGetRegionalEventSubscriptionsDataForTopicTypeRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, location, topicTypeName, filter, top, context);
                using DiagnosticScope scope = EventSubscriptionsResourceGroupScopeClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    Response response = await EventSubscriptionsResourceGroupScopeRestClient.Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    EventSubscriptionsListResult result = EventSubscriptionsListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.OriginalString, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<EventGridSubscriptionData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = EventSubscriptionsResourceGroupScopeRestClient.CreateNextGetRegionalEventSubscriptionsDataForTopicTypeRequest(new Uri(nextLink), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, location, topicTypeName, filter, top, context);
                using DiagnosticScope scope = EventSubscriptionsResourceGroupScopeClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    Response response = await EventSubscriptionsResourceGroupScopeRestClient.Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    EventSubscriptionsListResult result = EventSubscriptionsListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.OriginalString, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> List regional event subscriptions under a resource group for a topic type. </summary>
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(AzureLocation location, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicTypeName, nameof(topicTypeName));

            Page<EventGridSubscriptionData> FirstPageFunc(int? pageSizeHint)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = EventSubscriptionsResourceGroupScopeRestClient.CreateGetRegionalEventSubscriptionsDataForTopicTypeRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, location, topicTypeName, filter, top, context);
                using DiagnosticScope scope = EventSubscriptionsResourceGroupScopeClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    Response response = EventSubscriptionsResourceGroupScopeRestClient.Pipeline.ProcessMessage(message, context);
                    EventSubscriptionsListResult result = EventSubscriptionsListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.OriginalString, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<EventGridSubscriptionData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = EventSubscriptionsResourceGroupScopeRestClient.CreateNextGetRegionalEventSubscriptionsDataForTopicTypeRequest(new Uri(nextLink), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, location, topicTypeName, filter, top, context);
                using DiagnosticScope scope = EventSubscriptionsResourceGroupScopeClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    Response response = EventSubscriptionsResourceGroupScopeRestClient.Pipeline.ProcessMessage(message, context);
                    EventSubscriptionsListResult result = EventSubscriptionsListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.OriginalString, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
