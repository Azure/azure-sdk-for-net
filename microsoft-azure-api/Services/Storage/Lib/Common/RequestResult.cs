// -----------------------------------------------------------------------------------------
// <copyright file="RequestResult.cs" company="Microsoft">
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
    using System.IO;
    using System.Text;
    using System.Xml;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

#if COMMON
    // XML / Linq not available in COMMON
#elif RTMD
    using System.Xml.Linq;
#endif

    /// <summary>
    /// Represents the result of a physical request.
    /// </summary>
    public sealed class RequestResult
    {
        private int httpStatusCode = -1;

        private volatile Exception exception = null;

        /// <summary>
        /// Gets or sets the HTTP status code for the request.
        /// </summary>
        /// <value>The HTTP status code for the request.</value>
        public int HttpStatusCode
        {
            get
            {
                return this.httpStatusCode;
            }

            set
            {
                this.httpStatusCode = value;
            }
        }

        /// <summary>
        /// Gets the HTTP status message for the request.
        /// </summary>
        /// <value>The HTTP status message for the request.</value>
        public string HttpStatusMessage { get; internal set; }

        /// <summary>
        /// Gets the service request ID for this request.
        /// </summary>
        /// <value>The service request ID for this request.</value>
        public string ServiceRequestID { get; internal set; }

        /// <summary>
        /// Gets the content-MD5 value for the request. 
        /// </summary>
        /// <value>The content-MD5 value for the request.</value>
        public string ContentMd5 { get; internal set; }

        /// <summary>
        /// Gets the ETag value of the request.
        /// </summary>
        /// <value>The ETag value of the request.</value>
        public string Etag { get; internal set; }

        /// <summary>
        /// Gets the request date.
        /// </summary>
        /// <value>The request date.</value>
        public string RequestDate { get; internal set; }

        /// <summary>
        /// Gets the extended error information.
        /// </summary>
        /// <value>The extended error information.</value>
        public StorageExtendedErrorInformation ExtendedErrorInformation { get; internal set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception
        {
            get
            {
                return this.exception;
            }

            set
            {
#if RTMD
                this.ExceptionInfo = (value != null) ? new ExceptionInfo(value) : null;            
#endif
                this.exception = value;
            }
        }

#if RTMD
        public DateTimeOffset StartTime { get; internal set; }

        public DateTimeOffset EndTime { get; internal set; }

        public ExceptionInfo ExceptionInfo { get; internal set; }
#else
        /// <summary>
        /// Gets the start time of the operation.
        /// </summary>
        /// <value>The start time of the operation.</value>
        public DateTime StartTime { get; internal set; }

        /// <summary>
        /// Gets the end time of the operation.
        /// </summary>
        /// <value>The end time of the operation.</value>
        public DateTime EndTime { get; internal set; }
#endif
        /// <summary>
        /// Translates the specified message into a <see cref="RequestResult"/> object.
        /// </summary>
        /// <param name="message">The message to translate.</param>
        /// <returns>The translated <see cref="RequestResult"/>.</returns>
        public static RequestResult TranslateFromExceptionMessage(string message)
        {
            RequestResult res = new RequestResult();

            using (XmlReader reader = XmlReader.Create(new StringReader(message)))
            {
                res.ReadXml(reader);
            }

            return res;
        }

        internal string WriteAsXml()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            StringBuilder sb = new StringBuilder();
            try
            {
                using (XmlWriter writer = XmlWriter.Create(sb, settings))
                {
                    this.WriteXml(writer);
                }

                return sb.ToString();
            }
            catch (XmlException)
            {
                return null;
            }
        }

        #region XML Serializable

        internal void ReadXml(XmlReader reader)
        {
            reader.Read();

            if (reader.NodeType == XmlNodeType.Comment)
            {
                reader.Read();
            }

            reader.ReadStartElement("RequestResult");

            this.httpStatusCode = int.Parse(General.ReadElementAsString("HTTPStatusCode", reader));
            this.HttpStatusMessage = General.ReadElementAsString("HttpStatusMessage", reader);
            this.ServiceRequestID = General.ReadElementAsString("ServiceRequestID", reader);

            this.ContentMd5 = General.ReadElementAsString("ContentMd5", reader);
            this.Etag = General.ReadElementAsString("Etag", reader);
            this.RequestDate = General.ReadElementAsString("RequestDate", reader);
#if RTMD
            this.StartTime = DateTimeOffset.Parse(General.ReadElementAsString("StartTime", reader));
            this.EndTime = DateTimeOffset.Parse(General.ReadElementAsString("EndTime", reader));
#else
            this.StartTime = DateTime.Parse(General.ReadElementAsString("StartTime", reader));
            this.EndTime = DateTime.Parse(General.ReadElementAsString("EndTime", reader));
#endif
            this.ExtendedErrorInformation = new StorageExtendedErrorInformation();
            this.ExtendedErrorInformation.ReadXml(reader);

#if RTMD
            this.ExceptionInfo = ExceptionInfo.ReadFromXMLReader(reader);
#endif
            // End request Result
            reader.ReadEndElement();
        }

        internal void WriteXml(XmlWriter writer)
        {
            writer.WriteComment("An exception has occurred. For more information please deserialize this message via RequestResult.TranslateFromExceptionMessage.");
            writer.WriteStartElement("RequestResult");
            writer.WriteElementString("HTTPStatusCode", Convert.ToString(this.HttpStatusCode));
            writer.WriteElementString("HttpStatusMessage", this.HttpStatusMessage);

            // Headers
            writer.WriteElementString("ServiceRequestID", this.ServiceRequestID);
            writer.WriteElementString("ContentMd5", this.ContentMd5);
            writer.WriteElementString("Etag", this.Etag);
            writer.WriteElementString("RequestDate", this.RequestDate);

            // Dates - using RFC 1123 pattern
            writer.WriteElementString("StartTime", this.StartTime.ToString("R", CultureInfo.InvariantCulture));
            writer.WriteElementString("EndTime", this.EndTime.ToString("R", CultureInfo.InvariantCulture));

            // Extended info
            if (this.ExtendedErrorInformation != null)
            {
                this.ExtendedErrorInformation.WriteXml(writer);
            }
            else
            {
                // Write empty
                writer.WriteStartElement(Constants.ErrorRootElement);
                writer.WriteEndElement();
            }
#if RTMD
            // Exception
            if (this.ExceptionInfo != null)
            {
                this.ExceptionInfo.WriteXml(writer);
            }
            else
            {
                // Write empty
                writer.WriteStartElement("ExceptionInfo");
                writer.WriteEndElement();
            }
#endif

            // End RequestResult
            writer.WriteEndElement();
        }
        #endregion
    }
}
