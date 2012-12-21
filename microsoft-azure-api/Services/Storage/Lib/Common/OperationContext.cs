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
    using System.Collections.Generic;

    /// <summary>
    /// Represents the context for a request to the storage service and provides additional runtime information about its execution.
    /// </summary>
    public sealed class OperationContext
    {
        #region State
        
        internal object OperationState { get; set; }
        
        #endregion

        #region Headers

        /// <summary>
        /// Gets or sets additional headers, for example proxy or logging information.
        /// </summary>
        /// <value>A <see cref="System.Collections.Generic.IDictionary{T, K}"/> object containing additional header information.</value>
        public IDictionary<string, string> UserHeaders { get; set; }

        /// <summary>
        /// Gets or sets the client request ID.
        /// </summary>
        /// <value>The client request ID.</value>
        public string ClientRequestID { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// Occurs immediately before a request is signed.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "Cannot expose EventArgs due to Javascript projection")]
        public event EventHandler<RequestEventArgs> SendingRequest;

        /// <summary>
        /// Occurs when a response is received from the server.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "Cannot expose EventArgs due to Javascript projection")]
        public event EventHandler<RequestEventArgs> ResponseReceived;

        internal void FireSendingRequest(RequestEventArgs args)
        {
            if (this.SendingRequest != null)
            {
                this.SendingRequest(this, args);
            }
        }

        internal void FireResponseReceived(RequestEventArgs args)
        {
            if (this.ResponseReceived != null)
            {
                this.ResponseReceived(this, args);
            }
        }
        #endregion

        #region Times
#if RT
        public System.DateTimeOffset StartTime { get; set; }

        public System.DateTimeOffset EndTime { get; set; }
        
        internal System.DateTimeOffset? OperationExpiryTime { get; set; }
#else
        /// <summary>
        /// Gets or sets the start time of the operation.
        /// </summary>
        /// <value>The start time of the operation.</value>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the operation.
        /// </summary>
        /// <value>The end time of the operation.</value>
        public DateTime EndTime { get; set; }

        internal DateTime? OperationExpiryTime { get; set; }
#endif
        #endregion

        #region Request Results

        private IList<RequestResult> requestResults = new List<RequestResult>();

        /// <summary>
        /// Gets or sets the set of request results that the current operation has created.
        /// </summary>
        /// <value>An <see cref="System.Collections.IList"/> object that contains <see cref="RequestResult"/> objects that represent the request results created by the current operation.</value>
        public IList<RequestResult> RequestResults
        {
            get { return this.requestResults; }
            set { this.requestResults = value; }
        }

        /// <summary>
        /// Gets the last request result encountered for the operation.
        /// </summary>
        /// <value>A <see cref="RequestResult"/> object that represents the last request result.</value>
        public RequestResult LastResult
        {
            get
            {
                if (this.requestResults == null || this.requestResults.Count == 0)
                {
                    return null;
                }
                else
                {
                    return this.requestResults[this.requestResults.Count - 1];
                }
            }
        }
        #endregion
    }
}
