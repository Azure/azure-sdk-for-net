// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Custom;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;

namespace Azure.AI.FormRecognizer
{
    [CodeGenClient("")]
    internal partial class ServiceClient
    {
        /// <summary> Get information about all custom models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<CustomModelInfo> GetCustomModelsPageableModelInfo(GetModelOptions? op, CancellationToken cancellationToken = default)
        {
            Page<CustomModelInfo> FirstPageFunc(int? pageSizeHint)
            {
                var response =  RestClient.GetCustomModels(op, cancellationToken);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            Page<CustomModelInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetCustomModelsNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get information about all custom models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<CustomModelInfo> GetCustomModelsPageableModelInfoAsync(GetModelOptions? op, CancellationToken cancellationToken = default)
        {

            async Task<Page<CustomModelInfo>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetCustomModelsAsync(op, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<CustomModelInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetCustomModelsNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

    }
}
