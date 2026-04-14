// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Maintenance
{
    // Backward-compatibility: the old Swagger-based SDK (1.1.3) had MaintenancePublicConfigurationResource
    // as a separate resource type for subscription-level read-only access to public maintenance configurations.
    // The TypeSpec generator produces only an empty shell (ValidateResourceId + interface declarations).
    // This custom code provides the full implementation: constructors, ResourceType, HasData/Data properties,
    // Get/CreateResourceIdentifier methods, and DataDeserializationInstance for serialization.
    public partial class MaintenancePublicConfigurationResource : ArmResource
    {
        private readonly ClientDiagnostics _publicMaintenanceConfigurationsClientDiagnostics;
        private readonly PublicMaintenanceConfigurations _publicMaintenanceConfigurationsRestClient;
        private readonly MaintenanceConfigurationData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Maintenance/publicMaintenanceConfigurations";

        /// <summary> Initializes a new instance of MaintenancePublicConfigurationResource for mocking. </summary>
        protected MaintenancePublicConfigurationResource()
        {
        }

        internal MaintenancePublicConfigurationResource(ArmClient client, MaintenanceConfigurationData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        internal MaintenancePublicConfigurationResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _publicMaintenanceConfigurationsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Maintenance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _publicMaintenanceConfigurationsRestClient = new PublicMaintenanceConfigurations(_publicMaintenanceConfigurationsClientDiagnostics, Pipeline, Endpoint, "2023-10-01-preview");
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        public virtual MaintenanceConfigurationData Data
        {
            get
            {
                if (!HasData)
                {
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                }
                return _data;
            }
        }

        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceName"> The resourceName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/{resourceName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Gets the public maintenance configuration. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MaintenancePublicConfigurationResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _publicMaintenanceConfigurationsClientDiagnostics.CreateScope("MaintenancePublicConfigurationResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _publicMaintenanceConfigurationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MaintenanceConfigurationData> response = Response.FromValue(MaintenanceConfigurationData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenancePublicConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the public maintenance configuration. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MaintenancePublicConfigurationResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _publicMaintenanceConfigurationsClientDiagnostics.CreateScope("MaintenancePublicConfigurationResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _publicMaintenanceConfigurationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<MaintenanceConfigurationData> response = Response.FromValue(MaintenanceConfigurationData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenancePublicConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static IJsonModel<MaintenanceConfigurationData> s_dataDeserializationInstance;

        private static IJsonModel<MaintenanceConfigurationData> DataDeserializationInstance => s_dataDeserializationInstance ??= new MaintenanceConfigurationData();
    }
}
