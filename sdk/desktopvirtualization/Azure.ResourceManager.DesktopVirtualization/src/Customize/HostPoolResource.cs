// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DesktopVirtualization.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A Class representing a HostPool along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="HostPoolResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetHostPoolResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetHostPool method.
    /// </summary>
    public partial class HostPoolResource : ArmResource
    {
        /// <summary>
        /// List scaling plan associated with hostpool.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/scalingPlans</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScalingPlans_ListByHostPool</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ScalingPlanResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ScalingPlanResource> GetScalingPlansAsync(CancellationToken cancellationToken) => GetScalingPlansAsync(null, null, null, cancellationToken);

        /// <summary>
        /// List scaling plan associated with hostpool.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/scalingPlans</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScalingPlans_ListByHostPool</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ScalingPlanResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ScalingPlanResource> GetScalingPlans(CancellationToken cancellationToken) => GetScalingPlans(null, null, null, cancellationToken);

        /// <summary>
        /// List userSessions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/userSessions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UserSessions_ListByHostPool</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> OData filter expression. Valid properties for filtering are userprincipalname and sessionstate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="UserSessionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<UserSessionResource> GetUserSessionsAsync(string filter, CancellationToken cancellationToken) => GetUserSessionsAsync(filter, null, null, null, cancellationToken);

        /// <summary>
        /// List userSessions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/userSessions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UserSessions_ListByHostPool</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> OData filter expression. Valid properties for filtering are userprincipalname and sessionstate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="UserSessionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<UserSessionResource> GetUserSessions(string filter, CancellationToken cancellationToken) => GetUserSessions(filter, null, null, null, cancellationToken);

        /// <summary> Gets information from a package given the path to the package. </summary>
        /// <param name="body"> Information to import app attach package. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AppAttachPackageResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<AppAttachPackageResource> ImportAppAttachPackageInfosAsync(ImportPackageInfoContent body, CancellationToken cancellationToken = default)
            => ImportAsync(new ImportParameterBody(body), cancellationToken);

        /// <summary> Gets information from a package given the path to the package. </summary>
        /// <param name="body"> Information to import app attach package. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AppAttachPackageResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<AppAttachPackageResource> ImportAppAttachPackageInfos(ImportPackageInfoContent body, CancellationToken cancellationToken = default)
            => Import(new ImportParameterBody(body), cancellationToken);

        /// <summary> Expands and Lists MSIX packages in an Image, given the Image Path. </summary>
        /// <param name="msixImageUri"> URI to Image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ExpandMsixImage" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ExpandMsixImage> ExpandMsixImagesAsync(MsixImageUri msixImageUri, CancellationToken cancellationToken = default)
            => ExpandAsync(new ExpandParameterBody(msixImageUri, null), cancellationToken);

        /// <summary> Expands and Lists MSIX packages in an Image, given the Image Path. </summary>
        /// <param name="msixImageUri"> URI to Image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ExpandMsixImage" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ExpandMsixImage> ExpandMsixImages(MsixImageUri msixImageUri, CancellationToken cancellationToken = default)
            => Expand(new ExpandParameterBody(msixImageUri, null), cancellationToken);

        /// <summary> List the private link resources available for this hostpool. </summary>
        /// <param name="pageSize"> Number of items per page. </param>
        /// <param name="isDescending"> Indicates whether the collection is descending. </param>
        /// <param name="initialSkip"> Initial number of items to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DesktopVirtualizationPrivateLinkResourceData" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DesktopVirtualizationPrivateLinkResourceData> GetPrivateLinkResourcesAsync(int? pageSize = default, bool? isDescending = default, int? initialSkip = default, CancellationToken cancellationToken = default)
            => GetByHostPoolAsync(pageSize, isDescending, initialSkip, cancellationToken);

        /// <summary> List the private link resources available for this hostpool. </summary>
        /// <param name="pageSize"> Number of items per page. </param>
        /// <param name="isDescending"> Indicates whether the collection is descending. </param>
        /// <param name="initialSkip"> Initial number of items to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DesktopVirtualizationPrivateLinkResourceData" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DesktopVirtualizationPrivateLinkResourceData> GetPrivateLinkResources(int? pageSize = default, bool? isDescending = default, int? initialSkip = default, CancellationToken cancellationToken = default)
            => GetByHostPool(pageSize, isDescending, initialSkip, cancellationToken);
    }
}
