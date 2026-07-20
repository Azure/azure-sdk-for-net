// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Extensions.OpenAI
{
    /// <summary>The memory limit for code interpreter container.</summary>
    [CodeGenType("ContainerMemoryLimit")]
    public enum ResponsesContainerMemoryLimit
    {
        /// <summary> _1g. </summary>
        _1g,
        /// <summary> _4g. </summary>
        _4g,
        /// <summary> _16g. </summary>
        _16g,
        /// <summary> _64g. </summary>
        _64g
    }
}
