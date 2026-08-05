// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AlertsManagement.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertsManagement
{
    // Backward compatibility additions for ServiceAlertResource:
    //  1. CreateResourceIdentifier(string subscriptionId, Guid alertId) - matches the
    //     v1.1.x autorest-generated subscription-scope factory that builds the
    //     /subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/alerts/{alertId}
    //     resource id. The TypeSpec spec now models the alert under the AlertOperationGroup
    //     interface using a subscription-scoped Legacy.ExtensionOperations alias, so the
    //     emitted Request Path matches the AutoRest GA contract byte-for-byte.
    //  2. ChangeState(ServiceAlertState, string, ...) - v1.1.x accepted a plain string for the
    //     comment; the new spec wraps it in ServiceAlertChangeStateContent. These overloads
    //     convert the string into ServiceAlertChangeStateContent and call the generated REST client.
    [CodeGenSuppress("ChangeStateAsync", typeof(ServiceAlertState), typeof(ServiceAlertChangeStateContent), typeof(CancellationToken))]
    [CodeGenSuppress("ChangeState", typeof(ServiceAlertState), typeof(ServiceAlertChangeStateContent), typeof(CancellationToken))]
    public partial class ServiceAlertResource
    {
        /// <summary>
        /// Generate the resource identifier of a subscription-scope ServiceAlertResource.
        /// Preserved for binary compatibility with the previous AutoRest SDK; new code should
        /// use <see cref="CreateResourceIdentifier(string, Guid)"/> with the desired scope.
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
        public virtual async Task<Response<ServiceAlertResource>> ChangeStateAsync(ServiceAlertState newState, string comment = null, CancellationToken cancellationToken = default)
        {
            ServiceAlertChangeStateContent content = comment != null ? new ServiceAlertChangeStateContent { Comments = comment } : default;
            using DiagnosticScope scope = _alertsClientDiagnostics.CreateScope("ServiceAlertResource.ChangeState");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _alertsRestClient.CreateChangeStateRequest(Id.Parent.ToString(), Guid.Parse(Id.Name), newState.ToString(), ServiceAlertChangeStateContent.ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ServiceAlertData> response = Response.FromValue(ServiceAlertData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ServiceAlertResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Change the state of an alert. </summary>
        /// <param name="newState"> New state of the alert. </param>
        /// <param name="comment"> reason of change alert state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ServiceAlertResource> ChangeState(ServiceAlertState newState, string comment = null, CancellationToken cancellationToken = default)
        {
            ServiceAlertChangeStateContent content = comment != null ? new ServiceAlertChangeStateContent { Comments = comment } : default;
            using DiagnosticScope scope = _alertsClientDiagnostics.CreateScope("ServiceAlertResource.ChangeState");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _alertsRestClient.CreateChangeStateRequest(Id.Parent.ToString(), Guid.Parse(Id.Name), newState.ToString(), ServiceAlertChangeStateContent.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ServiceAlertData> response = Response.FromValue(ServiceAlertData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ServiceAlertResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
