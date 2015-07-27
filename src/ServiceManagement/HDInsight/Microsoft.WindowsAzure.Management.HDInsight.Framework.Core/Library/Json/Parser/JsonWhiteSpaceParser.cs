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
    /// Used to parse Json Whitespace.  This consumes all irrelevant white space 
    /// until the next valid character.
    /// </summary>
#if Non_Public_SDK
    public class JsonWhiteSpaceParser : JsonParserBase, IJsonParser
#else
    internal class JsonWhiteSpaceParser : JsonParserBase, IJsonParser
#endif
    {
        private static readonly char[] WhiteSpace = new char[] { ' ', '\t', '\n', '\r' };
        private JsonParseType parseType;

        /// <summary>
        /// Initializes a new instance of the JsonWhiteSpaceParser class.
        /// </summary>
        /// <param name="parseType">
        /// The type of object that was being parsed.
        /// </param>
        /// <param name="buffer">
        /// The parser buffer used to conduct parsing.
        /// </param>
        public JsonWhiteSpaceParser(JsonParseType parseType, ParseBuffer buffer)
            : base(buffer)
        {
            this.parseType = parseType;
        }

        /// <inheritdoc />
        public JsonItem ParseNext()
        {
            while (this.Consume(WhiteSpace))
            {
            }
            return JsonNull.Singleton;
        }

        /// <inheritdoc />
        protected override JsonParseType ParseType
        {
            get { return this.parseType; }
        }
    }
}
