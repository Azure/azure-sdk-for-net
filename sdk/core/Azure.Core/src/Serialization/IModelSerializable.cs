// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// TODO
    /// </summary>
    public interface IModelSerializable
    {
        /// <summary>
        /// .
        /// </summary>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        Stream Serialize(ModelSerializerOptions options);
#pragma warning restore AZC0014 // Avoid using banned types in public API
    }
}
