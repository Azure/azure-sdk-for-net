// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Representation of a publisher plan for marketplace RPs.
    /// </summary>
    public sealed class Plan : IEquatable<Plan>, IComparable<Plan>
    {
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
        /// Initializes a new instance of the <see cref="Plan"/> class.
        /// </summary>
        /// <param name="plan"> The plan to copy from. </param>
        internal Plan(ResourceManager.Resources.Models.Plan plan)
            : this(plan.Name, plan.Publisher, plan.Product, plan.PromotionCode, plan.Version)
        {
        }

        /// <summary>
        /// Gets the plan's Name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the plan's Publisher.
        /// </summary>
        public string Publisher { get; private set; }

        /// <summary>
        /// Gets the plan's product.
        /// </summary>
        public string Product { get; private set; }

        /// <summary>
        /// Gets the plan's Promotion Code.
        /// </summary>
        public string PromotionCode { get; private set; }

        /// <summary>
        /// Gets the plan's version.
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// Compares this <see cref="Plan"/> with another instance.
        /// </summary>
        /// <param name="other"> <see cref="Plan"/> object to compare. </param>
        /// <returns> -1 for less than, 0 for equals, 1 for greater than. </returns>
        public int CompareTo(Plan other)
        {
            if (other == null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            int compareResult = 0;
            if ((compareResult = string.Compare(Name, other.Name, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Product, other.Product, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(PromotionCode, other.PromotionCode, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Publisher, other.Publisher, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Version, other.Version, StringComparison.InvariantCultureIgnoreCase)) == 0)
            {
                return 0;
            }

            return compareResult;
        }

        /// <summary>
        /// Compares this <see cref="Plan"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="other"> <see cref="Plan"/> object to compare. </param>
        /// <returns> True if they are equals, otherwise false. </returns>
        public bool Equals(Plan other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Product, other.Product, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(PromotionCode, other.PromotionCode, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Publisher, other.Publisher, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Version, other.Version, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
