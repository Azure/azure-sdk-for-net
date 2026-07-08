// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Analytics.PlanetaryComputer
{
/// <summary> Options for search-based TileJSON operations. </summary>
    public class GetSearchTileJsonOptions
    {
        /// <summary> Per asset band indexes. </summary>
        public IEnumerable<int> Bidx { get; set; }
        /// <summary> Asset names. </summary>
        public IEnumerable<string> Assets { get; set; }
        /// <summary> Band math expression. </summary>
        public string Expression { get; set; }
        /// <summary> Per asset band math expression. </summary>
        public IEnumerable<string> AssetBandIndices { get; set; }
        /// <summary> Treat each asset as a single band. </summary>
        public bool? AssetAsBand { get; set; }
        /// <summary> Overwrite internal nodata value. </summary>
        public string NoData { get; set; }
        /// <summary> Apply internal scale/offset. </summary>
        public bool? Unscale { get; set; }
        /// <summary> WarpKernel resampling algorithm for reprojection. </summary>
        public WarpKernelResampling? Reproject { get; set; }
        /// <summary> Scan limit for mosaic. </summary>
        public int? ScanLimit { get; set; }
        /// <summary> Items limit per geometry. </summary>
        public int? ItemsLimit { get; set; }
        /// <summary> Time limit in seconds. </summary>
        public int? TimeLimit { get; set; }
        /// <summary> Return when geometry is fully covered. </summary>
        public bool? ExitWhenFull { get; set; }
        /// <summary> Skip items covered by previous items. </summary>
        public bool? SkipCovered { get; set; }
        /// <summary> Subdataset name. </summary>
        public string SubdatasetName { get; set; }
        /// <summary> Subdataset band indexes. </summary>
        public IEnumerable<int> SubdatasetBands { get; set; }
        /// <summary> Coordinate Reference System for subdataset. </summary>
        public string Crs { get; set; }
        /// <summary> Datetime filter. </summary>
        public string Datetime { get; set; }
        /// <summary> Xarray indexing. </summary>
        public IEnumerable<string> Sel { get; set; }
        /// <summary> Xarray indexing method. </summary>
        public SelMethod? SelMethod { get; set; }
        /// <summary> TileMatrixSet identifier. </summary>
        public TileMatrixSetId? TileMatrixSetId { get; set; }
        /// <summary> Output image format. </summary>
        public TilerImageFormat? TileFormat { get; set; }
        /// <summary> Tile size scale. </summary>
        public int? TileScale { get; set; }
        /// <summary> Minimum zoom level. </summary>
        public int? MinZoom { get; set; }
        /// <summary> Maximum zoom level. </summary>
        public int? MaxZoom { get; set; }
        /// <summary> Padding to apply to tile edges. </summary>
        public int? Padding { get; set; }
        /// <summary> Buffer on each side of the tile. </summary>
        public float? Buffer { get; set; }
        /// <summary> rio-color formula. </summary>
        public string ColorFormula { get; set; }
        /// <summary> STAC collection ID for context. </summary>
        public string CollectionId { get; set; }
        /// <summary> Resampling method. </summary>
        public ResamplingMethod? Resampling { get; set; }
        /// <summary> Pixel selection method. </summary>
        public PixelSelection? PixelSelection { get; set; }
        /// <summary> Terrain algorithm. </summary>
        public TerrainAlgorithm? Algorithm { get; set; }
        /// <summary> JSON encoded terrain algorithm parameters. </summary>
        public string AlgorithmParams { get; set; }
        /// <summary> Rescale ranges. </summary>
        public IEnumerable<string> Rescale { get; set; }
        /// <summary> Colormap name. </summary>
        public ColorMapNames? ColorMapName { get; set; }
        /// <summary> JSON encoded custom colormap. </summary>
        public string ColorMap { get; set; }
        /// <summary> Add mask to the output data. </summary>
        public bool? ReturnMask { get; set; }
    }
}
