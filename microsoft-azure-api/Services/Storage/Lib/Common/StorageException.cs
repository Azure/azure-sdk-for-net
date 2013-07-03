// -----------------------------------------------------------------------------------------
// <copyright file="StorageException.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Net;
    using System.Text;

#if WINDOWS_DESKTOP
    using System.Runtime.Serialization;
#elif WINDOWS_RT
    using System.IO;
    using System.Runtime.InteropServices;
#endif

    /// <summary>
    /// Represents an exception for the Windows Azure storage service.
    /// </summary>
#if !WINDOWS_RT && !WINDOWS_PHONE
    [Serializable]
#endif

#if WINDOWS_RT
    internal class StorageException : COMException
#else
    public class StorageException : Exception
#endif
    {
        /// <summary>
        /// Gets the <see cref="RequestResult"/> object for this <see cref="StorageException"/> object.
        /// </summary>
        /// <value>The <see cref="RequestResult"/> object for this <see cref="StorageException"/> object.</value>
        public RequestResult RequestInformation { get; private set; }

        internal bool IsRetryable { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageException"/> class.
        /// </summary>
        public StorageException() : this(null /* res */, null /* message */, null /* inner */) 
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageException"/> class using the specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public StorageException(string message) : 
            this(null /* res */, message, null /* inner */) 
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public StorageException(string message, Exception innerException) :
            this(null /* res */, message, innerException) 
        {
        }

#if !WINDOWS_RT && !WINDOWS_PHONE
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageException"/> class with serialized data.
        /// </summary>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <param name="info">The <see cref="System.Runtime.Serialization.SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <remarks>This constructor is called during de-serialization to reconstitute the exception object transmitted over a stream.</remarks>
        protected StorageException(SerializationInfo info, StreamingContext context) :
            base(info, context) 
        {
            if (info != null)
            {
                this.IsRetryable = info.GetBoolean("IsRetryable");
                this.RequestInformation = (RequestResult)info.GetValue("RequestInformation", typeof(RequestResult));
            }
        }

        /// <summary>
        /// Populates a <see cref="System.Runtime.Serialization.SerializationInfo"/> object with the data needed to serialize the target object.
        /// </summary>
        /// <param name="context">The destination context for this serialization.</param>
        /// <param name="info">The <see cref="System.Runtime.Serialization.SerializationInfo"/> object to populate with data.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info != null)
            {
                info.AddValue("IsRetryable", this.IsRetryable);
                info.AddValue("RequestInformation", this.RequestInformation, typeof(RequestResult));
            }

            base.GetObjectData(info, context);
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageException"/> class by using the specified parameters.
        /// </summary>
        /// <param name="res">The request result.</param>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner exception.</param>
        public StorageException(RequestResult res, string message, Exception inner)
            : base(message, inner)
        {
            this.RequestInformation = res;
            this.IsRetryable = true;
        }

        /// <summary>
        /// Translates the specified exception into a storage exception.
        /// </summary>
        /// <param name="ex">The exception to translate.</param>
        /// <param name="reqResult">The request result.</param>
        /// <returns>The storage exception.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "General Exception wrapped as a StorageException.")]
        [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily", Justification = "Code clarity.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "req", Justification = "Reviewed : req is allowed.")]
        public static StorageException TranslateException(Exception ex, RequestResult reqResult)
        {
            CommonUtility.AssertNotNull("reqResult", reqResult);
            CommonUtility.AssertNotNull("ex", ex);

            // Dont re-wrap storage exceptions
            if (ex is StorageException)
            {
                return (StorageException)ex;
            }
            else if (ex is TimeoutException)
            {
                reqResult.HttpStatusMessage = null;
                reqResult.HttpStatusCode = (int)HttpStatusCode.Unused;
                reqResult.ExtendedErrorInformation = null;
                return new StorageException(reqResult, ex.Message, ex);
            }
            else if (ex is ArgumentException)
            {
                reqResult.HttpStatusMessage = null;
                reqResult.HttpStatusCode = (int)HttpStatusCode.Unused;
                reqResult.ExtendedErrorInformation = null;
                return new StorageException(reqResult, ex.Message, ex) { IsRetryable = false };
            }
#if WINDOWS_RT
            else if (ex is OperationCanceledException)
            {
                reqResult.HttpStatusMessage = null;
                reqResult.HttpStatusCode = 306; // unused
                reqResult.ExtendedErrorInformation = null;
                return new StorageException(reqResult, ex.Message, ex);
            }
#elif WINDOWS_DESKTOP && !WINDOWS_PHONE
            else
            {
                StorageException tableEx = TableUtilities.TranslateDataServiceClientException(ex, reqResult);

                if (tableEx != null)
                {
                    return tableEx;
                }
            }
#endif

            WebException we = ex as WebException;
            if (we != null)
            {
                try
                {
                    HttpWebResponse response = we.Response as HttpWebResponse;
                    if (response != null)
                    {
                        reqResult.HttpStatusMessage = response.StatusDescription;
                        reqResult.HttpStatusCode = (int)response.StatusCode;
                        if (response.Headers != null)
                        {
#if WINDOWS_DESKTOP
                            reqResult.ServiceRequestID = HttpWebUtility.TryGetHeader(response, Constants.HeaderConstants.RequestIdHeader, null);
                            reqResult.ContentMd5 = HttpWebUtility.TryGetHeader(response, "Content-MD5", null);
                            string tempDate = HttpWebUtility.TryGetHeader(response, "Date", null);
                            reqResult.RequestDate = string.IsNullOrEmpty(tempDate) ? DateTime.Now.ToString("R", CultureInfo.InvariantCulture) : tempDate;
                            reqResult.Etag = response.Headers[HttpResponseHeader.ETag];
#endif
                        }
#if WINDOWS_RT
                        reqResult.ExtendedErrorInformation = StorageExtendedErrorInformation.ReadFromStream(response.GetResponseStream().AsInputStream());
#else
                        reqResult.ExtendedErrorInformation = StorageExtendedErrorInformation.ReadFromStream(response.GetResponseStream());
#endif
                    }
                }
                catch (Exception)
                {
                    // no op
                }
            }

            // Not WebException, just wrap in StorageException
            return new StorageException(reqResult, ex.Message, ex);
        }

        /// <summary>
        /// Represents an exception thrown by the Windows Azure storage client library. 
        /// </summary>
        /// <returns>A string that represents the exception.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            if (this.RequestInformation != null)
            {
                sb.AppendLine("Request Information");
                sb.AppendLine("RequestID:" + this.RequestInformation.ServiceRequestID);
                sb.AppendLine("RequestDate:" + this.RequestInformation.RequestDate);
                sb.AppendLine("StatusMessage:" + this.RequestInformation.HttpStatusMessage);

                if (this.RequestInformation.ExtendedErrorInformation != null)
                {
                    sb.AppendLine("ErrorCode:" + this.RequestInformation.ExtendedErrorInformation.ErrorCode);
                }
            }

            return sb.ToString();
        }
    }
}