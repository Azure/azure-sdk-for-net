// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

#if !NETFX_CORE // In portable library we have our own implementation of Concurrent Dictionary which is in the internal namespace
#endif
#if NETFX_CORE // In portable library we have our own implementation of Concurrent Dictionary which is in the internal namespace
using System.Net.Http.Internal;
#endif

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Internal;

    /// <summary>
    /// Base class to handle serializing and deserializing strongly-typed objects using <see cref="ObjectContent"/>.
    /// </summary>
    internal abstract class MediaTypeFormatter
    {
        private const int DefaultMinHttpCollectionKeys = 1;
        private const int DefaultMaxHttpCollectionKeys = 1000; // same default as ASPNET
        private const string IWellKnownComparerTypeName = "System.IWellKnownStringEqualityComparer, mscorlib, Version=4.0.0.0, PublicKeyToken=b77a5c561934e089";

        private static readonly ConcurrentDictionary<Type, Type> _delegatingEnumerableCache = new ConcurrentDictionary<Type, Type>();
        private static ConcurrentDictionary<Type, ConstructorInfo> _delegatingEnumerableConstructorCache = new ConcurrentDictionary<Type, ConstructorInfo>();
        private static Lazy<int> _defaultMaxHttpCollectionKeys = new Lazy<int>(InitializeDefaultCollectionKeySize, true); // Max number of keys is 1000
        private static int _maxHttpCollectionKeys = -1;

        private readonly List<MediaTypeHeaderValue> _supportedMediaTypes;
        private readonly List<Encoding> _supportedEncodings;
#if !NETFX_CORE // No MediaTypeMappings in portable library or IRequiredMemberSelector (no model state on client)
        private readonly List<MediaTypeMapping> _mediaTypeMappings;
        private IRequiredMemberSelector _requiredMemberSelector;
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaTypeFormatter"/> class.
        /// </summary>
        protected MediaTypeFormatter()
        {
            this._supportedMediaTypes = new List<MediaTypeHeaderValue>();
            this.SupportedMediaTypes = new MediaTypeHeaderValueCollection(this._supportedMediaTypes);
            this._supportedEncodings = new List<Encoding>();
            this.SupportedEncodings = new Collection<Encoding>(this._supportedEncodings);
#if !NETFX_CORE // No MediaTypeMappings in portable library
            this._mediaTypeMappings = new List<MediaTypeMapping>();
            this.MediaTypeMappings = new Collection<MediaTypeMapping>(this._mediaTypeMappings);
#endif
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaTypeFormatter"/> class.
        /// </summary>
        /// <param name="formatter">The <see cref="MediaTypeFormatter"/> instance to copy settings from.</param>
        protected MediaTypeFormatter(MediaTypeFormatter formatter)
        {
            if (formatter == null)
            {
                throw Error.ArgumentNull("formatter");
            }

            this._supportedMediaTypes = formatter._supportedMediaTypes;
            this.SupportedMediaTypes = formatter.SupportedMediaTypes;
            this._supportedEncodings = formatter._supportedEncodings;
            this.SupportedEncodings = formatter.SupportedEncodings;
#if !NETFX_CORE // No MediaTypeMappings in portable library or IRequiredMemberSelector (no model state on client)
            this._mediaTypeMappings = formatter._mediaTypeMappings;
            this.MediaTypeMappings = formatter.MediaTypeMappings;
            this._requiredMemberSelector = formatter._requiredMemberSelector;
#endif
        }

        /// <summary>
        /// Gets or sets the maximum number of keys stored in a NameValueCollection. 
        /// </summary>
        public static int MaxHttpCollectionKeys
        {
            get
            {
                if (_maxHttpCollectionKeys < 0)
                {
                    _maxHttpCollectionKeys = _defaultMaxHttpCollectionKeys.Value;
                }

                return _maxHttpCollectionKeys;
            }
            set
            {
                if (value < DefaultMinHttpCollectionKeys)
                {
                    throw Error.ArgumentMustBeGreaterThanOrEqualTo("value", value, DefaultMinHttpCollectionKeys);
                }

                _maxHttpCollectionKeys = value;
            }
        }

        /// <summary>
        /// Gets the mutable collection of <see cref="MediaTypeHeaderValue"/> elements supported by
        /// this <see cref="MediaTypeFormatter"/> instance.
        /// </summary>
        public Collection<MediaTypeHeaderValue> SupportedMediaTypes { get; private set; }

        internal List<MediaTypeHeaderValue> SupportedMediaTypesInternal
        {
            get { return this._supportedMediaTypes; }
        }

        /// <summary>
        /// Gets the mutable collection of character encodings supported by
        /// this <see cref="MediaTypeFormatter"/> instance. The encodings are
        /// used when reading or writing data. 
        /// </summary>
        public Collection<Encoding> SupportedEncodings { get; private set; }

        internal List<Encoding> SupportedEncodingsInternal
        {
            get { return this._supportedEncodings; }
        }

#if !NETFX_CORE // No MediaTypeMappings in portable library
        /// <summary>
        /// Gets the mutable collection of <see cref="MediaTypeMapping"/> elements used
        /// by this <see cref="MediaTypeFormatter"/> instance to determine the
        /// <see cref="MediaTypeHeaderValue"/> of requests or responses.
        /// </summary>
        public Collection<MediaTypeMapping> MediaTypeMappings { get; private set; }

        internal List<MediaTypeMapping> MediaTypeMappingsInternal
        {
            get { return this._mediaTypeMappings; }
        }
#endif

#if !NETFX_CORE // IRequiredMemberSelector is not in portable libraries because there is no model state on the client.
        /// <summary>
        /// Gets or sets the <see cref="IRequiredMemberSelector"/> used to determine required members.
        /// </summary>
        public virtual IRequiredMemberSelector RequiredMemberSelector
        {
            get
            {
                return this._requiredMemberSelector;
            }
            set
            {
                this._requiredMemberSelector = value;
            }
        }
#endif

        internal virtual bool CanWriteAnyTypes
        {
            get { return true; }
        }

        /// <summary>
        /// Returns a <see cref="Task"/> to deserialize an object of the given <paramref name="type"/> from the given <paramref name="readStream"/>
        /// </summary>
        /// <remarks>
        /// <para>This implementation throws a <see cref="NotSupportedException"/>. Derived types should override this method if the formatter
        /// supports reading.</para>
        /// <para>An implementation of this method should NOT close <paramref name="readStream"/> upon completion. The stream will be closed independently when
        /// the <see cref="HttpContent"/> instance is disposed.
        /// </para>
        /// </remarks>
        /// <param name="type">The type of the object to deserialize.</param>
        /// <param name="readStream">The <see cref="Stream"/> to read.</param>
        /// <param name="content">The <see cref="HttpContent"/> if available. It may be <c>null</c>.</param>
        /// <param name="formatterLogger">The <see cref="IFormatterLogger"/> to log events to.</param>
        /// <returns>A <see cref="Task"/> whose result will be an object of the given type.</returns>
        /// <exception cref="NotSupportedException">Derived types need to support reading.</exception>
        /// <seealso cref="CanReadType(Type)"/>
        public virtual Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            throw Error.NotSupported(Resources.MediaTypeFormatterCannotRead, this.GetType().Name);
        }

        /// <summary>
        /// Returns a <see cref="Task"/> to deserialize an object of the given <paramref name="type"/> from the given <paramref name="readStream"/>
        /// </summary>
        /// <remarks>
        /// <para>This implementation throws a <see cref="NotSupportedException"/>. Derived types should override this method if the formatter
        /// supports reading.</para>
        /// <para>An implementation of this method should NOT close <paramref name="readStream"/> upon completion. The stream will be closed independently when
        /// the <see cref="HttpContent"/> instance is disposed.
        /// </para>
        /// </remarks>
        /// <param name="type">The type of the object to deserialize.</param>
        /// <param name="readStream">The <see cref="Stream"/> to read.</param>
        /// <param name="content">The <see cref="HttpContent"/> if available. It may be <c>null</c>.</param>
        /// <param name="formatterLogger">The <see cref="IFormatterLogger"/> to log events to.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> whose result will be an object of the given type.</returns>
        /// <exception cref="NotSupportedException">Derived types need to support reading.</exception>
        /// <seealso cref="CanReadType(Type)"/>
        public virtual Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content,
            IFormatterLogger formatterLogger, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return TaskHelpers.Canceled<object>();
            }

            return this.ReadFromStreamAsync(type, readStream, content, formatterLogger);
        }

        /// <summary>
        /// Returns a <see cref="Task"/> that serializes the given <paramref name="value"/> of the given <paramref name="type"/>
        /// to the given <paramref name="writeStream"/>.
        /// </summary>
        /// <remarks>
        /// <para>This implementation throws a <see cref="NotSupportedException"/>. Derived types should override this method if the formatter
        /// supports reading.</para>
        /// <para>An implementation of this method should NOT close <paramref name="writeStream"/> upon completion. The stream will be closed independently when
        /// the <see cref="HttpContent"/> instance is disposed.
        /// </para>
        /// </remarks>
        /// <param name="type">The type of the object to write.</param>
        /// <param name="value">The object value to write.  It may be <c>null</c>.</param>
        /// <param name="writeStream">The <see cref="Stream"/> to which to write.</param>
        /// <param name="content">The <see cref="HttpContent"/> if available. It may be <c>null</c>.</param>
        /// <param name="transportContext">The <see cref="TransportContext"/> if available. It may be <c>null</c>.</param>
        /// <returns>A <see cref="Task"/> that will perform the write.</returns>
        /// <exception cref="NotSupportedException">Derived types need to support writing.</exception>
        /// <seealso cref="CanWriteType(Type)"/>
        public virtual Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            // HttpContent.SerializeToStreamAsync doesn't take in a CancellationToken. So, there is no easy way to get the CancellationToken
            // to the formatter while writing response. We are cheating here by passing fake cancellation tokens. We should fix this
            // when we fix HttpContent.
            return this.WriteToStreamAsync(type, value, writeStream, content, transportContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a <see cref="Task"/> that serializes the given <paramref name="value"/> of the given <paramref name="type"/>
        /// to the given <paramref name="writeStream"/>.
        /// </summary>
        /// <remarks>
        /// <para>This implementation throws a <see cref="NotSupportedException"/>. Derived types should override this method if the formatter
        /// supports reading.</para>
        /// <para>An implementation of this method should NOT close <paramref name="writeStream"/> upon completion. The stream will be closed independently when
        /// the <see cref="HttpContent"/> instance is disposed.
        /// </para>
        /// </remarks>
        /// <param name="type">The type of the object to write.</param>
        /// <param name="value">The object value to write.  It may be <c>null</c>.</param>
        /// <param name="writeStream">The <see cref="Stream"/> to which to write.</param>
        /// <param name="content">The <see cref="HttpContent"/> if available. It may be <c>null</c>.</param>
        /// <param name="transportContext">The <see cref="TransportContext"/> if available. It may be <c>null</c>.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> that will perform the write.</returns>
        /// <exception cref="NotSupportedException">Derived types need to support writing.</exception>
        /// <seealso cref="CanWriteType(Type)"/>
        public virtual Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext, CancellationToken cancellationToken)
        {
            throw Error.NotSupported(Resources.MediaTypeFormatterCannotWrite, this.GetType().Name);
        }

        private static bool TryGetDelegatingType(Type interfaceType, ref Type type)
        {
            if (type != null && type.IsInterface() && type.IsGenericType())
            {
                Type genericType = type.ExtractGenericInterface(interfaceType);

                if (genericType != null)
                {
                    type = GetOrAddDelegatingType(type, genericType);
                    return true;
                }
            }

            return false;
        }

        private static int InitializeDefaultCollectionKeySize()
        {
            return Int32.MaxValue;
        }

        /// <summary>
        /// This method converts <see cref="IEnumerable{T}"/> (and interfaces that mandate it) to a <see cref="DelegatingEnumerable{T}"/> for serialization purposes.
        /// </summary>
        /// <param name="type">The type to potentially be wrapped. If the type is wrapped, it's changed in place.</param>
        /// <returns>Returns <c>true</c> if the type was wrapped; <c>false</c>, otherwise</returns>
        internal static bool TryGetDelegatingTypeForIEnumerableGenericOrSame(ref Type type)
        {
            return TryGetDelegatingType(FormattingUtilities.EnumerableInterfaceGenericType, ref type);
        }

        /// <summary>
        /// This method converts <see cref="IQueryable{T}"/> (and interfaces that mandate it) to a <see cref="DelegatingEnumerable{T}"/> for serialization purposes.
        /// </summary>
        /// <param name="type">The type to potentially be wrapped. If the type is wrapped, it's changed in place.</param>
        /// <returns>Returns <c>true</c> if the type was wrapped; <c>false</c>, otherwise</returns>
        internal static bool TryGetDelegatingTypeForIQueryableGenericOrSame(ref Type type)
        {
            return TryGetDelegatingType(FormattingUtilities.QueryableInterfaceGenericType, ref type);
        }

        internal static ConstructorInfo GetTypeRemappingConstructor(Type type)
        {
            ConstructorInfo constructorInfo;
            _delegatingEnumerableConstructorCache.TryGetValue(type, out constructorInfo);
            return constructorInfo;
        }

        /// <summary>
        /// Determines the best <see cref="Encoding"/> amongst the supported encodings
        /// for reading or writing an HTTP entity body based on the provided <paramref name="contentHeaders"/>.
        /// </summary>
        /// <param name="contentHeaders">The content headers provided as part of the request or response.</param>
        /// <returns>The <see cref="Encoding"/> to use when reading the request or writing the response.</returns>
        public Encoding SelectCharacterEncoding(HttpContentHeaders contentHeaders)
        {
            // Performance-sensitive
            Encoding encoding = null;
            if (contentHeaders != null && contentHeaders.ContentType != null)
            {
                // Find encoding based on content type charset parameter
                string charset = contentHeaders.ContentType.CharSet;
                if (!String.IsNullOrWhiteSpace(charset))
                {
                    for (int i = 0; i < this._supportedEncodings.Count; i++)
                    {
                        Encoding supportedEncoding = this._supportedEncodings[i];
                        if (charset.Equals(supportedEncoding.WebName, StringComparison.OrdinalIgnoreCase))
                        {
                            encoding = supportedEncoding;
                            break;
                        }
                    }
                }
            }

            if (encoding == null)
            {
                // We didn't find a character encoding match based on the content headers.
                // Instead we try getting the default character encoding.
                if (this._supportedEncodings.Count > 0)
                {
                    encoding = this._supportedEncodings[0];
                }
            }

            if (encoding == null)
            {
                // No supported encoding was found so there is no way for us to start reading or writing.
                throw Error.InvalidOperation(Resources.MediaTypeFormatterNoEncoding, this.GetType().Name);
            }

            return encoding;
        }

        /// <summary>
        /// Sets the default headers for content that will be formatted using this formatter. This method
        /// is called from the <see cref="ObjectContent"/> constructor.
        /// This implementation sets the Content-Type header to the value of <paramref name="mediaType"/> if it is
        /// not <c>null</c>. If it is <c>null</c> it sets the Content-Type to the default media type of this formatter.
        /// If the Content-Type does not specify a charset it will set it using this formatters configured
        /// <see cref="Encoding"/>.
        /// </summary>
        /// <remarks>
        /// Subclasses can override this method to set content headers such as Content-Type etc. Subclasses should
        /// call the base implementation. Subclasses should treat the passed in <paramref name="mediaType"/> (if not <c>null</c>)
        /// as the authoritative media type and use that as the Content-Type.
        /// </remarks>
        /// <param name="type">The type of the object being serialized. See <see cref="ObjectContent"/>.</param>
        /// <param name="headers">The content headers that should be configured.</param>
        /// <param name="mediaType">The authoritative media type. Can be <c>null</c>.</param>
        public virtual void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }
            if (headers == null)
            {
                throw Error.ArgumentNull("headers");
            }

            if (mediaType != null)
            {
                headers.ContentType = mediaType.Clone();
            }

            // If content type is not set then set it based on supported media types.
            if (headers.ContentType == null)
            {
                MediaTypeHeaderValue defaultMediaType = null;
                if (this._supportedMediaTypes.Count > 0)
                {
                    defaultMediaType = this._supportedMediaTypes[0];
                }
                if (defaultMediaType != null)
                {
                    headers.ContentType = defaultMediaType.Clone();
                }
            }

            // If content type charset parameter is not set then set it based on the supported encodings.
            if (headers.ContentType != null && headers.ContentType.CharSet == null)
            {
                Encoding defaultEncoding = null;
                if (this._supportedEncodings.Count > 0)
                {
                    defaultEncoding = this._supportedEncodings[0];
                }
                if (defaultEncoding != null)
                {
                    headers.ContentType.CharSet = defaultEncoding.WebName;
                }
            }
        }

        /// <summary>
        /// Returns a specialized instance of the <see cref="MediaTypeFormatter"/> that can handle formatting a response for the given
        /// parameters. This method is called after a formatter has been selected through content negotiation.
        /// </summary>
        /// <remarks>
        /// The default implementation returns <c>this</c> instance. Derived classes can choose to return a new instance if
        /// they need to close over any of the parameters.
        /// </remarks>
        /// <param name="type">The type being serialized.</param>
        /// <param name="request">The request.</param>
        /// <param name="mediaType">The media type chosen for the serialization. Can be <c>null</c>.</param>
        /// <returns>An instance that can format a response to the given <paramref name="request"/>.</returns>
        public virtual MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        {
            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }
            if (request == null)
            {
                throw Error.ArgumentNull("request");
            }

            return this;
        }

        /// <summary>
        /// Determines whether this <see cref="MediaTypeFormatter"/> can deserialize
        /// an object of the specified type.
        /// </summary>
        /// <remarks>
        /// Derived classes must implement this method and indicate if a type can or cannot be deserialized.
        /// </remarks>
        /// <param name="type">The type of object that will be deserialized.</param>
        /// <returns><c>true</c> if this <see cref="MediaTypeFormatter"/> can deserialize an object of that type; otherwise <c>false</c>.</returns>
        public abstract bool CanReadType(Type type);

        /// <summary>
        /// Determines whether this <see cref="MediaTypeFormatter"/> can serialize
        /// an object of the specified type.
        /// </summary>
        /// <remarks>
        /// Derived classes must implement this method and indicate if a type can or cannot be serialized.
        /// </remarks>
        /// <param name="type">The type of object that will be serialized.</param>
        /// <returns><c>true</c> if this <see cref="MediaTypeFormatter"/> can serialize an object of that type; otherwise <c>false</c>.</returns>
        public abstract bool CanWriteType(Type type);

        private static Type GetOrAddDelegatingType(Type type, Type genericType)
        {
            return _delegatingEnumerableCache.GetOrAdd(
                type,
                (typeToRemap) =>
                {
                    // The current method is called by methods that already checked the type for is not null, is generic and is or implements IEnumerable<T>
                    // This retrieves the T type of the IEnumerable<T> interface.
                    Type elementType = genericType.GetGenericArguments()[0];
                    Type delegatingType = FormattingUtilities.DelegatingEnumerableGenericType.MakeGenericType(elementType);
                    ConstructorInfo delegatingConstructor = delegatingType.GetConstructor(new Type[] { FormattingUtilities.EnumerableInterfaceGenericType.MakeGenericType(elementType) });
                    _delegatingEnumerableConstructorCache.TryAdd(delegatingType, delegatingConstructor);

                    return delegatingType;
                });
        }

        /// <summary>
        /// Gets the default value for the specified type.
        /// </summary>
        public static object GetDefaultValueForType(Type type)
        {
            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }

            if (type.IsValueType())
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }

        /// <summary>
        /// Collection class that validates it contains only <see cref="MediaTypeHeaderValue"/> instances
        /// that are not null and not media ranges.
        /// </summary>
        internal class MediaTypeHeaderValueCollection : Collection<MediaTypeHeaderValue>
        {
            private static readonly Type _mediaTypeHeaderValueType = typeof(MediaTypeHeaderValue);

            internal MediaTypeHeaderValueCollection(IList<MediaTypeHeaderValue> list)
                : base(list)
            {
            }

            /// <summary>
            /// Inserts the <paramref name="item"/> into the collection at the specified <paramref name="index"/>.
            /// </summary>
            /// <param name="index">The zero-based index at which item should be inserted.</param>
            /// <param name="item">The object to insert. It cannot be <c>null</c>.</param>
            protected override void InsertItem(int index, MediaTypeHeaderValue item)
            {
                ValidateMediaType(item);
                base.InsertItem(index, item);
            }

            /// <summary>
            /// Replaces the element at the specified <paramref name="index"/>.
            /// </summary>
            /// <param name="index">The zero-based index of the item that should be replaced.</param>
            /// <param name="item">The new value for the element at the specified index.  It cannot be <c>null</c>.</param>
            protected override void SetItem(int index, MediaTypeHeaderValue item)
            {
                ValidateMediaType(item);
                base.SetItem(index, item);
            }

            private static void ValidateMediaType(MediaTypeHeaderValue item)
            {
                if (item == null)
                {
                    throw Error.ArgumentNull("item");
                }

                ParsedMediaTypeHeaderValue parsedMediaType = new ParsedMediaTypeHeaderValue(item);
                if (parsedMediaType.IsAllMediaRange || parsedMediaType.IsSubtypeMediaRange)
                {
                    throw Error.Argument("item", Resources.CannotUseMediaRangeForSupportedMediaType, _mediaTypeHeaderValueType.Name, item.MediaType);
                }
            }
        }
    }
}
