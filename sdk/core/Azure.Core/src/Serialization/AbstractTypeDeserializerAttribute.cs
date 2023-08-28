// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Attribute class that indicates which subtype of an abstract class is the <see cref="Type"/>
    /// that knows how to deserialize the hierarchy.  The type should be able to determine which subtype should be deserialized
    /// and return an instance of that subtype.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class AbstractTypeDeserializerAttribute : Attribute
    {
        /// <summary>
        /// Instantiates a new instance of the <see cref="AbstractTypeDeserializerAttribute"/> class.
        /// </summary>
        /// <param name="deserializationProxy">The <see cref="Type"/> to create and call deserialize on.</param>
        public AbstractTypeDeserializerAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type deserializationProxy)
        {
            DeserializationProxy = deserializationProxy;
        }

        /// <summary>
        /// Gets the <see cref="Type"/> to create and call deserialize on.
        /// The type must have a public or non-public parameterless constructor.
        /// The type must implement <see cref="IModelSerializable{T}"/> where T is the type of the abstract class.
        /// </summary>
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
        public Type DeserializationProxy { get; }
    }
}
