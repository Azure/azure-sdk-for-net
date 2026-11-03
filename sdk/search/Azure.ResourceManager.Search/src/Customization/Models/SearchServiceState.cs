// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Search.Models
{
    [CodeGenType("SearchServiceStatus")]
    public readonly partial struct SearchServiceState
    {
        /// <summary> Converts a legacy status to an extensible service status. </summary>
        /// <param name="value"> The legacy status. </param>
        public static implicit operator SearchServiceState(SearchServiceStatus value) => new SearchServiceState(value.ToSerialString());

        /// <summary> Converts a string to a nullable service status, preserving null. </summary>
        /// <param name="value"> The status value. </param>
        public static implicit operator SearchServiceState?(string value) => value is null ? (SearchServiceState?)null : new SearchServiceState(value);
    }
}
