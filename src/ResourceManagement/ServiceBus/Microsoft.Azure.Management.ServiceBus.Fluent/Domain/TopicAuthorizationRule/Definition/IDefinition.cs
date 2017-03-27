// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent.TopicAuthorizationRule.Definition
{
    using Microsoft.Azure.Management.Servicebus.Fluent;
    using Microsoft.Azure.Management.Servicebus.Fluent.AuthorizationRule.Definition;
    using ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Servicebus.Fluent.ITopicAuthorizationRule>
    {
    }

    /// <summary>
    /// The first stage of topic authorization rule definition.
    /// </summary>
    public interface IBlank  :
        IWithListenOrSendOrManage<Microsoft.Azure.Management.Servicebus.Fluent.TopicAuthorizationRule.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The entirety of the topic authorization rule definition.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithCreate
    {
    }
}