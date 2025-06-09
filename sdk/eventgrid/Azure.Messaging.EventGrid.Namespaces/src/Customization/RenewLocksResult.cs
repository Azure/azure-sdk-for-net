// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventGrid.Namespaces
{
    public partial class RenewLocksResult
    {
        /// <param name="renewLocksResult"> The <see cref="RenewLocksResult"/> to serialize into <see cref="RequestContent"/>. </param>
        public static implicit operator RequestContent(RenewLocksResult renewLocksResult)
        {
            if (renewLocksResult == null)
            {
                return null;
            }
            Utf8JsonBinaryContent content = new Utf8JsonBinaryContent();
            content.JsonWriter.WriteObjectValue(renewLocksResult, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
