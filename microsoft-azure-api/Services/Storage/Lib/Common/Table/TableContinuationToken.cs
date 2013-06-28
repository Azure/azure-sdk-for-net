// -----------------------------------------------------------------------------------------
// <copyright file="TableContinuationToken.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Table
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Xml;
    using System.Xml.Serialization;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;

    /// <summary>
    /// Represents a continuation token for listing operations. 
    /// </summary>
    /// <remarks>A method that may return a partial set of results via a <see cref="TableResultSegment"/> object also returns a continuation token, 
    /// which can be used in a subsequent call to return the next set of available results. </remarks>
#if DNCP
    [Serializable]
#endif

    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1001:CommasMustBeSpacedCorrectly", Justification = "Reviewed.")]
    public sealed class TableContinuationToken : IContinuationToken
#if DNCP
, IXmlSerializable
#endif
    {
        /// <summary>
        /// Gets or sets the next partition key for <see cref="ITableEntity"/> enumeration operations.
        /// </summary>
        /// <value>The next partition key.</value>
        public string NextPartitionKey { get; set; }

        /// <summary>
        /// Gets or sets the next row key for <see cref="ITableEntity"/> enumeration operations.
        /// </summary>
        /// <value>The next row key.</value>
        public string NextRowKey { get; set; }

        /// <summary>
        /// Gets or sets the next table name for <see cref="ITableEntity"/> enumeration operations.
        /// </summary>
        /// <value>The name of the next table.</value>
        public string NextTableName { get; set; }

#if !RTMD
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
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            reader.MoveToContent();

            bool isEmptyElement = reader.IsEmptyElement;
            reader.ReadStartElement(Constants.ContinuationConstants.ContinuationTopElement);

            if (!isEmptyElement)
            {
                while (true)
                {
                    if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement)
                    {
                        switch (reader.Name)
                        {
                            case Constants.ContinuationConstants.VersionElement:
                                string version = reader.ReadElementContentAsString();
                                if (version != Constants.ContinuationConstants.CurrentVersion)
                                {
                                    throw new System.Xml.XmlException(string.Format(SR.UnexpectedElement, version));
                                }

                                break;
                            case Constants.ContinuationConstants.NextPartitionKeyElement:
                                this.NextPartitionKey = reader.ReadElementContentAsString();
                                break;
                            case Constants.ContinuationConstants.NextRowKeyElement:
                                this.NextRowKey = reader.ReadElementContentAsString();
                                break;
                            case Constants.ContinuationConstants.NextTableNameElement:
                                this.NextTableName = reader.ReadElementContentAsString();
                                break;
                            case Constants.ContinuationConstants.TypeElement:
                                string continuationType = reader.ReadElementContentAsString();
                                if ("Table" != continuationType)
                                {
                                    throw new System.Xml.XmlException(SR.UnexpectedContinuationType);
                                }

                                break;
                            default:
                                throw new System.Xml.XmlException(string.Format(SR.UnexpectedElement, reader.Name));
                        }
                    }
                    else
                    {
                        reader.ReadEndElement();
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Converts a serializable continuation token into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the continuation token is serialized.</param>
        public void WriteXml(XmlWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.WriteStartElement(Constants.ContinuationConstants.ContinuationTopElement);

            writer.WriteElementString(Constants.ContinuationConstants.VersionElement, Constants.ContinuationConstants.CurrentVersion);

            writer.WriteElementString(Constants.ContinuationConstants.TypeElement, "Table");

            if (this.NextPartitionKey != null)
            {
                writer.WriteElementString(Constants.ContinuationConstants.NextPartitionKeyElement, this.NextPartitionKey);
            }

            if (this.NextRowKey != null)
            {
                writer.WriteElementString(Constants.ContinuationConstants.NextRowKeyElement, this.NextRowKey);
            }

            if (this.NextTableName != null)
            {
                writer.WriteElementString(Constants.ContinuationConstants.NextTableNameElement, this.NextTableName);
            }

            writer.WriteEndElement(); // End ContinuationToken
        }
#endif

        internal void ApplyToUriQueryBuilder(UriQueryBuilder builder)
        {
            if (!string.IsNullOrEmpty(this.NextPartitionKey))
            {
                builder.Add(TableConstants.TableServiceNextPartitionKey, this.NextPartitionKey);
            }

            if (!string.IsNullOrEmpty(this.NextRowKey))
            {
                builder.Add(TableConstants.TableServiceNextRowKey, this.NextRowKey);
            }

            if (!string.IsNullOrEmpty(this.NextTableName))
            {
                builder.Add(TableConstants.TableServiceNextTableName, this.NextTableName);
            }
        }
    }
}
