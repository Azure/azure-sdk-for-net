// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Azure.AI.Projects
{
    public static class FunctionTracer
    {
        private static readonly ActivitySource ActivitySource = new("Azure.AI.Projects.FunctionTracer");

        #region Synchronous Methods

        /// <summary>
        /// Traces a synchronous function execution with automatic parameter and return value capture.
        /// Only traces supported data types (primitives, common framework types, and collections).
        /// Object types are omitted from tracing.
        /// </summary>
        public static T Trace<T>(Expression<Func<T>> expression, string? functionName = null)
        {
            var func = expression.Compile();
            var extractedName = functionName ?? ExtractFunctionName(expression);

            var activity = ActivitySource.StartActivity(extractedName);

            try
            {
                // Extract and trace parameters
                TraceParameters(activity, expression);

                var stopwatch = Stopwatch.StartNew();
                var result = func();
                stopwatch.Stop();

                activity?.SetTag("duration_ms", stopwatch.ElapsedMilliseconds);

                // Only trace if result is a supported type
                if (result != null && IsSupportedType(result))
                {
                    activity?.SetTag("code.function.return.value", ConvertToTraceValue(result));
                }

                return result;
            }
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                activity?.SetTag("error.type", ex.GetType().Name);
                activity?.SetTag("error.message", ex.Message);
                throw;
            }
            finally
            {
                activity?.Dispose();
            }
        }

        /// <summary>
        /// Traces a synchronous action (void return) with automatic parameter capture.
        /// </summary>
        public static void Trace(Expression<Action> expression, string? functionName = null)
        {
            var action = expression.Compile();
            var extractedName = functionName ?? ExtractFunctionName(expression);

            var activity = ActivitySource.StartActivity(extractedName);

            try
            {
                // Extract and trace parameters
                TraceParameters(activity, expression);

                var stopwatch = Stopwatch.StartNew();
                action();
                stopwatch.Stop();

                activity?.SetTag("duration_ms", stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                activity?.SetTag("error.type", ex.GetType().Name);
                activity?.SetTag("error.message", ex.Message);
                throw;
            }
            finally
            {
                activity?.Dispose();
            }
        }

        #endregion

        #region Asynchronous Methods

        /// <summary>
        /// Traces an asynchronous function execution with automatic parameter and return value capture.
        /// Only traces supported data types (primitives, common framework types, and collections).
        /// Object types are omitted from tracing.
        /// </summary>
        public static async Task<T> TraceAsync<T>(Expression<Func<Task<T>>> expression, string? functionName = null)
        {
            var func = expression.Compile();
            var extractedName = functionName ?? ExtractFunctionName(expression);

            var activity = ActivitySource.StartActivity(extractedName);

            try
            {
                // Extract and trace parameters
                TraceParameters(activity, expression);

                var stopwatch = Stopwatch.StartNew();
                var result = await func().ConfigureAwait(false);
                stopwatch.Stop();

                activity?.SetTag("duration_ms", stopwatch.ElapsedMilliseconds);

                // Only trace if result is a supported type
                if (result != null && IsSupportedType(result))
                {
                    activity?.SetTag("code.function.return.value", ConvertToTraceValue(result));
                }

                return result;
            }
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                activity?.SetTag("error.type", ex.GetType().Name);
                activity?.SetTag("error.message", ex.Message);
                throw;
            }
            finally
            {
                activity?.Dispose();
            }
        }

        /// <summary>
        /// Traces an asynchronous action (Task return) with automatic parameter capture.
        /// </summary>
        public static async Task TraceAsync(Expression<Func<Task>> expression, string? functionName = null)
        {
            var func = expression.Compile();
            var extractedName = functionName ?? ExtractFunctionName(expression);

            var activity = ActivitySource.StartActivity(extractedName);

            try
            {
                // Extract and trace parameters
                TraceParameters(activity, expression);

                var stopwatch = Stopwatch.StartNew();
                await func().ConfigureAwait(false);
                stopwatch.Stop();

                activity?.SetTag("duration_ms", stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                activity?.SetTag("error.type", ex.GetType().Name);
                activity?.SetTag("error.message", ex.Message);
                throw;
            }
            finally
            {
                activity?.Dispose();
            }
        }

        #endregion

        #region Expression Analysis and Parameter Tracing

        /// <summary>
        /// Extracts function name from expression tree.
        /// </summary>
        private static string ExtractFunctionName(LambdaExpression expression)
        {
            return expression.Body switch
            {
                MethodCallExpression methodCall => methodCall.Method.Name,
                MemberExpression member => member.Member.Name,
                _ => "UnknownFunction"
            };
        }

        /// <summary>
        /// Traces function parameters by analyzing the expression tree.
        /// Only evaluates and traces parameters of supported types.
        /// </summary>
        private static void TraceParameters(Activity? activity, LambdaExpression expression)
        {
            if (expression.Body is not MethodCallExpression methodCall)
                return;

            var method = methodCall.Method;
            var parameters = method.GetParameters();
            var arguments = methodCall.Arguments;

            for (int i = 0; i < parameters.Length && i < arguments.Count; i++)
            {
                var param = parameters[i];
                var argExpression = arguments[i];

                // First, check if the parameter TYPE is potentially supported
                if (!CouldBeSupportedType(param.ParameterType))
                {
                    // Skip entirely - don't even try to evaluate
                    continue;
                }

                try
                {
                    // Only evaluate if the type might be supported
                    var value = EvaluateExpression(argExpression);

                    // Double-check with actual value (for polymorphic cases)
                    if (value != null && IsSupportedType(value))
                    {
                        activity?.SetTag($"code.function.parameter.{param.Name}", ConvertToTraceValue(value));
                    }
                    // If not supported, omit (like Python @trace_function)
                }
                catch
                {
                    // If evaluation fails, skip this parameter silently
                    // This handles complex expressions, side effects, etc.
                }
            }
        }

        /// <summary>
        /// Quick type check to see if a parameter type could potentially be supported.
        /// This avoids expensive expression evaluation for obviously unsupported types.
        /// </summary>
        private static bool CouldBeSupportedType(Type type)
        {
            // Handle nullable types
            var underlyingType = Nullable.GetUnderlyingType(type) ?? type;

            return underlyingType == typeof(string) ||
                   underlyingType == typeof(int) ||
                   underlyingType == typeof(long) ||
                   underlyingType == typeof(float) ||
                   underlyingType == typeof(double) ||
                   underlyingType == typeof(decimal) ||
                   underlyingType == typeof(bool) ||
                   underlyingType == typeof(char) ||
                   underlyingType == typeof(byte) ||
                   underlyingType == typeof(sbyte) ||
                   underlyingType == typeof(short) ||
                   underlyingType == typeof(ushort) ||
                   underlyingType == typeof(uint) ||
                   underlyingType == typeof(ulong) ||
                   underlyingType == typeof(DateTime) ||
                   underlyingType == typeof(DateTimeOffset) ||
                   underlyingType == typeof(Guid) ||
                   underlyingType == typeof(TimeSpan) ||
                   typeof(IEnumerable).IsAssignableFrom(underlyingType); // Collections
        }

        /// <summary>
        /// Safely evaluates an expression to get its runtime value.
        /// Returns null if evaluation fails or is unsafe.
        /// </summary>
        private static object? EvaluateExpression(Expression expression)
        {
            try
            {
                // Additional safety: avoid evaluating expressions that might have side effects
                if (HasPotentialSideEffects(expression))
                {
                    return null;
                }

                var lambda = Expression.Lambda(expression);
                var compiled = lambda.Compile();
                return compiled.DynamicInvoke();
            }
            catch
            {
                // Silently ignore evaluation failures
                return null;
            }
        }

        /// <summary>
        /// Checks if an expression might have side effects and should not be evaluated twice.
        /// </summary>
        private static bool HasPotentialSideEffects(Expression expression)
        {
            return expression switch
            {
                // Method calls might have side effects
                MethodCallExpression => true,

                // New object creation is usually safe but can be expensive
                NewExpression => false,

                // Member access is usually safe
                MemberExpression => false,

                // Constants are always safe
                ConstantExpression => false,

                // Parameter access is safe
                ParameterExpression => false,

                // Unary expressions (like conversions) are usually safe
                UnaryExpression => false,

                // Binary expressions (like arithmetic) are usually safe
                BinaryExpression => false,

                // For other types, be conservative
                _ => true
            };
        }

        #endregion

        #region Type Checking and Conversion

        /// <summary>
        /// Determines if a value is of a supported type for tracing.
        /// Supports: all C# primitive types, common framework types, and collections.
        /// Object types are not supported and will be omitted from tracing.
        /// </summary>
        private static bool IsSupportedType(object value)
        {
            return value switch
            {
                // Integer types
                byte or sbyte => true,
                short or ushort => true,
                int or uint => true,
                long or ulong => true,

                // Floating-point types
                float or double or decimal => true,

                // Other basic types
                bool => true,
                char => true,
                string => true,

                // Common framework types
                DateTime => true,
                DateTimeOffset => true,
                Guid => true,
                TimeSpan => true,

                // Collections (C# equivalents of Python list, dict, tuple, set)
                IEnumerable when value is not string => true,

                // Object types are omitted
                _ => false
            };
        }

        /// <summary>
        /// Converts a supported value to its string representation for tracing.
        /// Handles special formatting for different types and nested collections.
        /// </summary>
        private static string ConvertToTraceValue(object value)
        {
            return value switch
            {
                // String - return as-is
                string str => str,

                // Integer types
                byte b => b.ToString(),
                sbyte sb => sb.ToString(),
                short s => s.ToString(),
                ushort us => us.ToString(),
                int i => i.ToString(),
                uint ui => ui.ToString(),
                long l => l.ToString(),
                ulong ul => ul.ToString(),

                // Floating-point types
                float f => f.ToString(),
                double d => d.ToString(),
                decimal dec => dec.ToString(),

                // Other basic types
                bool b => b.ToString().ToLowerInvariant(), // "true"/"false" to match Python
                char c => c.ToString(),

                // Common framework types
                DateTime dt => dt.ToString("O"), // ISO 8601 format
                DateTimeOffset dto => dto.ToString("O"), // ISO 8601 with offset
                Guid guid => guid.ToString(), // Standard GUID format
                TimeSpan ts => ts.ToString(), // Standard TimeSpan format

                // Collections
                IEnumerable enumerable when value is not string => ConvertCollectionToString(enumerable),

                // Fallback (shouldn't reach here if IsSupportedType is correct)
                _ => value.ToString() ?? "null"
            };
        }

        /// <summary>
        /// Converts collections to string representation, handling nested collections.
        /// Follows Python @trace_function behavior for collection handling.
        /// </summary>
        private static string ConvertCollectionToString(IEnumerable collection)
        {
            var items = new List<string>();

            foreach (var item in collection)
            {
                if (item == null)
                {
                    items.Add("null");
                }
                else if (IsSupportedType(item))
                {
                    // If item is a collection itself, convert entire thing to string
                    if (item is IEnumerable && !(item is string))
                    {
                        items.Add($"[{ConvertCollectionToString((IEnumerable)item)}]");
                    }
                    else
                    {
                        items.Add(ConvertToTraceValue(item));
                    }
                }
                // Unsupported types in collections are omitted
            }

            return string.Join(", ", items);
        }

        #endregion
    }

    #region Extension Methods for Fluent Syntax

    /// <summary>
    /// Extension methods to provide fluent syntax for tracing.
    /// </summary>
    public static class FunctionTracerExtensions
    {
        /// <summary>
        /// Traces the execution of a function with fluent syntax and automatic parameter capture.
        /// </summary>
        public static T WithTracing<T>(this Expression<Func<T>> expression, string? functionName = null)
        {
            return FunctionTracer.Trace(expression, functionName);
        }

        /// <summary>
        /// Traces the execution of an action with fluent syntax and automatic parameter capture.
        /// </summary>
        public static void WithTracing(this Expression<Action> expression, string? functionName = null)
        {
            FunctionTracer.Trace(expression, functionName);
        }

        /// <summary>
        /// Traces the execution of an async function with fluent syntax and automatic parameter capture.
        /// </summary>
        public static Task<T> WithTracingAsync<T>(this Expression<Func<Task<T>>> expression, string? functionName = null)
        {
            return FunctionTracer.TraceAsync(expression, functionName);
        }

        /// <summary>
        /// Traces the execution of an async action with fluent syntax and automatic parameter capture.
        /// </summary>
        public static Task WithTracingAsync(this Expression<Func<Task>> expression, string? functionName = null)
        {
            return FunctionTracer.TraceAsync(expression, functionName);
        }
    }

    #endregion
}
