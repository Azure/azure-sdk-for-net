// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.LRO
{
    using Microsoft.Rest.Azure;
    using System.Threading.Tasks;

    /// <summary>
    /// Base interface for LRO operations
    /// </summary>
    interface IRestLRO
    {
        /// <summary>
        /// REST Verb
        /// </summary>
        string RESTOperationVerb { get; }
    }

    /// <summary>
    /// Base interface for Azure LRO operation classes
    /// </summary>
    /// <typeparam name="TResourceBody"></typeparam>
    /// <typeparam name="TRequestHeaders"></typeparam>
    interface IAzureLRO<TResourceBody, TRequestHeaders> : IRestLRO
        where TResourceBody: class
        where TRequestHeaders: class
    {
        /// <summary>
        /// Function that will begin the LRO operation
        /// </summary>
        /// <returns></returns>
        Task BeginLROAsync();

        /// <summary>
        /// Returns LRO operation result
        /// </summary>
        /// <returns></returns>
        Task<AzureOperationResponse<TResourceBody, TRequestHeaders>> GetLROResults();
    }
}


