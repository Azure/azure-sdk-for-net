// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Rest.TransientFaultHandling
{
    /// <summary>
    /// Provides the base implementation of the retry mechanism for unreliable actions and 
    /// transient conditions.
    /// </summary>
    public class RetryPolicy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy"/> class with the specified number of retry 
        /// attempts and parameters defining the progressive delay between retries.
        /// </summary>
        /// <param name="errorDetectionStrategy">The <see cref="ITransientErrorDetectionStrategy"/> that is 
        /// responsible for detecting transient conditions.</param>
        /// <param name="retryStrategy">The strategy to use for this retry policy.</param>
        public RetryPolicy(ITransientErrorDetectionStrategy errorDetectionStrategy, RetryStrategy retryStrategy)
        {
            Guard.ArgumentNotNull(errorDetectionStrategy, "errorDetectionStrategy");
            Guard.ArgumentNotNull(retryStrategy, "retryPolicy");

            this.ErrorDetectionStrategy = errorDetectionStrategy;

            if (errorDetectionStrategy == null)
            {
                throw new InvalidOperationException(ClientRuntime.Properties.Resources.ITransientErrorDetectionStrategyNotImplemented);
            }

            this.RetryStrategy = retryStrategy;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy"/> class with the specified number of retry 
        /// attempts and default fixed time interval between retries.
        /// </summary>
        /// <param name="errorDetectionStrategy">The <see cref="ITransientErrorDetectionStrategy"/> that is responsible 
        /// for detecting transient conditions.</param>
        /// <param name="retryCount">The number of retry attempts.</param>
        public RetryPolicy(ITransientErrorDetectionStrategy errorDetectionStrategy, int retryCount)
            : this(errorDetectionStrategy, new FixedIntervalRetryStrategy(retryCount))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy"/> class with the specified number of retry 
        /// attempts and fixed time interval between retries.
        /// </summary>
        /// <param name="errorDetectionStrategy">The <see cref="ITransientErrorDetectionStrategy"/> that is responsible 
        /// for detecting transient conditions.</param>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="retryInterval">The interval between retries.</param>
        public RetryPolicy(ITransientErrorDetectionStrategy errorDetectionStrategy, int retryCount, TimeSpan retryInterval)
            : this(errorDetectionStrategy, new FixedIntervalRetryStrategy(retryCount, retryInterval))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy"/> class with the specified number of retry attempts 
        /// and backoff parameters for calculating the exponential delay between retries.
        /// </summary>
        /// <param name="errorDetectionStrategy">The <see cref="ITransientErrorDetectionStrategy"/> that is responsible 
        /// for detecting transient conditions.</param>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="minBackoff">The minimum backoff time.</param>
        /// <param name="maxBackoff">The maximum backoff time.</param>
        /// <param name="deltaBackoff">The time value that will be used to calculate a random delta in the exponential delay 
        /// between retries.</param>
        public RetryPolicy(ITransientErrorDetectionStrategy errorDetectionStrategy, int retryCount, TimeSpan minBackoff, 
            TimeSpan maxBackoff, TimeSpan deltaBackoff)
            : this(errorDetectionStrategy, new ExponentialBackoffRetryStrategy(retryCount, minBackoff, maxBackoff, deltaBackoff))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy"/> class with the specified number of retry 
        /// attempts and parameters defining the progressive delay between retries.
        /// </summary>
        /// <param name="errorDetectionStrategy">The <see cref="ITransientErrorDetectionStrategy"/> that is responsible for 
        /// detecting transient conditions.</param>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="initialInterval">The initial interval that will apply for the first retry.</param>
        /// <param name="increment">The incremental time value that will be used to calculate the progressive delay between 
        /// retries.</param>
        public RetryPolicy(ITransientErrorDetectionStrategy errorDetectionStrategy, int retryCount, TimeSpan initialInterval, 
            TimeSpan increment)
            : this(errorDetectionStrategy, new IncrementalRetryStrategy(retryCount, initialInterval, increment))
        {
        }

        /// <summary>
        /// An instance of a callback delegate that will be invoked whenever a retry condition is encountered.
        /// </summary>
        public event EventHandler<RetryingEventArgs> Retrying;

        /// <summary>
        /// Gets the retry strategy.
        /// </summary>
        public RetryStrategy RetryStrategy { get; private set; }

        /// <summary>
        /// Gets the instance of the error detection strategy.
        /// </summary>
        public ITransientErrorDetectionStrategy ErrorDetectionStrategy { get; private set; }

        /// <summary>
        /// Repetitively executes the specified action while it satisfies the current retry policy.
        /// </summary>
        /// <param name="action">A delegate that represents the executable action that doesn't return any results.</param>
        public virtual void ExecuteAction(Action action)
        {
            Guard.ArgumentNotNull(action, "action");

            this.ExecuteAction(() => { action(); return default(object); });
        }

        /// <summary>
        /// Repetitively executes the specified action while it satisfies the current retry policy.
        /// </summary>
        /// <typeparam name="TResult">The type of result expected from the executable action.</typeparam>
        /// <param name="func">A delegate that represents the executable action that returns the result of 
        /// type <typeparamref name="TResult"/>.</param>
        /// <returns>The result from the action.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", 
            "CA1062:Validate arguments of public methods", 
            MessageId = "0", Justification = "Validated with Guard")]
        public virtual TResult ExecuteAction<TResult>(Func<TResult> func)
        {
            Guard.ArgumentNotNull(func, "func");

            int retryCount = 0;
            TimeSpan delay = TimeSpan.Zero;
            Exception lastError;

            var shouldRetry = this.RetryStrategy.GetShouldRetryHandler();

            for (;;)
            {
                lastError = null;

                try
                {
                    return func();
                }
                catch (Exception ex)
                {
                    lastError = ex;

                    if (!(this.ErrorDetectionStrategy.IsTransient(lastError)))
                    {
                        throw;
                    }

                    RetryCondition condition = shouldRetry(retryCount++, lastError);
                    if (!condition.RetryAllowed){
                        throw;
                    }
                    delay = condition.DelayBeforeRetry;
                }

                // Perform an extra check in the delay interval. Should prevent from accidentally ending up with the 
                // value of -1 that will block a thread indefinitely. In addition, any other negative numbers will 
                // cause an ArgumentOutOfRangeException fault that will be thrown by Thread.Sleep.
                if (delay.TotalMilliseconds < 0)
                {
                    delay = TimeSpan.Zero;
                }

                this.OnRetrying(retryCount, lastError, delay);

                if (retryCount > 1 || !this.RetryStrategy.FastFirstRetry)
                {
                    Task.Delay(delay).Wait();
                }
            }
        }

        /// <summary>
        /// Repetitively executes the specified asynchronous task while it satisfies the current retry policy.
        /// </summary>
        /// <param name="taskAction">A function that returns a started task (also known as "hot" task).</param>
        /// <returns>
        /// A task that will run to completion if the original task completes successfully (either the
        /// first time or after retrying transient failures). If the task fails with a non-transient error or
        /// the retry limit is reached, the returned task will transition to a faulted state and the exception must be observed.
        /// </returns>
        public Task ExecuteAsync(Func<Task> taskAction)
        {
            return this.ExecuteAsync(taskAction, default(CancellationToken));
        }

        /// <summary>
        /// Repetitively executes the specified asynchronous task while it satisfies the current retry policy.
        /// </summary>
        /// <param name="taskAction">A function that returns a started task (also known as "hot" task).</param>
        /// <param name="cancellationToken">The token used to cancel the retry operation. This token does not cancel 
        /// the execution of the asynchronous task.</param>
        /// <returns>
        /// Returns a task that will run to completion if the original task completes successfully (either the
        /// first time or after retrying transient failures). If the task fails with a non-transient error or
        /// the retry limit is reached, the returned task will transition to a faulted state and the exception must be observed.
        /// </returns>
        public Task ExecuteAsync(Func<Task> taskAction, CancellationToken cancellationToken)
        {
            if (taskAction == null) throw new ArgumentNullException("taskAction");

            return new AsyncExecution(
                    taskAction,
                    this.RetryStrategy.GetShouldRetryHandler(),
                    this.ErrorDetectionStrategy.IsTransient,
                    this.OnRetrying,
                    this.RetryStrategy.FastFirstRetry,
                    cancellationToken)
                .ExecuteAsync();
        }

        /// <summary>
        /// Repeatedly executes the specified asynchronous task while it satisfies the current retry policy.
        /// </summary>
        /// <param name="taskFunc">A function that returns a started task (also known as "hot" task).</param>
        /// <returns>
        /// Returns a task that will run to completion if the original task completes successfully (either the
        /// first time or after retrying transient failures). If the task fails with a non-transient error or
        /// the retry limit is reached, the returned task will transition to a faulted state and the exception 
        /// must be observed.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> taskFunc)
        {
            return this.ExecuteAsync<TResult>(taskFunc, default(CancellationToken));
        }

        /// <summary>
        /// Repeatedly executes the specified asynchronous task while it satisfies the current retry policy.
        /// </summary>
        /// <param name="taskFunc">A function that returns a started task (also known as "hot" task).</param>
        /// <param name="cancellationToken">The token used to cancel the retry operation. This token does not 
        /// cancel the execution of the asynchronous task.</param>
        /// <returns>
        /// Returns a task that will run to completion if the original task completes successfully (either the
        /// first time or after retrying transient failures). If the task fails with a non-transient error or
        /// the retry limit is reached, the returned task will transition to a faulted state and the exception must 
        /// be observed.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> taskFunc, CancellationToken cancellationToken)
        {
            if (taskFunc == null) throw new ArgumentNullException("taskFunc");

            return new AsyncExecution<TResult>(
                    taskFunc,
                    this.RetryStrategy.GetShouldRetryHandler(),
                    this.ErrorDetectionStrategy.IsTransient,
                    this.OnRetrying,
                    this.RetryStrategy.FastFirstRetry,
                    cancellationToken)
                .ExecuteAsync();
        }

        /// <summary>
        /// Notifies the subscribers whenever a retry condition is encountered.
        /// </summary>
        /// <param name="retryCount">The current retry attempt count.</param>
        /// <param name="lastError">The exception that caused the retry conditions to occur.</param>
        /// <param name="delay">The delay that indicates how long the current thread will be suspended before 
        /// the next iteration is invoked.</param>
        protected virtual void OnRetrying(int retryCount, Exception lastError, TimeSpan delay)
        {
            if (this.Retrying != null)
            {
                this.Retrying(this, new RetryingEventArgs(retryCount, delay, lastError));
            }
        }
    }
}
