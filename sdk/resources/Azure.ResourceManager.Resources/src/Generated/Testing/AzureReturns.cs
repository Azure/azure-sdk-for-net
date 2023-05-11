// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Moq;
using Moq.Language;
using Moq.Language.Flow;

namespace Azure.ResourceManager.Resources.Testing
{
    internal class AzureReturns<T> : IReturnsResult<T> where T : ArmResource
    {
        private readonly object _intermediateReturns; // runtime type: IReturnsResult<intermediateType>
        private readonly Type _intermediateType;

        public AzureReturns(object intermediateReturns, Type intermediateType)
        {
            _intermediateReturns = intermediateReturns;
            _intermediateType = intermediateType;
        }

        IVerifies IOccurrence.AtMost(int callCount)
        {
            throw new NotImplementedException();
        }

        IVerifies IOccurrence.AtMostOnce()
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback(InvocationAction action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback(Delegate callback)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback(Action action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1>(Action<T1> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2>(Action<T1, T2> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
        {
            throw new NotImplementedException();
        }

        ICallbackResult ICallback.Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
        {
            throw new NotImplementedException();
        }

        bool IFluentInterface.Equals(object obj)
        {
            return base.Equals(obj);
        }

        int IFluentInterface.GetHashCode()
        {
            return base.GetHashCode();
        }

        Type IFluentInterface.GetType()
        {
            return base.GetType();
        }

        IVerifies IRaise<T>.Raises(Action<T> eventExpression, EventArgs args)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises(Action<T> eventExpression, Func<EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises(Action<T> eventExpression, params object[] args)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1>(Action<T> eventExpression, Func<T1, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2>(Action<T> eventExpression, Func<T1, T2, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3>(Action<T> eventExpression, Func<T1, T2, T3, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3, T4>(Action<T> eventExpression, Func<T1, T2, T3, T4, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3, T4, T5>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3, T4, T5, T6>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3, T4, T5, T6, T7>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        IVerifies IRaise<T>.Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, EventArgs> func)
        {
            throw new NotImplementedException();
        }

        string IFluentInterface.ToString()
        {
            return base.ToString();
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
