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
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Used to parse a Json Number.
    /// </summary>
#if Non_Public_SDK
    public class JsonNumberParser : JsonParserBase, IJsonParser
#else
    internal class JsonNumberParser : JsonParserBase, IJsonParser
#endif
    {
        private static readonly char[] Numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        private enum JsonNumberParseState
        {
            Start,
            Neg,
            Digit,
            Decimal,
            ExpSign,
            Exp,
            ExpValue,
            End
        }

        private JsonNumberParseState state = JsonNumberParseState.Start;

        private StringBuilder stringBuilder = new StringBuilder();

        /// <summary>
        /// Initializes a new instance of the JsonNumberParser class.
        /// </summary>
        /// <param name="buffer">
        /// The parser buffer used to conduct parsing.
        /// </param>
        public JsonNumberParser(ParseBuffer buffer)
            : base(buffer)
        {
        }

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json.Parser.JsonParserBase.MakeError(System.String)",
            Justification = "Acceptable here as this represents an error condition. [tgs]")]
        public JsonItem ParseNext()
        {
            this.state = JsonNumberParseState.Start;
            while (this.state != JsonNumberParseState.End)
            {
                switch (this.state)
                {
                    case JsonNumberParseState.Start:
                        if (this.Consume(Numbers))
                        {
                            this.stringBuilder.Append(this.OutChar);
                            this.state = JsonNumberParseState.Digit;
                        }
                        else if (this.Consume('-'))
                        {
                            this.stringBuilder.Append(this.OutChar);
                            this.state = JsonNumberParseState.Neg;
                        }
                        else
                        {
                            return this.MakeError(Numbers, '-');
                        }
                        break;
                    case JsonNumberParseState.Neg:
                        if (this.Consume(Numbers))
                        {
                            this.stringBuilder.Append(this.OutChar);
                            this.state = JsonNumberParseState.Digit;
                        }
                        else
                        {
                            return this.MakeError(Numbers);
                        }
                        break;
                    case JsonNumberParseState.Digit:
                        if (this.Consume(Numbers))
                        {
                            this.stringBuilder.Append(this.OutChar);
                        }
                        else if (this.Consume('.'))
                        {
                            this.stringBuilder.Append(this.OutChar);
                            this.state = JsonNumberParseState.Decimal;
                        }
                        else if (this.Consume('e', 'E'))
                        {
                            this.stringBuilder.Append(this.OutChar);
                            this.state = JsonNumberParseState.ExpSign;
                        }
                        else
                        {
                            this.state = JsonNumberParseState.End;
                        }
                        break;
                    case JsonNumberParseState.Decimal:
                        if (this.Consume(Numbers))
                        {
                            this.stringBuilder.Append(this.OutChar);
                        }
                        else if (this.Consume('e', 'E'))
                        {
                            this.stringBuilder.Append(this.OutChar);
                            this.state = JsonNumberParseState.ExpSign;
                        }
                        else
                        {
                            this.state = JsonNumberParseState.End;
                        }
                        break;
                    case JsonNumberParseState.ExpSign:
                        if (this.Consume('+', '-'))
                        {
                            this.stringBuilder.Append(this.OutChar);
                            this.state = JsonNumberParseState.Exp;
                        }
                        else if (this.Consume(Numbers))
                        {
                            this.stringBuilder.Append(this.OutChar);
                            this.state = JsonNumberParseState.ExpValue;
                        }
                        else
                        {
                            return this.MakeError(Numbers, '+', '-');
                        }
                        break;
                    case JsonNumberParseState.Exp:
                        if (this.Consume(Numbers))
                        {
                            this.stringBuilder.Append(this.OutChar);
                            this.state = JsonNumberParseState.ExpValue;
                        }
                        else
                        {
                            return this.MakeError(Numbers);
                        }
                        break;
                    case JsonNumberParseState.ExpValue:
                        if (this.Consume(Numbers))
                        {
                            this.stringBuilder.Append(this.OutChar);
                        }
                        else
                        {
                            this.state = JsonNumberParseState.End;
                        }
                        break;
                }
            }
            long asLong;
            double asDouble;
            var str = this.stringBuilder.ToString();
            if (long.TryParse(str, out asLong))
            {
                return new JsonInteger(asLong);
            }
            if (this.TryParse(str, out asDouble))
            {
                return new JsonFloat(asDouble);
            }
            return this.MakeError("the supplied number could not be parsed into a numerical value acceptable to the runtime.");
        }

        private bool TryParse(string str, out double asDouble)
        {
            asDouble = 0;
            var parts = str.Split('e', 'E');
            if (parts.Length > 1)
            {
                long asLong;
                if (long.TryParse(parts[1], out asLong))
                {
                    if (asLong >= -324 && asLong <= 308)
                    {
                        if (double.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out asDouble))
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                if (double.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out asDouble))
                {
                    return true;
                }
            }
            return false;
        }

        /// <inheritdoc />
        protected override JsonParseType ParseType
        {
            get { return JsonParseType.Number; }
        }
    }
}
