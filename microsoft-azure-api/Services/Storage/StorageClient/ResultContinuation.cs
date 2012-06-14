//-----------------------------------------------------------------------
// <copyright file="ResultContinuation.cs" company="Microsoft">
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
// <summary>
//    Contains code for the ResultContinuation class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Manage continuation information for various listing operation.
    /// Can be serialized using XmlSerialization.
    /// </summary>
    [Serializable]
    public sealed class ResultContinuation : IXmlSerializable
    {
        /// <summary>
        /// XML element for the next marker.
        /// </summary>
        private const string NextMarkerElement = "NextMarker";

        /// <summary>
        /// XML element for the next partition key.
        /// </summary>
        private const string NextPartitionKeyElement = "NextPartitionKey";

        /// <summary>
        /// XML element for the next row key.
        /// </summary>
        private const string NextRowKeyElement = "NextRowKey";

        /// <summary>
        /// XML element for the next table name.
        /// </summary>
        private const string NextTableNameElement = "NextTableName";

        /// <summary>
        /// XML element for the token version.
        /// </summary>
        private const string VersionElement = "Version";

        /// <summary>
        /// Stores the current token version value.
        /// </summary>
        private const string CurrentVersion = "1.0";

        /// <summary>
        /// XML element for the token type.
        /// </summary>
        private const string TypeElement = "Type";

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultContinuation"/> class.
        /// </summary>
        internal ResultContinuation()
        { 
        }

        /// <summary>
        /// Specifies the type of a continuation token.
        /// </summary>
        internal enum ContinuationType
        {
            /// <summary>
            /// Default for no continuation.
            /// </summary>
            None = 0,

            /// <summary>
            /// The token is a blob listing continuation token.
            /// </summary>
            Blob,

            /// <summary>
            /// The token is a queue listing continuation token.
            /// </summary>
            Queue,

            /// <summary>
            /// The token is a container listing continuation token.
            /// </summary>
            Container,

            /// <summary>
            /// The token is a table query continuation token.
            /// </summary>
            Table
        }

        /// <summary>
        /// Gets or sets the NextPartitionKey for TableServiceEntity enumeration operations.
        /// </summary>
        internal string NextPartitionKey { get; set; }

        /// <summary>
        /// Gets or sets the NextRowKey for TableServiceEntity enumeration operations.
        /// </summary>
        /// <value>The next row key.</value>
        internal string NextRowKey { get; set; }

        /// <summary>
        /// Gets or sets the NextTableName for Table enumeration operations.
        /// </summary>
        /// <value>The name of the next table.</value>
        internal string NextTableName { get; set; }

        /// <summary>
        /// Gets or sets the NextMarker for continuing results for CloudBlob and CloudBlobContainer and CloudQueue enumeration operations.
        /// </summary>
        /// <value>The next marker.</value>
        internal string NextMarker { get; set; }

        /// <summary>
        /// Gets a value indicating whether there is continuation information present.
        /// </summary>
        /// <returns></returns>
        internal bool HasContinuation
        {
            get { return this.NextMarker != null || this.NextPartitionKey != null || this.NextRowKey != null || this.NextTableName != null; }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The continuation type.</value>
        internal ContinuationType Type { get; set; }

        /// <summary>
        /// Gets an XML representation of an object.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates a serializable continuation token from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the continuation token is deserialized.</param>
        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {
            CommonUtils.AssertNotNull("reader", reader);

            reader.MoveToContent();

            bool isEmptyElement = reader.IsEmptyElement;
            reader.ReadStartElement();

            if (!isEmptyElement)
            {
                bool more = true;
                while (more)
                {
                    if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement)
                    {
                        switch (reader.Name)
                        {
                            case VersionElement:
                                string version = reader.ReadElementContentAsString();

                                // For future versioning
                                break;
                            case NextMarkerElement:
                                this.NextMarker = reader.ReadElementContentAsString();
                                break;
                            case NextPartitionKeyElement:
                                this.NextPartitionKey = reader.ReadElementContentAsString();
                                break;
                            case NextRowKeyElement:
                                this.NextRowKey = reader.ReadElementContentAsString();
                                break;
                            case NextTableNameElement:
                                this.NextTableName = reader.ReadElementContentAsString();
                                break;
                            case TypeElement:
                                this.Type = (ContinuationType)Enum.Parse(typeof(ContinuationType), reader.ReadElementContentAsString());
                                break;
                        }
                    }
                    else
                    {
                        more = reader.Read();
                    }
                }
            }
        }

        /// <summary>
        /// Converts a serializable continuation token into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the continuation token is serialized.</param>
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            CommonUtils.AssertNotNull("writer", writer);

            writer.WriteElementString(VersionElement, CurrentVersion);

            writer.WriteElementString(TypeElement, this.Type.ToString());

            if (this.NextMarker != null)
            {
                writer.WriteElementString(NextMarkerElement, this.NextMarker);
            }

            if (this.NextPartitionKey != null)
            {
                writer.WriteElementString(NextPartitionKeyElement, this.NextPartitionKey);
            }

            if (this.NextRowKey != null)
            {
                writer.WriteElementString(NextRowKeyElement, this.NextRowKey);
            }

            if (this.NextTableName != null)
            {
                writer.WriteElementString(NextTableNameElement, this.NextTableName);
            }
        }
    }
}
