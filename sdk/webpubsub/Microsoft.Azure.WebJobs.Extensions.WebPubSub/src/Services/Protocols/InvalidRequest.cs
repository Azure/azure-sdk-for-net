// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net;

namespace Azure.Messaging.WebPubSub
{
    public sealed class InvalidRequest : ServiceRequest
    {
        public override string Name => nameof(InvalidRequest);

        public InvalidRequest(HttpStatusCode statusCode, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
