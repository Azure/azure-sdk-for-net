// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward-compat option-bag type re-introduced for source compatibility with
    // the previous (AutoRest-based) public surface. See sibling
    // SubscriptionResourceGetVirtualMachineImagesOptions.cs for full justification.
    public partial class SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions
    {
        /// <summary> Initializes a new instance of <see cref="SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions"/>. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        public SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions(AzureLocation location, string publisherName, string offer, string skus, GetVirtualMachineImagesWithPropertiesExpand expand)
        {
            Location = location;
            PublisherName = publisherName;
            Offer = offer;
            Skus = skus;
            Expand = expand;
        }

        /// <summary> Initializes a new instance of <see cref="SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions"/> using a raw expand-option string. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="expandOption"> The expand expression to apply on the operation, as a raw string value. </param>
        public SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions(AzureLocation location, string publisherName, string offer, string skus, string expandOption)
        {
            Location = location;
            PublisherName = publisherName;
            Offer = offer;
            Skus = skus;
            ExpandOption = expandOption;
        }

        /// <summary> The name of a supported Azure region. </summary>
        public AzureLocation Location { get; }
        /// <summary> A valid image publisher. </summary>
        public string PublisherName { get; }
        /// <summary> A valid image publisher offer. </summary>
        public string Offer { get; }
        /// <summary> A valid image SKU. </summary>
        public string Skus { get; }
        /// <summary> The expand expression to apply on the operation. </summary>
        public GetVirtualMachineImagesWithPropertiesExpand Expand { get; }
        /// <summary> The expand expression to apply on the operation, as a raw string value. </summary>
        public string ExpandOption { get; }
        /// <summary> An integer value specifying the number of images to return that matches supplied values. </summary>
        public int? Top { get; set; }
        /// <summary> Specifies the order of the results returned. Formatted as an OData query. </summary>
        public string Orderby { get; set; }

        // Returns the string the generated method expects. If a typed Expand was set
        // via the enum-based ctor, prefer it; otherwise use the raw ExpandOption.
        internal string GetExpandValue() => ExpandOption ?? Expand.ToString();
    }
}
