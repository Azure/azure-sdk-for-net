// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// MPG migration back-compat: the generator emits an internal parameterless ctor and get-only
// ColumnName/ColumnType because @@usage(DatasetDataElement, Usage.input, "csharp") does not propagate
// transitively through the Dfe<T> union wrapping DatasetDataElement[] in the request body, so the
// model is treated as output-only. Restore the public surface so callers can construct + mutate.

#nullable disable

using Azure.Core.Expressions.DataFactory;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataFactory.Models
{
    [CodeGenSuppress("DatasetDataElement")]
    public partial class DatasetDataElement
    {
        /// <summary> Initializes a new instance of <see cref="DatasetDataElement"/>. </summary>
        public DatasetDataElement()
        {
        }

        /// <summary> Name of the column. Type: string (or Expression with resultType string). </summary>
        [CodeGenMember("ColumnName")]
        public DataFactoryElement<string> ColumnName { get; set; }

        /// <summary> Type of the column. Type: string (or Expression with resultType string). </summary>
        [CodeGenMember("ColumnType")]
        public DataFactoryElement<string> ColumnType { get; set; }
    }
}
