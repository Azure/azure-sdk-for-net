// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class PocoEntityArgumentBinding<TElement> : IArgumentBinding<TableEntityContext>
    {
        private readonly FuncAsyncConverter _pocoToEntityConverter;
        private readonly FuncAsyncConverter _entityToPocoConverter;

        public PocoEntityArgumentBinding(FuncAsyncConverter entityToPocoConverter, FuncAsyncConverter pocoToEntityConverter)
        {
            _pocoToEntityConverter = pocoToEntityConverter;
            _entityToPocoConverter = entityToPocoConverter;
        }

        public Type ValueType => typeof(TElement);

        public async Task<IValueProvider> BindAsync(TableEntityContext value, ValueBindingContext context)
        {
            var table = value.Table;
            TableEntity entity;
            try
            {
                entity = await table.GetEntityAsync<TableEntity>(
                    value.PartitionKey, value.RowKey).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when
                (e.Status == 404 && (e.ErrorCode == TableErrorCode.TableNotFound || e.ErrorCode == TableErrorCode.ResourceNotFound))
            {
                return new NullEntityValueProvider<TElement>(value);
            }

            return new PocoEntityValueBinder<TElement>(value, context, entity, _entityToPocoConverter, _pocoToEntityConverter);
        }
    }
}