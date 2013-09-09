// -----------------------------------------------------------------------------------------
// <copyright file="WCFBufferManagerAdapter.cs" company="Microsoft">
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

using System.ServiceModel.Channels;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage
{
    public class WCFBufferManagerAdapter : IBufferManager
    {
        private int defaultBufferSize = 0;

        public WCFBufferManagerAdapter(BufferManager manager, int defaultBufferSize)
        {
            this.Manager = manager;
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

        public BufferManager Manager { get; internal set; }

        public void ReturnBuffer(byte[] buffer)
        {
            Interlocked.Decrement(ref outstandingBufferCount);
            this.Manager.ReturnBuffer(buffer);
        }

        public byte[] TakeBuffer(int bufferSize)
        {
            Interlocked.Increment(ref outstandingBufferCount);
            return this.Manager.TakeBuffer(bufferSize);
        }

        public int GetDefaultBufferSize()
        {
            return this.defaultBufferSize;
        }
    }
}
