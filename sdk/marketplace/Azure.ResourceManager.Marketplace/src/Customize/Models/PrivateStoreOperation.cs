// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Marketplace.Models
{
    /// <summary>
    /// Provides the serialization helper the MPG code generator calls as
    /// <c>PrivateStoreOperation.ToRequestContent(payload)</c>. The generator has a
    /// codegen gap for extensible-enum/union body parameters: it emits <c>T.ToRequestContent(value)</c>
    /// for any non-primitive body, but only emits the actual method on MRW model types.
    /// Supplying this partial bridges the gap without changing the public API shape.
    /// </summary>
    public readonly partial struct PrivateStoreOperation
    {
        internal static RequestContent ToRequestContent(PrivateStoreOperation? payload)
        {
            if (payload == null)
            {
                return null;
            }

            return RequestContent.Create(payload.Value.ToString());
        }
    }
}
