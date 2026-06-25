// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    // Restores the protected parameterless constructor that the MPG generator drops on abstract base
    // classes, required so generated subclasses can chain via : base(). Generator bug:
    // https://github.com/Azure/azure-sdk-for-net/issues/59298
    // TODO: remove once the generator emits the base-class protected constructor.
    public abstract partial class SsisObjectMetadata
    {
        /// <summary> Initializes a new instance of <see cref="SsisObjectMetadata"/>. </summary>
        protected SsisObjectMetadata()
        { }
    }
}
