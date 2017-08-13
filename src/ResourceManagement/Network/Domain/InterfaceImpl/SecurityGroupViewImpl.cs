// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class SecurityGroupViewImpl 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken) as Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView;
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkWatcher Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>.Parent
        {
            get
            {
                return this.Parent() as Microsoft.Azure.Management.Network.Fluent.INetworkWatcher;
            }
        }

        /// <summary>
        /// Gets virtual machine id.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView.VMId
        {
            get
            {
                return this.VMId();
            }
        }

        /// <summary>
        /// Gets network interfaces on the specified VM.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.SecurityGroupNetworkInterface> Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView.NetworkInterfaces
        {
            get
            {
                return this.NetworkInterfaces() as System.Collections.Generic.IReadOnlyDictionary<string,Models.SecurityGroupNetworkInterface>;
            }
        }
    }
}