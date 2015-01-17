// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Reader
{
    /// <summary>
    /// Represents a mapping of a namespace prefix to its namespace uri.
    /// </summary>
#if Non_Public_SDK
    public class DynaXmlNamespaceMapping
#else
    internal class DynaXmlNamespaceMapping
#endif
    {
        /// <summary>
        ///    Initializes a new instance of the DynaXmlNamespaceMapping class.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="xmlNamespace">The URI.</param>
        public DynaXmlNamespaceMapping(string prefix, string xmlNamespace)
        {
            this.Prefix = prefix;
            this.XmlNamespace = xmlNamespace;
        }

        /// <summary>
        /// Gets the xmlNamespace for this mapping.
        /// </summary>
        public string XmlNamespace { get; private set; }

        /// <summary>
        /// Gets the prefix for this mapping.
        /// </summary>
        public string Prefix { get; private set; }
    }
}
