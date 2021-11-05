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

            Assert.AreEqual(options.MaximumTransferSize, realSize);
            Assert.AreEqual(options.MaximumTransferLength, realSize);
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

            Assert.AreEqual(options.MaximumTransferSize, realSize);
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

            Assert.AreEqual(options.InitialTransferSize, realSize);
            Assert.AreEqual(options.InitialTransferLength, realSize);
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

            Assert.AreEqual(options.InitialTransferSize, realSize);
            Assert.Throws<OverflowException>(() => _ = options.InitialTransferLength);
        }
    }
}
