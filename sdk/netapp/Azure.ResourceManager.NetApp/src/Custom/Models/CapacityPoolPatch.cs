// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class CapacityPoolPatch
    {
        /// <summary> Initializes a new instance of <see cref="CapacityPoolPatch"/>. </summary>
        /// <param name="location"> The location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CapacityPoolPatch(AzureLocation location) { Location = location.ToString(); }

        public float? CustomThroughputMibps
        {
            get => CustomThroughputMibpsInt;
            set => CustomThroughputMibpsInt = value.HasValue ? (int?)value.Value : null;
        }
    }
}
