// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.AI.OpenAI;

internal partial class ClientUriBuilder
{
    public Uri ToUri()
    {
        if (_pathBuilder != null)
        {
            UriBuilder.Path = _pathBuilder.ToString();
        }
        // CUSTOMIZATION: UriBuilder.Query.set always prepends its own '?' pre-net5.0, which results in a double '??'.
        //                To mitigate pending generated ClientUriBuilder updates, check for this condition and fall back.
        //           see: https://github.com/Azure/autorest.csharp/issues/4815
        if (_queryBuilder != null)
        {
            string queryStringParameters = _queryBuilder.ToString();
            UriBuilder.Query = queryStringParameters;
            if (UriBuilder.Query.StartsWith("??"))
            {
                UriBuilder.Query = queryStringParameters.Substring(1);
            }
        }

        return UriBuilder.Uri;
    }
}