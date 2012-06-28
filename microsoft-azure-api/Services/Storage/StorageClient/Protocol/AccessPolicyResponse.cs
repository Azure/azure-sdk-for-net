//-----------------------------------------------------------------------
// <copyright file="AccessPolicyResponse.cs" company="Microsoft">
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
//    Contains code for the AccessPolicyResponse class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;
    
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
            XElement root = XElement.Load(reader);
            IEnumerable<XElement> elements = root.Elements(Constants.SignedIdentifier);
            foreach (XElement signedIdentifierElement in elements)
            {
                SharedAccessPolicy sap = new SharedAccessPolicy();
                string id = (string)signedIdentifierElement.Element(Constants.Id);
                XElement accessPolicyElement = signedIdentifierElement.Element(Constants.AccessPolicy);
                if (accessPolicyElement != null)
                {
                    string sharedAccessStartTimeString = (string)accessPolicyElement.Element(Constants.Start);
                    if (!string.IsNullOrEmpty(sharedAccessStartTimeString))
                    {
                        sap.SharedAccessStartTime = Uri.UnescapeDataString(sharedAccessStartTimeString).ToUTCTime();
                    }

                    string sharedAccessExpiryTimeString = (string)accessPolicyElement.Element(Constants.Expiry);
                    if (!string.IsNullOrEmpty(sharedAccessExpiryTimeString))
                    {
                        sap.SharedAccessExpiryTime = Uri.UnescapeDataString(sharedAccessExpiryTimeString).ToUTCTime();
                    }

                    string permissionsString = (string)accessPolicyElement.Element(Constants.Permission);
                    if (!string.IsNullOrEmpty(permissionsString))
                    {
                        sap.Permissions = SharedAccessPolicy.PermissionsFromString(permissionsString);
                    }
                }

                yield return new KeyValuePair<string, SharedAccessPolicy>(id, sap);
            }
        }
    }
}
