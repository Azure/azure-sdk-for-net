// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Models
{
    /// <summary> Model factory for read-only models. </summary>
    public static partial class ResourceManagerModelFactory
    {
        /// <summary> Initializes a new instance of SubResource. </summary>
        /// <param name="id"></param>
        /// <returns> A new <see cref="Resources.Models.SubResource"/> instance for mocking. </returns>
        public static SubResource SubResource(ResourceIdentifier id = null)
        {
            return new SubResource(id);
        }

        /// <summary> Initializes a new instance of WritableSubResource. </summary>
        /// <param name="id"></param>
        /// <returns> A new <see cref="Resources.Models.WritableSubResource"/> instance for mocking. </returns>
        public static WritableSubResource WritableSubResource(ResourceIdentifier id = null)
        {
            return new WritableSubResource(id);
        }
    }
}
