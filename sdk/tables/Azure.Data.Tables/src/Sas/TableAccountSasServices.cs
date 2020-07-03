// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Data.Tables.Sas;

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// Specifies the services accessible from an account level shared access
    /// signature.
    /// </summary>
    [Flags]
    public enum TableAccountSasServices
    {
        /// <summary>
        /// Indicates whether Azure Blob Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        Blobs = 1,

        /// <summary>
        /// Indicates whether Azure Queue Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        Queues = 2,

        /// <summary>
        /// Indicates whether Azure File Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        Files = 4,

        /// <summary>
        /// Indicates whether Azure Table Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        Tables = 8,

        /// <summary>
        /// Indicates all services are accessible from the shared
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
        /// Creates a string representing which services can be used for
        /// <see cref="TableAccountSasBuilder.Services"/>.
        /// </summary>
        /// <returns>
        /// A string representing which services are allowed.
        /// </returns>
        /// <remarks>
        /// The order here matches the order used by the portal when generating SAS signatures.
        /// </remarks>
        internal static string ToPermissionsString(this TableAccountSasServices services)
        {
            var sb = new StringBuilder();
            if ((services & TableAccountSasServices.Blobs) == TableAccountSasServices.Blobs)
            {
                sb.Append(TableConstants.Sas.TableAccountServices.Blob);
            }
            if ((services & TableAccountSasServices.Files) == TableAccountSasServices.Files)
            {
                sb.Append(TableConstants.Sas.TableAccountServices.File);
            }
            if ((services & TableAccountSasServices.Queues) == TableAccountSasServices.Queues)
            {
                sb.Append(TableConstants.Sas.TableAccountServices.Queue);
            }
            if ((services & TableAccountSasServices.Tables) == TableAccountSasServices.Tables)
            {
                sb.Append(TableConstants.Sas.TableAccountServices.Table);
            }
            return sb.ToString();
        }
    }
}
