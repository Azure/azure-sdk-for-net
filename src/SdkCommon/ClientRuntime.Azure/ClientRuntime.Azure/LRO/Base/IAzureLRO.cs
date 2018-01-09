// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.LRO
{
    using Microsoft.Rest.Azure;
    using System.Threading.Tasks;

    interface IRestLRO
    {
        string RESTOperationVerb { get; }
    }

    interface IAzureLRO<TResourceBody, TRequestHeaders> : IRestLRO
        where TResourceBody: class
        where TRequestHeaders: class
    {
        Task BeginLROAsync();
        Task<AzureOperationResponse<TResourceBody, TRequestHeaders>> GetLROResults();
    }
}


