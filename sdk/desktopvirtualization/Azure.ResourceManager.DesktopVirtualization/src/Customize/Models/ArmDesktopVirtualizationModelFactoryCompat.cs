// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    public static partial class ArmDesktopVirtualizationModelFactory
    {
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="resourceType"></param>
        /// <param name="systemData"></param>
        /// <param name="privateEndpointId"></param>
        /// <param name="connectionState"></param>
        /// <param name="provisioningState"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DesktopVirtualizationPrivateEndpointConnection DesktopVirtualizationPrivateEndpointConnection(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ResourceIdentifier privateEndpointId, DesktopVirtualizationPrivateLinkServiceConnectionState connectionState, DesktopVirtualizationPrivateEndpointConnectionProvisioningState? provisioningState)
        {
            return DesktopVirtualizationPrivateEndpointConnection(id, name, resourceType, systemData, groupIds: default, privateEndpointId, connectionState, provisioningState);
        }

        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="resourceType"></param>
        /// <param name="systemData"></param>
        /// <param name="privateEndpointId"></param>
        /// <param name="connectionState"></param>
        /// <param name="provisioningState"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DesktopVirtualizationPrivateEndpointConnectionDataData DesktopVirtualizationPrivateEndpointConnectionDataData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ResourceIdentifier privateEndpointId, DesktopVirtualizationPrivateLinkServiceConnectionState connectionState, DesktopVirtualizationPrivateEndpointConnectionProvisioningState? provisioningState)
        {
            return DesktopVirtualizationPrivateEndpointConnectionDataData(id, name, resourceType, systemData, groupIds: default, privateEndpointId, connectionState, provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="DesktopVirtualization.VirtualApplicationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="objectId"> ObjectId of Application. (internal use). </param>
        /// <param name="description"> Description of Application. </param>
        /// <param name="friendlyName"> Friendly name of Application. </param>
        /// <param name="filePath"> Specifies a path for the executable file for the application. </param>
        /// <param name="msixPackageFamilyName"> Specifies the package family name for MSIX applications. </param>
        /// <param name="msixPackageApplicationId"> Specifies the package application Id for MSIX applications. </param>
        /// <param name="applicationType"> Resource Type of Application. </param>
        /// <param name="commandLineSetting"> Specifies whether this published application can be launched with command line arguments provided by the client, command line arguments specified at publish time, or no command line arguments at all. </param>
        /// <param name="commandLineArguments"> Command Line Arguments for Application. </param>
        /// <param name="showInPortal"> Specifies whether to show the RemoteApp program in the RD Web Access server. </param>
        /// <param name="iconPath"> Path to icon. </param>
        /// <param name="iconIndex"> Index of the icon. </param>
        /// <param name="iconHash"> Hash of the icon. </param>
        /// <param name="iconContent"> the icon a]  64bit stringEde icon. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualApplicationData VirtualApplicationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string objectId, string description, string friendlyName, string filePath, string msixPackageFamilyName, string msixPackageApplicationId, RemoteApplicationType? applicationType, VirtualApplicationCommandLineSetting commandLineSetting, string commandLineArguments, bool? showInPortal, string iconPath, int? iconIndex, string iconHash, BinaryData iconContent)
        {
            return VirtualApplicationData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                objectId: objectId,
                description: description,
                friendlyName: friendlyName,
                filePath: filePath,
                msixPackageFamilyName: msixPackageFamilyName,
                msixPackageApplicationId: msixPackageApplicationId,
                applicationType: applicationType,
                commandLineSetting: commandLineSetting,
                commandLineArguments: commandLineArguments,
                showInPortal: showInPortal,
                iconPath: iconPath,
                iconIndex: iconIndex,
                iconHash: iconHash,
                iconContent: iconContent);
        }
    }
}
