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
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Used to buffer input for parsing applications.
    /// </summary>
#if Non_Public_SDK
    public class ParseBuffer : DisposableObject
#else
    internal class ParseBuffer : DisposableObject
#endif
    {
        private Queue<char> queue = new Queue<char>();
        private StreamReader reader;
        private int queueLocation;

        /// <summary>
        /// Gets the current location of the next character in the buffer.
        /// </summary>
        public int Location
        {
            get { return this.queueLocation; }
        }

        /// <summary>
        /// Initializes a new instance of the ParseBuffer class.
        /// </summary>
        /// <param name="input">
        /// The Json Content to parse (UTF8 Encoded).
        /// </param>
        public ParseBuffer(Stream input)
            : this(input, Encoding.UTF8)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ParseBuffer class.
        /// </summary>
        /// <param name="input">
        /// The Json Content to parse (Encoded per encoding).
        /// </param>
        /// <param name="encoding">
        /// The encoding to use to read the stream.
        /// </param>
        public ParseBuffer(Stream input, Encoding encoding)
        {
            this.Initialize(input, encoding);
        }

        private void Initialize(Stream input, Encoding encoding)
        {
            this.reader = new StreamReader(input, encoding);
        }

        /// <summary>
        /// Gets a value indicating whether the buffer has reached the end of the stream.
        /// </summary>
        public bool EndOfStream
        {
            get
            {
                return this.queue.Count == 0 && this.reader.EndOfStream;
            }
        }

        /// <summary>
        /// Initializes a new instance of the ParseBuffer class.
        /// </summary>
        /// <param name="input">
        /// The Json Content to parse.
        /// </param>
        public ParseBuffer(string input)
        {
            var stream = Help.SafeCreate<MemoryStream>();
            using (Stream local = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(local, Encoding.UTF8))
            {
                writer.Write(input);
                writer.Flush();
                local.Flush();
                local.Position = 0;
                local.CopyTo(stream);
                stream.Position = 0;
            }
            this.Initialize(stream, Encoding.UTF8);
        }

        private bool Enque()
        {
            if (!this.reader.EndOfStream)
            {
                char[] buffer = new char[1024];
                var read = this.reader.Read(buffer, 0, 1024);
                for (int i = 0; i < read; i++)
                {
                    this.queue.Enqueue(buffer[i]);
                }
                return read > 0;
            }
            return false;
        }

        /// <summary>
        /// Returns the next character of output if there is one.
        /// </summary>
        /// <param name="output">
        /// The next character in the buffer.
        /// </param>
        /// <returns>
        /// True if there was a character to return otherwise false.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#",
            Justification = "Required for the 'try execute' design of this buffer method.")]
        public bool PeekNext(out char output)
        {
            output = default(char);
            if (this.queue.Count == 0)
            {
                this.Enque();
            }
            if (this.queue.Count > 0)
            {
                output = this.queue.Peek();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the next character of output if there is on.
        /// </summary>
        /// <param name="output">
        /// The next character of output.
        /// </param>
        /// <returns>
        /// True if there was a character to consume otherwise false.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#",
            Justification = "Required for the 'try execute' design of this buffer method.")]
        public bool PopNext(out char output)
        {
            if (this.PeekNext(out output))
            {
                this.queue.Dequeue();
                this.queueLocation++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Consumes the next character in the buffer, it it is one of the 
        /// expected characters.
        /// </summary>
        /// <param name="output">
        /// The character consumed.
        /// </param>
        /// <param name="expects">
        /// The set of expected (allowed) characters.
        /// </param>
        /// <returns>
        /// True if the next character was in the set and consumed otherwise false.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#",
            Justification = "Required for the 'try execute' design of this buffer method.")]
        public bool Consume(out char output, params char[] expects)
        {
            return this.Expects(false, out output, expects);
        }

        /// <summary>
        /// Returns the next character in the buffer, it it is one of the 
        /// expected characters.
        /// </summary>
        /// <param name="output">
        /// The character found.
        /// </param>
        /// <param name="expects">
        /// The set of expected (allowed) characters.
        /// </param>
        /// <returns>
        /// True if the next character was in the set and returned otherwise false.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#",
            Justification = "Required for the 'try execute' design of this buffer method.")]
        public bool Peek(out char output, params char[] expects)
        {
            return this.Expects(true, out output, expects);
        }

        private bool Expects(bool keep, out char output, params char[] expectChars)
        {
            if (this.PeekNext(out output))
            {
                if (expectChars.Contains(output))
                {
                    if (keep)
                    {
                        return true;
                    }
                    this.queue.Dequeue();
                    this.queueLocation++;
                    return true;
                }
            }
            return false;
        }
    }
}
