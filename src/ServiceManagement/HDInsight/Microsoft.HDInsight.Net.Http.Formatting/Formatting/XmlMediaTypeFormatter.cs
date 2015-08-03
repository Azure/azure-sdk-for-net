// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

#if !NETFX_CORE // In portable library we have our own implementation of Concurrent Dictionary which is in the internal namespace
#endif

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System;
    using System.Collections.Concurrent;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Internal;

    /// <summary>
    /// <see cref="MediaTypeFormatter"/> class to handle Xml.
    /// </summary>
    internal class XmlMediaTypeFormatter : MediaTypeFormatter
    {
        private ConcurrentDictionary<Type, object> _serializerCache = new ConcurrentDictionary<Type, object>();
        private XmlDictionaryReaderQuotas _readerQuotas = FormattingUtilities.CreateDefaultReaderQuotas();

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlMediaTypeFormatter"/> class.
        /// </summary>
        public XmlMediaTypeFormatter()
        {
            // Set default supported media types
            this.SupportedMediaTypes.Add(MediaTypeConstants.ApplicationXmlMediaType);
            this.SupportedMediaTypes.Add(MediaTypeConstants.TextXmlMediaType);

            // Set default supported character encodings
            this.SupportedEncodings.Add(new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true));
            this.SupportedEncodings.Add(new UnicodeEncoding(bigEndian: false, byteOrderMark: true, throwOnInvalidBytes: true));
            this.WriterSettings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                CloseOutput = false,
                CheckCharacters = false
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlMediaTypeFormatter"/> class.
        /// </summary>
        /// <param name="formatter">The <see cref="XmlMediaTypeFormatter"/> instance to copy settings from.</param>
        protected XmlMediaTypeFormatter(XmlMediaTypeFormatter formatter)
            : base(formatter)
        {
            this.UseXmlSerializer = formatter.UseXmlSerializer;
            this.WriterSettings = formatter.WriterSettings;
#if !NETFX_CORE // MaxDepth is not supported in portable libraries
            this.MaxDepth = formatter.MaxDepth;
#endif
        }

        /// <summary>
        /// Gets the default media type for xml, namely "application/xml".
        /// </summary>
        /// <value>
        /// <remarks>
        /// The default media type does not have any <c>charset</c> parameter as 
        /// the <see cref="Encoding"/> can be configured on a per <see cref="XmlMediaTypeFormatter"/> 
        /// instance basis.
        /// </remarks>
        /// Because <see cref="MediaTypeHeaderValue"/> is mutable, the value
        /// returned will be a new instance every time.
        /// </value>
        public static MediaTypeHeaderValue DefaultMediaType
        {
            get { return MediaTypeConstants.ApplicationXmlMediaType; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use <see cref="XmlSerializer"/> instead of <see cref="DataContractSerializer"/> by default.
        /// </summary>
        /// <value>
        ///     <c>true</c> if use <see cref="XmlSerializer"/> by default; otherwise, <c>false</c>. The default is <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool UseXmlSerializer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to indent elements when writing data. 
        /// </summary>
        public bool Indent
        {
            get
            {
                return this.WriterSettings.Indent;
            }
            set
            {
                this.WriterSettings.Indent = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="XmlWriterSettings"/> to be used while writing.
        /// </summary>
        public XmlWriterSettings WriterSettings { get; private set; }

#if !NETFX_CORE // MaxDepth is not supported in portable libraries
        /// <summary>
        /// Gets or sets the maximum depth allowed by this formatter.
        /// </summary>
        public int MaxDepth
        {
            get
            {
                return this._readerQuotas.MaxDepth;
            }
            set
            {
                if (value < FormattingUtilities.DefaultMinDepth)
                {
                    throw Error.ArgumentMustBeGreaterThanOrEqualTo("value", value, FormattingUtilities.DefaultMinDepth);
                }

                this._readerQuotas.MaxDepth = value;
            }
        }
#endif

        /// <summary>
        /// Registers the <see cref="XmlObjectSerializer"/> to use to read or write
        /// the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of object that will be serialized or deserialized with <paramref name="serializer"/>.</param>
        /// <param name="serializer">The <see cref="XmlObjectSerializer"/> instance to use.</param>
        public void SetSerializer(Type type, XmlObjectSerializer serializer)
        {
            this.VerifyAndSetSerializer(type, serializer);
        }

        /// <summary>
        /// Registers the <see cref="XmlObjectSerializer"/> to use to read or write
        /// the specified <typeparamref name="T"/> type.
        /// </summary>
        /// <typeparam name="T">The type of object that will be serialized or deserialized with <paramref name="serializer"/>.</typeparam>
        /// <param name="serializer">The <see cref="XmlObjectSerializer"/> instance to use.</param>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The T represents a Type parameter.")]
        public void SetSerializer<T>(XmlObjectSerializer serializer)
        {
            this.SetSerializer(typeof(T), serializer);
        }

        /// <summary>
        /// Registers the <see cref="XmlSerializer"/> to use to read or write
        /// the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of objects for which <paramref name="serializer"/> will be used.</param>
        /// <param name="serializer">The <see cref="XmlSerializer"/> instance to use.</param>
        public void SetSerializer(Type type, XmlSerializer serializer)
        {
            this.VerifyAndSetSerializer(type, serializer);
        }

        /// <summary>
        /// Registers the <see cref="XmlSerializer"/> to use to read or write
        /// the specified <typeparamref name="T"/> type.
        /// </summary>
        /// <typeparam name="T">The type of object that will be serialized or deserialized with <paramref name="serializer"/>.</typeparam>
        /// <param name="serializer">The <see cref="XmlSerializer"/> instance to use.</param>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The T represents a Type parameter.")]
        public void SetSerializer<T>(XmlSerializer serializer)
        {
            this.SetSerializer(typeof(T), serializer);
        }

        /// <summary>
        /// Unregisters the serializer currently associated with the given <paramref name="type"/>.
        /// </summary>
        /// <remarks>
        /// Unless another serializer is registered for the <paramref name="type"/>, a default one will be created.
        /// </remarks>
        /// <param name="type">The type of object whose serializer should be removed.</param>
        /// <returns><c>true</c> if a serializer was registered for the <paramref name="type"/>; otherwise <c>false</c>.</returns>
        public bool RemoveSerializer(Type type)
        {
            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }

            object value;
            return this._serializerCache.TryRemove(type, out value);
        }

        /// <summary>
        /// Determines whether this <see cref="XmlMediaTypeFormatter"/> can read objects
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

            // If there is a registered non-null serializer, we can support this type.
            // Otherwise attempt to create the default serializer.
            object serializer = this.GetCachedSerializer(type, throwOnError: false);

            // Null means we tested it before and know it is not supported
            return serializer != null;
        }

        /// <summary>
        /// Determines whether this <see cref="XmlMediaTypeFormatter"/> can write objects
        /// of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of object that will be written.</param>
        /// <returns><c>true</c> if objects of this <paramref name="type"/> can be written, otherwise <c>false</c>.</returns>
        public override bool CanWriteType(Type type)
        {
            // Performance-sensitive
            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }

            if (this.UseXmlSerializer)
            {
                MediaTypeFormatter.TryGetDelegatingTypeForIEnumerableGenericOrSame(ref type);
            }
            else
            {
                MediaTypeFormatter.TryGetDelegatingTypeForIQueryableGenericOrSame(ref type);
            }

            // If there is a registered non-null serializer, we can support this type.
            object serializer = this.GetCachedSerializer(type, throwOnError: false);

            // Null means we tested it before and know it is not supported
            return serializer != null;
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
                return Task.FromResult(this.ReadFromStream(type, readStream, content, formatterLogger));
            }
            catch (Exception e)
            {
                return TaskHelpers.FromError<object>(e);
            }
        }

        private object ReadFromStream(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            HttpContentHeaders contentHeaders = content == null ? null : content.Headers;

            // If content length is 0 then return default value for this type
            if (contentHeaders != null && contentHeaders.ContentLength == 0)
            {
                return GetDefaultValueForType(type);
            }

            object serializer = this.GetDeserializer(type, content);

            try
            {
                using (XmlReader reader = this.CreateXmlReader(readStream, content))
                {
                    XmlSerializer xmlSerializer = serializer as XmlSerializer;
                    if (xmlSerializer != null)
                    {
                        return xmlSerializer.Deserialize(reader);
                    }
                    else
                    {
                        XmlObjectSerializer xmlObjectSerializer = serializer as XmlObjectSerializer;
                        if (xmlObjectSerializer == null)
                        {
                            ThrowInvalidSerializerException(serializer, "GetDeserializer");
                        }
                        return xmlObjectSerializer.ReadObject(reader);
                    }
                }
            }
            catch (Exception e)
            {
                if (formatterLogger == null)
                {
                    throw;
                }
                formatterLogger.LogError(String.Empty, e);
                return GetDefaultValueForType(type);
            }
        }

        /// <summary>
        /// Called during deserialization to get the XML serializer to use for deserializing objects.
        /// </summary>
        /// <param name="type">The type of object to deserialize.</param>
        /// <param name="content">The <see cref="HttpContent"/> for the content being read.</param>
        /// <returns>An instance of <see cref="XmlObjectSerializer"/> or <see cref="XmlSerializer"/> to use for deserializing the object.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "The term deserializer is spelled correctly.")]
        protected internal virtual object GetDeserializer(Type type, HttpContent content)
        {
            return this.GetSerializerForType(type);
        }

        /// <summary>
        /// Called during deserialization to get the XML reader to use for reading objects from the stream.
        /// </summary>
        /// <param name="readStream">The <see cref="Stream"/> to read from.</param>
        /// <param name="content">The <see cref="HttpContent"/> for the content being read.</param>
        /// <returns>The <see cref="XmlReader"/> to use for reading objects.</returns>
        protected internal virtual XmlReader CreateXmlReader(Stream readStream, HttpContent content)
        {
            // Get the character encoding for the content
            Encoding effectiveEncoding = this.SelectCharacterEncoding(content == null ? null : content.Headers);
#if NETFX_CORE
            // Force a preamble into the stream, since CreateTextReader in WinRT only supports auto-detecting encoding.
            return XmlDictionaryReader.CreateTextReader(new ReadOnlyStreamWithEncodingPreamble(readStream, effectiveEncoding), _readerQuotas);
#else
            return XmlDictionaryReader.CreateTextReader(new NonClosingDelegatingStream(readStream), effectiveEncoding, this._readerQuotas, null);
#endif
        }

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "The caught exception type is reflected into a faulted task.")]
        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext, CancellationToken cancellationToken)
        {
            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }
            if (writeStream == null)
            {
                throw Error.ArgumentNull("writeStream");
            }
            if (cancellationToken.IsCancellationRequested)
            {
                return TaskHelpers.Canceled();
            }

            try
            {
                this.WriteToStream(type, value, writeStream, content);
                return TaskHelpers.Completed();
            }
            catch (Exception e)
            {
                return TaskHelpers.FromError(e);
            }
        }

        private void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            bool isRemapped = false;
            if (this.UseXmlSerializer)
            {
                isRemapped = MediaTypeFormatter.TryGetDelegatingTypeForIEnumerableGenericOrSame(ref type);
            }
            else
            {
                isRemapped = MediaTypeFormatter.TryGetDelegatingTypeForIQueryableGenericOrSame(ref type);
            }

            if (isRemapped && value != null)
            {
                value = MediaTypeFormatter.GetTypeRemappingConstructor(type).Invoke(new object[] { value });
            }

            object serializer = this.GetSerializer(type, value, content);

            using (XmlWriter writer = this.CreateXmlWriter(writeStream, content))
            {
                XmlSerializer xmlSerializer = serializer as XmlSerializer;
                if (xmlSerializer != null)
                {
                    xmlSerializer.Serialize(writer, value);
                }
                else
                {
                    XmlObjectSerializer xmlObjectSerializer = serializer as XmlObjectSerializer;
                    if (xmlObjectSerializer == null)
                    {
                        ThrowInvalidSerializerException(serializer, "GetSerializer");
                    }
                    xmlObjectSerializer.WriteObject(writer, value);
                }
            }
        }

        /// <summary>
        /// Called during serialization to get the XML serializer to use for serializing objects.
        /// </summary>
        /// <param name="type">The type of object to serialize.</param>
        /// <param name="value">The object to serialize.</param>
        /// <param name="content">The <see cref="HttpContent"/> for the content being written.</param>
        /// <returns>An instance of <see cref="XmlObjectSerializer"/> or <see cref="XmlSerializer"/> to use for serializing the object.</returns>
        protected internal virtual object GetSerializer(Type type, object value, HttpContent content)
        {
            return this.GetSerializerForType(type);
        }

        /// <summary>
        /// Called during serialization to get the XML writer to use for writing objects to the stream.
        /// </summary>
        /// <param name="writeStream">The <see cref="Stream"/> to write to.</param>
        /// <param name="content">The <see cref="HttpContent"/> for the content being written.</param>
        /// <returns>The <see cref="XmlWriter"/> to use for writing objects.</returns>
        protected internal virtual XmlWriter CreateXmlWriter(Stream writeStream, HttpContent content)
        {
            Encoding effectiveEncoding = this.SelectCharacterEncoding(content != null ? content.Headers : null);
            XmlWriterSettings writerSettings = this.WriterSettings.Clone();
            writerSettings.Encoding = effectiveEncoding;
            return XmlWriter.Create(writeStream, writerSettings);
        }

        /// <summary>
        /// Called during deserialization to get the XML serializer.
        /// </summary>
        /// <param name="type">The type of object that will be serialized or deserialized.</param>
        /// <returns>The <see cref="XmlSerializer"/> used to serialize the object.</returns>
        public virtual XmlSerializer CreateXmlSerializer(Type type)
        {
            return new XmlSerializer(type);
        }

        /// <summary>
        /// Called during deserialization to get the DataContractSerializer serializer.
        /// </summary>
        /// <param name="type">The type of object that will be serialized or deserialized.</param>
        /// <returns>The <see cref="DataContractSerializer"/> used to serialize the object.</returns>
        public virtual DataContractSerializer CreateDataContractSerializer(Type type)
        {
            return new DataContractSerializer(type);
        }

        /// <summary>
        /// This method is to support infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XmlReader InvokeCreateXmlReader(Stream readStream, HttpContent content)
        {
            return this.CreateXmlReader(readStream, content);
        }

        /// <summary>
        /// This method is to support infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XmlWriter InvokeCreateXmlWriter(Stream writeStream, HttpContent content)
        {
            return this.CreateXmlWriter(writeStream, content);
        }

        /// <summary>
        /// This method is to support infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object InvokeGetDeserializer(Type type, HttpContent content)
        {
            return this.GetDeserializer(type, content);
        }

        /// <summary>
        /// This method is to support infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object InvokeGetSerializer(Type type, object value, HttpContent content)
        {
            return this.GetSerializer(type, value, content);
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Since we use an extensible factory method we cannot control the exceptions being thrown")]
        private object CreateDefaultSerializer(Type type, bool throwOnError)
        {
            Contract.Assert(type != null, "type cannot be null.");
            Exception exception = null;
            object serializer = null;

            try
            {
                if (this.UseXmlSerializer)
                {
                    serializer = this.CreateXmlSerializer(type);
                }
                else
                {
#if !NETFX_CORE
                    // REVIEW: Is there something comparable in WinRT?
                    // Verify that type is a valid data contract by forcing the serializer to try to create a data contract
                    FormattingUtilities.XsdDataContractExporter.GetRootElementName(type);
#endif
                    serializer = this.CreateDataContractSerializer(type);
                }
            }
            catch (Exception caught)
            {
                exception = caught;
            }

            if (serializer == null && throwOnError)
            {
                if (exception != null)
                {
                    throw Error.InvalidOperation(exception, Resources.SerializerCannotSerializeType,
                                  this.UseXmlSerializer ? typeof(XmlSerializer).Name : typeof(DataContractSerializer).Name,
                                  type.Name);
                }
                else
                {
                    throw Error.InvalidOperation(Resources.SerializerCannotSerializeType,
                              this.UseXmlSerializer ? typeof(XmlSerializer).Name : typeof(DataContractSerializer).Name,
                              type.Name);
                }
            }

            return serializer;
        }

        private object GetCachedSerializer(Type type, bool throwOnError)
        {
            // Performance-sensitive
            object serializer;
            if (!this._serializerCache.TryGetValue(type, out serializer))
            {
                // Race condition on creation has no side effects
                serializer = this.CreateDefaultSerializer(type, throwOnError);
                this._serializerCache.TryAdd(type, serializer);
            }
            return serializer;
        }

        private void VerifyAndSetSerializer(Type type, object serializer)
        {
            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }

            if (serializer == null)
            {
                throw Error.ArgumentNull("serializer");
            }

            this.SetSerializerInternal(type, serializer);
        }

        private void SetSerializerInternal(Type type, object serializer)
        {
            Contract.Assert(type != null, "type cannot be null.");
            Contract.Assert(serializer != null, "serializer cannot be null.");

            this._serializerCache.AddOrUpdate(type, serializer, (key, value) => serializer);
        }

        private object GetSerializerForType(Type type)
        {
            // Performance-sensitive
            Contract.Assert(type != null, "Type cannot be null");

            object serializer = this.GetCachedSerializer(type, throwOnError: true);

            if (serializer == null)
            {
                // A null serializer indicates the type has already been tested
                // and found unsupportable.
                throw Error.InvalidOperation(Resources.SerializerCannotSerializeType,
                              this.UseXmlSerializer ? typeof(XmlSerializer).Name : typeof(DataContractSerializer).Name,
                              type.Name);
            }

            Contract.Assert(serializer is XmlSerializer || serializer is XmlObjectSerializer, "Only XmlSerializer or XmlObjectSerializer are supported.");
            return serializer;
        }

        private static void ThrowInvalidSerializerException(object serializer, string getSerializerMethodName)
        {
            if (serializer == null)
            {
                throw Error.InvalidOperation(Resources.XmlMediaTypeFormatter_NullReturnedSerializer, getSerializerMethodName);
            }
            else
            {
                throw Error.InvalidOperation(Resources.XmlMediaTypeFormatter_InvalidSerializerType, serializer.GetType().Name, getSerializerMethodName);
            }
        }
    }
}
