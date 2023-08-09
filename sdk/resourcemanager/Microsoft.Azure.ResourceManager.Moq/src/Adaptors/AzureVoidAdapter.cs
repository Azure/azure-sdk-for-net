// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Moq;
using Moq.Language;
using Moq.Language.Flow;

namespace Azure.ResourceManager.Moq
{
    internal class AzureVoidAdapter<T> : IReturnsResult<T>, ISetup<T> where T : class
    {
        private readonly object _intermediateReturns; // runtime type: IReturnsResult<TExtensionClient>

        public AzureVoidAdapter(object intermediateReturns)
        {
            _intermediateReturns = intermediateReturns;
        }

        public IVerifies AtMost(int callCount)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(int) }, new object[] { callCount });
            // this method is calling the method with same signature on _intermediateReturns, therefore the return value should be of type `IVerifies`, casting here is safe.
            return (IVerifies)result;
        }

        public IVerifies AtMostOnce()
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new Type[] { }, new object[] { });
            return (IVerifies)result;
        }

        public ICallbackResult Callback(InvocationAction action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(InvocationAction) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback(Delegate callback)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Delegate) }, new object[] { callback });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback(Action action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1>(Action<T1> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2>(Action<T1, T2> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>) }, new object[] { action });
            return (ICallbackResult)result;
        }

        public ICallBaseResult CallBase()
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, Array.Empty<Type>(), Array.Empty<object>());
            return (ICallBaseResult)result;
        }

        public IVerifies Raises(Action<T> eventExpression, EventArgs args)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(EventArgs) }, new object[] { eventExpression, args });
            return (IVerifies)result;
        }

        public IVerifies Raises(Action<T> eventExpression, Func<EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises(Action<T> eventExpression, params object[] args)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(object[]) }, new object[] { eventExpression, args });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1>(Action<T> eventExpression, Func<T1, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2>(Action<T> eventExpression, Func<T1, T2, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3>(Action<T> eventExpression, Func<T1, T2, T3, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3, T4>(Action<T> eventExpression, Func<T1, T2, T3, T4, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, T4, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3, T4, T5>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, T4, T5, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, T4, T5, T6, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, T4, T5, T6, T7, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, EventArgs> func)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T>), typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, EventArgs>) }, new object[] { eventExpression, func });
            return (IVerifies)result;
        }

        public IThrowsResult Throws(Exception exception)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Exception) }, new object[] { exception });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<TException>() where TException : Exception, new()
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, Array.Empty<Type>(), Array.Empty<object>());
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws(Delegate exceptionFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(Delegate) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        // these methods may have issues because these are generic methods.
        public IThrowsResult Throws<TException>(Func<TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, TException>(Func<T1, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, TException>(Func<T1, T2, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, TException>(Func<T1, T2, T3, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, T4, TException>(Func<T1, T2, T3, T4, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, TException>(Func<T1, T2, T3, T4, T5, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, TException>(Func<T1, T2, T3, T4, T5, T6, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, TException>(Func<T1, T2, T3, T4, T5, T6, T7, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TException> exceptionFunction) where TException : Exception
        {
            return Throws((Delegate)exceptionFunction);
        }

        public void Verifiable()
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, Array.Empty<Type>(), Array.Empty<object>());
            ((IVerifies)result).Verifiable();
        }

        public void Verifiable(string failMessage)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateReturns, MethodBase.GetCurrentMethod().Name, new[] { typeof(string) }, new object[] { failMessage });
            ((IVerifies)result).Verifiable();
        }
    }
}