// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.AspNetServer.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Microsoft.TypeSpec.Generator.AspNetServer
{
    /// <summary>
    /// Type factory for the ASP.NET server generator. Routes model and primitive
    /// type creation to the simplified server-side providers (POCOs) instead of
    /// the default client-model providers (which emit serialization machinery
    /// the server side does not need).
    /// </summary>
    public sealed class AspNetServerTypeFactory : TypeFactory
    {
        private readonly Dictionary<InputModelType, ServerModelProvider> _modelCache = new();

        /// <summary>Initializes a new instance of <see cref="AspNetServerTypeFactory"/>.</summary>
        public AspNetServerTypeFactory()
        {
        }

        /// <inheritdoc/>
        protected override ModelProvider? CreateModelCore(InputModelType model)
        {
            if (_modelCache.TryGetValue(model, out var existing))
            {
                return existing;
            }

            var provider = new ServerModelProvider(model);
            _modelCache[model] = provider;
            return provider;
        }

        /// <inheritdoc/>
        protected override CSharpType? CreateCSharpTypeCore(InputType inputType)
        {
            return inputType switch
            {
                InputPrimitiveType p => MapPrimitive(p),
                InputDateTimeType => typeof(DateTimeOffset),
                InputDurationType => typeof(TimeSpan),
                InputArrayType array => new CSharpType(typeof(IList<>), CreateCSharpType(array.ValueType) ?? typeof(object)),
                InputDictionaryType dict => new CSharpType(
                    typeof(IDictionary<,>),
                    CreateCSharpType(dict.KeyType) ?? typeof(string),
                    CreateCSharpType(dict.ValueType) ?? typeof(object)),
                InputLiteralType literal => CreateCSharpType(literal.ValueType),
                InputEnumType => typeof(string), // MVP: emit enum-typed properties as string
                InputModelType model => CreateModel(model)?.Type,
                InputNullableType nullable => (CreateCSharpType(nullable.Type) ?? typeof(object)).WithNullable(true),
                _ => typeof(object),
            };
        }

        private static CSharpType MapPrimitive(InputPrimitiveType primitive)
        {
            return primitive.Kind switch
            {
                InputPrimitiveTypeKind.Boolean => typeof(bool),
                InputPrimitiveTypeKind.String => typeof(string),
                InputPrimitiveTypeKind.Int32 => typeof(int),
                InputPrimitiveTypeKind.Int64 => typeof(long),
                InputPrimitiveTypeKind.Float32 => typeof(float),
                InputPrimitiveTypeKind.Float64 => typeof(double),
                InputPrimitiveTypeKind.Decimal => typeof(decimal),
                InputPrimitiveTypeKind.Decimal128 => typeof(decimal),
                InputPrimitiveTypeKind.Bytes => typeof(byte[]),
                InputPrimitiveTypeKind.Url => typeof(Uri),
                InputPrimitiveTypeKind.SafeInt => typeof(long),
                InputPrimitiveTypeKind.PlainDate => typeof(DateTimeOffset),
                InputPrimitiveTypeKind.PlainTime => typeof(TimeSpan),
                _ => typeof(string),
            };
        }
    }
}
