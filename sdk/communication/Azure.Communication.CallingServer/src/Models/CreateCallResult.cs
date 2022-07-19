// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer
{
    /// <summary> The result from creating a call. </summary>
    public class CreateCallResult
    {
        internal CreateCallResult(CallConnection callConnection, CallConnectionProperties callProperties)
        {
            CallConnection = callConnection;
            CallProperties = callProperties;
        }

        /// <summary> CallConnection instance. </summary>
        public CallConnection CallConnection { get; }

        /// <summary> Properties of the call. </summary>
        public CallConnectionProperties CallProperties { get; }
    }
}
