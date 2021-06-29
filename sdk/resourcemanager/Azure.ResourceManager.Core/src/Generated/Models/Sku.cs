// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing SKU for resource.
    /// </summary>
    public sealed partial class Sku : IEquatable<Sku>, IComparable<Sku>
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
                (compareResult = string.Compare(Model, other.Model, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
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
                string.Equals(Model, other.Model, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Size, other.Size, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Tier, other.Tier, StringComparison.InvariantCultureIgnoreCase) &&
                long.Equals(Capacity, other.Capacity);
        }
    }
}
