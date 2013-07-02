// -----------------------------------------------------------------------------------------
// <copyright file="HttpMangler.cs" company="Microsoft">
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


namespace Microsoft.WindowsAzure.Test.Network
{
    using Fiddler;
    using System;
    using System.Net;
    using System.Threading;

    /// <summary>
    /// HttpMangler is a test utility for mucking with the either the request to or the response from an HTTP server.
    /// </summary>
    public class HttpMangler : IDisposable
    {
        /// <summary>
        /// We'll use a global static to run the Fiddler initialization code, and trust that
        /// the finalizer call will run at normal process exit.
        /// </summary>
        private static readonly FiddlerOneTimeInitializer initializeFiddlerAndGlobalProxySettings = new FiddlerOneTimeInitializer();

        /// <summary>
        /// Gets or sets a value indicating whether the default proxy is the mangler proxy or not.
        /// </summary>
        public static bool Active
        {
            get
            {
                return WebRequest.DefaultWebProxy == HttpMangler.initializeFiddlerAndGlobalProxySettings.NewProxy;
            }

            set
            {
                if (value)
                {
                    WebRequest.DefaultWebProxy = HttpMangler.initializeFiddlerAndGlobalProxySettings.NewProxy;
                }
                else
                {
                    WebRequest.DefaultWebProxy = HttpMangler.initializeFiddlerAndGlobalProxySettings.OldProxy;
                }
            }
        }

        /// <summary>
        /// The behaviors this instance of HttpMangler is tracking
        /// </summary>
        private readonly ProxyBehavior[] behaviors;

        private bool drainSessions;

        private int outstandingEvents = 0;

        private bool shuttingDown = false;

        /// <summary>
        /// How many sessions are there?
        /// </summary>
        private int sessionCount;

        /// <summary>
        /// Whether this object has been torn down or not.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the HttpMangler class with the given set of behaviors
        /// </summary>
        /// <param name="behaviors">The behaviors to use while this class is alive</param>
        public HttpMangler(params ProxyBehavior[] behaviors)
            : this(true, behaviors)
        {
        }

        /// <summary>
        /// Initializes a new instance of the HttpMangler class with the given set of behaviors
        /// </summary>
        /// <param name="drainEventsOnShutdown">Determines if all sessions are allowed to complete on shutdown</param>
        /// <param name="behaviors">The behaviors to use while this class is alive</param>
        public HttpMangler(bool drainEventsOnShutdown, ProxyBehavior[] behaviors)
        {
            HttpMangler.Active = true;

            this.sessionCount = 0;
            this.behaviors = behaviors;
            this.drainSessions = drainEventsOnShutdown;

            FiddlerApplication.BeforeRequest += this.FiddlerApplication_BeforeRequest;
            FiddlerApplication.BeforeResponse += this.FiddlerApplication_BeforeResponse;
            FiddlerApplication.BeforeReturningError += this.FiddlerApplication_BeforeReturningError;
            FiddlerApplication.AfterSessionComplete += this.FiddlerApplication_AfterSessionComplete;
            FiddlerApplication.ResponseHeadersAvailable += this.FiddlerApplication_ResponseHeadersAvailable;
        }

        /// <summary>
        /// Finalizes an instance of the HttpMangler class, unhooking it from all events.
        /// </summary>
        ~HttpMangler()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets how many sessions this mangler has seen.
        /// </summary>
        public int Sessions
        {
            get { return this.sessionCount; }
        }

        /// <summary>
        /// Cleans up the HttpMangler instance, blocking until all events have been seen.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Dispose cleans up all unused resources of the HttpMangler class.
        /// </summary>
        /// <param name="disposing">Whether being called by a finalizer (false) or Dispose method (true)</param>
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                shuttingDown = true;

                FiddlerApplication.BeforeRequest -= this.FiddlerApplication_BeforeRequest;
                FiddlerApplication.BeforeResponse -= this.FiddlerApplication_BeforeResponse;
                FiddlerApplication.BeforeReturningError -= this.FiddlerApplication_BeforeReturningError;
                FiddlerApplication.ResponseHeadersAvailable -= this.FiddlerApplication_ResponseHeadersAvailable;

                // Wait for all items to finish
                drainOutStandingRequests(TimeSpan.FromMinutes(1));

                FiddlerApplication.AfterSessionComplete -= this.FiddlerApplication_AfterSessionComplete;

                HttpMangler.Active = false;
                this.disposed = true;

