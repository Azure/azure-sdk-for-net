// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.CloudMachine.Core;
using Azure.CloudMachine.EventGrid;
using Azure.CloudMachine.ServiceBus;
using Azure.CloudMachine.Storage;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Roles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.CloudMachine;

public class CloudMachineInfrastructure
{
    private readonly Infrastructure _infrastructure = new("cm");
    private readonly List<NamedProvisionableConstruct> _constrcuts = [];

    internal List<Type> Endpoints { get; } = [];
    public FeatureCollection Features { get; } = new();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ConnectionCollection Connections { get; } = [];

    [EditorBrowsable(EditorBrowsableState.Never)]
    public UserAssignedIdentity Identity { get; private set; }
    public string Id { get; private set; }

    public CloudMachineClient GetClient()
    {
        CloudMachineClient client = new(connections: Connections);
        return client;
    }

    /// <summary>
    /// The common principalId parameter.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProvisioningParameter PrincipalIdParameter => new("principalId", typeof(string));

    public CloudMachineInfrastructure(string? cmId = default)
    {
        if (cmId == default)
        {
            cmId = CloudMachineClient.ReadOrCreateCloudMachineId();
        }
        Id = cmId;

        // setup CM identity
        Identity = new UserAssignedIdentity("cm_identity");
        Identity.Name = Id;
        _infrastructure.Add(new ProvisioningOutput("cm_managed_identity_id", typeof(string)) { Value = Identity.Id });

        // Add core features
        var storage = AddFeature(new StorageAccountFeature(Id));
        var blobs = AddFeature(new BlobServiceFeature(storage));
        var defaultContainer = AddFeature(new BlobContainerFeature(blobs));
        var sbNamespace = AddFeature(new ServiceBusNamespaceFeature(Id));
        var sbTopicPrivate = AddFeature(new ServiceBusTopicFeature("cm_servicebus_topic_private", sbNamespace));
        var sbTopicDefault = AddFeature(new ServiceBusTopicFeature("cm_servicebus_default_topic", sbNamespace));
        AddFeature(new ServiceBusSubscriptionFeature("cm_servicebus_subscription_private", sbTopicPrivate)); // TODO: should private connections not be in the Connections collection?
        AddFeature(new ServiceBusSubscriptionFeature("cm_servicebus_subscription_default", sbTopicDefault));
        var systemTopic = AddFeature(new EventGridSystemTopicFeature(Id, storage, "Microsoft.Storage.StorageAccounts"));
        AddFeature(new SystemTopicEventSubscriptionFeature("cm-eventgrid-subscription-blob", systemTopic, sbTopicPrivate, sbNamespace));
    }

    public T AddFeature<T>(T feature) where T: CloudMachineFeature
    {
        feature.EmitFeatures(Features, Id);
        feature.EmitConnections(Connections, Id);
        return feature;
    }

    public void AddEndpoints<T>()
    {
        Type endpointsType = typeof(T);
        if (!endpointsType.IsInterface)
            throw new InvalidOperationException("Endpoints type must be an interface.");
        Endpoints.Add(endpointsType);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AddResource(NamedProvisionableConstruct resource)
    {
        _constrcuts.Add(resource);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProvisioningPlan Build(ProvisioningBuildOptions? context = default)
    {
        Features.Emit(this);

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
        foreach (Provisionable resource in _constrcuts)
        {
            _infrastructure.Add(resource);
        }

        context ??= new ProvisioningBuildOptions();
        // This must occur after the features have been emitted.
        context.InfrastructureResolvers.Add(new RoleResolver(Id, Features.RoleAnnotations, [Identity], [PrincipalIdParameter]));
        return _infrastructure.Build(context);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => Id;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => base.Equals(obj);
}

public static class CloudMachineInfrastructureConfiguration
{
    /// <summary>
    /// Adds a connections and CM ID to the config system.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="cm"></param>
    /// <returns></returns>
    public static IConfigurationBuilder AddCloudMachineConfiguration(this IConfigurationBuilder builder, CloudMachineInfrastructure cm)
    {
        builder.AddCloudMachineConnections(cm.Connections);
        builder.AddCloudMachineId(cm.Id);
        return builder;
    }

    /// <summary>
    /// Adds the CloudMachine to DI.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="cm"></param>
    /// <returns></returns>
    public static IHostApplicationBuilder AddCloudMachine(this IHostApplicationBuilder builder, CloudMachineInfrastructure cm)
    {
        builder.Services.AddSingleton(new CloudMachineClient(cm.Connections));
        return builder;
    }
}
