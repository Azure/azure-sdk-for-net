// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Provides the client options for serializing models.
    /// </summary>
    public class ModelSerializerOptions
    {
        private static readonly IReadOnlyDictionary<ModelSerializerFormat, ModelSerializerOptions> _singletonMap = new Dictionary<ModelSerializerFormat, ModelSerializerOptions>()
        {
            { ModelSerializerFormat.Json, new ModelSerializerOptions(ModelSerializerFormat.Json, true) },
            { ModelSerializerFormat.Wire, new ModelSerializerOptions(ModelSerializerFormat.Wire, true) }
        };

        /// <summary>
        /// Default options for serializing models into the format the Azure serivce is expecting.
        /// </summary>
        public static readonly ModelSerializerOptions DefaultWireOptions = _singletonMap[ModelSerializerFormat.Wire];

        internal static ModelSerializerOptions GetOptions(ModelSerializerFormat format)
            => _singletonMap.TryGetValue(format, out ModelSerializerOptions? options) ? options! : new ModelSerializerOptions(format);

        private bool _isFrozen;
        private Func<Type, ObjectSerializer>? _genericTypeSerializerCreator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSerializerOptions" /> class. Defaults to format <see cref="ModelSerializerFormat.Json"/>.
        /// </summary>
        public ModelSerializerOptions() : this(ModelSerializerFormat.Json, false) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSerializerOptions" /> class.
        /// </summary>
        /// <param name="format">String that determines <see cref="ModelSerializerFormat"/> of serialized model..</param>
        public ModelSerializerOptions(ModelSerializerFormat format) : this(format, false) { }

        private ModelSerializerOptions(ModelSerializerFormat format, bool isFrozen)
        {
            Format = format;
            _isFrozen = isFrozen;
        }

        /// <summary>
        /// Gets the <see cref="ModelSerializerFormat"/> that determines format of serialized model.
        /// </summary>
        public ModelSerializerFormat Format { get; }

        /// <summary>
        /// Gets or sets a factory method that returns an <see cref="ObjectSerializer"/> based on the provided <see cref="Type"/>.
        /// Should return <c>null</c> if the type is not supported.
        /// </summary>
        public Func<Type, ObjectSerializer>? ObjectSerializerResolver
        {
            get
            {
                return _genericTypeSerializerCreator;
            }
            set
            {
                if (_isFrozen)
                {
                    throw new InvalidOperationException("Cannot modify static options reference.");
                }

                _genericTypeSerializerCreator = value;
            }
        }
    }
}
