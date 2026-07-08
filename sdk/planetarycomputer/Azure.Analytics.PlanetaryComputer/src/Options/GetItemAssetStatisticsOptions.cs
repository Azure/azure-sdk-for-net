// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Analytics.PlanetaryComputer
{
/// <summary> Options for item asset statistics operations. </summary>
    public class GetItemAssetStatisticsOptions
    {
        /// <summary> Per asset band indexes. </summary>
        public IEnumerable<int> Bidx { get; set; }
        /// <summary> Asset names. </summary>
        public IEnumerable<string> Assets { get; set; }
        /// <summary> Per asset band math expression. </summary>
        public IEnumerable<string> AssetBandIndices { get; set; }
        /// <summary> Overwrite internal nodata value. </summary>
        public string NoData { get; set; }
        /// <summary> Apply internal scale/offset. </summary>
        public bool? Unscale { get; set; }
        /// <summary> WarpKernel resampling algorithm for reprojection. </summary>
        public WarpKernelResampling? Reproject { get; set; }
        /// <summary> Resampling method. </summary>
        public ResamplingMethod? Resampling { get; set; }
        /// <summary> Max image size for statistics calculation. </summary>
        public int? MaxSize { get; set; }
        /// <summary> Return statistics for categorical dataset. </summary>
        public bool? Categorical { get; set; }
        /// <summary> Pixel values for categories. </summary>
        public IEnumerable<int> CategoriesPixels { get; set; }
        /// <summary> Percentile values. </summary>
        public IEnumerable<int> Percentiles { get; set; }
        /// <summary> Histogram bins. </summary>
        public string HistogramBins { get; set; }
        /// <summary> Histogram range. </summary>
        public string HistogramRange { get; set; }
        /// <summary> Subdataset name. </summary>
        public string SubdatasetName { get; set; }
        /// <summary> Subdataset band indexes. </summary>
        public IEnumerable<int> SubdatasetBands { get; set; }
        /// <summary> Coordinate Reference System for subdataset. </summary>
        public string Crs { get; set; }
        /// <summary> Datetime for subsetting the asset. </summary>
        public string Datetime { get; set; }
        /// <summary> Xarray indexing. </summary>
        public IEnumerable<string> Sel { get; set; }
        /// <summary> Xarray indexing method. </summary>
        public SelMethod? SelMethod { get; set; }
        /// <summary> Per asset expression. </summary>
        public IEnumerable<string> AssetExpression { get; set; }
        /// <summary> Force image height for statistics. </summary>
        public int? Height { get; set; }
        /// <summary> Force image width for statistics. </summary>
        public int? Width { get; set; }
    }
}
