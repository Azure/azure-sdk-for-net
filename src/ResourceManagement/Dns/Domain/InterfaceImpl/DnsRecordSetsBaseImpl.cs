// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Dns.Fluent
{
    internal abstract partial class DnsRecordSetsBaseImpl<RecordSetT, RecordSetImplT>
    {
        /// <summary>
        /// Lists all the record sets with the given suffix.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <return>List of record sets.</return>
        System.Collections.Generic.IEnumerable<RecordSetT> Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSets<RecordSetT>.List(string recordSetNameSuffix)
        {
            return this.List(recordSetNameSuffix) as System.Collections.Generic.IEnumerable<RecordSetT>;
        }

        /// <summary>
        /// Lists all the record sets, with number of entries in each page limited to given size.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>List of record sets.</return>
        System.Collections.Generic.IEnumerable<RecordSetT> Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSets<RecordSetT>.List(int pageSize)
        {
            return this.List(pageSize) as System.Collections.Generic.IEnumerable<RecordSetT>;
        }

        /// <summary>
        /// Lists all the record sets with the given suffix, also limits the number of entries
        /// per page to the given page size.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The record sets.</return>
        System.Collections.Generic.IEnumerable<RecordSetT> Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSets<RecordSetT>.List(string recordSetNameSuffix, int pageSize)
        {
            return this.List(recordSetNameSuffix, pageSize) as System.Collections.Generic.IEnumerable<RecordSetT>;
        }

        /// <summary>
        /// Lists all the record sets with the given suffix.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <return>An observable that emits record sets.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>> Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSets<RecordSetT>.ListAsync(string recordSetNameSuffix, bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(recordSetNameSuffix, loadAllPages, cancellationToken) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>;
        }

        /// <summary>
        /// Lists all the record sets, with number of entries in each page limited to given size.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>An observable that emits record sets.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>> Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSets<RecordSetT>.ListAsync(int pageSize, bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(pageSize, loadAllPages, cancellationToken) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>;
        }

        /// <summary>
        /// Lists all the record sets with the given suffix, also limits the number of entries
        /// per page to the given page size.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>An observable that emits record sets.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>> Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSets<RecordSetT>.ListAsync(string recordSetNameSuffix, int pageSize, bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(recordSetNameSuffix, pageSize, loadAllPages, cancellationToken) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<RecordSetT> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<RecordSetT>.List()
        {
            return this.List() as System.Collections.Generic.IEnumerable<RecordSetT>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<RecordSetT>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>;
        }
    }
}
