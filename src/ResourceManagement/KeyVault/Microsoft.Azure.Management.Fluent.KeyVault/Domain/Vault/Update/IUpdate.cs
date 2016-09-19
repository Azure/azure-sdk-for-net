/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update
{

    using Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update;
    using Microsoft.Azure.Management.Fluent.KeyVault;
    using Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    /// <summary>
    /// A key vault update allowing various configurations to be set.
    /// </summary>
    public interface IWithConfigurations 
    {
        /// <summary>
        /// Enable Azure Virtual Machines to retrieve certificates stored as secrets from the key vault.
        /// </summary>
        /// <returns>the key vault update stage</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate WithDeploymentEnabled ();

        /// <summary>
        /// Enable Azure Disk Encryption to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        /// <returns>the key vault update stage</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate WithDiskEncryptionEnabled ();

        /// <summary>
        /// Enable Azure Resource Manager to retrieve secrets from the key vault.
        /// </summary>
        /// <returns>the key vault update stage</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate WithTemplateDeploymentEnabled ();

        /// <summary>
        /// Disable Azure Virtual Machines to retrieve certificates stored as secrets from the key vault.
        /// </summary>
        /// <returns>the key vault update stage</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate WithDeploymentDisabled ();

        /// <summary>
        /// Disable Azure Disk Encryption to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        /// <returns>the next stage of key vault definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate WithDiskEncryptionDisabled ();

        /// <summary>
        /// Disable Azure Resource Manager to retrieve secrets from the key vault.
        /// </summary>
        /// <returns>the key vault update stage</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate WithTemplateDeploymentDisabled ();

    }
    /// <summary>
    /// A key vault update allowing access policies to be modified, attached, or removed.
    /// </summary>
    public interface IWithAccessPolicy 
    {
        /// <summary>
        /// Remove an access policy from the access policy list.
        /// </summary>
        /// <param name="objectId">objectId the object ID of the Active Directory identity the access policy is for</param>
        /// <returns>the key vault update stage</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate WithoutAccessPolicy (string objectId);

        /// <summary>
        /// Attach an existing access policy.
        /// </summary>
        /// <param name="accessPolicy">accessPolicy the existing access policy</param>
        /// <returns>the key vault update stage</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate WithAccessPolicy (IAccessPolicy accessPolicy);

        /// <summary>
        /// Begins the definition of a new access policy to be added to this key vault.
        /// </summary>
        /// <returns>the first stage of the access policy definition</returns>
        IBlank<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate> DefineAccessPolicy ();

        /// <summary>
        /// Begins the update of an existing access policy attached to this key vault.
        /// </summary>
        /// <param name="objectId">objectId the object ID of the Active Directory identity the access policy is for</param>
        /// <returns>the update stage of the access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate UpdateAccessPolicy (string objectId);

    }
    /// <summary>
    /// The template for a key vault update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        IAppliable<IVault>,
        IWithAccessPolicy,
        IWithConfigurations
    {
    }
}