// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition;
    using Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for Packet Capture and its create and update interfaces.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUGFja2V0Q2FwdHVyZUltcGw=
    internal partial class PacketCaptureImpl  :
        Creatable<IPacketCapture,PacketCaptureResultInner,PacketCaptureImpl,IPacketCapture>,
        IPacketCapture,
        PacketCapture.Definition.IDefinition
    {
        private IPacketCapturesOperations client;
        private PacketCaptureInner createParameters;
        private INetworkWatcher parent;
        
        ///GENMHASH:AD5F8C8D5C6FAC34FAB0514B40C35462:45B7A6FB59405062F295ED24954B5FB9
        internal void AttachPCFilter(PCFilterImpl pcFilter)
        {
            if (createParameters.Filters == null) {
                createParameters.Filters = new List<PacketCaptureFilter>();
            }
            createParameters.Filters.Add(pcFilter.Inner);
        }

        
        ///GENMHASH:312924BF70BF0CB2274356670D3FCAD7:D0CF5C6B3397E40398F445F35BF6048F
        public PacketCaptureStorageLocation StorageLocation()
        {
            return Inner.StorageLocation;
        }

        
        ///GENMHASH:25941804086E52163BC33944A2FAC34F:B4CF07412D871BC54604665642E679CA
        public IPacketCaptureStatus GetStatus()
        {
            return Extensions.Synchronize(() => GetStatusAsync(CancellationToken.None));
        }

        
        ///GENMHASH:2357B38E494D9F10171A28E135CB1715:3961EA7B900ECE15CB8B6D76F00F665B
        internal  PacketCaptureImpl(string name, NetworkWatcherImpl parent, PacketCaptureResultInner innerObject, IPacketCapturesOperations client)
            : base(name, innerObject)
        {
            this.client = client;
            this.parent = parent;
            this.createParameters = new PacketCaptureInner();
        }

        
        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:754810EA5144700BBB078C6E55E8C153
        protected override async Task<PacketCaptureResultInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.client.GetAsync(parent.ResourceGroupName, parent.Name, Name);
        }

        
        ///GENMHASH:FE79E38E5D355183291E05FDB7F83D32:23F12F778E8DFA411BF85F0AF1E01886
        public IWithCreate WithStoragePath(string storagePath)
        {
            createParameters.StorageLocation.StoragePath = storagePath;
            return this;
        }

        
        ///GENMHASH:EBDC67617D32626C5B99D7F3CE1D33C3:6908653121E5F21D8FDA04D66FEFE581
        public PacketCaptureImpl WithBytesToCapturePerPacket(int bytesToCapturePerPacket)
        {
            createParameters.BytesToCapturePerPacket = bytesToCapturePerPacket;
            return this;
        }

        
        ///GENMHASH:F2B064A3B5CACCED7E15D9312A326AF9:3819295FA44155AD5379627305E6D27D
        public PacketCaptureImpl WithTimeLimitInSeconds(int timeLimitInSeconds)
        {
            createParameters.TimeLimitInSeconds = timeLimitInSeconds;
            return this;
        }

        
        ///GENMHASH:6CBF2D0A589B76ADE7F54B81F32D32B0:A63D6B9A42FB11AC0D5DB23382DEFAC4
        public PacketCaptureImpl WithFilePath(string filePath)
        {
            EnsureStorageLocation();
            createParameters.StorageLocation.FilePath = filePath;
            return this;
        }

        
        ///GENMHASH:3A9DEB5DB40432C66B95231CF6DB711B:438B160CE5A38AD636556A43EA40454F
        public PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate> DefinePacketCaptureFilter()
        {
            return new PCFilterImpl(new PacketCaptureFilter(),  this);
        }

        
        ///GENMHASH:D6FBED7FC7CBF34940541851FF5C3CC1:F5D6CDA97EA3E1877403AB883B63FBEC
        public async Task StopAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await client.StopAsync(parent.ResourceGroupName, parent.Name, Name);
        }

        
        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:A3CF7B3DC953F353AAE8083D72F74056
        public string Id()
        {
            return Inner.Id;
        }

        
        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:F76D810CABB51B3EECF2D1A748972F50
        public override async Task<IPacketCapture> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var packetCaptureInner = await this.client.CreateAsync(parent.ResourceGroupName, parent.Name, this.Name, createParameters);
            SetInner(packetCaptureInner);
            return this;

        }

        
        ///GENMHASH:C7AB6E06A7424B1A194803B9898CBA6E:61A2301CE073933CA4D1216222B9D642
        public PacketCaptureImpl WithTarget(string target)
        {
            createParameters.Target = target;
            return this;
        }

        
        ///GENMHASH:66B8723EC1C7D801A0BAD4D728E73E3B:3F9135058B33FB9EB4D4F5730DD3A411
        public PacketCaptureImpl WithStorageAccountId(string storageId)
        {
            EnsureStorageLocation();
            createParameters.StorageLocation.StorageId = storageId;
            return this;
        }

        private void EnsureStorageLocation()
        {
            PacketCaptureStorageLocation storageLocation = createParameters.StorageLocation;
            if (storageLocation == null)
            {
                createParameters.StorageLocation = new PacketCaptureStorageLocation();
            }
        }

        
        ///GENMHASH:78DF4F901F21A657D01F74A52C544710:655162C88FE2198B3A7136D452199C52
        public async Task<Microsoft.Azure.Management.Network.Fluent.IPacketCaptureStatus> GetStatusAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await client.GetStatusAsync(parent.ResourceGroupName, parent.Name, Name);
            return new PacketCaptureStatusImpl(result);
        }

        
        ///GENMHASH:489E3F2E5B9A682915B3CE8574961B81:DB50A02B724E3CF903DB29B7C76A82B5
        public PacketCaptureImpl WithTotalBytesPerSession(int totalBytesPerSession)
        {
            createParameters.TotalBytesPerSession = totalBytesPerSession;
            return this;
        }

        
        ///GENMHASH:345C2E689D54706DEA550F19BEFDFF33:3CC692393857371CADD3A0EF3687C595
        public string TargetId()
        {
            return Inner.Target;
        }

        
        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:19C4BD8FCE58F39FC1CCEB1A6C862717
        public bool IsInCreateMode()
        {
            return Inner.Id == null;
        }

        
        ///GENMHASH:D768B327B35A9791788E1A52CD700EEC:088F9AA90F1C6A051D54C7F70C6E2386
        public int TimeLimitInSeconds()
        {
            return (Inner.TimeLimitInSeconds.HasValue) ? Inner.TimeLimitInSeconds.Value : 0;
        }

        
        ///GENMHASH:EB3E88F3268B3D59E7C9F0586E24F599:9DDE92EC7BD6C54A24F4460E6383E146
        public int BytesToCapturePerPacket()
        {
            return (Inner.BytesToCapturePerPacket.HasValue) ? Inner.TimeLimitInSeconds.Value : 0;
        }

        
        ///GENMHASH:B93FB54B52C6F032C40EC8A51EF98D82:2581991E59EF8A81890738E86EDB4DE3
        public IReadOnlyList<Models.PacketCaptureFilter> Filters()
        {
            return Inner.Filters.ToList().AsReadOnly();
        }

        
        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:3DB04077E6BABC0FB5A5ACDA19D11309
        public ProvisioningState ProvisioningState()
        {
            return Models.ProvisioningState.Parse(Inner.ProvisioningState);
        }

        
        ///GENMHASH:94385C6094CA3D4D87CE93E7F2E670A2:15BADB04EC677F04F1FFBC2B34BFFC0D
        public int TotalBytesPerSession()
        {
            if (Inner.TotalBytesPerSession == null)
            {
                return 0;
            }
            return Inner.TotalBytesPerSession.Value;
        }

        
        ///GENMHASH:EB854F18026EDB6E01762FA4580BE789:42462B796F15B0EB6E603ACA753873C0
        public void Stop()
        {
            Extensions.Synchronize(() => StopAsync(CancellationToken.None));
        }
    }
}
