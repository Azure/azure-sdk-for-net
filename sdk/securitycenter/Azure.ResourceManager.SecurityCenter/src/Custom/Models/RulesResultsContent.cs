// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // TypeSpec uses latestScan -> IsLatestScan for C# boolean naming, while the GA SDK exposed LatestScan on this request model.
    public partial class RulesResultsContent
    {
        /// <summary> Gets or sets the LatestScan value preserved from the previous public API surface. </summary>
        public bool? LatestScan
        {
            get => IsLatestScan;
            set => IsLatestScan = value;
        }
    }
}
