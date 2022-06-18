// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager
{
    /// <summary>
    /// An attribute class indicating to test generator of AutoRest for the serialized name of a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class PropertySerializedNameAttribute : Attribute
    {
        public PropertySerializedNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
