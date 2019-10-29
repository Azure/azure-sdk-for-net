// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Specifies the services accessible from an account level shared access
    /// signature.
    /// </summary>
    [Flags]
    public enum AccountSasServices
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
        /// Indicates all services are accessible from the shared
        /// access signature.
        /// </summary>
        All = ~0
    }

    /// <summary>
    /// Extension methods for AccountSasServices enum
    /// </summary>
    internal static partial class SasExtensions
    {
        /// <summary>
        /// Creates a string representing which services can be used for
        /// <see cref="AccountSasBuilder.Services"/>.
        /// </summary>
        /// <returns>
        /// A string representing which services are allowed.
        /// </returns>
        internal static string ToPermissionsString(this AccountSasServices services)
        {
            var sb = new StringBuilder();
            if ((services & AccountSasServices.Blobs) == AccountSasServices.Blobs)
            {
                sb.Append(Constants.Sas.AccountServices.Blob);
            }
            if ((services & AccountSasServices.Queues) == AccountSasServices.Queues)
            {
                sb.Append(Constants.Sas.AccountServices.Queue);
            }
            if ((services & AccountSasServices.Files) == AccountSasServices.Files)
            {
                sb.Append(Constants.Sas.AccountServices.File);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Parse a string representing which services are accessible from a
        /// shared access signature.
        /// </summary>
        /// <param name="s">
        /// A string representing which services are accessible.
        /// </param>
        /// <returns>
        /// An <see cref="AccountSasServices"/> instance.
        /// </returns>
        internal static AccountSasServices ParseAccountServices(string s)
        {
            AccountSasServices svcs = default;
            foreach (var ch in s)
            {
                svcs |= ch switch
                {
                    Constants.Sas.AccountServices.Blob => AccountSasServices.Blobs,
                    Constants.Sas.AccountServices.Queue => AccountSasServices.Queues,
                    Constants.Sas.AccountServices.File => AccountSasServices.Files,
                    _ => throw Errors.InvalidService(ch),
                };
            }
            return svcs;
        }
    }
}
