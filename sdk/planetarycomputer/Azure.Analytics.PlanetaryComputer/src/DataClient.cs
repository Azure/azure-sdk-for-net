// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Analytics.PlanetaryComputer
{
    // Workaround for generator bugs:
    // 1. ToObjectFromJson<T>() causes AOT warnings (IL2026, IL3050)
    // 2. RegisterMosaicsSearch methods don't null-coalesce query/filter parameters causing NullReferenceException
    [CodeGenSuppress("GetTileMatrices", typeof(CancellationToken))]
    [CodeGenSuppress("GetTileMatricesAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetAvailableAssets", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAvailableAssetsAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class DataClient
    {
        #region AOT Workaround - ToObjectFromJson<T>() causes IL2026/IL3050 warnings

        /// <summary> Return Matrix List. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<IReadOnlyList<string>> GetTileMatrices(CancellationToken cancellationToken = default)
        {
            Response result = GetTileMatrices(cancellationToken.ToRequestContext());
            return Response.FromValue(DeserializeStringList(result.Content), result);
        }

        /// <summary> Return Matrix List. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<IReadOnlyList<string>>> GetTileMatricesAsync(CancellationToken cancellationToken = default)
        {
            Response result = await GetTileMatricesAsync(cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue(DeserializeStringList(result.Content), result);
        }

        /// <summary> Return a list of supported assets. </summary>
        /// <param name="collectionId"> STAC Collection Identifier. </param>
        /// <param name="itemId"> STAC Item Identifier. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="collectionId"/> or <paramref name="itemId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="collectionId"/> or <paramref name="itemId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<IReadOnlyList<string>> GetAvailableAssets(string collectionId, string itemId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(collectionId, nameof(collectionId));
            Argument.AssertNotNullOrEmpty(itemId, nameof(itemId));

            Response result = GetAvailableAssets(collectionId, itemId, cancellationToken.ToRequestContext());
            return Response.FromValue(DeserializeStringList(result.Content), result);
        }

        /// <summary> Return a list of supported assets. </summary>
        /// <param name="collectionId"> STAC Collection Identifier. </param>
        /// <param name="itemId"> STAC Item Identifier. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="collectionId"/> or <paramref name="itemId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="collectionId"/> or <paramref name="itemId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<IReadOnlyList<string>>> GetAvailableAssetsAsync(string collectionId, string itemId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(collectionId, nameof(collectionId));
            Argument.AssertNotNullOrEmpty(itemId, nameof(itemId));

            Response result = await GetAvailableAssetsAsync(collectionId, itemId, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue(DeserializeStringList(result.Content), result);
        }

        /// <summary>
        /// Deserializes a JSON array of strings from the response content.
        /// This is an AOT-compatible alternative to BinaryData.ToObjectFromJson&lt;IReadOnlyList&lt;string&gt;&gt;().
        /// </summary>
        private static IReadOnlyList<string> DeserializeStringList(BinaryData content)
        {
            using JsonDocument document = JsonDocument.Parse(content);
            var list = new List<string>();
            foreach (JsonElement element in document.RootElement.EnumerateArray())
            {
                list.Add(element.GetString());
            }
            return list;
        }

        #endregion
    }
}
