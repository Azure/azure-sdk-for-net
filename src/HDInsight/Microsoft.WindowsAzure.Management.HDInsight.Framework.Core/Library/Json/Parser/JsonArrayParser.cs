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
    using System.Collections.Generic;

    /// <summary>
    /// Parses a Json Array.
    /// </summary>
#if Non_Public_SDK
    public class JsonArrayParser : JsonParserBase, IJsonParser
#else
    internal class JsonArrayParser : JsonParserBase, IJsonParser
#endif
    {
        private enum JsonArrayParseState
        {
            Start,
            Value,
            Seperator,
            End,
        }

        private JsonArrayParseState state = JsonArrayParseState.Start;

        /// <summary>
        /// Initializes a new instance of the JsonArrayParser class.
        /// </summary>
        /// <param name="buffer">
        /// The parser buffer used to conduct parsing.
        /// </param>
        public JsonArrayParser(ParseBuffer buffer)
            : base(buffer)
        {
        }

        /// <inheritdoc />
        protected override JsonParseType ParseType
        {
            get { return JsonParseType.Array; }
        }

        /// <inheritdoc />
        public JsonItem ParseNext()
        {
            List<JsonItem> items = new List<JsonItem>();
            JsonItem item;
            this.state = JsonArrayParseState.Start;
            while (this.state != JsonArrayParseState.End)
            {
                switch (this.state)
                {
                    case JsonArrayParseState.Start:
                        if (this.Consume('['))
                        {
                            this.state = JsonArrayParseState.Value;
                            new JsonWhiteSpaceParser(JsonParseType.Array, this.Buffer).ParseNext();
                        }
                        else
                        {
                            return this.MakeError('[');
                        }
                        break;
                    case JsonArrayParseState.Value:
                        if (this.Consume(']'))
                        {
                            this.state = JsonArrayParseState.End;
                        }
                        else
                        {
                            item = new JsonValueParser(this.Buffer).ParseNext();
                            if (item.IsError)
                            {
                                return item;
                            }
                            items.Add(item);
                            new JsonWhiteSpaceParser(JsonParseType.Array, this.Buffer).ParseNext();
                            this.state = JsonArrayParseState.Seperator;
                        }
                        break;
                    case JsonArrayParseState.Seperator:
                        if (this.Consume(','))
                        {
                            new JsonWhiteSpaceParser(JsonParseType.Array, this.Buffer).ParseNext();
                            this.state = JsonArrayParseState.Value;
                        }
                        else if (this.Consume(']'))
                        {
                            this.state = JsonArrayParseState.End;
                        }
                        else
                        {
                            return this.MakeError(',', ']');
                        }
                        break;
                }
            }
            return new JsonArray(items);
        }
    }
}
