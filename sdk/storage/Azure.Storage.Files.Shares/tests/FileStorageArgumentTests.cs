// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    [TestFixture]
    public class FileStorageArgumentTests
    {
        [Test]
        public void PopulateShareFileUploadTransferOptionDefaultsTest()
        {
            StorageTransferOptions result = StorageArgument.PopulateShareFileUploadTransferOptionDefaults(
                new StorageTransferOptions());

            Assert.AreEqual(4 * Constants.MB, result.InitialTransferSize);
            Assert.AreEqual(4 * Constants.MB, result.MaximumTransferSize);
            Assert.AreEqual(1, result.MaximumConcurrency);
        }

        [Test]
        public void PopulateShareFileUploadTransferOptionDefaultsTest_NoOverwrite()
        {
            int prepopulatedValue = 12345;

            StorageTransferOptions resultInitial = StorageArgument.PopulateShareFileUploadTransferOptionDefaults(
                new StorageTransferOptions
                {
                    InitialTransferSize = prepopulatedValue
                });

            StorageTransferOptions resultMaximum = StorageArgument.PopulateShareFileUploadTransferOptionDefaults(
                new StorageTransferOptions
                {
                    MaximumTransferSize = prepopulatedValue
                });

            StorageTransferOptions resultConcurrency = StorageArgument.PopulateShareFileUploadTransferOptionDefaults(
                new StorageTransferOptions
                {
                    MaximumConcurrency = prepopulatedValue
                });

            Assert.AreEqual(prepopulatedValue, resultInitial.InitialTransferSize);
            Assert.AreEqual(4 * Constants.MB, resultInitial.MaximumTransferSize);
            Assert.AreEqual(1, resultInitial.MaximumConcurrency);

            Assert.AreEqual(4 * Constants.MB, resultMaximum.InitialTransferSize);
            Assert.AreEqual(prepopulatedValue, resultMaximum.MaximumTransferSize);
            Assert.AreEqual(1, resultMaximum.MaximumConcurrency);

            Assert.AreEqual(4 * Constants.MB, resultConcurrency.InitialTransferSize);
            Assert.AreEqual(4 * Constants.MB, resultConcurrency.MaximumTransferSize);
            Assert.AreEqual(prepopulatedValue, resultConcurrency.MaximumConcurrency);
        }

        [Test]
        public void AssertTransferOptionsDefinedInBounds_Max()
        {
            string argName = "myTransferOptions";

            Assert.Throws<ArgumentOutOfRangeException>(
                () => StorageArgument.AssertShareFileUploadTransferOptionBounds(
                    new StorageTransferOptions
                    {
                        InitialTransferSize = long.MaxValue,
                        MaximumTransferSize = Constants.KB,
                        MaximumConcurrency = 1
                    },
                    argName),
                $"Value is greater than the maximum allowed. (Parameter '{argName}.InitialTransferSize')");
            Assert.Throws<ArgumentOutOfRangeException>(
                () => StorageArgument.AssertShareFileUploadTransferOptionBounds(
                    new StorageTransferOptions
                    {
                        InitialTransferSize = Constants.KB,
                        MaximumTransferSize = long.MaxValue,
                        MaximumConcurrency = 1
                    },
                    argName),
                $"Value is greater than the maximum allowed. (Parameter '{argName}.MaximumTransferSize')");
            Assert.Throws<ArgumentOutOfRangeException>(
                () => StorageArgument.AssertShareFileUploadTransferOptionBounds(
                    new StorageTransferOptions
                    {
                        InitialTransferSize = Constants.KB,
                        MaximumTransferSize = Constants.KB,
                        MaximumConcurrency = int.MaxValue
                    },
                    argName),
                $"Value is greater than the maximum allowed. (Parameter '{argName}.MaximumConcurrency')");
        }

        [Test]
        public void AssertTransferOptionsDefinedInBounds_Min()
        {
            string argName = "myTransferOptions";

            Assert.Throws<ArgumentOutOfRangeException>(
                () => StorageArgument.AssertShareFileUploadTransferOptionBounds(
                    new StorageTransferOptions
                    {
                        InitialTransferSize = 0,
                        MaximumTransferSize = Constants.KB,
                        MaximumConcurrency = 1
                    },
                    argName),
                $"Value is less than the minimum allowed. (Parameter '{argName}.InitialTransferSize')");
            Assert.Throws<ArgumentOutOfRangeException>(
                () => StorageArgument.AssertShareFileUploadTransferOptionBounds(
                    new StorageTransferOptions
                    {
                        InitialTransferSize = Constants.KB,
                        MaximumTransferSize = 0,
                        MaximumConcurrency = 1
                    },
                    argName),
                $"Value is less than the minimum allowed. (Parameter '{argName}.MaximumTransferSize')");
            Assert.Throws<ArgumentOutOfRangeException>(
                () => StorageArgument.AssertShareFileUploadTransferOptionBounds(
                    new StorageTransferOptions
                    {
                        InitialTransferSize = Constants.KB,
                        MaximumTransferSize = Constants.KB,
                        MaximumConcurrency = 0
                    },
                    argName),
                $"Value is less than the minimum allowed. (Parameter '{argName}.MaximumConcurrency')");
        }
    }
}
