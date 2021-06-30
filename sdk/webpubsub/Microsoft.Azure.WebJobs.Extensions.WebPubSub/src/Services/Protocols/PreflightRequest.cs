// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Azure.Messaging.WebPubSub
{
    public class PreflightRequest : ServiceRequest
    {
        public override string Name => nameof(PreflightRequest);

        public PreflightRequest(bool valid)
            :base(true, valid)
        {
        }
    }
}
