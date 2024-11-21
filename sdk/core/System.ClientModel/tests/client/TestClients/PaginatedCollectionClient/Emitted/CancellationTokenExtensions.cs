// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;

namespace ClientModel.Tests.Collections;

internal static class CancellationTokenExtensions
{
    public static RequestOptions ToRequestOptions(this CancellationToken cancellationToken)
    {
        return new RequestOptions()
        {
            CancellationToken = cancellationToken
        };
    }
}
