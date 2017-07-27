// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NetworkWatcher.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Container interface for all the definitions.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.NetworkWatcher.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.NetworkWatcher.Definition.IWithGroup,
        Microsoft.Azure.Management.Network.Fluent.NetworkWatcher.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the network watcher definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.NetworkWatcher.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// A network watcher with sufficient inputs to create a new network watcher in the cloud,
    /// but exposing additional optional inputs to specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.NetworkWatcher.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The first stage of a network watcher definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.NetworkWatcher.Definition.IWithGroup>
    {
    }
}