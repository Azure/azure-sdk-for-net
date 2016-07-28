// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Microsoft.Azure.Batch
{
    //
    // NOTE: All lock-scope objects are not-reentrant by design.  Each lock scope
    // objects must be associated with a single thread.
    //

    abstract class LockScope : IDisposable
    {
#if DEBUG
        int _threadId;
#endif

        protected LockScope()
        {
#if DEBUG
            _threadId = Thread.CurrentThread.ManagedThreadId;
#endif
        }

#if DEBUG
        protected void VerifyThread()
        {
            if (Thread.CurrentThread.ManagedThreadId != _threadId)
            {
                throw new InvalidOperationException("The current thread does not own the lock scope object");
            }
        }
#endif

        public void Dispose()
        {
#if DEBUG
            VerifyThread();
#endif
            ExitLock();
        }

        protected abstract void ExitLock();
    }

    abstract class ReaderWriterLockScope : LockScope
    {
        protected ReaderWriterLockSlim _lock;

        protected ReaderWriterLockScope(ReaderWriterLockSlim rwLock) : base()
        {
            if (rwLock == null)
            {
                throw new ArgumentNullException("rwLock");
            }
            _lock = rwLock;
        }
    }

    internal class ReaderLockScope : ReaderWriterLockScope
    {
        public ReaderLockScope(ReaderWriterLockSlim rwLock)
            : base(rwLock)
        {
            _lock.EnterReadLock();
        }
        protected override void ExitLock()
        {            
            _lock.ExitReadLock();
        }
    }

    internal class WriterLockScope : ReaderWriterLockScope
    {
        public WriterLockScope(ReaderWriterLockSlim rwLock)
            : base(rwLock)
        {
            _lock.EnterWriteLock();
        }
        protected override void ExitLock()
        {            
            _lock.ExitWriteLock();
        }
    }

    internal class UpgradeableLockScope : ReaderWriterLockScope
    {
        public UpgradeableLockScope(ReaderWriterLockSlim rwLock)
            : base(rwLock)
        {
            _lock.EnterUpgradeableReadLock();
        }
        protected override void ExitLock()
        {            
            _lock.ExitUpgradeableReadLock();
        }
    }
}