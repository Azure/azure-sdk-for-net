// <copyright file="HttpWebRequestActivitySource.netfx.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

#if NETFRAMEWORK
using System.Collections;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using OpenTelemetry.Context.Propagation;
using OpenTelemetry.Trace;
using static OpenTelemetry.Internal.HttpSemanticConventionHelper;

namespace OpenTelemetry.Instrumentation.Http.Implementation
{
    /// <summary>
    /// Hooks into the <see cref="HttpWebRequest"/> class reflectively and writes diagnostic events as requests are processed.
    /// </summary>
    /// <remarks>
    /// Inspired from the System.Diagnostics.DiagnosticSource.HttpHandlerDiagnosticListener class which has some bugs and feature gaps.
    /// See https://github.com/dotnet/runtime/pull/33732 for details.
    /// </remarks>
    internal static class HttpWebRequestActivitySource
    {
        internal static readonly AssemblyName AssemblyName = typeof(HttpWebRequestActivitySource).Assembly.GetName();
        internal static readonly string ActivitySourceName = AssemblyName.Name + ".HttpWebRequest";
        internal static readonly string ActivityName = ActivitySourceName + ".HttpRequestOut";

        internal static readonly Func<HttpWebRequest, string, IEnumerable<string>> HttpWebRequestHeaderValuesGetter = (request, name) => request.Headers.GetValues(name);
        internal static readonly Action<HttpWebRequest, string, string> HttpWebRequestHeaderValuesSetter = (request, name, value) => request.Headers.Add(name, value);

        private static readonly Version Version = AssemblyName.Version;
        private static readonly ActivitySource WebRequestActivitySource = new ActivitySource(ActivitySourceName, Version.ToString());

        private static HttpClientInstrumentationOptions options;

        private static bool emitOldAttributes;
        private static bool emitNewAttributes;

        // Fields for reflection
        private static FieldInfo connectionGroupListField;
        private static Type connectionGroupType;
        private static FieldInfo connectionListField;
        private static Type connectionType;
        private static FieldInfo writeListField;
        private static Func<object, IAsyncResult> writeAResultAccessor;
        private static Func<object, IAsyncResult> readAResultAccessor;

        // LazyAsyncResult & ContextAwareResult
        private static Func<object, AsyncCallback> asyncCallbackAccessor;
        private static Action<object, AsyncCallback> asyncCallbackModifier;
        private static Func<object, object> asyncStateAccessor;
        private static Action<object, object> asyncStateModifier;
        private static Func<object, bool> endCalledAccessor;
        private static Func<object, object> resultAccessor;
        private static Func<object, bool> isContextAwareResultChecker;

        // HttpWebResponse
        private static Func<object[], HttpWebResponse> httpWebResponseCtor;
        private static Func<HttpWebResponse, Uri> uriAccessor;
        private static Func<HttpWebResponse, object> verbAccessor;
        private static Func<HttpWebResponse, string> mediaTypeAccessor;
        private static Func<HttpWebResponse, bool> usesProxySemanticsAccessor;
        private static Func<HttpWebResponse, object> coreResponseDataAccessor;
        private static Func<HttpWebResponse, bool> isWebSocketResponseAccessor;
        private static Func<HttpWebResponse, string> connectionGroupNameAccessor;

        static HttpWebRequestActivitySource()
        {
            try
            {
                PrepareReflectionObjects();
                PerformInjection();

                Options = new HttpClientInstrumentationOptions();
            }
            catch (Exception ex)
            {
                // If anything went wrong, just no-op. Write an event so at least we can find out.
                HttpInstrumentationEventSource.Log.ExceptionInitializingInstrumentation(typeof(HttpWebRequestActivitySource).FullName, ex);
            }
        }

