// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

using System;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Tests
{
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class MiscellaneousTests
    {
        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Defect")]
        public void TestSHA256ManagedVsSHA256CryptoServiceProvider()
        {
            Guid subscriptionId;
            string hashedSubIdCryptoServiceProvider;
            string hashedSubIdManaged;
            for (var i = 0; i < 1000; i++)
            {
                subscriptionId = Guid.NewGuid();
                using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
                {
                    hashedSubIdCryptoServiceProvider =
                        Base32NoPaddingEncode(sha256.ComputeHash(Encoding.UTF8.GetBytes(subscriptionId.ToString())));
                }

                using (SHA256 sha256 = SHA256.Create())
                {
                    hashedSubIdManaged =
                        Base32NoPaddingEncode(sha256.ComputeHash(Encoding.UTF8.GetBytes(subscriptionId.ToString())));
                }
                Assert.IsTrue(String.Compare(hashedSubIdManaged, hashedSubIdCryptoServiceProvider, StringComparison.Ordinal) == 0,
                    string.Format("hashedSubIdManaged {0} is not same as hashedSubIdCryptoServiceProvider {1}",
                        hashedSubIdManaged, hashedSubIdCryptoServiceProvider));
            }
        }

        private static string Base32NoPaddingEncode(byte[] data)
        {
            const string Base32StandardAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

            var result = new StringBuilder(Math.Max((int)Math.Ceiling(data.Length * 8 / 5.0), 1));

            var emptyBuffer = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            var workingBuffer = new byte[8];

            // Process input 5 bytes at a time
            for (int i = 0; i < data.Length; i += 5)
            {
                int bytes = Math.Min(data.Length - i, 5);
                Array.Copy(emptyBuffer, workingBuffer, emptyBuffer.Length);
                Array.Copy(data, i, workingBuffer, workingBuffer.Length - (bytes + 1), bytes);
                Array.Reverse(workingBuffer);
                ulong val = BitConverter.ToUInt64(workingBuffer, 0);

                for (int bitOffset = ((bytes + 1) * 8) - 5; bitOffset > 3; bitOffset -= 5)
                {
                    result.Append(Base32StandardAlphabet[(int)((val >> bitOffset) & 0x1f)]);
                }
            }

            return result.ToString();
        }
    }
}
