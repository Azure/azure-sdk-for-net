//-----------------------------------------------------------------------
// <copyright file="BlobContinuationToken.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a continuation token for listing operations. 
    /// </summary>
    /// <remarks><see cref="BlobContinuationToken"/> continuation tokens are used in methods that return a <see cref="BlobResultSegment"/> object, such as <see cref="CloudBlobDirectory.ListBlobsSegmented(BlobContinuationToken)"/>.</remarks>
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1001:CommasMustBeSpacedCorrectly", Justification = "Reviewed.")]
    public sealed class BlobContinuationToken : IContinuationToken
#if WINDOWS_DESKTOP
        , IXmlSerializable
#endif
    {
        /// <summary>
        /// Gets or sets the next marker for continuing results for <see cref="ICloudBlob"/> enumeration operations.
        /// </summary>
        /// <value>The next marker.</value>
        public string NextMarker { get; set; }

#if WINDOWS_DESKTOP
        /// <summary>
        /// Gets an XML representation of an object.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates a serializable continuation token from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the continuation token is deserialized.</param>
        public void ReadXml(XmlReader reader)
        {
            CommonUtility.AssertNotNull("reader", reader);

            reader.MoveToContent();

            if (reader.IsEmptyElement)
            {
                reader.Skip();
            }
            else
            {
                reader.ReadStartElement();
                while (reader.IsStartElement())
                {
                    if (reader.IsEmptyElement)
                    {
                        reader.Skip();
                    }
                    else
                    {
                        switch (reader.Name)
                        {
                            case Constants.ContinuationConstants.VersionElement:
                                string version = reader.ReadElementContentAsString();
                                if (version != Constants.ContinuationConstants.CurrentVersion)
                                {
                                    throw new XmlException(string.Format(CultureInfo.InvariantCulture, SR.UnexpectedElement, version));
                                }

                                break;

                            case Constants.ContinuationConstants.NextMarkerElement:
                                this.NextMarker = reader.ReadElementContentAsString();
                                break;

                            case Constants.ContinuationConstants.TypeElement:
                                string continuationType = reader.ReadElementContentAsString();
                                if (Constants.ContinuationConstants.BlobType != continuationType)
                                {
                                    throw new XmlException(SR.UnexpectedContinuationType);
                                }

                                break;

                            default:
                                throw new XmlException(string.Format(CultureInfo.InvariantCulture, SR.UnexpectedElement, reader.Name));
                        }
                    }
                }

                reader.ReadEndElement();
            }
        }

        /// <summary>
        /// Converts a serializable continuation token into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the continuation token is serialized.</param>
        public void WriteXml(XmlWriter writer)
        {
            CommonUtility.AssertNotNull("writer", writer);

            writer.WriteStartElement(Constants.ContinuationConstants.ContinuationTopElement);

            writer.WriteElementString(Constants.ContinuationConstants.VersionElement, Constants.ContinuationConstants.CurrentVersion);

            writer.WriteElementString(Constants.ContinuationConstants.TypeElement, Constants.ContinuationConstants.BlobType);

            if (this.NextMarker != null)
            {
                writer.WriteElementString(Constants.ContinuationConstants.NextMarkerElement, this.NextMarker);
            }

            writer.WriteEndElement(); // End ContinuationToken
        }
#endif
    }
}
