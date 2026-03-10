// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: The model factory methods gained new parameters (e.g. groupIds).
// These overloads preserve the old signatures with fewer parameters by delegating to the new
// methods with default values, so existing callers using the model factory are not broken.

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
            return DesktopVirtualizationPrivateEndpointConnection(id, name, resourceType, systemData, null, privateEndpointId, connectionState, provisioningState);
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
            return DesktopVirtualizationPrivateEndpointConnectionDataData(id, name, resourceType, systemData, null, privateEndpointId, connectionState, provisioningState);
        }

        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="resourceType"></param>
        /// <param name="systemData"></param>
        /// <param name="objectId"></param>
        /// <param name="description"></param>
        /// <param name="friendlyName"></param>
        /// <param name="filePath"></param>
        /// <param name="msixPackageFamilyName"></param>
        /// <param name="msixPackageApplicationId"></param>
        /// <param name="applicationType"></param>
        /// <param name="commandLineSetting"></param>
        /// <param name="commandLineArguments"></param>
        /// <param name="showInPortal"></param>
        /// <param name="iconPath"></param>
        /// <param name="iconIndex"></param>
        /// <param name="iconHash"></param>
        /// <param name="iconContent"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualApplicationData VirtualApplicationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string objectId, string description, string friendlyName, string filePath, string msixPackageFamilyName, string msixPackageApplicationId, RemoteApplicationType? applicationType, VirtualApplicationCommandLineSetting commandLineSetting, string commandLineArguments, bool? showInPortal, string iconPath, int? iconIndex, string iconHash, BinaryData iconContent)
        {
            var properties = new ApplicationProperties(objectId, description, friendlyName, filePath, msixPackageFamilyName, msixPackageApplicationId, applicationType, commandLineSetting, commandLineArguments, showInPortal, iconPath, iconIndex, iconHash, iconContent, null);
            return new VirtualApplicationData(id, name, resourceType, systemData, additionalBinaryDataProperties: null, properties);
        }
    }
}
