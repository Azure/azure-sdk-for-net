// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// MPG migration back-compat: the generator emits an internal parameterless ctor and a get-only `Name`
// because @@usage(OutputColumn, Usage.input, "csharp") does not propagate transitively through the
// Dfe<T> union that wraps OutputColumn[] in the request body, so the model is treated as output-only.
// Restore the public surface so callers can construct + mutate Office365TableOutputColumn instances.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataFactory.Models
{
    [CodeGenSuppress("Office365TableOutputColumn")]
    public partial class Office365TableOutputColumn
    {
        /// <summary> Initializes a new instance of <see cref="Office365TableOutputColumn"/>. </summary>
        public Office365TableOutputColumn()
        {
        }

        /// <summary> Name of the table column. Type: string. </summary>
        [CodeGenMember("Name")]
        public string Name { get; set; }
    }
}
