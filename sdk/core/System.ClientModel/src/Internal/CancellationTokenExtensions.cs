// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;

namespace System.ClientModel.Internal;

internal static class CancellationTokenExtensions
{
    public static RequestOptions? ToRequestOptions(this CancellationToken cancellationToken)
    {
        if (cancellationToken == default)
        {
            return null;
        }

        return new RequestOptions()
        {
            CancellationToken = cancellationToken
        };
    }
}
