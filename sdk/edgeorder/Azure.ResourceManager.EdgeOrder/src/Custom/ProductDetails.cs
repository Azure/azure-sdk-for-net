// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    public partial class ProductDetails
    {
        /// <summary> Quantity of the product. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? Count { get; }
    }
}
