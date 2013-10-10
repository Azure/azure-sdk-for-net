// -----------------------------------------------------------------------------------------
// <copyright file="TableConstants.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Test.Network
{

    using System.Xml.Linq;

    /// <summary>
    /// Constants that are well-known in XTable
    /// </summary>
    public static class TableConstants
    {
        /// <summary>
        /// The ADO.NET (OData) namespace
        /// </summary>
        public static readonly XNamespace OData = "http://schemas.microsoft.com/ado/2007/08/dataservices";

        /// <summary>
        /// OData metadata
        /// </summary>

        public static readonly XNamespace Metadata = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";

        /// <summary>
        /// Root namespace for Atom content
        /// </summary>
        public static readonly XNamespace Atom = "http://www.w3.org/2005/Atom";

        /// <summary>
        /// Entry element
        /// </summary>
        public static readonly XElement Entry = new XElement(Atom + "entry", 
            new XAttribute(XNamespace.Xmlns + "d", OData.NamespaceName),
            new XAttribute(XNamespace.Xmlns + "m", Metadata.NamespaceName),
            new XAttribute("xmlns", Atom.NamespaceName));

        /// <summary>
        /// Title element
        /// </summary>
        public static readonly XElement Title = new XElement(Atom + "title", new XAttribute("type", "text"));

        /// <summary>
        /// Author element
        /// </summary>
        public static readonly XElement Author = new XElement(Atom + "author", new XElement(Atom + "name"));

        /// <summary>
        /// Content element
        /// </summary>
        public static readonly XElement Content = new XElement(Atom + "content", new XAttribute("type", "application/xml"));

        /// <summary>
        /// Properties element
        /// </summary>
        public static readonly XElement Properties = new XElement(Metadata + "properties");

        /// <summary>
        /// Version string
        /// </summary>
        public const string XMsVersion = "2009-09-19";

        /// <summary>
        /// GetEntry returns a new Entry element
        /// </summary>
        /// <param name="base">The value of the xml:base attribute</param>
        /// <returns>A new XElement</returns>
        public static XElement GetEntry(string @base)
        {
            XElement element = new XElement(Entry);
            element.SetAttributeValue(XNamespace.Xml + "base", @base);
            return element;
        }

        /// <summary>
        /// GetCategory returns the category element of an atom feed
        /// </summary>
        /// <param name="term">The term to use</param>
        /// <returns>A new XElement</returns>
        public static XElement GetCategory(string term)
        {
            return new XElement(Atom + "category", 
                new XAttribute("term", term), 
                new XAttribute("scheme", "http://schemas.microsoft.com/ado/2007/08/dataservices/scheme"));
        }

        /// <summary>
        /// GetError retuns the error element of an Azure Storage error
        /// </summary>
        /// <param name="code">The code to return</param>
        /// <param name="message">The message to return</param>
        /// <returns>A new XElement</returns>
        public static XElement GetError(string code, string message)
        {
            return new XElement(Metadata + "error",
                new XAttribute("xmlns", Metadata.NamespaceName),
                new XElement(Metadata + "code", code),
                new XElement(Metadata + "message",
                    new XAttribute(XNamespace.Xml + "lang", "en-US"),
                    message));
        }

        /// <summary>
        /// GetLink returns the link element for a table entry.
        /// </summary>
        /// <param name="tableName">The referenced table</param>
        /// <returns>A new XElement</returns>
        public static XElement GetLink(string tableName)
        {
            return new XElement(
                Atom + "link",
                new XAttribute("rel", "edit"),
                new XAttribute("title", "Tables"),
                new XAttribute("href", string.Format("Tables('{0}')", tableName)));
        }

        /// <summary>
        /// GetProperty returns an OData property.
        /// </summary>
        /// <param name="name">The property name</param>
        /// <param name="value">The property value</param>
        /// <returns>A new XElement</returns>
        public static XElement GetProperty(string name, string value)
        {
            return new XElement(OData + name, value);
        }
    }
}
