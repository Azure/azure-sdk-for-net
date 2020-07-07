// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class HostMessageExecutor
    {
        private readonly IFunctionExecutor _innerExecutor;
        private readonly IFunctionIndexLookup _functionLookup;
        private readonly IFunctionInstanceLogger _functionInstanceLogger;

        public HostMessageExecutor(IFunctionExecutor innerExecutor, IFunctionIndexLookup functionLookup, IFunctionInstanceLogger functionInstanceLogger)
        {
            _innerExecutor = innerExecutor;
            _functionLookup = functionLookup;
            _functionInstanceLogger = functionInstanceLogger;
        }

        public async Task<FunctionResult> ExecuteAsync(string value, CancellationToken cancellationToken)
        {
            HostMessage model = JsonConvert.DeserializeObject<HostMessage>(value, JsonSerialization.Settings);

            if (model == null)
            {
                throw new InvalidOperationException("Invalid invocation message.");
            }

            CallAndOverrideMessage callAndOverrideModel = model as CallAndOverrideMessage;

            if (callAndOverrideModel != null)
            {
                await ProcessCallAndOverrideMessage(callAndOverrideModel, cancellationToken);
                return new FunctionResult(true);
            }

            AbortHostInstanceMessage abortModel = model as AbortHostInstanceMessage;

            if (abortModel != null)
            {
                ProcessAbortHostInstanceMessage();
                return new FunctionResult(true);
            }

            string error = String.Format(CultureInfo.InvariantCulture, "Unsupported invocation type '{0}'.", model.Type);
            throw new NotSupportedException(error);
        }

        // This snapshot won't contain full normal data for Function.FullName, Function.ShortName and Function.Parameters.
        // (All we know is an unavailable function ID; which function location method info to use is a mystery.)
        private static FunctionCompletedMessage CreateFailedMessage(CallAndOverrideMessage message)
        {
            DateTimeOffset startAndEndTime = DateTimeOffset.UtcNow;
            Exception exception = new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                        "No function '{0}' currently exists.", message.FunctionId));

            // In theory, we could also set HostId, HostInstanceId and WebJobRunId; we'd just have to expose that data
            // directly to this Worker class.
            return new FunctionCompletedMessage
            {
                FunctionInstanceId = message.Id,
                Function = new FunctionDescriptor
                {
                    Id = message.FunctionId
                },
                Arguments = message.Arguments,
                ParentId = message.ParentId,
                Reason = message.Reason,
                StartTime = startAndEndTime,
                EndTime = startAndEndTime,
                Failure = new FunctionFailure
                {
                    Exception = exception,
                    ExceptionType = exception.GetType().FullName,
                    ExceptionDetails = exception.Message
                }
            };
        }

        private IFunctionInstance CreateFunctionInstance(CallAndOverrideMessage message)
        {
            IFunctionDefinition function = _functionLookup.Lookup(message.FunctionId);

            if (function == null)
            {
                return null;
            }

            IDictionary<string, object> objectParameters = new Dictionary<string, object>();

            if (message.Arguments != null)
            {
                foreach (KeyValuePair<string, string> item in message.Arguments)
                {
                    objectParameters.Add(item.Key, item.Value);
                }
            }

            var context = new FunctionInstanceFactoryContext
            {
                Id = message.Id,
                ParentId = message.ParentId,
                ExecutionReason = message.Reason,
                Parameters = objectParameters
            };

            return function.InstanceFactory.Create(context);
        }

        private async Task ProcessCallAndOverrideMessage(CallAndOverrideMessage message, CancellationToken cancellationToken)
        {
            IFunctionInstance instance = CreateFunctionInstance(message);

            if (instance != null)
            {
                await _innerExecutor.TryExecuteAsync(instance, cancellationToken);
            }
            else
            {
                // Log that the function failed.
                FunctionCompletedMessage failedMessage = CreateFailedMessage(message);
                await _functionInstanceLogger.LogFunctionCompletedAsync(failedMessage, cancellationToken);
            }
        }

        private static void ProcessAbortHostInstanceMessage()
        {
            bool terminated = NativeMethods.TerminateProcess(NativeMethods.GetCurrentProcess(), 1);
            Debug.Assert(terminated);
        }
    }
}
