// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Projects.Core;
using Azure.Projects.EventGrid;
using Azure.Projects.ServiceBus;
using Azure.Projects.Storage;
using Azure.Provisioning;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Roles;
using System.ClientModel.Primitives;

namespace Azure.Projects;

public partial class ProjectInfrastructure
{
    private readonly Infrastructure _infrastructure = new("project");
    private readonly List<NamedProvisionableConstruct> _constrcuts = [];

    /// <summary>
    /// This is the resource group name for the project resources.
    /// </summary>
    public string ProjectId { get; private set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public UserAssignedIdentity Identity { get; private set; }

    /// <summary>
    /// The common principalId parameter.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProvisioningParameter PrincipalIdParameter => new("principalId", typeof(string));

    public FeatureCollection Features { get; } = new();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ConnectionCollection Connections { get; } = [];

    public ProjectClient GetClient()
    {
        ProjectClient client = new(Connections);
        return client;
    }

    public ProjectInfrastructure(string? projectId = default)
    {
        ProjectId = projectId ?? ProjectClient.ReadOrCreateProjectId();

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

        // setup project identity
        Identity = new UserAssignedIdentity("project_identity")
        {
            Name = ProjectId
        };
        _infrastructure.Add(Identity);
        _infrastructure.Add(new ProvisioningOutput("project_identity_id", typeof(string)) { Value = Identity.Id });
    }

    public T AddFeature<T>(T feature) where T: AzureProjectFeature
    {
        feature.EmitFeatures(Features, ProjectId);
        feature.EmitConnections(Connections, ProjectId);
        return feature;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AddResource(NamedProvisionableConstruct resource)
    {
        _constrcuts.Add(resource);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProvisioningPlan Build(ProvisioningBuildOptions? context = default)
    {
        context ??= new ProvisioningBuildOptions();

        Features.Emit(this);

        // Add any add-on resources to the infrastructure.
        foreach (Provisionable resource in _constrcuts)
        {
            _infrastructure.Add(resource);
        }

        // This must occur after the features have been emitted.
        context.InfrastructureResolvers.Add(new RoleResolver(ProjectId, Features.RoleAnnotations, [Identity], [PrincipalIdParameter]));

        return _infrastructure.Build(context);
    }
}

public static class OfxExtensions
{
    public static void AddOfx(this ProjectInfrastructure infra)
    {
        infra.AddBlobsContainer();
        infra.AddServiceBus();
    }

    public static void AddBlobsContainer(this ProjectInfrastructure infra, string? containerName = default, bool enableEvents = true)
    {
        var storage = infra.AddStorageAccount();
        var blobs = infra.AddFeature(new BlobServiceFeature(storage));
        var defaultContainer = infra.AddFeature(new BlobContainerFeature(blobs));

        if (enableEvents)
        {
            var sb = infra.AddServiceBusNamespace();
            var sbTopicPrivate = infra.AddFeature(new ServiceBusTopicFeature("cm_servicebus_topic_private", sb));
            var systemTopic = infra.AddFeature(new EventGridSystemTopicFeature(infra.ProjectId, storage, "Microsoft.Storage.StorageAccounts"));
            infra.AddFeature(new SystemTopicEventSubscriptionFeature("cm-eventgrid-subscription-blob", systemTopic, sbTopicPrivate, sb));
            infra.AddFeature(new ServiceBusSubscriptionFeature("cm_servicebus_subscription_private", sbTopicPrivate)); // TODO: should private connections not be in the Connections collection?
        }
    }

    private static ServiceBusNamespaceFeature AddServiceBusNamespace(this ProjectInfrastructure infra)
    {
        if (!infra.Features.TryGet(out ServiceBusNamespaceFeature? serviceBusNamespace))
        {
            serviceBusNamespace = infra.AddFeature(new ServiceBusNamespaceFeature(infra.ProjectId));
        }
        return serviceBusNamespace!;
    }

    private static StorageAccountFeature AddStorageAccount(this ProjectInfrastructure infra)
    {
        if (!infra.Features.TryGet(out StorageAccountFeature? storageAccount))
        {
            storageAccount = infra.AddFeature(new StorageAccountFeature(infra.ProjectId));
        }
        return storageAccount!;
    }

    private static void AddServiceBus(this ProjectInfrastructure infra)
    {
        var sb = infra.AddServiceBusNamespace();
        // Add core features
        var sbTopicDefault = infra.AddFeature(new ServiceBusTopicFeature("cm_servicebus_default_topic", sb));
        infra.AddFeature(new ServiceBusSubscriptionFeature("cm_servicebus_subscription_default", sbTopicDefault));
    }
}
