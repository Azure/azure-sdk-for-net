// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// This object wraps around <see cref="BasicDigitalTwin"/> to deserialize the response of a query that is using aliasing.
    /// </summary>
    public class AliasedBasicDigitalTwin
    {
        /// <summary>
        /// When using aliasing, each digital twin will be wrapped around the alias name as an object.
        /// In this case, The query "SELECT D FROM DIGITALTWINS D" will name each object using the alias, so this wrapper object will help with deserialization.
        /// </summary>
        [JsonPropertyName("D")]
        public BasicDigitalTwin Twin { get; set; }
    }
}
