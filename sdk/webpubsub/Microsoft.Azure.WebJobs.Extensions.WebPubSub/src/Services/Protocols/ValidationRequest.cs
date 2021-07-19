// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Azure.Messaging.WebPubSub
{
    public sealed class ValidationRequest : ServiceRequest
    {
        public override string Name => nameof(ValidationRequest);

        public ValidationRequest(bool valid)
            :base(true, valid)
        {
        }
    }
}
