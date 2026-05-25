// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AlertsManagement.Models;

namespace Azure.ResourceManager.AlertsManagement
{
    // Backward compatibility additions for the tenant-scope ServiceAlertResource:
    //  1. ChangeState(ServiceAlertState, string, ...) - the AutoRest-based v1.1.1 SDK accepted
    //     a plain string for the comment; the new TypeSpec spec wraps it in a ServiceAlertComments
    //     model. These overloads convert the string into ServiceAlertComments and delegate.
    //  2. GetEnrichments / GetEnrichmentsAsync - the new spec binds the getEnrichments operation
    //     to the extension-scope ScopedServiceAlertResource only (because it carries the @list
    //     decorator). The v1.1.1 SDK exposed the same operation on the tenant-scope resource, so
    //     we restore it here by forwarding to a ScopedServiceAlertResource constructed with the
    //     tenant alert Id (which yields the same wire path).
    public partial class ServiceAlertResource
    {
        /// <summary>
        /// Generate the resource identifier of a subscription-scope ServiceAlertResource.
        /// Preserved for binary compatibility with the previous AutoRest SDK; new code should use
        /// <see cref="CreateResourceIdentifier(Guid)"/> for tenant-scope alerts or
        /// <see cref="ScopedServiceAlertResource.CreateResourceIdentifier(string, Guid)"/> for any scope.
        /// </summary>
        /// <param name="subscriptionId"> The subscription id. </param>
        /// <param name="alertId"> The alert id. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Guid alertId)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/alerts/{alertId}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Change the state of an alert. </summary>
        /// <param name="newState"> New state of the alert. </param>
        /// <param name="comment"> reason of change alert state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ServiceAlertResource>> ChangeStateAsync(ServiceAlertState newState, string comment, CancellationToken cancellationToken = default)
        {
            var comments = comment != null ? new ServiceAlertComments { Comments = comment } : default(ServiceAlertComments);
            return await ChangeStateAsync(newState, comments, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Change the state of an alert. </summary>
        /// <param name="newState"> New state of the alert. </param>
        /// <param name="comment"> reason of change alert state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ServiceAlertResource> ChangeState(ServiceAlertState newState, string comment, CancellationToken cancellationToken = default)
        {
            var comments = comment != null ? new ServiceAlertComments { Comments = comment } : default(ServiceAlertComments);
            return ChangeState(newState, comments, cancellationToken);
        }

        /// <summary> Get the enrichments of an alert. It returns a collection of one object named default. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<AlertEnrichmentResult> GetEnrichments(CancellationToken cancellationToken = default)
        {
            return Client.GetCachedClient(client => new ScopedServiceAlertResource(client, Id)).GetEnrichments(cancellationToken);
        }

        /// <summary> Get the enrichments of an alert. It returns a collection of one object named default. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<AlertEnrichmentResult> GetEnrichmentsAsync(CancellationToken cancellationToken = default)
        {
            return Client.GetCachedClient(client => new ScopedServiceAlertResource(client, Id)).GetEnrichmentsAsync(cancellationToken);
        }
    }
}
