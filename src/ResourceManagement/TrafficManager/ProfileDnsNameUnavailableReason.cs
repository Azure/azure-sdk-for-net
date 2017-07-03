// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    /// <summary>
    /// The reason for unavailability of traffic manager profile DNS name.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLlByb2ZpbGVEbnNOYW1lVW5hdmFpbGFibGVSZWFzb24=
    public class ProfileDnsNameUnavailableReason : ExpandableStringEnum<ProfileDnsNameUnavailableReason>
    {
        public static readonly ProfileDnsNameUnavailableReason NotValid = Parse("Invalid");
        public static readonly ProfileDnsNameUnavailableReason AlreadyExists = Parse("AlreadyExists");
    }
}
