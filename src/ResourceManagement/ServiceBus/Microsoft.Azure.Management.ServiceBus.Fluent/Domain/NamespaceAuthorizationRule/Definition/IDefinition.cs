// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent.NamespaceAuthorizationRule.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Servicebus.Fluent;
    using Microsoft.Azure.Management.Servicebus.Fluent.AuthorizationRule.Definition;

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRule>
    {
    }

    /// <summary>
    /// The first stage of namespace authorization rule definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Servicebus.Fluent.AuthorizationRule.Definition.IWithListenOrSendOrManage<Microsoft.Azure.Management.Servicebus.Fluent.NamespaceAuthorizationRule.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The entirety of the namespace authorization rule definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Servicebus.Fluent.NamespaceAuthorizationRule.Definition.IBlank,
        Microsoft.Azure.Management.Servicebus.Fluent.NamespaceAuthorizationRule.Definition.IWithCreate
    {
    }
}