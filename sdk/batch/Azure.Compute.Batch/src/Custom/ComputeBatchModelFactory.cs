// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Compute.Batch
{
    [CodeGenType("BatchModelFactory")]
    public partial class ComputeBatchModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Azure.Compute.Batch.BatchFileProperties"/> for mocking. </summary>
        /// <param name="isDirectory"> Whether the object represents a directory. </param>
        /// <param name="mode"> The file mode attribute in octal format. </param>
        /// <param name="fileUri"> The URL of the file. </param>
        /// <param name="creationTime"> The file creation time. </param>
        /// <returns> A new <see cref="Azure.Compute.Batch.BatchFileProperties"/> instance for mocking. </returns>
        public static BatchFileProperties BatchFileProperties(bool isDirectory = default, string mode = default, Uri fileUri = default, DateTime creationTime = default)
            => new BatchFileProperties(isDirectory, mode, fileUri, creationTime);
    }
}
