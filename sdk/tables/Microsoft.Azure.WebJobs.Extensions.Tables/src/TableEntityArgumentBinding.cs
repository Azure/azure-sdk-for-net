// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class TableEntityArgumentBinding<TElement> : IArgumentBinding<TableEntityContext>
        where TElement : ITableEntity, new()
    {
        public Type ValueType => typeof(TElement);

        public async Task<IValueProvider> BindAsync(TableEntityContext value, ValueBindingContext context)
        {
            var table = value.Table;
            var retrieve = table.CreateRetrieveOperation<TElement>(value.PartitionKey, value.RowKey);
            TableResult result = await table.ExecuteAsync(retrieve, context.CancellationToken).ConfigureAwait(false);
            TElement entity = (TElement)result.Result;
            if (entity == null)
            {
                return new NullEntityValueProvider<TElement>(value);
            }

            return new TableEntityValueBinder(value, entity, typeof(TElement));
        }
    }
}