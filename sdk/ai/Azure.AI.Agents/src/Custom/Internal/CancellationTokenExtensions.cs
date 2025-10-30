// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Threading;

namespace Azure.AI.Agents;

/// <summary> The AgentsClient. </summary>
internal static partial class CancellationTokenExtensions
{
    public static RequestOptions ToRequestOptions(this CancellationToken cancellationToken)
    {
        return cancellationToken.CanBeCanceled
            ? new RequestOptions()
            {
                CancellationToken = cancellationToken,
            }
            : null;
    }
}
