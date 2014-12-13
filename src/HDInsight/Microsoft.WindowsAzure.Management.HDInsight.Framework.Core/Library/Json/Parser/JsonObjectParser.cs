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
    /// Parses a Json object (class).
    /// </summary>
#if Non_Public_SDK
    public class JsonObjectParser : JsonParserBase, IJsonParser
#else
    internal class JsonObjectParser : JsonParserBase, IJsonParser
#endif
    {
        private enum JsonObjectParseState
        {
            Start,
            PropertyName,
            KeyValueSperator,
            Value,
            PropertySetSeperator,
            End
        }

        private JsonObjectParseState state = JsonObjectParseState.Start;

        /// <summary>
        /// Initializes a new instance of the JsonObjectParser class.
        /// </summary>
        /// <param name="buffer">
        /// The parser buffer used to conduct parsing.
        /// </param>
        public JsonObjectParser(ParseBuffer buffer)
            : base(buffer)
        {
        }

        /// <inheritdoc />
        public JsonItem ParseNext()
        {
            JsonString propertyName = null;
            string propertyNameAsString;
            IDictionary<string, JsonItem> propertyBag = new Dictionary<string, JsonItem>();
            this.state = JsonObjectParseState.Start;
            while (this.state != JsonObjectParseState.End)
            {
                JsonItem item = null;
                switch (this.state)
                {
                    case JsonObjectParseState.Start:
                        if (this.Consume('{'))
                        {
                            this.state = JsonObjectParseState.PropertyName;
                            new JsonWhiteSpaceParser(JsonParseType.Object, this.Buffer).ParseNext();
                        }
                        else
                        {
                            return this.MakeError('{');
                        }
                        break;
                    case JsonObjectParseState.PropertyName:
                        if (this.Peek('"'))
                        {
                            item = new JsonStringParser(this.Buffer).ParseNext();
                            if (item.IsString)
                            {
                                propertyName = (JsonString)item;
                            }
                            else
                            {
                                return item;
                            }
                            new JsonWhiteSpaceParser(JsonParseType.Object, this.Buffer).ParseNext();
                            this.state = JsonObjectParseState.KeyValueSperator;
                        }
                        else if (this.Consume('}'))
                        {
                            new JsonWhiteSpaceParser(JsonParseType.Object, this.Buffer).ParseNext();
                            this.state = JsonObjectParseState.End;
                        }
                        else
                        {
                            return this.MakeError('"');
                        }
                        break;
                    case JsonObjectParseState.KeyValueSperator:
                        if (this.Consume(':'))
                        {
                            new JsonWhiteSpaceParser(JsonParseType.Object, this.Buffer).ParseNext();
                            this.state = JsonObjectParseState.Value;
                        }
                        else
                        {
                            return this.MakeError(':');
                        }
                        break;
                    case JsonObjectParseState.Value:
                        item = new JsonValueParser(this.Buffer).ParseNext();
                        if (item.IsError)
                        {
                            return item;
                        }
                        propertyName.TryGetValue(out propertyNameAsString);
                        propertyBag.Add(propertyNameAsString, item);
                        new JsonWhiteSpaceParser(JsonParseType.Object, this.Buffer).ParseNext();
                        this.state = JsonObjectParseState.PropertySetSeperator;
                        break;
                    case JsonObjectParseState.PropertySetSeperator:
                        if (this.Consume(','))
                        {
                            new JsonWhiteSpaceParser(JsonParseType.Object, this.Buffer).ParseNext();
                            this.state = JsonObjectParseState.PropertyName;
                        }
                        else if (this.Consume('}'))
                        {
                            new JsonWhiteSpaceParser(JsonParseType.Object, this.Buffer).ParseNext();
                            this.state = JsonObjectParseState.End;
                        }
                        else
                        {
                            return this.MakeError(',');
                        }
                        break;
                }
            }
            return new JsonObject(propertyBag);
        }

        /// <inheritdoc />
        protected override JsonParseType ParseType
        {
            get { return JsonParseType.Object; }
        }
    }
}
