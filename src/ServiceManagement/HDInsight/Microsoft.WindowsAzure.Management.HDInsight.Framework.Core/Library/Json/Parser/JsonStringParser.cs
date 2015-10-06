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
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Parses a Json String.
    /// </summary>
#if Non_Public_SDK
    public class JsonStringParser : JsonParserBase, IJsonParser
#else
    internal class JsonStringParser : JsonParserBase, IJsonParser
#endif
    {
        private enum JsonStringParseState
        {
            Start,
            InString,
            Escaping,
            InHex,
            End
        }

        private JsonStringParseState state = JsonStringParseState.Start;

        private StringBuilder stringBuilder = new StringBuilder();

        private static readonly char[] Hex = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'A', 'B', 'C', 'D', 'E', 'F' };

        /// <summary>
        /// Initializes a new instance of the JsonStringParser class.
        /// </summary>
        /// <param name="buffer">
        /// The parser buffer used to conduct parsing.
        /// </param>
        public JsonStringParser(ParseBuffer buffer)
            : base(buffer)
        {
        }

        /// <inheritdoc />
        public JsonItem ParseNext()
        {
            this.state = JsonStringParseState.Start;
            while (this.state != JsonStringParseState.End)
            {
                if (this.Buffer.EndOfStream)
                {
                    this.MakeEosError('\"');
                }
                switch (this.state)
                {
                    case JsonStringParseState.Start:
                        if (this.Consume('"'))
                        {
                            this.state = JsonStringParseState.InString;
                        }
                        else
                        {
                            return this.MakeError('"');
                        }
                        break;
                    case JsonStringParseState.InString:
                        if (this.Consume('\\'))
                        {
                            this.state = JsonStringParseState.Escaping;
                        }
                        else if (this.Consume('"'))
                        {
                            this.state = JsonStringParseState.End;
                        }
                        else if (this.Pop())
                        {
                            this.stringBuilder.Append(this.OutChar);
                        }
                        break;
                    case JsonStringParseState.InHex:
                        ushort value = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            if (this.Consume(Hex))
                            {
                                value <<= 4;
                                value |= ushort.Parse(this.OutChar.ToString(CultureInfo.InvariantCulture), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                return this.MakeError(Hex);
                            }
                        }
                        this.stringBuilder.Append((char)value);
                        this.state = JsonStringParseState.InString;
                        break;
                    case JsonStringParseState.Escaping:
                        if (this.Consume('"', '\\', '/'))
                        {
                            this.state = JsonStringParseState.InString;
                            this.stringBuilder.Append(this.OutChar);
                        }
                        else if (this.Consume('b', 'f', 'n', 'r', 't', 'u'))
                        {
                            switch (this.OutChar)
                            {
                                case 'b':
                                    this.stringBuilder.Append('\b');
                                    this.state = JsonStringParseState.InString;
                                    break;
                                case 'f':
                                    this.stringBuilder.Append('\f');
                                    this.state = JsonStringParseState.InString;
                                    break;
                                case 'n':
                                    this.stringBuilder.Append('\n');
                                    this.state = JsonStringParseState.InString;
                                    break;
                                case 'r':
                                    this.stringBuilder.Append('\r');
                                    this.state = JsonStringParseState.InString;
                                    break;
                                case 't':
                                    this.stringBuilder.Append('\t');
                                    this.state = JsonStringParseState.InString;
                                    break;
                                case 'u':
                                    this.state = JsonStringParseState.InHex;
                                    break;
                            }
                        }
                        else if (this.Pop())
                        {
                            this.stringBuilder.Append(this.OutChar);
                            this.state = JsonStringParseState.InString;
                        }
                        else
                        {
                            return this.MakeError('"', '\\', '/', 'b', 'f', 'n', 'r', 't', 'u');
                        }
                        break;
                }
            }
            return new JsonString(this.stringBuilder.ToString());
        }

        /// <inheritdoc />
        protected override JsonParseType ParseType
        {
            get { return JsonParseType.String; }
        }
    }
}
