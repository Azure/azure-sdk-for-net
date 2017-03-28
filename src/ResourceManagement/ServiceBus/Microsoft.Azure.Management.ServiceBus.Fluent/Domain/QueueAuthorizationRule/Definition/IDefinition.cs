// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent.QueueAuthorizationRule.Definition
{
    using Microsoft.Azure.Management.Servicebus.Fluent.AuthorizationRule.Definition;
    using Microsoft.Azure.Management.Servicebus.Fluent;
    using ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The entirety of the queue authorization rule definition.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithCreate
    {
    }

    /// <summary>
    /// The first stage of queue authorization rule definition.
    /// </summary>
    public interface IBlank  :
        IWithListenOrSendOrManage<Microsoft.Azure.Management.Servicebus.Fluent.QueueAuthorizationRule.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Servicebus.Fluent.IQueueAuthorizationRule>
    {
    }
}