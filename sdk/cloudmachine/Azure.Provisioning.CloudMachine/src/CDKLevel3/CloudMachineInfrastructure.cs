// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Roles;

namespace Azure.CloudMachine;

public class CloudMachineInfrastructure
{
    internal const string SB_PRIVATE_TOPIC = "cm_servicebus_topic_private";
    internal const string SB_PRIVATE_SUB = "cm_servicebus_subscription_private";

    private readonly List<ClientConnectionOptions> _connections = [];
    private readonly Infrastructure _infrastructure = new("cm");
    private readonly List<Provisionable> _resources = [];
    internal List<Type> Endpoints { get; } = [];

    public FeatureCollection Features { get; } = new();
    public UserAssignedIdentity Identity { get; private set; }
    public string Id { get; private set; }

    /// <summary>
    /// The common principalId parameter.
    /// </summary>
    public ProvisioningParameter PrincipalIdParameter => new("principalId", typeof(string));

    ///// <summary>
    ///// The common principalType parameter.
    ///// </summary>
    //public ProvisioningParameter PrincipalTypeParameter => new BicepParameter("principalType", typeof(string));

    ///// <summary>
    ///// The common principalName parameter.
    ///// </summary>
    //public ProvisioningParameter PrincipalNameParameter => new BicepParameter("principalName", typeof(string));

    public CloudMachineInfrastructure(string? cmId = default)
    {
        if (cmId == default)
        {
            cmId = AppConfigHelpers.ReadOrCreateCmid();
        }
        Id = cmId;

        // setup CM identity
        Identity = new UserAssignedIdentity("cm_identity");
        Identity.Name = Id;
        _infrastructure.Add(new ProvisioningOutput("cm_managed_identity_id", typeof(string)) { Value = Identity.Id });

        // Add core features
        var storage = new StorageFeature(Id);
        Features.Add(storage);
        var sbNamespace = new ServiceBusNamespaceFeature(Id);
        Features.Add(sbNamespace);
        var sbTopicPrivate = new ServiceBusTopicFeature("cm_servicebus_topic_private", sbNamespace);
        Features.Add(sbTopicPrivate);
        var sbTopicDefault = new ServiceBusTopicFeature("cm_servicebus_default_topic", sbNamespace);
        Features.Add(sbTopicDefault);
        Features.Add(new ServiceBusSubscriptionFeature("cm_servicebus_subscription_private", sbTopicPrivate));
        Features.Add(new ServiceBusSubscriptionFeature("cm_servicebus_subscription_default", sbTopicDefault));
        var systemTopic = new EventGridSystemTopicFeature(Id, storage);
        Features.Add(systemTopic);
        Features.Add(new SystemTopicEventSubscriptionFeature("cm_eventgrid_subscription_blob", systemTopic, sbTopicPrivate, sbNamespace));
    }

    public void AddResource(NamedProvisionableConstruct resource)
    {
        _resources.Add(resource);
    }
    public void AddFeature(CloudMachineFeature feature)
    {
        feature.AddTo(this);
    }

    public void AddEndpoints<T>()
    {
        Type endpointsType = typeof(T);
        if (!endpointsType.IsInterface)
            throw new InvalidOperationException("Endpoints type must be an interface.");
        Endpoints.Add(endpointsType);
    }

    public ProvisioningPlan Build(ProvisioningBuildOptions? context = default)
    {
        context ??= new ProvisioningBuildOptions();

        Features.Emit(this);

        // This must occur after the features have been emitted.
        context.InfrastructureResolvers.Add(new RoleResolver(Features.RoleAnnotations, [Identity], [PrincipalIdParameter]));

        // Always add a default location parameter.
        // azd assumes there will be a location parameter for every module.
        // The Infrastructure location resolver will resolve unset Location properties to this parameter.
        _infrastructure.Add(new ProvisioningParameter("location", typeof(string))
        {
            Description = "The location for the resource(s) to be deployed.",
            Value = BicepFunction.GetResourceGroup().Location
        });

        _infrastructure.Add(new ProvisioningParameter("principalId", typeof(string))
        {
            Description = "The objectId of the current user principal.",
        });

        _infrastructure.Add(Identity);

        // Add any add-on resources to the infrastructure.
        foreach (Provisionable resource in _resources)
        {
            _infrastructure.Add(resource);
        }

        return _infrastructure.Build(context);
    }

    internal class RoleResolver(Dictionary<Provisionable, (string RoleName, string RoleId)[]> annotations, IEnumerable<UserAssignedIdentity> managedIdentities, IEnumerable<BicepValue<Guid>> userPrincipals) : InfrastructureResolver
    {
        public override IEnumerable<Provisionable> ResolveResources(IEnumerable<Provisionable> resources, ProvisioningBuildOptions options)
        {
            foreach (Provisionable provisionable in base.ResolveResources(resources, options))
            {
                yield return provisionable;
                if (annotations.TryGetValue(provisionable, out (string RoleName, string RoleId)[]? roles) && provisionable is ProvisionableResource resource && roles is not null)
                {
                    foreach ((string RoleName, string RoleId) in roles)
                    {
                        foreach (BicepValue<Guid> userPrincipal in userPrincipals)
                        {
                            yield return new RoleAssignment($"{resource.BicepIdentifier}_{userPrincipal.Value.ToString().Replace('-', '_')}_{RoleName}")
                            {
                                Name = BicepFunction.CreateGuid(resource.BicepIdentifier, userPrincipal, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", RoleId)),
                                Scope = new IdentifierExpression(resource.BicepIdentifier),
                                PrincipalType = RoleManagementPrincipalType.User,
                                RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", RoleId),
                                PrincipalId = userPrincipal
                            };
                        }

                        foreach (UserAssignedIdentity identity in managedIdentities)
                        {
                            yield return new RoleAssignment($"{resource.BicepIdentifier}_{identity.BicepIdentifier}_{RoleName}")
                            {
                                Name = BicepFunction.CreateGuid(resource.BicepIdentifier, identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", RoleId)),
                                Scope = new IdentifierExpression(resource.BicepIdentifier),
                                PrincipalType = RoleManagementPrincipalType.ServicePrincipal,
                                RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", RoleId),
                                PrincipalId = identity.PrincipalId
                            };
                        }
                    }
                }
            }
        }
    }
}
