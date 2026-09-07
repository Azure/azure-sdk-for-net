// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.Resources.Models
{
    public static partial class ArmResourcesModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="DecompileOperationSuccessResult"/>. </summary>
        /// <param name="files"> The decompiled files. </param>
        /// <param name="entryPoint"> The path to the main Bicep file. </param>
        /// <returns> A new model instance for mocking. </returns>
        [Obsolete("Use Azure.ResourceManager.Resources.Bicep.Models.ArmResourcesBicepModelFactory.DecompileOperationSuccessResult instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DecompileOperationSuccessResult DecompileOperationSuccessResult(IEnumerable<DecompiledFileDefinition> files = null, string entryPoint = null)
        {
            files ??= new List<DecompiledFileDefinition>();

            return new DecompileOperationSuccessResult(files.ToList(), entryPoint, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DecompiledFileDefinition"/>. </summary>
        /// <param name="path"> The file path. </param>
        /// <param name="contents"> The file contents. </param>
        /// <returns> A new model instance for mocking. </returns>
        [Obsolete("Use Azure.ResourceManager.Resources.Bicep.Models.ArmResourcesBicepModelFactory.DecompiledFileDefinition instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DecompiledFileDefinition DecompiledFileDefinition(string path = null, string contents = null)
        {
            return new DecompiledFileDefinition(path, contents, serializedAdditionalRawData: null);
        }
    }
}
