// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using Azure.Storage.Test;

namespace Azure.Storage.DataMovement.Tests
{
    public class JobPartPlanFileNameTests
    {
        private string schemaVersion = DataMovementConstants.PlanFile.SchemaVersion;
        public JobPartPlanFileNameTests() { }

        [Test]
        public void Ctor()
        {
            // "12345678-1234-1234-1234-123456789abc--001.steV01"
            // Transfer Id: 12345678-1234-1234-1234-123456789abc
            // Part Num: 001
            JobPartPlanFileName jobFileName = new JobPartPlanFileName($"12345678-1234-1234-1234-123456789abc--00001.steV{schemaVersion}");

            Assert.AreEqual("", jobFileName.PrefixPath);
            Assert.AreEqual("12345678-1234-1234-1234-123456789abc", jobFileName.Id);
            Assert.AreEqual(1, jobFileName.JobPartNumber);
            Assert.AreEqual(schemaVersion, jobFileName.SchemaVersion);

            // "randomtransferidthataddsupto36charac--jobpart.steV01"
            // Transfer Id: randomtransferidthataddsupto36charac
            // Part Num: 001
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName($"randomtransferidthataddsupto36charac--00001.steV{schemaVersion}");

            Assert.AreEqual("", jobFileName.PrefixPath);
            Assert.AreEqual("randomtransferidthataddsupto36charac", jobFileName2.Id);
            Assert.AreEqual(1, jobFileName2.JobPartNumber);
            Assert.AreEqual(schemaVersion, jobFileName2.SchemaVersion);

            // "abcdefgh-abcd-abcd-abcd-123456789abc.steV02"
            // Transfer Id: abcdefgh-abcd-abcd-abcd-123456789abc
            // Part Num: 210
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName($"abcdefgh-abcd-abcd-abcd-123456789abc--00210.steV{schemaVersion}");

            Assert.AreEqual("", jobFileName.PrefixPath);
            Assert.AreEqual("abcdefgh-abcd-abcd-abcd-123456789abc", jobFileName3.Id);
            Assert.AreEqual(210, jobFileName3.JobPartNumber);
            Assert.AreEqual(schemaVersion, jobFileName3.SchemaVersion);
        }

        [Test]
        public void Ctor_FullPath()
        {
            // "12345678-1234-1234-1234-123456789abc--001.steV01"
            // Transfer Id: 12345678-1234-1234-1234-123456789abc
            // Part Num: 001
            JobPartPlanFileName jobFileName = new JobPartPlanFileName($"C:\\folder\\subfolder\\12345678-1234-1234-1234-123456789abc--00001.steV{schemaVersion}");

            Assert.AreEqual("C:\\folder\\subfolder", jobFileName.PrefixPath);
            Assert.AreEqual("12345678-1234-1234-1234-123456789abc", jobFileName.Id);
            Assert.AreEqual(1, jobFileName.JobPartNumber);
            Assert.AreEqual(schemaVersion, jobFileName.SchemaVersion);

            // "randomtransferidthataddsupto36charac--jobpart.steV01"
            // Transfer Id: randomtransferidthataddsupto36charac
            // Part Num: 001
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName($"F:\\folder\\foo\\randomtransferidthataddsupto36charac--00001.steV{schemaVersion}");

            Assert.AreEqual("F:\\folder\\foo", jobFileName2.PrefixPath);
            Assert.AreEqual("randomtransferidthataddsupto36charac", jobFileName2.Id);
            Assert.AreEqual(1, jobFileName2.JobPartNumber);
            Assert.AreEqual(schemaVersion, jobFileName2.SchemaVersion);

            // "abcdefgh-abcd-abcd-abcd-123456789abc.steV02"
            // Transfer Id: abcdefgh-abcd-abcd-abcd-123456789abc
            // Part Num: 210
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName($"\\folder\\sub\\abcdefgh-abcd-abcd-abcd-123456789abc--00210.steV{schemaVersion}");

            Assert.AreEqual("\\folder\\sub", jobFileName3.PrefixPath);
            Assert.AreEqual("abcdefgh-abcd-abcd-abcd-123456789abc", jobFileName3.Id);
            Assert.AreEqual(210, jobFileName3.JobPartNumber);
            Assert.AreEqual(schemaVersion, jobFileName3.SchemaVersion);
        }

