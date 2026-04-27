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
        public SubscriptionResourceGetVirtualMachineImagesOptions(AzureLocation location, string publisherName, string offer, string skus)
        {
            Location = location;
            PublisherName = publisherName;
            Offer = offer;
            Skus = skus;
        }

        public AzureLocation Location { get; }
        public string PublisherName { get; }
        public string Offer { get; }
        public string Skus { get; }
        public string Expand { get; set; }
        public int? Top { get; set; }
        public string Orderby { get; set; }
    }
}
