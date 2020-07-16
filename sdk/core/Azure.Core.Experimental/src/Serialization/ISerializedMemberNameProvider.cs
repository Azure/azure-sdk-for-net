// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

namespace Azure.Core
{
    /// <summary>
    /// Provides mappings for member names to serialized property names.
    /// </summary>
    public interface ISerializedMemberNameProvider
    {
        /// <summary>
        /// Maps a member <see cref="MemberInfo.Name"/> to a serialized property name.
        /// </summary>
        /// <param name="memberInfo">The <see cref="MemberInfo"/> to map to a serialized property name.</param>
        /// <returns>The serialized property name, or null if the member is not defined or ignored by the serializer.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="memberInfo"/> is null.</exception>
        string? GetSerializedMemberName(MemberInfo memberInfo);
    }
}
