// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Compute.Batch.Models
{
    public partial class ImageReference
    {
        public ImageReference(string offer, string publisher, string sku) : this()
        {
            Offer = offer;
            Publisher = publisher;
            Sku = sku;
        }
    }
}
