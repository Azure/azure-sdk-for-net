// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure;
using Azure.Core;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppService.Models
{
    [CodeGenSuppress("AppServiceIdentifierData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string))]
    [CodeGenSuppress("PremierAddOnData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("DiagnosticCategoryData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string))]
    [CodeGenSuppress("WebSiteAnalysisDefinitionData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string))]
    public static partial class ArmAppServiceModelFactory
    {
        // TODO: Remove these compatibility factory methods after https://github.com/Azure/azure-sdk-for-net/issues/61815 is fixed.

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="value"> String representation of the identity. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.AppServiceIdentifierData"/> instance for mocking. </returns>
        public static AppServiceIdentifierData AppServiceIdentifierData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string kind = default, string value = default)
        {
            return new AppServiceIdentifierData(
                id,
                name,
                resourceType,
                systemData,
                value is null ? default : new IdentifierProperties(value, default),
                kind,
                default);
        }

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="sku"> Premier add on SKU. </param>
        /// <param name="product"> Premier add on Product. </param>
        /// <param name="vendor"> Premier add on Vendor. </param>
        /// <param name="marketplacePublisher"> Premier add on Marketplace publisher. </param>
        /// <param name="marketplaceOffer"> Premier add on Marketplace offer. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.PremierAddOnData"/> instance for mocking. </returns>
        public static PremierAddOnData PremierAddOnData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, string kind = default, string sku = default, string product = default, string vendor = default, string marketplacePublisher = default, string marketplaceOffer = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new PremierAddOnData(
                id,
                name,
                resourceType,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                sku is null && product is null && vendor is null && marketplacePublisher is null && marketplaceOffer is null ? default : new PremierAddOnProperties(
                    sku,
                    product,
                    vendor,
                    marketplacePublisher,
                    marketplaceOffer,
                    default),
                kind,
                default);
        }

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="description"> Description of the diagnostic category. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.DiagnosticCategoryData"/> instance for mocking. </returns>
        public static DiagnosticCategoryData DiagnosticCategoryData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string kind = default, string description = default)
        {
            return new DiagnosticCategoryData(
                id,
                name,
                resourceType,
                systemData,
                description is null ? default : new DiagnosticCategoryProperties(description, default),
                kind,
                default);
        }

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="description"> Description of the Analysis. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.WebSiteAnalysisDefinitionData"/> instance for mocking. </returns>
        public static WebSiteAnalysisDefinitionData WebSiteAnalysisDefinitionData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string kind = default, string description = default)
        {
            return new WebSiteAnalysisDefinitionData(
                id,
                name,
                resourceType,
                systemData,
                description is null ? default : new AnalysisDefinitionProperties(description, default),
                kind,
                default);
        }
    }
}
