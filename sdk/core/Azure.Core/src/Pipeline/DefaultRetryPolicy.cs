// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Pipeline
{
    internal class DefaultRetryPolicy : RetryPolicy
    {
        public DefaultRetryPolicy(RetryOptions options) : base(options)
        {
        }
    }
}