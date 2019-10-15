// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Specifies the resource types accessible from an account level shared
    /// access signature.
    /// </summary>
    [Flags]
    public enum AccountSasResourceTypes
    {
        /// <summary>
        /// Indicates whether service-level APIs are accessible
        /// from this shared access signature (e.g., Get/Set Service
        /// Properties, Get Service Stats, List Containers/Queues/Tables/
        /// Shares).
        /// </summary>
        Service = 1,

        /// <summary>
        /// Indicates whether blob container-level APIs are accessible
        /// from this shared access signature (e.g., Create/Delete Container,
        /// Create/Delete Queue, Create/Delete Table, Create/Delete Share, List
        /// Blobs/Files and Directories).
        /// </summary>
        Container = 2,

#pragma warning disable CA1720 // Identifier contains type name
        /// <summary>
        /// Indicates whether object-level APIs for blobs, queue
        /// messages, and files are accessible from this shared access
        /// signature (e.g. Put Blob, Query Entity, Get Messages, Create File,
        /// etc.).
        /// </summary>
        Object = 4,
#pragma warning restore CA1720 // Identifier contains type name

        /// <summary>
        /// Indicates all service-level APIs are accessible from this shared
        /// access signature.
        /// </summary>
        All = ~0
    }

    /// <summary>
    /// Extension methods for AccountSasResourceTypes enum
    /// </summary>
    internal static partial class SasExtensions
    {
        /// <summary>
        /// Creates a string representing which resource types are allowed
        /// for <see cref="AccountSasBuilder.ResourceTypes"/>.
        /// </summary>
        /// <returns>
        /// A string representing which resource types are allowed.
        /// </returns>
        internal static string ToPermissionsString(this AccountSasResourceTypes resourceTypes)
        {
            var sb = new StringBuilder();
            if ((resourceTypes & AccountSasResourceTypes.Service) == AccountSasResourceTypes.Service)
            {
                sb.Append(Constants.Sas.AccountResources.Service);
            }
            if ((resourceTypes & AccountSasResourceTypes.Container) == AccountSasResourceTypes.Container)
            {
                sb.Append(Constants.Sas.AccountResources.Container);
            }
            if ((resourceTypes & AccountSasResourceTypes.Object) == AccountSasResourceTypes.Object)
            {
                sb.Append(Constants.Sas.AccountResources.Object);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Parse a string representing which resource types are accessible
        /// from a shared access signature.
        /// </summary>
        /// <param name="s">
        /// A string representing which resource types are accessible.
        /// </param>
        /// <returns>
        /// An <see cref="AccountSasResourceTypes"/> instance.
        /// </returns>
        internal static AccountSasResourceTypes ParseResourceTypes(string s)
        {
            AccountSasResourceTypes types = default;
            foreach (var ch in s)
            {
                types |= ch switch
                {
                    Constants.Sas.AccountResources.Service => AccountSasResourceTypes.Service,
                    Constants.Sas.AccountResources.Container => AccountSasResourceTypes.Container,
                    Constants.Sas.AccountResources.Object => AccountSasResourceTypes.Object,
                    _ => throw Errors.InvalidResourceType(ch),
                };
            }
            return types;
        }

    }
}
