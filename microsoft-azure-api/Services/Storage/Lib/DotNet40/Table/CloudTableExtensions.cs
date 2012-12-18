// -----------------------------------------------------------------------------------------
// <copyright file="CloudTableExtensions.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table
{
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;

	/// <summary>
	/// Provides <see cref="Task"/> wrappers for asynchronous execution.
	/// </summary>
	public static class CloudTableExtensions
	{
		#region Private Cancellable Task Wrappers

		private static Task FromCancellableAsync(Func<AsyncCallback, object, ICancellableAsyncResult> beginMethod, Action<IAsyncResult> endMethod, CancellationToken token)
		{
			ICancellableAsyncResult result = beginMethod(null, null);
			var cancellationRegistration = token.Register(result.Cancel);

			return Task.Factory.FromAsync(result, asyncResult =>
			{
				cancellationRegistration.Dispose();
				endMethod(asyncResult);
			});
		}

		private static Task FromCancellableAsync<TArg1>(Func<TArg1, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, CancellationToken token)
		{
			ICancellableAsyncResult result = beginMethod(arg1, null, null);
			var cancellationRegistration = token.Register(result.Cancel);

			return Task.Factory.FromAsync(result, asyncResult =>
			{
				cancellationRegistration.Dispose();
				endMethod(asyncResult);
			});
		}

		private static Task FromCancellableAsync<TArg1, TArg2>(Func<TArg1, TArg2, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, CancellationToken token)
		{
			ICancellableAsyncResult result = beginMethod(arg1, arg2, null, null);
			var cancellationRegistration = token.Register(result.Cancel);

			return Task.Factory.FromAsync(result, asyncResult =>
			{
				cancellationRegistration.Dispose();
				endMethod(asyncResult);
			});
		}

		private static Task FromCancellableAsync<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken token)
		{
			ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, null, null);
			var cancellationRegistration = token.Register(result.Cancel);

			return Task.Factory.FromAsync(result, asyncResult =>
			{
				cancellationRegistration.Dispose();
				endMethod(asyncResult);
			});
		}

		private static Task<TResult> FromCancellableAsync<TResult>(Func<AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, CancellationToken token)
		{
			ICancellableAsyncResult result = beginMethod(null, null);
			var cancellationRegistration = token.Register(result.Cancel);

			return Task.Factory.FromAsync(result, asyncResult =>
			{
				cancellationRegistration.Dispose();
				return endMethod(asyncResult);
			});
		}

		private static Task<TResult> FromCancellableAsync<TArg1, TResult>(Func<TArg1, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, CancellationToken token)
		{
			ICancellableAsyncResult result = beginMethod(arg1, null, null);
			var cancellationRegistration = token.Register(result.Cancel);

			return Task.Factory.FromAsync(result, asyncResult =>
			{
				cancellationRegistration.Dispose();
				return endMethod(asyncResult);
			});
		}

		private static Task<TResult> FromCancellableAsync<TArg1, TArg2, TResult>(Func<TArg1, TArg2, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, CancellationToken token)
		{
			ICancellableAsyncResult result = beginMethod(arg1, arg2, null, null);
			var cancellationRegistration = token.Register(result.Cancel);

			return Task.Factory.FromAsync(result, asyncResult =>
			{
				cancellationRegistration.Dispose();
				return endMethod(asyncResult);
			});
		}

		private static Task<TResult> FromCancellableAsync<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken token)
		{
			ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, null, null);
			var cancellationRegistration = token.Register(result.Cancel);

			return Task.Factory.FromAsync(result, asyncResult =>
			{
				cancellationRegistration.Dispose();
				return endMethod(asyncResult);
			});
		}

		private static Task<TResult> FromCancellableAsync<TArg1, TArg2, TArg3, TArg4, TResult>(Func<TArg1, TArg2, TArg3, TArg4, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken token)
		{
			ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, arg4, null, null);
			var cancellationRegistration = token.Register(result.Cancel);

			return Task.Factory.FromAsync(result, asyncResult =>
			{
				cancellationRegistration.Dispose();
				return endMethod(asyncResult);
			});
		}

		private static Task<TResult> FromCancellableAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken token)
		{
			ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, arg4, arg5, null, null);
			var cancellationRegistration = token.Register(result.Cancel);

			return Task.Factory.FromAsync(result, asyncResult =>
			{
				cancellationRegistration.Dispose();
				return endMethod(asyncResult);
			});
		}

		#endregion

		#region TableOperation ExecuteAsync Methods

		/// <summary>
		/// Executes an asynchronous table operation.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="operation">A <see cref="TableOperation"/> object that represents the operation to perform.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableResult> ExecuteAsync(this CloudTable cloudTable, TableOperation operation)
		{
			return Task<TableResult>.Factory.FromAsync(cloudTable.BeginExecute, cloudTable.EndExecute, operation, null);
		}

		/// <summary>
		/// Executes an asynchronous table operation.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="operation">A <see cref="TableOperation" /> object that represents the operation to perform.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>
		/// An <see cref="ICancellableAsyncResult" /> that references the asynchronous operation.
		/// </returns>
		[DoesServiceRequest]
		public static Task<TableResult> ExecuteAsync(this CloudTable cloudTable, TableOperation operation, CancellationToken token)
		{
			return FromCancellableAsync<TableOperation, TableResult>(cloudTable.BeginExecute, cloudTable.EndExecute, operation, token);
		}

		/// <summary>
		/// Executes an asynchronous table operation using the specified <see cref="TableRequestOptions"/> and <see cref="OperationContext"/>.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="operation">A <see cref="TableOperation"/> object that represents the operation to perform.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableResult> ExecuteAsync(this CloudTable cloudTable, TableOperation operation, TableRequestOptions requestOptions, OperationContext operationContext)
		{
			return Task<TableResult>.Factory.FromAsync(cloudTable.BeginExecute, cloudTable.EndExecute, operation,
				requestOptions, operationContext, null);
		}

		/// <summary>
		/// Executes an asynchronous table operation using the specified <see cref="TableRequestOptions"/> and <see cref="OperationContext"/>.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="operation">A <see cref="TableOperation"/> object that represents the operation to perform.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableResult> ExecuteAsync(this CloudTable cloudTable, TableOperation operation, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken token)
		{
			return FromCancellableAsync<TableOperation, TableRequestOptions, OperationContext, TableResult>(cloudTable.BeginExecute, cloudTable.EndExecute, operation,
				requestOptions, operationContext, token);
		}

		#endregion

		#region TableBatchOperation ExecuteAsync Methods

		/// <summary>
		/// Executes an asynchronous batch operation on a table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="batch">The batch operation to run.</param>
		/// <returns>
		/// The task corresponding to asynchronous batch operation.
		/// </returns>
		[DoesServiceRequest]
		public static Task<IList<TableResult>> ExecuteBatchAsync(this CloudTable cloudTable, TableBatchOperation batch)
		{
			return Task<IList<TableResult>>.Factory.FromAsync(cloudTable.BeginExecuteBatch, cloudTable.EndExecuteBatch,
				batch, null);
		}

		/// <summary>
		/// Executes a cancellable asynchronous batch operation on a table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="batch">The batch operation to run.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>
		/// The task corresponding to asynchronous batch operation.
		/// </returns>
		[DoesServiceRequest]
		public static Task<IList<TableResult>> ExecuteBatchAsync(this CloudTable cloudTable, TableBatchOperation batch, CancellationToken token)
		{
			return FromCancellableAsync<TableBatchOperation, IList<TableResult>>(cloudTable.BeginExecuteBatch, cloudTable.EndExecuteBatch, batch, token);
		}

		/// <summary>
		/// Executes an asynchronous batch operation on a table as an atomic operation, using the specified <see cref="TableRequestOptions" /> and <see cref="OperationContext" />.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="batch">The <see cref="TableBatchOperation" /> object representing the operations to execute on the table.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions" /> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
		/// <returns>
		/// An enumerable collection of <see cref="TableResult" /> objects that contains the results, in order, of each operation in the <see cref="TableBatchOperation" /> on the table.
		/// </returns>
		[DoesServiceRequest]
		public static Task<IList<TableResult>> ExecuteBatchAsync(this CloudTable cloudTable, TableBatchOperation batch,
			TableRequestOptions requestOptions, OperationContext operationContext)
		{
			return Task<IList<TableResult>>.Factory.FromAsync(cloudTable.BeginExecuteBatch, cloudTable.EndExecuteBatch,
				batch, requestOptions, operationContext, null);
		}

		/// <summary>
		/// Executes a cancellable asynchronous batch operation on a table as an atomic operation, using the specified <see cref="TableRequestOptions" /> and <see cref="OperationContext" />.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="batch">The <see cref="TableBatchOperation" /> object representing the operations to execute on the table.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions" /> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>
		/// An enumerable collection of <see cref="TableResult" /> objects that contains the results, in order, of each operation in the <see cref="TableBatchOperation" /> on the table.
		/// </returns>
		[DoesServiceRequest]
		public static Task<IList<TableResult>> ExecuteBatchAsync(this CloudTable cloudTable, TableBatchOperation batch,
			TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken token)
		{
			return FromCancellableAsync<TableBatchOperation, TableRequestOptions, OperationContext, IList<TableResult>>(cloudTable.BeginExecuteBatch, cloudTable.EndExecuteBatch, batch, requestOptions, operationContext, token);
		}

		#endregion

		#region TableQuery ExecuteAsync Methods

		#region NonGeneric

		/// <summary>
		/// Executes an asynchronous segmented query operation using the specified <see cref="TableContinuationToken"/> continuation token.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="query">A <see cref="TableQuery"/> representing the query to execute.</param>
		/// <param name="continuationToken">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableQuerySegment<DynamicTableEntity>> ExecuteQuerySegmentedAsync(this CloudTable cloudTable, TableQuery query,
			TableContinuationToken continuationToken)
		{
			return Task<TableQuerySegment<DynamicTableEntity>>.Factory.FromAsync(cloudTable.BeginExecuteQuerySegmented, cloudTable.EndExecuteQuerySegmented, query, continuationToken, null);
		}

		/// <summary>
		/// Executes an asynchronous segmented query operation using the specified <see cref="TableContinuationToken"/> continuation token.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="query">A <see cref="TableQuery"/> representing the query to execute.</param>
		/// <param name="continuationToken">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableQuerySegment<DynamicTableEntity>> ExecuteQuerySegmentedAsync(this CloudTable cloudTable, TableQuery query,
			TableContinuationToken continuationToken, CancellationToken cancellationToken)
		{
			return FromCancellableAsync<TableQuery, TableContinuationToken, TableQuerySegment<DynamicTableEntity>>(cloudTable.BeginExecuteQuerySegmented,
				cloudTable.EndExecuteQuerySegmented, query, continuationToken, cancellationToken);
		}

		/// <summary>
		/// Executes an asynchronous operation to query a table in segmented mode using the specified <see cref="TableContinuationToken"/> continuation token, <see cref="TableRequestOptions"/>, and <see cref="OperationContext"/>.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="query">A <see cref="TableQuery"/> representing the query to execute.</param>
		/// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableQuerySegment<DynamicTableEntity>> ExecuteQuerySegmentedAsync(this CloudTable cloudTable, TableQuery query,
			TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext)
		{
			return Task<TableQuerySegment<DynamicTableEntity>>.Factory.FromAsync(
				(callback, state) => cloudTable.BeginExecuteQuerySegmented(query, token, requestOptions, operationContext, callback, state),
				cloudTable.EndExecuteQuerySegmented, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to query a table in segmented mode using the specified <see cref="TableContinuationToken"/> continuation token, <see cref="TableRequestOptions"/>, and <see cref="OperationContext"/>.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="query">A <see cref="TableQuery"/> representing the query to execute.</param>
		/// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableQuerySegment<DynamicTableEntity>> ExecuteQuerySegmentedAsync(this CloudTable cloudTable, TableQuery query,
			TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
		{
			return FromCancellableAsync(cloudTable.BeginExecuteQuerySegmented, cloudTable.EndExecuteQuerySegmented, query, token, requestOptions,
				operationContext, cancellationToken);
		}

		#endregion

		#region Generic

		/// <summary>
		/// Executes an asynchronous operation to query a table in segmented mode, using the specified <see cref="TableContinuationToken"/> continuation token.
		/// </summary>
		/// <typeparam name="TElement">The entity type of the query.</typeparam>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
		/// <param name="continuationToken">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableQuerySegment<TElement>> ExecuteQuerySegmentedAsync<TElement>(this CloudTable cloudTable, TableQuery<TElement> query, TableContinuationToken continuationToken) where TElement : ITableEntity, new()
		{
			return Task<TableQuerySegment<TElement>>.Factory.FromAsync(cloudTable.BeginExecuteQuerySegmented, cloudTable.EndExecuteQuerySegmented<TElement>, query, continuationToken, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to query a table in segmented mode, using the specified <see cref="TableContinuationToken"/> continuation token.
		/// </summary>
		/// <typeparam name="TElement">The entity type of the query.</typeparam>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
		/// <param name="continuationToken">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableQuerySegment<TElement>> ExecuteQuerySegmentedAsync<TElement>(this CloudTable cloudTable, TableQuery<TElement> query,
			TableContinuationToken continuationToken, CancellationToken cancellationToken) where TElement : ITableEntity, new()
		{
			return FromCancellableAsync<TableQuery<TElement>, TableContinuationToken, TableQuerySegment<TElement>>(cloudTable.BeginExecuteQuerySegmented, cloudTable.EndExecuteQuerySegmented<TElement>, query, continuationToken, cancellationToken);
		}

		/// <summary>
		/// Executes an asynchronous operation to query a table in segmented mode using the specified <see cref="TableContinuationToken"/> continuation token and <see cref="OperationContext"/>.
		/// </summary>
		/// <typeparam name="TElement">The entity type of the query.</typeparam>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
		/// <param name="continuationToken">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableQuerySegment<TElement>> ExecuteQuerySegmentedAsync<TElement>(this CloudTable cloudTable, TableQuery<TElement> query,
			TableContinuationToken continuationToken, TableRequestOptions requestOptions, OperationContext operationContext) where TElement : ITableEntity, new()
		{
			return Task<TableQuerySegment<TElement>>.Factory.FromAsync(
				(callback, state) => cloudTable.BeginExecuteQuerySegmented(query, continuationToken, requestOptions, operationContext, callback, state),
				cloudTable.EndExecuteQuerySegmented<TElement>, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to query a table in segmented mode using the specified <see cref="TableContinuationToken"/> continuation token and <see cref="OperationContext"/>.
		/// </summary>
		/// <typeparam name="TElement">The entity type of the query.</typeparam>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
		/// <param name="continuationToken">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableQuerySegment<TElement>> ExecuteQuerySegmentedAsync<TElement>(this CloudTable cloudTable, TableQuery<TElement> query,
			TableContinuationToken continuationToken, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken) where TElement : ITableEntity, new()
		{
			return FromCancellableAsync(cloudTable.BeginExecuteQuerySegmented, cloudTable.EndExecuteQuerySegmented<TElement>, query, continuationToken,
				requestOptions, operationContext, cancellationToken);
		}

		#endregion

		#region With Resolvers

		/// <summary>
		/// Executes an asynchronous operation to query a table in segmented mode, using the specified <see cref="EntityResolver"/> and <see cref="TableContinuationToken"/> continuation token.
		/// </summary>
		/// <typeparam name="TElement">The entity type of the query.</typeparam>
		/// <typeparam name="TResult">The type into which the <see cref="EntityResolver"/> will project the query results.</typeparam>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
		/// <param name="resolver">An <see cref="EntityResolver"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param>
		/// <param name="continuationToken">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TElement, TResult>(this CloudTable cloudTable, TableQuery<TElement> query, EntityResolver<TResult> resolver, TableContinuationToken continuationToken) where TElement : ITableEntity, new()
		{
			return Task<TableQuerySegment<TResult>>.Factory.FromAsync(cloudTable.BeginExecuteQuerySegmented, cloudTable.EndExecuteQuerySegmented<TElement, TResult>, query, resolver, continuationToken, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to query a table in segmented mode, using the specified <see cref="EntityResolver"/> and <see cref="TableContinuationToken"/> continuation token.
		/// </summary>
		/// <typeparam name="TElement">The entity type of the query.</typeparam>
		/// <typeparam name="TResult">The type into which the <see cref="EntityResolver"/> will project the query results.</typeparam>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
		/// <param name="resolver">An <see cref="EntityResolver"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param>
		/// <param name="continuationToken">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TElement, TResult>(this CloudTable cloudTable, TableQuery<TElement> query, EntityResolver<TResult> resolver,
			TableContinuationToken continuationToken, CancellationToken cancellationToken) where TElement : ITableEntity, new()
		{
			return FromCancellableAsync<TableQuery<TElement>, EntityResolver<TResult>, TableContinuationToken, TableQuerySegment<TResult>>(
				cloudTable.BeginExecuteQuerySegmented, cloudTable.EndExecuteQuerySegmented<TElement, TResult>, query, resolver,
				continuationToken, cancellationToken);
		}

		/// <summary>
		/// Executes an asynchronous operation to execute a query in segmented mode with the specified <see cref="TableContinuationToken"/> continuation token, <see cref="TableRequestOptions"/>, and <see cref="OperationContext"/>, applies the <see cref="EntityResolver"/> to the results.
		/// </summary>
		/// <typeparam name="TElement">The entity type of the query.</typeparam>
		/// <typeparam name="TResult">The type into which the <see cref="EntityResolver"/> will project the query results.</typeparam>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
		/// <param name="resolver">An <see cref="EntityResolver"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param>
		/// <param name="continuationToken">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TElement, TResult>(this CloudTable cloudTable, TableQuery<TElement> query, EntityResolver<TResult> resolver,
			TableContinuationToken continuationToken, TableRequestOptions requestOptions, OperationContext operationContext) where TElement : ITableEntity, new()
		{
			return Task<TableQuerySegment<TResult>>.Factory.FromAsync(
				(callback, state) => cloudTable.BeginExecuteQuerySegmented(query, resolver, continuationToken, requestOptions, operationContext, callback, state),
				cloudTable.EndExecuteQuerySegmented<TElement, TResult>, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to execute a query in segmented mode with the specified <see cref="TableContinuationToken"/> continuation token, <see cref="TableRequestOptions"/>, and <see cref="OperationContext"/>, applies the <see cref="EntityResolver"/> to the results.
		/// </summary>
		/// <typeparam name="TElement">The entity type of the query.</typeparam>
		/// <typeparam name="TResult">The type into which the <see cref="EntityResolver"/> will project the query results.</typeparam>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
		/// <param name="resolver">An <see cref="EntityResolver"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param>
		/// <param name="continuationToken">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>An <see cref="Task{T}"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TElement, TResult>(this CloudTable cloudTable, TableQuery<TElement> query, EntityResolver<TResult> resolver,
			TableContinuationToken continuationToken, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken) where TElement : ITableEntity, new()
		{
			return FromCancellableAsync(cloudTable.BeginExecuteQuerySegmented, cloudTable.EndExecuteQuerySegmented<TElement, TResult>, query, resolver, continuationToken,
				requestOptions, operationContext, cancellationToken);
		}

		#endregion

		#endregion

		#region CreateAsync

		/// <summary>
		/// Executes an asynchronous operation to create a table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task CreateAsync(this CloudTable cloudTable)
		{
			return Task.Factory.FromAsync(cloudTable.BeginCreate, cloudTable.EndCreate, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to create a table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task CreateAsync(this CloudTable cloudTable, CancellationToken token)
		{
			return FromCancellableAsync(cloudTable.BeginCreate, cloudTable.EndCreate, token);
		}

		/// <summary>
		/// Executes an asynchronous operation to create a table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task CreateAsync(this CloudTable cloudTable, TableRequestOptions requestOptions, OperationContext operationContext)
		{
			return Task.Factory.FromAsync(cloudTable.BeginCreate, cloudTable.EndCreate, requestOptions, operationContext, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to create a table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task CreateAsync(this CloudTable cloudTable, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken token)
		{
			return FromCancellableAsync(cloudTable.BeginCreate, cloudTable.EndCreate, requestOptions, operationContext, token);
		}

		#endregion

		#region CreateIfNotExistsAsync

		/// <summary>
		/// Executes an asynchronous operation to create a table if it does not already exist.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<bool> CreateIfNotExistsAsync(this CloudTable cloudTable)
		{
			return Task.Factory.FromAsync<bool>(cloudTable.BeginCreateIfNotExists, cloudTable.EndCreateIfNotExists, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to create a table if it does not already exist.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<bool> CreateIfNotExistsAsync(this CloudTable cloudTable, CancellationToken token)
		{
			return FromCancellableAsync<bool>(cloudTable.BeginCreateIfNotExists, cloudTable.EndCreateIfNotExists, token);
		}

		/// <summary>
		/// Executes an asynchronous operation to create a table if it does not already exist.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<bool> CreateIfNotExistsAsync(this CloudTable cloudTable, TableRequestOptions requestOptions, OperationContext operationContext)
		{
			return Task.Factory.FromAsync<TableRequestOptions, OperationContext, bool>(cloudTable.BeginCreateIfNotExists, cloudTable.EndCreateIfNotExists, requestOptions, operationContext, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to create a table if it does not already exist.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<bool> CreateIfNotExistsAsync(this CloudTable cloudTable, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken token)
		{
			return FromCancellableAsync<TableRequestOptions, OperationContext, bool>(cloudTable.BeginCreateIfNotExists, cloudTable.EndCreateIfNotExists, requestOptions, operationContext, token);
		}

		#endregion

		#region DeleteAsync

		/// <summary>
		/// Executes an asynchronous operation to delete a table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task DeleteAsync(this CloudTable cloudTable)
		{
			return Task.Factory.FromAsync(cloudTable.BeginDelete, cloudTable.EndDelete, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to delete a table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task DeleteAsync(this CloudTable cloudTable, CancellationToken token)
		{
			return FromCancellableAsync(cloudTable.BeginDelete, cloudTable.EndDelete, token);
		}

		/// <summary>
		/// Executes an asynchronous operation to delete a table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task DeleteAsync(this CloudTable cloudTable, TableRequestOptions requestOptions, OperationContext operationContext)
		{
			return Task.Factory.FromAsync(cloudTable.BeginDelete, cloudTable.EndDelete, requestOptions, operationContext, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to delete a table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task DeleteAsync(this CloudTable cloudTable, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken token)
		{
			return FromCancellableAsync(cloudTable.BeginDelete, cloudTable.EndDelete, requestOptions, operationContext, token);
		}

		#endregion

		#region DeleteIfExistsAsync

		/// <summary>
		/// Executes an asynchronous operation to delete the tables if it exists.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<bool> DeleteIfNotExistsAsync(this CloudTable cloudTable)
		{
			return Task.Factory.FromAsync<bool>(cloudTable.BeginDeleteIfExists, cloudTable.EndDeleteIfExists, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to delete the tables if it exists.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<bool> DeleteIfNotExistsAsync(this CloudTable cloudTable, CancellationToken token)
		{
			return FromCancellableAsync<bool>(cloudTable.BeginDeleteIfExists, cloudTable.EndDeleteIfExists, token);
		}

		/// <summary>
		/// Executes an asynchronous operation to delete the tables if it exists.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<bool> DeleteIfNotExistsAsync(this CloudTable cloudTable, TableRequestOptions requestOptions, OperationContext operationContext)
		{
			return Task.Factory.FromAsync<TableRequestOptions, OperationContext, bool>(cloudTable.BeginDeleteIfExists, cloudTable.EndDeleteIfExists, requestOptions, operationContext, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to delete the tables if it exists.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<bool> DeleteIfNotExistsAsync(this CloudTable cloudTable, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken token)
		{
			return FromCancellableAsync<TableRequestOptions, OperationContext, bool>(cloudTable.BeginDeleteIfExists, cloudTable.EndDeleteIfExists, requestOptions, operationContext, token);
		}

		#endregion

		#region ExistsAsync

		/// <summary>
		/// Executes an asynchronous operation to determine whether a table exists.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<bool> ExistsAsync(this CloudTable cloudTable)
		{
			return Task.Factory.FromAsync<bool>(cloudTable.BeginExists, cloudTable.EndExists, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to determine whether a table exists.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<bool> ExistsAsync(this CloudTable cloudTable, CancellationToken token)
		{
			return FromCancellableAsync<bool>(cloudTable.BeginExists, cloudTable.EndExists, token);
		}

		/// <summary>
		/// Executes an asynchronous operation to determine whether a table exists.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<bool> ExistsAsync(this CloudTable cloudTable, TableRequestOptions requestOptions, OperationContext operationContext)
		{
			return Task.Factory.FromAsync<TableRequestOptions, OperationContext, bool>(cloudTable.BeginExists, cloudTable.EndExists, requestOptions, operationContext, null);
		}

		/// <summary>
		/// Executes an asynchronous operation to determine whether a table exists.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<bool> ExistsAsync(this CloudTable cloudTable, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken token)
		{
			return FromCancellableAsync<TableRequestOptions, OperationContext, bool>(cloudTable.BeginExists, cloudTable.EndExists, requestOptions, operationContext, token);
		}

		#endregion

		#region PermissionsAsync

		/// <summary>
		/// Executes an asynchronous request to get the permissions settings for the table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TablePermissions> GetPermissionsAsync(this CloudTable cloudTable)
		{
			return Task.Factory.FromAsync<TablePermissions>(cloudTable.BeginGetPermissions, cloudTable.EndGetPermissions, null);
		}

		/// <summary>
		/// Executes an asynchronous request to get the permissions settings for the table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TablePermissions> GetPermissionsAsync(this CloudTable cloudTable, CancellationToken token)
		{
			return FromCancellableAsync<TablePermissions>(cloudTable.BeginGetPermissions, cloudTable.EndGetPermissions, token);
		}

		/// <summary>
		/// Executes an asynchronous request to get the permissions settings for the table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TablePermissions> GetPermissionsAsync(this CloudTable cloudTable, TableRequestOptions requestOptions, OperationContext operationContext)
		{
			return Task.Factory.FromAsync<TableRequestOptions, OperationContext, TablePermissions>(cloudTable.BeginGetPermissions, cloudTable.EndGetPermissions, requestOptions, operationContext, null);
		}

		/// <summary>
		/// Executes an asynchronous request to get the permissions settings for the table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task<TablePermissions> GetPermissionsAsync(this CloudTable cloudTable, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken token)
		{
			return FromCancellableAsync<TableRequestOptions, OperationContext, TablePermissions>(cloudTable.BeginGetPermissions, cloudTable.EndGetPermissions, requestOptions, operationContext, token);
		}

		/// <summary>
		/// Executes an asynchronous request to set permissions for the table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="permissions">The permissions to apply to the table.</param>
		/// <returns>An <see cref="Task"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task SetPermissionsAsync(this CloudTable cloudTable, TablePermissions permissions)
		{
			return Task.Factory.FromAsync(cloudTable.BeginSetPermissions, cloudTable.EndSetPermissions, permissions, null);
		}

		/// <summary>
		/// Executes an asynchronous request to set permissions for the table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="permissions">The permissions to apply to the table.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>
		/// An <see cref="ICancellableAsyncResult" /> that references the asynchronous operation.
		/// </returns>
		[DoesServiceRequest]
		public static Task SetPermissionsAsync(this CloudTable cloudTable, TablePermissions permissions, CancellationToken token)
		{
			return FromCancellableAsync(cloudTable.BeginSetPermissions, cloudTable.EndSetPermissions, permissions, token);
		}

		/// <summary>
		/// Executes an asynchronous request to set permissions for the table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="permissions">The permissions to apply to the table.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <returns>An <see cref="Task"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task SetPermissionsAsync(this CloudTable cloudTable, TablePermissions permissions, TableRequestOptions requestOptions, OperationContext operationContext)
		{
			return Task.Factory.FromAsync(cloudTable.BeginSetPermissions, cloudTable.EndSetPermissions, permissions,
				requestOptions, operationContext, null);
		}

		/// <summary>
		/// Executes an asynchronous request to set permissions for the table.
		/// </summary>
		/// <param name="cloudTable">The cloud table to run on.</param>
		/// <param name="permissions">The permissions to apply to the table.</param>
		/// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
		/// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>An <see cref="Task"/> that references the asynchronous operation.</returns>
		[DoesServiceRequest]
		public static Task SetPermissionsAsync(this CloudTable cloudTable, TablePermissions permissions, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken token)
		{
			return FromCancellableAsync(cloudTable.BeginSetPermissions, cloudTable.EndSetPermissions, permissions, requestOptions, operationContext, token);
		}

		#endregion
	}
}