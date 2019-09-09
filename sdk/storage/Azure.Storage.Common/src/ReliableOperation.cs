// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading.Tasks;

namespace Azure.Storage.Common
{
    static class ReliableOperation
    {
        public static T Do<T>(Func<T> operation, Action reset, Action cleanup, Func<Exception, bool> predicate, int maximumRetries)
        {
            while (true)
            {
                try
                {
                    var result = operation();
                    return result;
                }
                catch (OperationCanceledException)
                {
                    cleanup();
                    throw;
                }
                catch (Exception e) when (predicate(e))
                {
                    if (maximumRetries-- <= 0)
                    {
                        cleanup();
                        throw;
                    }

                    reset();
                }
                catch
                {
                    cleanup();
                    throw;
                }
            }
        }

        public static Task<T> DoAsync<T>(Func<Task<T>> operation, ReliabilityConfiguration? reliabilityConfiguration = default, int maximumRetries = Constants.MaxReliabilityRetries)
        {
            reliabilityConfiguration = reliabilityConfiguration ?? ReliabilityConfiguration.Default;

            return DoAsync(operation, reliabilityConfiguration.Value.Reset, reliabilityConfiguration.Value.Cleanup, reliabilityConfiguration.Value.ExceptionPredicate, maximumRetries);
        }

        public static async Task<T> DoAsync<T>(Func<Task<T>> operation, Action reset, Action cleanup, Func<Exception, bool> predicate, int maximumRetries)
        {
            while (true)
            {
                try
                {
                    var result = await operation().ConfigureAwait(false);
                    return result;
                }
                catch (OperationCanceledException)
                {
                    cleanup();
                    throw;
                }
                catch (Exception e) when (predicate(e))
                {
                    if (maximumRetries-- <= 0)
                    {
                        cleanup();
                        throw;
                    }

                    reset();
                }
                catch
                {
                    cleanup();
                    throw;
                }
            }
        }

        public static async Task<T> DoSyncOrAsync<T>(bool isAsync, Func<Task<T>> operation, Action reset, Action cleanup, Func<Exception, bool> predicate, int maximumRetries)
        {
            while (true)
            {
                try
                {
                    var result = isAsync ?
                        await operation().ConfigureAwait(false) :
                        operation().EnsureCompleted();
                    return result;
                }
                catch (OperationCanceledException)
                {
                    cleanup();
                    throw;
                }
                catch (Exception e) when (predicate(e))
                {
                    if (maximumRetries-- <= 0)
                    {
                        cleanup();
                        throw;
                    }

                    reset();
                }
                catch
                {
                    cleanup();
                    throw;
                }
            }
        }
    }
}
