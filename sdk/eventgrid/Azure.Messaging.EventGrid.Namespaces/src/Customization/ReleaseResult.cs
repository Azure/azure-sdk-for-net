// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventGrid.Namespaces
{
    public partial class ReleaseResult
    {
        /// <param name="releaseResult"> The <see cref="ReleaseResult"/> to serialize into <see cref="RequestContent"/>. </param>
        public static implicit operator RequestContent(ReleaseResult releaseResult)
        {
            if (releaseResult == null)
            {
                return null;
            }
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(releaseResult, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
