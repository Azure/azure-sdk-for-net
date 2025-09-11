// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid.Namespaces
{
    public partial class RejectResult
    {
        /// <param name="rejectResult"> The <see cref="RejectResult"/> to serialize into <see cref="RequestContent"/>. </param>
        public static implicit operator RequestContent(RejectResult rejectResult)
        {
            if (rejectResult == null)
            {
                return null;
            }
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(rejectResult, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
