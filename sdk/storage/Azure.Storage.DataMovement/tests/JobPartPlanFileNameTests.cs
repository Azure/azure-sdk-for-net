// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using Azure.Storage.Test;
using System.IO;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement.Tests
{
    public class JobPartPlanFileNameTests
    {
        public JobPartPlanFileNameTests()
        {
        }

        [Test]
        public void Ctor()
        {
            // "12345678-1234-1234-1234-123456789abc.00001.ndmpart"
            // Transfer Id: 12345678-1234-1234-1234-123456789abc
            // Part Num: 1
            JobPartPlanFileName jobFileName = new JobPartPlanFileName($"12345678-1234-1234-1234-123456789abc.00001.ndmpart");

            Assert.AreEqual("", jobFileName.PrefixPath);
            Assert.AreEqual("12345678-1234-1234-1234-123456789abc", jobFileName.Id);
            Assert.AreEqual(1, jobFileName.JobPartNumber);

            // "randomtransferidthataddsupto36charac.jobpart.ndmpart"
            // Transfer Id: randomtransferidthataddsupto36charac
            // Part Num: 1
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName($"randomtransferidthataddsupto36charac.00210.ndmpart");

            Assert.AreEqual("", jobFileName.PrefixPath);
            Assert.AreEqual("randomtransferidthataddsupto36charac", jobFileName2.Id);
            Assert.AreEqual(210, jobFileName2.JobPartNumber);
        }

        [Test]
        public void Ctor_FullPath()
        {
            // "12345678-1234-1234-1234-123456789abc.00001.ndmpart"
            // Transfer Id: 12345678-1234-1234-1234-123456789abc
            // Part Num: 1
            string tempPath = Path.GetTempPath().TrimEnd(Path.DirectorySeparatorChar);
            string pathName1 = Path.Combine(tempPath, $"12345678-1234-1234-1234-123456789abc.00001.ndmpart");
            JobPartPlanFileName jobFileName = new JobPartPlanFileName(pathName1);

            Assert.AreEqual(tempPath, jobFileName.PrefixPath);
            Assert.AreEqual("12345678-1234-1234-1234-123456789abc", jobFileName.Id);
            Assert.AreEqual(1, jobFileName.JobPartNumber);

            // "randomtransferidthataddsupto36charac.00001.ndmpart"
            // Transfer Id: randomtransferidthataddsupto36charac
            // Part Num: 1
            string pathName2 = Path.Combine(tempPath, $"randomtransferidthataddsupto36charac.00001.ndmpart");
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(pathName2);

            Assert.AreEqual(tempPath, jobFileName2.PrefixPath);
            Assert.AreEqual("randomtransferidthataddsupto36charac", jobFileName2.Id);
            Assert.AreEqual(1, jobFileName2.JobPartNumber);

            // "abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart"
            // Transfer Id: abcdefgh-abcd-abcd-abcd-123456789abc
            // Part Num: 210
            string prefixPath3 = Path.Combine("folder", "sub");
            string pathName3 = Path.Combine(prefixPath3, $"abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart");
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName(pathName3);

            Assert.AreEqual(prefixPath3, jobFileName3.PrefixPath);
            Assert.AreEqual("abcdefgh-abcd-abcd-abcd-123456789abc", jobFileName3.Id);
            Assert.AreEqual(210, jobFileName3.JobPartNumber);
        }

        [Test]
        public void Ctor_Divided()
        {
            // "12345678-1234-1234-1234-123456789abc.001.ndmpart"
            // Transfer Id: 12345678-1234-1234-1234-123456789abc
            // Part Num: 001
            JobPartPlanFileName jobFileName = new JobPartPlanFileName(
                checkpointerPath: "C:\\folder\\subfolder",
                id: "12345678-1234-1234-1234-123456789abc",
                jobPartNumber: 1);

            Assert.AreEqual("C:\\folder\\subfolder", jobFileName.PrefixPath);
            Assert.AreEqual("12345678-1234-1234-1234-123456789abc", jobFileName.Id);
            Assert.AreEqual(1, jobFileName.JobPartNumber);

            // "randomtransferidthataddsupto36charac.jobpart.ndmpart"
            // Transfer Id: randomtransferidthataddsupto36charac
            // Part Num: 1
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(
                checkpointerPath: "F:\\folder\\foo",
                id: "randomtransferidthataddsupto36charac",
                jobPartNumber: 1);

            Assert.AreEqual("F:\\folder\\foo", jobFileName2.PrefixPath);
            Assert.AreEqual("randomtransferidthataddsupto36charac", jobFileName2.Id);
            Assert.AreEqual(1, jobFileName2.JobPartNumber);

            // "abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart"
            // Transfer Id: abcdefgh-abcd-abcd-abcd-123456789abc
            // Part Num: 210
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName(
                checkpointerPath: "\\folder\\sub",
                id: "abcdefgh-abcd-abcd-abcd-123456789abc",
                jobPartNumber: 210);

            Assert.AreEqual("\\folder\\sub", jobFileName3.PrefixPath);
            Assert.AreEqual("abcdefgh-abcd-abcd-abcd-123456789abc", jobFileName3.Id);
            Assert.AreEqual(210, jobFileName3.JobPartNumber);
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
                () => new JobPartPlanFileName("invalidJobId.001.ndmpart"),
                e => e.Message.Contains("Invalid Checkpoint File"));

            TestHelper.AssertExpectedException<ArgumentException>(
                () => new JobPartPlanFileName("abcdefgh-abcd-abcd-abcd-123456789abc.XY.ndmpart"),
                e => e.Message.Contains("Invalid Job Part Plan File"));

            TestHelper.AssertExpectedException<ArgumentException>(
                () => new JobPartPlanFileName("abcdefgh-abcd-abcd-abcd-123456789abc.001.txt"),
                e => e.Message.Contains("Invalid Job Part Plan File"));
        }

        [Test]
        public void ToStringTest()
        {
            string originalPath = $"12345678-1234-1234-1234-123456789abc.00001.ndmpart";
            JobPartPlanFileName jobFileName = new JobPartPlanFileName(originalPath);
            Assert.AreEqual(originalPath, jobFileName.ToString());

            string originalPath2 = $"randomtransferidthataddsupto36charac.00210.ndmpart";
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(originalPath2);
            Assert.AreEqual(originalPath2, jobFileName2.ToString());
        }

        [Test]
        public void ToString_FullPath()
        {
            // "C:/folder/subfolder/12345678-1234-1234-1234-123456789abc.00001.ndmpart"
            string tempPath = Path.GetTempPath().TrimEnd(Path.DirectorySeparatorChar);
            string originalPath = Path.Combine(tempPath, $"12345678-1234-1234-1234-123456789abc.00001.ndmpart");
            JobPartPlanFileName jobFileName = new JobPartPlanFileName(originalPath);
            Assert.AreEqual(originalPath, jobFileName.ToString());

            // "F:/folder/foo/randomtransferidthataddsupto36charac.00001.ndmpart"
            string originalPath2 = Path.Combine(tempPath, $"randomtransferidthataddsupto36charac.00001.ndmpart");
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(originalPath2);
            Assert.AreEqual(originalPath2, jobFileName2.ToString());

            // "/folder/sub/abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart"
            string prefixPath3 = Path.Combine("folder", "sub");
            string originalPath3 = Path.Combine(prefixPath3, $"abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart");
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName(originalPath3);
            Assert.AreEqual(originalPath3, jobFileName3.ToString());
        }

        [Test]
        public void ToString_Divided()
        {
            // "C:/folder/subfolder/12345678-1234-1234-1234-123456789abc.00001.ndmpart"
            string tempPath = Path.GetTempPath().TrimEnd(Path.DirectorySeparatorChar);
            string originalPath = Path.Combine(tempPath, $"12345678-1234-1234-1234-123456789abc.00001.ndmpart");
            JobPartPlanFileName jobFileName = new JobPartPlanFileName(
                checkpointerPath: tempPath,
                id: "12345678-1234-1234-1234-123456789abc",
                jobPartNumber: 1);
            Assert.AreEqual(originalPath, jobFileName.ToString());

            // "F:/folder/foo/randomtransferidthataddsupto36charac.00001.ndmpart"
            string originalPath2 = Path.Combine(tempPath, $"randomtransferidthataddsupto36charac.00001.ndmpart");
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(
                checkpointerPath: tempPath,
                id: "randomtransferidthataddsupto36charac",
                jobPartNumber: 1);
            Assert.AreEqual(originalPath2, jobFileName2.ToString());

            // "/folder/sub/abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart"
            string prefixPath3 = Path.Combine("folder", "sub");
            string originalPath3 = Path.Combine(prefixPath3, $"abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart");
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName(
                checkpointerPath: prefixPath3,
                id: "abcdefgh-abcd-abcd-abcd-123456789abc",
                jobPartNumber: 210);
            Assert.AreEqual(originalPath3, jobFileName3.ToString());
        }
    }
}
