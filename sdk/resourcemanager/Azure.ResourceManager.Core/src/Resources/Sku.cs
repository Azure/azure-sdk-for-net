// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Representaion of ARM SKU
    /// </summary>
    public sealed class Sku : IEquatable<Sku>, IComparable<Sku>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sku"/> class.
        /// </summary>
        /// <param name="name"> SKU's name. </param>
        /// <param name="tier"> SKU's tier. </param>
        /// <param name="family"> SKU's family. </param>
        /// <param name="size"> SKU's size. </param>
        /// <param name="capacity"> SKU's capacity. </param>
        internal Sku(string name, string tier, string family, string size, long? capacity = null)
        {
            Name = name;
            Tier = tier;
            Family = family;
            Size = size;
            Capacity = capacity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sku"/> class.
        /// </summary>
        /// <param name="sku"> The sku to copy from. </param>
        internal Sku(ResourceManager.Resources.Models.Sku sku)
            : this(sku.Name, sku.Tier, sku.Family, sku.Size, sku.Capacity)
        {
        }

        /// <summary>
        /// Gets the Name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the Tier.
        /// </summary>
        public string Tier { get; private set; }

        /// <summary>
        /// Gets the Family.
        /// </summary>
        public string Family { get; private set; }

        /// <summary>
        /// Gets the Size.
        /// </summary>
        public string Size { get; private set; }

        /// <summary>
        /// Gets the Capacity.
        /// </summary>
        public long? Capacity { get; private set; }

        /// <summary>
        /// Compares this <see cref="Sku"/> with another instance.
        /// </summary>
        /// <param name="other"> <see cref="Sku"/> object to compare. </param>
        /// <returns> -1 for less than, 0 for equals, 1 for greater than. </returns>
        public int CompareTo(Sku other)
        {
            if (other == null)
                return 1;

            if (object.ReferenceEquals(this, other))
                return 0;

            int compareResult = 0;
            if ((compareResult = string.Compare(Name, other.Name, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Family, other.Family, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Size, other.Size, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Tier, other.Tier, StringComparison.InvariantCultureIgnoreCase)) == 0)
            {
                return Nullable.Compare<long>(Capacity, other.Capacity);
            }

            return compareResult;
        }

        /// <summary>
        /// Compares this <see cref="Sku"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="other"> <see cref="Sku"/> object to compare. </param>
        /// <returns> True if they are equals, otherwise false. </returns>
        public bool Equals(Sku other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Family, other.Family, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Size, other.Size, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Tier, other.Tier, StringComparison.InvariantCultureIgnoreCase) &&
                long.Equals(Capacity, other.Capacity);
        }
    }
}
