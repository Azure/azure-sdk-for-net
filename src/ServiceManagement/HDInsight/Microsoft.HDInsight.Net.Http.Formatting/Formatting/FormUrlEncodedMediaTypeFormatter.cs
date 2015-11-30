// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting.Parsers;

    /// <summary>
    /// <see cref="MediaTypeFormatter"/> class for handling HTML form URL-ended data, also known as <c>application/x-www-form-urlencoded</c>. 
    /// </summary>
    internal class FormUrlEncodedMediaTypeFormatter : MediaTypeFormatter
    {
        private const int MinBufferSize = 256;
        private const int DefaultBufferSize = 32 * 1024;

        private int _readBufferSize = DefaultBufferSize;
        private int _maxDepth = FormattingUtilities.DefaultMaxDepth;
        private readonly bool _isDerived;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormUrlEncodedMediaTypeFormatter"/> class.
        /// </summary>
        public FormUrlEncodedMediaTypeFormatter()
        {
            this.SupportedMediaTypes.Add(MediaTypeConstants.ApplicationFormUrlEncodedMediaType);
            this._isDerived = this.GetType() != typeof(FormUrlEncodedMediaTypeFormatter);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormUrlEncodedMediaTypeFormatter"/> class.
        /// </summary>
        /// <param name="formatter">The <see cref="FormUrlEncodedMediaTypeFormatter"/> instance to copy settings from.</param>
        protected FormUrlEncodedMediaTypeFormatter(FormUrlEncodedMediaTypeFormatter formatter)
            : base(formatter)
        {
            this.MaxDepth = formatter.MaxDepth;
            this.ReadBufferSize = formatter.ReadBufferSize;
            this._isDerived = this.GetType() != typeof(FormUrlEncodedMediaTypeFormatter);
        }

        /// <summary>
        /// Gets the default media type for HTML Form URL encoded data, namely <c>application/x-www-form-urlencoded</c>.
        /// </summary>
        /// <value>
        /// Because <see cref="MediaTypeHeaderValue"/> is mutable, the value
        /// returned will be a new instance every time.
        /// </value>
        public static MediaTypeHeaderValue DefaultMediaType
        {
            get { return MediaTypeConstants.ApplicationFormUrlEncodedMediaType; }
        }

        /// <summary>
        /// Gets or sets the maximum depth allowed by this formatter.
        /// </summary>
        public int MaxDepth
        {
            get
            {
                return this._maxDepth;
            }
            set
            {
                if (value < FormattingUtilities.DefaultMinDepth)
                {
                    throw Error.ArgumentMustBeGreaterThanOrEqualTo("value", value, FormattingUtilities.DefaultMinDepth);
                }

                this._maxDepth = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of the buffer when reading the incoming stream.
        /// </summary>
        /// <value>
        /// The size of the read buffer.
        /// </value>
        public int ReadBufferSize
        {
            get { return this._readBufferSize; }

            set
            {
                if (value < MinBufferSize)
                {
                    throw Error.ArgumentMustBeGreaterThanOrEqualTo("value", value, MinBufferSize);
                }

                this._readBufferSize = value;
            }
        }

        internal override bool CanWriteAnyTypes
        {
            get
            {
                return this._isDerived;
            }
        }

        /// <summary>
        /// Determines whether this <see cref="FormUrlEncodedMediaTypeFormatter"/> can read objects
        /// of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of object that will be read.</param>
        /// <returns><c>true</c> if objects of this <paramref name="type"/> can be read, otherwise <c>false</c>.</returns>
        public override bool CanReadType(Type type)
        {
            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }

            // Can't read arbitrary types. 
            return type == typeof(FormDataCollection) || FormattingUtilities.IsJTokenType(type);
        }

        /// <summary>
        /// Determines whether this <see cref="FormUrlEncodedMediaTypeFormatter"/> can write objects
        /// of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of object that will be written.</param>
        /// <returns><c>true</c> if objects of this <paramref name="type"/> can be written, otherwise <c>false</c>.</returns>
        public override bool CanWriteType(Type type)
        {
            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }

            return false;
        }

        /// <summary>
        /// Called during deserialization to read an object of the specified <paramref name="type"/>
        /// from the specified <paramref name="readStream"/>.
        /// </summary>
        /// <param name="type">The type of object to read.</param>
        /// <param name="readStream">The <see cref="Stream"/> from which to read.</param>
        /// <param name="content">The <see cref="HttpContent"/> for the content being read.</param>
        /// <param name="formatterLogger">The <see cref="IFormatterLogger"/> to log events to.</param>
        /// <returns>A <see cref="Task"/> whose result will be the object instance that has been read.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "The caught exception type is reflected into a faulted task.")]
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }

            if (readStream == null)
            {
                throw Error.ArgumentNull("readStream");
            }

            try
            {
                return Task.FromResult(this.ReadFromStream(type, readStream));
            }
            catch (Exception e)
            {
                return TaskHelpers.FromError<object>(e);
            }
        }

        private object ReadFromStream(Type type, Stream readStream)
        {
            object result;
            IEnumerable<KeyValuePair<string, string>> nameValuePairs = ReadFormUrlEncoded(readStream, this.ReadBufferSize);

            if (type == typeof(FormDataCollection))
            {
                result = new FormDataCollection(nameValuePairs);
            }
            else if (FormattingUtilities.IsJTokenType(type))
            {
                result = FormUrlEncodedJson.Parse(nameValuePairs, this._maxDepth);
            }
            else
            {
                // Passed us an unsupported type. Should have called CanReadType() first.
                throw Error.InvalidOperation(Resources.SerializerCannotSerializeType, this.GetType().Name, type.Name);
            }
            return result;
        }

        /// <summary>
        /// Reads all name-value pairs encoded as HTML Form URL encoded data and add them to 
        /// a collection as UNescaped URI strings.
        /// </summary>
        /// <param name="input">Stream to read from.</param>
        /// <param name="bufferSize">Size of the buffer used to read the contents.</param>
        /// <returns>Collection of name-value pairs.</returns>
        private static IEnumerable<KeyValuePair<string, string>> ReadFormUrlEncoded(Stream input, int bufferSize)
        {
            Contract.Assert(input != null, "input stream cannot be null");
            Contract.Assert(bufferSize >= MinBufferSize, "buffer size cannot be less than MinBufferSize");

            byte[] data = new byte[bufferSize];

            int bytesRead;
            bool isFinal = false;
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            FormUrlEncodedParser parser = new FormUrlEncodedParser(result, Int64.MaxValue);
            ParserState state;

            while (true)
            {
                try
                {
                    bytesRead = input.Read(data, 0, data.Length);
                    if (bytesRead == 0)
                    {
                        isFinal = true;
                    }
                }
                catch (Exception e)
                {
                    throw Error.InvalidOperation(e, Resources.ErrorReadingFormUrlEncodedStream);
                }

                int bytesConsumed = 0;
                state = parser.ParseBuffer(data, bytesRead, ref bytesConsumed, isFinal);
                if (state != ParserState.NeedMoreData && state != ParserState.Done)
                {
                    throw Error.InvalidOperation(Resources.FormUrlEncodedParseError, bytesConsumed);
                }

                if (isFinal)
                {
                    return result;
                }
            }
        }
    }
}
