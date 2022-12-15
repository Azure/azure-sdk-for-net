// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// The default retry policy that will be used by the pipeline if no policy is specified in <see cref="ClientOptions.RetryPolicy"/>.
    /// All logic for the default retry policy is implemented in <see cref="RetryPolicy"/> and this class is only used to provide a concrete type
    /// that can be instantiated.
    /// </summary>
    internal class DefaultRetryPolicy : RetryPolicy
    {
        public DefaultRetryPolicy(RetryOptions options) : base(options)
        {
        }
    }
}