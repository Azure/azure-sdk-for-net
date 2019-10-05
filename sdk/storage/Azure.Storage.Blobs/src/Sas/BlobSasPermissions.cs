// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="BlobSasPermissions"/> supports reading and writing
    /// permissions string for a blob's access policy.  Use ToString
    /// to generate a permissions string you can provide to
    /// <see cref="BlobSasBuilder.Permissions"/>.
    /// </summary>
    [Flags]
    public enum BlobSasPermissions
    {
        /// <summary>
        ///
        /// </summary>
        None = 0,

        /// <summary>
        /// Get or sets whether Read is permitted.
        /// </summary>
        Read = 1,

        /// <summary>
        /// Get or sets whether Add is permitted.
        /// </summary>
        Add = 2,

        /// <summary>
        /// Get or sets whether Create is permitted.
        /// </summary>
        Create = 4,

        /// <summary>
        /// Get or sets whether Write is permitted.
        /// </summary>
        Write = 8,

        /// <summary>
        /// Get or sets whether Delete is permitted.
        /// </summary>
        Delete = 16,

        /// <summary>
        ///
        /// </summary>
        All = ~None
    }
}

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Blob enum extensions
    /// </summary>
    internal static partial class BlobExtensions
    {

        /// <summary>
        /// Create a permissions string to provide
        /// <see cref="BlobSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        public static string ToPermissionsString(this BlobSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & BlobSasPermissions.Read) == BlobSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & BlobSasPermissions.Add) == BlobSasPermissions.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }
            if ((permissions & BlobSasPermissions.Create) == BlobSasPermissions.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }
            if ((permissions & BlobSasPermissions.Write) == BlobSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & BlobSasPermissions.Delete) == BlobSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Parse a permissions string into a new <see cref="BlobSasPermissions"/>.
        /// </summary>
        /// <param name="s">Permissions string to parse.</param>
        /// <returns>The parsed <see cref="BlobSasPermissions"/>.</returns>
        public static BlobSasPermissions Parse(string s)
        {
            // Clear the flags
            BlobSasPermissions p = BlobSasPermissions.None;
            foreach (var c in s)
            {
                p |= c switch
                {
                    Constants.Sas.Permissions.Read => BlobSasPermissions.Read,
                    Constants.Sas.Permissions.Add => BlobSasPermissions.Add,
                    Constants.Sas.Permissions.Create => BlobSasPermissions.Create,
                    Constants.Sas.Permissions.Write => BlobSasPermissions.Write,
                    Constants.Sas.Permissions.Delete => BlobSasPermissions.Delete,
                    _ => throw Errors.InvalidPermission(c),
                };
            }
            return p;
        }
    }
}
