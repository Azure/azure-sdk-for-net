// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Collection class that contains <see cref="MediaTypeFormatter"/> instances.
    /// </summary>
    internal class MediaTypeFormatterCollection : Collection<MediaTypeFormatter>
    {
        private static readonly Type _mediaTypeFormatterType = typeof(MediaTypeFormatter);

        private MediaTypeFormatter[] _writingFormatters;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaTypeFormatterCollection"/> class.
        /// </summary>
        /// <remarks>
        /// This collection will be initialized to contain default <see cref="MediaTypeFormatter"/>
        /// instances for Xml, JsonValue and Json.
        /// </remarks>
        public MediaTypeFormatterCollection()
            : this(CreateDefaultFormatters())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaTypeFormatterCollection"/> class.
        /// </summary>
        /// <param name="formatters">A collection of <see cref="MediaTypeFormatter"/> instances to place in the collection.</param>
        public MediaTypeFormatterCollection(IEnumerable<MediaTypeFormatter> formatters)
        {
            this.VerifyAndSetFormatters(formatters);
        }

        internal event EventHandler Changing;

        /// <summary>
        /// Gets the <see cref="MediaTypeFormatter"/> to use for Xml.
        /// </summary>
        public XmlMediaTypeFormatter XmlFormatter
        {
            get { return this.Items.OfType<XmlMediaTypeFormatter>().FirstOrDefault(); }
        }

        /// <summary>
        /// Gets the <see cref="MediaTypeFormatter"/> to use for Json.
        /// </summary>
        public JsonMediaTypeFormatter JsonFormatter
        {
            get { return this.Items.OfType<JsonMediaTypeFormatter>().FirstOrDefault(); }
        }

#if !NETFX_CORE // FormUrlEncodedMediaTypeFormatter is not supported in portable library.
        /// <summary>
        /// Gets the <see cref="MediaTypeFormatter"/> to use for <c>application/x-www-form-urlencoded</c> data.
        /// </summary>
        public FormUrlEncodedMediaTypeFormatter FormUrlEncodedFormatter
        {
            get { return this.Items.OfType<FormUrlEncodedMediaTypeFormatter>().FirstOrDefault(); }
        }
#endif

        internal MediaTypeFormatter[] WritingFormatters
        {
            get
            {
                if (this._writingFormatters == null)
                {
                    this._writingFormatters = this.GetWritingFormatters();
                }
                return this._writingFormatters;
            }
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="MediaTypeFormatterCollection"/>.
        /// </summary>
        /// <param name="items">
        /// The items that should be added to the end of the <see cref="MediaTypeFormatterCollection"/>.
        /// The items collection itself cannot be <see langword="null"/>, but it can contain elements that are
        /// <see langword="null"/>.
        /// </param>
        public void AddRange(IEnumerable<MediaTypeFormatter> items)
        {
            if (items == null)
            {
                throw Error.ArgumentNull("items");
            }

            foreach (MediaTypeFormatter item in items)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Inserts the elements of a collection into the <see cref="MediaTypeFormatterCollection"/> at the specified
        /// index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="items">
        /// The items that should be inserted into the <see cref="MediaTypeFormatterCollection"/>. The items collection
        /// itself cannot be <see langword="null"/>, but it can contain elements that are <see langword="null"/>.
        /// </param>
        public void InsertRange(int index, IEnumerable<MediaTypeFormatter> items)
        {
            if (items == null)
            {
                throw Error.ArgumentNull("items");
            }

            foreach (MediaTypeFormatter item in items)
            {
                this.Insert(index++, item);
            }
        }

        /// <summary>
        /// Helper to search a collection for a formatter that can read the .NET type in the given mediaType.
        /// </summary>
        /// <param name="type">.NET type to read</param>
        /// <param name="mediaType">media type to match on.</param>
        /// <returns>Formatter that can read the type. Null if no formatter found.</returns>
        public MediaTypeFormatter FindReader(Type type, MediaTypeHeaderValue mediaType)
        {
            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }
            if (mediaType == null)
            {
                throw Error.ArgumentNull("mediaType");
            }

            foreach (MediaTypeFormatter formatter in this.Items)
            {
                if (formatter != null && formatter.CanReadType(type))
                {
                    foreach (MediaTypeHeaderValue supportedMediaType in formatter.SupportedMediaTypes)
                    {
                        if (supportedMediaType != null && supportedMediaType.IsSubsetOf(mediaType))
                        {
                            return formatter;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Helper to search a collection for a formatter that can write the .NET type in the given mediaType.
        /// </summary>
        /// <param name="type">.NET type to read</param>
        /// <param name="mediaType">media type to match on.</param>
        /// <returns>Formatter that can write the type. Null if no formatter found.</returns>
        public MediaTypeFormatter FindWriter(Type type, MediaTypeHeaderValue mediaType)
        {
            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }
            if (mediaType == null)
            {
                throw Error.ArgumentNull("mediaType");
            }

            foreach (MediaTypeFormatter formatter in this.Items)
            {
                if (formatter != null && formatter.CanWriteType(type))
                {
                    foreach (MediaTypeHeaderValue supportedMediaType in formatter.SupportedMediaTypes)
                    {
                        if (supportedMediaType != null && supportedMediaType.IsSubsetOf(mediaType))
                        {
                            return formatter;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns true if the type is one of those loosely defined types that should be excluded from validation
        /// </summary>
        /// <param name="type">.NET <see cref="Type"/> to validate</param>
        /// <returns><c>true</c> if the type should be excluded.</returns>
        public static bool IsTypeExcludedFromValidation(Type type)
        {
            return
#if !NETFX_CORE
                typeof(XmlNode).IsAssignableFrom(type) ||
                typeof(FormDataCollection).IsAssignableFrom(type) ||
#endif
                FormattingUtilities.IsJTokenType(type) ||
                typeof(XObject).IsAssignableFrom(type) ||
                typeof(Type).IsAssignableFrom(type) ||
                type == typeof(byte[]);
        }

        protected override void ClearItems()
        {
            this.OnChanging();
            base.ClearItems();
        }

        protected override void InsertItem(int index, MediaTypeFormatter item)
        {
            this.OnChanging();
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            this.OnChanging();
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, MediaTypeFormatter item)
        {
            this.OnChanging();
            base.SetItem(index, item);
        }

        private void OnChanging()
        {
            if (this.Changing != null)
            {
                this.Changing(this, EventArgs.Empty);
            }

            // Clear cached state
            this._writingFormatters = null;
        }

        private MediaTypeFormatter[] GetWritingFormatters()
        {
            return this.Items.Where((formatter) => formatter != null && formatter.CanWriteAnyTypes).ToArray();
        }

        /// <summary>
        /// Creates a collection of new instances of the default <see cref="MediaTypeFormatter"/>s.
        /// </summary>
        /// <returns>The collection of default <see cref="MediaTypeFormatter"/> instances.</returns>
        private static IEnumerable<MediaTypeFormatter> CreateDefaultFormatters()
        {
            return new MediaTypeFormatter[]
            {
                new JsonMediaTypeFormatter(),
                new XmlMediaTypeFormatter(),
#if !NETFX_CORE
                new FormUrlEncodedMediaTypeFormatter()
#endif
            };
        }

        private void VerifyAndSetFormatters(IEnumerable<MediaTypeFormatter> formatters)
        {
            if (formatters == null)
            {
                throw Error.ArgumentNull("formatters");
            }

            foreach (MediaTypeFormatter formatter in formatters)
            {
                if (formatter == null)
                {
                    throw Error.Argument("formatters", Resources.CannotHaveNullInList, _mediaTypeFormatterType.Name);
                }

                this.Add(formatter);
            }
        }
    }
}
