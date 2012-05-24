// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
	/// <summary>
	/// Wrapper on Monitor that looks for out of order locks
	/// Also can track what thread holds a lock
	/// </summary>
	public static class CriticalSection
	{
#if DEBUG
		class DependentLockInfo
		{
			public LockInfo LockInfo { get; private set; }
			public List<StackTrace> CallStacks { get; private set; }
			public DependentLockInfo(LockInfo lockInfo)
			{
				LockInfo = lockInfo;
				CallStacks = new List<StackTrace>();
			}
		}
		/// <summary>
		/// Information on a single lock
		/// </summary>
		class LockInfo
		{
			/// <summary>
			/// Lock object
			/// </summary>
			private readonly WeakReference _lock;
			/// <summary>
			/// Current owning thread, -1 if no owner
			/// </summary>
			private int _owningThread=-1;
			/// <summary>
			/// List of depentent locks.
			/// </summary>
			private readonly List<DependentLockInfo> _dependentLocks = new List<DependentLockInfo>();
			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="obj"></param>
			public LockInfo(object obj)
			{
				_lock = new WeakReference(obj);
			}
			/// <summary>
			/// Add a lock as a depenedtent of this lock
			/// </summary>
			/// <param name="lockInfo"></param>
			public void AddDependent(LockInfo lockInfo)
			{
#if !CAPTURE_STACK_TRACES
				if(IsDependent(lockInfo))
					return;
#endif
				DependentLockInfo foundInfo = null;
				foreach (DependentLockInfo dependLockInfo in _dependentLocks)
				{
					if (dependLockInfo.LockInfo == lockInfo)
					{
						foundInfo = dependLockInfo;
						break;
					}
				}
				if (foundInfo == null)
				{
					foundInfo = new DependentLockInfo(lockInfo);
					_dependentLocks.Add(foundInfo);
				}

#if CAPTURE_STACK_TRACES
				StackTrace callStack = new StackTrace(true);
				foreach (StackTrace currentTraces in foundInfo.CallStacks)
				{
					if (IsSameCallStack(callStack, currentTraces))
						return;
				}
				foundInfo.CallStacks.Add(callStack);
#endif
			}
#if CAPTURE_STACK_TRACES
			static private bool IsSameCallStack(StackTrace lhs, StackTrace rhs)
			{
				if (lhs.FrameCount != rhs.FrameCount)
					return false;

				for (int i = 0; i < lhs.FrameCount; i++)
				{
					StackFrame lhsFrame = lhs.GetFrame(i);
					StackFrame rhsFrame = rhs.GetFrame(i);

					if(lhsFrame.GetMethod() != rhsFrame.GetMethod())
						return false;
					if (lhsFrame.GetILOffset() != rhsFrame.GetILOffset())
						return false;
				}
				return true;
			}
#endif
			/// <summary>
			/// Is a lock a depenedent of this lock
			/// </summary>
			/// <param name="lockInfo"></param>
			/// <returns></returns>
			public bool IsDependent(LockInfo lockInfo)
			{
				if (this == lockInfo)
					return true;
				foreach (DependentLockInfo child in _dependentLocks)
				{
					if (child.LockInfo.IsDependent(lockInfo))
						return true;
				}
				return false;
			}
			/// <summary>
			/// Get/Set current owning thread
			/// </summary>
			public int OwningThread
			{
				get
				{
					return _owningThread;
				}
				set
				{
					_owningThread = value;
				}
			}
			/// <summary>
			/// Get the lock object
			/// </summary>
			public object Lock
			{
				get
				{
					return _lock.Target;
				}
			}
			/// <summary>
			/// Is the lock object currently alive
			/// </summary>
			public bool IsAlive
			{
				get
				{
					return _lock.IsAlive;
				}
			}
			/// <summary>
			/// Kill a depend object, ihearting its dependents
			/// </summary>
			/// <param name="lockInfo"></param>
			public void KillDependent(LockInfo lockInfo)
			{
				int nIndex = -1;
				for (int i = 0; i < _dependentLocks.Count; i++)
				{
					if (_dependentLocks[i].LockInfo == lockInfo)
					{
						nIndex = i;
						break;
					}
				}
				if (nIndex == -1)
					return;
				_dependentLocks.RemoveAt(nIndex);
				_dependentLocks.AddRange(lockInfo._dependentLocks);
			}
		}

		/// <summary>
		/// Locks currently held by thread
		/// </summary>
		[ThreadStatic]
		static Stack<LockInfo> heldLocks;
		/// <summary>
		/// List of all locks seen
		/// </summary>
		static readonly List<LockInfo> RgLocks = new List<LockInfo>();
#endif
		/// <summary>
		/// release the lock on dispose
		/// </summary>
		class ExitOnDispose : IDisposable
		{
#if DEBUG
			/// <summary>
			/// Lock object working with
			/// </summary>
			private readonly LockInfo _lockInfo;
			/// <summary>
			/// Is this a recursive lock.  If so don't reset owning thread
			/// </summary>
			private readonly bool _recLock;
#endif
			/// <summary>
			/// Lock object
			/// </summary>
			private readonly object _object;
			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="obj"></param>
			/// <param name="lockInfo"></param>
			/// <param name="fRecLock"></param>
			public ExitOnDispose(object obj
#if DEBUG
				, LockInfo lockInfo, bool fRecLock
#endif
				)
			{
				_object = obj;
#if DEBUG
				_lockInfo = lockInfo;
				_recLock = fRecLock;
#endif
			}
			/// <summary>
			/// Dispose, unlock the lock, reset state
			/// </summary>
			public void Dispose()
			{
#if DEBUG
				if(!_recLock)
					_lockInfo.OwningThread = -1;
				Debug.Assert(heldLocks.Peek() == _lockInfo);
				heldLocks.Pop();
#endif
				Monitor.Exit(_object);
				GC.SuppressFinalize(this);
			}
#if DEBUG
			/// <summary>
			/// Destructor, should never be called. show use using statement
			/// </summary>
			~ExitOnDispose()
			{
				Debug.Assert(false, "Use using keyword");
			}
#endif
		}
		/// <summary>
		/// Enter a critical section
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		static public IDisposable Enter(object obj)
		{
			bool fLockTaken = false;
			try
			{
				Monitor.Enter(obj, ref fLockTaken);
				Debug.Assert(fLockTaken);	// if we got this far shoud always be true
#if DEBUG
				lock (RgLocks)
				{
					if (heldLocks == null)
						heldLocks = new Stack<LockInfo>();

					LockInfo lockInfo = FindLock(obj);
					LockInfo potentionDeadlock = null;
					foreach (LockInfo currentLock in heldLocks)
					{
						if (currentLock == lockInfo)	//recursive lock ok
						{
							potentionDeadlock = null;
							continue;
						}
						if (currentLock.IsDependent(lockInfo))
						{
							potentionDeadlock = currentLock;
						}
					}
					Debug.Assert(potentionDeadlock==null, "Potention Deadlock");
					bool fRec = lockInfo.OwningThread != -1;
					Debug.Assert(lockInfo.OwningThread == -1 || lockInfo.OwningThread == Thread.CurrentThread.ManagedThreadId);
					lockInfo.OwningThread = Thread.CurrentThread.ManagedThreadId;
					if (heldLocks.Count != 0 && potentionDeadlock==null && !fRec)
						lockInfo.AddDependent(heldLocks.Peek());
					heldLocks.Push(lockInfo);
					return new ExitOnDispose(obj, lockInfo, fRec);
				}
#else
				return new ExitOnDispose(obj);
#endif
			}
			catch
			{
				//if for some resons we messed up, release lock
				if(fLockTaken)
					Monitor.Exit(obj);
				throw;
			}
		}
#if DEBUG
		/// <summary>
		/// Find a lock
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		static private LockInfo FindLock(object obj)
		{
			for (int i = RgLocks.Count - 1; i >= 0; i--)
			{
				if (!RgLocks[i].IsAlive)
				{
					LockInfo infoRemove = RgLocks[i];
					RgLocks.RemoveAt(i);
					foreach (LockInfo info in RgLocks)
						info.KillDependent(infoRemove);
				}
				else
				{
					if (object.ReferenceEquals(RgLocks[i].Lock, obj))
						return RgLocks[i];
				}
			}
			LockInfo lockInfo = new LockInfo(obj);
			RgLocks.Add(lockInfo);
			return lockInfo;
		}
		/// <summary>
		/// See if current thread holds the lock
		/// </summary>
		/// <param name="obj"></param>
		static public void CheckCurrentThreadHoldsLock(object obj)
		{
			bool fLockTaken = false;
			try
			{
				Monitor.TryEnter(obj, ref fLockTaken);
				if (!fLockTaken)	//if we held lock, then we could always get it
				{
					Debug.Assert(false, "Current thread doesn't hold lock");
				}
				lock (RgLocks)
				{
					LockInfo info = FindLock(obj);
					Debug.Assert(info.OwningThread == Thread.CurrentThread.ManagedThreadId, "Current thread doesn't hold lock");
				}
			}
			finally
			{
				if(fLockTaken)
					Monitor.Exit(obj);
			}
		}
#endif
	}
}
