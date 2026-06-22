// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward-compat option-bag type. The previous (AutoRest-based) generator
    // produced "*Options" bags automatically when a method had more than 6
    // parameters. The new TypeSpec generator no longer emits option bags; instead
    // it produces a multi-parameter method directly. To preserve source/binary
    // compatibility we re-introduce the bag type here and add forwarding
    // overloads on ComputeExtensions / MockableComputeSubscriptionResource that
    // accept the bag and call the multi-parameter generated method.
    public partial class SubscriptionResourceGetVirtualMachineImagesOptions
    {
        /// <summary> Initializes a new instance of <see cref="SubscriptionResourceGetVirtualMachineImagesOptions"/>. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        public SubscriptionResourceGetVirtualMachineImagesOptions(AzureLocation location, string publisherName, string offer, string skus)
        {
            Location = location;
            PublisherName = publisherName;
            Offer = offer;
            Skus = skus;
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
        public string Expand { get; set; }
        /// <summary> An integer value specifying the number of images to return that matches supplied values. </summary>
        public int? Top { get; set; }
        /// <summary> Specifies the order of the results returned. Formatted as an OData query. </summary>
        public string Orderby { get; set; }
    }
}
