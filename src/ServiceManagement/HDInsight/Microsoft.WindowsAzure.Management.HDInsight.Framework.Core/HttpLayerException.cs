// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest
{
    using System;
    using System.Globalization;
    using System.Net;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception that will be raise either when there is an exception on 
    /// the Rest client or when the results != OK.
    /// </summary>
    [Serializable]
    public class HttpLayerException : Exception
    {
        /// <summary>
        /// Gets the StatusCode of the request.
        /// </summary>
        public HttpStatusCode RequestStatusCode { get; private set; }

        /// <summary>
        /// Gets error details of the exception.
        /// Only used per inharitance request.
        /// </summary>
        public string RequestContent { get; private set; }

        /// <summary>
        /// Gets the number of attempts tha .
        /// </summary>
        public int AttemptsMade { get; private set; }

        /// <summary>
        /// Initializes a new instance of the HttpLayerException class.
        /// </summary>
        public HttpLayerException() : base()
        {
            this.AttemptsMade = 1;
        }

        /// <summary>
        /// Initializes a new instance of the HttpLayerException class.
        /// </summary>
        /// <param name="message">Message for the base class.</param>
        public HttpLayerException(string message) :
            base(message)
        {
            this.AttemptsMade = 1;
        }

        /// <summary>
        /// Initializes a new instance of the HttpLayerException class.
        /// </summary>
        /// <param name="message">Message for the base class.</param>
        /// <param name="innerException">Inner Exception.</param>
        public HttpLayerException(string message, Exception innerException) :
            base(message, innerException)
        {
            this.AttemptsMade = 1;
        }
        
        /// <summary>
        /// Initializes a new instance of the HttpLayerException class.
        /// </summary>
        /// <param name="statusCode">Status code received from the failed request.</param>
        /// <param name="content">Content of the failed request.</param>
        public HttpLayerException(HttpStatusCode statusCode, string content) : base(string.Format(CultureInfo.InvariantCulture,
                                                                                                             "Request failed with code:{0}\r\nContent:{1}",
                                                                                                             statusCode,
                                                                                                             content ?? "(null)"))
        {
            this.RequestStatusCode = statusCode;
            this.RequestContent = content;
            this.AttemptsMade = 1;
        }

        /// <summary>
        /// Initializes a new instance of the HttpLayerException class.
        /// </summary>
        /// <param name="statusCode">Status code received from the failed request.</param>
        /// <param name="content">Content of the failed request.</param>
        /// <param name="attemptsMade">The number of retry attempts used when attempting the operation.</param>
        /// <param name="period">The time period spent attempting the request.</param>
        public HttpLayerException(HttpStatusCode statusCode, string content, int attemptsMade, TimeSpan period) : base(string.Format(CultureInfo.InvariantCulture,
                                                                                                                       "Request failed after ({0}) attempts over a period of ({1}) with code: {2}\r\nContent:{3}",
                                                                                                                       attemptsMade,
                                                                                                                       period,
                                                                                                                       statusCode,
                                                                                                                       content ?? "(null)"))
        {
            this.RequestStatusCode = statusCode;
            this.RequestContent = content;
            this.AttemptsMade = attemptsMade;
        }

        /// <summary>
        /// Initializes a new instance of the HttpLayerException class from deserialization.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected HttpLayerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.RequestStatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), info.GetString("RequestStatusCode"));
            this.RequestContent = info.GetString("RequestContent");
        }

        /// <summary>
        /// Serializes this object.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        public new virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("RequestStatusCode", this.RequestStatusCode);
            info.AddValue("RequestContent", this.RequestContent);
        }
    }
}