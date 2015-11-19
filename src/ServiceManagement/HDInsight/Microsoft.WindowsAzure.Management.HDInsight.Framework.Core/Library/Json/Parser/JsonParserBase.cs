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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Base class for Json parsers.
    /// </summary>
#if Non_Public_SDK
    public abstract class JsonParserBase 
#else
    internal abstract class JsonParserBase
#endif
    {
        /// <summary>
        /// Gets the parser buffer.
        /// </summary>
        protected ParseBuffer Buffer { get; private set; }

        private int startLocation;

        /// <summary>
        /// Gets the character that was most recently parsed.
        /// </summary>
        protected char OutChar { get; private set; }

        /// <summary>
        /// Gets the type of JsonItem currently being parsed.
        /// </summary>
        protected abstract JsonParseType ParseType { get; }

        /// <summary>
        /// Disposes of the internal buffer.
        /// </summary>
        protected void DisposeBuffer()
        {
            this.Buffer.Dispose();
            this.Buffer = null;
        }

        /// <summary>
        /// Initializes a new instance of the JsonParserBase class.
        /// </summary>
        /// <param name="buffer">
        /// The parser buffer used to conduct parsing.
        /// </param>
        protected JsonParserBase(ParseBuffer buffer)
        {
            if (ReferenceEquals(buffer, null))
            {
                throw new ArgumentNullException("buffer");
            }
            this.Buffer = buffer;
            this.startLocation = buffer.Location;
        }

        /// <summary>
        /// Gets a value indicating whether the buffer has reached the end of the stream.
        /// </summary>
        protected bool EndOfStream
        {
            get { return this.Buffer.EndOfStream; }
        }

        /// <summary>
        /// Consumes the next character off of the stream if it matches one of the
        /// expected characters (otherwise the character stays on the stream).
        /// </summary>
        /// <param name="expects">
        /// The set of expected characters.
        /// </param>
        /// <returns>
        /// True if the next character was one of the expected and was consumed, otherwise false.
        /// </returns>
        protected bool Consume(params char[] expects)
        {
            char readChar;
            if (this.Buffer.Consume(out readChar, expects))
            {
                this.OutChar = readChar;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the next character off the stream.
        /// </summary>
        /// <returns>
        /// true if there was a character to remove.
        /// </returns>
        protected bool Pop()
        {
            char readChar;
            if (this.Buffer.PopNext(out readChar))
            {
                this.OutChar = readChar;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Peeks the next character but keeps it on the stream.
        /// </summary>
        /// <param name="expects">
        /// The set of expected characters.
        /// </param>
        /// <returns>
        /// True if the next character was one of the expected.
        /// </returns>
        protected bool Peek(params char[] expects)
        {
            char readChar;
            if (this.Buffer.Peek(out readChar, expects))
            {
                this.OutChar = readChar;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Creates a parser error specifying that one of the set of characters were expected but a different character was found.
        /// </summary>
        /// <param name="expected">
        /// The set of the next characters that were expected but not found.
        /// </param>
        /// <returns>
        /// A parser error.
        /// </returns>
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json.JsonParseError.#ctor(Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json.JsonParseType,System.Int32,System.Int32,System.String)",
            Justification = "Acceptable here as this represents an error condition. [tgs]")]
        protected JsonParseError MakeError(params char[] expected)
        {
            var charParts = (from e in expected select "'" + e + "'").ToList();
            string messagePart = string.Join(", ", charParts);
            var msg = string.Format(CultureInfo.InvariantCulture, "Expected {0}; instead received '{1}'.", messagePart, this.OutChar);
            return new JsonParseError(this.ParseType, this.startLocation, this.Buffer.Location, msg);
        }

        /// <summary>
        /// Creates a parser error specifying that one of the two sets of characters were expected but a different character was found.
        /// </summary>
        /// <param name="baseExpected">
        /// The set of the next characters that were expected but not found.
        /// </param>
        /// <param name="additionalExpected">
        /// An additional set of expected values.
        /// </param>
        /// <returns>
        /// A parser error.
        /// </returns>
        protected JsonParseError MakeError(char[] baseExpected, params char[] additionalExpected)
        {
            List<char> expected = new List<char>();
            expected.AddRange(baseExpected);
            expected.AddRange(additionalExpected);
            return this.MakeError(expected.ToArray());
        }

        /// <summary>
        /// Creates a parser error specifying that one of the set of characters were expected but the end of stream was found.
        /// </summary>
        /// <param name="expected">
        /// The set of the next characters that were expected but not found.
        /// </param>
        /// <returns>
        /// A parser error.
        /// </returns>
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json.JsonParseError.#ctor(Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json.JsonParseType,System.Int32,System.Int32,System.String)",
            Justification = "Acceptable here as this represents an error condition. [tgs]")]
        protected JsonParseError MakeEosError(params char[] expected)
        {
            var charParts = (from e in expected select "'" + e + "'").ToList();
            string messagePart = string.Join(", ", charParts);
            var msg = string.Format(CultureInfo.InvariantCulture, "Expected {0}; instead received 'end of stream'.", messagePart);
            return new JsonParseError(this.ParseType, this.startLocation, this.Buffer.Location, msg);
        }

        /// <summary>
        /// Creates a parser error specifying that one of the two sets of characters were expected but the end of stream was found.
        /// </summary>
        /// <param name="baseExpected">
        /// The set of the next characters that were expected but not found.
        /// </param>
        /// <param name="additionalExpected">
        /// An additional set of expected values.
        /// </param>
        /// <returns>
        /// A parser error.
        /// </returns>
        protected JsonParseError MakeEosError(char[] baseExpected, params char[] additionalExpected)
        {
            List<char> expected = new List<char>();
            expected.AddRange(baseExpected);
            expected.AddRange(additionalExpected);
            return this.MakeEosError(expected.ToArray());
        }

        /// <summary>
        /// Creates a parser error allowing the caller to provide the nature of the error.
        /// </summary>
        /// <param name="message">
        /// A message that describes the nature of the error.
        /// </param>
        /// <returns>
        /// A parser error.
        /// </returns>
        protected JsonParseError MakeError(string message)
        {
            return new JsonParseError(this.ParseType, this.startLocation, this.Buffer.Location, message);
        }
    }
}
