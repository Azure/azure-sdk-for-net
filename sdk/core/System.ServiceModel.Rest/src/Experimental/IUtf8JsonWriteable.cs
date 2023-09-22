// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ServiceModel.Rest.Experimental.Core.Serialization
{
    /// <summary>
    /// TBD.
    /// </summary>
    public interface IUtf8JsonWriteable
    {
#pragma warning disable AZC0014 // Avoid using banned types in public API
        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="writer"></param>
        void Write(Utf8JsonWriter writer);
#pragma warning restore AZC0014 // Avoid using banned types in public API
    }
}
