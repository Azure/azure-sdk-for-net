// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlobContainerClient.GetBlobsByHierarchyAsync(GetBlobsByHierarchyOptions, System.Threading.CancellationToken)"/>
    /// </summary>
    public class GetBlobsByHierarchyOptions
    {
        /// <summary>
        /// Optional.  Specifies trait options for shaping the blobs.
        /// </summary>
        public BlobTraits Traits { get; set; }

        /// <summary>
        /// Optional.  Specifies state options for filtering the blobs.
        /// </summary>
        public BlobStates States { get; set; }

        /// <summary>
        /// A delimiter that can be used to traverse a
        /// virtual hierarchy of blobs as though it were a file system.  The
        /// delimiter may be a single character or a string.
        /// <see cref="BlobHierarchyItem.Prefix"/> will be returned
        /// in place of all blobs whose names begin with the same substring up
        /// to the appearance of the delimiter character.  The value of a
        /// prefix is substring+delimiter, where substring is the common
        /// substring that begins one or more blob  names, and delimiter is the
        /// value of delimiter. You can use the value of
        /// prefix to make a subsequent call to list the blobs that begin with
        /// this prefix, by specifying the value of the prefix for the
        /// <see cref="Prefix"/>
        ///
        /// Note that each BlobPrefix element returned counts toward the
        /// maximum result, just as each Blob element does.
        /// </summary>
        public string Delimiter { get; set; }

        /// <summary>
        /// Optional.  Specifies a string that filters the results to return only blobs
        /// whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Optional.  Specifies a fully qualified path within the container, similar to how the prefix parameter
        /// is used to list paths starting from a defined location within prefix’s specified range.
        /// For non-recursive list, only one entity level is supported.
        /// For recursive list, multiple entity levels are supported. (Inclusive).
        /// </summary>
        public string StartFrom { get; set; }
    }
}
