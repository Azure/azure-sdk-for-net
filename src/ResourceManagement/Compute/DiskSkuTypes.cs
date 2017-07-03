// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    /// <summary>
    /// Defines values for DiskSkuTypes.
    /// </summary>
    public class DiskSkuTypes
    {
        private static IDictionary<string, DiskSkuTypes> ValuesByName;

        /// <summary>
        /// Known disk SKU types.
        /// </summary>
        /// <returns></returns>

        public static IEnumerable<DiskSkuTypes> Values
        {
            get
            {
                return (ValuesByName != null) ? ValuesByName.Values : null;
            }
        }

        /// <summary>
        /// Static value StandardLRS for DiskSkuTypes.
        /// </summary>
        public static readonly DiskSkuTypes StandardLRS = new DiskSkuTypes(StorageAccountTypes.StandardLRS);
        /// <summary>
        /// Static value PremiumLRS for DiskSkuTypes.
        /// </summary>
        public static readonly DiskSkuTypes PremiumLRS = new DiskSkuTypes(StorageAccountTypes.PremiumLRS);

        private StorageAccountTypes value;

        /// <summary>
        /// Creates a custom value for DiskSkuTypes.
        /// </summary>
        /// <param name="value">the custom value</param>
        public DiskSkuTypes(StorageAccountTypes value)
        {
            if (ValuesByName == null)
            {
                ValuesByName = new Dictionary<string, DiskSkuTypes>();
            }

            ValuesByName[value.ToString().ToLower()] = this;
            this.value = value;
        }

        /// <summary>
        /// Parses a disk SKU type from a storage account type.
        /// </summary>
        /// <param name="value">a storage account type</param>
        /// <returns>a disk SKU type</returns>
        public static DiskSkuTypes FromStorageAccountType(StorageAccountTypes value)
        {
            DiskSkuTypes result;
            if (ValuesByName == null)
            {
                return new DiskSkuTypes(value);
            }
            else if(ValuesByName.TryGetValue(value.ToString().ToLower(), out result))
            {
                return result;
            }
            else
            {
                return new DiskSkuTypes(value);
            }
        }

        public StorageAccountTypes AccountType
        {
            get
            {
                return this.value;
            }
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(DiskSkuTypes lhs, DiskSkuTypes rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(DiskSkuTypes lhs, DiskSkuTypes rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            string value = this.ToString();
            if (!(obj is DiskSkuTypes))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            DiskSkuTypes rhs = (DiskSkuTypes)obj;
            if (value == null)
            {
                return rhs.value == null;
            }
            return value.Equals(rhs.value.ToString());
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
