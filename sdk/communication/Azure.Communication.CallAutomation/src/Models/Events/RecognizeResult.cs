// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Recognize result which could be tone result.
    /// </summary>
    public abstract class RecognizeResult
    {
        /// <summary> The type of recognize result. </summary>
        public abstract RecognizeResultType ResultType { get; }
    }
}
