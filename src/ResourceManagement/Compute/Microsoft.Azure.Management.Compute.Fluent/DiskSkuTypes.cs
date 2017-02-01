// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    /// <summary>
    /// Defines values for DiskSkuTypes.
    /// </summary>
    public class DiskSkuTypes
    {
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
            this.value = value;
            
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
