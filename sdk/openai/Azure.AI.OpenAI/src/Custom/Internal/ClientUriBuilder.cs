// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI;

internal partial class ClientUriBuilder
{
    public Uri ToUri()
    {
        if (_pathBuilder is not null)
        {
            UriBuilder.Path = _pathBuilder.ToString();
        }

        // CUSTOMIZATION: UriBuilder.Query.set always prepends its own '?' pre-net5.0, which results in a double '??'.
        //                To mitigate pending generated ClientUriBuilder updates, ensure we only get one '?' by letting
        //                the builder add it.
        //           see: https://github.com/Azure/autorest.csharp/issues/4815
        if (_queryBuilder is not null)
        {
            UriBuilder.Query = _queryBuilder.ToString().TrimStart('?');
        }

        return UriBuilder.Uri;
    }
}
