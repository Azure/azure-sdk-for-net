// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventGrid.Namespaces
{
    public partial class ReceiveResult
    {
        /// <param name="receiveResult"> The <see cref="ReceiveResult"/> to serialize into <see cref="RequestContent"/>. </param>
        public static implicit operator RequestContent(ReceiveResult receiveResult)
        {
            if (receiveResult == null)
            {
                return null;
            }
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(receiveResult, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
