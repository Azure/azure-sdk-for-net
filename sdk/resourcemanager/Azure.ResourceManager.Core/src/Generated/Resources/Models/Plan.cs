// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// Representation of a publisher plan for marketplace RPs.
    /// </summary>
    public sealed partial class Plan
    {
        /// <summary> Initializes a new instance of Plan. </summary>
        public Plan()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Plan"/> class.
        /// </summary>
        /// <param name="name"> Plan's Name. </param>
        /// <param name="publisher"> Plan's Publisher.</param>
        /// <param name="product"> Plan's Product. </param>
        /// <param name="promotionCode"> Plan's Promotion Code. </param>
        /// <param name="version"> Plan's Version. </param>
        internal Plan(string name, string publisher, string product, string promotionCode, string version)
        {
            Name = name;
            Publisher = publisher;
            Product = product;
            PromotionCode = promotionCode;
            Version = version;
        }

        /// <summary>
        /// Gets or sets the plan's Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the plan's Publisher.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the plan's product.
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Gets or sets the plan's Promotion Code.
        /// </summary>
        public string PromotionCode { get; set; }

        /// <summary>
        /// Gets or sets the plan's version.
        /// </summary>
        public string Version { get; set; }
    }
}
