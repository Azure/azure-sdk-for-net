// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Response received after successful job cancellation.
    /// </summary>
    public class CancelJobResult: EmptyPlaceholderObject
    {
        /// <inheritdoc />
        public CancelJobResult(object value) : base(value)
        {
        }
    }
}
