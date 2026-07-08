// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Analytics.PlanetaryComputer
{
/// <summary> Options for item info operations. </summary>
    public class GetItemInfoOptions
    {
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
        /// <summary> Asset names. </summary>
        public IEnumerable<string> Assets { get; set; }
    }
}
