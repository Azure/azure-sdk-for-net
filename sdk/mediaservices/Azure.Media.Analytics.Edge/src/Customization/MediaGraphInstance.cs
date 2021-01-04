// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Media.Analytics.Edge.Models
{
    /// <summary>
    ///  MediaGraphInstance model.
    /// </summary>
    public partial class MediaGraphInstance
    {
        /// <summary>
        ///  Deserialize MediaGraphInstance.
        /// </summary>
        /// <param name="json">The json to be deserialized.</param>
        /// <returns>A MediaGraphInstance.</returns>
        public static MediaGraphInstance Deserialize(string json)
        {
            JsonElement element = JsonDocument.Parse(json).RootElement;
            return DeserializeMediaGraphInstance(element);
        }
    }
}
