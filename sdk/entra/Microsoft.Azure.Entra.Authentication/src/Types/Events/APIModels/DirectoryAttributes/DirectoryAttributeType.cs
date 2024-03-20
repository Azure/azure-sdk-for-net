// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// The type of directory attribute.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DirectoryAttributeType
    {
        /// <summary>
        /// Built in directory attribute.
        /// </summary>
        [EnumMember(Value = "builtIn")]
        BuiltIn,

        /// <summary>
        /// Custom directory attribute.
        /// </summary>
        [EnumMember(Value = "directorySchemaExtension")]
        DirectorySchemaExtension
    }
}
