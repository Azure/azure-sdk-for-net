// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Nginx;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Nginx.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    public static partial class ArmNginxModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Nginx.NginxConfigurationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"></param>
        /// <param name="location"></param>
        /// <returns> A new <see cref="Nginx.NginxConfigurationData"/> instance for mocking. </returns>
        public static NginxConfigurationData NginxConfigurationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, NginxConfigurationProperties properties, AzureLocation? location)
            => NginxConfigurationData(id, name, resourceType, systemData, properties);

        /// <summary> Initializes a new instance of <see cref="Nginx.NginxDeploymentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> Gets or sets the identity. </param>
        /// <param name="properties"></param>
        /// <param name="skuName"></param>
        /// <returns> A new <see cref="Nginx.NginxDeploymentData"/> instance for mocking. </returns>
        public static NginxDeploymentData NginxDeploymentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, NginxDeploymentProperties properties = default, string skuName = default)
            => NginxDeploymentData(id, name, resourceType, systemData, tags, location, properties, identity, skuName);

        /// <summary> Initializes a new instance of <see cref="Models.NginxCertificateProperties"/>. </summary>
        /// <param name="provisioningState"></param>
        /// <param name="keyVirtualPath"></param>
        /// <param name="certificateVirtualPath"></param>
        /// <param name="keyVaultSecretId"></param>
        /// <returns> A new <see cref="Models.NginxCertificateProperties"/> instance for mocking. </returns>
        public static NginxCertificateProperties NginxCertificateProperties(NginxProvisioningState? provisioningState, string keyVirtualPath, string certificateVirtualPath, string keyVaultSecretId)
            => NginxCertificateProperties(provisioningState, keyVirtualPath, certificateVirtualPath, keyVaultSecretId, null, null, null, null);

        /// <summary> Initializes a new instance of <see cref="Models.NginxDeploymentProperties"/>. </summary>
        /// <param name="provisioningState"></param>
        /// <param name="nginxVersion"></param>
        /// <param name="managedResourceGroup"> The managed resource group to deploy VNet injection related network resources. </param>
        /// <param name="networkProfile"></param>
        /// <param name="ipAddress"> The IP address of the deployment. </param>
        /// <param name="enableDiagnosticsSupport"></param>
        /// <param name="loggingStorageAccount"></param>
        /// <param name="scalingCapacity"></param>
        /// <param name="userPreferredEmail"></param>
        /// <returns> A new <see cref="Models.NginxDeploymentProperties"/> instance for mocking. </returns>
        public static NginxDeploymentProperties NginxDeploymentProperties(NginxProvisioningState? provisioningState, string nginxVersion, string managedResourceGroup, NginxNetworkProfile networkProfile, string ipAddress, bool? enableDiagnosticsSupport, NginxStorageAccount loggingStorageAccount, int? scalingCapacity, string userPreferredEmail = default)
            => NginxDeploymentProperties(provisioningState, nginxVersion, networkProfile, ipAddress, enableDiagnosticsSupport, loggingStorageAccount, null, null, userPreferredEmail, null, null);
    }
}
