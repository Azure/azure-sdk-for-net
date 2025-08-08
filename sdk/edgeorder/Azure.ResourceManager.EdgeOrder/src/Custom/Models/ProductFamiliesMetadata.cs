// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    [CodeGenSerialization(nameof(DisplayName), new string[] { "properties", "displayName" })]
    [CodeGenSerialization(nameof(Description), new string[] { "properties", "description" })]
    [CodeGenSerialization(nameof(ImageInformation), new string[] { "properties", "imageInformation" })]
    [CodeGenSerialization(nameof(CostInformation), new string[] { "properties", "costInformation" })]
    [CodeGenSerialization(nameof(AvailabilityInformation), new string[] { "properties", "availabilityInformation" })]
    [CodeGenSerialization(nameof(HierarchyInformation), new string[] { "properties", "hierarchyInformation" })]
    [CodeGenSerialization(nameof(FilterableProperties), new string[] { "properties", "filterableProperties" })]
    public partial class ProductFamiliesMetadata
    {
        /// <summary> Display Name for the product system. </summary>
        public string DisplayName { get; }
        /// <summary> Description related to the product system. </summary>
        public ProductDescription Description { get; }
        /// <summary> Image information for the product system. </summary>
        public IReadOnlyList<EdgeOrderProductImageInformation> ImageInformation { get; }
        /// <summary> Cost information for the product system. </summary>
        public EdgeOrderProductCostInformation CostInformation { get; }
        /// <summary> Availability information of the product system. </summary>
        public ProductAvailabilityInformation AvailabilityInformation { get; }
        /// <summary> Hierarchy information of a product. </summary>
        public HierarchyInformation HierarchyInformation { get; }
        /// <summary> list of filters supported for a product. </summary>
        public IReadOnlyList<FilterableProperty> FilterableProperties { get; }
    }
}
