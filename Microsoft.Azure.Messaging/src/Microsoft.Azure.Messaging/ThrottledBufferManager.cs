using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Messaging
{
    sealed class ThrottledBufferManager
    {
        const int DefaultMaxSize = 1024 * 1024 * 100;
        static ThrottledBufferManager instance;
        static object syncLock = new object();

        InternalBufferManager bufferManager;
        long currentAllocationSize;

        ThrottledBufferManager(int maxSize)
        {
            this.bufferManager = InternalBufferManager.Create(maxSize, Int32.MaxValue, false);
            this.ProxyBufferManager = new WrappedBufferManager(this);
        }

        InternalBufferManager ProxyBufferManager { get; set; }

        public static InternalBufferManager GetBufferManager()
        {
            return GetThrottledBufferManager().ProxyBufferManager;
        }

        public static ThrottledBufferManager GetThrottledBufferManager()
        {
            return GetThrottledBufferManager(DefaultMaxSize);
        }

        public static ThrottledBufferManager GetThrottledBufferManager(int maxSize)
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new ThrottledBufferManager(maxSize);
                    }
                }
            }

            return instance;
        }

        public bool TryTakeBuffer(int bufferSize, out byte[] buffer)
        {
            buffer = this.bufferManager.TakeBuffer(bufferSize);

            Interlocked.Add(ref this.currentAllocationSize, buffer.Length);

            return true;
        }

        public void ReturnBuffer(byte[] buffer)
        {
            Interlocked.Add(ref this.currentAllocationSize, -buffer.Length);

            this.bufferManager.ReturnBuffer(buffer);
        }

        sealed class WrappedBufferManager : InternalBufferManager
        {
            public WrappedBufferManager(ThrottledBufferManager bufferManager)
            {
                this.ThrottledBufferManager = bufferManager;
            }

            ThrottledBufferManager ThrottledBufferManager { get; set; }

            public override void Clear()
            {
                //TODO: throw FxTrace.Exception.AsError(new NotImplementedException());
                throw new NotImplementedException();
            }

            public override void ReturnBuffer(byte[] buffer)
            {
                this.ThrottledBufferManager.ReturnBuffer(buffer);
            }

            public override byte[] TakeBuffer(int bufferSize)
            {
                byte[] result;
                this.ThrottledBufferManager.TryTakeBuffer(bufferSize, out result);
                return result;
            }
        }
    }
}
