// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Files.Shares.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class NfsFileModeTests
    {
        [Test]
        [TestCase("0000")]
        [TestCase("1111")]
        [TestCase("2222")]
        [TestCase("3333")]
        [TestCase("4444")]
        [TestCase("5555")]
        [TestCase("6666")]
        [TestCase("7777")]
        [TestCase("0124")]
        [TestCase("4210")]
        [TestCase("1357")]
        [TestCase("7531")]
        public void OctalPermissionsRoundTrip(string s)
        {
            // Act
            NfsFileMode fileMode = NfsFileMode.ParseOctalFileMode(s);
            string output = fileMode.ToOctalFileMode();

            // Assert
            Assert.AreEqual(s, output);
        }

        [Test]
        [TestCase("---------")]
        [TestCase("rwxrwxrwx")]
        [TestCase("r---w---x")]
        [TestCase("rwsrwsrwt")]
        [TestCase("rwSrwSrwT")]
        public void SymbolicPermissionsRoundTrip(string s)
        {
            // Act
            NfsFileMode fileMode = NfsFileMode.ParseSymbolicFileMode(s);
            string output = fileMode.ToSymbolicFileMode();

            // Assert
            Assert.AreEqual(s, output);
        }
    }
}
