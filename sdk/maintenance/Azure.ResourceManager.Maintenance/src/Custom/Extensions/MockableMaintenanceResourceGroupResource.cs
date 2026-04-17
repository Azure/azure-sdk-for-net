// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Maintenance.Models;

namespace Azure.ResourceManager.Maintenance.Mocking
{
    // Backward-compat bridge: The TypeSpec migration uses OverrideResourceName on ExtensionOperations
    // in ConfigurationAssignment.tsp and ApplyUpdate.tsp to create separate
    // MaintenanceConfigurationAssignment*Resource/Collection and MaintenanceApplyUpdate*Resource/Collection
    // classes per scope variant, resolving CS0111 duplicate method errors from merging operations that
    // share the ConfigurationAssignment/ApplyUpdate models across different scope paths (5-param generic,
    // 7-param by-parent, subscription, resource-group). This changes the API from flat extension methods
    // with explicit path parameters (providerName, resourceType, resourceName, etc.) to typed
    // Resource/Collection classes with scope encoded in ResourceIdentifier. These bridge methods preserve
    // the old v1.1.3 parameter-based API surface using direct REST client calls.
    //
    // Methods in this file cover: apply updates (create, get, get-by-parent), configuration assignments
    // (create, delete, get, list, by-parent variants), and update listing (get updates, get-updates-by-parent).
    public partial class MockableMaintenanceResourceGroupResource
    {
        private ClientDiagnostics _maintenanceApplyUpdateClientDiagnostics;
        private MaintenanceApplyUpdate _maintenanceApplyUpdateRestClient;
        private ClientDiagnostics _configurationAssignmentsClientDiagnostics;
        private ConfigurationAssignments _configurationAssignmentsRestClient;
        private ClientDiagnostics _updatesClientDiagnostics;
        private Updates _updatesRestClient;

        private ClientDiagnostics MaintenanceApplyUpdateClientDiagnostics => _maintenanceApplyUpdateClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Maintenance.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);

        private MaintenanceApplyUpdate MaintenanceApplyUpdateRestClient => _maintenanceApplyUpdateRestClient ??= new MaintenanceApplyUpdate(MaintenanceApplyUpdateClientDiagnostics, Pipeline, Endpoint, "2023-10-01-preview");

