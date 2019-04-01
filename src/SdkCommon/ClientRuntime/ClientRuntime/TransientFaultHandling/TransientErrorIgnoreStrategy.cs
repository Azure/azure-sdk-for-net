// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Rest.TransientFaultHandling
{
    /// <summary>
    /// Retry strategy that ignores any transient errors.
    /// </summary>
    public class TransientErrorIgnoreStrategy : ITransientErrorDetectionStrategy
    {
        /// <summary>
        /// Always returns false.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <returns>Always false.</returns>
        public bool IsTransient(Exception ex)
        {
            return false;
        }
    }
}
