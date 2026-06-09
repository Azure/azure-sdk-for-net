// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.EventGrid.Models
{
    public partial class EventSubscriptionFilter
    {
        /// <summary> Allows advanced filters to be evaluated against an array of values instead of expecting a singular value. </summary>
        [WirePath("enableAdvancedFilteringOnArrays")]
        public bool? IsAdvancedFilteringOnArraysEnabled
        {
            get => EnableAdvancedFilteringOnArrays;
            set => EnableAdvancedFilteringOnArrays = value;
        }
    }
}
