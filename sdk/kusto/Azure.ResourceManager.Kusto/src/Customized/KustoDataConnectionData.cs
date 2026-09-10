// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Kusto
{
    [CodeGenSuppress("KustoDataConnectionData")]
    public partial class KustoDataConnectionData
    {
        // KustoDataConnectionData is the base of a discriminated (kind) hierarchy. The generator emits a public
        // constructor that takes the required discriminator (DataConnectionKind), but the previous AutoRest SDK used
        // suppress-abstract-base-class and shipped a public parameterless constructor. Restore it for compatibility.

        /// <summary> Initializes a new instance of <see cref="KustoDataConnectionData"/>. </summary>
        public KustoDataConnectionData()
        {
        }
    }
}
