// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Moq;
using Moq.Language.Flow;

namespace Azure.ResourceManager.Moq
{
    internal class AzureNonVoidAdapter<T, R> : ISetup<T, R> where T : class
    {
        private readonly object _intermediateSetup; // runtime type: ISetup<TExtensionClient, R>

        public AzureNonVoidAdapter(object intermediateSetup)
        {
            _intermediateSetup = intermediateSetup;
        }

        public IReturnsThrows<T, R> Callback(InvocationAction action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(InvocationAction) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback(Delegate callback)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Delegate) }, new object[] { callback });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback(Action action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1>(Action<T1> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2>(Action<T1, T2> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsThrows<T, R> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>) }, new object[] { action });
            return new AzureNonVoidAdapter<T, R>(result);
        }

        public IReturnsResult<T> CallBase()
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, Array.Empty<Type>(), Array.Empty<object>());
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns(R value)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(R) }, new object[] { value });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns(InvocationFunc valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(InvocationFunc) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns(Delegate valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Delegate) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns(Func<R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1>(Func<T1, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2>(Func<T1, T2, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3>(Func<T1, T2, T3, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3, T4>(Func<T1, T2, T3, T4, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R> valueFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>) }, new object[] { valueFunction });
            return new AzureVoidAdapter<T>(result);
        }

        public IThrowsResult Throws(Exception exception)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Exception) }, new object[] { exception });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<TException>() where TException : Exception, new()
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, Array.Empty<Type>(), Array.Empty<object>());
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws(Delegate exceptionFunction)
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Delegate) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<TException>(Func<TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, TException>(Func<T1, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, TException>(Func<T1, T2, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, TException>(Func<T1, T2, T3, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, T4, TException>(Func<T1, T2, T3, T4, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, TException>(Func<T1, T2, T3, T4, T5, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, TException>(Func<T1, T2, T3, T4, T5, T6, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, TException>(Func<T1, T2, T3, T4, T5, T6, T7, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public IThrowsResult Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TException> exceptionFunction) where TException : Exception
        {
            var result = MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TException>) }, new object[] { exceptionFunction });
            return (IThrowsResult)result;
        }

        public void Verifiable()
        {
            MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, Array.Empty<Type>(), Array.Empty<object>());
        }

        public void Verifiable(string failMessage)
        {
            MockingExtensions.RedirectMethodInvocation(_intermediateSetup, MethodBase.GetCurrentMethod().Name, new[] { typeof(string) }, new object[] { failMessage });
        }
    }
}