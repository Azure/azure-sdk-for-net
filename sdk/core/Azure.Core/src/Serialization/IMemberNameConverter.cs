// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Converts type member names to serializable member names.
    /// </summary>
    public interface IMemberNameConverter
    {
        /// <summary>
        /// Converts a <see cref="MemberInfo"/> to a serializable member name.
        /// </summary>
        /// <param name="member">The <see cref="MemberInfo"/> to convert to a serializable member name.</param>
        /// <returns>The serializable member name, or null if the member is not defined or ignored by the serializer.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="member"/> is null.</exception>
        string? ConvertMemberName(MemberInfo member);
    }
}
