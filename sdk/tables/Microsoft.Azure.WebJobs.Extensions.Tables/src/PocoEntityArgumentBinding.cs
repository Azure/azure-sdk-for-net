// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class PocoEntityArgumentBinding<TElement> : IArgumentBinding<TableEntityContext>
        where TElement : new()
    {
        private static readonly IConverter<ITableEntity, TElement> Converter =
            TableEntityToPocoConverter<TElement>.Create();

        public Type ValueType => typeof(TElement);

        public async Task<IValueProvider> BindAsync(TableEntityContext value, ValueBindingContext context)
        {
            var table = value.Table;
            var retrieve = table.CreateRetrieveOperation<DynamicTableEntity>(
                value.PartitionKey, value.RowKey);
            TableResult result = await table.ExecuteAsync(retrieve, context.CancellationToken).ConfigureAwait(false);
            DynamicTableEntity entity = (DynamicTableEntity)result.Result;
            if (entity == null)
            {
                return new NullEntityValueProvider<TElement>(value);
            }

            TElement userEntity = Converter.Convert(entity);
            return new PocoEntityValueBinder<TElement>(value, entity.ETag, userEntity);
        }
    }
}