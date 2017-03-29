// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using ResourceManager.Fluent.Core;
    using VirtualMachineCustomImage.Definition;
    using Models;

    /// <summary>
    /// The implementation for VirtualMachineCustomImages.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVDdXN0b21JbWFnZXNJbXBs
    internal partial class VirtualMachineCustomImagesImpl  :
        GroupableResources<
            IVirtualMachineCustomImage,
            VirtualMachineCustomImageImpl,
            ImageInner,
            IImagesOperations,
            IComputeManager>,
        IVirtualMachineCustomImages
    {
        ///GENMHASH:6A8C3AA1368511D4E81A72BFE585DB51:872A681ED7AE386A7C237A1C77E3E12A
        internal  VirtualMachineCustomImagesImpl(ComputeManager computeManager) : base(computeManager.Inner.Images, computeManager)
        {
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:737180B1BC9FBD3E5083EE06E951D489
        public async override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:664BEF11BF4AA10D27449EE89EF181F3
        public IBlank Define(string name)
        {
            return this.WrapModel(name);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:0DA05B447E9373BA84F249FC22D8EDFF
        public async override Task<IVirtualMachineCustomImage> GetByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Inner.GetAsync(resourceGroupName, name, null, cancellationToken);
            return WrapModel(inner);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:6FB4EA69673E1D8A74E1418EB52BB9FE
        public PagedList<IVirtualMachineCustomImage> List()
        {
            var pagedList = new PagedList<ImageInner>(Inner.List(), (string nextPageLink) =>
            {
                return Inner.ListNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:F27988875BD81EE531DA23D26C675612
        public PagedList<IVirtualMachineCustomImage> ListByGroup(string resourceGroupName)
        {
            var pagedList = new PagedList<ImageInner>(Inner.ListByResourceGroup(resourceGroupName), (string nextPageLink) =>
            {
                return Inner.ListByResourceGroupNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:EB96DF7C77547AEAC01FB2D702838F18
        protected override VirtualMachineCustomImageImpl WrapModel(string name)
        {
            return new VirtualMachineCustomImageImpl(name, new ImageInner(), Manager);
        }

        ///GENMHASH:88D8001BD70F8778E738FCD90AAC6393:2316F6D4021A1DA94B0CD48DF822F2CD
        protected override IVirtualMachineCustomImage WrapModel(ImageInner inner)
        {
            return new VirtualMachineCustomImageImpl(inner.Name, inner, Manager);
        }
    }
}