        internal static HttpClientInstrumentationOptions Options
        {
            get => options;
            set
            {
                options = value;

                emitOldAttributes = value.HttpSemanticConvention.HasFlag(HttpSemanticConvention.Old);
                emitNewAttributes = value.HttpSemanticConvention.HasFlag(HttpSemanticConvention.New);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void AddRequestTagsAndInstrumentRequest(HttpWebRequest request, Activity activity)
        {
            activity.DisplayName = HttpTagHelper.GetOperationNameForHttpMethod(request.Method);

            if (activity.IsAllDataRequested)
            {
                // see the spec https://github.com/open-telemetry/opentelemetry-specification/blob/v1.20.0/specification/trace/semantic_conventions/http.md
                if (emitOldAttributes)
                {
                    activity.SetTag(SemanticConventions.AttributeHttpMethod, request.Method);
                    activity.SetTag(SemanticConventions.AttributeNetPeerName, request.RequestUri.Host);
                    if (!request.RequestUri.IsDefaultPort)
                    {
                        activity.SetTag(SemanticConventions.AttributeNetPeerPort, request.RequestUri.Port);
                    }

                    activity.SetTag(SemanticConventions.AttributeHttpScheme, request.RequestUri.Scheme);
                    activity.SetTag(SemanticConventions.AttributeHttpUrl, HttpTagHelper.GetUriTagValueFromRequestUri(request.RequestUri));
                    activity.SetTag(SemanticConventions.AttributeHttpFlavor, HttpTagHelper.GetFlavorTagValueFromProtocolVersion(request.ProtocolVersion));
                }

                // see the spec https://github.com/open-telemetry/semantic-conventions/blob/v1.21.0/docs/http/http-spans.md
                if (emitNewAttributes)
                {
                    activity.SetTag(SemanticConventions.AttributeHttpRequestMethod, request.Method);
                    activity.SetTag(SemanticConventions.AttributeServerAddress, request.RequestUri.Host);
                    if (!request.RequestUri.IsDefaultPort)
                    {
                        activity.SetTag(SemanticConventions.AttributeServerPort, request.RequestUri.Port);
                    }

                    activity.SetTag(SemanticConventions.AttributeUrlFull, HttpTagHelper.GetUriTagValueFromRequestUri(request.RequestUri));
                    activity.SetTag(SemanticConventions.AttributeNetworkProtocolVersion, HttpTagHelper.GetFlavorTagValueFromProtocolVersion(request.ProtocolVersion));
                }

                try
                {
                    Options.EnrichWithHttpWebRequest?.Invoke(activity, request);
                }
                catch (Exception ex)
                {
                    HttpInstrumentationEventSource.Log.EnrichmentException(ex);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void AddResponseTags(HttpWebResponse response, Activity activity)
        {
            if (activity.IsAllDataRequested)
            {
                if (emitOldAttributes)
                {
                    activity.SetTag(SemanticConventions.AttributeHttpStatusCode, TelemetryHelper.GetBoxedStatusCode(response.StatusCode));
                }

                if (emitNewAttributes)
                {
                    activity.SetTag(SemanticConventions.AttributeHttpResponseStatusCode, TelemetryHelper.GetBoxedStatusCode(response.StatusCode));
                }

                activity.SetStatus(SpanHelper.ResolveSpanStatusForHttpStatusCode(activity.Kind, (int)response.StatusCode));

                try
                {
                    Options.EnrichWithHttpWebResponse?.Invoke(activity, response);
                }
                catch (Exception ex)
                {
                    HttpInstrumentationEventSource.Log.EnrichmentException(ex);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void AddExceptionTags(Exception exception, Activity activity)
        {
            if (!activity.IsAllDataRequested)
            {
                return;
            }

            ActivityStatusCode status;
            string exceptionMessage = null;

            if (exception is WebException wexc)
            {
                if (wexc.Response is HttpWebResponse response)
                {
                    if (emitOldAttributes)
                    {
                        activity.SetTag(SemanticConventions.AttributeHttpStatusCode, (int)response.StatusCode);
                    }

                    if (emitNewAttributes)
                    {
                        activity.SetTag(SemanticConventions.AttributeHttpResponseStatusCode, (int)response.StatusCode);
                    }

                    status = SpanHelper.ResolveSpanStatusForHttpStatusCode(activity.Kind, (int)response.StatusCode);
                }
                else
                {
                    switch (wexc.Status)
                    {
                        case WebExceptionStatus.Timeout:
                        case WebExceptionStatus.RequestCanceled:
                            status = ActivityStatusCode.Error;
                            break;
                        case WebExceptionStatus.SendFailure:
                        case WebExceptionStatus.ConnectFailure:
                        case WebExceptionStatus.SecureChannelFailure:
                        case WebExceptionStatus.TrustFailure:
                        case WebExceptionStatus.ServerProtocolViolation:
                        case WebExceptionStatus.MessageLengthLimitExceeded:
                            status = ActivityStatusCode.Error;
                            exceptionMessage = exception.Message;
                            break;
                        default:
                            status = ActivityStatusCode.Error;
                            exceptionMessage = exception.Message;
                            break;
                    }
                }
            }
            else
            {
                status = ActivityStatusCode.Error;
                exceptionMessage = exception.Message;
            }

            activity.SetStatus(status, exceptionMessage);
            if (Options.RecordException)
            {
                activity.RecordException(exception);
            }

            try
            {
                Options.EnrichWithException?.Invoke(activity, exception);
            }
            catch (Exception ex)
            {
                HttpInstrumentationEventSource.Log.EnrichmentException(ex);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void InstrumentRequest(HttpWebRequest request, ActivityContext activityContext)
            => Propagators.DefaultTextMapPropagator.Inject(new PropagationContext(activityContext, Baggage.Current), request, HttpWebRequestHeaderValuesSetter);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsRequestInstrumented(HttpWebRequest request)
            => Propagators.DefaultTextMapPropagator.Extract(default, request, HttpWebRequestHeaderValuesGetter) != default;

        private static void ProcessRequest(HttpWebRequest request)
        {
            if (!WebRequestActivitySource.HasListeners() || !Options.EventFilterHttpWebRequest(request))
            {
                // No subscribers to the ActivitySource or User provider Filter is
                // filtering this request.
                // Propagation must still be done in such cases, to allow
                // downstream services to continue from parent context, if any.
                // Eg: Parent could be the Asp.Net activity.
                InstrumentRequest(request, Activity.Current?.Context ?? default);
                return;
            }

            if (IsRequestInstrumented(request))
            {
                // This request was instrumented by previous
                // ProcessRequest, such is the case with redirect responses where the same request is sent again.
                return;
            }

            var activity = WebRequestActivitySource.StartActivity(ActivityName, ActivityKind.Client);
            var activityContext = Activity.Current?.Context ?? default;

            // Propagation must still be done in all cases, to allow
            // downstream services to continue from parent context, if any.
            // Eg: Parent could be the Asp.Net activity.
            InstrumentRequest(request, activityContext);
            if (activity == null)
            {
                // There is a listener but it decided not to sample the current request.
                return;
            }

            IAsyncResult asyncContext = writeAResultAccessor(request);
            if (asyncContext != null)
            {
                // Flow here is for [Begin]GetRequestStream[Async].

                AsyncCallbackWrapper callback = new AsyncCallbackWrapper(request, activity, asyncCallbackAccessor(asyncContext));
                asyncCallbackModifier(asyncContext, callback.AsyncCallback);
            }
            else
            {
                // Flow here is for [Begin]GetResponse[Async] without a prior call to [Begin]GetRequestStream[Async].

                asyncContext = readAResultAccessor(request);
                AsyncCallbackWrapper callback = new AsyncCallbackWrapper(request, activity, asyncCallbackAccessor(asyncContext));
                asyncCallbackModifier(asyncContext, callback.AsyncCallback);
            }

            AddRequestTagsAndInstrumentRequest(request, activity);
        }

        private static void HookOrProcessResult(HttpWebRequest request)
        {
            IAsyncResult writeAsyncContext = writeAResultAccessor(request);
            if (writeAsyncContext == null || !(asyncCallbackAccessor(writeAsyncContext)?.Target is AsyncCallbackWrapper writeAsyncContextCallback))
            {
                // If we already hooked into the read result during ProcessRequest or we hooked up after the fact already we don't need to do anything here.
                return;
            }

            // If we got here it means the user called [Begin]GetRequestStream[Async] and we have to hook the read result after the fact.

            IAsyncResult readAsyncContext = readAResultAccessor(request);
            if (readAsyncContext == null)
            {
                // We're still trying to establish the connection (no read has started).
                return;
            }

            // Clear our saved callback so we know not to process again.
            asyncCallbackModifier(writeAsyncContext, null);

            if (endCalledAccessor.Invoke(readAsyncContext) || readAsyncContext.CompletedSynchronously)
            {
                // We need to process the result directly because the read callback has already fired. Force a copy because response has likely already been disposed.
                ProcessResult(readAsyncContext, null, writeAsyncContextCallback.Activity, resultAccessor(readAsyncContext), true);
                return;
            }

            // Hook into the result callback if it hasn't already fired.
            AsyncCallbackWrapper callback = new AsyncCallbackWrapper(writeAsyncContextCallback.Request, writeAsyncContextCallback.Activity, asyncCallbackAccessor(readAsyncContext));
            asyncCallbackModifier(readAsyncContext, callback.AsyncCallback);
        }

        private static void ProcessResult(IAsyncResult asyncResult, AsyncCallback asyncCallback, Activity activity, object result, bool forceResponseCopy)
        {
            // We could be executing on a different thread now so restore the activity if needed.
            if (Activity.Current != activity)
            {
                Activity.Current = activity;
            }

            try
            {
                if (result is Exception ex)
                {
                    AddExceptionTags(ex, activity);
                }
                else
                {
                    HttpWebResponse response = (HttpWebResponse)result;

                    if (forceResponseCopy || (asyncCallback == null && isContextAwareResultChecker(asyncResult)))
                    {
                        // For async calls (where asyncResult is ContextAwareResult)...
                        // If no callback was set assume the user is manually calling BeginGetResponse & EndGetResponse
                        // in which case they could dispose the HttpWebResponse before our listeners have a chance to work with it.
                        // Disposed HttpWebResponse throws when accessing properties, so let's make a copy of the data to ensure that doesn't happen.

                        HttpWebResponse responseCopy = httpWebResponseCtor(
                            new object[]
                            {
                                uriAccessor(response), verbAccessor(response), coreResponseDataAccessor(response), mediaTypeAccessor(response),
                                usesProxySemanticsAccessor(response), DecompressionMethods.None,
                                isWebSocketResponseAccessor(response), connectionGroupNameAccessor(response),
                            });

                        AddResponseTags(responseCopy, activity);
                    }
                    else
                    {
                        AddResponseTags(response, activity);
                    }
                }
            }
            catch (Exception ex)
            {
                HttpInstrumentationEventSource.Log.FailedProcessResult(ex);
            }

            activity.Stop();
        }

        private static void PrepareReflectionObjects()
        {
            // At any point, if the operation failed, it should just throw. The caller should catch all exceptions and swallow.

            Type servicePointType = typeof(ServicePoint);
            Assembly systemNetHttpAssembly = servicePointType.Assembly;
            connectionGroupListField = servicePointType.GetField("m_ConnectionGroupList", BindingFlags.Instance | BindingFlags.NonPublic);
            connectionGroupType = systemNetHttpAssembly?.GetType("System.Net.ConnectionGroup");
            connectionListField = connectionGroupType?.GetField("m_ConnectionList", BindingFlags.Instance | BindingFlags.NonPublic);
            connectionType = systemNetHttpAssembly?.GetType("System.Net.Connection");
            writeListField = connectionType?.GetField("m_WriteList", BindingFlags.Instance | BindingFlags.NonPublic);

            writeAResultAccessor = CreateFieldGetter<IAsyncResult>(typeof(HttpWebRequest), "_WriteAResult", BindingFlags.NonPublic | BindingFlags.Instance);
            readAResultAccessor = CreateFieldGetter<IAsyncResult>(typeof(HttpWebRequest), "_ReadAResult", BindingFlags.NonPublic | BindingFlags.Instance);

            // Double checking to make sure we have all the pieces initialized
            if (connectionGroupListField == null ||
                connectionGroupType == null ||
                connectionListField == null ||
                connectionType == null ||
                writeListField == null ||
                writeAResultAccessor == null ||
                readAResultAccessor == null ||
                !PrepareAsyncResultReflectionObjects(systemNetHttpAssembly) ||
                !PrepareHttpWebResponseReflectionObjects(systemNetHttpAssembly))
            {
                // If anything went wrong here, just return false. There is nothing we can do.
                throw new InvalidOperationException("Unable to initialize all required reflection objects");
            }
        }

        private static bool PrepareAsyncResultReflectionObjects(Assembly systemNetHttpAssembly)
        {
            Type lazyAsyncResultType = systemNetHttpAssembly?.GetType("System.Net.LazyAsyncResult");
            if (lazyAsyncResultType != null)
            {
                asyncCallbackAccessor = CreateFieldGetter<AsyncCallback>(lazyAsyncResultType, "m_AsyncCallback", BindingFlags.NonPublic | BindingFlags.Instance);
                asyncCallbackModifier = CreateFieldSetter<AsyncCallback>(lazyAsyncResultType, "m_AsyncCallback", BindingFlags.NonPublic | BindingFlags.Instance);
                asyncStateAccessor = CreateFieldGetter<object>(lazyAsyncResultType, "m_AsyncState", BindingFlags.NonPublic | BindingFlags.Instance);
                asyncStateModifier = CreateFieldSetter<object>(lazyAsyncResultType, "m_AsyncState", BindingFlags.NonPublic | BindingFlags.Instance);
                endCalledAccessor = CreateFieldGetter<bool>(lazyAsyncResultType, "m_EndCalled", BindingFlags.NonPublic | BindingFlags.Instance);
                resultAccessor = CreateFieldGetter<object>(lazyAsyncResultType, "m_Result", BindingFlags.NonPublic | BindingFlags.Instance);
            }

            Type contextAwareResultType = systemNetHttpAssembly?.GetType("System.Net.ContextAwareResult");
            if (contextAwareResultType != null)
            {
                isContextAwareResultChecker = CreateTypeChecker(contextAwareResultType);
            }

            return asyncCallbackAccessor != null
                && asyncCallbackModifier != null
                && asyncStateAccessor != null
                && asyncStateModifier != null
                && endCalledAccessor != null
                && resultAccessor != null
                && isContextAwareResultChecker != null;
        }

        private static bool PrepareHttpWebResponseReflectionObjects(Assembly systemNetHttpAssembly)
        {
            Type knownHttpVerbType = systemNetHttpAssembly?.GetType("System.Net.KnownHttpVerb");
            Type coreResponseData = systemNetHttpAssembly?.GetType("System.Net.CoreResponseData");

            if (knownHttpVerbType != null && coreResponseData != null)
            {
                var constructorParameterTypes = new Type[]
                {
                    typeof(Uri), knownHttpVerbType, coreResponseData, typeof(string),
                    typeof(bool), typeof(DecompressionMethods),
                    typeof(bool), typeof(string),
                };

                ConstructorInfo ctor = typeof(HttpWebResponse).GetConstructor(
                    BindingFlags.NonPublic | BindingFlags.Instance,
                    null,
                    constructorParameterTypes,
                    null);

                if (ctor != null)
                {
                    httpWebResponseCtor = CreateTypeInstance<HttpWebResponse>(ctor);
                }
            }

            uriAccessor = CreateFieldGetter<HttpWebResponse, Uri>("m_Uri", BindingFlags.NonPublic | BindingFlags.Instance);
            verbAccessor = CreateFieldGetter<HttpWebResponse, object>("m_Verb", BindingFlags.NonPublic | BindingFlags.Instance);
            mediaTypeAccessor = CreateFieldGetter<HttpWebResponse, string>("m_MediaType", BindingFlags.NonPublic | BindingFlags.Instance);
            usesProxySemanticsAccessor = CreateFieldGetter<HttpWebResponse, bool>("m_UsesProxySemantics", BindingFlags.NonPublic | BindingFlags.Instance);
            coreResponseDataAccessor = CreateFieldGetter<HttpWebResponse, object>("m_CoreResponseData", BindingFlags.NonPublic | BindingFlags.Instance);
            isWebSocketResponseAccessor = CreateFieldGetter<HttpWebResponse, bool>("m_IsWebSocketResponse", BindingFlags.NonPublic | BindingFlags.Instance);
            connectionGroupNameAccessor = CreateFieldGetter<HttpWebResponse, string>("m_ConnectionGroupName", BindingFlags.NonPublic | BindingFlags.Instance);

            return httpWebResponseCtor != null
                && uriAccessor != null
                && verbAccessor != null
                && mediaTypeAccessor != null
                && usesProxySemanticsAccessor != null
                && coreResponseDataAccessor != null
                && isWebSocketResponseAccessor != null
                && connectionGroupNameAccessor != null;
        }

        private static void PerformInjection()
        {
            FieldInfo servicePointTableField = typeof(ServicePointManager).GetField("s_ServicePointTable", BindingFlags.Static | BindingFlags.NonPublic);
            if (servicePointTableField == null)
            {
                // If anything went wrong here, just return false. There is nothing we can do.
                throw new InvalidOperationException("Unable to access the ServicePointTable field");
            }

            Hashtable originalTable = servicePointTableField.GetValue(null) as Hashtable;
            ServicePointHashtable newTable = new ServicePointHashtable(originalTable ?? new Hashtable());

            foreach (DictionaryEntry existingServicePoint in originalTable)
            {
                HookServicePoint(existingServicePoint.Value);
            }

            servicePointTableField.SetValue(null, newTable);
        }

        private static void HookServicePoint(object value)
        {
            if (value is WeakReference weakRef
                && weakRef.IsAlive
                && weakRef.Target is ServicePoint servicePoint)
            {
                // Replace the ConnectionGroup hashtable inside this ServicePoint object,
                // which allows us to intercept each new ConnectionGroup object added under
                // this ServicePoint.
                Hashtable originalTable = connectionGroupListField.GetValue(servicePoint) as Hashtable;
                ConnectionGroupHashtable newTable = new ConnectionGroupHashtable(originalTable ?? new Hashtable());

                foreach (DictionaryEntry existingConnectionGroup in originalTable)
                {
                    HookConnectionGroup(existingConnectionGroup.Value);
                }

                connectionGroupListField.SetValue(servicePoint, newTable);
            }
        }

        private static void HookConnectionGroup(object value)
        {
            if (connectionGroupType.IsInstanceOfType(value))
            {
                // Replace the Connection arraylist inside this ConnectionGroup object,
                // which allows us to intercept each new Connection object added under
                // this ConnectionGroup.
                ArrayList originalArrayList = connectionListField.GetValue(value) as ArrayList;
                ConnectionArrayList newArrayList = new ConnectionArrayList(originalArrayList ?? new ArrayList());

                foreach (object connection in originalArrayList)
                {
                    HookConnection(connection);
                }

                connectionListField.SetValue(value, newArrayList);
            }
        }

        private static void HookConnection(object value)
        {
            if (connectionType.IsInstanceOfType(value))
            {
                // Replace the HttpWebRequest arraylist inside this Connection object,
                // which allows us to intercept each new HttpWebRequest object added under
                // this Connection.
                ArrayList originalArrayList = writeListField.GetValue(value) as ArrayList;
                HttpWebRequestArrayList newArrayList = new HttpWebRequestArrayList(originalArrayList ?? new ArrayList());

                writeListField.SetValue(value, newArrayList);
            }
        }

        private static Func<TClass, TField> CreateFieldGetter<TClass, TField>(string fieldName, BindingFlags flags)
            where TClass : class
        {
            FieldInfo field = typeof(TClass).GetField(fieldName, flags);
            if (field != null)
            {
                string methodName = field.ReflectedType.FullName + ".get_" + field.Name;
                DynamicMethod getterMethod = new DynamicMethod(methodName, typeof(TField), new[] { typeof(TClass) }, true);
                ILGenerator generator = getterMethod.GetILGenerator();
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, field);
                generator.Emit(OpCodes.Ret);
                return (Func<TClass, TField>)getterMethod.CreateDelegate(typeof(Func<TClass, TField>));
            }

            return null;
        }

        /// <summary>
        /// Creates getter for a field defined in private or internal type
        /// repesented with classType variable.
        /// </summary>
        private static Func<object, TField> CreateFieldGetter<TField>(Type classType, string fieldName, BindingFlags flags)
        {
            FieldInfo field = classType.GetField(fieldName, flags);
            if (field != null)
            {
                string methodName = classType.FullName + ".get_" + field.Name;
                DynamicMethod getterMethod = new DynamicMethod(methodName, typeof(TField), new[] { typeof(object) }, true);
                ILGenerator generator = getterMethod.GetILGenerator();
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Castclass, classType);
                generator.Emit(OpCodes.Ldfld, field);
                generator.Emit(OpCodes.Ret);

                return (Func<object, TField>)getterMethod.CreateDelegate(typeof(Func<object, TField>));
            }

            return null;
        }

        /// <summary>
        /// Creates setter for a field defined in private or internal type
        /// repesented with classType variable.
        /// </summary>
        private static Action<object, TField> CreateFieldSetter<TField>(Type classType, string fieldName, BindingFlags flags)
        {
            FieldInfo field = classType.GetField(fieldName, flags);
            if (field != null)
            {
                string methodName = classType.FullName + ".set_" + field.Name;
                DynamicMethod setterMethod = new DynamicMethod(methodName, null, new[] { typeof(object), typeof(TField) }, true);
                ILGenerator generator = setterMethod.GetILGenerator();
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Castclass, classType);
                generator.Emit(OpCodes.Ldarg_1);
                generator.Emit(OpCodes.Stfld, field);
                generator.Emit(OpCodes.Ret);

                return (Action<object, TField>)setterMethod.CreateDelegate(typeof(Action<object, TField>));
            }

            return null;
        }

        /// <summary>
        /// Creates an "is" method for the private or internal type.
        /// </summary>
        private static Func<object, bool> CreateTypeChecker(Type classType)
        {
            string methodName = classType.FullName + ".typeCheck";
            DynamicMethod setterMethod = new DynamicMethod(methodName, typeof(bool), new[] { typeof(object) }, true);
            ILGenerator generator = setterMethod.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Isinst, classType);
            generator.Emit(OpCodes.Ldnull);
            generator.Emit(OpCodes.Cgt_Un);
            generator.Emit(OpCodes.Ret);

            return (Func<object, bool>)setterMethod.CreateDelegate(typeof(Func<object, bool>));
        }

        /// <summary>
        /// Creates an instance of T using a private or internal ctor.
        /// </summary>
        private static Func<object[], T> CreateTypeInstance<T>(ConstructorInfo constructorInfo)
        {
            Type classType = typeof(T);
            string methodName = classType.FullName + ".ctor";
            DynamicMethod setterMethod = new DynamicMethod(methodName, classType, new Type[] { typeof(object[]) }, true);
            ILGenerator generator = setterMethod.GetILGenerator();

            ParameterInfo[] ctorParams = constructorInfo.GetParameters();
            for (int i = 0; i < ctorParams.Length; i++)
            {
                generator.Emit(OpCodes.Ldarg_0);
                switch (i)
                {
                    case 0: generator.Emit(OpCodes.Ldc_I4_0); break;
                    case 1: generator.Emit(OpCodes.Ldc_I4_1); break;
                    case 2: generator.Emit(OpCodes.Ldc_I4_2); break;
                    case 3: generator.Emit(OpCodes.Ldc_I4_3); break;
                    case 4: generator.Emit(OpCodes.Ldc_I4_4); break;
                    case 5: generator.Emit(OpCodes.Ldc_I4_5); break;
                    case 6: generator.Emit(OpCodes.Ldc_I4_6); break;
                    case 7: generator.Emit(OpCodes.Ldc_I4_7); break;
                    case 8: generator.Emit(OpCodes.Ldc_I4_8); break;
                    default: generator.Emit(OpCodes.Ldc_I4, i); break;
                }

                generator.Emit(OpCodes.Ldelem_Ref);
                Type paramType = ctorParams[i].ParameterType;
                generator.Emit(paramType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, paramType);
            }

            generator.Emit(OpCodes.Newobj, constructorInfo);
            generator.Emit(OpCodes.Ret);

            return (Func<object[], T>)setterMethod.CreateDelegate(typeof(Func<object[], T>));
        }

        private class HashtableWrapper : Hashtable, IEnumerable
        {
            private readonly Hashtable table;

            internal HashtableWrapper(Hashtable table)
                : base()
            {
                this.table = table;
            }

            public override int Count => this.table.Count;

            public override bool IsReadOnly => this.table.IsReadOnly;

            public override bool IsFixedSize => this.table.IsFixedSize;

            public override bool IsSynchronized => this.table.IsSynchronized;

            public override object SyncRoot => this.table.SyncRoot;

            public override ICollection Keys => this.table.Keys;

            public override ICollection Values => this.table.Values;

            public override object this[object key]
            {
                get => this.table[key];
                set => this.table[key] = value;
            }

            public override void Add(object key, object value)
            {
                this.table.Add(key, value);
            }

            public override void Clear()
            {
                this.table.Clear();
            }

            public override bool Contains(object key)
            {
                return this.table.Contains(key);
            }

            public override bool ContainsKey(object key)
            {
                return this.table.ContainsKey(key);
            }

            public override bool ContainsValue(object key)
            {
                return this.table.ContainsValue(key);
            }

            public override void CopyTo(Array array, int arrayIndex)
            {
                this.table.CopyTo(array, arrayIndex);
            }

            public override object Clone()
            {
                return new HashtableWrapper((Hashtable)this.table.Clone());
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.table.GetEnumerator();
            }

            public override IDictionaryEnumerator GetEnumerator()
            {
                return this.table.GetEnumerator();
            }

            public override void Remove(object key)
            {
                this.table.Remove(key);
            }
        }

        /// <summary>
        /// Helper class used for ServicePointManager.s_ServicePointTable. The goal here is to
        /// intercept each new ServicePoint object being added to ServicePointManager.s_ServicePointTable
        /// and replace its ConnectionGroupList hashtable field.
        /// </summary>
        private sealed class ServicePointHashtable : HashtableWrapper
        {
            public ServicePointHashtable(Hashtable table)
                : base(table)
            {
            }

            public override object this[object key]
            {
                get => base[key];
                set
                {
                    HookServicePoint(value);
                    base[key] = value;
                }
            }
        }

        /// <summary>
        /// Helper class used for ServicePoint.m_ConnectionGroupList. The goal here is to
        /// intercept each new ConnectionGroup object being added to ServicePoint.m_ConnectionGroupList
        /// and replace its m_ConnectionList arraylist field.
        /// </summary>
        private sealed class ConnectionGroupHashtable : HashtableWrapper
        {
            public ConnectionGroupHashtable(Hashtable table)
                : base(table)
            {
            }

            public override object this[object key]
            {
                get => base[key];
                set
                {
                    HookConnectionGroup(value);
                    base[key] = value;
                }
            }
        }

        /// <summary>
        /// Helper class used to wrap the array list object. This class itself doesn't actually
        /// have the array elements, but rather access another array list that's given at
        /// construction time.
        /// </summary>
        private class ArrayListWrapper : ArrayList
        {
            private ArrayList list;

            internal ArrayListWrapper(ArrayList list)
                : base()
            {
                this.list = list;
            }

            public override int Capacity
            {
                get => this.list.Capacity;
                set => this.list.Capacity = value;
            }

            public override int Count => this.list.Count;

            public override bool IsReadOnly => this.list.IsReadOnly;

            public override bool IsFixedSize => this.list.IsFixedSize;

            public override bool IsSynchronized => this.list.IsSynchronized;

            public override object SyncRoot => this.list.SyncRoot;

            public override object this[int index]
            {
                get => this.list[index];
                set => this.list[index] = value;
            }

            public override int Add(object value)
            {
                return this.list.Add(value);
            }

            public override void AddRange(ICollection c)
            {
                this.list.AddRange(c);
            }

            public override int BinarySearch(object value)
            {
                return this.list.BinarySearch(value);
            }

            public override int BinarySearch(object value, IComparer comparer)
            {
                return this.list.BinarySearch(value, comparer);
            }

            public override int BinarySearch(int index, int count, object value, IComparer comparer)
            {
                return this.list.BinarySearch(index, count, value, comparer);
            }

            public override void Clear()
            {
                this.list.Clear();
            }

            public override object Clone()
            {
                return new ArrayListWrapper((ArrayList)this.list.Clone());
            }

            public override bool Contains(object item)
            {
                return this.list.Contains(item);
            }

            public override void CopyTo(Array array)
            {
                this.list.CopyTo(array);
            }

            public override void CopyTo(Array array, int index)
            {
                this.list.CopyTo(array, index);
            }

            public override void CopyTo(int index, Array array, int arrayIndex, int count)
            {
                this.list.CopyTo(index, array, arrayIndex, count);
            }

            public override IEnumerator GetEnumerator()
            {
                return this.list.GetEnumerator();
            }

            public override IEnumerator GetEnumerator(int index, int count)
            {
                return this.list.GetEnumerator(index, count);
            }

            public override int IndexOf(object value)
            {
                return this.list.IndexOf(value);
            }

            public override int IndexOf(object value, int startIndex)
            {
                return this.list.IndexOf(value, startIndex);
            }

            public override int IndexOf(object value, int startIndex, int count)
            {
                return this.list.IndexOf(value, startIndex, count);
            }

            public override void Insert(int index, object value)
            {
                this.list.Insert(index, value);
            }

            public override void InsertRange(int index, ICollection c)
            {
                this.list.InsertRange(index, c);
            }

            public override int LastIndexOf(object value)
            {
                return this.list.LastIndexOf(value);
            }

            public override int LastIndexOf(object value, int startIndex)
            {
                return this.list.LastIndexOf(value, startIndex);
            }

            public override int LastIndexOf(object value, int startIndex, int count)
            {
                return this.list.LastIndexOf(value, startIndex, count);
            }

            public override void Remove(object value)
            {
                this.list.Remove(value);
            }

            public override void RemoveAt(int index)
            {
                this.list.RemoveAt(index);
            }

            public override void RemoveRange(int index, int count)
            {
                this.list.RemoveRange(index, count);
            }

            public override void Reverse(int index, int count)
            {
                this.list.Reverse(index, count);
            }

            public override void SetRange(int index, ICollection c)
            {
                this.list.SetRange(index, c);
            }

            public override ArrayList GetRange(int index, int count)
            {
                return this.list.GetRange(index, count);
            }

            public override void Sort()
            {
                this.list.Sort();
            }

            public override void Sort(IComparer comparer)
            {
                this.list.Sort(comparer);
            }

            public override void Sort(int index, int count, IComparer comparer)
            {
                this.list.Sort(index, count, comparer);
            }

            public override object[] ToArray()
            {
                return this.list.ToArray();
            }

            public override Array ToArray(Type type)
            {
                return this.list.ToArray(type);
            }

            public override void TrimToSize()
            {
                this.list.TrimToSize();
            }

            public ArrayList Swap()
            {
                ArrayList old = this.list;
                this.list = new ArrayList(old.Capacity);
                return old;
            }
        }

        /// <summary>
        /// Helper class used for ConnectionGroup.m_ConnectionList. The goal here is to
        /// intercept each new Connection object being added to ConnectionGroup.m_ConnectionList
        /// and replace its m_WriteList arraylist field.
        /// </summary>
        private sealed class ConnectionArrayList : ArrayListWrapper
        {
            public ConnectionArrayList(ArrayList list)
                : base(list)
            {
            }

            public override int Add(object value)
            {
                HookConnection(value);
                return base.Add(value);
            }
        }

        /// <summary>
        /// Helper class used for Connection.m_WriteList. The goal here is to
        /// intercept all new HttpWebRequest objects being added to Connection.m_WriteList
        /// and notify the listener about the HttpWebRequest that's about to send a request.
        /// It also intercepts all HttpWebRequest objects that are about to get removed from
        /// Connection.m_WriteList as they have completed the request.
        /// </summary>
        private sealed class HttpWebRequestArrayList : ArrayListWrapper
        {
            public HttpWebRequestArrayList(ArrayList list)
                : base(list)
            {
            }

            public override int Add(object value)
            {
                // Add before firing events so if some user code cancels/aborts the request it will be found in the outstanding list.
                int index = base.Add(value);

                if (value is HttpWebRequest request)
                {
                    ProcessRequest(request);
                }

                return index;
            }

            public override void RemoveAt(int index)
            {
                object request = this[index];

                base.RemoveAt(index);

                if (request is HttpWebRequest webRequest)
                {
                    HookOrProcessResult(webRequest);
                }
            }

            public override void Clear()
            {
                ArrayList oldList = this.Swap();
                for (int i = 0; i < oldList.Count; i++)
                {
                    if (oldList[i] is HttpWebRequest request)
                    {
                        HookOrProcessResult(request);
                    }
                }
            }
        }

        /// <summary>
        /// A closure object so our state is available when our callback executes.
        /// </summary>
        private sealed class AsyncCallbackWrapper
        {
            public AsyncCallbackWrapper(HttpWebRequest request, Activity activity, AsyncCallback originalCallback)
            {
                this.Request = request;
                this.Activity = activity;
                this.OriginalCallback = originalCallback;
            }

            public HttpWebRequest Request { get; }

            public Activity Activity { get; }

            public AsyncCallback OriginalCallback { get; }

            public void AsyncCallback(IAsyncResult asyncResult)
            {
                object result = resultAccessor(asyncResult);
                if (result is Exception || result is HttpWebResponse)
                {
                    ProcessResult(asyncResult, this.OriginalCallback, this.Activity, result, false);
                }

                this.OriginalCallback?.Invoke(asyncResult);
            }
        }
    }
}
#endif
