// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class TableEntityArgumentBinding<TElement> : IArgumentBinding<TableEntityContext>
        where TElement :class, ITableEntity, new()
    {
        public Type ValueType => typeof(TElement);

        public async Task<IValueProvider> BindAsync(TableEntityContext value, ValueBindingContext context)
        {
            var table = value.Table;
            try
            {
                var result = await table.GetEntityAsync<TElement>(value.PartitionKey, value.RowKey, cancellationToken: context.CancellationToken).ConfigureAwait(false);
                return new TableEntityValueBinder(value, result.Value, typeof(TElement));
            }
            catch (RequestFailedException e) when (e.Status == 404 && e.ErrorCode == "TableNotFound")
            {
                return new NullEntityValueProvider<TElement>(value);
            }
        }
    }
}