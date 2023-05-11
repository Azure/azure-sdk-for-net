// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using Moq;
using Moq.Language;
using Moq.Language.Flow;

namespace Azure.ResourceManager.Resources.Testing
{
    internal class AzureSetupAdapter<T, R> : ISetup<T, R> where T : ArmResource
    {
        private readonly object _intermediateSetup; // runtime type: ISetup<intermediateType, R>
        private readonly Type _intermediateType;

        public AzureSetupAdapter(object intermediateSetup, Type intermediateType)
        {
            _intermediateSetup = intermediateSetup;
            _intermediateType = intermediateType;
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback(InvocationAction action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback(Delegate callback)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback(Action action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1>(Action<T1> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2>(Action<T1, T2> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
        {
            throw new NotImplementedException();
        }

        IReturnsThrows<T, R> ICallback<T, R>.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.CallBase()
        {
            throw new NotImplementedException();
        }

        bool IFluentInterface.Equals(object obj)
        {
            throw new NotImplementedException();
        }

        int IFluentInterface.GetHashCode()
        {
            throw new NotImplementedException();
        }

        Type IFluentInterface.GetType()
        {
            throw new NotImplementedException();
        }

        private object RedirectMethodInvocation(MethodBase currentMethod, object[] arguments)
        {
            // find the exact same method with same name and same parameter list, then call it
            var methodName = currentMethod.Name.Split('.').Last();
            var parameterTypes = currentMethod.GetParameters().Select(p => p.ParameterType).ToArray();
            var method = _intermediateSetup.GetType().GetMethod(methodName, parameterTypes);
            return method.Invoke(_intermediateSetup, arguments);
        }

        IReturnsResult<T> IReturns<T, R>.Returns(R value)
        {
            var result = RedirectMethodInvocation(MethodBase.GetCurrentMethod(), new object[] { value });
            return new AzureReturns<T>(result, _intermediateType);
        }

        IReturnsResult<T> IReturns<T, R>.Returns(InvocationFunc valueFunction)
        {
            var result = RedirectMethodInvocation(MethodBase.GetCurrentMethod(), new object[] { valueFunction });
            return new AzureReturns<T>(result, _intermediateType);
        }

        IReturnsResult<T> IReturns<T, R>.Returns(Delegate valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns(Func<R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1>(Func<T1, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2>(Func<T1, T2, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3>(Func<T1, T2, T3, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3, T4>(Func<T1, T2, T3, T4, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IReturnsResult<T> IReturns<T, R>.Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R> valueFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws(Exception exception)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<TException>()
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws(Delegate exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<TException>(Func<TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, TException>(Func<T1, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, TException>(Func<T1, T2, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, TException>(Func<T1, T2, T3, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, T4, TException>(Func<T1, T2, T3, T4, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, T4, T5, TException>(Func<T1, T2, T3, T4, T5, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, T4, T5, T6, TException>(Func<T1, T2, T3, T4, T5, T6, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, T4, T5, T6, T7, TException>(Func<T1, T2, T3, T4, T5, T6, T7, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, T4, T5, T6, T7, T8, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        IThrowsResult IThrows.Throws<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TException>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TException> exceptionFunction)
        {
            throw new NotImplementedException();
        }

        string IFluentInterface.ToString()
        {
            throw new NotImplementedException();
        }

        void IVerifies.Verifiable()
        {
            throw new NotImplementedException();
        }

        void IVerifies.Verifiable(string failMessage)
        {
            throw new NotImplementedException();
        }
    }
}
