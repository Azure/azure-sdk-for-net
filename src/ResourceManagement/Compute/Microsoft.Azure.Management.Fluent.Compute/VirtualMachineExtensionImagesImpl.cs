// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using System;

    /// <summary>
    /// The implementation for {@link VirtualMachineExtensionImages}.
    /// </summary>
    internal partial class VirtualMachineExtensionImagesImpl  :
        IVirtualMachineExtensionImages
    {
        private IVirtualMachinePublishers publishers;
        internal  VirtualMachineExtensionImagesImpl (IVirtualMachinePublishers publishers)
        {
            this.publishers = publishers;
        }

        public PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage> ListByRegion (Region region)
        {
            return ListByRegion(EnumNameAttribute.GetName(region));
        }

        public PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage> ListByRegion (string regionName)
        {

            PagedList<IVirtualMachinePublisher> publishers = Publishers().ListByRegion(regionName);

            PagedList<IVirtualMachineExtensionImageType> types = new ChildListFlattener<IVirtualMachinePublisher, IVirtualMachineExtensionImageType>(publishers,
                (IVirtualMachinePublisher publisher) =>
                {
                    return publisher.ExtensionTypes().List();
                }).Flatten();

            PagedList<IVirtualMachineExtensionImageVersion> versions = new ChildListFlattener<IVirtualMachineExtensionImageType, IVirtualMachineExtensionImageVersion>(types,
                (IVirtualMachineExtensionImageType type) =>
                {
                    return type.Versions.List();
                }).Flatten();

            return PagedListConverter.Convert(versions, version => {
                return version.Image();
            });
        }

        public IVirtualMachinePublishers Publishers ()
        {
            return this.publishers;
        }
    }
}