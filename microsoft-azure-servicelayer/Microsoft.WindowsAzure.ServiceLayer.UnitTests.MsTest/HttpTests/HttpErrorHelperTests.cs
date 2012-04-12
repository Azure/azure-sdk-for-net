//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.ServiceLayer.Http;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.MsTest.HttpTests
{
    /// <summary>
    /// Tests for encoding/decoding HRESULTs.
    /// </summary>
    [TestClass]
    public class HttpErrorHelperTests
    {
        /// <summary>
        /// Tests passing invalid error sources to the GetComErrorCode method.
        /// </summary>
        [TestMethod]
        public void InvalidErrorSource()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => HttpErrorHelper.GetComErrorCode((ErrorSource)(-1), 200));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => HttpErrorHelper.GetComErrorCode((ErrorSource)2, 200));
        }

        /// <summary>
        /// Tests passing invalid HTTP status to the GetComErrorCode method.
        /// </summary>
        [TestMethod]
        public void InvalidHttpStatus()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => HttpErrorHelper.GetComErrorCode(ErrorSource.ServiceBus, -1));
        }

        /// <summary>
        /// Tests passing invalid HRESULTs to the TranslateComErrorCode method.
        /// </summary>
        [TestMethod]
        public void InvalidHresult()
        {
            int validCode = HttpErrorHelper.GetComErrorCode(ErrorSource.ServiceBus, 400);
            ErrorSource source;
            int code;

            Assert.ThrowsException<ArgumentException>(() => HttpErrorHelper.TranslateComErrorCode(validCode & 0x7FFFFFFF, out source, out code));   // Invalid severity.
            Assert.ThrowsException<ArgumentException>(() => HttpErrorHelper.TranslateComErrorCode(validCode | 0x0000F000, out source, out code));   // Invalid error source.
            Assert.ThrowsException<ArgumentException>(() => HttpErrorHelper.TranslateComErrorCode(validCode | 0x00000FFF, out source, out code));   // Invalid error code.
        }
    }
}
