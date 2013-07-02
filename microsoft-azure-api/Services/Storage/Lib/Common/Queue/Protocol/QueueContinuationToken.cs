// -----------------------------------------------------------------------------------------
// <copyright file="QueueContinuationToken.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Queue.Protocol
{
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a continuation token returned by the Queue service.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1001:CommasMustBeSpacedCorrectly", Justification = "Reviewed.")]
    public sealed class QueueContinuationToken : IContinuationToken
#if DNCP
        , IXmlSerializable
#endif
    {
        /// <summary>
        /// Gets or sets the NextMarker for continuing results for CloudQueeu enumeration operations.
        /// </summary>
        /// <value>The next marker.</value>
        public string NextMarker { get; set; }

#if DNCP
        /// <summary>
        /// Gets an XML representation of an object.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates a serializable continuation token from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the continuation token is deserialized.</param>
        public void ReadXml(System.Xml.XmlReader reader)
        {
            CommonUtils.AssertNotNull("reader", reader);

            reader.MoveToContent();

            bool isEmptyElement = reader.IsEmptyElement;
            reader.ReadStartElement();

            if (!isEmptyElement)
            {
                while (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement)
                {
                    if (!reader.IsEmptyElement)
                    {
                        switch (reader.Name)
                        {
                            case Constants.ContinuationConstants.VersionElement:
                                string version = reader.ReadElementContentAsString();

                                // For future versioning
                                break;
                            case Constants.ContinuationConstants.NextMarkerElement:
                                this.NextMarker = reader.ReadElementContentAsString();
                                break;
                            case Constants.ContinuationConstants.TypeElement:
                                string continuationType = reader.ReadElementContentAsString();
                                if ("Queue" != continuationType)
                                {
                                    throw new System.Xml.XmlException(SR.UnexpectedContinuationType);
                                }

                                break;
                            default:
                                throw new XmlException(string.Format(SR.UnexpectedElement, reader.Name));
                        }
                    }
                    else
                    {
                        throw new XmlException(string.Format(SR.UnexpectedEmptyElement, reader.Name));
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
            CommonUtils.AssertNotNull("writer", writer);

            writer.WriteStartElement(Constants.ContinuationConstants.ContinuationTopElement);

            writer.WriteElementString(Constants.ContinuationConstants.VersionElement, Constants.ContinuationConstants.CurrentVersion);

            writer.WriteElementString(Constants.ContinuationConstants.TypeElement, "Queue");

            if (this.NextMarker != null)
            {
                writer.WriteElementString(Constants.ContinuationConstants.NextMarkerElement, this.NextMarker);
            }

            writer.WriteEndElement(); // End ContinuationToken
        }
#endif
    }
}
