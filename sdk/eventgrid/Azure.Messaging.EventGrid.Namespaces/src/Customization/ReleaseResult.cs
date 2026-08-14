// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Messaging.EventGrid.Namespaces
{
    [CodeGenSuppress("op_Explicit", typeof(Response))]
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

        // TODO: Remove this workaround once https://github.com/microsoft/typespec/issues/11669 is addressed.
        /// <param name="result"> The <see cref="Response"/> to deserialize the <see cref="ReleaseResult"/> from. </param>
        public static explicit operator ReleaseResult(Response result)
        {
            using JsonDocument document = JsonDocument.Parse(result.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeReleaseResult(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
