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
    /// Parses a Boolean value in Json.
    /// </summary>
#if Non_Public_SDK
    public class JsonBooleanParser : JsonParserBase, IJsonParser
#else
    internal class JsonBooleanParser : JsonParserBase, IJsonParser
#endif
    {
        /// <summary>
        /// Initializes a new instance of the JsonBooleanParser class.
        /// </summary>
        /// <param name="buffer">
        /// The parser buffer used to conduct parsing.
        /// </param>
        public JsonBooleanParser(ParseBuffer buffer)
            : base(buffer)
        {
        }

        /// <inheritdoc />
        protected override JsonParseType ParseType
        {
            get { return JsonParseType.Boolean; }
        }

        /// <inheritdoc />
        public JsonItem ParseNext()
        {
            if (this.Consume('t'))
            {
                if (this.Consume('r'))
                {
                    if (this.Consume('u'))
                    {
                        if (this.Consume('e'))
                        {
                            return new JsonBoolean(true);
                        }
                        return this.MakeError('e');
                    }
                    return this.MakeError('u');
                }
                return this.MakeError('r');
            }
            if (this.Consume('f'))
            {
                if (this.Consume('a'))
                {
                    if (this.Consume('l'))
                    {
                        if (this.Consume('s'))
                        {
                            if (this.Consume('e'))
                            {
                                return new JsonBoolean(false);
                            }
                            return this.MakeError('e');
                        }
                        return this.MakeError('s');
                    }
                    return this.MakeError('l');
                }
                return this.MakeError('a');
            }
            return this.MakeError('t', 'f');
        }
    }
}
