// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// A class representing SKU for resource.
    /// </summary>
    public sealed partial class Sku
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sku"/> class.
        /// </summary>
        public Sku()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sku"/> class.
        /// </summary>
        /// <param name="name"> The SKU name. </param>
        /// <param name="tier"> The SKU tier. </param>
        /// <param name="family"> The SKU family. </param>
        /// <param name="model"> The SKU faimily. </param>
        /// <param name="size"> The SKU size. </param>
        /// <param name="capacity"> The SKU capacity. </param>
        internal Sku(string name, string tier, string size, string family, string model, long? capacity = null)
        {
            Name = name;
            Tier = tier;
            Family = family;
            Size = size;
            Capacity = capacity;
            Model = model;
        }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the Tier.
        /// </summary>
        public string Tier { get; set; }

        /// <summary>
        /// Gets or sets the Family.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets the Size.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the Capacity.
        /// </summary>
        public long? Capacity { get; set; }
    }
}
