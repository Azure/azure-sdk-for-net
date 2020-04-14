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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<CustomFormModelInfo> GetCustomModelsPageableModelInfo(CancellationToken cancellationToken = default)
        {
            Page<CustomFormModelInfo> FirstPageFunc(int? pageSizeHint)
            {
                Response<Models_internal> response =  RestClient.ListCustomModels(cancellationToken);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomFormModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            Page<CustomFormModelInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                Response<Models_internal> response = RestClient.ListCustomModelsNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomFormModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get information about all custom models. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<CustomFormModelInfo> GetCustomModelsPageableModelInfoAsync(CancellationToken cancellationToken = default)
        {

            async Task<Page<CustomFormModelInfo>> FirstPageFunc(int? pageSizeHint)
            {
                Response<Models_internal> response = await RestClient.ListCustomModelsAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomFormModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<CustomFormModelInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                Response<Models_internal> response = await RestClient.ListCustomModelsNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomFormModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

    }
}
