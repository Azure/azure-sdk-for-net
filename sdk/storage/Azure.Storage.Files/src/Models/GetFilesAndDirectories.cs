// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Common;
using Azure.Storage.Files.Models;

namespace Azure.Storage.Files.Models
{
    /// <summary>
    /// Specifies options for listing files and directories with the 
    /// <see cref="DirectoryClient.GetFilesAndDirectoriesAsync"/>
    /// operation.
    /// </summary>
    public struct GetFilesAndDirectoriesOptions : IEquatable<GetFilesAndDirectoriesOptions>
    {
        /// <summary>
        /// Gets or sets a string that filters the results to return only
        /// files and directories whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets an optional share snapshot to query.
        /// </summary>
        public string ShareSnapshot { get; set; }

        /// <summary>
        /// Check if two GetFilesAndDirectoriesOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is GetFilesAndDirectoriesOptions other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the GetFilesAndDirectoriesOptions.
        /// </summary>
        /// <returns>Hash code for the GetFilesAndDirectoriesOptions.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            (this.ShareSnapshot?.GetHashCode() ?? 0) ^
            (this.Prefix?.GetHashCode() ?? 0);

        /// <summary>
        /// Check if two GetFilesAndDirectoriesOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(GetFilesAndDirectoriesOptions left, GetFilesAndDirectoriesOptions right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two GetFilesAndDirectoriesOptions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(GetFilesAndDirectoriesOptions left, GetFilesAndDirectoriesOptions right) =>
            !(left == right);

        /// <summary>
        /// Check if two GetFilesAndDirectoriesOptions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(GetFilesAndDirectoriesOptions other) =>
            this.ShareSnapshot == other.ShareSnapshot &&
            this.Prefix == other.Prefix;
    }

    internal class GetFilesAndDirectoriesAsyncCollection : StorageAsyncCollection<StorageFileItem>
    {
        private readonly DirectoryClient _client;
        private readonly GetFilesAndDirectoriesOptions? _options;

        public GetFilesAndDirectoriesAsyncCollection(
            DirectoryClient client,
            GetFilesAndDirectoriesOptions? options,
            CancellationToken cancellationToken)
            : base(cancellationToken)
        {
            this._client = client;
            this._options = options;
        }

        protected override async Task<Page<StorageFileItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            var task = this._client.GetFilesAndDirectoriesAsync(
                continuationToken,
                this._options,
                pageSizeHint,
                isAsync,
                cancellationToken);
            var response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();

            var items = new List<StorageFileItem>();
            items.AddRange(response.Value.DirectoryItems.Select(d => new StorageFileItem(true, d.Name)));
            items.AddRange(response.Value.FileItems.Select(f => new StorageFileItem(false, f.Name, f.Properties?.ContentLength)));
            return new Page<StorageFileItem>(
                items.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }

    /// <summary>
    /// Describes a file or directory returned by
    /// <see cref="DirectoryClient.GetFilesAndDirectoriesAsync"/>.
    /// </summary>
    public class StorageFileItem
    {
        /// <summary>
        /// Gets a value indicating whether this item is a directory.
        /// </summary>
        public bool IsDirectory { get; }

        /// <summary>
        /// Gets the name of this item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets an optional value indicating the file size, if this item is
        /// a file.
        /// </summary>
        public long? FileSize { get; }

        internal StorageFileItem(bool isDirectory, string name, long? fileSize = null)
        {
            this.IsDirectory = isDirectory;
            this.Name = name;
            this.FileSize = fileSize;
        }
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new StorageFileItem instance for mocking.
        /// </summary>
        public static StorageFileItem StorageFileItem(
            bool isDirectory, string name, long? fileSize) =>
            new StorageFileItem(isDirectory, name, fileSize);
    }
}
