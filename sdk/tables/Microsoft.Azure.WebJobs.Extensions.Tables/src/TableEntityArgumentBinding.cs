// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
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
            var result = await table.GetEntityAsync<TElement>(value.PartitionKey, value.RowKey, cancellationToken: context.CancellationToken).ConfigureAwait(false);
            TElement entity = (TElement)result.Value;
            if (entity == null)
            {
                return new NullEntityValueProvider<TElement>(value);
            }

            return new TableEntityValueBinder(value, entity, typeof(TElement));
        }
    }
}