                if (disposing)
                {
                    GC.SuppressFinalize(this);
                }
            }
        }

        private void drainOutStandingRequests(TimeSpan timeout)
        {
            DateTime expiry = DateTime.Now + timeout;

            while (this.drainSessions && outstandingEvents > 0 && DateTime.Now < expiry)
            {
                Thread.Sleep(Math.Max(0, Math.Min(100, (int)(expiry - DateTime.Now).TotalMilliseconds)));
            }
        }

        /// <summary>
        /// HandleFiddlerEvent deals with all events from Fiddler
        /// </summary>
        /// <param name="openSession">The relevant session for this event</param>
        /// <param name="triggerFlag">An enum value representing the type of event that has been raised</param>
        private void HandleFiddlerEvent(Session openSession, TriggerType triggerFlag)
        {
            for (int i = 0; i < this.behaviors.Length; ++i)
            {
                if (this.ShouldCallBehavior(this.behaviors[i], openSession, triggerFlag))
                {
                    this.behaviors[i].Execute(openSession);
                }
            }
        }

        /// <summary>
        /// ShouldCallBehavior handles all logic about whether a behavior should be invoked on a session.
        /// </summary>
        /// <param name="proxyBehavior">The relevant behavior</param>
        /// <param name="openSession">The relevant session</param>
        /// <param name="triggerFlag">The type of event</param>
        /// <returns>True if the behavior should be invoked on this session; false otherwise</returns>
        private bool ShouldCallBehavior(ProxyBehavior proxyBehavior, Session openSession, TriggerType triggerFlag)
        {
            return TriggerType.None != (proxyBehavior.TriggerFlags & triggerFlag)
                && DateTime.Now < proxyBehavior.Options.Expiry
                && 0 < proxyBehavior.Options.RemainingSessions
                && proxyBehavior.Selector(openSession);
        }

        /// <summary>
        /// FiddlerApplication_BeforeRequest is invoked before the HTTP call goes out to the remote server.
        /// </summary>
        /// <param name="openSession">The relevant session</param>
        private void FiddlerApplication_BeforeRequest(Session openSession)
        {
            // If we're shutting down, don't do any more work
            if (shuttingDown)
            {
                return;
            }

            this.sessionCount += 1;

            // On the first iteration, the wait will be signaled and we can't increment -- so, reset to 1
            Interlocked.Increment(ref outstandingEvents);

            this.HandleFiddlerEvent(openSession, TriggerType.BeforeRequest);
        }

        /// <summary>
        /// FiddlerApplication_BeforeReturningError is invoked when an error response is generated by Fiddler.
        /// </summary>
        /// <param name="openSession">The relevant session.</param>
        private void FiddlerApplication_BeforeReturningError(Session openSession)
        {
            this.HandleFiddlerEvent(openSession, TriggerType.BeforeReturningError);
        }

        /// <summary>
        /// FiddlerApplication_AfterSessionComplete is invoked when a session has been completed. 
        /// </summary>
        /// <param name="openSession">The relevant session.</param>
        private void FiddlerApplication_AfterSessionComplete(Session openSession)
        {
            this.HandleFiddlerEvent(openSession, TriggerType.AfterSessionComplete);
            Interlocked.Decrement(ref outstandingEvents);
        }

        /// <summary>
        /// FiddlerApplication_BeforeResponse is invoked when a server response is received by Fiddler.
        /// </summary>
        /// <param name="openSession">The relevant session.</param>
        private void FiddlerApplication_BeforeResponse(Session openSession)
        {
            this.HandleFiddlerEvent(openSession, TriggerType.BeforeResponse);
        }

        /// <summary>
        /// FiddlerApplication_ResponseHeadersAvailable is invoked when Response Headers are available.
        /// </summary>
        /// <param name="openSession">The relevant session.</param>
        private void FiddlerApplication_ResponseHeadersAvailable(Session openSession)
        {
            this.HandleFiddlerEvent(openSession, TriggerType.ResponseHeadersAvailable);
        }

        /// <summary>
        /// FiddlerOneTimeInitializer initializes Fiddler on port 8877 for the current process only,
        /// setting the default web proxy to go through it. This class is intended to be stored in a
        /// private static readonly variable, so that it only is invoked once in an AppDomain's lifetime.
        /// </summary>
        private class FiddlerOneTimeInitializer
        {
            private readonly IWebProxy oldProxy;
            private readonly IWebProxy newProxy;

            /// <summary>
            /// Gets the old default proxy prior to setting it in constructor.
            /// </summary>
            public IWebProxy OldProxy
            {
                get { return this.oldProxy; }
            }

            /// <summary>
            /// Gets the new default proxy after setting it in constructor.
            /// </summary>
            public IWebProxy NewProxy
            {
                get { return this.newProxy; }
            }

            /// <summary>
            /// Initializes a new instance of the FiddlerOneTimeInitializer class.
            /// </summary>
            public FiddlerOneTimeInitializer()
            {
                FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);

                // We'd like all default values, but we don't want to muck with system settings or
                // SSL connections.
                FiddlerCoreStartupFlags flags = FiddlerCoreStartupFlags.Default
                    & ~FiddlerCoreStartupFlags.RegisterAsSystemProxy
                    & ~FiddlerCoreStartupFlags.DecryptSSL;

                // For now, hardcoding 8877 for the proxy port seems appropriate.
                FiddlerApplication.Startup(8877, flags);

                this.oldProxy = WebRequest.DefaultWebProxy;
                this.newProxy = new WebProxy("http://localhost:8877", true);
            }

            /// <summary>
            /// Finalizes an instance of the FiddlerOneTimeInitializer class, causing the Fiddler proxy to shut down.
            /// </summary>
            ~FiddlerOneTimeInitializer()
            {
                FiddlerApplication.Shutdown();
            }
        }
    }
}
