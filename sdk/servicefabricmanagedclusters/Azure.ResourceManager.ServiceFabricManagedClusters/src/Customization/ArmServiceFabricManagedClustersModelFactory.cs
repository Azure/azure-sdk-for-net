// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    public static partial class ArmServiceFabricManagedClustersModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ServiceFabricManagedClusters.ServiceFabricManagedApplicationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> Describes the managed identities for an Azure resource. </param>
        /// <param name="provisioningState"> The current deployment or provisioning state, which only appears in the response. </param>
        /// <param name="version">
        /// The version of the application type as defined in the application manifest.
        /// This name must be the full Arm Resource ID for the referenced application type version.
        /// </param>
        /// <param name="parameters"> List of application parameters with overridden values from their default values specified in the application manifest. </param>
        /// <param name="upgradePolicy"> Describes the policy for a monitored application upgrade. </param>
        /// <param name="managedIdentities"> List of user assigned identities for the application, each mapped to a friendly name. </param>
        /// <returns> A new <see cref="ServiceFabricManagedClusters.ServiceFabricManagedApplicationData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceFabricManagedApplicationData ServiceFabricManagedApplicationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location = default, ManagedServiceIdentity identity = null, string provisioningState = null, string version = null, IDictionary<string, string> parameters = null, ApplicationUpgradePolicy upgradePolicy = null, IEnumerable<ApplicationUserAssignedIdentityInfo> managedIdentities = null)
            => ServiceFabricManagedApplicationData(id, name, resourceType, systemData, location, managedIdentities, provisioningState, version, parameters, upgradePolicy, tags, identity);

        /// <summary> Initializes a new instance of <see cref="Models.NodeTypeVmssExtension"/>. </summary>
        /// <param name="name"> The name of the extension. </param>
        /// <param name="publisher"> The name of the extension handler publisher. </param>
        /// <param name="vmssExtensionPropertiesType"> Specifies the type of the extension; an example is "CustomScriptExtension". </param>
        /// <param name="typeHandlerVersion"> Specifies the version of the script handler. </param>
        /// <param name="autoUpgradeMinorVersion"> Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true. </param>
        /// <param name="settings"> Json formatted public settings for the extension. </param>
        /// <param name="protectedSettings"> The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all. </param>
        /// <param name="forceUpdateTag"> If a value is provided and is different from the previous value, the extension handler will be forced to update even if the extension configuration has not changed. </param>
        /// <param name="provisionAfterExtensions"> Collection of extension names after which this extension needs to be provisioned. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <param name="isAutomaticUpgradeEnabled"> Indicates whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available. </param>
        /// <param name="setupOrder"> Indicates the setup order for the extension. </param>
        /// <returns> A new <see cref="Models.NodeTypeVmssExtension"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NodeTypeVmssExtension NodeTypeVmssExtension(string name, string publisher, string vmssExtensionPropertiesType, string typeHandlerVersion, bool? autoUpgradeMinorVersion, BinaryData settings, BinaryData protectedSettings, string forceUpdateTag, IEnumerable<string> provisionAfterExtensions, string provisioningState, bool? isAutomaticUpgradeEnabled, IEnumerable<VmssExtensionSetupOrder> setupOrder)
        {
            provisionAfterExtensions ??= new List<string>();
            setupOrder ??= new List<VmssExtensionSetupOrder>();

            return new NodeTypeVmssExtension(
                        name,
                        new VmssExtensionProperties(publisher,
                                vmssExtensionPropertiesType,
                                typeHandlerVersion,
                                autoUpgradeMinorVersion,
                                settings,
                                protectedSettings,
                                forceUpdateTag,
                                provisionAfterExtensions?.ToList(),
                                provisioningState,
                                isAutomaticUpgradeEnabled,
                                setupOrder?.ToList(),
                                null),
                        null);
        }
    }
}
