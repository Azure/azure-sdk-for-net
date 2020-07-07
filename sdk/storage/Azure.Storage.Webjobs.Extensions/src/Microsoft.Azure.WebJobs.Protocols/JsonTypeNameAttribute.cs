// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>
    /// Provides a key to use in place of the .NET type name when deserializing polymorphic objects using
    /// <see cref="PolymorphicJsonConverter"/>.
    /// </summary>
#if PUBLICPROTOCOL
    public sealed class JsonTypeNameAttribute : Attribute
#else
    internal sealed class JsonTypeNameAttribute : Attribute
#endif
    {
        private readonly string _typeName;

        /// <summary>Initializes a new instance of the <see cref="JsonTypeNameAttribute"/> class.</summary>
        /// <param name="typeName">The type name to use for serialization.</param>
        public JsonTypeNameAttribute(string typeName)
        {
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName");
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