        [Test]
        public void Ctor_Divided()
        {
            // "12345678-1234-1234-1234-123456789abc--001.steV01"
            // Transfer Id: 12345678-1234-1234-1234-123456789abc
            // Part Num: 001
            JobPartPlanFileName jobFileName = new JobPartPlanFileName(
                checkpointerPath: "C:\\folder\\subfolder",
                id: "12345678-1234-1234-1234-123456789abc",
                jobPartNumber: 1,
                schemaVersion: schemaVersion);

            Assert.AreEqual("C:\\folder\\subfolder", jobFileName.PrefixPath);
            Assert.AreEqual("12345678-1234-1234-1234-123456789abc", jobFileName.Id);
            Assert.AreEqual(1, jobFileName.JobPartNumber);
            Assert.AreEqual(schemaVersion, jobFileName.SchemaVersion);

            // "randomtransferidthataddsupto36charac--jobpart.steV01"
            // Transfer Id: randomtransferidthataddsupto36charac
            // Part Num: 001
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(
                checkpointerPath: "F:\\folder\\foo",
                id: "randomtransferidthataddsupto36charac",
                jobPartNumber: 1,
                schemaVersion: schemaVersion);

            Assert.AreEqual("F:\\folder\\foo", jobFileName2.PrefixPath);
            Assert.AreEqual("randomtransferidthataddsupto36charac", jobFileName2.Id);
            Assert.AreEqual(1, jobFileName2.JobPartNumber);
            Assert.AreEqual(schemaVersion, jobFileName2.SchemaVersion);

            // "abcdefgh-abcd-abcd-abcd-123456789abc.steV02"
            // Transfer Id: abcdefgh-abcd-abcd-abcd-123456789abc
            // Part Num: 210
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName(
                checkpointerPath: "\\folder\\sub",
                id: "abcdefgh-abcd-abcd-abcd-123456789abc",
                jobPartNumber: 210,
                schemaVersion: schemaVersion);

            Assert.AreEqual("\\folder\\sub", jobFileName3.PrefixPath);
            Assert.AreEqual("abcdefgh-abcd-abcd-abcd-123456789abc", jobFileName3.Id);
            Assert.AreEqual(210, jobFileName3.JobPartNumber);
            Assert.AreEqual(schemaVersion, jobFileName3.SchemaVersion);
        }

        [Test]
        public void Ctor_Error()
        {
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new JobPartPlanFileName(""),
                e => e.Message.Contains("Value cannot be an empty string"));

            TestHelper.AssertExpectedException<ArgumentException>(
                () => new JobPartPlanFileName(default),
                e => e.Message.Contains("Value cannot be null"));

            TestHelper.AssertExpectedException<ArgumentException>(
                () => new JobPartPlanFileName("badname"),
                e => e.Message.Contains("Invalid Job Part Plan File"));

            TestHelper.AssertExpectedException<ArgumentException>(
                () => new JobPartPlanFileName("invalidJobId--001.steV01"),
                e => e.Message.Contains("Invalid Job Part Plan File"));

            TestHelper.AssertExpectedException<ArgumentException>(
                () => new JobPartPlanFileName("abcdefgh-abcd-abcd-abcd-123456789abc--XY.steV01"),
                e => e.Message.Contains("Invalid Job Part Plan File"));

            TestHelper.AssertExpectedException<ArgumentException>(
                () => new JobPartPlanFileName("abcdefgh-abcd-abcd-abcd-123456789abc--001.txt"),
                e => e.Message.Contains("Invalid Job Part Plan File"));
        }

