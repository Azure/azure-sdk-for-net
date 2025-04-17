// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Rendezvous Directive
    /// </summary>
    public class RendezvousDirective : List<RendezvousInstruction>
    {
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
            if (obj is RendezvousDirective rendezvousDirective)
            {
                return this.SequenceEqual(rendezvousDirective);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Aggregate(0, (hash, item) => HashCode.Combine(hash, item?.GetHashCode() ?? 0));
        }
    }
}
