// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AlertsManagement.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertsManagement
{
    [CodeGenSuppress("ChangeStateAsync", typeof(ServiceAlertState), typeof(ServiceAlertChangeStateContent), typeof(CancellationToken))]
    [CodeGenSuppress("ChangeState", typeof(ServiceAlertState), typeof(ServiceAlertChangeStateContent), typeof(CancellationToken))]
    public partial class ServiceAlertTenantResource
    {
        /// <summary> Change the state of an alert. </summary>
        /// <param name="newState"> New state of the alert. </param>
        /// <param name="comment"> reason of change alert state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ServiceAlertTenantResource>> ChangeStateAsync(ServiceAlertState newState, string comment = null, CancellationToken cancellationToken = default)
        {
            ServiceAlertChangeStateContent content = comment != null ? new ServiceAlertChangeStateContent { Comments = comment } : default;
            using DiagnosticScope scope = _alertsClientDiagnostics.CreateScope("ServiceAlertTenantResource.ChangeState");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _alertsRestClient.CreateChangeStateRequest(Guid.Parse(Id.Name), newState.ToString(), ServiceAlertChangeStateContent.ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ServiceAlertData> response = Response.FromValue(ServiceAlertData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ServiceAlertTenantResource(Client, response.Value), response.GetRawResponse());
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
        public virtual Response<ServiceAlertTenantResource> ChangeState(ServiceAlertState newState, string comment = null, CancellationToken cancellationToken = default)
        {
            ServiceAlertChangeStateContent content = comment != null ? new ServiceAlertChangeStateContent { Comments = comment } : default;
            using DiagnosticScope scope = _alertsClientDiagnostics.CreateScope("ServiceAlertTenantResource.ChangeState");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _alertsRestClient.CreateChangeStateRequest(Guid.Parse(Id.Name), newState.ToString(), ServiceAlertChangeStateContent.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ServiceAlertData> response = Response.FromValue(ServiceAlertData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ServiceAlertTenantResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
