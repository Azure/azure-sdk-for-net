// -----------------------------------------------------------------------------------------
// <copyright file="OperationContext.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage
{
    using System;

    /// <summary>
    /// Enables intercepting all storage requests based on event handlers.
    /// </summary>
    public static class RequestInterceptor
    {
        /// <summary>
        /// Occurs immediately before a request is signed.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "Cannot expose EventArgs due to Javascript projection")]
        public static event EventHandler<RequestEventArgs> SendingRequest;

        /// <summary>
        /// Occurs when a response is received from the server.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "Cannot expose EventArgs due to Javascript projection")]
        public static event EventHandler<RequestEventArgs> ResponseReceived;

        internal static void FireSendingRequest(object sender, RequestEventArgs args)
        {
            if (SendingRequest != null)
            {
                SendingRequest(sender, args);
            }
        }

        internal static void FireResponseReceived(object sender, RequestEventArgs args)
        {
            if (ResponseReceived != null)
            {
                ResponseReceived(sender, args);
            }
        }
    }
}
