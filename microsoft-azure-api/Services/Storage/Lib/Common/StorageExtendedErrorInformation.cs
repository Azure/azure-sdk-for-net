// -----------------------------------------------------------------------------------------
// <copyright file="StorageExtendedErrorInformation.cs" company="Microsoft">
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
    using System.IO;
    using System.Xml;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

#if RT
    using Windows.Storage.Streams;
#endif

    /// <summary>
    /// Represents extended error information returned by the Windows Azure storage services.
    /// </summary>
    public sealed class StorageExtendedErrorInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageExtendedErrorInformation"/> class.
        /// </summary>
        public StorageExtendedErrorInformation()
        {
        }

        /// <summary>
        /// Gets the storage service error code.
        /// </summary>
        /// <value>The storage service error code.</value>
        public string ErrorCode { get; internal set; }

        /// <summary>
        /// Gets the storage service error message.
        /// </summary>
        /// <value>The storage service error message.</value>
        public string ErrorMessage { get; internal set; }

        /// <summary>
        /// Gets additional error details.
        /// </summary>
        /// <value>The additional error details.</value>
        public IDictionary<string, string> AdditionalDetails { get; internal set; }

#if RT
        public static StorageExtendedErrorInformation ReadFromStream(IInputStream inputStream)
        {
            return ReadFromStream(inputStream.AsStreamForRead());
        }
#endif

        /// <summary>
        /// Gets the error details from stream.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <returns>The error details.</returns>
#if RT
        internal
#else
        public
#endif
 static StorageExtendedErrorInformation ReadFromStream(Stream inputStream)
        {
            StorageExtendedErrorInformation extendedErrorInfo = new StorageExtendedErrorInformation();
            try
            {
                using (XmlReader reader = XmlReader.Create(inputStream))
                {
                    reader.Read();
                    extendedErrorInfo.ReadXml(reader);
                }

                return extendedErrorInfo;
            }
            catch (XmlException)
            {
                // If there is a parsing error we cannot return extended error information
                return null;
            }
        }

        #region IXmlSerializable

        internal void ReadXml(XmlReader reader)
        {
            General.SkipWhitespace(reader);

            while (reader.NodeType == XmlNodeType.XmlDeclaration || reader.NodeType == XmlNodeType.Whitespace)
            {
                reader.Read();
            }

            if (reader.LocalName == Constants.ErrorRootElement && reader.IsEmptyElement)
            {
                reader.Read();
                return;
            }

            reader.ReadStartElement(reader.LocalName == Constants.ErrorRootElement ? Constants.ErrorRootElement : Constants.ErrorRootElement.ToLower());

            General.SkipWhitespace(reader);

            this.ErrorCode = General.ReadElementAsString(reader.LocalName == Constants.ErrorCode ? Constants.ErrorCode : Constants.ErrorCode.ToLower(), reader);
            this.ErrorMessage = General.ReadElementAsString(reader.LocalName == Constants.ErrorMessage ? Constants.ErrorMessage : Constants.ErrorMessage.ToLower(), reader);
            this.AdditionalDetails = new Dictionary<string, string>();

            // After error code and message we can have a number of additional details optionally followed
            // by ExceptionDetails element - we'll read all of these into the additionalDetails collection
            do
            {
                if (reader.IsStartElement())
                {
                    // Exception
                    if (string.Compare(reader.LocalName, Constants.ErrorException, StringComparison.Ordinal) == 0)
                    {
                        // Need to read exception details - we have message and stack trace
                        reader.ReadStartElement(reader.LocalName);

                        this.AdditionalDetails.Add(
                            Constants.ErrorExceptionMessage,
                            reader.ReadElementContentAsString(Constants.ErrorExceptionMessage, string.Empty));
                        this.AdditionalDetails.Add(
                            Constants.ErrorExceptionStackTrace,
                            reader.ReadElementContentAsString(Constants.ErrorExceptionStackTrace, string.Empty));

                        // End exception
                        reader.ReadEndElement();
                    }
                    else
                    {
                        // Name Value pair
                        string elementName = reader.LocalName;
                        this.AdditionalDetails.Add(elementName, reader.ReadElementContentAsString());
                    }
                }
            }
            while (reader.IsStartElement());

            // End Error
            reader.ReadEndElement();
        }

        internal void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement(Constants.ErrorRootElement);
            writer.WriteElementString(Constants.ErrorCode, this.ErrorCode);
            writer.WriteElementString(Constants.ErrorMessage, this.ErrorMessage);

            foreach (string key in this.AdditionalDetails.Keys)
            {
                writer.WriteElementString("key", this.AdditionalDetails[key]);
            }

            // End StorageExtendedErrorInformation
            writer.WriteEndElement();
        }

        #endregion
    }
}