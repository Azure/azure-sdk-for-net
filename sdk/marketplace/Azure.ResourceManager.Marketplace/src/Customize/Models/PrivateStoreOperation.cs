// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Marketplace.Models
{
    public partial struct PrivateStoreOperation
    {
        // Fix generator bug: generated code calls PrivateStoreOperation.ToRequestContent(payload)
        // but extensible enum structs don't have this method
        internal static RequestContent ToRequestContent(PrivateStoreOperation? value)
        {
            if (value == null)
                return null;
            return RequestContent.Create(value.Value.ToString());
        }
    }
}
