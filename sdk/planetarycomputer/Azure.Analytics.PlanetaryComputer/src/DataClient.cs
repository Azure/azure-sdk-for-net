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
    [CodeGenSuppress("RegisterMosaicsSearch", typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(float?), typeof(GeoJsonGeometry), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, BinaryData>), typeof(string), typeof(IEnumerable<StacSortExtension>), typeof(FilterLanguage?), typeof(MosaicMetadata), typeof(CancellationToken))]
    [CodeGenSuppress("RegisterMosaicsSearchAsync", typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(float?), typeof(GeoJsonGeometry), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, BinaryData>), typeof(string), typeof(IEnumerable<StacSortExtension>), typeof(FilterLanguage?), typeof(MosaicMetadata), typeof(CancellationToken))]
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

        #region Null Reference Workaround - Generator doesn't null-coalesce IDictionary parameters

        /// <summary> Register a Search query. </summary>
        /// <param name="collections"> List of STAC collection IDs to include in the mosaic. </param>
        /// <param name="ids"> List of specific STAC item IDs to include in the mosaic. </param>
        /// <param name="boundingBox"> Geographic bounding box to filter items [west, south, east, north]. </param>
        /// <param name="intersects"> GeoJSON geometry to spatially filter items by intersection. </param>
        /// <param name="query"> Query. </param>
        /// <param name="filter"> Filter. </param>
        /// <param name="datetime"> Temporal filter in RFC 3339 format or interval. </param>
        /// <param name="sortBy"> Criteria for ordering items in the mosaic. </param>
        /// <param name="filterLanguage"> Query language format used in the filter parameter. </param>
        /// <param name="metadata"> Additional metadata to associate with the mosaic. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<TilerMosaicSearchRegistrationResult> RegisterMosaicsSearch(IEnumerable<string> collections = default, IEnumerable<string> ids = default, float? boundingBox = default, GeoJsonGeometry intersects = default, IDictionary<string, BinaryData> query = default, IDictionary<string, BinaryData> filter = default, string datetime = default, IEnumerable<StacSortExtension> sortBy = default, FilterLanguage? filterLanguage = default, MosaicMetadata metadata = default, CancellationToken cancellationToken = default)
        {
            RegisterMosaicsSearchRequest spreadModel = new RegisterMosaicsSearchRequest(
                collections?.ToList() as IList<string> ?? new ChangeTrackingList<string>(),
                ids?.ToList() as IList<string> ?? new ChangeTrackingList<string>(),
                boundingBox,
                intersects,
                query ?? new ChangeTrackingDictionary<string, BinaryData>(),
                filter ?? new ChangeTrackingDictionary<string, BinaryData>(),
                datetime,
                sortBy?.ToList() as IList<StacSortExtension> ?? new ChangeTrackingList<StacSortExtension>(),
                filterLanguage,
                metadata,
                default);
            Response result = RegisterMosaicsSearch(spreadModel, cancellationToken.ToRequestContext());
            return Response.FromValue((TilerMosaicSearchRegistrationResult)result, result);
        }

        /// <summary> Register a Search query. </summary>
        /// <param name="collections"> List of STAC collection IDs to include in the mosaic. </param>
        /// <param name="ids"> List of specific STAC item IDs to include in the mosaic. </param>
        /// <param name="boundingBox"> Geographic bounding box to filter items [west, south, east, north]. </param>
        /// <param name="intersects"> GeoJSON geometry to spatially filter items by intersection. </param>
        /// <param name="query"> Query. </param>
        /// <param name="filter"> Filter. </param>
        /// <param name="datetime"> Temporal filter in RFC 3339 format or interval. </param>
        /// <param name="sortBy"> Criteria for ordering items in the mosaic. </param>
        /// <param name="filterLanguage"> Query language format used in the filter parameter. </param>
        /// <param name="metadata"> Additional metadata to associate with the mosaic. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<TilerMosaicSearchRegistrationResult>> RegisterMosaicsSearchAsync(IEnumerable<string> collections = default, IEnumerable<string> ids = default, float? boundingBox = default, GeoJsonGeometry intersects = default, IDictionary<string, BinaryData> query = default, IDictionary<string, BinaryData> filter = default, string datetime = default, IEnumerable<StacSortExtension> sortBy = default, FilterLanguage? filterLanguage = default, MosaicMetadata metadata = default, CancellationToken cancellationToken = default)
        {
            RegisterMosaicsSearchRequest spreadModel = new RegisterMosaicsSearchRequest(
                collections?.ToList() as IList<string> ?? new ChangeTrackingList<string>(),
                ids?.ToList() as IList<string> ?? new ChangeTrackingList<string>(),
                boundingBox,
                intersects,
                query ?? new ChangeTrackingDictionary<string, BinaryData>(),
                filter ?? new ChangeTrackingDictionary<string, BinaryData>(),
                datetime,
                sortBy?.ToList() as IList<StacSortExtension> ?? new ChangeTrackingList<StacSortExtension>(),
                filterLanguage,
                metadata,
                default);
            Response result = await RegisterMosaicsSearchAsync(spreadModel, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((TilerMosaicSearchRegistrationResult)result, result);
        }

        #endregion
    }
}
