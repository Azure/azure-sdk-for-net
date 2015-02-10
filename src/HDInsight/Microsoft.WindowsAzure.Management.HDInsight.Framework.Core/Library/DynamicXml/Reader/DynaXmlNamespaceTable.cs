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
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml;
    using System.Xml.XPath;

    /// <summary>
    /// Provides a namespace manager for an xml document that recognized the namespaces
    /// that have been defined within that document.
    /// </summary>
#if Non_Public_SDK
    public class DynaXmlNamespaceTable
#else
    internal class DynaXmlNamespaceTable
#endif
    {
        internal IDictionary<string, string> PrefixMatches = new Dictionary<string, string>();
        internal IDictionary<string, IEnumerable<string>> NamespaceMatches = new Dictionary<string, IEnumerable<string>>();

        private void AddToMap(IDictionary<string, ICollection<string>> map, string key, string value)
        {
            ICollection<string> list;
            if (!map.TryGetValue(key, out list))
            {
                list = new List<string>();
                map.Add(key, list);
            }
            list.Add(value);
        }

        /// <summary>
        /// Initializes a new instance of the DynaXmlNamespaceTable class.
        /// </summary>
        /// <param name="document">
        /// The document for which namespace mappings are required.
        /// </param>
        public DynaXmlNamespaceTable(IXPathNavigable document)
        {
            //this.PrefixMatches.Add("empty", string.Empty);
            //this.NamespaceMatches.Add(string.Empty, new string[] { "empty" });
            if (document == null)
            {
                throw new ArgumentNullException("document");
            }

            var prefixToUri = new Dictionary<string, string>();
            var uriToPrefix = new Dictionary<string, ICollection<string>>();
            XPathNavigator nav = document.CreateNavigator();
            XPathNodeIterator list = nav.Select("//namespace::*[name() != 'xml']");
            var nodes = new List<KeyValuePair<string, string>>();
            string firstDefaultNamespace = null;
            while (list.MoveNext())
            {
                XPathNavigator namespaceNode = list.Current;
                if (namespaceNode.NodeType == XPathNodeType.Namespace)
                {
                    string prefix = namespaceNode.LocalName;
                    if (string.IsNullOrEmpty(prefix))
                    {
                        prefix = "def";
                        if (string.IsNullOrEmpty(firstDefaultNamespace))
                        {
                            firstDefaultNamespace = namespaceNode.Value;
                        }
                    }
                    nodes.Add(new KeyValuePair<string, string>(prefix, namespaceNode.Value));
                }
            }
            if (!string.IsNullOrEmpty(firstDefaultNamespace))
            {
                prefixToUri.Add("def", firstDefaultNamespace);
                this.AddToMap(uriToPrefix, firstDefaultNamespace, "def");
            }
            prefixToUri.Add("empty", string.Empty);
            this.AddToMap(uriToPrefix, string.Empty, "empty");
            foreach (KeyValuePair<string, string> namespaceNode in nodes)
            {
                string originalPrefix = namespaceNode.Key;
                string uri = namespaceNode.Value;
                if (string.IsNullOrEmpty(originalPrefix))
                {
                    originalPrefix = "def";
                }
                string prefix = originalPrefix;
                // If the prefix is not in the maps... then it can be added.
                if (!prefixToUri.ContainsKey(prefix))
                {
                    prefixToUri.Add(prefix, uri);
                    this.AddToMap(uriToPrefix, uri, prefix);
                }

                // Otherwise, we only have something to do if this uri
                // has not previously been mapped.
                string mappedNamespace;
                int c = 1;
                while (prefixToUri.TryGetValue(prefix, out mappedNamespace))
                {
                    if (mappedNamespace != uri)
                    {
                        prefix = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", originalPrefix, c++);
                        if (!prefixToUri.ContainsKey(prefix))
                        {
                            prefixToUri.Add(prefix, uri);
                            this.AddToMap(uriToPrefix, uri, prefix);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            this.PrefixMatches = prefixToUri;
            foreach (var match in uriToPrefix)
            {
                this.NamespaceMatches.Add(match.Key, match.Value);
            }
            this.NamespaceManager = new XmlNamespaceManager(document.CreateNavigator().NameTable);
            foreach (KeyValuePair<string, string> pair in prefixToUri)
            {
                this.NamespaceManager.AddNamespace(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// Gets the namespace manager for the xml document supplied.
        /// </summary>
        public XmlNamespaceManager NamespaceManager { get; private set; }

        /// <summary>
        /// Gets the set of DynaXmlNamespaceMappings defined by the supplied document.
        /// </summary>
        public IEnumerable<DynaXmlNamespaceMapping> Mappings
        {
            get
            {
                var list = new List<DynaXmlNamespaceMapping>();
                foreach (KeyValuePair<string, string> prefix in this.PrefixMatches)
                {
                    list.Add(new DynaXmlNamespaceMapping(prefix.Key, prefix.Value));
                }
                return list;
            }
        }

        /// <summary>
        /// Indexer that returns the xmlNamespace for a give prefix.
        /// </summary>
        /// <param name="prefix">The prefix for which to return the xmlNamespaceUri.</param>
        /// <returns>The xmlNamespace for this prefix.</returns>
        public string this[string prefix]
        {
            get { return this.GetNamespaceForPrefix(prefix); }
        }

        /// <summary>
        /// Returns the namespaceUri for a given prefix.
        /// </summary>
        /// <param name="prefix">The prefix for which to return the xmlNamespaceUri.</param>
        /// <returns>The xmlNamespace for this prefix.</returns>
        public string GetNamespaceForPrefix(string prefix)
        {
            string retval;
            this.PrefixMatches.TryGetValue(prefix, out retval);
            return retval;
        }

        /// <summary>
        /// Returns the set of prefixes for a given namespaceUri.
        /// </summary>
        /// <param name="xmlNamespace">The xmlNamespaceUri for which to return the prefixes.</param>
        /// <returns>The prefixes defined for this xmlNamespaceUri.</returns>
        public IEnumerable<string> GetPrefixesForNamespace(string xmlNamespace)
        {
            IEnumerable<string> retval;
            this.NamespaceMatches.TryGetValue(xmlNamespace, out retval);
            return retval;
        }
    }
}
