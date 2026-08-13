// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.MachineLearning;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    [CodeGenSuppress("MachineLearningCodeContainerProperties", typeof(string), typeof(IDictionary<string, string>), typeof(IDictionary<string, string>), typeof(bool?), typeof(string), typeof(string), typeof(RegistryAssetProvisioningState?))]
    [CodeGenSuppress("MachineLearningAssetContainer", typeof(string), typeof(IDictionary<string, string>), typeof(IDictionary<string, string>), typeof(bool?), typeof(string), typeof(string))]
    [CodeGenSuppress("MachineLearningCodeVersionProperties", typeof(string), typeof(IDictionary<string, string>), typeof(IDictionary<string, string>), typeof(bool?), typeof(bool?), typeof(Uri), typeof(RegistryAssetProvisioningState?))]
    [CodeGenSuppress("MachineLearningComponentContainerProperties", typeof(string), typeof(IDictionary<string, string>), typeof(IDictionary<string, string>), typeof(bool?), typeof(string), typeof(string), typeof(RegistryAssetProvisioningState?))]
    [CodeGenSuppress("MachineLearningComponentVersionProperties", typeof(string), typeof(IDictionary<string, string>), typeof(IDictionary<string, string>), typeof(bool?), typeof(bool?), typeof(BinaryData), typeof(RegistryAssetProvisioningState?))]
    [CodeGenSuppress("MachineLearningDataContainerProperties", typeof(string), typeof(IDictionary<string, string>), typeof(IDictionary<string, string>), typeof(bool?), typeof(string), typeof(string), typeof(MachineLearningDataType))]
    [CodeGenSuppress("MachineLearningEnvironmentContainerProperties", typeof(string), typeof(IDictionary<string, string>), typeof(IDictionary<string, string>), typeof(bool?), typeof(string), typeof(string), typeof(RegistryAssetProvisioningState?))]
    [CodeGenSuppress("MachineLearningModelContainerProperties", typeof(string), typeof(IDictionary<string, string>), typeof(IDictionary<string, string>), typeof(bool?), typeof(string), typeof(string), typeof(RegistryAssetProvisioningState?))]
    [CodeGenSuppress("MachineLearningFeatureSetContainerProperties", typeof(string), typeof(IDictionary<string, string>), typeof(IDictionary<string, string>), typeof(bool?), typeof(string), typeof(string), typeof(RegistryAssetProvisioningState?))]
    [CodeGenSuppress("MachineLearningFeatureStoreEntityContainerProperties", typeof(string), typeof(IDictionary<string, string>), typeof(IDictionary<string, string>), typeof(bool?), typeof(string), typeof(string), typeof(RegistryAssetProvisioningState?))]
    [CodeGenSuppress("MachineLearningSkuCapacity", typeof(int?), typeof(int?), typeof(int?), typeof(MachineLearningSkuScaleType?))]
    [CodeGenSuppress("MachineLearningMarketplacePlan", typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("DockerCredential", typeof(string), typeof(string))]
    [CodeGenSuppress("ManagedIdentityCredential", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string))]
    public static partial class ArmMachineLearningModelFactory
    {
        // TODO: Remove these compatibility factory methods after https://github.com/Azure/azure-sdk-for-net/issues/61815 is fixed.

        /// <param name="description"> The asset description text. </param>
        /// <param name="properties"> The asset property dictionary. </param>
        /// <param name="tags"> Tag dictionary. Tags can be added, removed, and updated. </param>
        /// <param name="isArchived"> Is the asset archived?. </param>
        /// <param name="latestVersion"> The latest version inside this container. </param>
        /// <param name="nextVersion"> The next auto incremental version. </param>
        /// <param name="provisioningState"> Provisioning state for the code container. </param>
        /// <returns> A new <see cref="Models.MachineLearningCodeContainerProperties"/> instance for mocking. </returns>
        public static MachineLearningCodeContainerProperties MachineLearningCodeContainerProperties(string description = default, IDictionary<string, string> tags = default, IDictionary<string, string> properties = default, bool? isArchived = default, string latestVersion = default, string nextVersion = default, RegistryAssetProvisioningState? provisioningState = default)
        {
            properties ??= new ChangeTrackingDictionary<string, string>();
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new MachineLearningCodeContainerProperties(
                description,
                properties ?? new ChangeTrackingDictionary<string, string>(),
                tags ?? new ChangeTrackingDictionary<string, string>(),
                default,
                isArchived,
                latestVersion,
                nextVersion,
                provisioningState);
        }

        /// <param name="description"> The asset description text. </param>
        /// <param name="properties"> The asset property dictionary. </param>
        /// <param name="tags"> Tag dictionary. Tags can be added, removed, and updated. </param>
        /// <param name="isArchived"> Is the asset archived?. </param>
        /// <param name="latestVersion"> The latest version inside this container. </param>
        /// <param name="nextVersion"> The next auto incremental version. </param>
        /// <returns> A new <see cref="Models.MachineLearningAssetContainer"/> instance for mocking. </returns>
        public static MachineLearningAssetContainer MachineLearningAssetContainer(string description = default, IDictionary<string, string> tags = default, IDictionary<string, string> properties = default, bool? isArchived = default, string latestVersion = default, string nextVersion = default)
        {
            properties ??= new ChangeTrackingDictionary<string, string>();
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new MachineLearningAssetContainer(
                description,
                properties ?? new ChangeTrackingDictionary<string, string>(),
                tags ?? new ChangeTrackingDictionary<string, string>(),
                default,
                isArchived,
                latestVersion,
                nextVersion);
        }

        /// <param name="description"> The asset description text. </param>
        /// <param name="properties"> The asset property dictionary. </param>
        /// <param name="tags"> Tag dictionary. Tags can be added, removed, and updated. </param>
        /// <param name="isAnonymous"> If the name version are system generated (anonymous registration). </param>
        /// <param name="isArchived"> Is the asset archived?. </param>
        /// <param name="codeUri"> Uri where code is located. </param>
        /// <param name="provisioningState"> Provisioning state for the code version. </param>
        /// <returns> A new <see cref="Models.MachineLearningCodeVersionProperties"/> instance for mocking. </returns>
        public static MachineLearningCodeVersionProperties MachineLearningCodeVersionProperties(string description = default, IDictionary<string, string> tags = default, IDictionary<string, string> properties = default, bool? isArchived = default, bool? isAnonymous = default, Uri codeUri = default, RegistryAssetProvisioningState? provisioningState = default)
        {
            properties ??= new ChangeTrackingDictionary<string, string>();
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new MachineLearningCodeVersionProperties(
                description,
                properties ?? new ChangeTrackingDictionary<string, string>(),
                tags ?? new ChangeTrackingDictionary<string, string>(),
                default,
                isAnonymous,
                isArchived,
                codeUri,
                provisioningState);
        }

        /// <param name="description"> The asset description text. </param>
        /// <param name="properties"> The asset property dictionary. </param>
        /// <param name="tags"> Tag dictionary. Tags can be added, removed, and updated. </param>
        /// <param name="isArchived"> Is the asset archived?. </param>
        /// <param name="latestVersion"> The latest version inside this container. </param>
        /// <param name="nextVersion"> The next auto incremental version. </param>
        /// <param name="provisioningState"> Provisioning state for the component container. </param>
        /// <returns> A new <see cref="Models.MachineLearningComponentContainerProperties"/> instance for mocking. </returns>
        public static MachineLearningComponentContainerProperties MachineLearningComponentContainerProperties(string description = default, IDictionary<string, string> tags = default, IDictionary<string, string> properties = default, bool? isArchived = default, string latestVersion = default, string nextVersion = default, RegistryAssetProvisioningState? provisioningState = default)
        {
            properties ??= new ChangeTrackingDictionary<string, string>();
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new MachineLearningComponentContainerProperties(
                description,
                properties ?? new ChangeTrackingDictionary<string, string>(),
                tags ?? new ChangeTrackingDictionary<string, string>(),
                default,
                isArchived,
                latestVersion,
                nextVersion,
                provisioningState);
        }

        /// <param name="description"> The asset description text. </param>
        /// <param name="properties"> The asset property dictionary. </param>
        /// <param name="tags"> Tag dictionary. Tags can be added, removed, and updated. </param>
        /// <param name="isAnonymous"> If the name version are system generated (anonymous registration). </param>
        /// <param name="isArchived"> Is the asset archived?. </param>
        /// <param name="componentSpec">
        /// Defines Component definition details.
        /// <see href="https://docs.microsoft.com/en-us/azure/machine-learning/reference-yaml-component-command" />
        /// </param>
        /// <param name="provisioningState"> Provisioning state for the component version. </param>
        /// <returns> A new <see cref="Models.MachineLearningComponentVersionProperties"/> instance for mocking. </returns>
        public static MachineLearningComponentVersionProperties MachineLearningComponentVersionProperties(string description = default, IDictionary<string, string> tags = default, IDictionary<string, string> properties = default, bool? isArchived = default, bool? isAnonymous = default, BinaryData componentSpec = default, RegistryAssetProvisioningState? provisioningState = default)
        {
            properties ??= new ChangeTrackingDictionary<string, string>();
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new MachineLearningComponentVersionProperties(
                description,
                properties ?? new ChangeTrackingDictionary<string, string>(),
                tags ?? new ChangeTrackingDictionary<string, string>(),
                default,
                isAnonymous,
                isArchived,
                componentSpec,
                provisioningState);
        }

        /// <param name="description"> The asset description text. </param>
        /// <param name="properties"> The asset property dictionary. </param>
        /// <param name="tags"> Tag dictionary. Tags can be added, removed, and updated. </param>
        /// <param name="isArchived"> Is the asset archived?. </param>
        /// <param name="latestVersion"> The latest version inside this container. </param>
        /// <param name="nextVersion"> The next auto incremental version. </param>
        /// <param name="dataType"> [Required] Specifies the type of data. </param>
        /// <returns> A new <see cref="Models.MachineLearningDataContainerProperties"/> instance for mocking. </returns>
        public static MachineLearningDataContainerProperties MachineLearningDataContainerProperties(string description = default, IDictionary<string, string> tags = default, IDictionary<string, string> properties = default, bool? isArchived = default, string latestVersion = default, string nextVersion = default, MachineLearningDataType dataType = default)
        {
            properties ??= new ChangeTrackingDictionary<string, string>();
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new MachineLearningDataContainerProperties(
                description,
                properties ?? new ChangeTrackingDictionary<string, string>(),
                tags ?? new ChangeTrackingDictionary<string, string>(),
                default,
                isArchived,
                latestVersion,
                nextVersion,
                dataType);
        }

        /// <param name="description"> The asset description text. </param>
        /// <param name="properties"> The asset property dictionary. </param>
        /// <param name="tags"> Tag dictionary. Tags can be added, removed, and updated. </param>
        /// <param name="isArchived"> Is the asset archived?. </param>
        /// <param name="latestVersion"> The latest version inside this container. </param>
        /// <param name="nextVersion"> The next auto incremental version. </param>
        /// <param name="provisioningState"> Provisioning state for the environment container. </param>
        /// <returns> A new <see cref="Models.MachineLearningEnvironmentContainerProperties"/> instance for mocking. </returns>
        public static MachineLearningEnvironmentContainerProperties MachineLearningEnvironmentContainerProperties(string description = default, IDictionary<string, string> tags = default, IDictionary<string, string> properties = default, bool? isArchived = default, string latestVersion = default, string nextVersion = default, RegistryAssetProvisioningState? provisioningState = default)
        {
            properties ??= new ChangeTrackingDictionary<string, string>();
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new MachineLearningEnvironmentContainerProperties(
                description,
                properties ?? new ChangeTrackingDictionary<string, string>(),
                tags ?? new ChangeTrackingDictionary<string, string>(),
                default,
                isArchived,
                latestVersion,
                nextVersion,
                provisioningState);
        }

        /// <param name="description"> The asset description text. </param>
        /// <param name="properties"> The asset property dictionary. </param>
        /// <param name="tags"> Tag dictionary. Tags can be added, removed, and updated. </param>
        /// <param name="isArchived"> Is the asset archived?. </param>
        /// <param name="latestVersion"> The latest version inside this container. </param>
        /// <param name="nextVersion"> The next auto incremental version. </param>
        /// <param name="provisioningState"> Provisioning state for the model container. </param>
        /// <returns> A new <see cref="Models.MachineLearningModelContainerProperties"/> instance for mocking. </returns>
        public static MachineLearningModelContainerProperties MachineLearningModelContainerProperties(string description = default, IDictionary<string, string> tags = default, IDictionary<string, string> properties = default, bool? isArchived = default, string latestVersion = default, string nextVersion = default, RegistryAssetProvisioningState? provisioningState = default)
        {
            properties ??= new ChangeTrackingDictionary<string, string>();
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new MachineLearningModelContainerProperties(
                description,
                properties ?? new ChangeTrackingDictionary<string, string>(),
                tags ?? new ChangeTrackingDictionary<string, string>(),
                default,
                isArchived,
                latestVersion,
                nextVersion,
                provisioningState);
        }

        /// <param name="description"> The asset description text. </param>
        /// <param name="properties"> The asset property dictionary. </param>
        /// <param name="tags"> Tag dictionary. Tags can be added, removed, and updated. </param>
        /// <param name="isArchived"> Is the asset archived?. </param>
        /// <param name="latestVersion"> The latest version inside this container. </param>
        /// <param name="nextVersion"> The next auto incremental version. </param>
        /// <param name="provisioningState"> Provisioning state for the featureset container. </param>
        /// <returns> A new <see cref="Models.MachineLearningFeatureSetContainerProperties"/> instance for mocking. </returns>
        public static MachineLearningFeatureSetContainerProperties MachineLearningFeatureSetContainerProperties(string description = default, IDictionary<string, string> tags = default, IDictionary<string, string> properties = default, bool? isArchived = default, string latestVersion = default, string nextVersion = default, RegistryAssetProvisioningState? provisioningState = default)
        {
            properties ??= new ChangeTrackingDictionary<string, string>();
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new MachineLearningFeatureSetContainerProperties(
                description,
                properties ?? new ChangeTrackingDictionary<string, string>(),
                tags ?? new ChangeTrackingDictionary<string, string>(),
                default,
                isArchived,
                latestVersion,
                nextVersion,
                provisioningState);
        }

        /// <param name="description"> The asset description text. </param>
        /// <param name="properties"> The asset property dictionary. </param>
        /// <param name="tags"> Tag dictionary. Tags can be added, removed, and updated. </param>
        /// <param name="isArchived"> Is the asset archived?. </param>
        /// <param name="latestVersion"> The latest version inside this container. </param>
        /// <param name="nextVersion"> The next auto incremental version. </param>
        /// <param name="provisioningState"> Provisioning state for the featurestore entity container. </param>
        /// <returns> A new <see cref="Models.MachineLearningFeatureStoreEntityContainerProperties"/> instance for mocking. </returns>
        public static MachineLearningFeatureStoreEntityContainerProperties MachineLearningFeatureStoreEntityContainerProperties(string description = default, IDictionary<string, string> tags = default, IDictionary<string, string> properties = default, bool? isArchived = default, string latestVersion = default, string nextVersion = default, RegistryAssetProvisioningState? provisioningState = default)
        {
            properties ??= new ChangeTrackingDictionary<string, string>();
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new MachineLearningFeatureStoreEntityContainerProperties(
                description,
                properties ?? new ChangeTrackingDictionary<string, string>(),
                tags ?? new ChangeTrackingDictionary<string, string>(),
                default,
                isArchived,
                latestVersion,
                nextVersion,
                provisioningState);
        }

        /// <param name="default"> Gets or sets the default capacity. </param>
        /// <param name="maximum"> Gets or sets the maximum. </param>
        /// <param name="minimum"> Gets or sets the minimum. </param>
        /// <param name="scaleType"> Node scaling setting for the compute sku. </param>
        /// <returns> A new <see cref="Models.MachineLearningSkuCapacity"/> instance for mocking. </returns>
        public static MachineLearningSkuCapacity MachineLearningSkuCapacity(int? minimum = default, int? maximum = default, int? @default = default, MachineLearningSkuScaleType? scaleType = default)
        {
            return new MachineLearningSkuCapacity(@default, maximum, minimum, scaleType, default);
        }

        /// <param name="offerId"> The identifying name of the Offer of the Marketplace Plan. </param>
        /// <param name="planId"> The identifying name of the Plan of the Marketplace Plan. </param>
        /// <param name="publisherId"> The identifying name of the Publisher of the Marketplace Plan. </param>
        /// <returns> A new <see cref="Models.MachineLearningMarketplacePlan"/> instance for mocking. </returns>
        public static MachineLearningMarketplacePlan MachineLearningMarketplacePlan(string publisherId = default, string offerId = default, string planId = default)
        {
            return new MachineLearningMarketplacePlan(offerId, planId, publisherId, default);
        }

        /// <param name="password"> DockerCredential user password. </param>
        /// <param name="userName"> DockerCredential user name. </param>
        /// <returns> A new <see cref="Models.DockerCredential"/> instance for mocking. </returns>
        public static DockerCredential DockerCredential(string userName = default, string password = default)
        {
            return new DockerCredential(default, default, password, userName);
        }

        /// <param name="managedIdentityType"> ManagedIdentityCredential identity type. </param>
        /// <param name="userManagedIdentityClientId"> ClientId for the UAMI. For ManagedIdentityType = SystemManaged, this field is null. </param>
        /// <param name="userManagedIdentityPrincipalId"> PrincipalId for the UAMI. For ManagedIdentityType = SystemManaged, this field is null. </param>
        /// <param name="userManagedIdentityResourceId"> Full arm scope for the Id. For ManagedIdentityType = SystemManaged, this field is null. </param>
        /// <param name="userManagedIdentityTenantId"> TenantId for the UAMI. For ManagedIdentityType = SystemManaged, this field is null. </param>
        /// <returns> A new <see cref="Models.ManagedIdentityCredential"/> instance for mocking. </returns>
        public static ManagedIdentityCredential ManagedIdentityCredential(string managedIdentityType = default, string userManagedIdentityResourceId = default, string userManagedIdentityClientId = default, string userManagedIdentityPrincipalId = default, string userManagedIdentityTenantId = default)
        {
            return new ManagedIdentityCredential(
                default,
                default,
                managedIdentityType,
                userManagedIdentityClientId,
                userManagedIdentityPrincipalId,
                userManagedIdentityResourceId,
                userManagedIdentityTenantId);
        }
    }
}
