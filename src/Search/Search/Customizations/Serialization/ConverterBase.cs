// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Serialization
{
    /// <summary>
    /// Base class for custom JsonConverters.
    /// </summary>
    internal abstract class ConverterBase : JsonConverter
    {
        protected void ExpectAndAdvance(JsonReader reader, JsonToken expectedToken, object expectedValue = null)
        {
            ExpectAndAdvance<object>(reader, expectedToken, expectedValue);
        }

        protected TValue ExpectAndAdvance<TValue>(JsonReader reader, JsonToken expectedToken, object expectedValue = null)
        {
            TValue result = Expect<TValue>(reader, expectedToken, expectedValue);
            Advance(reader);
            return result;
        }

        protected void Expect(JsonReader reader, JsonToken expectedToken, object expectedValue = null)
        {
            Expect<object>(reader, expectedToken, expectedValue);
        }

        protected TValue Expect<TValue>(JsonReader reader, JsonToken expectedToken, object expectedValue = null)
        {
            if (reader.TokenType != expectedToken)
            {
                throw new JsonSerializationException(
                    String.Format("Deserialization failed. Expected token: '{0}'", expectedToken));
            }

            if (expectedValue != null && !reader.Value.Equals(expectedValue))
            {
                string message =
                    String.Format(
                        "Deserialization failed. Expected value: '{0}'. Actual: '{1}'",
                        expectedValue,
                        reader.Value);

                throw new JsonSerializationException(message);
            }

            TValue result = default(TValue);

            if (reader.Value != null)
            {
                if (!typeof(TValue).IsAssignableFrom(reader.ValueType))
                {
                    string message =
                        String.Format(
                            "Deserialization failed. Value '{0}' is not of expected type '{1}'.",
                            reader.Value,
                            typeof(TValue));

                    throw new JsonSerializationException(message);
                }

                result = (TValue)reader.Value;
            }

            return result;
        }

        protected void Advance(JsonReader reader)
        {
            if (!reader.Read())
            {
                throw new JsonSerializationException("Deserialization failed. Unexpected end of input.");
            }
        }
    }
}
