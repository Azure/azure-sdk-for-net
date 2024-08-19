// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Primitive that combines async lock and value cache
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed class AsyncLockWithValue<T>
    {
        private readonly object _syncObj = new();
        private Queue<TaskCompletionSource<LockOrValue>>? _waiters;
        private bool _isLocked;
        private bool _hasValue;
        private long _index;
        private T? _value;

        public bool HasValue
        {
            get
            {
                lock (_syncObj)
                {
                    return _hasValue;
                }
            }
        }

        public AsyncLockWithValue() { }

        public AsyncLockWithValue(T value)
        {
            _hasValue = true;
            _value = value;
        }

        public bool TryGetValue(out T? value)
        {
            lock (_syncObj)
            {
                if (_hasValue)
                {
                    value = _value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Method that either returns cached value or acquire a lock.
        /// If one caller has acquired a lock, other callers will be waiting for the lock to be released.
        /// If value is set, lock is released and all waiters get that value.
        /// If value isn't set, the next waiter in the queue will get the lock.
        /// </summary>
        /// <param name="async"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async ValueTask<LockOrValue> GetLockOrValueAsync(bool async, CancellationToken cancellationToken = default)
        {
            TaskCompletionSource<LockOrValue> valueTcs;
            lock (_syncObj)
            {
                // If there is a value, just return it
                if (_hasValue)
                {
                    return new LockOrValue(_value!);
                }

                // If lock isn't acquire yet, acquire it and return to the caller
                if (!_isLocked)
                {
                    _isLocked = true;
                    _index = unchecked(_index + 1);
                    return new LockOrValue(this, _index);
                }

                // Check cancellationToken before instantiating waiter
                cancellationToken.ThrowIfCancellationRequested();

                // If lock is already taken, create a waiter and wait either until value is set or lock can be acquired by this waiter
                _waiters ??= new Queue<TaskCompletionSource<LockOrValue>>();
                // if async == false, valueTcs will be waited only in this thread and only synchronously, so RunContinuationsAsynchronously isn't needed.
                valueTcs = new TaskCompletionSource<LockOrValue>(async ? TaskCreationOptions.RunContinuationsAsynchronously : TaskCreationOptions.None);
                _waiters.Enqueue(valueTcs);
            }

            try
            {
                if (async)
                {
                    return await valueTcs.Task.AwaitWithCancellation(cancellationToken);
                }

#pragma warning disable AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
#pragma warning disable AZC0111 // DO NOT use EnsureCompleted in possibly asynchronous scope.
                valueTcs.Task.Wait(cancellationToken);
                return valueTcs.Task.EnsureCompleted();
#pragma warning restore AZC0111 // DO NOT use EnsureCompleted in possibly asynchronous scope.
#pragma warning restore AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
            }
            catch (OperationCanceledException)
            {
                // Throw OperationCanceledException only if another thread hasn't set a value to this waiter
                // by calling either Reset or SetValue
                if (valueTcs.TrySetCanceled(cancellationToken))
                {
                    throw;
                }

                return valueTcs.Task.Result;
            }
        }

        /// <summary>
        /// Set value to the cache and to all the waiters
        /// </summary>
        /// <param name="value"></param>
        /// <param name="lockIndex"></param>
        private void SetValue(T value, in long lockIndex)
        {
            Queue<TaskCompletionSource<LockOrValue>> waiters;
            lock (_syncObj)
            {
                if (lockIndex != _index)
                {
                    throw new InvalidOperationException($"Disposed {nameof(LockOrValue)} tries to set value. Current index: {_index}, {nameof(LockOrValue)} index: {lockIndex}");
                }

                _value = value;
                _hasValue = true;
                _index = 0;
                _isLocked = false;
                if (_waiters == default)
                {
                    return;
                }

                waiters = _waiters;
                _waiters = default;
            }

            while (waiters.Count > 0)
            {
                waiters.Dequeue().TrySetResult(new LockOrValue(value));
            }
        }

        /// <summary>
        /// Release the lock and allow next waiter acquire it
        /// </summary>
        private void Reset(in long lockIndex)
        {
            UnlockOrGetNextWaiter(lockIndex, out var nextWaiter);
            while (nextWaiter != default && !nextWaiter.TrySetResult(new LockOrValue(this, unchecked(lockIndex + 1))))
            {
                UnlockOrGetNextWaiter(lockIndex, out nextWaiter);
            }
        }

        private void UnlockOrGetNextWaiter(in long lockIndex, out TaskCompletionSource<LockOrValue>? nextWaiter)
        {
            lock (_syncObj)
            {
                nextWaiter = default;
                // If lock isn't acquired, just return
                if (!_isLocked || lockIndex != _index)
                {
                    return;
                }

                _index = unchecked(lockIndex + 1);

                // If lock was acquired, but there are no waiters, unlock and return
                if (_waiters == default)
                {
                    _isLocked = false;
                    return;
                }

                // Find the next waiter
                while (_waiters.Count > 0)
                {
                    nextWaiter = _waiters.Dequeue();
                    if (!nextWaiter.Task.IsCompleted)
                    {
                        // Return the waiter only if it wasn't canceled already
                        return;
                    }
                }

                // If no next waiter has been found, unlock and return
                _isLocked = false;
            }
        }

        public readonly struct LockOrValue : IDisposable
        {
            private readonly AsyncLockWithValue<T>? _owner;
            private readonly T? _value;
            private readonly long _index;

            /// <summary>
            /// Returns true if lock contains the cached value. Otherwise false.
            /// </summary>
            public bool HasValue => _owner == default;

            /// <summary>
            /// Returns cached value if it was set when lock has been created. Throws exception otherwise.
            /// </summary>
            /// <exception cref="InvalidOperationException">Value isn't set.</exception>
            public T Value => HasValue ? _value! : throw new InvalidOperationException("Value isn't set");

            public LockOrValue(T value)
            {
                _owner = default;
                _value = value;
                _index = 0;
            }

            public LockOrValue(AsyncLockWithValue<T> owner, long index)
            {
                _owner = owner;
                _index = index;
                _value = default;
            }

            /// <summary>
            /// Set value to the cache and to all the waiters.
            /// </summary>
            /// <param name="value"></param>
            /// <exception cref="InvalidOperationException">Value is set already.</exception>
            public void SetValue(T value)
            {
                if (_owner != null)
                {
                    _owner.SetValue(value, _index);
                }
                else
                {
                    throw new InvalidOperationException("Value for the lock is set already");
                }
            }

            public void Dispose() => _owner?.Reset(_index);
        }
    }
}
