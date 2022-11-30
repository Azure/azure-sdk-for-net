// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer
{
    /// <summary> The result from creating a call. </summary>
    public class AnswerCallResult
    {
        internal AnswerCallResult(CallConnection callConnection, CallConnectionProperties callConnectionProperties)
        {
            CallConnection = callConnection;
            CallConnectionProperties = callConnectionProperties;
        }

        /// <summary> CallConnection instance. </summary>
        public CallConnection CallConnection { get; }

        /// <summary> Properties of the call. </summary>
        public CallConnectionProperties CallConnectionProperties { get; }
    }
}
