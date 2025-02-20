// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Purview.Models
{
    /// <summary> Model factory for models. </summary>
    [CodeGenSuppress("PurviewAccountEndpoint", typeof(string), typeof(string))]
    public static partial class ArmPurviewModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.PurviewAccountEndpoint"/>. </summary>
        /// <param name="catalog"> Gets the catalog endpoint. </param>
        /// <param name="guardian"> Gets the guardian endpoint. </param>
        /// <param name="scan"> Gets the scan endpoint. </param>
        /// <returns> A new <see cref="Models.PurviewAccountEndpoint"/> instance for mocking. </returns>
        public static PurviewAccountEndpoint PurviewAccountEndpoint(string catalog = null, string guardian = null, string scan = null)
        {
            return new PurviewAccountEndpoint(catalog, scan, serializedAdditionalRawData: null);
        }
    }
}
