// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Communication.Messages
{
    // workaround for issue that:
    // 1. `MessageDataStream` is explicitly marked as `internal`: https://github.com/Azure/azure-rest-api-specs/blob/e6a20fec72ed3bcb4b43c559ee20b56ca2786ec0/specification/communication/Communication.Messages/client.tsp#L31-L33
    // 2. It's actually not directly used as model. Only `body` property has real data: https://github.com/Azure/azure-rest-api-specs/blob/e6a20fec72ed3bcb4b43c559ee20b56ca2786ec0/specification/communication/Communication.Messages/models.tsp#L327-L343
    // 3. And `body` is returned directly: https://github.com/Azure/azure-rest-api-specs/blob/e6a20fec72ed3bcb4b43c559ee20b56ca2786ec0/specification/communication/Communication.Messages/routes.tsp#L46
    // So TCGC will not assign a `serializedName` to `body`, but we'll still generate the whole model due to #1
    // Here we need a workaround to assign a `serializedName` to `body` so that the generated code can be compiled
    [CodeGenSerialization(nameof(Body), "body")]
    internal partial class MessageDataStream
    {
    }
}
