// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.IotOperations.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.IotOperations
{
    public partial class IotOperationsDataflowData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="IotOperationsDataflowData"/>. </summary>
        /// <param name="extendedLocation"> Edge location of the resource. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/> is null. </exception>
        public IotOperationsDataflowData(IotOperationsExtendedLocation extendedLocation) : base()
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            ExtendedLocation = extendedLocation;
        }
    }
}
