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
        public SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions(AzureLocation location, string publisherName, string offer, string skus, GetVirtualMachineImagesWithPropertiesExpand expand)
        {
            Location = location;
            PublisherName = publisherName;
            Offer = offer;
            Skus = skus;
            Expand = expand;
        }

        public SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions(AzureLocation location, string publisherName, string offer, string skus, string expandOption)
        {
            Location = location;
            PublisherName = publisherName;
            Offer = offer;
            Skus = skus;
            ExpandOption = expandOption;
        }

        public AzureLocation Location { get; }
        public string PublisherName { get; }
        public string Offer { get; }
        public string Skus { get; }
        public GetVirtualMachineImagesWithPropertiesExpand Expand { get; }
        public string ExpandOption { get; }
        public int? Top { get; set; }
        public string Orderby { get; set; }

        // Returns the string the generated method expects. If a typed Expand was set
        // via the enum-based ctor, prefer it; otherwise use the raw ExpandOption.
        internal string GetExpandValue() => ExpandOption ?? Expand.ToString();
    }
}
