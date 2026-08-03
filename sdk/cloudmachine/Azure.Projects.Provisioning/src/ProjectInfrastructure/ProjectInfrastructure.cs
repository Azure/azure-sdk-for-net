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

/// <summary>
/// Represents the provisioning infrastructure for an Azure project, managing features, constructs, and connections.
/// </summary>
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

    /// <summary>
    /// Gets the user-assigned managed identity for this project.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public UserAssignedIdentity Identity { get; private set; }

    /// <summary>
    /// The common principalId parameter.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProvisioningParameter PrincipalIdParameter => new("principalId", typeof(string));

    /// <summary>
    /// Gets the collection of features registered with this infrastructure.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FeatureCollection Features => _features;

    /// <summary>
    /// Gets the connection store used to persist feature connection information.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ConnectionStore Connections => _connectionStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectInfrastructure"/> class with a specified connection store.
    /// </summary>
    /// <param name="connections">The connection store to use for persisting connection information.</param>
    /// <param name="projectId">The project identifier. If <see langword="null"/>, the Id is read from or created in the project configuration.</param>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectInfrastructure"/> class using a default <see cref="AppConfigConnectionStore"/>.
    /// </summary>
    /// <param name="projectId">The project identifier. If <see langword="null"/>, the Id is read from or created in the project configuration.</param>
    public ProjectInfrastructure(string? projectId = default)
        : this(new AppConfigConnectionStore(), projectId)
    { }

    /// <summary>
    /// Adds a feature to this infrastructure and emits its prerequisite features.
    /// </summary>
    /// <typeparam name="T">The type of feature to add.</typeparam>
    /// <param name="feature">The feature to add.</param>
    /// <returns>The added feature.</returns>
    public T AddFeature<T>(T feature) where T : AzureProjectFeature
    {
        feature.EmitFeatures(this);
        return feature;
    }

    /// <summary>
    /// Registers a named provisioning construct with this infrastructure.
    /// </summary>
    /// <param name="id">The identifier for the construct.</param>
    /// <param name="construct">The provisioning construct to register.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AddConstruct(string id, NamedProvisionableConstruct construct)
    {
        _constrcuts.Add(id, construct);
    }

    /// <summary>
    /// Retrieves a previously registered provisioning construct by its identifier.
    /// </summary>
    /// <typeparam name="T">The expected type of the construct.</typeparam>
    /// <param name="id">The identifier of the construct to retrieve.</param>
    /// <returns>The construct cast to <typeparamref name="T"/>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public T GetConstruct<T>(string id) where T : NamedProvisionableConstruct
    {
        if (_constrcuts.TryGetValue(id, out NamedProvisionableConstruct? construct))
        {
            return (T)construct;
        }
        throw new InvalidOperationException($"Construct of type {typeof(T).FullName} not found.");
    }

    /// <summary>
    /// Adds a required role assignment for the project identity on the specified provisionable resource.
    /// </summary>
    /// <param name="provisionable">The resource to assign the role on.</param>
    /// <param name="roleName">The display name of the role.</param>
    /// <param name="roleId">The identifier of the role definition.</param>
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

    /// <summary>
    /// Builds the provisioning plan by emitting all registered features and constructs.
    /// </summary>
    /// <param name="context">Optional build options for the provisioning plan.</param>
    /// <returns>The compiled <see cref="ProvisioningPlan"/>.</returns>
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
