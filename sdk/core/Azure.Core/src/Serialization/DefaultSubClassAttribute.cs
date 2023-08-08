// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Attribute class that indicates which derived type of an abstract class is the default subclass.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DefaultSubClassAttribute : Attribute
    {
        /// <summary>
        /// Instantiates a new instance of the <see cref="DefaultSubClassAttribute"/> class.
        /// </summary>
        /// <param name="type">The type of the default subclass.</param>
        public DefaultSubClassAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type type)
        {
            DefaultSubClass = type;
        }

        /// <summary>
        /// Gets the type of the default subclass.
        /// </summary>
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
        public Type DefaultSubClass { get; }
    }
}
