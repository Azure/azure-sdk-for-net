// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.Core
{
    internal static class ResponseWithHeaders
    {
        public static ResponseWithHeaders<T, THeaders> FromValue<T, THeaders>(T value, THeaders headers, Response rawResponse)
        {
            return new ResponseWithHeaders<T, THeaders>(value, headers, rawResponse);
        }

        public static ResponseWithHeaders<THeaders> FromValue<THeaders>(THeaders headers, Response rawResponse)
        {
            return new ResponseWithHeaders<THeaders>(headers, rawResponse);
        }
    }
}
