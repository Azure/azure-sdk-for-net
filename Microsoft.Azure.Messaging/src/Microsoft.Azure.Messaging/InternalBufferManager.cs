using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Messaging
{
    abstract class InternalBufferManager
    {
        protected InternalBufferManager()
        {
        }

        public abstract byte[] TakeBuffer(int bufferSize);
        public abstract void ReturnBuffer(byte[] buffer);
        public abstract void Clear();

        public static InternalBufferManager Create(long maxBufferPoolSize, int maxBufferSize, bool isTransportBufferPool)
        {
            if (maxBufferPoolSize == 0)
            {
                return GCBufferManager.Value;
            }
            else
            {
                Fx.Assert(maxBufferPoolSize > 0 && maxBufferSize >= 0, "bad params, caller should verify");
                if (isTransportBufferPool)
                {
                    return new PreallocatedBufferManager(maxBufferPoolSize, maxBufferSize);
                }
                else
                {
                    return new PooledBufferManager(maxBufferPoolSize, maxBufferSize);
                }
            }
        }

        public static byte[] AllocateByteArray(int size)
        {
            //TODO: MessagingClientEtwProvider.Provider.EventWriteBufferManagerAllocatedNewArray(size);
            // This will be inlined in retail bits but provides a 
            // common entry point for debugging all buffer allocations 
            // and can be instrumented if necessary. 
            return new byte[size];
        }

        class PreallocatedBufferManager : InternalBufferManager
        {
            readonly int maxBufferSize;
            readonly int smallBufferSize;
            readonly ConcurrentQueue<byte[]> freeSmallBuffers;
            readonly ConcurrentQueue<byte[]> freeLargeBuffers;
            int outstandingTakes;

            internal PreallocatedBufferManager(long maxMemoryToPool, int maxBufferSize)
            {
                // default values: maxMemoryToPool = 48MB, maxBufferSize = 64KB
                // This creates the following buffers:
                // max: 64KB = 192, small 8KB = 4608
                this.maxBufferSize = maxBufferSize;
                this.smallBufferSize = maxBufferSize / 8;

                long largePoolSize = maxMemoryToPool / 4;
                long numLargeBuffers = largePoolSize / maxBufferSize;
                long numSmallBuffers = (maxMemoryToPool - largePoolSize) / smallBufferSize;

                this.freeSmallBuffers = new ConcurrentQueue<byte[]>();
                this.freeLargeBuffers = new ConcurrentQueue<byte[]>();

                for (int i = 0; i < numLargeBuffers; i++)
                {
                    this.freeLargeBuffers.Enqueue(new byte[maxBufferSize]);
                }

                for (int i = 0; i < numSmallBuffers; i++)
                {
                    this.freeSmallBuffers.Enqueue(new byte[smallBufferSize]);
                }
            }

            public override byte[] TakeBuffer(int bufferSize)
            {
                if (Interlocked.Increment(ref this.outstandingTakes) % 10000 == 0)
                {
                    //TODO:MessagingClientEtwProvider.Provider.EventWriteAmqpBufferHighTakeCount(this.GetType().Name, this.outstandingTakes);
                }

                byte[] returnedBuffer = null;
                if (bufferSize <= this.smallBufferSize)
                {
                    this.freeSmallBuffers.TryDequeue(out returnedBuffer);
                }
                else if (bufferSize <= this.maxBufferSize)
                {
                    this.freeLargeBuffers.TryDequeue(out returnedBuffer);
                }

                return returnedBuffer;
            }

            /// <summary>
            /// Returned buffer must have been acquired via a call to TakeBuffer
            /// </summary>
            /// <param name="buffer"></param>
            public override void ReturnBuffer(byte[] buffer)
            {
                Interlocked.Decrement(ref this.outstandingTakes);

                if (buffer.Length == this.smallBufferSize)
                {
                    this.freeSmallBuffers.Enqueue(buffer);
                }
                else if (buffer.Length == this.maxBufferSize)
                {
                    this.freeLargeBuffers.Enqueue(buffer);
                }
            }

            public override void Clear()
            {
                byte[] buffer;
                while (this.freeSmallBuffers.TryDequeue(out buffer)) ;
                while (this.freeLargeBuffers.TryDequeue(out buffer)) ;
            }
        }

        class PooledBufferManager : InternalBufferManager
        {
            const int minBufferSize = 128;
            const int maxMissesBeforeTuning = 8;
            const int initialBufferCount = 1;
            readonly object tuningLock;

            int[] bufferSizes;
            BufferPool[] bufferPools;
            long remainingMemory;
            bool areQuotasBeingTuned;
            int totalMisses;

            public PooledBufferManager(long maxMemoryToPool, int maxBufferSize)
            {
                this.tuningLock = new object();
                this.remainingMemory = maxMemoryToPool;
                List<BufferPool> bufferPoolList = new List<BufferPool>();

                for (int bufferSize = minBufferSize; ;)
                {
                    long bufferCountLong = this.remainingMemory / bufferSize;

                    int bufferCount = bufferCountLong > int.MaxValue ? int.MaxValue : (int)bufferCountLong;

                    if (bufferCount > initialBufferCount)
                    {
                        bufferCount = initialBufferCount;
                    }

                    bufferPoolList.Add(BufferPool.CreatePool(bufferSize, bufferCount));

                    this.remainingMemory -= (long)bufferCount * bufferSize;

                    if (bufferSize >= maxBufferSize)
                    {
                        break;
                    }

                    long newBufferSizeLong = (long)bufferSize * 2;

                    if (newBufferSizeLong > (long)maxBufferSize)
                    {
                        bufferSize = maxBufferSize;
                    }
                    else
                    {
                        bufferSize = (int)newBufferSizeLong;
                    }
                }

                this.bufferPools = bufferPoolList.ToArray();
                this.bufferSizes = new int[bufferPools.Length];
                for (int i = 0; i < bufferPools.Length; i++)
                {
                    this.bufferSizes[i] = bufferPools[i].BufferSize;
                }
            }

            public override void Clear()
            {
                for (int i = 0; i < this.bufferPools.Length; i++)
                {
                    BufferPool bufferPool = this.bufferPools[i];
                    bufferPool.Clear();
                }
            }

            void ChangeQuota(ref BufferPool bufferPool, int delta)
            {
                BufferPool oldBufferPool = bufferPool;
                int newLimit = oldBufferPool.Limit + delta;
                BufferPool newBufferPool = BufferPool.CreatePool(oldBufferPool.BufferSize, newLimit);
                for (int i = 0; i < newLimit; i++)
                {
                    byte[] buffer = oldBufferPool.Take();
                    if (buffer == null)
                    {
                        break;
                    }
                    newBufferPool.Return(buffer);
                    newBufferPool.IncrementCount();
                }
                this.remainingMemory -= oldBufferPool.BufferSize * delta;
                bufferPool = newBufferPool;
            }

            void DecreaseQuota(ref BufferPool bufferPool)
            {
                //TODO:MessagingClientEtwProvider.Provider.EventWriteBufferQuotaDecreased(bufferPool.BufferSize, bufferPool.Limit);
                ChangeQuota(ref bufferPool, -1);
            }

            int FindMostExcessivePool()
            {
                long maxBytesInExcess = 0;
                int index = -1;

                for (int i = 0; i < this.bufferPools.Length; i++)
                {
                    BufferPool bufferPool = this.bufferPools[i];

                    if (bufferPool.Peak < bufferPool.Limit)
                    {
                        long bytesInExcess = (bufferPool.Limit - bufferPool.Peak) * (long)bufferPool.BufferSize;

                        if (bytesInExcess > maxBytesInExcess)
                        {
                            index = i;
                            maxBytesInExcess = bytesInExcess;
                        }
                    }
                }

                return index;
            }

            int FindMostStarvedPool()
            {
                long maxBytesMissed = 0;
                int index = -1;

                for (int i = 0; i < this.bufferPools.Length; i++)
                {
                    BufferPool bufferPool = this.bufferPools[i];

                    if (bufferPool.Peak == bufferPool.Limit)
                    {
                        long bytesMissed = bufferPool.Misses * (long)bufferPool.BufferSize;

                        if (bytesMissed > maxBytesMissed)
                        {
                            index = i;
                            maxBytesMissed = bytesMissed;
                        }
                    }
                }

                return index;
            }

            BufferPool FindPool(int desiredBufferSize)
            {
                for (int i = 0; i < this.bufferSizes.Length; i++)
                {
                    if (desiredBufferSize <= this.bufferSizes[i])
                    {
                        return this.bufferPools[i];
                    }
                }

                return null;
            }

            void IncreaseQuota(ref BufferPool bufferPool)
            {
                //TODO:MessagingClientEtwProvider.Provider.EventWriteBufferQuotaIncreased(bufferPool.BufferSize, bufferPool.Limit, bufferPool.Misses);
                ChangeQuota(ref bufferPool, 1);
            }

            public override void ReturnBuffer(byte[] buffer)
            {
                Fx.Assert(buffer != null, "caller must verify");

                BufferPool bufferPool = FindPool(buffer.Length);
                if (bufferPool != null)
                {
                    if (buffer.Length != bufferPool.BufferSize)
                    {
                        //TODO:throw Fx.Exception.Argument("buffer", SRCore.BufferIsNotRightSizeForBufferManager);
                        throw new ArgumentException("BufferIsNotRightSizeForBufferManager");
                    }

                    if (bufferPool.Return(buffer))
                    {
                        bufferPool.IncrementCount();
                    }
                }
            }

            public override byte[] TakeBuffer(int bufferSize)
            {
                Fx.Assert(bufferSize >= 0, "caller must ensure a non-negative argument");

                BufferPool bufferPool = FindPool(bufferSize);
                if (bufferPool != null)
                {
                    byte[] buffer = bufferPool.Take();
                    if (buffer != null)
                    {
                        bufferPool.DecrementCount();
                        return buffer;
                    }
                    if (bufferPool.Peak == bufferPool.Limit)
                    {
                        bufferPool.Misses++;
                        if (++totalMisses >= maxMissesBeforeTuning)
                        {
                            TuneQuotas();
                        }
                    }


                    return InternalBufferManager.AllocateByteArray(bufferPool.BufferSize);
                }
                else
                {
                    return InternalBufferManager.AllocateByteArray(bufferSize);
                }
            }

            void TuneQuotas()
            {
                if (this.areQuotasBeingTuned)
                {
                    return;
                }

                bool lockHeld = false;
                try
                {
                    Monitor.TryEnter(this.tuningLock, ref lockHeld);

                    // Don't bother if another thread already has the lock
                    if (!lockHeld || this.areQuotasBeingTuned)
                    {
                        return;
                    }

                    this.areQuotasBeingTuned = true;
                }
                finally
                {
                    if (lockHeld)
                    {
                        Monitor.Exit(this.tuningLock);
                    }
                }

                // find the "poorest" pool
                int starvedIndex = FindMostStarvedPool();
                if (starvedIndex >= 0)
                {
                    BufferPool starvedBufferPool = this.bufferPools[starvedIndex];

                    if (this.remainingMemory < starvedBufferPool.BufferSize)
                    {
                        // find the "richest" pool
                        int excessiveIndex = FindMostExcessivePool();
                        if (excessiveIndex >= 0)
                        {
                            // steal from the richest
                            DecreaseQuota(ref this.bufferPools[excessiveIndex]);
                        }
                    }

                    if (this.remainingMemory >= starvedBufferPool.BufferSize)
                    {
                        // give to the poorest
                        IncreaseQuota(ref this.bufferPools[starvedIndex]);
                    }
                }

                // reset statistics
                for (int i = 0; i < this.bufferPools.Length; i++)
                {
                    BufferPool bufferPool = this.bufferPools[i];
                    bufferPool.Misses = 0;
                }

                this.totalMisses = 0;
                this.areQuotasBeingTuned = false;
            }

            abstract class BufferPool
            {
                int bufferSize;
                int count;
                int limit;
                int misses;
                int peak;

                public BufferPool(int bufferSize, int limit)
                {
                    this.bufferSize = bufferSize;
                    this.limit = limit;
                }

                public int BufferSize
                {
                    get { return this.bufferSize; }
                }

                public int Limit
                {
                    get { return this.limit; }
                }

                public int Misses
                {
                    get { return this.misses; }
                    set { this.misses = value; }
                }

                public int Peak
                {
                    get { return this.peak; }
                }

                public void Clear()
                {
                    this.OnClear();
                    this.count = 0;
                }

                public void DecrementCount()
                {
                    int newValue = this.count - 1;
                    if (newValue >= 0)
                    {
                        this.count = newValue;
                    }
                }

                public void IncrementCount()
                {
                    int newValue = this.count + 1;
                    if (newValue <= this.limit)
                    {
                        this.count = newValue;
                        if (newValue > this.peak)
                        {
                            this.peak = newValue;
                        }
                    }
                }

                internal abstract byte[] Take();
                internal abstract bool Return(byte[] buffer);
                internal abstract void OnClear();

                internal static BufferPool CreatePool(int bufferSize, int limit)
                {
                    // To avoid many buffer drops during training of large objects which
                    // get allocated on the LOH, we use the LargeBufferPool and for 
                    // bufferSize < 85000, the SynchronizedPool. There is a 12 or 24(x64)
                    // byte overhead for an array so we use 85000-24=84976 as the limit
                    //if (bufferSize < 84976)
                    //{
                    //    return new SynchronizedBufferPool(bufferSize, limit);
                    //}
                    //else
                    //{
                    //    return new LargeBufferPool(bufferSize, limit);
                    //}
                    return new LargeBufferPool(bufferSize, limit);
                }

                //TODO
                //class SynchronizedBufferPool : BufferPool
                //{
                //    SynchronizedPool<byte[]> innerPool;

                //    internal SynchronizedBufferPool(int bufferSize, int limit)
                //        : base(bufferSize, limit)
                //    {
                //        this.innerPool = new SynchronizedPool<byte[]>(limit);
                //    }

                //    internal override void OnClear()
                //    {
                //        this.innerPool.Clear();
                //    }

                //    internal override byte[] Take()
                //    {
                //        return this.innerPool.Take();
                //    }

                //    internal override bool Return(byte[] buffer)
                //    {
                //        return this.innerPool.Return(buffer);
                //    }
                //}

                class LargeBufferPool : BufferPool
                {
                    Stack<byte[]> items;

                    internal LargeBufferPool(int bufferSize, int limit)
                        : base(bufferSize, limit)
                    {
                        this.items = new Stack<byte[]>(limit);
                    }

                    object ThisLock
                    {
                        get
                        {
                            return this.items;
                        }
                    }

                    internal override void OnClear()
                    {
                        lock (ThisLock)
                        {
                            this.items.Clear();
                        }
                    }

                    internal override byte[] Take()
                    {
                        lock (ThisLock)
                        {
                            if (this.items.Count > 0)
                            {
                                return this.items.Pop();
                            }
                        }

                        return null;
                    }

                    internal override bool Return(byte[] buffer)
                    {
                        lock (ThisLock)
                        {
                            if (this.items.Count < this.Limit)
                            {
                                this.items.Push(buffer);
                                return true;
                            }
                        }

                        return false;
                    }
                }
            }
        }

        class GCBufferManager : InternalBufferManager
        {
            static GCBufferManager value = new GCBufferManager();

            GCBufferManager()
            {
            }

            public static GCBufferManager Value
            {
                get { return value; }
            }

            public override void Clear()
            {
            }

            public override byte[] TakeBuffer(int bufferSize)
            {
                return InternalBufferManager.AllocateByteArray(bufferSize);
            }

            public override void ReturnBuffer(byte[] buffer)
            {
                // do nothing, GC will reclaim this buffer
            }
        }
    }
}
