// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Analytics.PlanetaryComputer
{
    public partial class DataClient
    {
        #region Item Point

        /// <summary> Get point value for a STAC item dataset. </summary>
        /// <param name="collectionId"> STAC Collection Identifier. </param>
        /// <param name="itemId"> STAC Item Identifier. </param>
        /// <param name="longitude"> Longitude. </param>
        /// <param name="latitude"> Latitude. </param>
        /// <param name="options"> Additional options for the request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<TilerCoreModelsResponsesPoint> GetItemPoint(string collectionId, string itemId, float longitude, float latitude, GetItemPointOptions options, CancellationToken cancellationToken = default)
        {
            return GetItemPoint(collectionId, itemId, longitude, latitude,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.SubdatasetName, options?.SubdatasetBands, options?.Crs, options?.Datetime,
                options?.Sel, options?.SelMethod, options?.CoordinateReferenceSystem, options?.Resampling,
                cancellationToken);
        }

        /// <summary> Get point value for a STAC item dataset. </summary>
        /// <param name="collectionId"> STAC Collection Identifier. </param>
        /// <param name="itemId"> STAC Item Identifier. </param>
        /// <param name="longitude"> Longitude. </param>
        /// <param name="latitude"> Latitude. </param>
        /// <param name="options"> Additional options for the request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual async Task<Response<TilerCoreModelsResponsesPoint>> GetItemPointAsync(string collectionId, string itemId, float longitude, float latitude, GetItemPointOptions options, CancellationToken cancellationToken = default)
        {
            return await GetItemPointAsync(collectionId, itemId, longitude, latitude,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.SubdatasetName, options?.SubdatasetBands, options?.Crs, options?.Datetime,
                options?.Sel, options?.SelMethod, options?.CoordinateReferenceSystem, options?.Resampling,
                cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Item TileJson

        /// <summary> Return TileJSON document for an item. </summary>
        /// <param name="collectionId"> STAC Collection Identifier. </param>
        /// <param name="itemId"> STAC Item Identifier. </param>
        /// <param name="options"> Additional options for the request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<TileJsonMetadata> GetItemTileJson(string collectionId, string itemId, GetItemTileJsonOptions options, CancellationToken cancellationToken = default)
        {
            return GetItemTileJson(collectionId, itemId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.Algorithm, options?.AlgorithmParams, options?.TileMatrixSetId, options?.TileFormat,
                options?.TileScale, options?.MinZoom, options?.MaxZoom, options?.Buffer, options?.ColorFormula,
                options?.Resampling, options?.Rescale, options?.ColorMapName, options?.ColorMap,
                options?.ReturnMask, options?.Padding, options?.SubdatasetName, options?.SubdatasetBands,
                options?.Crs, options?.Datetime, options?.Sel, options?.SelMethod,
                cancellationToken);
        }

        /// <summary> Return TileJSON document for an item. </summary>
        public virtual async Task<Response<TileJsonMetadata>> GetItemTileJsonAsync(string collectionId, string itemId, GetItemTileJsonOptions options, CancellationToken cancellationToken = default)
        {
            return await GetItemTileJsonAsync(collectionId, itemId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.Algorithm, options?.AlgorithmParams, options?.TileMatrixSetId, options?.TileFormat,
                options?.TileScale, options?.MinZoom, options?.MaxZoom, options?.Buffer, options?.ColorFormula,
                options?.Resampling, options?.Rescale, options?.ColorMapName, options?.ColorMap,
                options?.ReturnMask, options?.Padding, options?.SubdatasetName, options?.SubdatasetBands,
                options?.Crs, options?.Datetime, options?.Sel, options?.SelMethod,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return TileJSON document for an item with a specific TileMatrixSet. </summary>
        /// <param name="collectionId"> STAC Collection Identifier. </param>
        /// <param name="itemId"> STAC Item Identifier. </param>
        /// <param name="tileMatrixSetId"> TileMatrixSet identifier. </param>
        /// <param name="options"> Additional options for the request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<TileJsonMetadata> GetItemTileJsonByTms(string collectionId, string itemId, string tileMatrixSetId, GetItemTileJsonOptions options, CancellationToken cancellationToken = default)
        {
            return GetItemTileJsonByTms(collectionId, itemId, tileMatrixSetId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.Algorithm, options?.AlgorithmParams, options?.TileFormat,
                options?.TileScale, options?.MinZoom, options?.MaxZoom, options?.Buffer, options?.ColorFormula,
                options?.Resampling, options?.Rescale, options?.ColorMapName, options?.ColorMap,
                options?.ReturnMask, options?.Padding, options?.SubdatasetName, options?.SubdatasetBands,
                options?.Crs, options?.Datetime, options?.Sel, options?.SelMethod,
                cancellationToken);
        }

        /// <summary> Return TileJSON document for an item with a specific TileMatrixSet. </summary>
        public virtual async Task<Response<TileJsonMetadata>> GetItemTileJsonByTmsAsync(string collectionId, string itemId, string tileMatrixSetId, GetItemTileJsonOptions options, CancellationToken cancellationToken = default)
        {
            return await GetItemTileJsonByTmsAsync(collectionId, itemId, tileMatrixSetId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.Algorithm, options?.AlgorithmParams, options?.TileFormat,
                options?.TileScale, options?.MinZoom, options?.MaxZoom, options?.Buffer, options?.ColorFormula,
                options?.Resampling, options?.Rescale, options?.ColorMapName, options?.ColorMap,
                options?.ReturnMask, options?.Padding, options?.SubdatasetName, options?.SubdatasetBands,
                options?.Crs, options?.Datetime, options?.Sel, options?.SelMethod,
                cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Collection TileJson

        /// <summary> Return TileJSON document for a collection. </summary>
        /// <param name="collectionId"> STAC Collection Identifier. </param>
        /// <param name="options"> Additional options for the request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<TileJsonMetadata> GetCollectionTileJson(string collectionId, GetCollectionTileJsonOptions options, CancellationToken cancellationToken = default)
        {
            return GetCollectionTileJson(collectionId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.ScanLimit, options?.ItemsLimit, options?.TimeLimit, options?.ExitWhenFull,
                options?.SkipCovered, options?.Ids, options?.Bbox, options?.Query, options?.SortBy,
                options?.Datetime, options?.SubdatasetName, options?.SubdatasetBands, options?.Crs,
                options?.Sel, options?.SelMethod, options?.Algorithm, options?.AlgorithmParams,
                options?.TileMatrixSetId, options?.TileFormat, options?.TileScale, options?.MinZoom,
                options?.MaxZoom, options?.Buffer, options?.ColorFormula, options?.Collection,
                options?.Resampling, options?.PixelSelection, options?.Rescale, options?.ColorMapName,
                options?.ColorMap, options?.ReturnMask, options?.Padding,
                cancellationToken);
        }

        /// <summary> Return TileJSON document for a collection. </summary>
        public virtual async Task<Response<TileJsonMetadata>> GetCollectionTileJsonAsync(string collectionId, GetCollectionTileJsonOptions options, CancellationToken cancellationToken = default)
        {
            return await GetCollectionTileJsonAsync(collectionId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.ScanLimit, options?.ItemsLimit, options?.TimeLimit, options?.ExitWhenFull,
                options?.SkipCovered, options?.Ids, options?.Bbox, options?.Query, options?.SortBy,
                options?.Datetime, options?.SubdatasetName, options?.SubdatasetBands, options?.Crs,
                options?.Sel, options?.SelMethod, options?.Algorithm, options?.AlgorithmParams,
                options?.TileMatrixSetId, options?.TileFormat, options?.TileScale, options?.MinZoom,
                options?.MaxZoom, options?.Buffer, options?.ColorFormula, options?.Collection,
                options?.Resampling, options?.PixelSelection, options?.Rescale, options?.ColorMapName,
                options?.ColorMap, options?.ReturnMask, options?.Padding,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return TileJSON document for a collection with a specific TileMatrixSet. </summary>
        public virtual Response<TileJsonMetadata> GetCollectionTileJsonByTms(string collectionId, string tileMatrixSetId, GetCollectionTileJsonOptions options, CancellationToken cancellationToken = default)
        {
            return GetCollectionTileJsonByTms(collectionId, tileMatrixSetId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.ScanLimit, options?.ItemsLimit, options?.TimeLimit, options?.ExitWhenFull,
                options?.SkipCovered, options?.Ids, options?.Bbox, options?.Query, options?.SortBy,
                options?.Datetime, options?.SubdatasetName, options?.SubdatasetBands, options?.Crs,
                options?.Sel, options?.SelMethod, options?.Algorithm, options?.AlgorithmParams,
                options?.TileFormat, options?.TileScale, options?.MinZoom,
                options?.MaxZoom, options?.Buffer, options?.ColorFormula, options?.Collection,
                options?.Resampling, options?.PixelSelection, options?.Rescale, options?.ColorMapName,
                options?.ColorMap, options?.ReturnMask, options?.Padding,
                cancellationToken);
        }

        /// <summary> Return TileJSON document for a collection with a specific TileMatrixSet. </summary>
        public virtual async Task<Response<TileJsonMetadata>> GetCollectionTileJsonByTmsAsync(string collectionId, string tileMatrixSetId, GetCollectionTileJsonOptions options, CancellationToken cancellationToken = default)
        {
            return await GetCollectionTileJsonByTmsAsync(collectionId, tileMatrixSetId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.ScanLimit, options?.ItemsLimit, options?.TimeLimit, options?.ExitWhenFull,
                options?.SkipCovered, options?.Ids, options?.Bbox, options?.Query, options?.SortBy,
                options?.Datetime, options?.SubdatasetName, options?.SubdatasetBands, options?.Crs,
                options?.Sel, options?.SelMethod, options?.Algorithm, options?.AlgorithmParams,
                options?.TileFormat, options?.TileScale, options?.MinZoom,
                options?.MaxZoom, options?.Buffer, options?.ColorFormula, options?.Collection,
                options?.Resampling, options?.PixelSelection, options?.Rescale, options?.ColorMapName,
                options?.ColorMap, options?.ReturnMask, options?.Padding,
                cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Search TileJson

        /// <summary> Return TileJSON document for a search. </summary>
        /// <param name="searchId"> PgSTAC Search Identifier. </param>
        /// <param name="options"> Additional options for the request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<TileJsonMetadata> GetSearchTileJson(string searchId, GetSearchTileJsonOptions options, CancellationToken cancellationToken = default)
        {
            return GetSearchTileJson(searchId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.ScanLimit, options?.ItemsLimit, options?.TimeLimit, options?.ExitWhenFull,
                options?.SkipCovered, options?.SubdatasetName, options?.SubdatasetBands, options?.Crs,
                options?.Datetime, options?.Sel, options?.SelMethod, options?.TileMatrixSetId,
                options?.TileFormat, options?.TileScale, options?.MinZoom, options?.MaxZoom,
                options?.Padding, options?.Buffer, options?.ColorFormula, options?.CollectionId,
                options?.Resampling, options?.PixelSelection, options?.Algorithm, options?.AlgorithmParams,
                options?.Rescale, options?.ColorMapName, options?.ColorMap, options?.ReturnMask,
                cancellationToken);
        }

        /// <summary> Return TileJSON document for a search. </summary>
        public virtual async Task<Response<TileJsonMetadata>> GetSearchTileJsonAsync(string searchId, GetSearchTileJsonOptions options, CancellationToken cancellationToken = default)
        {
            return await GetSearchTileJsonAsync(searchId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.ScanLimit, options?.ItemsLimit, options?.TimeLimit, options?.ExitWhenFull,
                options?.SkipCovered, options?.SubdatasetName, options?.SubdatasetBands, options?.Crs,
                options?.Datetime, options?.Sel, options?.SelMethod, options?.TileMatrixSetId,
                options?.TileFormat, options?.TileScale, options?.MinZoom, options?.MaxZoom,
                options?.Padding, options?.Buffer, options?.ColorFormula, options?.CollectionId,
                options?.Resampling, options?.PixelSelection, options?.Algorithm, options?.AlgorithmParams,
                options?.Rescale, options?.ColorMapName, options?.ColorMap, options?.ReturnMask,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return TileJSON document for a search with a specific TileMatrixSet. </summary>
        public virtual Response<TileJsonMetadata> GetSearchTileJsonByTms(string searchId, string tileMatrixSetId, GetSearchTileJsonOptions options, CancellationToken cancellationToken = default)
        {
            return GetSearchTileJsonByTms(searchId, tileMatrixSetId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.ScanLimit, options?.ItemsLimit, options?.TimeLimit, options?.ExitWhenFull,
                options?.SkipCovered, options?.SubdatasetName, options?.SubdatasetBands, options?.Crs,
                options?.Datetime, options?.Sel, options?.SelMethod, options?.Algorithm,
                options?.AlgorithmParams, options?.MinZoom, options?.MaxZoom, options?.TileFormat,
                options?.TileScale, options?.Buffer, options?.ColorFormula, options?.CollectionId,
                options?.Resampling, options?.PixelSelection, options?.Rescale, options?.ColorMapName,
                options?.ColorMap, options?.ReturnMask, options?.Padding,
                cancellationToken);
        }

        /// <summary> Return TileJSON document for a search with a specific TileMatrixSet. </summary>
        public virtual async Task<Response<TileJsonMetadata>> GetSearchTileJsonByTmsAsync(string searchId, string tileMatrixSetId, GetSearchTileJsonOptions options, CancellationToken cancellationToken = default)
        {
            return await GetSearchTileJsonByTmsAsync(searchId, tileMatrixSetId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.ScanLimit, options?.ItemsLimit, options?.TimeLimit, options?.ExitWhenFull,
                options?.SkipCovered, options?.SubdatasetName, options?.SubdatasetBands, options?.Crs,
                options?.Datetime, options?.Sel, options?.SelMethod, options?.Algorithm,
                options?.AlgorithmParams, options?.MinZoom, options?.MaxZoom, options?.TileFormat,
                options?.TileScale, options?.Buffer, options?.ColorFormula, options?.CollectionId,
                options?.Resampling, options?.PixelSelection, options?.Rescale, options?.ColorMapName,
                options?.ColorMap, options?.ReturnMask, options?.Padding,
                cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Collection Point

        /// <summary> Get point value for a collection. </summary>
        public virtual Response<TilerCoreModelsResponsesPoint> GetCollectionPoint(string collectionId, float longitude, float latitude, GetCollectionPointOptions options, CancellationToken cancellationToken = default)
        {
            return GetCollectionPoint(collectionId, longitude, latitude,
                options?.ScanLimit, options?.ItemsLimit, options?.TimeLimit, options?.ExitWhenFull,
                options?.SkipCovered, options?.Ids, options?.Bbox, options?.Query, options?.SortBy,
                options?.Datetime, options?.SubdatasetName, options?.SubdatasetBands, options?.Crs,
                options?.Sel, options?.SelMethod, options?.Bidx, options?.Assets, options?.Expression,
                options?.AssetBandIndices, options?.AssetAsBand, options?.NoData, options?.Unscale,
                options?.Reproject, options?.CoordinateReferenceSystem, options?.Resampling,
                cancellationToken);
        }

        /// <summary> Get point value for a collection. </summary>
        public virtual async Task<Response<TilerCoreModelsResponsesPoint>> GetCollectionPointAsync(string collectionId, float longitude, float latitude, GetCollectionPointOptions options, CancellationToken cancellationToken = default)
        {
            return await GetCollectionPointAsync(collectionId, longitude, latitude,
                options?.ScanLimit, options?.ItemsLimit, options?.TimeLimit, options?.ExitWhenFull,
                options?.SkipCovered, options?.Ids, options?.Bbox, options?.Query, options?.SortBy,
                options?.Datetime, options?.SubdatasetName, options?.SubdatasetBands, options?.Crs,
                options?.Sel, options?.SelMethod, options?.Bidx, options?.Assets, options?.Expression,
                options?.AssetBandIndices, options?.AssetAsBand, options?.NoData, options?.Unscale,
                options?.Reproject, options?.CoordinateReferenceSystem, options?.Resampling,
                cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Search Point

        /// <summary> Get point value for a search. </summary>
        public virtual Response<TilerCoreModelsResponsesPoint> GetSearchPoint(string searchId, float longitude, float latitude, GetSearchPointOptions options, CancellationToken cancellationToken = default)
        {
            return GetSearchPoint(searchId, longitude, latitude,
                options?.ScanLimit, options?.ItemsLimit, options?.TimeLimit, options?.ExitWhenFull,
                options?.SkipCovered, options?.SubdatasetName, options?.SubdatasetBands, options?.Crs,
                options?.Datetime, options?.Sel, options?.SelMethod, options?.Bidx, options?.Assets,
                options?.Expression, options?.AssetBandIndices, options?.AssetAsBand, options?.NoData,
                options?.Unscale, options?.Reproject, options?.CoordinateReferenceSystem, options?.Resampling,
                cancellationToken);
        }

        /// <summary> Get point value for a search. </summary>
        public virtual async Task<Response<TilerCoreModelsResponsesPoint>> GetSearchPointAsync(string searchId, float longitude, float latitude, GetSearchPointOptions options, CancellationToken cancellationToken = default)
        {
            return await GetSearchPointAsync(searchId, longitude, latitude,
                options?.ScanLimit, options?.ItemsLimit, options?.TimeLimit, options?.ExitWhenFull,
                options?.SkipCovered, options?.SubdatasetName, options?.SubdatasetBands, options?.Crs,
                options?.Datetime, options?.Sel, options?.SelMethod, options?.Bidx, options?.Assets,
                options?.Expression, options?.AssetBandIndices, options?.AssetAsBand, options?.NoData,
                options?.Unscale, options?.Reproject, options?.CoordinateReferenceSystem, options?.Resampling,
                cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Item Statistics

        /// <summary> Return item statistics (merged). </summary>
        public virtual Response<TilerStacItemStatistics> GetItemStatistics(string collectionId, string itemId, GetItemStatisticsOptions options, CancellationToken cancellationToken = default)
        {
            return GetItemStatistics(collectionId, itemId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.Resampling, options?.MaxSize, options?.Categorical, options?.CategoriesPixels,
                options?.Percentiles, options?.HistogramBins, options?.HistogramRange,
                options?.SubdatasetName, options?.SubdatasetBands, options?.Crs, options?.Datetime,
                options?.Sel, options?.SelMethod, options?.Algorithm, options?.AlgorithmParams,
                options?.Height, options?.Width,
                cancellationToken);
        }

        /// <summary> Return item statistics (merged). </summary>
        public virtual async Task<Response<TilerStacItemStatistics>> GetItemStatisticsAsync(string collectionId, string itemId, GetItemStatisticsOptions options, CancellationToken cancellationToken = default)
        {
            return await GetItemStatisticsAsync(collectionId, itemId,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.Resampling, options?.MaxSize, options?.Categorical, options?.CategoriesPixels,
                options?.Percentiles, options?.HistogramBins, options?.HistogramRange,
                options?.SubdatasetName, options?.SubdatasetBands, options?.Crs, options?.Datetime,
                options?.Sel, options?.SelMethod, options?.Algorithm, options?.AlgorithmParams,
                options?.Height, options?.Width,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return per-asset statistics. </summary>
        public virtual Response<AssetStatisticsResult> GetItemAssetStatistics(string collectionId, string itemId, GetItemAssetStatisticsOptions options, CancellationToken cancellationToken = default)
        {
            return GetItemAssetStatistics(collectionId, itemId,
                options?.Bidx, options?.Assets, options?.AssetBandIndices, options?.NoData,
                options?.Unscale, options?.Reproject, options?.Resampling, options?.MaxSize,
                options?.Categorical, options?.CategoriesPixels, options?.Percentiles,
                options?.HistogramBins, options?.HistogramRange, options?.SubdatasetName,
                options?.SubdatasetBands, options?.Crs, options?.Datetime, options?.Sel,
                options?.SelMethod, options?.AssetExpression, options?.Height, options?.Width,
                cancellationToken);
        }

        /// <summary> Return per-asset statistics. </summary>
        public virtual async Task<Response<AssetStatisticsResult>> GetItemAssetStatisticsAsync(string collectionId, string itemId, GetItemAssetStatisticsOptions options, CancellationToken cancellationToken = default)
        {
            return await GetItemAssetStatisticsAsync(collectionId, itemId,
                options?.Bidx, options?.Assets, options?.AssetBandIndices, options?.NoData,
                options?.Unscale, options?.Reproject, options?.Resampling, options?.MaxSize,
                options?.Categorical, options?.CategoriesPixels, options?.Percentiles,
                options?.HistogramBins, options?.HistogramRange, options?.SubdatasetName,
                options?.SubdatasetBands, options?.Crs, options?.Datetime, options?.Sel,
                options?.SelMethod, options?.AssetExpression, options?.Height, options?.Width,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return statistics for a GeoJSON feature. </summary>
        public virtual Response<StacItemStatisticsGeoJson> GetItemFeatureStatistics(string collectionId, string itemId, GeoJsonFeature body, GetItemFeatureStatisticsOptions options, CancellationToken cancellationToken = default)
        {
            return GetItemFeatureStatistics(collectionId, itemId, body,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.CoordinateReferenceSystem, options?.Resampling, options?.MaxSize,
                options?.Categorical, options?.CategoriesPixels, options?.Percentiles,
                options?.HistogramBins, options?.HistogramRange, options?.DestinationCrs,
                options?.SubdatasetName, options?.SubdatasetBands, options?.Crs, options?.Datetime,
                options?.Sel, options?.SelMethod, options?.Algorithm, options?.AlgorithmParams,
                options?.Height, options?.Width,
                cancellationToken);
        }

        /// <summary> Return statistics for a GeoJSON feature. </summary>
        public virtual async Task<Response<StacItemStatisticsGeoJson>> GetItemFeatureStatisticsAsync(string collectionId, string itemId, GeoJsonFeature body, GetItemFeatureStatisticsOptions options, CancellationToken cancellationToken = default)
        {
            return await GetItemFeatureStatisticsAsync(collectionId, itemId, body,
                options?.Bidx, options?.Assets, options?.Expression, options?.AssetBandIndices,
                options?.AssetAsBand, options?.NoData, options?.Unscale, options?.Reproject,
                options?.CoordinateReferenceSystem, options?.Resampling, options?.MaxSize,
                options?.Categorical, options?.CategoriesPixels, options?.Percentiles,
                options?.HistogramBins, options?.HistogramRange, options?.DestinationCrs,
                options?.SubdatasetName, options?.SubdatasetBands, options?.Crs, options?.Datetime,
                options?.Sel, options?.SelMethod, options?.Algorithm, options?.AlgorithmParams,
                options?.Height, options?.Width,
                cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Item Info

        /// <summary> Return item asset info. </summary>
        public virtual Response<TilerInfoMapResult> GetItemInfo(string collectionId, string itemId, GetItemInfoOptions options, CancellationToken cancellationToken = default)
        {
            return GetItemInfo(collectionId, itemId,
                options?.SubdatasetName, options?.SubdatasetBands, options?.Crs, options?.Datetime,
                options?.Sel, options?.SelMethod, options?.Assets,
                cancellationToken);
        }

        /// <summary> Return item asset info. </summary>
        public virtual async Task<Response<TilerInfoMapResult>> GetItemInfoAsync(string collectionId, string itemId, GetItemInfoOptions options, CancellationToken cancellationToken = default)
        {
            return await GetItemInfoAsync(collectionId, itemId,
                options?.SubdatasetName, options?.SubdatasetBands, options?.Crs, options?.Datetime,
                options?.Sel, options?.SelMethod, options?.Assets,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return item asset info as GeoJSON. </summary>
        public virtual Response<TilerInfoGeoJsonFeature> GetItemInfoGeoJson(string collectionId, string itemId, GetItemInfoOptions options, CancellationToken cancellationToken = default)
        {
            return GetItemInfoGeoJson(collectionId, itemId,
                options?.SubdatasetName, options?.SubdatasetBands, options?.Crs, options?.Datetime,
                options?.Sel, options?.SelMethod, options?.Assets,
                cancellationToken);
        }

        /// <summary> Return item asset info as GeoJSON. </summary>
        public virtual async Task<Response<TilerInfoGeoJsonFeature>> GetItemInfoGeoJsonAsync(string collectionId, string itemId, GetItemInfoOptions options, CancellationToken cancellationToken = default)
        {
            return await GetItemInfoGeoJsonAsync(collectionId, itemId,
                options?.SubdatasetName, options?.SubdatasetBands, options?.Crs, options?.Datetime,
                options?.Sel, options?.SelMethod, options?.Assets,
                cancellationToken).ConfigureAwait(false);
        }

        #endregion
    }
}
