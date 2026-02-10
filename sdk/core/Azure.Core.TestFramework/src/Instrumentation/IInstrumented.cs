// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.TestFramework
{
    /// <summary>
    /// An interface implemented by instrumented clients and LROs that allows to retrieve the original value
    /// </summary>
    internal interface IInstrumented
    {
        public object Original { get; }
    }
}