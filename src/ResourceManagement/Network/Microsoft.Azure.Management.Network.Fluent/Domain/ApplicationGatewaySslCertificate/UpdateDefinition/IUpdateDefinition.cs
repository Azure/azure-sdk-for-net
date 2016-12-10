// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The entirety of an application gateway SSL certificate definition as part of an application gateway update.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching.</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of an application gateway SSL certificate definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching.</typeparam>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>
    {
    }

    /// <summary>
    /// The first stage of an application gateway authentication certificate definition.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching.</typeparam>
    public interface IBlank<ParentT>  :
        IWithAttach<ParentT>
    {
    }
}