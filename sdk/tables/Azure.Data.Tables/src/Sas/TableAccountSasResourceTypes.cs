// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Data.Tables.Sas;

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// Specifies the resource types accessible from an account level shared
    /// access signature.
    /// </summary>
    [Flags]
    public enum TableAccountSasResourceTypes
    {
        /// <summary>
        /// Indicates whether service-level APIs are accessible
        /// from this shared access signature (e.g., Get/Set Service
        /// Properties, Get Service Stats, List Tables).
        /// </summary>
        Service = 1,

        /// <summary>
        /// Indicates whether table account-level APIs are accessible
        /// from this shared access signature (e.g. Create/Delete/Query Table).
        /// </summary>
        Container = 2,

#pragma warning disable CA1720 // Identifier contains type name
        /// <summary>
        /// Indicates whether entity-level APIs are accessible from this shared access
        /// signature (e.g. Query/Insert/Update/Delete entity).
        /// </summary>
        Object = 4,
#pragma warning restore CA1720 // Identifier contains type name

        /// <summary>
        /// Indicates all service-level APIs are accessible from this shared
        /// access signature.
        /// </summary>
        All = ~0
    }
}

namespace Azure.Data.Tables
{
    internal static partial class TableExtensions
    {
        /// <summary>
        /// Creates a string representing which resource types are allowed
        /// for <see cref="TableAccountSasBuilder.ResourceTypes"/>.
        /// </summary>
        /// <returns>
        /// A string representing which resource types are allowed.
        /// </returns>
        /// <remarks>
        /// The order here matches the order used by the portal when generating SAS signatures.
        /// </remarks>
        internal static string ToPermissionsString(this TableAccountSasResourceTypes resourceTypes)
        {
            var sb = new StringBuilder();
            if ((resourceTypes & TableAccountSasResourceTypes.Service) == TableAccountSasResourceTypes.Service)
            {
                sb.Append(TableConstants.Sas.TableAccountResources.Service);
            }
            if ((resourceTypes & TableAccountSasResourceTypes.Container) == TableAccountSasResourceTypes.Container)
            {
                sb.Append(TableConstants.Sas.TableAccountResources.Container);
            }
            if ((resourceTypes & TableAccountSasResourceTypes.Object) == TableAccountSasResourceTypes.Object)
            {
                sb.Append(TableConstants.Sas.TableAccountResources.Object);
            }
            return sb.ToString();
        }
    }
}
