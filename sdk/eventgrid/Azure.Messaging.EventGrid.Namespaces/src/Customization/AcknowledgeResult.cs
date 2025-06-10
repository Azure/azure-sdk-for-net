// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventGrid.Namespaces
{
    public partial class AcknowledgeResult
    {
        /// <param name="acknowledgeResult"> The <see cref="AcknowledgeResult"/> to serialize into <see cref="RequestContent"/>. </param>
        public static implicit operator RequestContent(AcknowledgeResult acknowledgeResult)
        {
            if (acknowledgeResult == null)
            {
                return null;
            }
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(acknowledgeResult, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
