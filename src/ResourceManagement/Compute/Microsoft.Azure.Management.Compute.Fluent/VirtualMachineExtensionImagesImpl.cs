// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Resource.Fluent.Core;

    /// <summary>
    /// The implementation for VirtualMachineExtensionImages.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFeHRlbnNpb25JbWFnZXNJbXBs
    internal partial class VirtualMachineExtensionImagesImpl  :
        IVirtualMachineExtensionImages
    {
        private IVirtualMachinePublishers publishers;

        ///GENMHASH:5CB92C08673ABFA2D2A7D4213EB2D305:FA897FEBD514346FC3C576EAB52CCC9D
        internal VirtualMachineExtensionImagesImpl(IVirtualMachinePublishers publishers)
        {
            this.publishers = publishers;
        }

        ///GENMHASH:BA2FEDDF9D78BF55786D81F6C85E907C:CD5A589A9B297BE134944F6A531D30E8
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage> ListByRegion(Region region)
        {
            return ListByRegion(region.Name);
        }

        ///GENMHASH:360BB74037893879A730ED7ED0A3938A:639E5895B91E59F5F02E157A874115D1
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage> ListByRegion(string regionName)
        {

            PagedList<IVirtualMachinePublisher> publishers = Publishers().ListByRegion(regionName);

            PagedList<IVirtualMachineExtensionImageType> types = new ChildListFlattener<IVirtualMachinePublisher, IVirtualMachineExtensionImageType>(publishers,
                (IVirtualMachinePublisher publisher) =>
                {
                    return publisher.ExtensionTypes.List();
                }).Flatten();

            PagedList<IVirtualMachineExtensionImageVersion> versions = new ChildListFlattener<IVirtualMachineExtensionImageType, IVirtualMachineExtensionImageVersion>(types,
                (IVirtualMachineExtensionImageType type) =>
                {
                    return type.Versions.List();
                }).Flatten();

            return PagedListConverter.Convert(versions, version => {
                return version.GetImage();
            });
        }

        ///GENMHASH:0BEBF248F53E3703454D841A5CB0C8BD:F1262C25E062855DE7A22FF21A820919
        public IVirtualMachinePublishers Publishers()
        {
            return this.publishers;
        }
    }
}