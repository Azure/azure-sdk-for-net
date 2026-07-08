// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Analytics.PlanetaryComputer
{
/// <summary> Options for collection-level point query operations. </summary>
    public class GetCollectionPointOptions
    {
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
        /// <summary> STAC item IDs filter. </summary>
        public string Ids { get; set; }
        /// <summary> Bounding box filter. </summary>
        public string Bbox { get; set; }
        /// <summary> CQL2 query filter. </summary>
        public string Query { get; set; }
        /// <summary> Sort expression. </summary>
        public string SortBy { get; set; }
        /// <summary> Datetime filter. </summary>
        public string Datetime { get; set; }
        /// <summary> Subdataset name. </summary>
        public string SubdatasetName { get; set; }
        /// <summary> Subdataset band indexes. </summary>
        public IEnumerable<int> SubdatasetBands { get; set; }
        /// <summary> Coordinate Reference System for subdataset. </summary>
        public string Crs { get; set; }
        /// <summary> Xarray indexing. </summary>
        public IEnumerable<string> Sel { get; set; }
        /// <summary> Xarray indexing method. </summary>
        public SelMethod? SelMethod { get; set; }
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
        /// <summary> Coordinate Reference System of the input coordinates. </summary>
        public string CoordinateReferenceSystem { get; set; }
        /// <summary> Resampling method. </summary>
        public ResamplingMethod? Resampling { get; set; }
    }
}
