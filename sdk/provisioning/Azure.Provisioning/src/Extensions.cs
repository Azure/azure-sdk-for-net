// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning
{
    internal static class Extensions
    {
        public static string ToCamelCase(this string str)
        {
#if NET6_0_OR_GREATER
            return char.ToLowerInvariant(str[0]) + str[1..];
#else
            return char.ToLowerInvariant(str[0]) + str.Substring(1);
#endif
        }

        public static bool IsChildResource(this Resource resource)
        {
            //TODO: this is a bit of a hack. We should probably have a better way to determine if a resource is a child resource
            return resource.Parent is not null &&
                   resource.Parent is not ResourceGroup &&
                   resource.Parent is not Subscription &&
                   resource is not DeploymentScript &&
                   resource is not Subscription &&
                   resource is not RoleAssignment;
        }

        public static void Write(this MemoryStream stream, string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
#if NET6_0_OR_GREATER
            stream.Write(bytes);
#else
            stream.Write(bytes, 0, bytes.Length);
#endif
        }

        public static void WriteLine(this MemoryStream stream, string? value = null)
        {
            value ??= string.Empty;
            var bytes = Encoding.UTF8.GetBytes($"{value}{Environment.NewLine}");
#if NET6_0_OR_GREATER
            stream.Write(bytes);
#else
            stream.Write(bytes, 0, bytes.Length);
#endif
        }

        public static void Write(this MemoryStream stream, byte[] value)
        {
#if NET6_0_OR_GREATER
            stream.Write(value);
#else
            stream.Write(value, 0, value.Length);
#endif
        }
    }
}
