// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;

namespace Payload.MultiPart
{
    internal static partial class CancellationTokenExtensions
    {
        public static RequestContext ToRequestContext(this CancellationToken cancellationToken) => cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
    }
}
