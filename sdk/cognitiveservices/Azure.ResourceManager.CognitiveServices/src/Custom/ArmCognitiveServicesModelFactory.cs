// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.CognitiveServices;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices.Models
{
    public static partial class ArmCognitiveServicesModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="CognitiveServices.CognitiveServicesAccountDeploymentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="sku"> The resource model definition representing SKU. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <param name="properties"> Properties of Cognitive Services account deployment. </param>
        /// <returns> A new <see cref="CognitiveServices.CognitiveServicesAccountDeploymentData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CognitiveServicesAccountDeploymentData CognitiveServicesAccountDeploymentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, CognitiveServicesSku sku, ETag? etag, CognitiveServicesAccountDeploymentProperties properties)
        {
            return CognitiveServicesAccountDeploymentData(id, name, resourceType, systemData, sku, etag, default, properties);
        }

        /// <summary> Initializes a new instance of <see cref="CognitiveServices.CommitmentPlanAccountAssociationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <param name="accountId"> The Azure resource id of the account. </param>
        /// <returns> A new <see cref="CognitiveServices.CommitmentPlanAccountAssociationData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommitmentPlanAccountAssociationData CommitmentPlanAccountAssociationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, string accountId)
        {
            return CommitmentPlanAccountAssociationData(id, name, resourceType, systemData, etag, default, accountId);
        }
    }
}
