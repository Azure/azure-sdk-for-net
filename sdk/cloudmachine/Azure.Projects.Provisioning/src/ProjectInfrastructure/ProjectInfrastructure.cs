// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Azure.Projects.Core;
using Azure.Provisioning;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Roles;

namespace Azure.Projects;

[DebuggerTypeProxy(typeof(ProjectInfrastructureDebugView))]
public partial class ProjectInfrastructure
{
    private readonly Infrastructure _infrastructure = new("project");
    private readonly Dictionary<string, NamedProvisionableConstruct> _constrcuts = [];
    private readonly Dictionary<Provisionable, List<FeatureRole>> _requiredSystemRoles = new();
    private readonly FeatureCollection _features = new();
    private readonly ConnectionStore _connectionStore;

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

    [EditorBrowsable(EditorBrowsableState.Never)]
    public FeatureCollection Features => _features;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ConnectionStore Connections => _connectionStore;

    public ProjectInfrastructure(ConnectionStore connections, string? projectId = default)
    {
        ProjectId = projectId ?? ProjectClient.ReadOrCreateProjectId();
        _connectionStore = connections;

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
        Identity = new UserAssignedIdentity("projectIdentity", UserAssignedIdentity.ResourceVersions.V2023_01_31)
        {
            Name = ProjectId
        };
        _infrastructure.Add(Identity);
        _infrastructure.Add(new ProvisioningOutput("project_identity_id", typeof(string)) { Value = Identity.Id });

        if (_connectionStore.TryGetFeature(out AzureProjectFeature? feature))
        {
            AddFeature(feature!);
        }
    }

    public ProjectInfrastructure(string? projectId = default)
        : this(new AppConfigConnectionStore(), projectId)
    {}

    public T AddFeature<T>(T feature) where T: AzureProjectFeature
    {
        feature.EmitFeatures(this);
        return feature;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AddConstruct(string id, NamedProvisionableConstruct construct)
    {
        _constrcuts.Add(id, construct);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public T GetConstruct<T>(string id) where T : NamedProvisionableConstruct
    {
        if (_constrcuts.TryGetValue(id, out NamedProvisionableConstruct? construct))
        {
            return (T)construct;
        }
        throw new InvalidOperationException($"Construct of type {typeof(T).FullName} not found.");
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AddSystemRole(Provisionable provisionable, string roleName, string roleId)
    {
        FeatureRole role = new(roleName, roleId);

        if (!_requiredSystemRoles.TryGetValue(provisionable, out List<FeatureRole>? roles))
        {
            _requiredSystemRoles.Add(provisionable, [role]);
        }
        else
        {
            roles.Add(role);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProvisioningPlan Build(ProvisioningBuildOptions? context = default)
    {
        // emit features
        foreach (AzureProjectFeature feature in Features)
        {
            feature.EmitConstructs(this);
        }

        // add constructs to infrastructure
        foreach (NamedProvisionableConstruct construct in _constrcuts.Values)
        {
            _infrastructure.Add(construct);
        }

        // This must occur after the features have been emitted.
        context ??= new ProvisioningBuildOptions();
        context.InfrastructureResolvers.Add(new RoleResolver(ProjectId, _requiredSystemRoles, [Identity], [PrincipalIdParameter]));

        return _infrastructure.Build(context);
    }

    private class ProjectInfrastructureDebugView
    {
        private readonly ProjectInfrastructure _projectInfrastructure;

        public ProjectInfrastructureDebugView(ProjectInfrastructure projectInfrastructure)
        {
            _projectInfrastructure = projectInfrastructure;
        }

        public AzureProjectFeature[] Features => _projectInfrastructure.Features.ToArray();

        //[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public Dictionary<string, NamedProvisionableConstruct> Constructs => _projectInfrastructure._constrcuts;

        public string ProjectId => _projectInfrastructure.ProjectId;
    }
}
