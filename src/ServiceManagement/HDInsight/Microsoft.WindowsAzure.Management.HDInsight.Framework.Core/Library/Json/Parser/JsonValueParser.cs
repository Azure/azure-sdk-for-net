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
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json.Parser
{
    /// <summary>
    /// Parses a Json Value.
    /// </summary>
#if Non_Public_SDK
    public class JsonValueParser : JsonParserBase, IJsonParser
#else
    internal class JsonValueParser : JsonParserBase, IJsonParser
#endif
    {
        private static readonly char[] NumberStart = new char[] { '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        /// <summary>
        /// Initializes a new instance of the JsonValueParser class.
        /// </summary>
        /// <param name="buffer">
        /// The parser buffer used to conduct parsing.
        /// </param>
        public JsonValueParser(ParseBuffer buffer)
            : base(buffer)
        {
        }

        /// <inheritdoc />
        public JsonItem ParseNext()
        {
            if (this.Peek('"'))
            {
                return new JsonStringParser(this.Buffer).ParseNext();
            }
            if (this.Peek(NumberStart))
            {
                return new JsonNumberParser(this.Buffer).ParseNext();
            }
            if (this.Peek('['))
            {
                return new JsonArrayParser(this.Buffer).ParseNext();
            }
            if (this.Peek('{'))
            {
                return new JsonObjectParser(this.Buffer).ParseNext();
            }
            if (this.Peek('t', 'f'))
            {
                return new JsonBooleanParser(this.Buffer).ParseNext();
            }
            if (this.Peek('n'))
            {
                return new JsonNullParser(this.Buffer).ParseNext();
            }
            return this.MakeError('"', '[', '{', 't', 'f', 'n');
        }

        /// <inheritdoc />
        protected override JsonParseType ParseType
        {
            get { return JsonParseType.Value; }
        }
    }
}
