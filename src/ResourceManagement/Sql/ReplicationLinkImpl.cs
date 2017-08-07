// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;
    using System;
    using ResourceManager.Fluent.Core.ResourceActions;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// Implementation for SqlServer and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5SZXBsaWNhdGlvbkxpbmtJbXBs
    internal partial class ReplicationLinkImpl :
        IndexableRefreshableWrapper<IReplicationLink, ReplicationLinkInner>,
        IReplicationLink
    {
        private IDatabasesOperations innerCollection;
        private ResourceId resourceId;

        ///GENMHASH:59D8987F7EC078423F8247D1F7D40FBD:D2670680EF14BA9058384CB186AA4289
        public string ReplicationState()
        {
            return Inner.ReplicationState;
        }

        ///GENMHASH:7DDE9B1BB82467D17BDE73EEF70FC15A:FD23977BD91FE98C3065B6E757B7B31A
        public ReplicationRole Role()
        {
            return Inner.Role.GetValueOrDefault();
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:9FE42D967416923E070F823D07063A47
        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        ///GENMHASH:E7ABDAFE895DE30905D46D515062DB59:4FF2FEC4B193B40F5666C7C0244DEB2E
        public string DatabaseName()
        {
            return resourceId.Parent.Name;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:1DE3B7D49F042BF9BD713FC79256757A
        public string SqlServerName()
        {
            return resourceId.Parent.Parent.Name;
        }

        ///GENMHASH:A6FB40DB55DA08C2751F5BBFFCD06BA6:0BD76FC865DFF06EA7CB878F1666969B
        public string PartnerServer()
        {
            return Inner.PartnerServer;
        }

        ///GENMHASH:663AECE9E2B94E49177C45542A675796:6FCFDC6E0E888975E162F9E3A6690673
        public ReplicationRole PartnerRole()
        {
            return Inner.PartnerRole.GetValueOrDefault();
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:A7F868EA1D284A335598127348D0A1AD
        protected override async Task<ReplicationLinkInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await this.innerCollection.GetReplicationLinkAsync(this.ResourceGroupName(),
            this.SqlServerName(),
            this.DatabaseName(),
            this.Name(), cancellationToken: cancellationToken);
        }

        ///GENMHASH:64FDD7DAC0F2CAB9406652DA7545E8AA:3F5BF88EAEB847CE67B8C16A5FDD2D28
        public int PercentComplete()
        {
            return Inner.PercentComplete.GetValueOrDefault();
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:5DF2D34B34E97D7C050D4229F8A0ABE1
        public void Delete()
        {
            Extensions.Synchronize(() => this.innerCollection.DeleteReplicationLinkAsync(
                        this.ResourceGroupName(),
                        this.SqlServerName(),
                        this.DatabaseName(),
                        this.Name()));
        }

        ///GENMHASH:DD6979366C7B4F3C6845144DBE9E011A:E0A904BDF0C6E5F4C37230C1174B190E
        public void ForceFailoverAllowDataLoss()
        {
            Extensions.Synchronize(() => ForceFailoverAllowDataLossAsync());
        }
        public async Task ForceFailoverAllowDataLossAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.innerCollection.FailoverReplicationLinkAllowDataLossAsync(
                this.ResourceGroupName(),
                this.SqlServerName(),
                this.DatabaseName(),
                this.Name(),
                cancellationToken);
        }

        ///GENMHASH:EE0BD4E72D19A69170DA4CD2D7DA10B4:271A8BBAC31D775322091915FE56A406
        internal ReplicationLinkImpl(ReplicationLinkInner innerObject, IDatabasesOperations innerCollection)
            : base(innerObject.Name, innerObject)
        {
            this.resourceId = ResourceId.FromString(Inner.Id);
            this.innerCollection = innerCollection;
        }

        ///GENMHASH:75146396042F3B3D55B973EBEDF73CD2:6BA113CAE218C7605AC4729294DDB001
        public void Failover()
        {
            Extensions.Synchronize(() => FailoverAsync());
        }
        public async Task FailoverAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.innerCollection.FailoverReplicationLinkAsync(
                this.ResourceGroupName(),
                this.SqlServerName(),
                this.DatabaseName(),
                this.Name(),
                cancellationToken);
        }

        ///GENMHASH:D1AA514022A702178FC60111EBA279F9:23D982D34E0AA0229B0409AE0E6C9099
        public string PartnerDatabase()
        {
            return Inner.PartnerDatabase;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:A08302619254C2A4BBCEC7165449AD96
        public string Name()
        {
            return this.resourceId.Name;
        }

        ///GENMHASH:8550B4F26F41D82222F735D9324AEB6D:42AE1A0453935D9BF88147F2F9C3EC20
        public DateTime StartTime()
        {
            return Inner.StartTime.GetValueOrDefault();
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:003E1843567E7760DFADC015F30E6AF4
        public string Id()
        {
            return this.resourceId.Id;
        }

        ///GENMHASH:868B2F3C33B56DD970703291B23E174D:DF14267C442E5344D77EF314AD1B4A87
        public string PartnerLocation()
        {
            return Inner.PartnerLocation;
        }
    }
}
