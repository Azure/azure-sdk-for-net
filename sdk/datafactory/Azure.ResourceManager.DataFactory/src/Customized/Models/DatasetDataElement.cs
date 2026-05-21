// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// MPG migration back-compat: generator emits an internal-only ctor for DatasetDataElement
// (the @@usage decorator does not transitively reach models wrapped by Dfe<T>). Restore the public
// parameterless ctor to match the pre-MPG API surface so callers can construct instances.

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    public partial class DatasetDataElement
    {
        /// <summary> Initializes a new instance of <see cref="DatasetDataElement"/>. </summary>
        public DatasetDataElement()
        {
        }
    }
}