        private ClientDiagnostics UpdatesClientDiagnostics => _updatesClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Maintenance.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);

        private Updates UpdatesRestClient => _updatesRestClient ??= new Updates(UpdatesClientDiagnostics, Pipeline, Endpoint, "2023-10-01-preview");

        private ClientDiagnostics ConfigurationAssignmentsClientDiagnostics => _configurationAssignmentsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Maintenance.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);

        private ConfigurationAssignments ConfigurationAssignmentsRestClient => _configurationAssignmentsRestClient ??= new ConfigurationAssignments(ConfigurationAssignmentsClientDiagnostics, Pipeline, Endpoint, "2023-10-01-preview");

        // ===== ApplyUpdate operations =====

        /// <summary> Gets a collection of MaintenanceApplyUpdateResources in the ResourceGroupResource. </summary>
        public virtual MaintenanceApplyUpdateCollection GetMaintenanceApplyUpdates()
        {
            return this.GetCachedClient(client => new MaintenanceApplyUpdateCollection(client, Id));
        }

        /// <summary> Get Configuration records within a subscription and resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdatesAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<MaintenanceApplyUpdateData, MaintenanceApplyUpdateResource>(
                new ApplyUpdateForResourceGroupGetAllAsyncCollectionResultOfT(ApplyUpdateForResourceGroupRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, context, "MockableMaintenanceResourceGroupResource.GetMaintenanceApplyUpdates"),
                data => new MaintenanceApplyUpdateResource(Client, data));
        }

        /// <summary> Get Configuration records within a subscription and resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdates(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<MaintenanceApplyUpdateData, MaintenanceApplyUpdateResource>(
                new ApplyUpdateForResourceGroupGetAllCollectionResultOfT(ApplyUpdateForResourceGroupRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, context, "MockableMaintenanceResourceGroupResource.GetMaintenanceApplyUpdates"),
                data => new MaintenanceApplyUpdateResource(Client, data));
        }

        /// <summary> Apply maintenance updates to resource. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MaintenanceApplyUpdateResource>> CreateOrUpdateApplyUpdateAsync(string providerName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using DiagnosticScope scope = MaintenanceApplyUpdateClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.CreateOrUpdateApplyUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = MaintenanceApplyUpdateRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MaintenanceApplyUpdateData> response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenanceApplyUpdateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Apply maintenance updates to resource. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MaintenanceApplyUpdateResource> CreateOrUpdateApplyUpdate(string providerName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using DiagnosticScope scope = MaintenanceApplyUpdateClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.CreateOrUpdateApplyUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = MaintenanceApplyUpdateRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<MaintenanceApplyUpdateData> response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenanceApplyUpdateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Apply maintenance updates to resource with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MaintenanceApplyUpdateResource>> CreateOrUpdateApplyUpdateByParentAsync(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using DiagnosticScope scope = MaintenanceApplyUpdateClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.CreateOrUpdateApplyUpdateByParent");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = MaintenanceApplyUpdateRestClient.CreateCreateOrUpdateApplyUpdateByParentRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MaintenanceApplyUpdateData> response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenanceApplyUpdateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Apply maintenance updates to resource with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MaintenanceApplyUpdateResource> CreateOrUpdateApplyUpdateByParent(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using DiagnosticScope scope = MaintenanceApplyUpdateClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.CreateOrUpdateApplyUpdateByParent");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = MaintenanceApplyUpdateRestClient.CreateCreateOrUpdateApplyUpdateByParentRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<MaintenanceApplyUpdateData> response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenanceApplyUpdateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Track maintenance updates to resource. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="applyUpdateName"> The name of the ApplyUpdate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<MaintenanceApplyUpdateResource>> GetMaintenanceApplyUpdateAsync(string providerName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(applyUpdateName, nameof(applyUpdateName));

            using DiagnosticScope scope = MaintenanceApplyUpdateClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.GetMaintenanceApplyUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = MaintenanceApplyUpdateRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, applyUpdateName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MaintenanceApplyUpdateData> response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenanceApplyUpdateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Track maintenance updates to resource. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="applyUpdateName"> The name of the ApplyUpdate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdate(string providerName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(applyUpdateName, nameof(applyUpdateName));

            using DiagnosticScope scope = MaintenanceApplyUpdateClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.GetMaintenanceApplyUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = MaintenanceApplyUpdateRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, applyUpdateName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<MaintenanceApplyUpdateData> response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenanceApplyUpdateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Track maintenance updates to resource with parent. </summary>
        /// <param name="options"> The options for getting apply updates by parent. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MaintenanceApplyUpdateResource>> GetApplyUpdatesByParentAsync(ResourceGroupResourceGetApplyUpdatesByParentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return await GetApplyUpdatesByParentAsync(options.ProviderName, options.ResourceParentType, options.ResourceParentName, options.ResourceType, options.ResourceName, options.ApplyUpdateName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Track maintenance updates to resource with parent. </summary>
        /// <param name="options"> The options for getting apply updates by parent. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MaintenanceApplyUpdateResource> GetApplyUpdatesByParent(ResourceGroupResourceGetApplyUpdatesByParentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return GetApplyUpdatesByParent(options.ProviderName, options.ResourceParentType, options.ResourceParentName, options.ResourceType, options.ResourceName, options.ApplyUpdateName, cancellationToken);
        }

        /// <summary> Track maintenance updates to resource with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="applyUpdateName"> applyUpdate Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MaintenanceApplyUpdateResource>> GetApplyUpdatesByParentAsync(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(applyUpdateName, nameof(applyUpdateName));

            using DiagnosticScope scope = MaintenanceApplyUpdateClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.GetApplyUpdatesByParent");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = MaintenanceApplyUpdateRestClient.CreateGetApplyUpdatesByParentRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, applyUpdateName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MaintenanceApplyUpdateData> response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenanceApplyUpdateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Track maintenance updates to resource with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="applyUpdateName"> applyUpdate Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MaintenanceApplyUpdateResource> GetApplyUpdatesByParent(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(applyUpdateName, nameof(applyUpdateName));

            using DiagnosticScope scope = MaintenanceApplyUpdateClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.GetApplyUpdatesByParent");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = MaintenanceApplyUpdateRestClient.CreateGetApplyUpdatesByParentRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, applyUpdateName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<MaintenanceApplyUpdateData> response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenanceApplyUpdateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // ===== ConfigurationAssignment operations =====

        /// <summary> List configurationAssignments for resource. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Models.MaintenanceConfigurationAssignmentData> GetConfigurationAssignmentsAsync(string providerName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ModelsConfigurationAssignmentAsyncPageable(new ConfigurationAssignmentsGetAllAsyncCollectionResultOfT(ConfigurationAssignmentsRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, context, "MockableMaintenanceResourceGroupResource.GetConfigurationAssignments"));
        }

        /// <summary> List configurationAssignments for resource. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Models.MaintenanceConfigurationAssignmentData> GetConfigurationAssignments(string providerName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ModelsConfigurationAssignmentPageable(new ConfigurationAssignmentsGetAllCollectionResultOfT(ConfigurationAssignmentsRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, context, "MockableMaintenanceResourceGroupResource.GetConfigurationAssignments"));
        }

        /// <summary> List configurationAssignments for resource with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Models.MaintenanceConfigurationAssignmentData> GetConfigurationAssignmentsByParentAsync(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ModelsConfigurationAssignmentAsyncPageable(new ConfigurationAssignmentsGetConfigurationAssignmentsByParentAsyncCollectionResultOfT(ConfigurationAssignmentsRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, context, "MockableMaintenanceResourceGroupResource.GetConfigurationAssignmentsByParent"));
        }

        /// <summary> List configurationAssignments for resource with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Models.MaintenanceConfigurationAssignmentData> GetConfigurationAssignmentsByParent(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ModelsConfigurationAssignmentPageable(new ConfigurationAssignmentsGetConfigurationAssignmentsByParentCollectionResultOfT(ConfigurationAssignmentsRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, context, "MockableMaintenanceResourceGroupResource.GetConfigurationAssignmentsByParent"));
        }

        /// <summary> Register configuration for resource. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="configurationAssignmentName"> Configuration assignment name. </param>
        /// <param name="data"> The configurationAssignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Models.MaintenanceConfigurationAssignmentData>> CreateOrUpdateConfigurationAssignmentAsync(string providerName, string resourceType, string resourceName, string configurationAssignmentName, Models.MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = ConfigurationAssignmentsClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.CreateOrUpdateConfigurationAssignment");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = ConfigurationAssignmentsRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, configurationAssignmentName, MaintenanceConfigurationAssignmentData.ToRequestContent(data), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Models.MaintenanceConfigurationAssignmentData value = MaintenanceConfigurationAssignmentData.FromResponse(result);
                return Response.FromValue(value, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Register configuration for resource. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="configurationAssignmentName"> Configuration assignment name. </param>
        /// <param name="data"> The configurationAssignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Models.MaintenanceConfigurationAssignmentData> CreateOrUpdateConfigurationAssignment(string providerName, string resourceType, string resourceName, string configurationAssignmentName, Models.MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = ConfigurationAssignmentsClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.CreateOrUpdateConfigurationAssignment");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = ConfigurationAssignmentsRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, configurationAssignmentName, MaintenanceConfigurationAssignmentData.ToRequestContent(data), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Models.MaintenanceConfigurationAssignmentData value = MaintenanceConfigurationAssignmentData.FromResponse(result);
                return Response.FromValue(value, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Register configuration for resource with parent. </summary>
        /// <param name="options"> The options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Models.MaintenanceConfigurationAssignmentData>> CreateOrUpdateConfigurationAssignmentByParentAsync(ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return await CreateOrUpdateConfigurationAssignmentByParentAsync(options.ProviderName, options.ResourceParentType, options.ResourceParentName, options.ResourceType, options.ResourceName, options.ConfigurationAssignmentName, options.Data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Register configuration for resource with parent. </summary>
        /// <param name="options"> The options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Models.MaintenanceConfigurationAssignmentData> CreateOrUpdateConfigurationAssignmentByParent(ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return CreateOrUpdateConfigurationAssignmentByParent(options.ProviderName, options.ResourceParentType, options.ResourceParentName, options.ResourceType, options.ResourceName, options.ConfigurationAssignmentName, options.Data, cancellationToken);
        }

        /// <summary> Register configuration for resource with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="configurationAssignmentName"> Configuration assignment name. </param>
        /// <param name="data"> The configurationAssignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Models.MaintenanceConfigurationAssignmentData>> CreateOrUpdateConfigurationAssignmentByParentAsync(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, Models.MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = ConfigurationAssignmentsClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.CreateOrUpdateConfigurationAssignmentByParent");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = ConfigurationAssignmentsRestClient.CreateCreateOrUpdateConfigurationAssignmentByParentRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName, MaintenanceConfigurationAssignmentData.ToRequestContent(data), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue((Models.MaintenanceConfigurationAssignmentData)MaintenanceConfigurationAssignmentData.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Register configuration for resource with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="configurationAssignmentName"> Configuration assignment name. </param>
        /// <param name="data"> The configurationAssignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Models.MaintenanceConfigurationAssignmentData> CreateOrUpdateConfigurationAssignmentByParent(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, Models.MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = ConfigurationAssignmentsClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.CreateOrUpdateConfigurationAssignmentByParent");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = ConfigurationAssignmentsRestClient.CreateCreateOrUpdateConfigurationAssignmentByParentRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName, MaintenanceConfigurationAssignmentData.ToRequestContent(data), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Models.MaintenanceConfigurationAssignmentData value = MaintenanceConfigurationAssignmentData.FromResponse(result);
                return Response.FromValue(value, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Unregister configuration for resource. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="configurationAssignmentName"> Configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Models.MaintenanceConfigurationAssignmentData>> DeleteConfigurationAssignmentAsync(string providerName, string resourceType, string resourceName, string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));

            using DiagnosticScope scope = ConfigurationAssignmentsClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.DeleteConfigurationAssignment");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = ConfigurationAssignmentsRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, configurationAssignmentName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Models.MaintenanceConfigurationAssignmentData value = MaintenanceConfigurationAssignmentData.FromResponse(result);
                return Response.FromValue(value, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Unregister configuration for resource. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="configurationAssignmentName"> Configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Models.MaintenanceConfigurationAssignmentData> DeleteConfigurationAssignment(string providerName, string resourceType, string resourceName, string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));

            using DiagnosticScope scope = ConfigurationAssignmentsClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.DeleteConfigurationAssignment");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = ConfigurationAssignmentsRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, configurationAssignmentName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Models.MaintenanceConfigurationAssignmentData value = MaintenanceConfigurationAssignmentData.FromResponse(result);
                return Response.FromValue(value, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Unregister configuration for resource with parent. </summary>
        /// <param name="options"> The options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Models.MaintenanceConfigurationAssignmentData>> DeleteConfigurationAssignmentByParentAsync(ResourceGroupResourceDeleteConfigurationAssignmentByParentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return await DeleteConfigurationAssignmentByParentAsync(options.ProviderName, options.ResourceParentType, options.ResourceParentName, options.ResourceType, options.ResourceName, options.ConfigurationAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Unregister configuration for resource with parent. </summary>
        /// <param name="options"> The options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Models.MaintenanceConfigurationAssignmentData> DeleteConfigurationAssignmentByParent(ResourceGroupResourceDeleteConfigurationAssignmentByParentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return DeleteConfigurationAssignmentByParent(options.ProviderName, options.ResourceParentType, options.ResourceParentName, options.ResourceType, options.ResourceName, options.ConfigurationAssignmentName, cancellationToken);
        }

        /// <summary> Unregister configuration for resource with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="configurationAssignmentName"> Configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Models.MaintenanceConfigurationAssignmentData>> DeleteConfigurationAssignmentByParentAsync(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));

            using DiagnosticScope scope = ConfigurationAssignmentsClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.DeleteConfigurationAssignmentByParent");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = ConfigurationAssignmentsRestClient.CreateDeleteConfigurationAssignmentByParentRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Models.MaintenanceConfigurationAssignmentData value = MaintenanceConfigurationAssignmentData.FromResponse(result);
                return Response.FromValue(value, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Unregister configuration for resource with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="configurationAssignmentName"> Configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Models.MaintenanceConfigurationAssignmentData> DeleteConfigurationAssignmentByParent(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));

            using DiagnosticScope scope = ConfigurationAssignmentsClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.DeleteConfigurationAssignmentByParent");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = ConfigurationAssignmentsRestClient.CreateDeleteConfigurationAssignmentByParentRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Models.MaintenanceConfigurationAssignmentData value = MaintenanceConfigurationAssignmentData.FromResponse(result);
                return Response.FromValue(value, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // ===== Update operations =====

        /// <summary> Get updates to resources. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<MaintenanceUpdate> GetUpdatesAsync(string providerName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new UpdatesGetAllAsyncCollectionResultOfT(UpdatesRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, context, "MockableMaintenanceResourceGroupResource.GetUpdates");
        }

        /// <summary> Get updates to resources. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<MaintenanceUpdate> GetUpdates(string providerName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new UpdatesGetAllCollectionResultOfT(UpdatesRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, context, "MockableMaintenanceResourceGroupResource.GetUpdates");
        }

        /// <summary> Get updates to resources with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<MaintenanceUpdate> GetUpdatesByParentAsync(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new UpdatesGetUpdatesByParentAsyncCollectionResultOfT(UpdatesRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, context, "MockableMaintenanceResourceGroupResource.GetUpdatesByParent");
        }

        /// <summary> Get updates to resources with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<MaintenanceUpdate> GetUpdatesByParent(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new UpdatesGetUpdatesByParentCollectionResultOfT(UpdatesRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, context, "MockableMaintenanceResourceGroupResource.GetUpdatesByParent");
        }
    }
}
