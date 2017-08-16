// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The implementation for VirtualMachineImage.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVJbWFnZUltcGw=
    internal partial class VirtualMachineImageImpl :
        IndexableWrapper<VirtualMachineImageInner>,
        IVirtualMachineImage
    {
        private Region location;
        private ImageReference imageReference;
        ///GENMHASH:3037DFCA1BCDE07672005B139B094F10:0578F9D5B08EF1856822AB6B7B18110E
        internal VirtualMachineImageImpl(Region location, string publisher, string offer, string sku, string version)
            : base(null)
        {
            this.location = location;
            ///GENMHASH:FD3E0F0AD8E30CCC81844784FA2869A4:5B94A718C46B69AD383734512FB0562D
            this.imageReference = new ImageReference
            {
                Publisher = publisher,
                Offer = offer,
                Sku = sku,
                Version = version
            };
        }

        ///GENMHASH:CAB6054620B9FCCB39E850FA6DA1DC9E:D5C70E9798250262CE50A31D1767529C
        internal VirtualMachineImageImpl(
            Region location,
            string publisher,
            string offer,
            string sku,
            string version,
            VirtualMachineImageInner inner) 
            : base(inner)
        {
            this.location = location;
            this.imageReference = new ImageReference
            {
                Publisher = publisher,
                Offer = offer,
                Sku = sku,
                Version = version
            };
        }

        ///GENMHASH:467A5E1DBEFF6DFFFD3FD21A958498A3:AD62B7CD7788055CCE7DF3AC1125614D
        public IReadOnlyDictionary<int, DataDiskImage> DataDiskImages()
        {
            if (Inner.DataDiskImages == null)
            {
                return new Dictionary<int, DataDiskImage>();
            }
            Dictionary<int, DataDiskImage> diskImages = new Dictionary<int, DataDiskImage>();
            foreach (var diskImage in Inner.DataDiskImages)
            {
                if (diskImage.Lun.HasValue)
                {
                    diskImages.Add(diskImage.Lun.Value, diskImage);
                }
            }
            return diskImages;
        }

        public ImageReference ImageReference()
        {
            return this.imageReference;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:7DECE31892F905458F7A5F7C5B963D8F
        public string Id()
        {
            if (Inner == null) {
                return null;
            }
            return Inner.Id;
        }

        ///GENMHASH:A85BBC58BA3B783F90EB92B75BD97D51:B0F0BE5FE7AB84929ACF2368E8415A69
        public Region Location()
        {
            return this.location;
        }

        ///GENMHASH:C45A9968A03993B152B3E8DC4FD3A429:3B4EAE5C3184CFE696A886744083B492
        public string Offer()
        {
            return this.imageReference.Offer;
        }

        ///GENMHASH:9E984BEB4133DD0B3AA842B63D7D77AC:6D8F2FF773E3B310A12FB550BBF5501D
        public OSDiskImage OSDiskImage()
        {
            return Inner.OsDiskImage;
        }

        ///GENMHASH:283A7CD491ABC476D6646B943D8641A8:BB7251641858D1CBEADD4ABE2AF921D3
        public PurchasePlan Plan()
        {
            return Inner.Plan;
        }

        ///GENMHASH:06BBF1077FAA38CC78AFC6E69E23FB58:5D28523A513481A96A35A0B72BDA3B43
        public string PublisherName()
        {
            return this.imageReference.Publisher;
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:D2CE592B8121C94F66EBE0B912033A17
        public string Sku()
        {
            return this.imageReference.Sku;
        }

        ///GENMHASH:493B1EDB88EACA3A476D936362A5B14C:CA9319D6738937BD76EDD7EDAA0ECA55
        public string Version()
        {
            return this.imageReference.Version;
        }
    }
}