        [Test]
        public void ToStringTest()
        {
            // "12345678-1234-1234-1234-123456789abc--001.steV01"
            string originalPath = $"12345678-1234-1234-1234-123456789abc--00001.steV{schemaVersion}";
            JobPartPlanFileName jobFileName = new JobPartPlanFileName(originalPath);
            Assert.AreEqual(originalPath, jobFileName.ToString());

            // "randomtransferidthataddsupto36charac--jobpart.steV01"
            string originalPath2 = $"randomtransferidthataddsupto36charac--00001.steV{schemaVersion}";
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(originalPath2);
            Assert.AreEqual(originalPath2, jobFileName2.ToString());

            // "abcdefgh-abcd-abcd-abcd-123456789abc.steV02"
            string originalPath3 = $"abcdefgh-abcd-abcd-abcd-123456789abc--00210.steV{schemaVersion}";
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName(originalPath3);
            Assert.AreEqual(originalPath3, jobFileName3.ToString());
        }

        [Test]
        public void ToString_FullPath()
        {
            // "C:/folder/subfolder/12345678-1234-1234-1234-123456789abc--00001.steV01"
            string originalPath = $"C:/folder/subfolder/12345678-1234-1234-1234-123456789abc--00001.steV{schemaVersion}";
            JobPartPlanFileName jobFileName = new JobPartPlanFileName(originalPath);
            Assert.AreEqual(originalPath, jobFileName.ToString());

            // "F:/folder/foo/randomtransferidthataddsupto36charac--00001.steV01"
            string originalPath2 = $"F:/folder/foo/randomtransferidthataddsupto36charac--00001.steV{schemaVersion}";
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(originalPath2);
            Assert.AreEqual(originalPath2, jobFileName2.ToString());

            // "/folder/sub/abcdefgh-abcd-abcd-abcd-123456789abc--00210.steV02"
            // Transfer Id: abcdefgh-abcd-abcd-abcd-123456789abc
            // Part Num: 210
            string originalPath3 = $"/folder/sub/abcdefgh-abcd-abcd-abcd-123456789abc--00210.steV{schemaVersion}";
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName(originalPath3);
            Assert.AreEqual(originalPath3, jobFileName3.ToString());
        }

        [Test]
        public void ToString_Divided()
        {
            // "C:/folder/subfolder/12345678-1234-1234-1234-123456789abc--00001.steV01"
            string originalPath = $"C:\\folder\\subfolder\\12345678-1234-1234-1234-123456789abc--00001.steV{schemaVersion}";
            JobPartPlanFileName jobFileName = new JobPartPlanFileName(
                checkpointerPath: "C:\\folder\\subfolder",
                id: "12345678-1234-1234-1234-123456789abc",
                jobPartNumber: 1,
                schemaVersion: schemaVersion);
            Assert.AreEqual(originalPath, jobFileName.ToString());

            // "F:/folder/foo/randomtransferidthataddsupto36charac--00001.steV01"
            string originalPath2 = $"F:\\folder\\foo\\randomtransferidthataddsupto36charac--00001.steV{schemaVersion}";
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(
                checkpointerPath: "F:\\folder\\foo",
                id: "randomtransferidthataddsupto36charac",
                jobPartNumber: 1,
                schemaVersion: schemaVersion);
            Assert.AreEqual(originalPath2, jobFileName2.ToString());

            // "/folder/sub/abcdefgh-abcd-abcd-abcd-123456789abc--00210.steV02"
            // Transfer Id: abcdefgh-abcd-abcd-abcd-123456789abc
            // Part Num: 210
            string originalPath3 = $"\\folder\\sub\\abcdefgh-abcd-abcd-abcd-123456789abc--00210.steV{schemaVersion}";
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName(
                checkpointerPath: "\\folder\\sub",
                id: "abcdefgh-abcd-abcd-abcd-123456789abc",
                jobPartNumber: 210,
                schemaVersion: schemaVersion);
            Assert.AreEqual(originalPath3, jobFileName3.ToString());
        }
    }
}
