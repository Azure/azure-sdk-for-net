// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// An attribute class indicating the constructor to use for serialization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor)]
    public class SerializationConstructorAttribute : Attribute
    {
        /// <summary>
        /// Instatiate a new SerializationConstructor attribute.
        /// </summary>
        public SerializationConstructorAttribute()
        {
        }
    }
}
