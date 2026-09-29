// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Storage.Queues.Tests
{
    public class QueueAccountSasPermissionsTests
    {
        [Test]
        public void Read_ReturnsR()
        {
            Assert.AreEqual("r", QueueAccountSasPermissions.Read.ToPermissionsString());
        }

        [Test]
        public void Write_ReturnsW()
        {
            Assert.AreEqual("w", QueueAccountSasPermissions.Write.ToPermissionsString());
        }

        [Test]
        public void Delete_ReturnsD()
        {
            Assert.AreEqual("d", QueueAccountSasPermissions.Delete.ToPermissionsString());
        }

        [Test]
        public void List_ReturnsL()
        {
            Assert.AreEqual("l", QueueAccountSasPermissions.List.ToPermissionsString());
        }

        [Test]
        public void Add_ReturnsA()
        {
            Assert.AreEqual("a", QueueAccountSasPermissions.Add.ToPermissionsString());
        }

        [Test]
        public void Update_ReturnsU()
        {
            Assert.AreEqual("u", QueueAccountSasPermissions.Update.ToPermissionsString());
        }

        [Test]
        public void Process_ReturnsP()
        {
            Assert.AreEqual("p", QueueAccountSasPermissions.Process.ToPermissionsString());
        }

        [Test]
        public void AllCombined_ReturnsCorrectOrder()
        {
            var all = QueueAccountSasPermissions.Read |
                      QueueAccountSasPermissions.Write |
                      QueueAccountSasPermissions.Delete |
                      QueueAccountSasPermissions.List |
                      QueueAccountSasPermissions.Add |
                      QueueAccountSasPermissions.Update |
                      QueueAccountSasPermissions.Process;

            Assert.AreEqual("rwdlaup", all.ToPermissionsString());
        }

        [Test]
        public void None_ReturnsEmpty()
        {
            Assert.AreEqual("", ((QueueAccountSasPermissions)0).ToPermissionsString());
        }

        [Test]
        public void ReadWrite_ReturnsRW()
        {
            var permissions = QueueAccountSasPermissions.Read | QueueAccountSasPermissions.Write;

            Assert.AreEqual("rw", permissions.ToPermissionsString());
        }
    }
}
