// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Messaging.EventGrid.Namespaces
{
    [CodeGenSuppress("op_Explicit", typeof(Response))]
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

        // TODO: Remove this workaround once https://github.com/microsoft/typespec/issues/11669 is addressed.
        /// <param name="result"> The <see cref="Response"/> to deserialize the <see cref="ReceiveResult"/> from. </param>
        public static explicit operator ReceiveResult(Response result)
        {
            using JsonDocument document = JsonDocument.Parse(result.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeReceiveResult(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
