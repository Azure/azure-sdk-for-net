// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Base interface for all record sets.
    /// </summary>
    /// <typeparam name="RecordSetT">The record set type.</typeparam>
    public interface IDnsRecordSetsBeta<RecordSetT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Lists all the record sets with the given suffix.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <return>List of record sets.</return>
        System.Collections.Generic.IEnumerable<RecordSetT> List(string recordSetNameSuffix);

        /// <summary>
        /// Lists all the record sets, with number of entries in each page limited to given size.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>List of record sets.</return>
        System.Collections.Generic.IEnumerable<RecordSetT> List(int pageSize);

        /// <summary>
        /// Lists all the record sets with the given suffix, also limits the number of entries
        /// per page to the given page size.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The record sets.</return>
        System.Collections.Generic.IEnumerable<RecordSetT> List(string recordSetNameSuffix, int pageSize);

        /// <summary>
        /// Lists all the record sets with the given suffix.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <return>An observable that emits record sets.</return>
        Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>> ListAsync(string recordSetNameSuffix, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all the record sets, with number of entries in each page limited to given size.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>An observable that emits record sets.</return>
        Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>> ListAsync(int pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all the record sets with the given suffix, also limits the number of entries
        /// per page to the given page size.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>An observable that emits record sets.</return>
        Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<RecordSetT>> ListAsync(string recordSetNameSuffix, int pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));
    }
}