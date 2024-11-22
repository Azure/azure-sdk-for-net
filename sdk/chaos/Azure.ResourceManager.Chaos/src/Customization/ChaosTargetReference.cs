// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Chaos.Models
{
    public partial class ChaosTargetReference
    {
        /// <summary> Initializes a new instance of <see cref="ChaosTargetReference"/>. </summary>
        /// <param name="referenceType"> Enum of the Target reference type. </param>
        /// <param name="id"> String of the resource ID of a Target resource. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public ChaosTargetReference(ChaosTargetReferenceType referenceType, ResourceIdentifier id)
        {
            Argument.AssertNotNull(id, nameof(id));

            ReferenceType = referenceType;
            Id = id;
        }
    }
}
