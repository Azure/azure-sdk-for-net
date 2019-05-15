// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    /// <summary>
    /// TokenCredential represents a token credential (which is also a pipeline.Factory).
    /// </summary>
    public interface ITokenCredentials : IStorageCredentials
    {
        string Token { get; }

        // SetToken changes the current token value
        void SetToken(string newToken);
    }

    public sealed class TokenCredentials : ITokenCredentials, IDisposable
    {

        /// <summary>
        /// TokenCredential is a wrapper over a TokenCredentialWithRefresh.
        /// When this wrapper object gets GC'd, it stops the TokenCredentialWithRefresh's timer
        /// which allows the TokenCredentialWithRefresh object to also be GC'd.
        /// </summary>
        readonly TokenCredentialsWithRefresh tokenCredentialsWithRefresh;

        public TokenCredentials(string initalToken) : this(initalToken, null) { }

        /// <summary>
        /// NewTokenCredential creates a token credential for use with role-based access control (RBAC) access to Azure Storage
        /// resources. You initialize the TokenCredential with an initial token value. If you pass a non-nil value for
        /// tokenRefresher, then the function you pass will be called immediately (so it can refresh and change the
        /// TokenCredential's token value by calling SetToken; your tokenRefresher function must return a time.Duration
        /// indicating how long the TokenCredential object should wait before calling your tokenRefresher function again.
        /// </summary>
        /// <param name="initialToken"></param>
        /// <param name="tokenRefresher"></param>
        public TokenCredentials(string initialToken, Func<ITokenCredentials, Task<TimeSpan>> tokenRefresher)
        {
            this.tokenCredentialsWithRefresh = new TokenCredentialsWithRefresh(initialToken, tokenRefresher);
            if (tokenRefresher != null)
            {
                this.tokenCredentialsWithRefresh.StartRefresh();
            }
        }

        /// <summary>
        /// tokenCredential is a pipeline.Factory is the credential's policy factory.
        /// </summary>
        sealed class TokenCredentialsWithRefresh : ITokenCredentials, IDisposable
        {
            // Must be accessed volatile
            // TODO remove the Volatile keyword.
            Volatile<string> volatileToken; 

            // The members below are only used if the user specified a tokenRefresher callback function.
            readonly Func<ITokenCredentials, Task<TimeSpan>> tokenRefresher;
            readonly object m_lock = new object();
            readonly Timer timer;
            bool stopped = false;

            public TokenCredentialsWithRefresh(string initialToken, Func<ITokenCredentials, Task<TimeSpan>> tokenRefresher)
            {
                this.volatileToken.Value = initialToken;
                this.tokenRefresher = tokenRefresher;
                if (this.tokenRefresher != null)
                {
                    this.timer = new Timer(this.Refresh);
                }
            }

            // Token returns the current token value
            public string Token => this.volatileToken;

            // SetToken changes the current token value
            public void SetToken(string newToken) => this.volatileToken.Value = newToken;

            /// <summary>
            /// startRefresh calls refresh which immediately calls tokenRefresher
            /// and then starts a timer to call tokenRefresher in the future.
            /// </summary>
            internal void StartRefresh()
            {
                this.stopped = false; // In case user calls StartRefresh, StopRefresh, & then StartRefresh again
                this.Refresh(null);
            }

            /// <summary>
            /// refresh calls the user's tokenRefresher so they can refresh the token (by
            /// calling SetToken) and then starts another time (based on the returned duration)
            /// in order to refresh the token again in the future.
            /// </summary>
            /// <param name="_"></param>
            async void Refresh(object _)              
            {
                // Invoke the user's refresh callback outside of the lock
                TimeSpan dueTime;
                try
                {
                    dueTime = await this.tokenRefresher(this).ConfigureAwait(false);
                }
                catch
                {
                    // Swallowing exception to prevent refresh errors from killing the process.
                    return;
                }
                lock (this.m_lock)
                {
                    if (!this.stopped)
                    {
                        this.timer.Change(dueTime, Timeout.InfiniteTimeSpan);
                    }
                }
            }

            /// <summary>
            /// stopRefresh stops any pending timer and sets stopped field to true to prevent
            /// any new timer from starting.
            /// NOTE: Stopping the timer allows the GC to destroy the tokenCredential object.
            /// </summary>
            internal void StopRefresh()
            {
                lock(this.m_lock)
                {
                    this.stopped = true;
                    this.timer?.Dispose();
                }
            }
            
            public void Dispose() => this.StopRefresh();
        }

        public string Token => this.tokenCredentialsWithRefresh.Token;

        // SetToken changes the current token value
        public void SetToken(string token) => this.tokenCredentialsWithRefresh.SetToken(token);
        
        public void Dispose() => this.tokenCredentialsWithRefresh?.Dispose();
    }
}
