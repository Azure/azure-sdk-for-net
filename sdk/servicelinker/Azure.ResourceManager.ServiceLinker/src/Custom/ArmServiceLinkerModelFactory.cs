// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    public static partial class ArmServiceLinkerModelFactory
    {
        // Add this method back due to the breaking change of models: `VnetSolution` & `SecretStore` have more properties in version 2024-07-01-preview.
        /// <summary> Initializes a new instance of <see cref="Models.LinkerResourcePatch"/>. </summary>
        /// <param name="targetService">
        /// The target service properties
        /// Please note <see cref="TargetServiceBaseInfo"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="AzureResourceInfo"/>, <see cref="ConfluentBootstrapServerInfo"/> and <see cref="ConfluentSchemaRegistryInfo"/>.
        /// </param>
        /// <param name="authInfo">
        /// The authentication type.
        /// Please note <see cref="AuthBaseInfo"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SecretAuthInfo"/>, <see cref="ServicePrincipalCertificateAuthInfo"/>, <see cref="ServicePrincipalSecretAuthInfo"/>, <see cref="SystemAssignedIdentityAuthInfo"/> and <see cref="UserAssignedIdentityAuthInfo"/>.
        /// </param>
        /// <param name="clientType"> The application client type. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="solutionType"> The VNet solution. </param>
        /// <param name="secretStoreKeyVaultId"> An option to store secret value in secure place. </param>
        /// <param name="scope"> connection scope in source service. </param>
        /// <returns> A new <see cref="Models.LinkerResourcePatch"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LinkerResourcePatch LinkerResourcePatch(TargetServiceBaseInfo targetService, AuthBaseInfo authInfo, LinkerClientType? clientType, string provisioningState, VnetSolutionType? solutionType, ResourceIdentifier secretStoreKeyVaultId = null, string scope = null)
        {
            return LinkerResourcePatch(
                targetService,
                authInfo,
                clientType,
                provisioningState,
                solutionType != null ? new VnetSolution() { SolutionType = solutionType } : null,
                secretStoreKeyVaultId != null ? new LinkerSecretStore() { KeyVaultId = secretStoreKeyVaultId } : null,
                scope);
        }

        // Add this method back due to the breaking change of models: `VnetSolution` & `SecretStore` have more properties in version 2024-07-01-preview.
        /// <summary> Initializes a new instance of <see cref="ServiceLinker.LinkerResourceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="targetService">
        /// The target service properties
        /// Please note <see cref="TargetServiceBaseInfo"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="AzureResourceInfo"/>, <see cref="ConfluentBootstrapServerInfo"/> and <see cref="ConfluentSchemaRegistryInfo"/>.
        /// </param>
        /// <param name="authInfo">
        /// The authentication type.
        /// Please note <see cref="AuthBaseInfo"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SecretAuthInfo"/>, <see cref="ServicePrincipalCertificateAuthInfo"/>, <see cref="ServicePrincipalSecretAuthInfo"/>, <see cref="SystemAssignedIdentityAuthInfo"/> and <see cref="UserAssignedIdentityAuthInfo"/>.
        /// </param>
        /// <param name="clientType"> The application client type. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="solutionType"> The VNet solution. </param>
        /// <param name="secretStoreKeyVaultId"> An option to store secret value in secure place. </param>
        /// <param name="scope"> connection scope in source service. </param>
        /// <returns> A new <see cref="ServiceLinker.LinkerResourceData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LinkerResourceData LinkerResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, TargetServiceBaseInfo targetService, AuthBaseInfo authInfo, LinkerClientType? clientType, string provisioningState, VnetSolutionType? solutionType, ResourceIdentifier secretStoreKeyVaultId = null, string scope = null)
        {
            return LinkerResourceData(
                id,
                name,
                resourceType,
                systemData,
                targetService,
                authInfo,
                clientType,
                provisioningState,
                solutionType != null ? new VnetSolution() { SolutionType = solutionType } : null,
                secretStoreKeyVaultId != null ? new LinkerSecretStore() { KeyVaultId = secretStoreKeyVaultId } : null,
                scope);
        }
    }
}
