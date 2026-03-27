// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Azure.Core;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.Files.Shares
{
    internal static partial class ShareExtensions
    {
        internal static void AssertValidFilePermissionAndKey(string filePermission, string filePermissionKey)
        {
            if (filePermission != null && Encoding.UTF8.GetByteCount(filePermission) > Constants.File.MaxFilePermissionHeaderSize)
            {
                throw Errors.MustBeLessThanOrEqualTo(nameof(filePermission), Constants.File.MaxFilePermissionHeaderSize);
            }

            if (filePermission != null && filePermissionKey != null)
            {
                throw new ArgumentException("filePermission and filePermissionKey cannot both be set");
            }
        }

        internal static string ToFileDateTimeString(this DateTimeOffset? dateTimeOffset)
            => dateTimeOffset.HasValue ? ToFileDateTimeString(dateTimeOffset.Value) : null;

        private static string ToFileDateTimeString(this DateTimeOffset dateTimeOffset)
            => dateTimeOffset.UtcDateTime.ToString(Constants.File.FileTimeFormat, CultureInfo.InvariantCulture);

        internal static string ToShareEnableProtocolsString(this ShareProtocols? shareEnabledProtocols)
        {
            if (shareEnabledProtocols == null)
            {
                return null;
            }

            return shareEnabledProtocols switch
            {
                ShareProtocols.Smb => Constants.File.SmbProtocol,
                ShareProtocols.Nfs => Constants.File.NfsProtocol,
                _ => throw new ArgumentException($"Unknown share protocol: {shareEnabledProtocols}"),
            };
        }

        internal static DeleteSnapshotsOptionType? ToShareSnapshotsDeleteOptionInternal(this ShareSnapshotsDeleteOption? option)
        {
            if (option == null)
            {
                return null;
            }
            return option switch
            {
                ShareSnapshotsDeleteOption.Include => DeleteSnapshotsOptionType.Include,
                ShareSnapshotsDeleteOption.IncludeWithLeased => DeleteSnapshotsOptionType.IncludeLeased,
                _ => throw new ArgumentException($"Invalid {nameof(ShareSnapshotsDeleteOption)}: {option}"),
            };
        }

        internal static ShareProtocols? ToShareEnabledProtocols(string rawProtocols)
        {
            if (rawProtocols == null)
            {
                return null;
            }

            string[] split = rawProtocols.Split(',');

            int result = 0;

            foreach (string s in split)
            {
                switch (s)
                {
                    case Constants.File.SmbProtocol:
                        result |= (int)ShareProtocols.Smb;
                        break;
                    case Constants.File.NfsProtocol:
                        result |= (int)ShareProtocols.Nfs;
                        break;
                }
            }

            if (result == 0)
            {
                return null;
            }

            return (ShareProtocols)result;
        }

        internal enum ShareDirectoryInfoHeaderType
        {
            Create,
            SetProperties,
            SetMetadata
        }

        internal static ShareDirectoryInfo ToShareDirectoryInfo(this Response response, ShareDirectoryInfoHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            const string FileAttributesHeader = "x-ms-file-attributes";
            const string FilePermissionKeyHeader = "x-ms-file-permission-key";
            const string FileCreationTimeHeader = "x-ms-file-creation-time";
            const string FileLastWriteTimeHeader = "x-ms-file-last-write-time";
            const string FileChangeTimeHeader = "x-ms-file-change-time";
            const string FileIdHeader = "x-ms-file-id";
            const string FileParentIdHeader = "x-ms-file-parent-id";
            const string FileModeHeader = "x-ms-mode";
            const string OwnerHeader = "x-ms-owner";
            const string GroupHeader = "x-ms-group";
            const string NfsFileTypeHeader = "x-ms-file-file-type";

            switch (headerType)
            {
                case ShareDirectoryInfoHeaderType.Create:
                    return new ShareDirectoryInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                        SmbProperties = new FileSmbProperties
                        {
                            FileAttributes = ShareModelExtensions.ToFileAttributes(response.Headers.TryGetValue(FileAttributesHeader, out string fileAttributes) ? fileAttributes : null),
                            FilePermissionKey = response.Headers.TryGetValue(FilePermissionKeyHeader, out string filePermissionKey) ? filePermissionKey : null,
                            FileCreatedOn = response.Headers.TryGetValue(FileCreationTimeHeader, out DateTimeOffset? fileCreationTime) ? fileCreationTime : null,
                            FileLastWrittenOn = response.Headers.TryGetValue(FileLastWriteTimeHeader, out DateTimeOffset? fileLastWriteTime) ? fileLastWriteTime : null,
                            FileChangedOn = response.Headers.TryGetValue(FileChangeTimeHeader, out DateTimeOffset? fileChangeTime) ? fileChangeTime : null,
                            FileId = response.Headers.TryGetValue(FileIdHeader, out string fileId) ? fileId : null,
                            ParentId = response.Headers.TryGetValue(FileParentIdHeader, out string fileParentId) ? fileParentId : null
                        },
                        PosixProperties = new FilePosixProperties
                        {
                            FileMode = NfsFileMode.ParseOctalFileMode(response.Headers.TryGetValue(FileModeHeader, out string fileMode) ? fileMode : null),
                            Owner = response.Headers.TryGetValue(OwnerHeader, out string owner) ? owner : null,
                            Group = response.Headers.TryGetValue(GroupHeader, out string group) ? group : null,
                            FileType = response.Headers.TryGetValue(NfsFileTypeHeader, out string nfsFileType) ? (NfsFileType?)nfsFileType : null,
                        }
                    };
                case ShareDirectoryInfoHeaderType.SetProperties:
                    return new ShareDirectoryInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string spValue) ? new ETag(spValue) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? spLastModified) ? spLastModified.GetValueOrDefault() : default,
                        SmbProperties = new FileSmbProperties
                        {
                            FileAttributes = ShareModelExtensions.ToFileAttributes(response.Headers.TryGetValue(FileAttributesHeader, out string spFileAttributes) ? spFileAttributes : null),
                            FilePermissionKey = response.Headers.TryGetValue(FilePermissionKeyHeader, out string spFilePermissionKey) ? spFilePermissionKey : null,
                            FileCreatedOn = response.Headers.TryGetValue(FileCreationTimeHeader, out DateTimeOffset? spFileCreationTime) ? spFileCreationTime : null,
                            FileLastWrittenOn = response.Headers.TryGetValue(FileLastWriteTimeHeader, out DateTimeOffset? spFileLastWriteTime) ? spFileLastWriteTime : null,
                            FileChangedOn = response.Headers.TryGetValue(FileChangeTimeHeader, out DateTimeOffset? spFileChangeTime) ? spFileChangeTime : null,
                            FileId = response.Headers.TryGetValue(FileIdHeader, out string spFileId) ? spFileId : null,
                            ParentId = response.Headers.TryGetValue(FileParentIdHeader, out string spFileParentId) ? spFileParentId : null
                        },
                        PosixProperties = new FilePosixProperties
                        {
                            FileMode = NfsFileMode.ParseOctalFileMode(response.Headers.TryGetValue(FileModeHeader, out string spFileMode) ? spFileMode : null),
                            Owner = response.Headers.TryGetValue(OwnerHeader, out string spOwner) ? spOwner : null,
                            Group = response.Headers.TryGetValue(GroupHeader, out string spGroup) ? spGroup : null
                        }
                    };
                case ShareDirectoryInfoHeaderType.SetMetadata:
                    // Set Directory metadata returns limited response headers - https://docs.microsoft.com/en-us/rest/api/storageservices/set-directory-metadata.
                    return new ShareDirectoryInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string smdValue) ? new ETag(smdValue) : default,
                        SmbProperties = new FileSmbProperties(),
                        LastModified = response.Headers.ExtractLastModified()
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(ShareDirectoryInfoHeaderType)}: {headerType}", nameof(headerType));
            }
        }

        internal static ShareDirectoryProperties ToShareDirectoryProperties(this Response response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareDirectoryProperties()
            {
                Metadata = response.Headers.TryGetValue(Constants.HeaderNames.MetadataPrefix, out IDictionary<string, string> metadata) ? metadata : null,
                ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                IsServerEncrypted = response.Headers.TryGetValue("x-ms-server-encrypted", out bool? isServerEncrypted) && isServerEncrypted.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties()
                {
                    FileAttributes = ShareModelExtensions.ToFileAttributes(response.Headers.TryGetValue("x-ms-file-attributes", out string fileAttributes) ? fileAttributes : null),
                    FilePermissionKey = response.Headers.TryGetValue("x-ms-file-permission-key", out string filePermissionKey) ? filePermissionKey : null,
                    FileCreatedOn = response.Headers.TryGetValue("x-ms-file-creation-time", out DateTimeOffset? fileCreationTime) ? fileCreationTime : null,
                    FileLastWrittenOn = response.Headers.TryGetValue("x-ms-file-last-write-time", out DateTimeOffset? fileLastWriteTime) ? fileLastWriteTime : null,
                    FileChangedOn = response.Headers.TryGetValue("x-ms-file-change-time", out DateTimeOffset? fileChangeTime) ? fileChangeTime : null,
                    FileId = response.Headers.TryGetValue("x-ms-file-id", out string fileId) ? fileId : null,
                    ParentId = response.Headers.TryGetValue("x-ms-file-parent-id", out string fileParentId) ? fileParentId : null
                },
                PosixProperties = new FilePosixProperties()
                {
                    FileMode = NfsFileMode.ParseOctalFileMode(response.Headers.TryGetValue("x-ms-mode", out string fileMode) ? fileMode : null),
                    Owner = response.Headers.TryGetValue("x-ms-owner", out string owner) ? owner : null,
                    Group = response.Headers.TryGetValue("x-ms-group", out string group) ? group : null,
                    FileType = response.Headers.TryGetValue("x-ms-file-file-type", out string nfsFileType) ? (NfsFileType?)nfsFileType : null,
                }
            };
        }

        internal static StorageHandlesSegment ToStorageHandlesSegment(this ListHandlesResponse listHandlesResponse)
        {
            if (listHandlesResponse == null)
            {
                return null;
            }

            return new StorageHandlesSegment()
            {
                NextMarker = listHandlesResponse.NextMarker,
                Handles = ((IReadOnlyList<HandleItem>)listHandlesResponse.HandleList).ToShareFileHandles()
            };
        }

        internal static List<ShareFileHandle> ToShareFileHandles(this IReadOnlyList<HandleItem> handleItems)
        {
            if (handleItems == null)
            {
                return null;
            }
            List<ShareFileHandle> list = new List<ShareFileHandle>();
            foreach (HandleItem handleItem in handleItems)
            {
                list.Add(handleItem.ToShareFileHandle());
            }
            return list;
        }

        internal static ShareFileHandle ToShareFileHandle(this HandleItem handleItem)
        {
            if (handleItem == null)
            {
                return null;
            }

            return new ShareFileHandle(
                handleId: handleItem.HandleId,
                path: handleItem.Path.Encoded == true ? Uri.UnescapeDataString(handleItem.Path.Content) : handleItem.Path.Content,
                fileId: handleItem.FileId,
                parentId: handleItem.ParentId,
                sessionId: handleItem.SessionId,
                clientIp: handleItem.ClientIp,
                clientName: handleItem.ClientName,
                openedOn: handleItem.OpenTime,
                lastReconnectedOn: handleItem.LastReconnectTime,
                accessRights: ((IReadOnlyList<AccessRight>)handleItem.AccessRightList).ToShareFileHandleAccessRight());
        }

        internal static ShareFileHandleAccessRights? ToShareFileHandleAccessRight(this IReadOnlyList<AccessRight> accessRightList)
        {
            if (accessRightList == null)
            {
                return null;
            }

            ShareFileHandleAccessRights accessRights = 0;

            foreach (AccessRight accessRight in accessRightList)
            {
                if (accessRight == AccessRight.Read)
                {
                    accessRights |= ShareFileHandleAccessRights.Read;
                }
                else if (accessRight == AccessRight.Write)
                {
                    accessRights |= ShareFileHandleAccessRights.Write;
                }
                else if (accessRight == AccessRight.Delete)
                {
                    accessRights |= ShareFileHandleAccessRights.Delete;
                }
            }

            return accessRights;
        }

        internal static StorageClosedHandlesSegment ToStorageClosedHandlesSegment(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            return new StorageClosedHandlesSegment
            {
                Marker = response.Headers.TryGetValue("x-ms-marker", out string marker) ? marker : null,
                NumberOfHandlesClosed = response.Headers.TryGetValue("x-ms-number-of-handles-closed", out int? handlesClosed) ? handlesClosed.GetValueOrDefault() : default,
                NumberOfHandlesFailedToClose = response.Headers.TryGetValue("x-ms-number-of-handles-failed", out int? handlesFailed) ? handlesFailed.GetValueOrDefault() : default
            };
        }

        internal enum ShareFileInfoHeaderType
        {
            Create,
            SetHttpHeaders,
            SetMetadata,
            CreateSymbolicLink,
            CreateHardLink
        }

        internal static ShareFileInfo ToShareFileInfo(this Response response, ShareFileInfoHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            const string ServerEncryptedHeader = "x-ms-request-server-encrypted";
            const string FilePermissionKeyHeader = "x-ms-file-permission-key";
            const string FileAttributesHeader = "x-ms-file-attributes";
            const string FileCreationTimeHeader = "x-ms-file-creation-time";
            const string FileLastWriteTimeHeader = "x-ms-file-last-write-time";
            const string FileChangeTimeHeader = "x-ms-file-change-time";
            const string FileIdHeader = "x-ms-file-id";
            const string FileParentIdHeader = "x-ms-file-parent-id";
            const string FileModeHeader = "x-ms-mode";
            const string OwnerHeader = "x-ms-owner";
            const string GroupHeader = "x-ms-group";
            const string NfsFileTypeHeader = "x-ms-file-file-type";
            const string LinkCountHeader = "x-ms-link-count";

            switch (headerType)
            {
                case ShareFileInfoHeaderType.Create:
                    return new ShareFileInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                        IsServerEncrypted = response.Headers.TryGetValue(ServerEncryptedHeader, out bool? isServerEncrypted) && isServerEncrypted.GetValueOrDefault(),
                        SmbProperties = new FileSmbProperties()
                        {
                            FileAttributes = ShareModelExtensions.ToFileAttributes(response.Headers.TryGetValue(FileAttributesHeader, out string fileAttributes) ? fileAttributes : null),
                            FilePermissionKey = response.Headers.TryGetValue(FilePermissionKeyHeader, out string filePermissionKey) ? filePermissionKey : null,
                            FileCreatedOn = response.Headers.TryGetValue(FileCreationTimeHeader, out DateTimeOffset? fileCreationTime) ? fileCreationTime : null,
                            FileLastWrittenOn = response.Headers.TryGetValue(FileLastWriteTimeHeader, out DateTimeOffset? fileLastWriteTime) ? fileLastWriteTime : null,
                            FileChangedOn = response.Headers.TryGetValue(FileChangeTimeHeader, out DateTimeOffset? fileChangeTime) ? fileChangeTime : null,
                            FileId = response.Headers.TryGetValue(FileIdHeader, out string fileId) ? fileId : null,
                            ParentId = response.Headers.TryGetValue(FileParentIdHeader, out string fileParentId) ? fileParentId : null
                        },
                        PosixProperties = new FilePosixProperties()
                        {
                            FileMode = NfsFileMode.ParseOctalFileMode(response.Headers.TryGetValue(FileModeHeader, out string fileMode) ? fileMode : null),
                            Owner = response.Headers.TryGetValue(OwnerHeader, out string owner) ? owner : null,
                            Group = response.Headers.TryGetValue(GroupHeader, out string group) ? group : null,
                            FileType = response.Headers.TryGetValue(NfsFileTypeHeader, out string nfsFileType) ? (NfsFileType?)nfsFileType : null,
                        },
                        ContentHash = response.Headers.TryGetValue("Content-MD5", out byte[] contentMD5) ? contentMD5 : null,
                    };
                case ShareFileInfoHeaderType.SetHttpHeaders:
                    return new ShareFileInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string shValue) ? new ETag(shValue) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? shLastModified) ? shLastModified.GetValueOrDefault() : default,
                        IsServerEncrypted = response.Headers.TryGetValue(ServerEncryptedHeader, out bool? shServerEncrypted) && shServerEncrypted.GetValueOrDefault(),
                        SmbProperties = new FileSmbProperties
                        {
                            FileAttributes = ShareModelExtensions.ToFileAttributes(response.Headers.TryGetValue(FileAttributesHeader, out string shFileAttributes) ? shFileAttributes : null),
                            FilePermissionKey = response.Headers.TryGetValue(FilePermissionKeyHeader, out string shFilePermissionKey) ? shFilePermissionKey : null,
                            FileCreatedOn = response.Headers.TryGetValue(FileCreationTimeHeader, out DateTimeOffset? shFileCreationTime) ? shFileCreationTime : null,
                            FileLastWrittenOn = response.Headers.TryGetValue(FileLastWriteTimeHeader, out DateTimeOffset? shFileLastWriteTime) ? shFileLastWriteTime : null,
                            FileChangedOn = response.Headers.TryGetValue(FileChangeTimeHeader, out DateTimeOffset? shFileChangeTime) ? shFileChangeTime : null,
                            FileId = response.Headers.TryGetValue(FileIdHeader, out string shFileId) ? shFileId : null,
                            ParentId = response.Headers.TryGetValue(FileParentIdHeader, out string shFileParentId) ? shFileParentId : null
                        },
                        PosixProperties = new FilePosixProperties()
                        {
                            FileMode = NfsFileMode.ParseOctalFileMode(response.Headers.TryGetValue(FileModeHeader, out string shFileMode) ? shFileMode : null),
                            Owner = response.Headers.TryGetValue(OwnerHeader, out string shOwner) ? shOwner : null,
                            Group = response.Headers.TryGetValue(GroupHeader, out string shGroup) ? shGroup : null,
                            LinkCount = response.Headers.TryGetValue(LinkCountHeader, out long? shLinkCount) ? shLinkCount : null
                        }
                    };
                case ShareFileInfoHeaderType.SetMetadata:
                    return new ShareFileInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string smValue) ? new ETag(smValue) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? smLastModified) ? smLastModified.GetValueOrDefault() : default,
                        IsServerEncrypted = response.Headers.TryGetValue(ServerEncryptedHeader, out bool? smServerEncrypted) && smServerEncrypted.GetValueOrDefault(),
                        SmbProperties = new FileSmbProperties { }
                    };
                case ShareFileInfoHeaderType.CreateSymbolicLink:
                    return new ShareFileInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string slValue) ? new ETag(slValue) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? slLastModified) ? slLastModified.GetValueOrDefault() : default,
                        SmbProperties = new FileSmbProperties
                        {
                            FileCreatedOn = response.Headers.TryGetValue(FileCreationTimeHeader, out DateTimeOffset? slFileCreationTime) ? slFileCreationTime : null,
                            FileLastWrittenOn = response.Headers.TryGetValue(FileLastWriteTimeHeader, out DateTimeOffset? slFileLastWriteTime) ? slFileLastWriteTime : null,
                            FileChangedOn = response.Headers.TryGetValue(FileChangeTimeHeader, out DateTimeOffset? slFileChangeTime) ? slFileChangeTime : null,
                            FileId = response.Headers.TryGetValue(FileIdHeader, out string slFileId) ? slFileId : null,
                            ParentId = response.Headers.TryGetValue(FileParentIdHeader, out string slFileParentId) ? slFileParentId : null
                        },
                        PosixProperties = new FilePosixProperties()
                        {
                            FileType = response.Headers.TryGetValue(NfsFileTypeHeader, out string slNfsFileType) ? (NfsFileType?)slNfsFileType : null,
                            FileMode = NfsFileMode.ParseOctalFileMode(response.Headers.TryGetValue(FileModeHeader, out string slFileMode) ? slFileMode : null),
                            Owner = response.Headers.TryGetValue(OwnerHeader, out string slOwner) ? slOwner : null,
                            Group = response.Headers.TryGetValue(GroupHeader, out string slGroup) ? slGroup : null
                        }
                    };
                case ShareFileInfoHeaderType.CreateHardLink:
                    return new ShareFileInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string hlValue) ? new ETag(hlValue) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? hlLastModified) ? hlLastModified.GetValueOrDefault() : default,
                        SmbProperties = new FileSmbProperties
                        {
                            FileCreatedOn = response.Headers.TryGetValue(FileCreationTimeHeader, out DateTimeOffset? hlFileCreationTime) ? hlFileCreationTime : null,
                            FileLastWrittenOn = response.Headers.TryGetValue(FileLastWriteTimeHeader, out DateTimeOffset? hlFileLastWriteTime) ? hlFileLastWriteTime : null,
                            FileChangedOn = response.Headers.TryGetValue(FileChangeTimeHeader, out DateTimeOffset? hlFileChangeTime) ? hlFileChangeTime : null,
                            FileId = response.Headers.TryGetValue(FileIdHeader, out string hlFileId) ? hlFileId : null,
                            ParentId = response.Headers.TryGetValue(FileParentIdHeader, out string hlFileParentId) ? hlFileParentId : null
                        },
                        PosixProperties = new FilePosixProperties()
                        {
                            FileMode = NfsFileMode.ParseOctalFileMode(response.Headers.TryGetValue(FileModeHeader, out string hlFileMode) ? hlFileMode : null),
                            Owner = response.Headers.TryGetValue(OwnerHeader, out string hlOwner) ? hlOwner : null,
                            Group = response.Headers.TryGetValue(GroupHeader, out string hlGroup) ? hlGroup : null,
                            LinkCount = response.Headers.TryGetValue(LinkCountHeader, out long? hlLinkCount) ? hlLinkCount : null,
                            FileType = response.Headers.TryGetValue(NfsFileTypeHeader, out string hlNfsFileType) ? (NfsFileType?)hlNfsFileType : null
                        }
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(ShareFileInfoHeaderType)}: {headerType}", nameof(headerType));
            }
        }

        internal static ShareFileCopyInfo ToShareFileCopyInfo(this Response response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareFileCopyInfo
            {
                ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                CopyId = response.Headers.TryGetValue("x-ms-copy-id", out string copyId) ? copyId : null,
                CopyStatus = response.Headers.TryGetValue("x-ms-copy-status", out string copyStatus) ? copyStatus.ToCopyStatus() : default
            };
        }

        internal static ShareFileProperties ToShareFileProperties(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            const string FileAttributesHeader = "x-ms-file-attributes";
            const string FilePermissionKeyHeader = "x-ms-file-permission-key";
            const string FileCreationTimeHeader = "x-ms-file-creation-time";
            const string FileLastWriteTimeHeader = "x-ms-file-last-write-time";
            const string FileChangeTimeHeader = "x-ms-file-change-time";
            const string FileIdHeader = "x-ms-file-id";
            const string FileParentIdHeader = "x-ms-file-parent-id";
            const string FileModeHeader = "x-ms-mode";
            const string OwnerHeader = "x-ms-owner";
            const string GroupHeader = "x-ms-group";
            const string NfsFileTypeHeader = "x-ms-file-file-type";
            const string LinkCountHeader = "x-ms-link-count";

            ShareFileProperties shareFileProperties = new ShareFileProperties
            {
                LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                Metadata = response.Headers.TryGetValue(Constants.HeaderNames.MetadataPrefix, out IDictionary<string, string> metadata) ? metadata : null,
                ContentLength = response.Headers.TryGetValue(Constants.HeaderNames.ContentLength, out long? contentLength) ? contentLength.GetValueOrDefault() : default,
                ContentType = response.Headers.TryGetValue(Constants.HeaderNames.ContentType, out string contentType) ? contentType : null,
                ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                ContentHash = response.Headers.TryGetValue("Content-MD5", out byte[] contentMD5) ? contentMD5 : null,
                CacheControl = response.Headers.TryGetValue("Cache-Control", out string cacheControl) ? cacheControl : null,
                ContentDisposition = response.Headers.TryGetValue("Content-Disposition", out string contentDisposition) ? contentDisposition : null,
                CopyCompletedOn = response.Headers.TryGetValue("x-ms-copy-completion-time", out DateTimeOffset? copyCompletionTime) ? copyCompletionTime.GetValueOrDefault() : default,
                CopyStatusDescription = response.Headers.TryGetValue("x-ms-copy-status-description", out string copyStatusDescription) ? copyStatusDescription : null,
                CopyId = response.Headers.TryGetValue("x-ms-copy-id", out string copyId) ? copyId : null,
                CopyProgress = response.Headers.TryGetValue("x-ms-copy-progress", out string copyProgress) ? copyProgress : null,
                CopySource = response.Headers.TryGetValue("x-ms-copy-source", out string copySource) ? copySource : null,
                CopyStatus = response.Headers.TryGetValue("x-ms-copy-status", out string copyStatus) ? copyStatus.ToCopyStatus() : default,
                IsServerEncrypted = response.Headers.TryGetValue("x-ms-server-encrypted", out bool? isServerEncrypted) && isServerEncrypted.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties
                {
                    FileAttributes = ShareModelExtensions.ToFileAttributes(response.Headers.TryGetValue(FileAttributesHeader, out string fileAttributes) ? fileAttributes : null),
                    FilePermissionKey = response.Headers.TryGetValue(FilePermissionKeyHeader, out string filePermissionKey) ? filePermissionKey : null,
                    FileCreatedOn = response.Headers.TryGetValue(FileCreationTimeHeader, out DateTimeOffset? fileCreationTime) ? fileCreationTime : null,
                    FileLastWrittenOn = response.Headers.TryGetValue(FileLastWriteTimeHeader, out DateTimeOffset? fileLastWriteTime) ? fileLastWriteTime : null,
                    FileChangedOn = response.Headers.TryGetValue(FileChangeTimeHeader, out DateTimeOffset? fileChangeTime) ? fileChangeTime : null,
                    FileId = response.Headers.TryGetValue(FileIdHeader, out string fileId) ? fileId : null,
                    ParentId = response.Headers.TryGetValue(FileParentIdHeader, out string fileParentId) ? fileParentId : null
                },
                LeaseDuration = response.Headers.TryGetValue("x-ms-lease-duration", out string leaseDuration) ? leaseDuration.ToShareLeaseDuration() : default,
                LeaseState = response.Headers.TryGetValue("x-ms-lease-state", out string leaseState) ? leaseState.ToShareLeaseState() : default,
                LeaseStatus = response.Headers.TryGetValue("x-ms-lease-status", out string leaseStatus) ? leaseStatus.ToShareLeaseStatus() : default,
                PosixProperties = new FilePosixProperties()
                {
                    FileMode = NfsFileMode.ParseOctalFileMode(response.Headers.TryGetValue(FileModeHeader, out string fileMode) ? fileMode : null),
                    Owner = response.Headers.TryGetValue(OwnerHeader, out string owner) ? owner : null,
                    Group = response.Headers.TryGetValue(GroupHeader, out string group) ? group : null,
                    FileType = response.Headers.TryGetValue(NfsFileTypeHeader, out string nfsFileType) ? (NfsFileType?)nfsFileType : null,
                    LinkCount = response.Headers.TryGetValue(LinkCountHeader, out long? linkCount) ? linkCount : null
                }
            };

            if (response.Headers.TryGetValue(Constants.HeaderNames.ContentEncoding, out string contentEncoding) && contentEncoding != null)
            {
                shareFileProperties.ContentEncoding = contentEncoding.Split(Constants.CommaChar);
            }

            if (response.Headers.TryGetValue(Constants.HeaderNames.ContentLanguage, out string contentLanguage) && contentLanguage != null)
            {
                shareFileProperties.ContentLanguage = contentLanguage.Split(Constants.CommaChar);
            }

            return shareFileProperties;
        }

        internal static ShareFileUploadInfo ToShareFileUploadInfo(this Response response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareFileUploadInfo()
            {
                ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                ContentHash = response.Headers.TryGetValue("Content-MD5", out byte[] contentMD5) ? contentMD5 : null,
                IsServerEncrypted = response.Headers.TryGetValue("x-ms-request-server-encrypted", out bool? isServerEncrypted) && isServerEncrypted.GetValueOrDefault()
            };
        }

        internal static ShareFileRangeInfo ToShareFileRangeInfo(this Response<ShareFileRangeList> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareFileRangeInfo
            {
                LastModified = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                FileContentLength = response.GetRawResponse().Headers.TryGetValue("x-ms-content-length", out long? fileContentLength) ? fileContentLength.GetValueOrDefault() : default,
                Ranges = response.Value.Ranges.Select(r => r.ToHttpRange()).ToList(),
                ClearRanges = response.Value.ClearRanges.Select(r => r.ToHttpRange()).ToList(),
            };
        }

        internal static HttpRange ToHttpRange(this FileRange fileRange)
            => new HttpRange(fileRange.Start, fileRange.End - fileRange.Start + 1);

        internal static HttpRange ToHttpRange(this ClearRange clearRange)
            => new HttpRange(clearRange.Start, clearRange.End - clearRange.Start + 1);

        // ToStorageClosedHandlesSegment for File is consolidated into the single method above.

        internal enum ShareLeaseHeaderType
        {
            FileAcquire,
            ShareAcquire,
            FileChange,
            ShareRenew,
            ShareChange,
            FileBreak,
            ShareBreak,
            FileRelease
        }

        internal static ShareFileLease ToShareFileLease(this Response response, ShareLeaseHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            switch (headerType)
            {
                case ShareLeaseHeaderType.FileAcquire:
                case ShareLeaseHeaderType.FileChange:
                case ShareLeaseHeaderType.ShareRenew:
                case ShareLeaseHeaderType.ShareChange:
                    return new ShareFileLease
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                        LeaseId = response.Headers.TryGetValue("x-ms-lease-id", out string leaseId) ? leaseId : null,
                        LeaseTime = response.Headers.ExtractLeaseTime()
                    };
                case ShareLeaseHeaderType.ShareAcquire:
                    return new ShareFileLease
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string saValue) ? new ETag(saValue) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? saLastModified) ? saLastModified.GetValueOrDefault() : default,
                        LeaseId = response.Headers.TryGetValue("x-ms-lease-id", out string saLeaseId) ? saLeaseId : null,
                        // File Aquire Lease does not return LeastTime.
                    };
                case ShareLeaseHeaderType.FileBreak:
                    return new ShareFileLease
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string fbValue) ? new ETag(fbValue) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? fbLastModified) ? fbLastModified.GetValueOrDefault() : default,
                        // Break lease does not return lease Id.
                        LeaseId = null,
                        LeaseTime = response.Headers.ExtractLeaseTime()
                    };
                case ShareLeaseHeaderType.ShareBreak:
                    return new ShareFileLease
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string sbValue) ? new ETag(sbValue) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? sbLastModified) ? sbLastModified.GetValueOrDefault() : default,
                        LeaseId = response.Headers.TryGetValue("x-ms-lease-id", out string sbLeaseId) ? sbLeaseId : null,
                        LeaseTime = response.Headers.TryGetValue("x-ms-lease-time", out int? sbLeaseTime) ? sbLeaseTime : null
                    };
                case ShareLeaseHeaderType.FileRelease:
                    // File Release Lease does not return LeaseId or LeaseTime.
                    return new ShareFileLease
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string frValue) ? new ETag(frValue) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? frLastModified) ? frLastModified.GetValueOrDefault() : default,
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(ShareLeaseHeaderType)}: {headerType}", nameof(headerType));
            }
        }

        internal static FileLeaseReleaseInfo ToFileLeaseReleaseInfo(this Response response)
        {
            if (response == null)
            {
                return null;
            }
            return new FileLeaseReleaseInfo
            {
                ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default
            };
        }

        internal enum ShareInfoHeaderType
        {
            Create,
            SetProperties,
            SetMetadata,
            SetAccessPolicy
        }

        internal static ShareInfo ToShareInfo(this Response response, ShareInfoHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            switch (headerType)
            {
                case ShareInfoHeaderType.Create:
                case ShareInfoHeaderType.SetProperties:
                case ShareInfoHeaderType.SetMetadata:
                case ShareInfoHeaderType.SetAccessPolicy:
                    return new ShareInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(ShareInfoHeaderType)}: {headerType}", nameof(headerType));
            }
        }

        internal static ShareSnapshotInfo ToShareSnapshotInfo(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            return new ShareSnapshotInfo
            {
                Snapshot = response.Headers.TryGetValue("x-ms-snapshot", out string snapshot) ? snapshot : null,
                ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default
            };
        }

        internal static ShareProperties ToShareProperties(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            return new ShareProperties
            {
                LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified : null,
                ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                ProvisionedIops = response.Headers.TryGetValue("x-ms-share-provisioned-iops", out int? provisionedIops) ? provisionedIops : null,
                ProvisionedIngressMBps = response.Headers.TryGetValue("x-ms-share-provisioned-ingress-mbps", out int? provisionedIngressMBps) ? provisionedIngressMBps : null,
                ProvisionedEgressMBps = response.Headers.TryGetValue("x-ms-share-provisioned-egress-mbps", out int? provisionedEgressMBps) ? provisionedEgressMBps : null,
                ProvisionedBandwidthMiBps = response.Headers.TryGetValue("x-ms-share-provisioned-bandwidth-mibps", out int? provisionedBandwidthMiBps) ? provisionedBandwidthMiBps : null,
                NextAllowedQuotaDowngradeTime = response.Headers.TryGetValue("x-ms-share-next-allowed-quota-downgrade-time", out DateTimeOffset? quotaDowngradeTime) ? quotaDowngradeTime : null,
                DeletedOn = null,
                RemainingRetentionDays = null,
                AccessTier = response.Headers.TryGetValue("x-ms-access-tier", out string accessTier) ? accessTier : null,
                AccessTierChangeTime = response.Headers.TryGetValue("x-ms-access-tier-change-time", out DateTimeOffset? accessTierChangeTime) ? accessTierChangeTime : null,
                AccessTierTransitionState = response.Headers.TryGetValue("x-ms-access-tier-transition-state", out string accessTierTransitionState) ? accessTierTransitionState : null,
                LeaseStatus = response.Headers.TryGetValue("x-ms-lease-status", out string leaseStatus) ? leaseStatus.ToShareLeaseStatus() : null,
                LeaseState = response.Headers.TryGetValue("x-ms-lease-state", out string leaseState) ? leaseState.ToShareLeaseState() : null,
                LeaseDuration = response.Headers.TryGetValue("x-ms-lease-duration", out string leaseDuration) ? leaseDuration.ToShareLeaseDuration() : null,
                Protocols = ToShareEnabledProtocols(response.Headers.TryGetValue("x-ms-enabled-protocols", out string enabledProtocols) ? enabledProtocols : null),
                RootSquash = response.Headers.TryGetValue("x-ms-root-squash", out string rootSquash) ? rootSquash.ToShareRootSquash() : null,
                Metadata = response.Headers.TryGetValue(Constants.HeaderNames.MetadataPrefix, out IDictionary<string, string> metadata) ? metadata : null,
                EnableSnapshotVirtualDirectoryAccess = response.Headers.TryGetValue("x-ms-enable-snapshot-virtual-directory-access", out bool? enableSnapshotVda) ? enableSnapshotVda : null,
                QuotaInGB = response.Headers.TryGetValue("x-ms-share-quota", out int? quota) ? quota : null,
                EnablePaidBursting = response.Headers.TryGetValue("x-ms-share-paid-bursting-enabled", out bool? paidBurstingEnabled) ? paidBurstingEnabled : null,
                PaidBurstingMaxIops = response.Headers.TryGetValue("x-ms-share-paid-bursting-max-iops", out long? paidBurstingMaxIops) ? paidBurstingMaxIops : null,
                PaidBurstingMaxBandwidthMibps = response.Headers.TryGetValue("x-ms-share-paid-bursting-max-bandwidth-mibps", out long? paidBurstingMaxBandwidthMibps) ? paidBurstingMaxBandwidthMibps : null,
                IncludedBurstIops = response.Headers.TryGetValue("x-ms-share-included-burst-iops", out long? includedBurstIops) ? includedBurstIops : null,
                MaxBurstCreditsForIops = response.Headers.TryGetValue("x-ms-share-max-burst-credits-for-iops", out long? maxBurstCreditsForIops) ? maxBurstCreditsForIops : null,
                NextAllowedProvisionedIopsDowngradeTime = response.Headers.TryGetValue("x-ms-share-next-allowed-provisioned-iops-downgrade-time", out DateTimeOffset? nextIopsDowngrade) ? nextIopsDowngrade : null,
                NextAllowedProvisionedBandwidthDowngradeTime = response.Headers.TryGetValue("x-ms-share-next-allowed-provisioned-bandwidth-downgrade-time", out DateTimeOffset? nextBwDowngrade) ? nextBwDowngrade : null,
                //EnableDirectoryLease = response.Headers.EnableSmbDirectoryLease,
            };
        }

        internal static PermissionInfo ToPermissionInfo(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            return new PermissionInfo
            {
                FilePermissionKey = response.Headers.TryGetValue("x-ms-file-permission-key", out string filePermissionKey) ? filePermissionKey : null
            };
        }

        internal static IEnumerable<ShareItem> ToShareItems(this IReadOnlyList<ShareItemInternal> shareItemInternals)
        {
            if (shareItemInternals == null)
            {
                return null;
            }

            return shareItemInternals.Select(r => r.ToShareItem());
        }

        internal static ShareItem ToShareItem(this ShareItemInternal shareItemInternal)
        {
            if (shareItemInternal == null)
            {
                return null;
            }

            return new ShareItem
            {
                Name = shareItemInternal.Name,
                Snapshot = shareItemInternal.Snapshot,
                IsDeleted = shareItemInternal.Deleted,
                VersionId = shareItemInternal.Version,
                Properties = ToShareProperties(shareItemInternal.Properties, (IReadOnlyDictionary<string, string>)shareItemInternal.Metadata),
            };
        }

        internal static ShareProperties ToShareProperties(SharePropertiesInternal sharePropertiesInternal, IReadOnlyDictionary<string, string> rawMetadata)
        {
            if (sharePropertiesInternal == null)
            {
                return null;
            }

            IDictionary<string, string> metadata = rawMetadata?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return new ShareProperties
            {
                LastModified = sharePropertiesInternal.LastModified,
                ETag = sharePropertiesInternal.ETag,
                ProvisionedIops = sharePropertiesInternal.ProvisionedIops,
                ProvisionedIngressMBps = sharePropertiesInternal.ProvisionedIngressMBps,
                ProvisionedEgressMBps = sharePropertiesInternal.ProvisionedEgressMBps,
                ProvisionedBandwidthMiBps = sharePropertiesInternal.ProvisionedBandwidthMiBps,
                NextAllowedQuotaDowngradeTime = sharePropertiesInternal.NextAllowedQuotaDowngradeTime,
                DeletedOn = sharePropertiesInternal.DeletedTime,
                RemainingRetentionDays = sharePropertiesInternal.RemainingRetentionDays,
                AccessTier = sharePropertiesInternal.AccessTier,
                AccessTierChangeTime = sharePropertiesInternal.AccessTierChangeTime,
                AccessTierTransitionState = sharePropertiesInternal.AccessTierTransitionState,
                LeaseStatus = sharePropertiesInternal.LeaseStatus,
                LeaseState = sharePropertiesInternal.LeaseState,
                LeaseDuration = sharePropertiesInternal.LeaseDuration,
                Protocols = ToShareEnabledProtocols(sharePropertiesInternal.EnabledProtocols),
                RootSquash = sharePropertiesInternal.RootSquash,
                Metadata = metadata,
                EnableSnapshotVirtualDirectoryAccess = sharePropertiesInternal.EnableSnapshotVirtualDirectoryAccess,
                QuotaInGB = sharePropertiesInternal.Quota,
                EnablePaidBursting = sharePropertiesInternal.PaidBurstingEnabled,
                PaidBurstingMaxIops = sharePropertiesInternal.PaidBurstingMaxIops,
                PaidBurstingMaxBandwidthMibps = sharePropertiesInternal.PaidBurstingMaxBandwidthMibps,
                IncludedBurstIops = sharePropertiesInternal.IncludedBurstIops,
                MaxBurstCreditsForIops = sharePropertiesInternal.MaxBurstCreditsForIops,
                NextAllowedProvisionedIopsDowngradeTime = sharePropertiesInternal.NextAllowedProvisionedIopsDowngradeTime,
                NextAllowedProvisionedBandwidthDowngradeTime = sharePropertiesInternal.NextAllowedProvisionedBandwidthDowngradeTime,
                //EnableDirectoryLease = sharePropertiesInternal.EnableSmbDirectoryLease,
            };
        }

        internal static ShareFileDownloadInfo ToShareFileDownloadInfo(this Response<Stream> response)
        {
            if (response == null)
            {
                return null;
            }

            var rawResponse = response.GetRawResponse();

            const string FileAttributesHeader = "x-ms-file-attributes";
            const string FilePermissionKeyHeader = "x-ms-file-permission-key";
            const string FileCreationTimeHeader = "x-ms-file-creation-time";
            const string FileLastWriteTimeHeader = "x-ms-file-last-write-time";
            const string FileChangeTimeHeader = "x-ms-file-change-time";
            const string FileIdHeader = "x-ms-file-id";
            const string FileParentIdHeader = "x-ms-file-parent-id";
            const string FileModeHeader = "x-ms-mode";
            const string OwnerHeader = "x-ms-owner";
            const string GroupHeader = "x-ms-group";
            const string LinkCountHeader = "x-ms-link-count";

            ShareFileDownloadInfo shareFileDownloadInfo = new ShareFileDownloadInfo
            {
                ContentLength = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentLength, out long? contentLength) ? contentLength.GetValueOrDefault() : default,
                Content = response.Value,
                ContentType = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentType, out string contentType) ? contentType : null,
                ContentHash = rawResponse.Headers.TryGetValue("Content-MD5", out byte[] contentMD5) ? contentMD5 : null,
                Details = new ShareFileDownloadDetails
                {
                    LastModified = rawResponse.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                    Metadata = rawResponse.Headers.TryGetValue(Constants.HeaderNames.MetadataPrefix, out IDictionary<string, string> metadata) ? metadata : null,
                    ContentRange = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentRange, out string contentRange) ? contentRange : null,
                    ETag = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                    CacheControl = rawResponse.Headers.TryGetValue("Cache-Control", out string cacheControl) ? cacheControl : null,
                    ContentDisposition = rawResponse.Headers.TryGetValue("Content-Disposition", out string contentDisposition) ? contentDisposition : null,
                    AcceptRanges = rawResponse.Headers.TryGetValue("Accept-Ranges", out string acceptRanges) ? acceptRanges : null,
                    CopyCompletedOn = rawResponse.Headers.TryGetValue("x-ms-copy-completion-time", out DateTimeOffset? copyCompletionTime) ? copyCompletionTime.GetValueOrDefault() : default,
                    CopyStatusDescription = rawResponse.Headers.TryGetValue("x-ms-copy-status-description", out string copyStatusDescription) ? copyStatusDescription : null,
                    CopyId = rawResponse.Headers.TryGetValue("x-ms-copy-id", out string copyId) ? copyId : null,
                    CopyProgress = rawResponse.Headers.TryGetValue("x-ms-copy-progress", out string copyProgress) ? copyProgress : null,
                    CopySource = rawResponse.Headers.TryGetValue("x-ms-copy-source", out string copySource) ? (copySource == null ? null : new Uri(copySource)) : null,
                    CopyStatus = rawResponse.Headers.TryGetValue("x-ms-copy-status", out string copyStatus) ? copyStatus.ToCopyStatus() : default,
                    FileContentHash = rawResponse.Headers.TryGetValue("x-ms-content-md5", out byte[] fileContentMD5) ? fileContentMD5 : null,
                    IsServerEncrypted = rawResponse.Headers.TryGetValue("x-ms-server-encrypted", out bool? isServerEncrypted) && isServerEncrypted.GetValueOrDefault(),
                    LeaseDuration = rawResponse.Headers.TryGetValue("x-ms-lease-duration", out string leaseDuration) ? leaseDuration.ToShareLeaseDuration() : default,
                    LeaseState = rawResponse.Headers.TryGetValue("x-ms-lease-state", out string leaseState) ? leaseState.ToShareLeaseState() : default,
                    LeaseStatus = rawResponse.Headers.TryGetValue("x-ms-lease-status", out string leaseStatus) ? leaseStatus.ToShareLeaseStatus() : default,
                    SmbProperties = new FileSmbProperties
                    {
                        FileAttributes = ShareModelExtensions.ToFileAttributes(rawResponse.Headers.TryGetValue(FileAttributesHeader, out string fileAttributes) ? fileAttributes : null),
                        FilePermissionKey = rawResponse.Headers.TryGetValue(FilePermissionKeyHeader, out string filePermissionKey) ? filePermissionKey : null,
                        FileCreatedOn = rawResponse.Headers.TryGetValue(FileCreationTimeHeader, out DateTimeOffset? fileCreationTime) ? fileCreationTime : null,
                        FileLastWrittenOn = rawResponse.Headers.TryGetValue(FileLastWriteTimeHeader, out DateTimeOffset? fileLastWriteTime) ? fileLastWriteTime : null,
                        FileChangedOn = rawResponse.Headers.TryGetValue(FileChangeTimeHeader, out DateTimeOffset? fileChangeTime) ? fileChangeTime : null,
                        FileId = rawResponse.Headers.TryGetValue(FileIdHeader, out string fileId) ? fileId : null,
                        ParentId = rawResponse.Headers.TryGetValue(FileParentIdHeader, out string fileParentId) ? fileParentId : null
                    },
                    PosixProperties = new FilePosixProperties
                    {
                        FileMode = NfsFileMode.ParseOctalFileMode(rawResponse.Headers.TryGetValue(FileModeHeader, out string fileMode) ? fileMode : null),
                        Owner = rawResponse.Headers.TryGetValue(OwnerHeader, out string owner) ? owner : null,
                        Group = rawResponse.Headers.TryGetValue(GroupHeader, out string group) ? group : null,
                        LinkCount = rawResponse.Headers.TryGetValue(LinkCountHeader, out long? linkCount) ? linkCount : null,
                    }
                }
            };

            if (rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentEncoding, out string contentEncoding) && contentEncoding != null)
            {
                shareFileDownloadInfo.Details.ContentEncoding = contentEncoding.Split(Constants.CommaChar);
            }

            if (rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentLanguage, out string contentLanguage) && contentLanguage != null)
            {
                shareFileDownloadInfo.Details.ContentLanguage = contentLanguage.Split(Constants.CommaChar);
            }

            return shareFileDownloadInfo;
        }

        internal static ShareFileItem ToShareFileItem(this DirectoryItem directoryItem)
        {
            if (directoryItem == null)
            {
                return null;
            }

            return new ShareFileItem(
                isDirectory: true,
                name: directoryItem.Name.Encoded == true ? Uri.UnescapeDataString(directoryItem.Name.Content) : directoryItem.Name.Content,
                id: directoryItem.FileId,
                properties: directoryItem.Properties.ToShareFileItemProperties(),
                fileAttributes: ShareModelExtensions.ToFileAttributes(directoryItem.Attributes),
                permissionKey: directoryItem.PermissionKey,
                fileSize: null);
        }

        internal static ShareFileItem ToShareFileItem(this FileItem fileItem)
        {
            if (fileItem == null)
            {
                return null;
            }

            return new ShareFileItem(
                isDirectory: false,
                name: fileItem.Name.Encoded == true ? Uri.UnescapeDataString(fileItem.Name.Content) : fileItem.Name.Content,
                id: fileItem.FileId,
                properties: fileItem.Properties.ToShareFileItemProperties(),
                fileAttributes: ShareModelExtensions.ToFileAttributes(fileItem.Attributes),
                permissionKey: fileItem.PermissionKey,
                fileSize: fileItem.Properties.ContentLength);
        }

        internal static ShareFileItemProperties ToShareFileItemProperties(this FileProperty fileProperty)
        {
            if (fileProperty == null)
            {
                return null;
            }

            return new ShareFileItemProperties(
                createdOn: fileProperty.CreationTime,
                lastAccessedOn: fileProperty.LastAccessTime,
                lastWrittenOn: fileProperty.LastWriteTime,
                changedOn: fileProperty.ChangeTime,
                lastModified: fileProperty.LastModified,
                eTag: fileProperty.ETag == null ? null : new ETag(fileProperty.ETag));
        }

        internal static DateTimeOffset ExtractLastModified(this ResponseHeaders responseHeaders)
        {
            DateTimeOffset lastModified = DateTimeOffset.MinValue;

            if (responseHeaders.TryGetValue(Constants.HeaderNames.LastModified, out string lastModifiedString))
            {
                lastModified = DateTimeOffset.Parse(lastModifiedString, CultureInfo.InvariantCulture);
            }

            return lastModified;
        }

        private static int? ExtractLeaseTime(this ResponseHeaders responseHeaders)
        {
            int? leaseTime = null;

            if (responseHeaders.TryGetValue(Constants.HeaderNames.LeaseTime, out string leaseTimeString))
            {
                leaseTime = int.Parse(leaseTimeString, CultureInfo.InvariantCulture);
            }

            return leaseTime;
        }

        internal static Response<ShareFilePermission> ToShareFilePermission(this Response<SharePermission> response)
        {
            return Response.FromValue(
                new ShareFilePermission
                {
                    Permission = response.Value.Permission,
                    PermissionFormat = response.Value.Format
                },
                response.GetRawResponse());
        }

        internal static ShareFileSymbolicLinkInfo ToFileSymbolicLinkInfo(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            return new ShareFileSymbolicLinkInfo
            {
                ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                LinkText = response.Headers.TryGetValue("x-ms-link-text", out string linkText) ? linkText : null
            };
        }
    }
}
