// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;
using Azure.Core;

namespace Azure.AI.FormRecognizer
{
    [CodeGenClient("")]
    internal partial class ServiceClient
    {
        /// <summary> Get information about all custom models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<CustomFormModelInfo> GetCustomModelsPageableModelInfo(GetModelOptions? op, CancellationToken cancellationToken = default)
        {
            Page<CustomFormModelInfo> FirstPageFunc(int? pageSizeHint)
            {
                var response =  RestClient.GetCustomModels(op, cancellationToken);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomFormModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            Page<CustomFormModelInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetCustomModelsNextPage(nextLink, op, cancellationToken);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomFormModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get information about all custom models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<CustomFormModelInfo> GetCustomModelsPageableModelInfoAsync(GetModelOptions? op, CancellationToken cancellationToken = default)
        {

            async Task<Page<CustomFormModelInfo>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetCustomModelsAsync(op, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomFormModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<CustomFormModelInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetCustomModelsNextPageAsync(nextLink, op, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomFormModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

    }
}
