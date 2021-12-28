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
    internal class TableEntityArgumentBinding : IArgumentBinding<TableEntityContext>
    {
        public Type ValueType => typeof(TableEntity);

        public async Task<IValueProvider> BindAsync(TableEntityContext value, ValueBindingContext context)
        {
            var table = value.Table;
            try
            {
                var result = await table.GetEntityAsync<TableEntity>(value.PartitionKey, value.RowKey, cancellationToken: context.CancellationToken).ConfigureAwait(false);
                return new TableEntityValueBinder(value, result.Value, typeof(TableEntity));
            }
            catch (RequestFailedException e) when
                (e.Status == 404 && (e.ErrorCode == TableErrorCode.TableNotFound || e.ErrorCode == TableErrorCode.ResourceNotFound))
            {
                return new NullEntityValueProvider<TableEntity>(value);
            }
        }
    }
}