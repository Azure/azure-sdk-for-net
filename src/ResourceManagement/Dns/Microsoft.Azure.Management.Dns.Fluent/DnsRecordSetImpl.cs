// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Threading;
    using DnsRecordSet.UpdateDefinition;
    using DnsRecordSet.Definition;
    using DnsRecordSet.UpdateCombined;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;
    using Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation of DnsRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5EbnNSZWNvcmRTZXRJbXBs
    internal abstract partial class DnsRecordSetImpl  :
        ExternalChildResource<IDnsRecordSet, RecordSetInner, IDnsZone, DnsZoneImpl>,
        IDnsRecordSet,
        IDefinition<DnsZone.Definition.IWithCreate>,
        IUpdateDefinition<DnsZone.Update.IUpdate>,
        IUpdateCombined
    {
        protected IRecordSetsOperations client;
        protected RecordSetInner recordSetRemoveInfo;

        ///GENMHASH:4F856FB578CC3E1352902BE5686B7CC9:D624DD59AB1913F5FF4AECA70621F115
        private RecordSetInner Prepare(RecordSetInner resource)
        {
            if (this.recordSetRemoveInfo.Metadata.Count > 0)
            {
                if (resource.Metadata != null)
                {
                    foreach(var key in this.recordSetRemoveInfo.Metadata.Keys)
                    {
                        if (resource.Metadata.ContainsKey(key))
                        {
                            resource.Metadata.Remove(key);
                        }
                    }
                }
                this.recordSetRemoveInfo.Metadata.Clear();
            }

            if (this.Inner.Metadata != null && this.Inner.Metadata.Count > 0)
            {
                if (resource.Metadata == null)
                {
                    resource.Metadata = new Dictionary<string, string>();
                }

                foreach (var keyVal in this.Inner.Metadata)
                {
                    resource.Metadata.Add(keyVal.Key, keyVal.Value);
                }
                this.Inner.Metadata.Clear();
            }
             
            if (this.Inner.TTL != null)
            {
                resource.TTL = this.Inner.TTL;
                this.Inner.TTL = null;
            }
            return PrepareForUpdate(resource);
        }

        ///GENMHASH:12F281B8230A0FD8CE8A0DF277EF885D:DF7D49CE4CC74DB0E5D593989B78CB8D
        public IReadOnlyDictionary<string,string> Metadata()
        {
            if (this.Inner.Metadata == null)
            {
                return new Dictionary<string, string>();
            }
            else
            {
                return this.Inner.Metadata as Dictionary<string, string>;
            }
        }

        ///GENMHASH:F9C01790C5D58B1748BB35183FF3B0D8:5457AA11A0051BA4663F3248B60D5E39
        private async Task<IDnsRecordSet> CreateOrUpdateAsync(RecordSetInner resource, CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner inner = await this.client.CreateOrUpdateAsync(this.Parent.ResourceGroupName, this.Parent.Name, 
                this.Name(),
                this.RecordType(),
                resource);
            this.SetInner(inner);
            return this;
        }

        ///GENMHASH:FB0C10CB41D7B922FF0580521AB216A6:8CAEADA4A5AF9EE51022E3AACA965264
        public DnsRecordSetImpl WithRecord(string target, int port, int priority, int weight)
        {
            this.Inner.SrvRecords
                .Add(new SrvRecord { Target = target, Port = port, Priority = priority, Weight = weight });
            return this;
        }

        ///GENMHASH:2929561387ABF878940284424229C907:DC4598B10EC964C77018370FF2C1D2C2
        public DnsRecordSetImpl WithoutMailExchange(string mailExchangeHostName, int priority)
        {
            this.recordSetRemoveInfo.MxRecords
                .Add(new MxRecord { Exchange = mailExchangeHostName, Preference = priority });
            return this;
        }

        ///GENMHASH:449585720E8D8C838341BFC3501A2C54:445B56F8A7E0DD6E4B2F2B7EAB7A7AE2
        public DnsRecordSetImpl WithoutNameServer(string nameServerHostName)
        {
            this.recordSetRemoveInfo.NsRecords
                .Add(new NsRecord { Nsdname = nameServerHostName });
            return this;
        }

        ///GENMHASH:F55643C465E2111FF58A74CD2FC02F67:E726662DDC93F264FBEC106CADBCFF38
        public DnsRecordSetImpl WithNegativeResponseCachingTimeToLiveInSeconds(long negativeCachingTimeToLive)
        {
            this.Inner.SoaRecord.MinimumTtl = negativeCachingTimeToLive;
            return this;
        }

        ///GENMHASH:32A8B56FE180FA4429482D706189DEA2:18B12FED433DF6A1F3CA0DD1940B789C
        public override async Task<IDnsRecordSet> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await CreateOrUpdateAsync(this.Inner);
        }

        ///GENMHASH:7126FE6FA387F1E4960F18681C53EC88:B90619A2787B110ED29E0558824FCEEC
        public DnsRecordSetImpl WithTargetDomainName(string targetDomainName)
        {
            this.Inner.PtrRecords
                .Add(new PtrRecord { Ptrdname = targetDomainName });
            return this;
        }

        ///GENMHASH:C37DFCF6F901676D7598649C45DBE65D:E77E730F4D50475504074AA0691BCCC8
        public DnsRecordSetImpl WithoutTargetDomainName(string targetDomainName)
        {
            this.recordSetRemoveInfo.PtrRecords
                .Add(new PtrRecord { Ptrdname = targetDomainName });
            return this;
        }

        ///GENMHASH:2C0DB6B1F104247169DC6BCC9246747C:FD4CF3518891ACD11184E48644DB2B2F
        public long TimeToLive()
        {
            return this.Inner.TTL.Value;
        }

        ///GENMHASH:EC29C72674344ADABB3A944C3E2479DB:5ED48E280A79185C34BAD7FC806CCBB5
        public DnsRecordSetImpl WithoutIpv4Address(string ipv4Address)
        {
            this.recordSetRemoveInfo.ARecords
                .Add(new ARecord { Ipv4Address = ipv4Address });
            return this;
        }

        ///GENMHASH:504BA34CAE2BA25152B7E5B0E29E8C87:5DA00DC8D7A2405A86C3DDBFD2B0DDC7
        public DnsRecordSetImpl WithoutIpv6Address(string ipv6Address)
        {
            this.recordSetRemoveInfo.AaaaRecords
                .Add(new AaaaRecord { Ipv6Address = ipv6Address });
            return this;
        }

        ///GENMHASH:EF847E8C645CB64D66F22F7C8F41EADF:668CAC97ECB380171D891C73BE38F63B
        public DnsRecordSetImpl WithSerialNumber(long serialNumber)
        {
            this.Inner.SoaRecord.SerialNumber = serialNumber;
            return this;
        }

        ///GENMHASH:40C52B3E2D072BD6B513ECBCC98E4F0B:C889D9872204B3122BF5D527764173CC
        public DnsRecordSetImpl WithoutMetadata(string key)
        {
            this.recordSetRemoveInfo.Metadata.Add(key, null);
            return this;
        }

        ///GENMHASH:0CFE78AB79C5BF41808567966F348D74:F96F4FA644159C0CD0EBB1C5B9EEF1A0
        public DnsRecordSetImpl WithIpv6Address(string ipv6Address)
        {
            this.Inner.AaaaRecords
                .Add(new AaaaRecord { Ipv6Address =ipv6Address });
            return this;
        }

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:27E486AB74A10242FF421C0798DDC450
        protected abstract RecordSetInner PrepareForUpdate(RecordSetInner resource);

        ///GENMHASH:C99F2F80022268E13D703B3379BD3B58:E0FC813C874E3B3480E4DA74E4253BCC
        public DnsRecordSetImpl WithIpv4Address(string ipv4Address)
        {
            this.Inner.ARecords.Add(new ARecord { Ipv4Address = ipv4Address });
            return this;
        }

        ///GENMHASH:4B07DB88181953A1AA185580F8B1266A:B3424C4783A914D6F340B7301EAFAE8E
        public DnsRecordSetImpl WithRetryTimeInSeconds(long retryTimeInSeconds)
        {
            this.Inner.SoaRecord.RetryTime = retryTimeInSeconds;
            return this;
        }

        ///GENMHASH:B691CFA349658CF97DA3EBA649A8ADB3:B05F9E0B8B96C671F86EA89FD77BF7DA
        public override string ChildResourceKey
        {
            get
            {
                return this.Name() + "_" + this.RecordType().ToString();
            }
        }

        ///GENMHASH:F08598A17ADD014E223DFD77272641FF:0D896236D48569C34CE1A91B25C2906D
        public override async Task<IDnsRecordSet> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner resource = await this.client.GetAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name(),
                this.RecordType(),
                cancellationToken);
            resource = this.Prepare(resource);
            return await this.CreateOrUpdateAsync(resource);
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:43D11CBDAF5A13A288B18B4C8884B621
        public string Id
        {
            get
            {
                return Inner.Id;
            }
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:8FF06E289719BB519BDB4F57C1488F6F
        public DnsZoneImpl Attach()
        {
            return this.Parent;
        }

        ///GENMHASH:6D37E4EB187608D1444EE0B12AEEAB67:4B5F1BDCC88474FFF19319243A41B6F7
        public DnsRecordSetImpl WithRefreshTimeInSeconds(long refreshTimeInSeconds)
        {
            this.Inner.SoaRecord.RefreshTime = refreshTimeInSeconds;
            return this;
        }

        ///GENMHASH:E8E20943CC1653864072EDF514EE642D:10153E6B4A158154E1E8933759138F87
        public DnsRecordSetImpl WithEmailServer(string emailServerHostName)
        {
            this.Inner.SoaRecord.Email = emailServerHostName;
            return this;
        }

        ///GENMHASH:B9A12A61DE5C3FD7372657598F28C736:ED60A90C82E8718F17C634907FC0D9F7
        public DnsRecordSetImpl WithoutText(string text)
        {
            List<string> value = new List<string>();
            value.Add(text);
            this.recordSetRemoveInfo.TxtRecords
                .Add(new TxtRecord { Value = value });
            return this;
        }

        ///GENMHASH:3802EA6243E9AF80A622FF944E74B5EA:8520CAFB7CB8489C528CA99FBB8E0916
        public RecordType RecordType()
        {
            return (RecordType) Enum.Parse(typeof(RecordType), this.Inner.Type);
        }

        ///GENMHASH:A8504DD39B3F14EC8A5C6530FB22292A:5BA5A4ACBB2C6A840606E1F8F35C4054
        public DnsRecordSetImpl WithMetadata(string key, string value)
        {
            if (this.Inner.Metadata == null)
            {
                this.Inner.Metadata = new Dictionary<string, string>();
            }
            if (!this.Inner.Metadata.ContainsKey(key))
            {
                this.Inner.Metadata.Add(key, value);
            }
            return this;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:4A10213038743768C271AE3184DC5B16
        public IDnsRecordSet Refresh()
        {
            this.SetInner(this.client.Get(this.Parent.ResourceGroupName, 
                this.Parent.Name, 
                this.Name(), 
                this.RecordType()));
            return this;
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:4983E2059828207A0EBDD76459661F4B
        public override async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.client.DeleteAsync(this.Parent.ResourceGroupName,
                this.Parent.Name, this.Name(), this.RecordType());
        }

        ///GENMHASH:4784E7B75FB76CEEC96CAC590D7BC733:EE061C20B2C852EF45A468E94B59809D
        public DnsRecordSetImpl WithMailExchange(string mailExchangeHostName, int priority)
        {
            this.Inner.MxRecords.Add(new MxRecord
            {
                Exchange = mailExchangeHostName,
                Preference = priority
            });
            return this;
        }

        ///GENMHASH:06F60982829BD1FCB08F550025D02EC6:DB0A29B22B9B76C5DFDCA28B3F4AD95F
        public DnsRecordSetImpl WithTimeToLive(long ttlInSeconds)
        {
            this.Inner.TTL = ttlInSeconds;
            return this;
        }

        ///GENMHASH:7E75EEC0B8C84C22E81E3BAFBC37AFB7:6901EFF3BEDF9329606BCF9A8C14052C
        public DnsRecordSetImpl WithoutRecord(string target, int port, int priority, int weight)
        {
            this.recordSetRemoveInfo.SrvRecords
                .Add(new SrvRecord { Target = target, Port = port, Priority = priority, Weight = weight });
            return this;
        }

        ///GENMHASH:4ECEC95ECA7A8DC269D2A9F01EFAB22F:23360CE86BB90FDBC6677495A1E19515
        public DnsRecordSetImpl WithExpireTimeInSeconds(long expireTimeInSeconds)
        {
            this.Inner.SoaRecord.ExpireTime = expireTimeInSeconds;
            return this;
        }

        ///GENMHASH:C9AB5BEB0FF2C1CFD204A7692C092D2D:2603823A7ECCC53B6CAF90D20F5F9E24
        protected  DnsRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel, IRecordSetsOperations client) : base(innerModel.Name, parent, innerModel)
        {
            this.client = client;
            this.recordSetRemoveInfo = new RecordSetInner
            {
                Name = innerModel.Name,
                Type = innerModel.Type,
                ARecords = new List<ARecord>(),
                AaaaRecords = new List<AaaaRecord>(),
                CnameRecord = new CnameRecord(),
                MxRecords = new List<MxRecord>(),
                NsRecords = new List<NsRecord>(),
                PtrRecords = new List<PtrRecord>(),
                SrvRecords = new List<SrvRecord>(),
                TxtRecords = new List<TxtRecord>(),
                Metadata = new Dictionary<string, string>()
            };
        }

        ///GENMHASH:A495194BB5D71557F5AA70FF3FAE37F2:DAF74D854B6F3C3F3FED97303FD90564
        public DnsRecordSetImpl WithNameServer(string nameServerHostName)
        {
            this.Inner.NsRecords
                .Add(new NsRecord { Nsdname = nameServerHostName });
            return this;
        }

        ///GENMHASH:6300EBC9252C6530D70C1A6340171C08:607AD7BECB4F73629F32C84583686875
        public DnsRecordSetImpl WithText(string text)
        {
            List<string> value = new List<string>();
            value.Add(text);
            this.Inner.TxtRecords.Add(new TxtRecord { Value = value });
            return this;
        }

        DnsZone.Update.IUpdate ISettable<DnsZone.Update.IUpdate>.Parent()
        {
            return this.Parent;
        }
    }
}