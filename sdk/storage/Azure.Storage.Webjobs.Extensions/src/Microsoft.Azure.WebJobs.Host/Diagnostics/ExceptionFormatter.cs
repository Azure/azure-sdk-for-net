// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// Adapted from code here: https://github.com/dotnet/roslyn/blob/master/src/VisualStudio/Core/Def/Implementation/Workspace/VisualStudioErrorReportingService.ExceptionFormatting.cs

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microsoft.Azure.WebJobs.Host.Diagnostics
{
    /// <summary>
    /// Provides functionality to format and sanitize an exception for logging.
    /// </summary>
    public static class ExceptionFormatter
    {
        private static readonly string[] EmtpyArray = new string[0];

        /// <summary>
        /// Formats an exception for logging.
        /// </summary>
        /// <param name="exception">The exception to be formatted.</param>
        /// <returns>A string representation of the exception with a sanitized stack trace.</returns>
        public static string GetFormattedException(Exception exception)
        {
            try
            {
                var aggregate = exception as AggregateException;
                if (aggregate != null)
                {
                    return GetStackForAggregateException(exception, aggregate);
                }

                return GetStackForException(exception, includeMessageOnly: false);
            }
            catch (Exception)
            {
                return exception?.ToString();
            }
        }

        private static string GetStackForAggregateException(Exception exception, AggregateException aggregate)
        {
            var text = GetStackForException(exception, includeMessageOnly: true);
            for (int i = 0; i < aggregate.InnerExceptions.Count; i++)
            {
                text = $"{text}{Environment.NewLine}---> (Inner Exception #{i}) {GetFormattedException(aggregate.InnerExceptions[i])}<---{Environment.NewLine}";
            }

            return text;
        }

        private static string GetStackForException(Exception exception, bool includeMessageOnly)
        {
            var message = exception.Message;
            var className = exception.GetType().ToString();
            var stackText = message.Length <= 0
                ? className
                : className + " : " + message;
            var innerException = exception.InnerException;
            if (innerException != null)
            {
                if (includeMessageOnly)
                {
                    do
                    {
                        stackText += " ---> " + innerException.Message;
                        innerException = innerException.InnerException;
                    }
                    while (innerException != null);
                }
                else
                {
                    stackText += $" ---> {GetFormattedException(innerException)} {Environment.NewLine}   End of inner exception";
                }
            }

            string stackTrace = GetAsyncStackTrace(exception);
            if (!string.IsNullOrEmpty(stackTrace))
            {
                stackText += Environment.NewLine + stackTrace;
            }

            return stackText;
        }

        private static string GetAsyncStackTrace(Exception exception)
        {
            var stackTrace = new StackTrace(exception, fNeedFileInfo: true);
            var stackFrames = stackTrace.GetFrames();
            if (stackFrames == null)
            {
                return string.Empty;
            }

            var stackFrameLines = from frame in stackFrames
                                  let method = frame.GetMethod()
                                  let declaringType = method?.DeclaringType
                                  where ShouldShowFrame(declaringType)
                                  select FormatFrame(method, declaringType, frame);

            return string.Join(Environment.NewLine, stackFrameLines);
        }

        private static bool ShouldShowFrame(Type declaringType) =>
            !(declaringType != null && typeof(INotifyCompletion).IsAssignableFrom(declaringType));

        private static string FormatFrame(MethodBase method, Type declaringType, StackFrame frame)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("   at ");
            bool isAsync;
            FormatMethodName(stringBuilder, declaringType, out isAsync);
            if (!isAsync)
            {
                stringBuilder.Append(method?.Name);
                var methodInfo = method as MethodInfo;
                if (methodInfo?.IsGenericMethod == true)
                {
                    FormatGenericArguments(stringBuilder, methodInfo.GetGenericArguments());
                }
            }
            else if (declaringType?.IsGenericType == true)
            {
                FormatGenericArguments(stringBuilder, declaringType.GetGenericArguments());
            }

            stringBuilder.Append("(");
            if (isAsync)
            {
                // Best effort
                string methodFromType = GetMethodFromAsyncStateMachineType(declaringType);
                List<MethodInfo> methods = null;
                if (methodFromType != null)
                {
                    methods = declaringType?.DeclaringType.GetMethods((BindingFlags)int.MaxValue)
                        .Where(m => string.Equals(m.Name, methodFromType))
                        .ToList();
                }

                if (methods != null && methods.Count == 1)
                {
                    FormatParameters(stringBuilder, methods.First());
                }
                else
                {
                    stringBuilder.Append("??");
                }
            }
            else
            {
                FormatParameters(stringBuilder, method);
            }

            stringBuilder.Append(")");

            FormatFileName(stringBuilder, frame);

            return stringBuilder.ToString();
        }

        private static void FormatFileName(StringBuilder stringBuilder, StackFrame frame)
        {
            try
            {
                var fileName = frame.GetFileName();
                if (fileName != null)
                {
                    stringBuilder.Append($" at {fileName} : {frame.GetFileLineNumber()}");
                }
            }
            catch
            {
                // If we're unable to get the file name, move on...
            }
        }

        private static void FormatMethodName(StringBuilder stringBuilder, Type declaringType, out bool isAsync)
        {
            if (declaringType == null)
            {
                isAsync = false;
                return;
            }

            var fullName = declaringType.FullName.Replace('+', '.');
            if (typeof(IAsyncStateMachine).GetTypeInfo().IsAssignableFrom(declaringType))
            {
                stringBuilder.Append("async ");
                var start = fullName.LastIndexOf('<');
                var end = fullName.LastIndexOf('>');
                if (start >= 0 && end >= 0)
                {
                    stringBuilder.Append(fullName.Remove(start, 1).Substring(0, end - 1));
                }
                else
                {
                    stringBuilder.Append(fullName);
                }

                isAsync = true;
            }
            else
            {
                stringBuilder.Append(fullName);
                stringBuilder.Append(".");
                isAsync = false;
            }
        }

        private static string GetMethodFromAsyncStateMachineType(Type type)
        {
            var fullName = type.FullName.Replace('+', '.');
            var start = fullName.LastIndexOf('<');
            var end = fullName.LastIndexOf('>') - 1;
            if (start >= 0 && end >= 0)
            {
                return fullName.Substring(start + 1, end - start);
            }

            return null;
        }

        private static void FormatGenericArguments(StringBuilder stringBuilder, Type[] genericTypeArguments)
        {
            if (genericTypeArguments.Length <= 0)
            {
                return;
            }

            stringBuilder.Append("[" + String.Join(",", genericTypeArguments.Select(args => args.Name)) + "]");
        }

        private static void FormatParameters(StringBuilder stringBuilder, MethodBase method) =>
            stringBuilder.Append(string.Join(",", method?.GetParameters().Select(t => (t.ParameterType?.Name ?? "<UnknownType>") + " " + t.Name) ?? EmtpyArray));
    }
}
