// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Storage.DataMovement.JobPlan;
using Azure.Storage.Test;
using NUnit.Framework;

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

            Assert.That(jobFileName.PrefixPath, Is.Empty);
            Assert.That(jobFileName.Id, Is.EqualTo("12345678-1234-1234-1234-123456789abc"));
            Assert.That(jobFileName.JobPartNumber, Is.EqualTo(1));

            // "randomtransferidthataddsupto36charac.jobpart.ndmpart"
            // Transfer Id: randomtransferidthataddsupto36charac
            // Part Num: 1
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName($"randomtransferidthataddsupto36charac.00210.ndmpart");

            Assert.That(jobFileName.PrefixPath, Is.Empty);
            Assert.That(jobFileName2.Id, Is.EqualTo("randomtransferidthataddsupto36charac"));
            Assert.That(jobFileName2.JobPartNumber, Is.EqualTo(210));
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

            Assert.That(jobFileName.PrefixPath, Is.EqualTo(tempPath));
            Assert.That(jobFileName.Id, Is.EqualTo("12345678-1234-1234-1234-123456789abc"));
            Assert.That(jobFileName.JobPartNumber, Is.EqualTo(1));

            // "randomtransferidthataddsupto36charac.00001.ndmpart"
            // Transfer Id: randomtransferidthataddsupto36charac
            // Part Num: 1
            string pathName2 = Path.Combine(tempPath, $"randomtransferidthataddsupto36charac.00001.ndmpart");
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(pathName2);

            Assert.That(jobFileName2.PrefixPath, Is.EqualTo(tempPath));
            Assert.That(jobFileName2.Id, Is.EqualTo("randomtransferidthataddsupto36charac"));
            Assert.That(jobFileName2.JobPartNumber, Is.EqualTo(1));

            // "abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart"
            // Transfer Id: abcdefgh-abcd-abcd-abcd-123456789abc
            // Part Num: 210
            string prefixPath3 = Path.Combine("folder", "sub");
            string pathName3 = Path.Combine(prefixPath3, $"abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart");
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName(pathName3);

            Assert.That(jobFileName3.PrefixPath, Is.EqualTo(prefixPath3));
            Assert.That(jobFileName3.Id, Is.EqualTo("abcdefgh-abcd-abcd-abcd-123456789abc"));
            Assert.That(jobFileName3.JobPartNumber, Is.EqualTo(210));
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

            Assert.That(jobFileName.PrefixPath, Is.EqualTo("C:\\folder\\subfolder"));
            Assert.That(jobFileName.Id, Is.EqualTo("12345678-1234-1234-1234-123456789abc"));
            Assert.That(jobFileName.JobPartNumber, Is.EqualTo(1));

            // "randomtransferidthataddsupto36charac.jobpart.ndmpart"
            // Transfer Id: randomtransferidthataddsupto36charac
            // Part Num: 1
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(
                checkpointerPath: "F:\\folder\\foo",
                id: "randomtransferidthataddsupto36charac",
                jobPartNumber: 1);

            Assert.That(jobFileName2.PrefixPath, Is.EqualTo("F:\\folder\\foo"));
            Assert.That(jobFileName2.Id, Is.EqualTo("randomtransferidthataddsupto36charac"));
            Assert.That(jobFileName2.JobPartNumber, Is.EqualTo(1));

            // "abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart"
            // Transfer Id: abcdefgh-abcd-abcd-abcd-123456789abc
            // Part Num: 210
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName(
                checkpointerPath: "\\folder\\sub",
                id: "abcdefgh-abcd-abcd-abcd-123456789abc",
                jobPartNumber: 210);

            Assert.That(jobFileName3.PrefixPath, Is.EqualTo("\\folder\\sub"));
            Assert.That(jobFileName3.Id, Is.EqualTo("abcdefgh-abcd-abcd-abcd-123456789abc"));
            Assert.That(jobFileName3.JobPartNumber, Is.EqualTo(210));
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
            Assert.That(jobFileName.ToString(), Is.EqualTo(originalPath));

            string originalPath2 = $"randomtransferidthataddsupto36charac.00210.ndmpart";
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(originalPath2);
            Assert.That(jobFileName2.ToString(), Is.EqualTo(originalPath2));
        }

        [Test]
        public void ToString_FullPath()
        {
            // "C:/folder/subfolder/12345678-1234-1234-1234-123456789abc.00001.ndmpart"
            string tempPath = Path.GetTempPath().TrimEnd(Path.DirectorySeparatorChar);
            string originalPath = Path.Combine(tempPath, $"12345678-1234-1234-1234-123456789abc.00001.ndmpart");
            JobPartPlanFileName jobFileName = new JobPartPlanFileName(originalPath);
            Assert.That(jobFileName.ToString(), Is.EqualTo(originalPath));

            // "F:/folder/foo/randomtransferidthataddsupto36charac.00001.ndmpart"
            string originalPath2 = Path.Combine(tempPath, $"randomtransferidthataddsupto36charac.00001.ndmpart");
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(originalPath2);
            Assert.That(jobFileName2.ToString(), Is.EqualTo(originalPath2));

            // "/folder/sub/abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart"
            string prefixPath3 = Path.Combine("folder", "sub");
            string originalPath3 = Path.Combine(prefixPath3, $"abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart");
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName(originalPath3);
            Assert.That(jobFileName3.ToString(), Is.EqualTo(originalPath3));
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
            Assert.That(jobFileName.ToString(), Is.EqualTo(originalPath));

            // "F:/folder/foo/randomtransferidthataddsupto36charac.00001.ndmpart"
            string originalPath2 = Path.Combine(tempPath, $"randomtransferidthataddsupto36charac.00001.ndmpart");
            JobPartPlanFileName jobFileName2 = new JobPartPlanFileName(
                checkpointerPath: tempPath,
                id: "randomtransferidthataddsupto36charac",
                jobPartNumber: 1);
            Assert.That(jobFileName2.ToString(), Is.EqualTo(originalPath2));

            // "/folder/sub/abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart"
            string prefixPath3 = Path.Combine("folder", "sub");
            string originalPath3 = Path.Combine(prefixPath3, $"abcdefgh-abcd-abcd-abcd-123456789abc.00210.ndmpart");
            JobPartPlanFileName jobFileName3 = new JobPartPlanFileName(
                checkpointerPath: prefixPath3,
                id: "abcdefgh-abcd-abcd-abcd-123456789abc",
                jobPartNumber: 210);
            Assert.That(jobFileName3.ToString(), Is.EqualTo(originalPath3));
        }
    }
}
