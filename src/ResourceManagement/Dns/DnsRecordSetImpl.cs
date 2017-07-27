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
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using System.Linq;

    /// <summary>
    /// Implementation of DnsRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5EbnNSZWNvcmRTZXRJbXBs
    internal partial class DnsRecordSetImpl  :
        ExternalChildResource<IDnsRecordSet, RecordSetInner, IDnsZone, DnsZoneImpl>,
        IDnsRecordSet,
        IDefinition<DnsZone.Definition.IWithCreate>,
        IUpdateDefinition<DnsZone.Update.IUpdate>,
        IUpdateCombined
    {
        protected RecordSetInner recordSetRemoveInfo;
        private ETagState eTagState = new ETagState();

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

            if (Inner.Metadata != null && Inner.Metadata.Count > 0)
            {
                if (resource.Metadata == null)
                {
                    resource.Metadata = new Dictionary<string, string>();
                }

                foreach (var keyVal in Inner.Metadata)
                {
                    resource.Metadata.Add(keyVal.Key, keyVal.Value);
                }
                Inner.Metadata.Clear();
            }
             
            if (Inner.TTL != null)
            {
                resource.TTL = Inner.TTL;
                Inner.TTL = null;
            }
            ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:27E486AB74A10242FF421C0798DDC450
            return PrepareForUpdate(resource);
        }

        ///GENMHASH:12F281B8230A0FD8CE8A0DF277EF885D:DF7D49CE4CC74DB0E5D593989B78CB8D
        public IReadOnlyDictionary<string,string> Metadata()
        {
            if (Inner.Metadata == null)
            {
                return new Dictionary<string, string>();
            }
            else
            {
                return Inner.Metadata as Dictionary<string, string>;
            }
        }

        ///GENMHASH:F9C01790C5D58B1748BB35183FF3B0D8:000E3438232752188E9F410E5DCAC466
        private async Task<IDnsRecordSet> CreateOrUpdateAsync(RecordSetInner resource, CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner inner = await Parent.Manager.Inner.RecordSets.CreateOrUpdateAsync(
                Parent.ResourceGroupName,
                Parent.Name, 
                Name(),
                RecordType(),
                resource,
                ifMatch: this.eTagState.IfMatchValueOnUpdate(resource.Etag),
                ifNoneMatch: this.eTagState.IfNonMatchValueOnCreate(),
                cancellationToken: cancellationToken);
            SetInner(inner);
            this.eTagState.Clear();
            return this;
        }

        ///GENMHASH:FB0C10CB41D7B922FF0580521AB216A6:8CAEADA4A5AF9EE51022E3AACA965264
        public DnsRecordSetImpl WithRecord(string target, int port, int priority, int weight)
        {
            Inner.SrvRecords
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
            Inner.SoaRecord.MinimumTtl = negativeCachingTimeToLive;
            return this;
        }

        ///GENMHASH:32A8B56FE180FA4429482D706189DEA2:18B12FED433DF6A1F3CA0DD1940B789C
        public async override Task<IDnsRecordSet> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await CreateOrUpdateAsync(Inner, cancellationToken);
        }

        ///GENMHASH:7126FE6FA387F1E4960F18681C53EC88:B90619A2787B110ED29E0558824FCEEC
        public DnsRecordSetImpl WithTargetDomainName(string targetDomainName)
        {
            Inner.PtrRecords
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
            return Inner.TTL.Value;
        }

        ///GENMHASH:97641C527D3F880E3D6A071B23B1C220:5ED48E280A79185C34BAD7FC806CCBB5
        public DnsRecordSetImpl WithoutIPv4Address(string ipv4Address)
        {
            this.recordSetRemoveInfo.ARecords
                .Add(new ARecord { Ipv4Address = ipv4Address });
            return this;
        }

        ///GENMHASH:8629B1E65EA81A8A3221F7E2E342A5FD:5DA00DC8D7A2405A86C3DDBFD2B0DDC7
        public DnsRecordSetImpl WithoutIPv6Address(string ipv6Address)
        {
            this.recordSetRemoveInfo.AaaaRecords
                .Add(new AaaaRecord { Ipv6Address = ipv6Address });
            return this;
        }

        ///GENMHASH:EF847E8C645CB64D66F22F7C8F41EADF:668CAC97ECB380171D891C73BE38F63B
        public DnsRecordSetImpl WithSerialNumber(long serialNumber)
        {
            Inner.SoaRecord.SerialNumber = serialNumber;
            return this;
        }

        ///GENMHASH:40C52B3E2D072BD6B513ECBCC98E4F0B:C889D9872204B3122BF5D527764173CC
        public DnsRecordSetImpl WithoutMetadata(string key)
        {
            this.recordSetRemoveInfo.Metadata.Add(key, null);
            return this;
        }

        ///GENMHASH:DC461002C137D25BAA574C45A4E811DF:F96F4FA644159C0CD0EBB1C5B9EEF1A0
        internal DnsRecordSetImpl WithIPv6Address(string ipv6Address)
        {
            Inner.AaaaRecords
                .Add(new AaaaRecord { Ipv6Address =ipv6Address });
            return this;
        }

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:B566554D9AFEED430A7C1AC9E97ADBDB
        protected virtual RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            return resource;
        }

        ///GENMHASH:C638904A9672FCBF061409871819AB8D:41137108673CA51222538BEBDE37F159
        public DnsRecordSetImpl WithAlias(string alias)
        {
            Inner.CnameRecord.Cname = alias;
            return this;
        }

        ///GENMHASH:4CA65F8144FED160954BD87CFFBC0595:E0FC813C874E3B3480E4DA74E4253BCC
        internal DnsRecordSetImpl WithIPv4Address(string ipv4Address)
        {
            Inner.ARecords.Add(new ARecord { Ipv4Address = ipv4Address });
            return this;
        }

        ///GENMHASH:4B07DB88181953A1AA185580F8B1266A:B3424C4783A914D6F340B7301EAFAE8E
        public DnsRecordSetImpl WithRetryTimeInSeconds(long retryTimeInSeconds)
        {
            Inner.SoaRecord.RetryTime = retryTimeInSeconds;
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

        ///GENMHASH:F08598A17ADD014E223DFD77272641FF:A945C11E2DCC935424E5B666E47F3D2C
        public async override Task<IDnsRecordSet> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner resource = await Parent.Manager.Inner.RecordSets.GetAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Name(),
                RecordType(),
                cancellationToken);
            resource = Prepare(resource);
            return await CreateOrUpdateAsync(resource, cancellationToken);
        }

        ///GENMHASH:4913BE5E272184975DDDF5335B476BBD:88ACBC17B6D51A9C055E4CC9834ED144
        public string ETag()
        {
            return this.Inner.Etag;
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

        ///GENMHASH:791593DE94E8D431FBB634CF0578A424:D24CFEDBDBC40A8AF2B5216EA0D7C954
        public DnsRecordSetImpl WithETagCheck()
        {
            this.eTagState.WithImplicitETagCheckOnCreate();
            this.eTagState.WithImplicitETagCheckOnUpdate();
            return this;
        }

        ///GENMHASH:CAE9667D3C5220302471B1AF817CBA6A:A7E77BD98437FA8383ED7A6B96761FD4
        public DnsRecordSetImpl WithETagCheck(string eTagValue)
        {
            this.eTagState.WithExplicitETagCheckOnUpdate(eTagValue);
            return this;
        }

        ///GENMHASH:6D37E4EB187608D1444EE0B12AEEAB67:4B5F1BDCC88474FFF19319243A41B6F7
        public DnsRecordSetImpl WithRefreshTimeInSeconds(long refreshTimeInSeconds)
        {
            Inner.SoaRecord.RefreshTime = refreshTimeInSeconds;
            return this;
        }

        ///GENMHASH:1DB2BF1F42540E5CABB126B2B9970516:12FBAC3B63C70ED810BCC3C5AE182F93
        internal DnsRecordSetImpl WithETagOnDelete(string eTagValue)
        {
            this.eTagState.WithExplicitETagCheckOnDelete(eTagValue);
            return this;
        }

        ///GENMHASH:E8E20943CC1653864072EDF514EE642D:10153E6B4A158154E1E8933759138F87
        public DnsRecordSetImpl WithEmailServer(string emailServerHostName)
        {
            Inner.SoaRecord.Email = emailServerHostName;
            return this;
        }

        ///GENMHASH:B9A12A61DE5C3FD7372657598F28C736:C0E78FE3325BAB97993FBD6D1EC3DD20
        public DnsRecordSetImpl WithoutText(string text)
        {
            if (text == null) {
                return this;
            }
            List<string> chunks = new List<string>();
            chunks.Add(text);
            return WithoutText(chunks);
        }

        ///GENMHASH:7514E74617844D31FA17DECC30EC7487:D45180FF29FB5C16A3FD358D567C01FD
        public DnsRecordSetImpl WithoutText(IList<string> textChunks)
        {
            this.recordSetRemoveInfo.TxtRecords
                .Add(new TxtRecord { Value = textChunks });
            return this;
        }

        ///GENMHASH:3802EA6243E9AF80A622FF944E74B5EA:8520CAFB7CB8489C528CA99FBB8E0916
        public RecordType RecordType()
        {
            var fullyQualifiedType = this.Inner.Type;
            var parts = fullyQualifiedType.Split('/');
            return (RecordType)Enum.Parse(typeof(RecordType), parts[parts.Length - 1]);
        }

        ///GENMHASH:A8504DD39B3F14EC8A5C6530FB22292A:5BA5A4ACBB2C6A840606E1F8F35C4054
        public DnsRecordSetImpl WithMetadata(string key, string value)
        {
            if (Inner.Metadata == null)
            {
                Inner.Metadata = new Dictionary<string, string>();
            }
            if (!Inner.Metadata.ContainsKey(key))
            {
                Inner.Metadata.Add(key, value);
            }
            else
            {
                Inner.Metadata[key] = value;
            }
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:12B69CFE7F6114AB5C15C38A5DAE43C8
        protected override async Task<RecordSetInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Parent.Manager.Inner.RecordSets.GetAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Name(),
                RecordType(), cancellationToken: cancellationToken);
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:2B9DD1C564ED2E952CDE4348D8C25EE7
        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Parent.Manager.Inner.RecordSets.DeleteAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Name(),
                RecordType(),
                ifMatch: this.eTagState.IfMatchValueOnDelete(),
                cancellationToken: cancellationToken);
        }

        ///GENMHASH:4784E7B75FB76CEEC96CAC590D7BC733:EE061C20B2C852EF45A468E94B59809D
        public DnsRecordSetImpl WithMailExchange(string mailExchangeHostName, int priority)
        {
            Inner.MxRecords.Add(new MxRecord
            {
                Exchange = mailExchangeHostName,
                Preference = priority
            });
            return this;
        }

        ///GENMHASH:06F60982829BD1FCB08F550025D02EC6:DB0A29B22B9B76C5DFDCA28B3F4AD95F
        public DnsRecordSetImpl WithTimeToLive(long ttlInSeconds)
        {
            Inner.TTL = ttlInSeconds;
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
            Inner.SoaRecord.ExpireTime = expireTimeInSeconds;
            return this;
        }

        ///GENMHASH:640F81D4B0689D165D5047EC30E0213C:0D6144F158DEA8BB449CD2540A30B54C
        internal DnsRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel) : base(innerModel.Name, parent, innerModel)
        {
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
            Inner.NsRecords
                .Add(new NsRecord { Nsdname = nameServerHostName });
            return this;
        }

        ///GENMHASH:6300EBC9252C6530D70C1A6340171C08:607AD7BECB4F73629F32C84583686875
        public DnsRecordSetImpl WithText(string text)
        {
            if (text == null)
            {
                return this;
            }
            List<string> value = new List<string>();
            if (text.Length < 255)
            {
                value.Add(text);
            }
            else
            {
                value.AddRange(Enumerable.Range(0, (int)(Math.Ceiling(text.Length / (double)255))).Select(i => text.Substring(i * 255, 255)));
            }
            Inner.TxtRecords.Add(new TxtRecord { Value = value });
            return this;
        }

        DnsZone.Update.IUpdate ISettable<DnsZone.Update.IUpdate>.Parent()
        {
            return this.Parent;
        }


        ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5EbnNSZWNvcmRTZXRJbXBsLkVUYWdTdGF0ZQ==
        class ETagState
        {
            private bool doImplicitETagCheckOnCreate;
            private bool doImplicitETagCheckOnUpdate;
            private string eTagOnUpdate;
            private string eTagOnDelete;

            ///GENMHASH:A2B627C663DDB747C621FCA1D7BE24A8:76A309CFA4E29C8A8F8C92BCF73A1AB6
            public ETagState WithExplicitETagCheckOnUpdate(string eTagValue)
            {
                this.eTagOnUpdate = eTagValue;
                return this;
            }

            ///GENMHASH:E56828D96951375F4EF1730388DE7346:5A4ECB9B6B7CBD3113C2CAA49D6DD200
            public ETagState WithImplicitETagCheckOnUpdate()
            {
                this.doImplicitETagCheckOnUpdate = true;
                return this;
            }

            ///GENMHASH:D3CEF7E2B598DD354274A5AFE552A662:A20A52DB2A85D7C3C8296FDFB1961372
            public string IfMatchValueOnDelete()
            {
                return this.eTagOnDelete;
            }

            ///GENMHASH:BDEEEC08EF65465346251F0F99D16258:C50E159EF615C54F8F31030BCA0B7576
            public ETagState Clear()
            {
                this.doImplicitETagCheckOnCreate = false;
                this.doImplicitETagCheckOnUpdate = false;
                this.eTagOnUpdate = null;
                this.eTagOnDelete = null;
                return this;
            }

            ///GENMHASH:212FE0B4DFB2C1FB72091A3F8865BE1B:CE3736CC8D80616CC9B9031CC0D0E5CA
            public string IfNonMatchValueOnCreate()
            {
                if (this.doImplicitETagCheckOnCreate)
                {
                    return "*";
                }
                return null;
            }

            ///GENMHASH:2FE5CB6C2E7B55F99613F61DA9EF4F1D:E1C7BCC3B078606C167311CDD4A1A54B
            public string IfMatchValueOnUpdate(string currentETagValue)
            {
                string eTagValue = null;
                if (this.doImplicitETagCheckOnUpdate)
                {
                    eTagValue = currentETagValue;
                }
                if (this.eTagOnUpdate != null)
                {
                    eTagValue = this.eTagOnUpdate;
                }
                return eTagValue;
            }

            ///GENMHASH:C8126BDFD9A21FF4295AF1F12B4EA871:99938E9DF848049CBB209F4237FC0B7B
            public ETagState WithExplicitETagCheckOnDelete(string eTagValue)
            {
                this.eTagOnDelete = eTagValue;
                return this;
            }

            ///GENMHASH:441A98D786D840B5B136CFD0CE477BAA:FFF1B40244858F3A733FD6117C08970B
            public ETagState WithImplicitETagCheckOnCreate()
            {
                this.doImplicitETagCheckOnCreate = true;
                return this;
            }
        }
    }
}
