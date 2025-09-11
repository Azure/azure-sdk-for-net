// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid.Namespaces
{
    public partial class FailedLockToken
    {
        /// <param name="failedLockToken"> The <see cref="FailedLockToken"/> to serialize into <see cref="RequestContent"/>. </param>
        public static implicit operator RequestContent(FailedLockToken failedLockToken)
        {
            if (failedLockToken == null)
            {
                return null;
            }
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(failedLockToken, ModelSerializationExtensions.WireOptions);
            return content;
        }

        /// <param name="result"> The <see cref="Response"/> to deserialize the <see cref="FailedLockToken"/> from. </param>
        public static explicit operator FailedLockToken(Response result)
        {
            using Response response = result;
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeFailedLockToken(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
