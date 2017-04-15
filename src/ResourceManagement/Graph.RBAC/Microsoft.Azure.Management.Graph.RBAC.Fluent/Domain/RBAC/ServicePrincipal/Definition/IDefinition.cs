// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of service principal definition allowing specifying if the service principal account is enabled.
    /// </summary>
    public interface IWithAccountEnabled 
    {
        /// <summary>
        /// Specifies whether the service principal account is enabled upon creation.
        /// </summary>
        /// <param name="enabled">If set to true, the service principal account is enabled.</param>
        /// <return>The next stage in service principal definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate WithAccountEnabled(bool enabled);
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IBlank,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate
    {
    }

    /// <summary>
    /// A service principal definition with sufficient inputs to create a new
    /// service principal in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithAccountEnabled
    {
    }

    /// <summary>
    /// The first stage of the service principal definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate
    {
    }
}