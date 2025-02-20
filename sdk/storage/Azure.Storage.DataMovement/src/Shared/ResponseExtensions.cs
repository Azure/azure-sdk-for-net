// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    internal static class ResponseExtensions
    {
        public static bool TryExtractStorageEtag(this Response response, out ETag etag)
        {
            if (response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string rawEtag))
            {
                etag = new ETag(rawEtag);
                return true;
            }
            etag = default;
            return false;
        }
    }
}
