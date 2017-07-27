// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;

    /// <summary>
    /// The base interface for all template interfaces that support execute operations.
    /// </summary>
    /// <typeparam name="T">The type of the resource returned from the execution.</typeparam>
    public interface IExecutable<T>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable
    {
        /// <summary>
        /// Execute the request.
        /// </summary>
        /// <return>Execution result object.</return>
        T Execute();

        /// <summary>
        /// Execute the request asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        Task<T> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true);

    }
}