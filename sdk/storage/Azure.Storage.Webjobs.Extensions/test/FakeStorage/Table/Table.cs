// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace FakeStorage
{
    public class FakeTable : CloudTable
    {
        private readonly FakeTableClient _client;

        private MemoryTableStore _store;
        private string _tableName;

        public FakeTable(FakeTableClient client, string tableName) : base(
            new Uri("http://localhost:10000/fakeaccount/" + tableName), client.Credentials
            )
        {
            _client = client;
            _store = _client._account.Store;
            _tableName = tableName;
        }

        public override Task CreateAsync()
        {
            return base.CreateAsync();
        }
        public override Task CreateAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return base.CreateAsync(requestOptions, operationContext);
        }
        public override Task CreateAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.CreateIfNotExistsAsync();
        }
        public override Task<bool> CreateIfNotExistsAsync()
        {
            return base.CreateIfNotExistsAsync();
        }
        public override Task<bool> CreateIfNotExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return base.CreateIfNotExistsAsync(requestOptions, operationContext);
        }
        public override Task<bool> CreateIfNotExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            _store.CreateIfNotExists(_tableName);
            return Task.FromResult(false); // $$$
        }


        public override Task DeleteAsync()
        {
            return base.DeleteAsync();
        }
        public override Task DeleteAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return base.DeleteAsync(requestOptions, operationContext);
        }
        public override Task DeleteAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.DeleteAsync(requestOptions, operationContext, cancellationToken);
        }
        public override Task<bool> DeleteIfExistsAsync()
        {
            return base.DeleteIfExistsAsync();
        }

        public override Task<bool> DeleteIfExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return base.DeleteIfExistsAsync(requestOptions, operationContext);
        }

        public override Task<bool> DeleteIfExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.DeleteIfExistsAsync(requestOptions, operationContext, cancellationToken);
        }

        public override bool Equals(object obj)
        {
            if (obj is FakeTable other)
            {
                return
                    (other._tableName == this._tableName) &&
                    (other._store == this._store);
            }
            return false;
        }
        public override Task<TableResult> ExecuteAsync(TableOperation operation)
        {
            return Task.FromResult(_store.Execute(_tableName, operation));
        }

        public override Task<TableResult> ExecuteAsync(TableOperation operation, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return Task.FromResult(_store.Execute(_tableName, operation));
        }

        public override Task<TableResult> ExecuteAsync(TableOperation operation, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(_store.Execute(_tableName, operation));
        }

        public override Task<TableBatchResult> ExecuteBatchAsync(TableBatchOperation batch, CancellationToken cancellationToken)
        {
            return Task.FromResult(_store.ExecuteBatch(_tableName, batch));
        }

        public override Task<TableQuerySegment<DynamicTableEntity>> ExecuteQuerySegmentedAsync(TableQuery query, TableContinuationToken token, CancellationToken cancellationToken)
        {
            return base.ExecuteQuerySegmentedAsync(query, token, cancellationToken);
        }

        public override Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TElement, TResult>(TableQuery<TElement> query, EntityResolver<TResult> resolver, TableContinuationToken token, CancellationToken cancellationToken)
        {
            return base.ExecuteQuerySegmentedAsync(query, resolver, token, cancellationToken);
        }

        public override Task<TableQuerySegment<TElement>> ExecuteQuerySegmentedAsync<TElement>(TableQuery<TElement> query, TableContinuationToken token, CancellationToken cancellationToken)
        {
            return base.ExecuteQuerySegmentedAsync(query, token, cancellationToken);
        }

        public override Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TResult>(TableQuery query, EntityResolver<TResult> resolver, TableContinuationToken token, CancellationToken cancellationToken)
        {
            return base.ExecuteQuerySegmentedAsync(query, resolver, token, cancellationToken);
        }

        public override Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<T, TResult>(TableQuery<T> query, EntityResolver<TResult> resolver, TableContinuationToken token)
        {
            return base.ExecuteQuerySegmentedAsync(query, resolver, token);
        }
        public override Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<T, TResult>(TableQuery<T> query, EntityResolver<TResult> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return base.ExecuteQuerySegmentedAsync(query, resolver, token, requestOptions, operationContext);
        }
        public override Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<T, TResult>(TableQuery<T> query, EntityResolver<TResult> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.ExecuteQuerySegmentedAsync(query, resolver, token, requestOptions, operationContext, cancellationToken);
        }
        public override Task<TableQuerySegment<T>> ExecuteQuerySegmentedAsync<T>(TableQuery<T> query, TableContinuationToken token)
        {
            return base.ExecuteQuerySegmentedAsync(query, token);
        }

        public override Task<TableQuerySegment<T>> ExecuteQuerySegmentedAsync<T>(TableQuery<T> query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return base.ExecuteQuerySegmentedAsync(query, token, requestOptions, operationContext);
        }

        public override Task<TableQuerySegment<T>> ExecuteQuerySegmentedAsync<T>(TableQuery<T> query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.ExecuteQuerySegmentedAsync(query, token, requestOptions, operationContext, cancellationToken);
        }

        public override Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TResult>(TableQuery query, EntityResolver<TResult> resolver, TableContinuationToken token)
        {
            return base.ExecuteQuerySegmentedAsync(query, resolver, token);
        }

        public override Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TResult>(TableQuery query, EntityResolver<TResult> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return base.ExecuteQuerySegmentedAsync(query, resolver, token, requestOptions, operationContext);
        }

        public override Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TResult>(TableQuery query, EntityResolver<TResult> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.ExecuteQuerySegmentedAsync(query, resolver, token, requestOptions, operationContext, cancellationToken);
        }

        public override Task<bool> ExistsAsync()
        {
            bool result = _store.Exists(_tableName);
            return Task.FromResult(result);
        }

        public override Task<bool> ExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            bool result = _store.Exists(_tableName);
            return Task.FromResult(result);
        }

        public override Task<bool> ExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            bool result = _store.Exists(_tableName);
            return Task.FromResult(result);
        }

        public override int GetHashCode()
        {
            return this._tableName.GetHashCode();
        }

        public override Task<TablePermissions> GetPermissionsAsync()
        {
            return base.GetPermissionsAsync();
        }

        public override Task<TablePermissions> GetPermissionsAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return base.GetPermissionsAsync(requestOptions, operationContext);
        }

        public override Task<TablePermissions> GetPermissionsAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.GetPermissionsAsync(requestOptions, operationContext, cancellationToken);
        }

        public override Task SetPermissionsAsync(TablePermissions permissions)
        {
            return base.SetPermissionsAsync(permissions);
        }

        public override Task SetPermissionsAsync(TablePermissions permissions, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return base.SetPermissionsAsync(permissions, requestOptions, operationContext);
        }

        public override Task SetPermissionsAsync(TablePermissions permissions, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.SetPermissionsAsync(permissions, requestOptions, operationContext, cancellationToken);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}