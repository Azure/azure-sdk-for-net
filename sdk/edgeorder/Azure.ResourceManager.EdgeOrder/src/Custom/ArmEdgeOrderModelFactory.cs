// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    // TODO: workaround for issue https://github.com/Azure/autorest.csharp/issues/5385.  Remove after the issue is fixed.
    public static partial class ArmEdgeOrderModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.EdgeOrderItemDetails"/>. </summary>
        /// <param name="productDetails"> Unique identifier for configuration. </param>
        /// <param name="orderItemType"> Order item type. </param>
        /// <param name="currentStage"> Current Order item Status. </param>
        /// <param name="orderItemStageHistory"> Order item status history. </param>
        /// <param name="preferences"> Customer notification Preferences. </param>
        /// <param name="forwardShippingDetails"> Forward Package Shipping details. </param>
        /// <param name="reverseShippingDetails"> Reverse Package Shipping details. </param>
        /// <param name="notificationEmailList"> Additional notification email list. </param>
        /// <param name="cancellationReason"> Cancellation reason. </param>
        /// <param name="cancellationStatus"> Describes whether the order item is cancellable or not. </param>
        /// <param name="deletionStatus"> Describes whether the order item is deletable or not. </param>
        /// <param name="returnReason"> Return reason. </param>
        /// <param name="returnStatus"> Describes whether the order item is returnable or not. </param>
        /// <param name="firstOrDefaultManagementResourceProviderNamespace"> Parent RP details - this returns only the first or default parent RP from the entire list. </param>
        /// <param name="managementRPDetailsList"> List of parent RP details supported for configuration. </param>
        /// <param name="error"> Top level error for the job. </param>
        /// <returns> A new <see cref="Models.EdgeOrderItemDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EdgeOrderItemDetails EdgeOrderItemDetails(ProductDetails productDetails = null, OrderItemType orderItemType = default, EdgeOrderStageDetails currentStage = null, IEnumerable<EdgeOrderStageDetails> orderItemStageHistory = null, OrderItemPreferences preferences = null, ForwardShippingDetails forwardShippingDetails = null, ReverseShippingDetails reverseShippingDetails = null, IEnumerable<string> notificationEmailList = null, string cancellationReason = null, OrderItemCancellationStatus? cancellationStatus = null, EdgeOrderActionStatus? deletionStatus = null, string returnReason = null, OrderItemReturnStatus? returnStatus = null, string firstOrDefaultManagementResourceProviderNamespace = null, IEnumerable<ResourceProviderDetails> managementRPDetailsList = null, ResponseError error = null)
        {
            orderItemStageHistory ??= new List<EdgeOrderStageDetails>();
            notificationEmailList ??= new List<string>();
            managementRPDetailsList ??= new List<ResourceProviderDetails>();

            return new EdgeOrderItemDetails(
                productDetails,
                orderItemType,
                null,
                null,
                currentStage,
                orderItemStageHistory?.ToList(),
                preferences,
                forwardShippingDetails,
                reverseShippingDetails,
                notificationEmailList?.ToList(),
                cancellationReason,
                cancellationStatus,
                deletionStatus,
                returnReason,
                returnStatus,
                managementRPDetailsList?.ToList(),
                error,
                firstOrDefaultManagementResourceProviderNamespace != null ? new ResourceProviderDetails(firstOrDefaultManagementResourceProviderNamespace, serializedAdditionalRawData: null) : null,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ProductLine"/>. </summary>
        /// <param name="displayName"> Display Name for the product system. </param>
        /// <param name="description"> Description related to the product system. </param>
        /// <param name="imageInformation"> Image information for the product system. </param>
        /// <param name="costInformation"> Cost information for the product system. </param>
        /// <param name="availabilityInformation"> Availability information of the product system. </param>
        /// <param name="hierarchyInformation"> Hierarchy information of a product. </param>
        /// <param name="filterableProperties"> list of filters supported for a product. </param>
        /// <param name="products"> List of products in the product line. </param>
        /// <returns> A new <see cref="Models.ProductLine"/> instance for mocking. </returns>
        public static ProductLine ProductLine(string displayName = null, ProductDescription description = null, IEnumerable<EdgeOrderProductImageInformation> imageInformation = null, EdgeOrderProductCostInformation costInformation = null, ProductAvailabilityInformation availabilityInformation = null, HierarchyInformation hierarchyInformation = null, IEnumerable<FilterableProperty> filterableProperties = null, IEnumerable<EdgeOrderProduct> products = null)
        {
            imageInformation ??= new List<EdgeOrderProductImageInformation>();
            filterableProperties ??= new List<FilterableProperty>();
            products ??= new List<EdgeOrderProduct>();

            return new ProductLine(
                products?.ToList(),
                displayName,
                description,
                imageInformation?.ToList(),
                costInformation,
                availabilityInformation,
                hierarchyInformation,
                filterableProperties?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ProductFamily"/>. </summary>
        /// <param name="displayName"> Display Name for the product system. </param>
        /// <param name="description"> Description related to the product system. </param>
        /// <param name="imageInformation"> Image information for the product system. </param>
        /// <param name="costInformation"> Cost information for the product system. </param>
        /// <param name="availabilityInformation"> Availability information of the product system. </param>
        /// <param name="hierarchyInformation"> Hierarchy information of a product. </param>
        /// <param name="filterableProperties"> list of filters supported for a product. </param>
        /// <param name="productLines"> List of product lines supported in the product family. </param>
        /// <param name="resourceProviderDetails"> Contains details related to resource provider. </param>
        /// <returns> A new <see cref="Models.ProductFamily"/> instance for mocking. </returns>
        public static ProductFamily ProductFamily(string displayName = null, ProductDescription description = null, IEnumerable<EdgeOrderProductImageInformation> imageInformation = null, EdgeOrderProductCostInformation costInformation = null, ProductAvailabilityInformation availabilityInformation = null, HierarchyInformation hierarchyInformation = null, IEnumerable<FilterableProperty> filterableProperties = null, IEnumerable<ProductLine> productLines = null, IEnumerable<ResourceProviderDetails> resourceProviderDetails = null)
        {
            imageInformation ??= new List<EdgeOrderProductImageInformation>();
            filterableProperties ??= new List<FilterableProperty>();
            productLines ??= new List<ProductLine>();
            resourceProviderDetails ??= new List<ResourceProviderDetails>();

            return new ProductFamily(
                productLines?.ToList(),
                resourceProviderDetails?.ToList(),
                displayName,
                description,
                imageInformation?.ToList(),
                costInformation,
                availabilityInformation,
                hierarchyInformation,
                filterableProperties?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ProductFamiliesMetadata"/>. </summary>
        /// <param name="displayName"> Display Name for the product system. </param>
        /// <param name="description"> Description related to the product system. </param>
        /// <param name="imageInformation"> Image information for the product system. </param>
        /// <param name="costInformation"> Cost information for the product system. </param>
        /// <param name="availabilityInformation"> Availability information of the product system. </param>
        /// <param name="hierarchyInformation"> Hierarchy information of a product. </param>
        /// <param name="filterableProperties"> list of filters supported for a product. </param>
        /// <param name="productLines"> List of product lines supported in the product family. </param>
        /// <param name="resourceProviderDetails"> Contains details related to resource provider. </param>
        /// <returns> A new <see cref="Models.ProductFamiliesMetadata"/> instance for mocking. </returns>
        public static ProductFamiliesMetadata ProductFamiliesMetadata(string displayName = null, ProductDescription description = null, IEnumerable<EdgeOrderProductImageInformation> imageInformation = null, EdgeOrderProductCostInformation costInformation = null, ProductAvailabilityInformation availabilityInformation = null, HierarchyInformation hierarchyInformation = null, IEnumerable<FilterableProperty> filterableProperties = null, IEnumerable<ProductLine> productLines = null, IEnumerable<ResourceProviderDetails> resourceProviderDetails = null)
        {
            imageInformation ??= new List<EdgeOrderProductImageInformation>();
            filterableProperties ??= new List<FilterableProperty>();
            productLines ??= new List<ProductLine>();
            resourceProviderDetails ??= new List<ResourceProviderDetails>();

            return new ProductFamiliesMetadata(
                productLines?.ToList(),
                resourceProviderDetails?.ToList(),
                displayName,
                description,
                imageInformation?.ToList(),
                costInformation,
                availabilityInformation,
                hierarchyInformation,
                filterableProperties?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ProductDetails"/>. </summary>
        /// <param name="displayInfo"> Display details of the product. </param>
        /// <param name="hierarchyInformation"> Hierarchy of the product which uniquely identifies the product. </param>
        /// <param name="count"> Quantity of the product. </param>
        /// <param name="productDoubleEncryptionStatus"> Double encryption status of the configuration. Read-only field. </param>
        /// <param name="deviceDetails"> list of device details. </param>
        /// <returns> A new <see cref="Models.ProductDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ProductDetails ProductDetails(ProductDisplayInfo displayInfo = null, HierarchyInformation hierarchyInformation = null, int? count = null, DoubleEncryptionStatus? productDoubleEncryptionStatus = null, IEnumerable<EdgeOrderProductDeviceDetails> deviceDetails = null)
        {
            deviceDetails ??= new List<EdgeOrderProductDeviceDetails>();

            return new ProductDetails(
                displayInfo,
                hierarchyInformation,
                productDoubleEncryptionStatus,
                null, // identificationType
                deviceDetails?.ToList().FirstOrDefault(),
                null, // parentProvisioningDetails
                new ChangeTrackingList<AdditionalConfiguration>(),
                new ChangeTrackingList<ConfigurationDeviceDetails>(),
                null, // termCommitmentInformation
                count,
                deviceDetails?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.EdgeOrderProduct"/>. </summary>
        /// <param name="displayName"> Display Name for the product system. </param>
        /// <param name="description"> Description related to the product system. </param>
        /// <param name="imageInformation"> Image information for the product system. </param>
        /// <param name="costInformation"> Cost information for the product system. </param>
        /// <param name="availabilityInformation"> Availability information of the product system. </param>
        /// <param name="hierarchyInformation"> Hierarchy information of a product. </param>
        /// <param name="filterableProperties"> list of filters supported for a product. </param>
        /// <param name="configurations"> List of configurations for the product. </param>
        /// <returns> A new <see cref="Models.EdgeOrderProduct"/> instance for mocking. </returns>
        public static EdgeOrderProduct EdgeOrderProduct(string displayName = null, ProductDescription description = null, IEnumerable<EdgeOrderProductImageInformation> imageInformation = null, EdgeOrderProductCostInformation costInformation = null, ProductAvailabilityInformation availabilityInformation = null, HierarchyInformation hierarchyInformation = null, IEnumerable<FilterableProperty> filterableProperties = null, IEnumerable<ProductConfiguration> configurations = null)
        {
            imageInformation ??= new List<EdgeOrderProductImageInformation>();
            filterableProperties ??= new List<FilterableProperty>();
            configurations ??= new List<ProductConfiguration>();

            return new EdgeOrderProduct(
                configurations?.ToList(),
                displayName,
                description,
                imageInformation?.ToList(),
                costInformation,
                availabilityInformation,
                hierarchyInformation,
                filterableProperties?.ToList(),
                serializedAdditionalRawData: null);
        }
    }
}
