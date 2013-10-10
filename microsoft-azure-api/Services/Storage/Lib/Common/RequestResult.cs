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
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Represents the result of a physical request.
    /// </summary>
#if WINDOWS_DESKTOP && !WINDOWS_PHONE
    [Serializable]
#endif
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
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ID", Justification = "Back compatibility.")]
        public string ServiceRequestID { get; internal set; }

        /// <summary>
        /// Gets the content-MD5 value for the request. 
        /// </summary>
        /// <value>The content-MD5 value for the request.</value>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Md", Justification = "Back compatibility.")]
        public string ContentMd5 { get; internal set; }

        /// <summary>
        /// Gets the ETag value of the request.
        /// </summary>
        /// <value>The ETag value of the request.</value>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Etag", Justification = "Reviewed: Etag can be used for identifier names.")]
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
#if WINDOWS_RT
                this.ExceptionInfo = (value != null) ? new ExceptionInfo(value) : null;            
#endif
                this.exception = value;
            }
        }

#if WINDOWS_RT
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
#if WINDOWS_DESKTOP
        [Obsolete("This should be available only in Microsoft.WindowsAzure.Storage.WinMD and not in Microsoft.WindowsAzure.Storage.dll. Please use ReadXML to deserialize RequestResult when Microsoft.WindowsAzure.Storage.dll is used.")]
#endif
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

        /// <summary>
        /// Generates a serializable RequestResult from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the RequestResult is deserialized.</param>
#if WINDOWS_RT
        internal
#else
        public
#endif
        void ReadXml(XmlReader reader)
        {
            CommonUtility.AssertNotNull("reader", reader);

            reader.Read();

            if (reader.NodeType == XmlNodeType.Comment)
            {
                reader.Read();
            }

            reader.ReadStartElement("RequestResult");

            this.httpStatusCode = int.Parse(CommonUtility.ReadElementAsString("HTTPStatusCode", reader), CultureInfo.InvariantCulture);
            this.HttpStatusMessage = CommonUtility.ReadElementAsString("HttpStatusMessage", reader);
            this.ServiceRequestID = CommonUtility.ReadElementAsString("ServiceRequestID", reader);

            this.ContentMd5 = CommonUtility.ReadElementAsString("ContentMd5", reader);
            this.Etag = CommonUtility.ReadElementAsString("Etag", reader);
            this.RequestDate = CommonUtility.ReadElementAsString("RequestDate", reader);
#if WINDOWS_RT
            this.StartTime = DateTimeOffset.Parse(CommonUtility.ReadElementAsString("StartTime", reader));
            this.EndTime = DateTimeOffset.Parse(CommonUtility.ReadElementAsString("EndTime", reader));
#else
            this.StartTime = DateTime.Parse(CommonUtility.ReadElementAsString("StartTime", reader), CultureInfo.InvariantCulture);
            this.EndTime = DateTime.Parse(CommonUtility.ReadElementAsString("EndTime", reader), CultureInfo.InvariantCulture);
#endif
            this.ExtendedErrorInformation = new StorageExtendedErrorInformation();
            this.ExtendedErrorInformation.ReadXml(reader);

#if WINDOWS_RT
            this.ExceptionInfo = ExceptionInfo.ReadFromXMLReader(reader);
#endif
            // End request Result
            reader.ReadEndElement();
        }

        /// <summary>
        /// Converts a serializable RequestResult into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the RequestResult is serialized.</param>
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "TranslateFromExceptionMessage", Justification = "TranslateFromException is a field name that when split could confuse the users")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "RequestResult", Justification = "RequestResult is a variable name which when split could confuse the users")]
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Xml.XmlWriter.WriteComment(System.String)", Justification = "Reviewed. Literals can be used in an internal method")]
#if WINDOWS_RT
        internal
#else
        public
#endif
        void WriteXml(XmlWriter writer)
        {
            CommonUtility.AssertNotNull("writer", writer);

            writer.WriteComment(SR.ExceptionOccurred);
            writer.WriteStartElement("RequestResult");
            writer.WriteElementString("HTTPStatusCode", Convert.ToString(this.HttpStatusCode, CultureInfo.InvariantCulture));
            writer.WriteElementString("HttpStatusMessage", this.HttpStatusMessage);

            // Headers
            writer.WriteElementString("ServiceRequestID", this.ServiceRequestID);
            writer.WriteElementString("ContentMd5", this.ContentMd5);
            writer.WriteElementString("Etag", this.Etag);
            writer.WriteElementString("RequestDate", this.RequestDate);

            // Dates - using RFC 1123 pattern
            writer.WriteElementString("StartTime", this.StartTime.ToUniversalTime().ToString("R", CultureInfo.InvariantCulture));
            writer.WriteElementString("EndTime", this.EndTime.ToUniversalTime().ToString("R", CultureInfo.InvariantCulture));

            // Extended info
            if (this.ExtendedErrorInformation != null)
            {
                this.ExtendedErrorInformation.WriteXml(writer);
            }
            else
            {
                // Write empty
                writer.WriteStartElement(Constants.ErrorRootElement);
                writer.WriteFullEndElement();
            }
#if WINDOWS_RT
            // Exception
            if (this.ExceptionInfo != null)
            {
                this.ExceptionInfo.WriteXml(writer);
            }
            else
            {
                // Write empty
                writer.WriteStartElement("ExceptionInfo");
                writer.WriteFullEndElement();
            }
#endif

            // End RequestResult
            writer.WriteEndElement();
        }
        #endregion
    }
}
