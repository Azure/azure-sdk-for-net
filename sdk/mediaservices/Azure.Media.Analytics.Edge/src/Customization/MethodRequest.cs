// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Media.Analytics.Edge.Models
{
    public partial class MethodRequest
    {
        /// <summary>
        /// Gets or Sets The Method name.
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// GetPayloadAsJSON function.
        /// </summary>
        /// <returns>A string representing the Json Payload.</returns>
        public virtual string GetPayloadAsJson()
        {
            return SerializeItemRequestInternal(this);
        }

        /// <summary>
        /// GetPayloadAsJSON function.
        /// </summary>
        /// <param name="serializable">The UTF8 serializer.</param>
        /// <returns>A string representing the Json Payload.</returns>
        internal static string SerializeItemRequestInternal(IUtf8JsonSerializable serializable)
        {
            using var memoryStream = new MemoryStream();

            using (var writer = new Utf8JsonWriter(memoryStream))
            {
                serializable.Write(writer);
            }

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }
    }
}
