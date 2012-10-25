// -----------------------------------------------------------------------------------------
// <copyright file="MD5WrapperTests.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    [TestClass()]
    public class MD5WrapperTests
    {
        byte[] data = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        /// <summary>
        ///Basic .net MD5 and nativemd5 comparison test
        ///</summary>
        [TestMethod()]
        public void MD5ComparisonTest()
        {
            MD5Wrapper nativeHash = new MD5Wrapper();
            nativeHash.UpdateHash(data, 0, data.Length);
            string nativeResult = nativeHash.ComputeHash();

            MD5 hash = MD5.Create();
            hash.TransformBlock(data, 0, data.Length, null, 0);
            hash.TransformFinalBlock(new byte[0], 0, 0);
            var bytes = hash.Hash;
            string result = Convert.ToBase64String(bytes);

            Assert.AreEqual(nativeResult, result);

        }

        /// <summary>
        /// Test offset to the array
        ///</summary>
        [TestMethod()]
        public void MD5SingleByteTest()
        {
            MD5Wrapper nativeHash = new MD5Wrapper();
            nativeHash.UpdateHash(data, 3, 2);
            string nativeResult = nativeHash.ComputeHash();

            MD5 hash = MD5.Create();
            hash.TransformBlock(data, 3, 2, null, 0);
            hash.TransformFinalBlock(new byte[0], 0, 0);
            var bytes = hash.Hash;
            string result = Convert.ToBase64String(bytes);

            Assert.AreEqual(nativeResult, result);
        }

        [TestMethod]
        public void MD5EmptyArrayTest()
        {
            byte[] data = new byte[] { };
            MD5Wrapper nativeHash = new MD5Wrapper();
            nativeHash.UpdateHash(data, 0, data.Length);
            string nativeResult = nativeHash.ComputeHash();


            MD5 hash = MD5.Create();
            hash.ComputeHash(data, 0, data.Length);
            var varResult = hash.Hash;
            string result = Convert.ToBase64String(varResult);

            Assert.AreEqual(nativeResult, result);

        }

        [TestMethod]
        public void MD5BigDataTest()
        {
            byte[] data = new byte[10000];
            for (int i = 1; i < 10000; i++)
            {
                data[i] = 1;
            }

            MD5Wrapper nativeHash = new MD5Wrapper();
            MD5 hash = MD5.Create();
            for (int i = 0; i < 999; i++)
            {
                int index = 10 * i;
                nativeHash.UpdateHash(data, 0, 10);
                hash.TransformBlock(data, 0, 10, null, 0);
            }
            string nativeResult = nativeHash.ComputeHash();

            hash.TransformFinalBlock(new byte[0], 0, 0);
            var varResult = hash.Hash;
            String result = Convert.ToBase64String(varResult);

            Assert.AreEqual(nativeResult, result);
        }

        [TestMethod]
        public void MD5LastByteTest()
        {
            MD5Wrapper nativeHash = new MD5Wrapper();
            nativeHash.UpdateHash(data, 8, 1);
            string nativeResult = nativeHash.ComputeHash();


            MD5 hash = MD5.Create();
            hash.ComputeHash(data, 8, 1);
            var varResult = hash.Hash;
            string result = Convert.ToBase64String(varResult);

            Assert.AreEqual(nativeResult, result);
        }
    }
}
