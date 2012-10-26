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
    using System;
    using System.Globalization;
    using System.Net;
#if RTMD
    using System.IO;
    using System.Runtime.InteropServices;
#endif

    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;
    using System.Text;

#if RTMD
    internal class StorageException : COMException
#else
    /// <summary>
    /// Represents an exception for the Windows Azure storage service.
    /// </summary>
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
        public static StorageException TranslateException(Exception ex, RequestResult reqResult)
        {
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
#if RT
            else if (ex is OperationCanceledException)
            {
                reqResult.HttpStatusMessage = null;
                reqResult.HttpStatusCode = 306; // unused
                reqResult.ExtendedErrorInformation = null;
                return new StorageException(reqResult, ex.Message, ex);
            }
#elif DNCP
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
#if DNCP
                            reqResult.ServiceRequestID = HttpUtility.TryGetHeader(response, Constants.HeaderConstants.RequestIdHeader, null);
                            reqResult.ContentMd5 = HttpUtility.TryGetHeader(response, "Content-MD5", null);
                            string tempDate = HttpUtility.TryGetHeader(response, "Date", null);
                            reqResult.RequestDate = string.IsNullOrEmpty(tempDate) ? DateTime.Now.ToString("R", CultureInfo.InvariantCulture) : tempDate;
                            reqResult.Etag = response.Headers[HttpResponseHeader.ETag];
#endif
                        }
#if RT
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