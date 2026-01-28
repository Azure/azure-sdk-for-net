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

            Assert.That(result.InitialTransferSize, Is.EqualTo(4 * Constants.MB));
            Assert.That(result.MaximumTransferSize, Is.EqualTo(4 * Constants.MB));
            Assert.That(result.MaximumConcurrency, Is.EqualTo(1));
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

            Assert.That(resultInitial.InitialTransferSize, Is.EqualTo(prepopulatedValue));
            Assert.That(resultInitial.MaximumTransferSize, Is.EqualTo(4 * Constants.MB));
            Assert.That(resultInitial.MaximumConcurrency, Is.EqualTo(1));

            Assert.That(resultMaximum.InitialTransferSize, Is.EqualTo(4 * Constants.MB));
            Assert.That(resultMaximum.MaximumTransferSize, Is.EqualTo(prepopulatedValue));
            Assert.That(resultMaximum.MaximumConcurrency, Is.EqualTo(1));

            Assert.That(resultConcurrency.InitialTransferSize, Is.EqualTo(4 * Constants.MB));
            Assert.That(resultConcurrency.MaximumTransferSize, Is.EqualTo(4 * Constants.MB));
            Assert.That(resultConcurrency.MaximumConcurrency, Is.EqualTo(prepopulatedValue));
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
