// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class DefaultRetryPolicy : RetryPolicy
    {
        public DefaultRetryPolicy(RetryOptions options) : base(options)
        {
        }
    }
}