// -----------------------------------------------------------------------------------------
// <copyright file="TestHelper.Common.cs" company="Microsoft">
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

using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

#if WINDOWS_DESKTOP
using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#endif

namespace Microsoft.WindowsAzure.Storage
{
    public class MockBufferManager : IBufferManager
    {
        private int defaultBufferSize = 0;

        public MockBufferManager(int defaultBufferSize)
        {
            this.defaultBufferSize = defaultBufferSize;
        }

        private int outstandingBufferCount = 0;
        public int OutstandingBufferCount
        {
            get
            {
                return Interlocked.CompareExchange(ref outstandingBufferCount, 0, 0);
            }
            set
            {
                Interlocked.Exchange(ref outstandingBufferCount, value);
            }
        }

        public void ReturnBuffer(byte[] buffer)
        {
            Interlocked.Decrement(ref outstandingBufferCount);
            // no op
        }

        public byte[] TakeBuffer(int bufferSize)
        {
            Interlocked.Increment(ref outstandingBufferCount);
            return new byte[bufferSize];
        }

        public int GetDefaultBufferSize()
        {
            return this.defaultBufferSize;
        }
    }
}
