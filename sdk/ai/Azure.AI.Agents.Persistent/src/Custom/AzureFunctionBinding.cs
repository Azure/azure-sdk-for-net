// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Agents.Persistent
{
    [CodeGenSuppress("Type")]
    public partial class AzureFunctionBinding
    {
        /// <summary> Storage queue. </summary>
        public AzureFunctionStorageQueue StorageQueue { get; }

        /// <summary> The type of binding, which is always 'storage_queue'. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureFunctionBindingType Type { get; } = new AzureFunctionBindingType("storage_queue");
    }
}
