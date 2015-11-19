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
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json
{
    using System;
    using System.IO;
    using System.Text;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json.Parser;

    /// <summary>
    /// Represents a JsonParser.
    /// </summary>
#if Non_Public_SDK
    public class JsonParser : JsonParserBase, IJsonParser, IQueryDisposable
#else
    internal class JsonParser : JsonParserBase, IJsonParser, IQueryDisposable
#endif
    {
        private JsonParser(ParseBuffer buffer) : base(buffer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the JsonParser class.
        /// </summary>
        /// <param name="json">
        /// A string containing the Json content to parse.
        /// </param>
        public JsonParser(string json) : this(Help.SafeCreate(() => new ParseBuffer(json)))
        {
        }

        /// <summary>
        /// Initializes a new instance of the JsonParser class.
        /// </summary>
        /// <param name="jsonStream">
        /// A stream containing the Json content to parse.
        /// </param>
        public JsonParser(Stream jsonStream)
            : this(new ParseBuffer(jsonStream))
        {
        }

        /// <summary>
        /// Initializes a new instance of the JsonParser class.
        /// </summary>
        /// <param name="jsonStream">
        /// A string containing the Json content to parse.
        /// </param>
        /// <param name="encoding">
        /// The encoding used for the stream.
        /// </param>
        public JsonParser(Stream jsonStream, Encoding encoding)
            : this(new ParseBuffer(jsonStream, encoding))
        {
        }

        /// <inheritdoc />
        protected override JsonParseType ParseType
        {
            get { return JsonParseType.JsonStream; }
        }

        /// <inheritdoc />
        public JsonItem ParseNext()
        {
            // Consume any opening white space.
            new JsonWhiteSpaceParser(JsonParseType.JsonStream, this.Buffer).ParseNext();
            if (this.Peek('{'))
            {
                return new JsonObjectParser(this.Buffer).ParseNext();
            }
            if (this.Peek('['))
            {
                return new JsonArrayParser(this.Buffer).ParseNext();
            }
            return this.MakeError('{', '[');
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Used to indicate how to dispose of the object.
        /// </summary>
        /// <param name="disposing">
        /// If true dispose of managed objects.  Always dispose
        /// of unmanaged objects.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.DisposeBuffer();
            }
        }

        /// <inheritdoc />
        public bool IsDisposed()
        {
            return this.Buffer == null;
        }
    }
}
