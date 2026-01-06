// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace Azure.Compute.Batch
{
    public partial class BatchError
    {
        /// <param name="result"> The <see cref="Response"/> to deserialize the <see cref="BatchError"/> from. </param>
        public static explicit operator BatchError(Response result)
        {
            using Response response = result;
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeBatchError(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
