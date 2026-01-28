// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class StorageTransferOptionsTests
    {
        /// <summary>
        /// Tests non-throwing cases for backwards compatibility of int? facade
        /// <see cref="StorageTransferOptions.MaximumTransferLength"/>.
        /// </summary>
        /// <param name="realSize"></param>
        [TestCase(default)]
        [TestCase(1)]
        [TestCase(int.MaxValue)]
        public void MaxTransferLengthBackCompatTest(long? realSize)
        {
            var options = new StorageTransferOptions
            {
                MaximumTransferSize = realSize
            };

            Assert.That(realSize, Is.EqualTo(options.MaximumTransferSize));
            Assert.That(realSize, Is.EqualTo(options.MaximumTransferLength));
        }

        /// <summary>
        /// Tests throwing cases for backwards compatibility of int? facade
        /// <see cref="StorageTransferOptions.MaximumTransferLength"/>.
        /// </summary>
        /// <param name="realSize"></param>
        [TestCase(int.MaxValue + 1L)]
        [TestCase(long.MaxValue)]
        public void MaxTransferLengthBackCompatOverflowTest(long? realSize)
        {
            var options = new StorageTransferOptions
            {
                MaximumTransferSize = realSize
            };

            Assert.That(realSize, Is.EqualTo(options.MaximumTransferSize));
            Assert.Throws<OverflowException>(() => _ = options.MaximumTransferLength);
        }

        /// <summary>
        /// Tests non-throwing cases for backwards compatibility of int? facade
        /// <see cref="StorageTransferOptions.MaximumTransferLength"/>.
        /// </summary>
        /// <param name="realSize"></param>
        [TestCase(default)]
        [TestCase(1)]
        [TestCase(int.MaxValue)]
        public void InitialTransferLengthBackCompatTest(long? realSize)
        {
            var options = new StorageTransferOptions
            {
                InitialTransferSize = realSize
            };

            Assert.That(realSize, Is.EqualTo(options.InitialTransferSize));
            Assert.That(realSize, Is.EqualTo(options.InitialTransferLength));
        }

        /// <summary>
        /// Tests throwing cases for backwards compatibility of int? facade
        /// <see cref="StorageTransferOptions.MaximumTransferLength"/>.
        /// </summary>
        /// <param name="realSize"></param>
        [TestCase(int.MaxValue + 1L)]
        [TestCase(long.MaxValue)]
        public void InitialTransferLengthBackCompatOverflowTest(long? realSize)
        {
            var options = new StorageTransferOptions
            {
                InitialTransferSize = realSize
            };

            Assert.That(realSize, Is.EqualTo(options.InitialTransferSize));
            Assert.Throws<OverflowException>(() => _ = options.InitialTransferLength);
        }
    }
}
