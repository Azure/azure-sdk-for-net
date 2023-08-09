// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Attribute class that indicates which derived type of an abstract class is the unknown subclass.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class UnknownSubclassAttribute : Attribute
    {
        /// <summary>
        /// Instantiates a new instance of the <see cref="UnknownSubclassAttribute"/> class.
        /// </summary>
        /// <param name="unknownSubclass">The type of the unknown subclass.</param>
        public UnknownSubclassAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type unknownSubclass)
        {
            UnknownSubclass = unknownSubclass;
        }

        /// <summary>
        /// Gets the type of the unknown subclass.
        /// </summary>
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
        public Type UnknownSubclass { get; }
    }
}
