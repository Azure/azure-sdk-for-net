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
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

#if RT
    using Windows.Storage.Streams;
#endif

    /// <summary>
    /// Represents extended error information returned by the Windows Azure storage services.
    /// </summary>
#if DNCP
    [Serializable]
#endif
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

        /// <summary>
        /// Generates a serializable StorageExtendedErrorInformation from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the StorageExtendedErrorInformation is deserialized.</param>
#if RTMD
        internal
#else
        public
#endif
 void ReadXml(XmlReader reader)
        {
            this.AdditionalDetails = new Dictionary<string, string>();

            reader.ReadStartElement();
            while (reader.IsStartElement())
            {
                if (reader.IsEmptyElement)
                {
                    reader.Skip();
                }
                else
                {
                    if ((string.Compare(reader.Name, Constants.ErrorCode, StringComparison.Ordinal) == 0) || (string.Compare(reader.Name, Constants.ErrorCodePreview, StringComparison.Ordinal) == 0))
                    {
                        this.ErrorCode = reader.ReadElementContentAsString();
                    }
                    else if ((string.Compare(reader.Name, Constants.ErrorMessage, StringComparison.Ordinal) == 0) || (string.Compare(reader.Name, Constants.ErrorMessagePreview, StringComparison.Ordinal) == 0))
                    {
                        this.ErrorMessage = reader.ReadElementContentAsString();
                    }
                    else if ((string.Compare(reader.Name, Constants.ErrorException, StringComparison.Ordinal) == 0))
                    {
                        reader.ReadStartElement();
                        while (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case Constants.ErrorExceptionMessage:
                                    this.AdditionalDetails.Add(
                                    Constants.ErrorExceptionMessage,
                                    reader.ReadElementContentAsString(Constants.ErrorExceptionMessage, string.Empty));
                                    break;

                                case Constants.ErrorExceptionStackTrace:
                                    this.AdditionalDetails.Add(
                                    Constants.ErrorExceptionStackTrace,
                                    reader.ReadElementContentAsString(Constants.ErrorExceptionStackTrace, string.Empty));
                                    break;

                                default:
                                    reader.Skip();
                                    break;
                            }
                        }

                        reader.ReadEndElement();
                    }
                    else
                    {
                        this.AdditionalDetails.Add(
                        reader.Name,
                        reader.ReadInnerXml());
                    }
                }
            }
        }

        /// <summary>
        /// Converts a serializable StorageExtendedErrorInformation object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the StorageExtendedErrorInformation is serialized.</param>
#if RTMD
        internal
#else
        public
#endif
        void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement(Constants.ErrorRootElement);
            writer.WriteElementString(Constants.ErrorCode, this.ErrorCode);
            writer.WriteElementString(Constants.ErrorMessage, this.ErrorMessage);

            foreach (string key in this.AdditionalDetails.Keys)
            {
                writer.WriteElementString(key, this.AdditionalDetails[key]);
            }

            // End StorageExtendedErrorInformation
            writer.WriteEndElement();
        }

        #endregion
    }
}