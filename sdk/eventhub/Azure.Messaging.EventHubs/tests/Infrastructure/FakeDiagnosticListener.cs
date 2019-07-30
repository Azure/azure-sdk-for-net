// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Encapsulates the necessary structure to locate the Azure.Messaging.EventHubs <see cref="DiagnosticListener" />
    ///   and listen to its events.
    /// </summary>
    ///
    /// <remarks>
    ///   An instance of this class must subscribe to the <see cref="DiagnosticListener.AllListeners" /> observable.
    ///   It will be possible to locate the Azure.Messaging.EventHubs <see cref="DiagnosticListener" /> this way.
    ///   An inner class will subscribe to it and deal with its events.
    /// </remarks>
    ///
    internal sealed class FakeDiagnosticListener : IObserver<DiagnosticListener>, IDisposable
    {
        /// <summary>A subscription to the Azure.Messaging.EventHubs <see cref="DiagnosticListener" /> used by the inner <see cref="FakeDiagnosticSourceWriteObserver" /> class.</summary>
        private IDisposable subscription;

        /// <summary>The callback to be called on every event fired by the Azure.Messaging.EventHubs <see cref="DiagnosticListener" />.</summary>
        private readonly Action<KeyValuePair<string, object>> writeCallback;

        /// <summary>Determines whether this <see cref="FakeDiagnosticListener" /> instance is enabled given the name of the fired event.</summary>
        private Func<string, bool> writeObserverEnabled = name => false;

        /// <summary>
        ///   Initializes a new instance of the <see cref="FakeDiagnosticListener" /> class.
        /// </summary>
        ///
        /// <param name="writeCallback">The callback to be called on every event fired by the Azure.Messaging.EventHubs <see cref="DiagnosticListener" />.</param>
        ///
        /// <remarks>
        ///   The <paramref name="writeCallback" /> action only takes a <see cref="KeyValuePair" /> as a parameter.
        ///   This parameter contains the event name and its payload object.
        /// </remarks>
        ///
        public FakeDiagnosticListener(Action<KeyValuePair<string, object>> writeCallback)
        {
            this.writeCallback = writeCallback;
        }

        /// <summary>
        ///   This method is necessary for the <see cref="IObserver{T}" /> interface,
        ///   but it won't be used.
        /// </summary>
        ///
        public void OnCompleted() { }

        /// <summary>
        ///   This method is necessary for the <see cref="IObserver{T}" /> interface,
        ///   but it won't be used.
        /// </summary>
        ///
        public void OnError(Exception error) { }

        /// <summary>
        ///   The method to be called whenever a <see cref="DiagnosticListener" /> this
        ///   <see cref="IObserver{T}" /> has subscribed to fires an event.
        /// </summary>
        ///
        /// <param name="value">A reference to an active <see cref="DiagnosticListener" />.</param>
        ///
        /// <remarks>
        ///   A reference to every active <see cref="DiagnosticListener" /> will be passed to this method once.
        ///   These references will be used to find the Azure.Messaging.EventHubs <see cref="DiagnosticListener" />.
        /// </remarks>
        ///
        public void OnNext(DiagnosticListener value)
        {
            if (value.Name.Equals("Azure.Messaging.EventHubs"))
            {
                this.subscription?.Dispose();
                this.subscription = value.Subscribe(new FakeDiagnosticSourceWriteObserver(this.writeCallback), this.IsEnabled);
            }
        }

        /// <summary>
        ///   Enables this <see cref="FakeDiagnosticListener" /> instance for every upcoming event that passes a specified callback filter.
        /// </summary>
        ///
        /// <param name="writeObserverEnabled">The callback filter to be applied to every upcoming event.</param>
        ///
        /// <remarks>
        ///   The <paramref name="writeObserverEnabled" /> callback function only takes an event name as a parameter.
        ///   It should return <c>true</c> if this <see cref="FakeDiagnosticListener" /> instance is enabled for the
        ///   specified event name; otherwise, it should return <c>false</c>.
        /// </remarks>
        ///
        public void Enable(Func<string, bool> writeObserverEnabled)
        {
            this.writeObserverEnabled = writeObserverEnabled;
        }

        /// <summary>
        ///   Disables this <see cref="FakeDiagnosticListener" /> instance for every upcoming event.
        /// </summary>
        ///
        public void Disable()
        {
            this.writeObserverEnabled = name => false;
        }

        /// <summary>
        ///   Determines whether this <see cref="FakeDiagnosticListener" /> instance is enabled given the name of the fired event.
        /// </summary>
        ///
        /// <param name="name">The name of the event.</param>
        ///
        /// <returns><c>true</c> if this <see cref="FakeDiagnosticListener" /> instance is enabled for the specified event name; otherwise, <c>false</c>.</returns>
        ///
        public bool IsEnabled(string name)
        {
            return this.writeObserverEnabled.Invoke(name);
        }

        /// <summary>
        ///   Disables this <see cref="FakeDiagnosticListener" /> instance and cancels
        ///   its current subscription, if existing.
        /// </summary>
        ///
        public void Dispose()
        {
            this.Disable();
            this.subscription?.Dispose();
        }

        /// <summary>
        ///   Subscribes to a <see cref="DiagnosticListener" /> and listens to the
        ///   events fired by it.
        /// </summary>
        ///
        private class FakeDiagnosticSourceWriteObserver : IObserver<KeyValuePair<string, object>>
        {
            /// <summary>The callback to be called on every fired event.</summary>
            private readonly Action<KeyValuePair<string, object>> writeCallback;

            /// <summary>
            ///   Initializes a new instance of the <see cref="FakeDiagnosticSourceWriteObserver" /> class.
            /// </summary>
            ///
            /// <param name="writeCallback">The callback to be called on every fired event.</param>
            ///
            /// <remarks>
            ///   The <paramref name="writeCallback" /> action only takes a <see cref="KeyValuePair" /> as a parameter.
            ///   This parameter contains the event name and its payload object.
            /// </remarks>
            ///
            public FakeDiagnosticSourceWriteObserver(Action<KeyValuePair<string, object>> writeCallback)
            {
                this.writeCallback = writeCallback;
            }

            /// <summary>
            ///   This method is necessary for the <see cref="IObserver{T}" /> interface,
            ///   but it won't be used.
            /// </summary>
            ///
            public void OnCompleted() { }

            /// <summary>
            ///   This method is necessary for the <see cref="IObserver{T}" /> interface,
            ///   but it won't be used.
            /// </summary>
            ///
            public void OnError(Exception error) { }

            /// <summary>
            ///   The method to be called whenever a <see cref="DiagnosticListener" /> this
            ///   <see cref="IObserver{T}" /> has subscribed to fires an event.
            /// </summary>
            ///
            /// <param name="value">A <see cref="KeyValuePair" /> containing the event name and its payload object.</param>
            ///
            public void OnNext(KeyValuePair<string, object> value)
            {
                this.writeCallback(value);
            }
        }
    }
}
