// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Tests.Shared;
using NUnit.Framework;
#if !NETFRAMEWORK
using Mono.Unix.Native;
#endif

namespace Azure.Storage.DataMovement.Tests
{
    public class TransferLoggerTests : DataMovementTestBase
    {
        private readonly string _temp = Path.GetTempPath();
        private readonly FileSystemAccessRule _winAcl;

        public TransferLoggerTests(BlobClientOptions.ServiceVersion serviceVersion) : base (false, serviceVersion, null)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                string currentUser = WindowsIdentity.GetCurrent().Name;
                _winAcl = new FileSystemAccessRule(currentUser, FileSystemRights.ReadData, AccessControlType.Deny);
            }
        }

        [Test]
        public void LogAsync_Message()
        {
            string loggerFolder = CreateRandomDirectory(_temp);
            string jobIdGuid = Recording.Random.NewGuid().ToString();

            TransferJobLoggerFactory loggerFactory = new TransferJobLoggerFactory(loggerFolder, jobIdGuid);
        }

        /// TODO: LogAsync Test
        /// - None Level
        /// - Debug Level
        /// - Error Level
        /// - log but log below the level set
        /// - log but log above the level set
        /// - log empty message
        /// - happy path log message with level set
        ///
        /// TODO; Remove Log File Tests
        /// - happy path, remove existing file
        /// - Not Exists log file
        /// - Locked log File
        ///
        /// Ctor
        /// - Existing log file
        /// - Not Exists log file
        /// - Too many log files (may need to emulate error)
        ///
        /// Parallel logging
        private static string CreateRandomDirectory(string parentPath)
        {
            return Directory.CreateDirectory(Path.Combine(parentPath, Path.GetRandomFileName())).FullName;
        }

        private static string CreateRandomFile(string parentPath)
        {
            using (FileStream fs = File.Create(Path.Combine(parentPath, Path.GetRandomFileName())))
            {
                return fs.Name;
            }
        }

        private void AllowReadData(string path, bool isDirectory, bool allowRead)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Dynamically will be set to correct type supplied by user
                dynamic fsInfo = isDirectory ? new DirectoryInfo(path) : new FileInfo(path);
                dynamic fsSec = FileSystemAclExtensions.GetAccessControl(fsInfo);

                fsSec.ModifyAccessRule(allowRead ? AccessControlModification.Remove : AccessControlModification.Add, _winAcl, out bool result);

                FileSystemAclExtensions.SetAccessControl(fsInfo, fsSec);
            }
#if !NETFRAMEWORK
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                FilePermissions permissions = (allowRead ?
                    (FilePermissions.S_IRWXU | FilePermissions.S_IRWXG | FilePermissions.S_IRWXO) :
                    (FilePermissions.S_IWUSR | FilePermissions.S_IWGRP | FilePermissions.S_IWOTH));

                Syscall.chmod(path, permissions);
            }
#endif
        }
    }
}
