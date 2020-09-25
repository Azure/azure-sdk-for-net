// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Host.Protocols
{
    /// <summary>
    /// Provides a key to use in place of the .NET type name when deserializing polymorphic objects using
    /// <see cref="PolymorphicJsonConverter"/>.
    /// </summary>
    // TODO (kasobol-msft) this doesn't seem to be relevant for .NET in the extension but might be for other langs supported by functions (see ParameterDescriptors)
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class JsonTypeNameAttribute : Attribute
    {
        private readonly string _typeName;

        /// <summary>Initializes a new instance of the <see cref="JsonTypeNameAttribute"/> class.</summary>
        /// <param name="typeName">The type name to use for serialization.</param>
        public JsonTypeNameAttribute(string typeName)
        {
            if (typeName == null)
            {
                throw new ArgumentNullException(nameof(typeName));
            }

            _typeName = typeName;
        }

        /// <summary>Gets the type name to use for serialization.</summary>
        public string TypeName
        {
            get { return _typeName; }
        }
    }
}
