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
namespace Microsoft.Hadoop.Avro.Serializers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Reflection;
    using Microsoft.Hadoop.Avro.Schema;

    internal abstract class ObjectSerializerBase<TSchema> : IObjectSerializer
        where TSchema : TypeSchema
    {
        private static readonly Dictionary<Type, string> DecoderTypes = new Dictionary<Type, string>
        {
            { typeof(long), "Long" },
            { typeof(int), "Int" },
            { typeof(bool), "Bool" },
            { typeof(byte[]), "ByteArray" },
            { typeof(float), "Float" },
            { typeof(double), "Double" },
            { typeof(string), "String" },
        };

        private static readonly Dictionary<string, MethodInfo> Encoders = new Dictionary<string, MethodInfo>
        {
            { "ArrayChunk", typeof(IEncoder).GetMethod("EncodeArrayChunk") },
            { "MapChunk", typeof(IEncoder).GetMethod("EncodeMapChunk") },
            { "Fixed", typeof(IEncoder).GetMethod("EncodeFixed") }
        };

        private static readonly Dictionary<string, MethodInfo> Decoders = new Dictionary<string, MethodInfo>
        {
            { "ArrayChunk", typeof(IDecoder).GetMethod("DecodeArrayChunk") },
            { "MapChunk", typeof(IDecoder).GetMethod("DecodeMapChunk") },
            { "Fixed", typeof(IDecoder).GetMethod("DecodeFixed") }
        };

        private static readonly Dictionary<string, MethodInfo> Skippers = new Dictionary<string, MethodInfo>
        {
            { "Fixed", typeof(ISkipper).GetMethod("SkipFixed") }
        };

        protected static readonly Expression ConstantZero = Expression.Constant(0);

        private readonly TSchema schema;

        protected ObjectSerializerBase(TSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException("schema");
            }

            this.schema = schema;
        }

        protected MethodInfo Encode(string value)
        {
            if (!Encoders.ContainsKey(value))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Requested method '{0}' is not found.", value));
            }
            return Encoders[value];
        }

        protected MethodInfo Decode(string value)
        {
            if (!Decoders.ContainsKey(value))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Requested method '{0}' is not found.", value));
            }
            return Decoders[value];
        }

        protected MethodInfo Skip(string value)
        {
            if (!Skippers.ContainsKey(value))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Requested method '{0}' is not found.", value));
            }
            return Skippers[value];
        }

        protected MethodInfo Encode<T>()
        {
            var result = typeof(IEncoder).GetMethod("Encode", new[] { typeof(T) });
            if (result == null)
            {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.InvariantCulture, "Requested method Encode({0}) is not found.", typeof(T)));
            }
            return result;
        }

        protected MethodInfo Decode<T>()
        {
            return this.GetDecoderMethod<T>("Decode", typeof(IDecoder));
        }

        protected MethodInfo Skip<T>()
        {
            return this.GetDecoderMethod<T>("Skip", typeof(ISkipper));
        }

        private MethodInfo GetDecoderMethod<T>(string genericMethodName, Type decoderType)
        {
            if (!DecoderTypes.ContainsKey(typeof(T)))
            {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.InvariantCulture, "Requested method is not found for type '{0}'.", typeof(T)));
            }
            var result = decoderType.GetMethod(genericMethodName + DecoderTypes[typeof(T)]);
            if (result == null)
            {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.InvariantCulture, "Requested method is not found."));
            }
            return result;
        }

        public Expression BuildSerializer(Expression encoder, Expression value)
        {
            if (encoder == null)
            {
                throw new ArgumentNullException("encoder");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return this.BuildSerializerSafe(encoder, value);
        }

        public Expression BuildDeserializer(Expression decoder)
        {
            if (decoder == null)
            {
                throw new ArgumentNullException("decoder");
            }

            return this.BuildDeserializerSafe(decoder);
        }

        public Expression BuildSkipper(Expression decoder)
        {
            if (decoder == null)
            {
                throw new ArgumentNullException("decoder");
            }

            return this.BuildSkipperSafe(decoder);
        }

        public void Serialize(IEncoder encoder, object value)
        {
            if (encoder == null)
            {
                throw new ArgumentNullException("encoder");
            }

            this.SerializeSafe(encoder, value);
        }

        public object Deserialize(IDecoder decoder)
        {
            if (decoder == null)
            {
                throw new ArgumentNullException("decoder");
            }

            return this.DeserializeSafe(decoder);
        }

        public void Skip(IDecoder decoder)
        {
            if (decoder == null)
            {
                throw new ArgumentNullException("decoder");
            }

            this.SkipSafe(decoder);
        }

        protected virtual Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            throw new InvalidOperationException();
        }

        protected virtual Expression BuildDeserializerSafe(Expression decoder)
        {
            throw new InvalidOperationException();
        }

        protected virtual Expression BuildSkipperSafe(Expression decoder)
        {
            throw new InvalidOperationException();
        }

        protected virtual void SerializeSafe(IEncoder encoder, object value)
        {
            throw new InvalidOperationException();
        }

        protected virtual object DeserializeSafe(IDecoder decoder)
        {
            throw new InvalidOperationException();
        }

        protected virtual void SkipSafe(IDecoder decoder)
        {
            throw new InvalidOperationException();
        }

        protected TSchema Schema
        {
            get { return this.schema; }
        }
    }
}
