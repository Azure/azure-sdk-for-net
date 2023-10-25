// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.DesktopVirtualization.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A Class representing a VirtualApplicationGroup along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="VirtualApplicationGroupResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetVirtualApplicationGroupResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetVirtualApplicationGroup method.
    /// </summary>
    public partial class VirtualApplicationGroupResource : ArmResource
    {
        /// <summary>
        /// List start menu items in the given application group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/startMenuItems</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StartMenuItems_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DesktopVirtualizationStartMenuItem" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DesktopVirtualizationStartMenuItem> GetStartMenuItemsAsync(CancellationToken cancellationToken) => GetStartMenuItemsAsync(cancellationToken);

        /// <summary>
        /// List start menu items in the given application group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/startMenuItems</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StartMenuItems_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DesktopVirtualizationStartMenuItem" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DesktopVirtualizationStartMenuItem> GetStartMenuItems(CancellationToken cancellationToken) => GetStartMenuItems(cancellationToken);
    }
}
