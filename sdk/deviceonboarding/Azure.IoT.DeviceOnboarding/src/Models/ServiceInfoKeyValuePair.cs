// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    ///  Service Info Key Value Pair
    /// </summary>
    public class ServiceInfoKeyValuePair
    {
        /// <summary>
        ///  Service Info Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///  Service Info Value
        /// </summary>
        public byte[] Value { get; set; }

        /// <summary>
        /// Override Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj is ServiceInfoKeyValuePair serviceInfoKeyValuePair)
            {
                return string.Equals(this.Key, serviceInfoKeyValuePair.Key) &&
                StructuralComparisons.StructuralEqualityComparer.Equals(this.Value, serviceInfoKeyValuePair.Value);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Key,
                StructuralComparisons.StructuralEqualityComparer.GetHashCode(Value));
        }
    }
}
