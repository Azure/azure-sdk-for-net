// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using ResourceManager.Fluent.Core;
    using Models;
    using Disk.Definition;

    /// <summary>
    /// The implementation for Disks.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uRGlza3NJbXBs
    internal partial class DisksImpl :
        GroupableResources<IDisk,
            DiskImpl,
            DiskInner,
            IDisksOperations, 
            IComputeManager>,
        IDisks
    {
        ///GENMHASH:6D37C99378AE377ECF5B67AC9088DAB3:872A681ED7AE386A7C237A1C77E3E12A
        internal DisksImpl(IComputeManager computeManager) : base(computeManager.Inner.Disks, computeManager)
        {
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:737180B1BC9FBD3E5083EE06E951D489
        public async override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:1BCE81BDD651175D2AF64E39F4F2C420:BFFE56CE1D59C3CA9284FED6EC0BD4DE
        public void RevokeAccess(string resourceGroupName, string diskName)
        {
            Inner.RevokeAccess(resourceGroupName, diskName);
        }

        ///GENMHASH:C2E2A5650639245BC0993A33DCAA5D61:5ED639AB5B297A577FFD766897FD02B8
        public string GrantAccess(string resourceGroupName, string diskName, AccessLevel accessLevel, int accessDuration)
        {
            GrantAccessDataInner grantAccessDataInner = new GrantAccessDataInner();
            grantAccessDataInner.Access = accessLevel;
            grantAccessDataInner.DurationInSeconds = accessDuration;
            AccessUriInner accessUriInner = Inner.GrantAccess(resourceGroupName,
                diskName, 
                grantAccessDataInner);
            return accessUriInner.AccessSAS;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:664BEF11BF4AA10D27449EE89EF181F3
        public IBlank Define(string name)
        {
            return this.WrapModel(name);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:D325A8AE4D96F3AFCF2E542EDFA900C6
        public async override Task<IDisk> GetByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            DiskInner inner = await Inner.GetAsync(resourceGroupName, name, cancellationToken);
            return WrapModel(inner);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:6FB4EA69673E1D8A74E1418EB52BB9FE
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IDisk> List()
        {
            var pagedList = new PagedList<DiskInner>(Inner.List(), (string nextPageLink) =>
            {
                return Inner.ListNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:F27988875BD81EE531DA23D26C675612
        public PagedList<IDisk> ListByGroup(string resourceGroupName)
        {
            var pagedList = new PagedList<DiskInner>(Inner.ListByResourceGroup(resourceGroupName), (string nextPageLink) =>
            {
                return Inner.ListByResourceGroupNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:37323FCC616B8746EEBA6B2152BF1DA6
        protected override DiskImpl WrapModel(string name)
        {
            return new DiskImpl(name, new DiskInner(), Manager);
        }

        ///GENMHASH:943063AEBCC7240660ED1B045E340B9C:5E0539B7C0A06A24BFDFF3DD193A9746
        protected override IDisk WrapModel(DiskInner inner)
        {
            return new DiskImpl(inner.Name, inner, Manager);
        }
    }
}