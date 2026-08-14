// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Messaging.EventGrid.Namespaces
{
    [CodeGenSuppress("op_Explicit", typeof(Response))]
    public partial class RenewLocksResult
    {
        /// <param name="renewLocksResult"> The <see cref="RenewLocksResult"/> to serialize into <see cref="RequestContent"/>. </param>
        public static implicit operator RequestContent(RenewLocksResult renewLocksResult)
        {
            if (renewLocksResult == null)
            {
                return null;
            }
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(renewLocksResult, ModelSerializationExtensions.WireOptions);
            return content;
        }

        // TODO: Remove this workaround once https://github.com/microsoft/typespec/issues/11669 is addressed.
        /// <param name="result"> The <see cref="Response"/> to deserialize the <see cref="RenewLocksResult"/> from. </param>
        public static explicit operator RenewLocksResult(Response result)
        {
            using Response response = result;
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeRenewLocksResult(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
