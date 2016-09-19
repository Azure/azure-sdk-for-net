/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition
{

    using Microsoft.Azure.Management.KeyVault.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition;
    using Microsoft.Azure.Management.Fluent.KeyVault;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition;
    /// <summary>
    /// A key vault definition allowing the sku to be set.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the sku of the key vault.
        /// </summary>
        /// <param name="skuName">skuName the sku</param>
        /// <returns>the next stage of key vault definition</returns>
        IWithCreate WithSku (SkuName skuName);

    }
    /// <summary>
    /// A key vault definition allowing various configurations to be set.
    /// </summary>
    public interface IWithConfigurations 
    {
        /// <summary>
        /// Enable Azure Virtual Machines to retrieve certificates stored as secrets from the key vault.
        /// </summary>
        /// <returns>the next stage of key vault definition</returns>
        IWithCreate WithDeploymentEnabled ();

        /// <summary>
        /// Enable Azure Disk Encryption to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        /// <returns>the next stage of key vault definition</returns>
        IWithCreate WithDiskEncryptionEnabled ();

        /// <summary>
        /// Enable Azure Resource Manager to retrieve secrets from the key vault.
        /// </summary>
        /// <returns>the next stage of key vault definition</returns>
        IWithCreate WithTemplateDeploymentEnabled ();

        /// <summary>
        /// Disable Azure Virtual Machines to retrieve certificates stored as secrets from the key vault.
        /// </summary>
        /// <returns>the next stage of key vault definition</returns>
        IWithCreate WithDeploymentDisabled ();

        /// <summary>
        /// Disable Azure Disk Encryption to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        /// <returns>the next stage of key vault definition</returns>
        IWithCreate WithDiskEncryptionDisabled ();

        /// <summary>
        /// Disable Azure Resource Manager to retrieve secrets from the key vault.
        /// </summary>
        /// <returns>the next stage of key vault definition</returns>
        IWithCreate WithTemplateDeploymentDisabled ();

    }
    /// <summary>
    /// A key vault definition allowing resource group to be set.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithGroup<IWithAccessPolicy>
    {
    }
    /// <summary>
    /// The first stage of the key vault definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithGroup>
    {
    }
    /// <summary>
    /// A key vault definition with sufficient inputs to create a new
    /// storage account in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<IVault>,
        IDefinitionWithTags<IWithCreate>,
        IWithSku,
        IWithConfigurations,
        IWithAccessPolicy
    {
    }
    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IBlank,
        Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithGroup,
        IWithAccessPolicy,
        IWithCreate
    {
    }
    /// <summary>
    /// A key vault definition allowing access policies to be attached.
    /// </summary>
    public interface IWithAccessPolicy 
    {
        /// <summary>
        /// Attach no access policy.
        /// </summary>
        /// <returns>the next stage of key vault definition</returns>
        IWithCreate WithEmptyAccessPolicy ();

        /// <summary>
        /// Attach an existing access policy.
        /// </summary>
        /// <param name="accessPolicy">accessPolicy the existing access policy</param>
        /// <returns>the next stage of key vault definition</returns>
        IWithCreate WithAccessPolicy (IAccessPolicy accessPolicy);

        /// <summary>
        /// Begins the definition of a new access policy to be added to this key vault.
        /// </summary>
        /// <returns>the first stage of the access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IBlank<IWithCreate> DefineAccessPolicy ();

    }
}