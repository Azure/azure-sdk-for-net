//-----------------------------------------------------------------------
// <copyright file="AccessPolicyResponse.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the AccessPolicyResponse class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    
    /// <summary>
    /// Parses the response XML from an operation to set the access policy for a container.
    /// </summary>
    public class AccessPolicyResponse : ResponseParsingBase<KeyValuePair<string, SharedAccessPolicy>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessPolicyResponse"/> class.
        /// </summary>
        /// <param name="stream">The stream to be parsed.</param>
        internal AccessPolicyResponse(Stream stream) : base(stream)
        {
        }

        /// <summary>
        /// Gets an enumerable collection of container-level access policy identifiers.
        /// </summary>
        /// <value>An enumerable collection of container-level access policy identifiers.</value>
        public IEnumerable<KeyValuePair<string, SharedAccessPolicy>> AccessIdentifiers
        {
            get
            {
                return this.ObjectsToParse;
            }
        }

        /// <summary>
        /// Parses the response XML from a Set Container ACL operation to retrieve container-level access policy data.
        /// </summary>
        /// <returns>A list of enumerable key-value pairs.</returns>
        protected override IEnumerable<KeyValuePair<string, SharedAccessPolicy>> ParseXml()
        {
            bool needToRead = true;
            while (true)
            {
                if (needToRead && !reader.Read())
                {
                    break;
                }

                needToRead = true;

                if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement && reader.Name == Constants.SignedIdentifiers)
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement && reader.Name == Constants.SignedIdentifier)
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement && reader.Name == Constants.Id)
                                {
                                    string id = reader.ReadElementContentAsString();
                                    SharedAccessPolicy identifier = new SharedAccessPolicy();
                                    bool needToReadItem = true;

                                    do
                                    {
                                        if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement
                                            && reader.Name == Constants.AccessPolicy)
                                        {
                                            bool needToReadElement = true;

                                            while (true)
                                            {
                                                if (needToReadElement && !reader.Read())
                                                {
                                                    break;
                                                }

                                                needToReadElement = true;

                                                if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement)
                                                {
                                                    switch (reader.Name)
                                                    {
                                                        case Constants.Start:
                                                            identifier.SharedAccessStartTime = Uri.UnescapeDataString(reader.ReadElementContentAsString()).ToUTCTime();
                                                            needToReadElement = false;
                                                            break;
                                                        case Constants.Expiry:
                                                            identifier.SharedAccessExpiryTime = Uri.UnescapeDataString(reader.ReadElementContentAsString()).ToUTCTime();
                                                            needToReadElement = false;
                                                            break;
                                                        case Constants.Permission:
                                                            identifier.Permissions = SharedAccessPolicy.PermissionsFromString(reader.ReadElementContentAsString());
                                                            needToReadElement = false;
                                                            break;
                                                    }
                                                }
                                                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.AccessPolicy)
                                                {
                                                    needToReadItem = false;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    while (needToReadItem && reader.Read());

                                    yield return new KeyValuePair<string, SharedAccessPolicy>(id, identifier);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
