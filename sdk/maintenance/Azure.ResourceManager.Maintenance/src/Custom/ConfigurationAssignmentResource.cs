// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Maintenance.Models;
namespace Azure.ResourceManager.Maintenance
{
    // Backward-compat: the old Swagger-based SDK (1.1.3) had Get/Update/Delete overloads on
    // ConfigurationAssignmentResource that accepted a configurationAssignmentName string parameter.
    // The TypeSpec generator produces parameterless Get/Delete (using Id) and Update(WaitUntil, data).
    // These custom overloads preserve the old API surface to avoid breaking existing consumers.
    // The Maintenance REST API (ConfigurationAssignments_Get/CreateOrUpdate/Delete) requires
    // providerName, resourceType, resourceName, and configurationAssignmentName as URL segments,
    // which these overloads construct from the resource Id hierarchy.
    public partial class ConfigurationAssignmentResource
    {
        /// <summary>
        /// Get configuration assignment for resource.
        /// </summary>
        /// <param name="configurationAssignmentName"> The name of the ConfigurationAssignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationAssignmentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="configurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<ConfigurationAssignmentResource>> GetAsync(string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));

            using DiagnosticScope scope = _configurationAssignmentsClientDiagnostics.CreateScope("ConfigurationAssignmentResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _configurationAssignmentsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.ResourceType.Namespace, Id.Parent.Parent.Name, Id.Parent.Parent.ResourceType.Type, configurationAssignmentName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MaintenanceConfigurationAssignmentData> response = Response.FromValue(MaintenanceConfigurationAssignmentData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ConfigurationAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get configuration assignment for resource.
        /// </summary>
        /// <param name="configurationAssignmentName"> The name of the ConfigurationAssignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationAssignmentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="configurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ConfigurationAssignmentResource> Get(string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));

            using DiagnosticScope scope = _configurationAssignmentsClientDiagnostics.CreateScope("ConfigurationAssignmentResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _configurationAssignmentsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.ResourceType.Namespace, Id.Parent.Parent.Name, Id.Parent.Parent.ResourceType.Type, configurationAssignmentName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<MaintenanceConfigurationAssignmentData> response = Response.FromValue(MaintenanceConfigurationAssignmentData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ConfigurationAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Register configuration for resource.
        /// </summary>
        /// <param name="configurationAssignmentName"> The name of the ConfigurationAssignment. </param>
        /// <param name="data"> The configurationAssignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationAssignmentName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="configurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<ConfigurationAssignmentResource>> UpdateAsync(string configurationAssignmentName, MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _configurationAssignmentsForResourceGroupClientDiagnostics.CreateScope("ConfigurationAssignmentResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _configurationAssignmentsForResourceGroupRestClient.CreateUpdateConfigurationAssignmentByResourceGroupRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, configurationAssignmentName, MaintenanceConfigurationAssignmentData.ToRequestContent(data), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MaintenanceConfigurationAssignmentData> response = Response.FromValue(MaintenanceConfigurationAssignmentData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ConfigurationAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Register configuration for resource.
        /// </summary>
        /// <param name="configurationAssignmentName"> The name of the ConfigurationAssignment. </param>
        /// <param name="data"> The configurationAssignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationAssignmentName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="configurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ConfigurationAssignmentResource> Update(string configurationAssignmentName, MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _configurationAssignmentsForResourceGroupClientDiagnostics.CreateScope("ConfigurationAssignmentResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _configurationAssignmentsForResourceGroupRestClient.CreateUpdateConfigurationAssignmentByResourceGroupRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, configurationAssignmentName, MaintenanceConfigurationAssignmentData.ToRequestContent(data), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<MaintenanceConfigurationAssignmentData> response = Response.FromValue(MaintenanceConfigurationAssignmentData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ConfigurationAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Unregister configuration for resource.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="configurationAssignmentName"> The name of the ConfigurationAssignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationAssignmentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="configurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ArmOperation<ConfigurationAssignmentResource>> DeleteAsync(WaitUntil waitUntil, string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));

            using DiagnosticScope scope = _configurationAssignmentsClientDiagnostics.CreateScope("ConfigurationAssignmentResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _configurationAssignmentsRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.ResourceType.Namespace, Id.Parent.Parent.Name, Id.Parent.Parent.ResourceType.Type, configurationAssignmentName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MaintenanceConfigurationAssignmentData> response = Response.FromValue(MaintenanceConfigurationAssignmentData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                MaintenanceArmOperation<ConfigurationAssignmentResource> operation = new MaintenanceArmOperation<ConfigurationAssignmentResource>(Response.FromValue(new ConfigurationAssignmentResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Unregister configuration for resource.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="configurationAssignmentName"> The name of the ConfigurationAssignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationAssignmentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="configurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<ConfigurationAssignmentResource> Delete(WaitUntil waitUntil, string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));

            using DiagnosticScope scope = _configurationAssignmentsClientDiagnostics.CreateScope("ConfigurationAssignmentResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _configurationAssignmentsRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.ResourceType.Namespace, Id.Parent.Parent.Name, Id.Parent.Parent.ResourceType.Type, configurationAssignmentName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<MaintenanceConfigurationAssignmentData> response = Response.FromValue(MaintenanceConfigurationAssignmentData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                MaintenanceArmOperation<ConfigurationAssignmentResource> operation = new MaintenanceArmOperation<ConfigurationAssignmentResource>(Response.FromValue(new ConfigurationAssignmentResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
