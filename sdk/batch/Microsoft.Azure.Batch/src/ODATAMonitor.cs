// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch
{
    using System.Threading;

    /// <summary>
    /// Contains control settings used for optimal retrieval of state data via OData predicates.
    /// </summary>
    public class ODATAMonitorControl
    {
        private TimeSpan _delayBetweenDataFetch = new TimeSpan(0, 0, seconds: 2);
        private static TimeSpan _lowerBoundDelayBetweenRefresh = new TimeSpan(0, 0, 0, 0, milliseconds : 500);

        /// <summary>
        /// The minimum time between attempts to fetch data for a monitored instance.
        /// </summary>
        public TimeSpan DelayBetweenDataFetch
        {
            get
            {
                return _delayBetweenDataFetch;
            }
            set
            {
                // forbid values that are too small... avoid DOS of server
                if (value < _lowerBoundDelayBetweenRefresh)
                {
                    value = _lowerBoundDelayBetweenRefresh;
                }

                _delayBetweenDataFetch = value;
            }
        }

        /// <summary>
        /// The maximum number of characters allowed for a single OData predicate.
        /// </summary>
        public int ODATAPredicateLimit = 500;
    }

    /// <summary>
    /// Use a lambda to construct the correct ListFoo calls with correct params.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    internal delegate IPagedEnumerable<T> ListDelegate<T>();

    /// <summary>
    /// A class that leverages OData predicates to poll the states of instances.
    /// </summary>
    internal class ODATAMonitor
    {
        /// <summary>
        /// Polls the collection of instances until each has passed the condition at least once.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionToMonitor"></param>
        /// <param name="condition"></param>
        /// <param name="getName"></param>
        /// <param name="listObjects"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="detailLevel">Controls the detail level of the data returned by a call to the Azure Batch Service.</param>
        /// <param name="control"></param>
        /// <returns></returns>
        public static async Task WhenAllAsync<T>(
            IEnumerable<T> collectionToMonitor,
            Func<T, bool> condition,
            Func<T, string> getName,
            ListDelegate<T> listObjects,
            CancellationToken cancellationToken,
            ODATADetailLevel detailLevel,
            ODATAMonitorControl control) where T : IRefreshable
        {
            if (null == collectionToMonitor)
            {
                throw new ArgumentNullException("collectionToMonitor");
            }

            if (null == condition)
            {
                throw new ArgumentNullException("condition");
            }

            RefreshViaODATAFilterList<T> odataRefresher = new RefreshViaODATAFilterList<T>(cancellationToken, detailLevel, condition, listObjects, control);

            // populate for first pass
            foreach (T curT in collectionToMonitor)
            {
                // filter out the instances that already meet the condition
                if (!condition(curT))
                {
                    MonitorLastCall<T> box = new MonitorLastCall<T>(curT, /* flags each instance as available to refresh "now" */ DateTime.MinValue);

                    odataRefresher.CurrentPassQueue.Enqueue(box);
                }
            }

            // process the instances in the current pass... swap queues to begin next pass
            while (!odataRefresher.CancellationToken.IsCancellationRequested &&
                odataRefresher.CurrentPassQueue.Count > 0)
            {
                // get next instance
                MonitorLastCall<T> nextInstanceToProcess = odataRefresher.CurrentPassQueue.Dequeue();

                // build an odata filter with as many names as the limit will allow and call refresh instances as needed
                Task asyncProcessOneInstance = odataRefresher.ProcessOneInstance(nextInstanceToProcess, getName);

                // a-wait for completion
                await asyncProcessOneInstance.ConfigureAwait(continueOnCapturedContext: false);

                // if the current pass queue is empty, swap the queues to begin next pass
                if (0 == odataRefresher.CurrentPassQueue.Count)
                {
                    odataRefresher.SwapQueues();

                    // if we appear to be done, the stringbuilder might have the last predicate in it so flush that
                    if (0 == odataRefresher.CurrentPassQueue.Count)
                    {
                        // start the call to process the last predicate
                        Task asyncListTask = odataRefresher.CallListAndProcessResults();

                        // a-wait for completion
                        await asyncListTask.ConfigureAwait(continueOnCapturedContext: false);

                        // if the last predicate created new work... the swap will bring it into a new pass
                        odataRefresher.SwapQueues();
                    }
                }
            }

            //Were we cancelled?
            odataRefresher.CancellationToken.ThrowIfCancellationRequested();
        }

        /// <summary>
        /// Will accept instances of T and construct a filter predicate.
        /// The predicate will be used (and reset) when it is full or if
        /// the given instance was to recently refreshed (DOS avoidance).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        internal class RefreshViaODATAFilterList<T>
        {
#region constructors

            private RefreshViaODATAFilterList()
            {
            }

            internal RefreshViaODATAFilterList(
                            CancellationToken cancellationToken,
                            ODATADetailLevel odataDetail,
                            Func<T, bool> condition,
                            ListDelegate<T> listObjects,
                            ODATAMonitorControl odataMonitorControl)
            {
                this.CancellationToken = cancellationToken;
                _odataDetailLevel = odataDetail;
                _condition = condition;
                _listObjects = listObjects;
                _odataMonitorControl = odataMonitorControl;

                CurrentPassQueue = new Queue<MonitorLastCall<T>>();
                NextPassQueue = new Queue<MonitorLastCall<T>>();
            }

#endregion constructors

            // queue that holds the instances being refreshed on this pass
            public Queue<MonitorLastCall<T>> CurrentPassQueue = new Queue<MonitorLastCall<T>>();

            // queue that holds the instances that have been refreshed and failed the condition...
            // to be refreshed again on the next pass
            public Queue<MonitorLastCall<T>> NextPassQueue = new Queue<MonitorLastCall<T>>();

            public CancellationToken CancellationToken { get; private set; }

            /// <summary>
            /// Holds the delegate that determines of the given instance no longer needs to be polled.
            /// </summary>
            private readonly Func<T, bool> _condition;

            /// <summary>
            /// Delegate to fetch new instances fresh state data.
            /// </summary>
            private readonly ListDelegate<T> _listObjects;

            /// <summary>
            /// To be updated with filter predicate for refreshing instance state data.
            /// </summary>
            private readonly ODATADetailLevel _odataDetailLevel;

            /// <summary>
            /// Holds control data for this odata monitor.
            /// </summary>
            private readonly ODATAMonitorControl _odataMonitorControl;

            // ODATA predicated will be constructed in this
            private readonly StringBuilder _odataFilterSB = new StringBuilder();

            private const string IdPrefix = "id eq '";
            private const char IdPostfix = '\'';
            private const string OrOperator = " or ";

            internal async Task ProcessOneInstance(MonitorLastCall<T> nextInstance, Func<T, string> getName)
            {
                // we will loop until this is null
                MonitorLastCall<T> processThisInstance = nextInstance;

                while (null != processThisInstance)
                {
                    bool usePredicateToCallList = false;
                    DateTime utcNow = DateTime.UtcNow;

                    // if it is not too early, we can use this instance
                    if (utcNow >= nextInstance.DoNotRefreshUntilUTC)
                    {
                        // now check to see if it will fit
                        // remember the limit on the name is 64 and the limit on the predicate is 500
                        // the assumption is that even if these #s evolve at least one max-sized-name will fit.

                        StringBuilder possibleAdditionalExpression = new StringBuilder();

                        // if this is not the first name then we must "or" this name in
                        if (0 != _odataFilterSB.Length)
                        {
                            possibleAdditionalExpression.Append(OrOperator);
                        }

                        // add in the name prefix
                        possibleAdditionalExpression.Append(IdPrefix);

                        // get the name of the object
                        string name = getName(nextInstance.Instance);

                        // add in the name
                        possibleAdditionalExpression.Append(name);

                        // add the name postfix
                        possibleAdditionalExpression.Append(IdPostfix);

                        // if it will fit then append the clause to the predicate
                        if ((_odataFilterSB.Length + possibleAdditionalExpression.Length) < _odataMonitorControl.ODATAPredicateLimit)
                        {
                            // amend the predicate to refresh the object
                            _odataFilterSB.Append(possibleAdditionalExpression.ToString());

                            processThisInstance = null;  // we are done
                        }
                        else
                        {
                            // it will not fit so we are done with this predicate
                            usePredicateToCallList = true;
                        }
                    }
                    else // if the next instance cannot be refreshed yet we may need to wait a bit
                    {
                        // if we have work to do... return to process that work and use up time
                        if (_odataFilterSB.Length > 0)
                        {
                            usePredicateToCallList = true;
                        }
                        else  // if we have no work to do we should delay until the instance can be refreshed
                        {
                            TimeSpan delayThisMuch = processThisInstance.DoNotRefreshUntilUTC - utcNow;

                            if (delayThisMuch.Ticks > 0)
                            {
                                await System.Threading.Tasks.Task.Delay(delayThisMuch).ConfigureAwait(continueOnCapturedContext: false);
                            }
                        }
                    }

                    // should we call the server with the current predicate data?
                    if (usePredicateToCallList)
                    {
                        usePredicateToCallList = false;

                        // start the new list operation
                        Task asyncListTask = CallListAndProcessResults();

                        // wait for completion
                        await asyncListTask.ConfigureAwait(continueOnCapturedContext: false);
                    }
                }
            }

            /// <summary>
            /// Will swap the queues.  This is the transition from one pass to the next.
            /// </summary>
            internal void SwapQueues()
            {
                Queue<MonitorLastCall<T>> tmp = this.CurrentPassQueue;

                this.CurrentPassQueue = this.NextPassQueue;
                this.NextPassQueue = tmp;
            }

            /// <summary>
            /// Uses list func to fetch fresh data on the instances in the predicate.
            /// Instances that fail the condition are enqueued for the next pass.
            /// </summary>
            /// <returns></returns>
            internal async Task CallListAndProcessResults()
            {
                // extract the predicate that restricts the list call
                string predicate = _odataFilterSB.ToString();

                // clear the sb for the next batch
                _odataFilterSB.Clear();

                // early exit if there is no work to do
                if (string.IsNullOrWhiteSpace(predicate))
                {
                    return;
                }

                // update the detail level
                _odataDetailLevel.FilterClause = predicate;

                // get the enumerable to refresh the instances
                IPagedEnumerable<T> tEnumberable = _listObjects();

                // get the enumerator for asycn walk of the collection
                IPagedEnumerator<T> tEnumerator = tEnumberable.GetPagedEnumerator();

                // used to enumerate until out of data
                bool thereIsMoreData;

                do
                {
                    // move to next instance, possibley make call to server to get next batch
                    Task<bool> asyncTask = tEnumerator.MoveNextAsync(this.CancellationToken);

                    thereIsMoreData = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

                    if (thereIsMoreData)
                    {
                        // get the current instance
                        T refreshedInstance = tEnumerator.Current;

                        // test it to see if it is done
                        if (!_condition(refreshedInstance))
                        {
                            // we will have to refresh it again so put in queue for next pass

                            // box it up
                            MonitorLastCall<T> mlc = new MonitorLastCall<T>(refreshedInstance, DateTime.UtcNow + _odataMonitorControl.DelayBetweenDataFetch);

                            // enqueue it for next pass
                            this.NextPassQueue.Enqueue(mlc);
                        }
                    }
                }
                while (thereIsMoreData);
            }
        }
    }

    /// <summary>
    /// A class to track the last time an instance was refreshed/monitored.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class MonitorLastCall<T>
    {
        private MonitorLastCall()
        {
        }

        internal MonitorLastCall(T instance, DateTime timestamp)
        {
            this.DoNotRefreshUntilUTC = timestamp;
            this.Instance = instance;
        }

        public DateTime DoNotRefreshUntilUTC { get; internal set; }

        public T Instance { get; internal set; }
    }
}
