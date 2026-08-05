// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ScVmm
{
    // The GA (AutoRest) SDK exposed a constructor that also required the vmmServer fqdn.
    // The TypeSpec model marks fqdn as optional, so re-add the overload for back-compat.
    public partial class ScVmmServerData
    {
        /// <summary> Initializes a new instance of <see cref="ScVmmServerData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="extendedLocation"> The extended location. </param>
        /// <param name="fqdn"> Fqdn is the hostname/ip of the vmmServer. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/> or <paramref name="fqdn"/> is null. </exception>
        public ScVmmServerData(AzureLocation location, ExtendedLocation extendedLocation, string fqdn) : this(location, extendedLocation)
        {
            Argument.AssertNotNull(fqdn, nameof(fqdn));

            Fqdn = fqdn;
        }
    }
}
