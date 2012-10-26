//-----------------------------------------------------------------------
// <copyright file="General.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using Microsoft.WindowsAzure.Storage;

    /// <summary>
    /// General class that provides helper methods for XML processing and lazy execution of segmented results.
    /// </summary>
    internal class General
    {
        /// <summary>
        /// Read the value of an element in the XML.
        /// </summary>
        /// <param name="elementName">The name of the element whose value is retrieved.</param>
        /// <param name="reader">A reader that provides access to XML data.</param>
        /// <returns>A string representation of the element's value.</returns>
        internal static string ReadElementAsString(string elementName, XmlReader reader)
        {
            string res = null;

            reader.ReadStartElement(elementName);
            if (reader.NodeType == XmlNodeType.Text)
            {
                res = reader.ReadContentAsString();
                reader.ReadEndElement();
            }
            else
            {
                reader.Read();
            }

            SkipWhitespace(reader);

            return res;
        }

        /// <summary>
        /// Skip white spaces.
        /// </summary>
        /// <param name="reader">A reader that provides access to XML data.</param>
        internal static void SkipWhitespace(XmlReader reader)
        {
            while (reader.NodeType == XmlNodeType.Whitespace)
            {
                reader.Read();
            }
        }

        /// <summary>
        /// Returns an enumerable collection of results that is retrieved lazily.
        /// </summary>
        /// <typeparam name="T">The type of ResultSegment like Blob, Container, Queue and Table.</typeparam>
        /// <param name="segmentGenerator">The segment generator.</param>
        /// <param name="maxResults">>A non-negative integer value that indicates the maximum number of results to be returned 
        /// in the result segment, up to the per-operation limit of 5000.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns></returns>
        internal static IEnumerable<T> LazyEnumerable<T>(Func<IContinuationToken, ResultSegment<T>> segmentGenerator, long maxResults, OperationContext operationContext)
        {
            ResultSegment<T> currentSeg = segmentGenerator(null);
            long count = 0;
            while (true)
            {
                foreach (var result in currentSeg.Results)
                {
                    yield return result;
                    count++;
                    if (count >= maxResults)
                    {
                        break;
                    }
                }

                if (count >= maxResults)
                {
                    break;
                }

                if (currentSeg.ContinuationToken != null)
                {
                    currentSeg = segmentGenerator(currentSeg.ContinuationToken);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
