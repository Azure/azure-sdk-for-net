// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    internal class VisualStudioCodeCredentialTests
    {
        [Test]
        public void GetAuthenticationRecord_WithInvalidJson_ReturnsNull()
        {
            var invalidJsonBytes = new byte[0];
            var testFileSystem = new TestFileSystemService
            {
                FileExistsHandler = path => path.Contains("authRecord.json"),
                GetFileStreamHandler = _ =>
                {
                    var tempFilePath = Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, invalidJsonBytes);
                    return new FileStream(tempFilePath, FileMode.Open, FileAccess.Read);
                }
            };

            var authRecord = CredentialOptionsMapper.GetAuthenticationRecord(testFileSystem);
            Assert.IsNull(authRecord, "Authentication record should be null when JSON is invalid");
        }

        [Test]
        public void GetAuthenticationRecord_WithEmptyJson_ReturnsNull()
        {
            var testFileSystem = new TestFileSystemService
            {
                FileExistsHandler = path => path.Contains("authRecord.json"),
                GetFileStreamHandler = _ =>
                {
                    var tempFilePath = Path.GetTempFileName();
                    return new FileStream(tempFilePath, FileMode.Open, FileAccess.Read);
                }
            };

            var authRecord = CredentialOptionsMapper.GetAuthenticationRecord(testFileSystem);
            Assert.IsNull(authRecord, "Authentication record should be null when JSON is empty");
        }

        [Test]
        public void GetAuthenticationRecord_WithIncompleteJson_ReturnsNull()
        {
            var incompleteJson = JsonSerializer.Serialize(new
            {
                tenantId = "test-tenant"
                // Missing homeAccountId
            });

            var testFileSystem = new TestFileSystemService
            {
                FileExistsHandler = path => path.Contains("authRecord.json"),
                GetFileStreamHandler = _ =>
                {
                    var tempFilePath = Path.GetTempFileName();
                    File.WriteAllText(tempFilePath, incompleteJson);
                    return new FileStream(tempFilePath, FileMode.Open, FileAccess.Read);
                }
            };

            var authRecord = CredentialOptionsMapper.GetAuthenticationRecord(testFileSystem);
            Assert.IsNull(authRecord, "Authentication record should be null when required fields are missing");
        }

        [Test]
        public void GetAuthenticationRecord_WithValidJson_ReturnsAuthenticationRecord()
        {
            var validJson = JsonSerializer.Serialize(new
            {
                version = "1.0",
                homeAccountId = "test-home-account-id.test-tenant-id",
                environment = "login.microsoftonline.com",
                tenantId = "test-tenant-id",
                username = "test@example.com",
                clientId = "test-client-id"
            });

            var testFileSystem = new TestFileSystemService
            {
                FileExistsHandler = path => path.Contains("authRecord.json"),
                GetFileStreamHandler = _ =>
                {
                    var tempFilePath = Path.GetTempFileName();
                    File.WriteAllText(tempFilePath, validJson);
                    return new FileStream(tempFilePath, FileMode.Open, FileAccess.Read);
                }
            };

            var authRecord = CredentialOptionsMapper.GetAuthenticationRecord(testFileSystem);
            Assert.IsNotNull(authRecord, "Authentication record should not be null with valid JSON");
            Assert.AreEqual("test-tenant-id", authRecord.TenantId);
            Assert.AreEqual("test-home-account-id.test-tenant-id", authRecord.HomeAccountId);
        }

        [Test]
        public void GetAuthenticationRecord_ChecksLowerCasePathFirst()
        {
            bool lowerCaseChecked = false;
            bool upperCaseChecked = false;

            var validJson = JsonSerializer.Serialize(new
            {
                version = "1.0",
                homeAccountId = "test-home-account-id.test-tenant-id",
                environment = "login.microsoftonline.com",
                tenantId = "test-tenant-id",
                username = "test@example.com",
                clientId = "test-client-id"
            });

            var testFileSystem = new TestFileSystemService
            {
                FileExistsHandler = path =>
                {
                    if (path.Contains(".azure"))
                    {
                        lowerCaseChecked = true;
                        return false; // Lower case doesn't exist
                    }
                    if (path.Contains(".Azure"))
                    {
                        upperCaseChecked = true;
                        return true; // Upper case exists
                    }
                    return false;
                },
                GetFileStreamHandler = _ => {
                    var tempFilePath = Path.GetTempFileName();
                    File.WriteAllText(tempFilePath, validJson);
                    return new FileStream(tempFilePath, FileMode.Open, FileAccess.Read);
                }
            };

            var authRecord = CredentialOptionsMapper.GetAuthenticationRecord(testFileSystem);

            Assert.IsTrue(lowerCaseChecked, "Lower case path should be checked first");
            Assert.IsTrue(upperCaseChecked, "Upper case path should be checked when lower case doesn't exist");
            Assert.IsNotNull(authRecord, "Authentication record should be found in upper case path");
        }

        [Test]
        public void GetAuthenticationRecord_HandlesIOException()
        {
            var testFileSystem = new TestFileSystemService
            {
                FileExistsHandler = path => path.Contains("authRecord.json"),
                GetFileStreamHandler = _ => throw new IOException("File access denied")
            };

            var authRecord = CredentialOptionsMapper.GetAuthenticationRecord(testFileSystem);
            Assert.IsNull(authRecord, "Authentication record should be null when IOException occurs");
        }

        [Test]
        public void GetAuthenticationRecord_FileDoesNotExist()
        {
            var testFileSystem = new TestFileSystemService
            {
                FileExistsHandler = path => false
            };

            var authRecord = CredentialOptionsMapper.GetAuthenticationRecord(testFileSystem);
            Assert.IsNull(authRecord, "Authentication record should be null when file doesn't exist");
        }

        [Test]
        public void Constructor_WithNullOptions_Succeeds()
        {
            Assert.DoesNotThrow(() => new VisualStudioCodeCredential(null));
        }

        [Test]
        public void Constructor_WithValidOptions_TransfersProperties()
        {
            var options = new VisualStudioCodeCredentialOptions
            {
                TenantId = "test-tenant",
                AuthorityHost = new Uri("https://login.microsoftonline.us"),
                IsUnsafeSupportLoggingEnabled = true
            };

            // Constructor should succeed and not throw
            Assert.DoesNotThrow(() => new VisualStudioCodeCredential(options));
        }
    }
}
