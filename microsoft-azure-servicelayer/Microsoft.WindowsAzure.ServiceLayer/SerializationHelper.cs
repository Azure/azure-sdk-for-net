//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

using Windows.Data.Xml.Dom;
using Windows.Web.Syndication;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    /// <summary>
    /// Serialization/deserialization helper.
    /// </summary>
    static internal class SerializationHelper
    {
        /// <summary>
        /// Deserializes the feed into a collection of items of the same type.
        /// </summary>
        /// <typeparam name="T">Type of result items in the collection.</typeparam>
        /// <param name="feed">Atom feed with serialized items.</param>
        /// <param name="itemAction">Additional action to perform on each item.</param>
        /// <param name="extraTypes">Extra types for deserialization.</param>
        /// <returns>Collection of deserialized items.</returns>
        internal static IEnumerable<T> DeserializeCollection<T>(SyndicationFeed feed, Action<SyndicationItem, T> itemAction, IEnumerable<Type> extraTypes)
        {
            Debug.Assert(extraTypes != null);
            DataContractSerializer serializer = new DataContractSerializer(typeof(T), extraTypes);
            return feed.Items.Select(item => DeserializeItem<T>(serializer, item, itemAction));
        }

        /// <summary>
        /// Deserializes an atom item.
        /// </summary>
        /// <typeparam name="T">Target object type.</typeparam>
        /// <param name="item">Atom item to deserialize.</param>
        /// <param name="itemAction">Action to perform after deserialization.</param>
        /// <param name="extraTypes">Extra types for deserialization.</param>
        /// <returns>Deserialized object.</returns>
        internal static T DeserializeItem<T>(SyndicationItem item, Action<SyndicationItem, T> itemAction, IEnumerable<Type> extraTypes)
        {
            Debug.Assert(extraTypes != null);
            return DeserializeItem<T>(new DataContractSerializer(typeof(T), extraTypes), item, itemAction);
        }

        /// <summary>
        /// Deserializes an atom item using given serializer.
        /// </summary>
        /// <typeparam name="T">Target object type.</typeparam>
        /// <param name="serializer">Serializer.</param>
        /// <param name="item">Atom item.</param>
        /// <param name="itemAction">Action to perform after deserialization.</param>
        /// <returns>Deserialized object.</returns>
        private static T DeserializeItem<T>(DataContractSerializer serializer, SyndicationItem item, Action<SyndicationItem, T> itemAction)
        {
            string serializedString = item.Content.Xml.GetXml();

            using (StringReader stringReader = new StringReader(serializedString))
            {
                XmlReader xmlReader = XmlReader.Create(stringReader);
                T deserializedObject = (T)serializer.ReadObject(xmlReader);
                itemAction(item, deserializedObject);

                return deserializedObject;
            }
        }

        /// <summary>
        /// Serializes given object.
        /// </summary>
        /// <param name="item">Object to serialize.</param>
        /// <param name="knownTypes">List of supported types</param>
        /// <returns>Serialized representation.</returns>
        internal static string Serialize(object item, params Type[] knownTypes)
        {
            // Serialize the content
            string itemXml;

            using (MemoryStream stream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(item.GetType(), knownTypes);
                serializer.WriteObject(stream, item);

                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                StreamReader reader = new StreamReader(stream);
                itemXml = reader.ReadToEnd();
            }

            // Turn serialized content into an atom entry.
            SyndicationContent content = new SyndicationContent();
            content.Type = Constants.SerializationContentType;
            content.Xml = new XmlDocument();
            content.Xml.LoadXml(itemXml);

            SyndicationItem entry = new SyndicationItem();
            entry.Content = content; 

            return entry.GetXmlDocument(SyndicationFormat.Atom10).GetXml();
        }
    }
}
