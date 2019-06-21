// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Rest.TransientFaultHandling
{
    /// <summary>
    /// Defines an interface that must be implemented by custom components responsible for 
    /// detecting specific transient conditions.
    /// </summary>
    public interface ITransientErrorDetectionStrategy
    {
        /// <summary>
        /// Determines whether the specified exception represents a transient failure that 
        /// can be compensated by a retry.
        /// </summary>
        /// <param name="ex">The exception object to be verified.</param>
        /// <returns>true if the specified exception is considered as transient; otherwise, 
        /// false.</returns>
        bool IsTransient(Exception ex);
    }
}