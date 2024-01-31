// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    [TestFixture]
    public class StorageArgumentTests
    {
        [Test]
        public void AssertTransferOptionsDefinedTest()
        {
            string argName = "myTransferOptions";

            Assert.Throws<ArgumentNullException>(
                () => StorageArgument.AssertTransferOptionsDefined(
                    new StorageTransferOptions
                    {
                        InitialTransferSize = Constants.KB,
                        MaximumTransferSize = Constants.KB,
                    },
                    argName),
                $"{argName}.MaximumConcurrency");
            Assert.Throws<ArgumentNullException>(
                () => StorageArgument.AssertTransferOptionsDefined(
                    new StorageTransferOptions
                    {
                        InitialTransferSize = Constants.KB,
                        MaximumConcurrency = 2
                    },
                    argName),
                $"{argName}.MaximumTransferSize");
            Assert.Throws<ArgumentNullException>(
                () => StorageArgument.AssertTransferOptionsDefined(
                    new StorageTransferOptions
                    {
                        MaximumTransferSize = Constants.KB,
                        MaximumConcurrency = 2
                    },
                    argName),
                $"{argName}.InitialTransferSize");
            Assert.DoesNotThrow(
                () => StorageArgument.AssertTransferOptionsDefined(
                    new StorageTransferOptions
                    {
                        InitialTransferSize = Constants.KB,
                        MaximumTransferSize = Constants.KB,
                        MaximumConcurrency = 2
                    },
                    argName));
        }

        [Test]
        public void AssertTransferOptionsDefinedInBounds_Max()
        {
            string argName = "myTransferOptions";
            var options = new StorageTransferOptions
            {
                InitialTransferSize = Constants.KB,
                MaximumTransferSize = Constants.KB,
                MaximumConcurrency = 4
            };

            Assert.Throws<ArgumentOutOfRangeException>(
                () => StorageArgument.AssertTransferOptionsDefinedInBounds(
                    options,
                    argName,
                    upperBoundInitial: options.InitialTransferSize.Value - 1),
                $"Value is greater than the maximum allowed. (Parameter '{argName}.InitialTransferSize')");
            Assert.Throws<ArgumentOutOfRangeException>(
                () => StorageArgument.AssertTransferOptionsDefinedInBounds(
                    options,
                    argName,
                    upperBoundMaximum: options.MaximumTransferSize.Value - 1),
                $"Value is greater than the maximum allowed. (Parameter '{argName}.MaximumTransferSize')");
            Assert.Throws<ArgumentOutOfRangeException>(
                () => StorageArgument.AssertTransferOptionsDefinedInBounds(
                    options,
                    argName,
                    upperBoundConcurrency: options.MaximumConcurrency.Value - 1),
                $"Value is greater than the maximum allowed. (Parameter '{argName}.MaximumConcurrency')");
        }

        [Test]
        public void AssertTransferOptionsDefinedInBounds_Min()
        {
            string argName = "myTransferOptions";

            Assert.Throws<ArgumentOutOfRangeException>(
                () => StorageArgument.AssertTransferOptionsDefinedInBounds(
                    new StorageTransferOptions
                    {
                        InitialTransferSize = 0,
                        MaximumTransferSize = Constants.KB,
                        MaximumConcurrency = 4
                    },
                    argName),
                $"Value is less than the minimum allowed. (Parameter '{argName}.InitialTransferSize')");
            Assert.Throws<ArgumentOutOfRangeException>(
                () => StorageArgument.AssertTransferOptionsDefinedInBounds(
                    new StorageTransferOptions
                    {
                        InitialTransferSize = Constants.KB,
                        MaximumTransferSize = 0,
                        MaximumConcurrency = 4
                    },
                    argName),
                $"Value is less than the minimum allowed. (Parameter '{argName}.MaximumTransferSize')");
            Assert.Throws<ArgumentOutOfRangeException>(
                () => StorageArgument.AssertTransferOptionsDefinedInBounds(
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
