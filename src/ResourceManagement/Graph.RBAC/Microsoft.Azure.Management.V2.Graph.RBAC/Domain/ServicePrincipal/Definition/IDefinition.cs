/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.Graph.RBAC.ServicePrincipal.Definition
{

    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Graph.RBAC;
    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithCreate
    {
    }
    /// <summary>
    /// The first stage of the service principal definition.
    /// </summary>
    public interface IBlank  :
        IWithCreate
    {
    }
    /// <summary>
    /// The stage of service principal definition allowing specifying if the service principal account is enabled.
    /// </summary>
    public interface IWithAccountEnabled 
    {
        /// <summary>
        /// Specifies whether the service principal account is enabled upon creation.
        /// </summary>
        /// <param name="enabled">enabled if set to true, the service principal account is enabled.</param>
        /// <returns>the next stage in service principal definition</returns>
        IWithCreate WithAccountEnabled (bool enabled);

    }
    /// <summary>
    /// A service principal definition with sufficient inputs to create a new
    /// service principal in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<IServicePrincipal>,
        IWithAccountEnabled
    {
    }
}