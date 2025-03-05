// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.Projects.AppConfiguration;
using Azure.Projects.Core;
using Azure.Provisioning;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Roles;

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

        AppConfigurationFeature appConfig = new();
        this.AddFeature(appConfig);
    }

    public T AddFeature<T>(T feature) where T: AzureProjectFeature
    {
        feature.EmitImplicitFeatures(Features, ProjectId);
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

    private int _index = 0;
    internal string CreateUniqueBicepIdentifier(string baseIdentifier)
    {
        int index = Interlocked.Increment(ref _index);
        return baseIdentifier + "_" + index;
    }
}
