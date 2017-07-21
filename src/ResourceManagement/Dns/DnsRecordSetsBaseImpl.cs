// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Dns.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System;

    /// <summary>
    /// The base implementation for Dns Record sets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5EbnNSZWNvcmRTZXRzQmFzZUltcGw=
    internal abstract partial class DnsRecordSetsBaseImpl<RecordSetT, RecordSetImplT> :
        ReadableWrappers<RecordSetT, RecordSetImplT, Models.RecordSetInner>,
        IDnsRecordSets<RecordSetT>
        where RecordSetImplT : RecordSetT
    {
        protected readonly DnsZoneImpl dnsZone;
        protected readonly RecordType recordType;

        ///GENMHASH:6B78047BDDCD605061F877C7337AA07F:27E486AB74A10242FF421C0798DDC450
        internal DnsRecordSetsBaseImpl(DnsZoneImpl dnsZone, RecordType recordType)
        {
            this.dnsZone = dnsZone;
            this.recordType = recordType;
        }
        
        public abstract Task<RecordSetT> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:64B3FB1F01DFC1156B75305640537ED6:27E486AB74A10242FF421C0798DDC450
        protected abstract Task<IPagedCollection<RecordSetT>> ListInternAsync(string recordSetNameSuffix, int? pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));
        
        ///GENMHASH:B94D04B9D91F75559A6D8E405D4A72FD:27E486AB74A10242FF421C0798DDC450
        protected abstract IEnumerable<RecordSetT> ListIntern(string recordSetNameSuffix, int? pageSize);

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:E19B1A43B8D006D892A5880F9F29D599
        public IDnsZone Parent {
            get {
                return this.dnsZone;
            }
        }

        public RecordSetT GetByName(string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(name));
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:8702BABF19DCC459AC95CE748259A3D1
        public IEnumerable<RecordSetT> List()
        {
            return ListIntern(null, null);
        }

        ///GENMHASH:BA1FD87F6E131F867F776046DC4F1016:CFD9DC16FCEFE5E9AEFA806B70A4BF54
        public IEnumerable<RecordSetT> List(string recordSetNameSuffix)
        {
            return ListIntern(recordSetNameSuffix, null);
        }

        ///GENMHASH:23ECE723D33E629E89DB16A462FDD1E4:25D68EA3FDA1306420F88DA163E66064
        public IEnumerable<RecordSetT> List(int pageSize)
        {
            return ListIntern(null, pageSize);
        }

        ///GENMHASH:E43E2CDE56BF8CFE6B0659494E069FAD:43168D25644091E552D5C1627152B8E0
        public IEnumerable<RecordSetT> List(string recordSetNameSuffix, int pageSize)
        {
            return ListIntern(recordSetNameSuffix, pageSize);
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:DBED4B2A153AE3F130B607A81D083E64
        public Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ListInternAsync(null, null);
        }

        ///GENMHASH:FA614278152C859D98338C2D5EA0A8A7:0585C6A796CA92BF2DD40DDA89F7AEE7
        public Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>> ListAsync(string recordSetNameSuffix, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ListInternAsync(recordSetNameSuffix, null);
        }

        ///GENMHASH:D44E964AE1FC03FEAE144ED2D669E437:4673B4F8F7FFF09971B71C357E86AB1F
        public Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>> ListAsync(int pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ListInternAsync(null, pageSize);
        }

        ///GENMHASH:DD68B13B8FC9F5660985F6DE7C52C1FE:4A6A0FF35A32FD08596FE3E69E8196B3
        public Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>> ListAsync(string recordSetNameSuffix, int pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ListInternAsync(recordSetNameSuffix, pageSize);
        }
    }
}