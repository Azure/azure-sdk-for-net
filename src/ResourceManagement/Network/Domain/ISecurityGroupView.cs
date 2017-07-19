// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// The information about security rules applied to the specified VM..
    /// </summary>
    public interface ISecurityGroupView  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SecurityGroupViewResultInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView>
    {
        /// <summary>
        /// Gets network interfaces on the specified VM.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.SecurityGroupNetworkInterface> NetworkInterfaces { get; }

        /// <summary>
        /// Gets virtual machine id.
        /// </summary>
        string VMId { get; }
    }
}