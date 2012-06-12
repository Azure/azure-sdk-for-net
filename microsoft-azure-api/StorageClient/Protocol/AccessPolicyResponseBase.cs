//-----------------------------------------------------------------------
// <copyright file="AccessPolicyResponseBase.cs" company="Microsoft">
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
//    Contains code for the AccessPolicyResponseBase class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;
    
    /// <summary>
    /// Parses the response XML from an operation to set the access policy for a cloud object.
    /// </summary>
    /// <typeparam name="T">The policy type to be filled.</typeparam>
    internal abstract class AccessPolicyResponseBase<T> : ResponseParsingBase<KeyValuePair<string, T>>
        where T : new()
    {
        /// <summary>
        /// Initializes a new instance of the AccessPolicyResponseBase class.
        /// </summary>
        /// <param name="stream">The stream to be parsed.</param>
        protected AccessPolicyResponseBase(Stream stream) : base(stream)
        {
        }

        /// <summary>
        /// Gets an enumerable collection of container-level access policy identifiers.
        /// </summary>
        /// <value>An enumerable collection of container-level access policy identifiers.</value>
        public IEnumerable<KeyValuePair<string, T>> AccessIdentifiers
        {
            get
            {
                return this.ObjectsToParse;
            }
        }

        /// <summary>
        /// Parses the current element.
        /// </summary>
        /// <param name="accessPolicyElement">The shared access policy element to parse.</param>
        /// <returns>The shared access policy.</returns>
        protected abstract T ParseElement(XElement accessPolicyElement);

        /// <summary>
        /// Parses the response XML from a Set Container ACL operation to retrieve container-level access policy data.
        /// </summary>
        /// <returns>A list of enumerable key-value pairs.</returns>
        protected override IEnumerable<KeyValuePair<string, T>> ParseXml()
        {
            XElement root = XElement.Load(reader);
            IEnumerable<XElement> elements = root.Elements(Constants.SignedIdentifier);
            foreach (var signedIdentifierElement in elements)
            {
                string id = (string)signedIdentifierElement.Element(Constants.Id);
                T accessPolicy;
                var accessPolicyElement = signedIdentifierElement.Element(Constants.AccessPolicy);
                if (accessPolicyElement != null)
                {
                    accessPolicy = ParseElement(accessPolicyElement);
                }
                else
                {
                    accessPolicy = new T();
                }

                yield return new KeyValuePair<string, T>(id, accessPolicy);
            }
        }
    }
}
