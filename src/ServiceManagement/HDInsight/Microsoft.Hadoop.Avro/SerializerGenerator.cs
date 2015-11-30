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
namespace Microsoft.Hadoop.Avro
{
    using System;
    using System.Linq.Expressions;
    using Microsoft.Hadoop.Avro.Schema;

    internal sealed class SerializerGenerator
    {
        public Action<IEncoder, T> GenerateSerializer<T>(TypeSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException("schema");
            }

            ParameterExpression instance = Expression.Parameter(typeof(T), "instance");
            ParameterExpression encoder = Expression.Parameter(typeof(IEncoder), "encoder");

            var result = schema.Serializer.BuildSerializer(encoder, instance);
            Type resultingFunctionType = typeof(Action<,>).MakeGenericType(new[] { typeof(IEncoder), typeof(T) });
            LambdaExpression lambda = Expression.Lambda(resultingFunctionType, result, encoder, instance);
            return lambda.Compile() as Action<IEncoder, T>;
        }

        public Func<IDecoder, T> GenerateDeserializer<T>(TypeSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException("schema");
            }

            ParameterExpression decoder = Expression.Parameter(typeof(IDecoder), "decoder");

            Expression result = schema.Serializer.BuildDeserializer(decoder);
            Type resultingFunctionType = typeof(Func<,>).MakeGenericType(new[] { typeof(IDecoder), typeof(T) });
            LambdaExpression lambda = Expression.Lambda(resultingFunctionType, result, decoder);
            return lambda.Compile() as Func<IDecoder, T>;
        }
    }
}
