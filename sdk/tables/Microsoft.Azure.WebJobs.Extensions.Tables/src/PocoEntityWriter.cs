// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    /// <summary>
    /// The POCO entity writer.
    /// </summary>
    /// <typeparam name="T">The POCO type.</typeparam>
    internal class PocoEntityWriter<T> : ICollector<T>, IAsyncCollector<T>, IWatcher
    {
        private static readonly IConverter<T, ITableEntity> Converter = PocoToTableEntityConverter<T>.Create();

        public PocoEntityWriter(CloudTable table, TableParameterLog tableStatistics)
        {
            TableEntityWriter = new TableEntityWriter<ITableEntity>(table, tableStatistics);
        }

        public PocoEntityWriter(CloudTable table)
        {
            TableEntityWriter = new TableEntityWriter<ITableEntity>(table);
        }

        internal TableEntityWriter<ITableEntity> TableEntityWriter { get; set; }

        public void Add(T item)
        {
            // TODO
#pragma warning disable AZC0102
            AddAsync(item).GetAwaiter().GetResult();
#pragma warning restore AZC0102
        }

        public Task FlushAsync(CancellationToken cancellationToken)
        {
            return TableEntityWriter.FlushAsync(cancellationToken);
        }

        public Task AddAsync(T item, CancellationToken cancellationToken = default(CancellationToken))
        {
            ITableEntity tableEntity = Converter.Convert(item);
            return TableEntityWriter.AddAsync(tableEntity, cancellationToken);
        }

        public ParameterLog GetStatus()
        {
            return TableEntityWriter.GetStatus();
        }
    }
}