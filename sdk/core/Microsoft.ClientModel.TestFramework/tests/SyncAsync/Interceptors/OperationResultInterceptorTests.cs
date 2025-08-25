// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Castle.DynamicProxy;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync.Interceptors;

[TestFixture]
public class OperationResultInterceptorTests
{
    #region Constructor

    [Test]
    public void ConstructorSetsMode()
    {
        var interceptor = new OperationResultInterceptor(RecordedTestMode.Playback);

        Assert.That(interceptor, Is.Not.Null);
    }

    [TestCase(RecordedTestMode.Live)]
    [TestCase(RecordedTestMode.Record)]
    [TestCase(RecordedTestMode.Playback)]
    public void ConstructorAcceptsAllModes(RecordedTestMode mode)
    {
        var interceptor = new OperationResultInterceptor(mode);

        Assert.That(interceptor, Is.Not.Null);
    }

    #endregion

    #region Intercept Method

    [Test]
    public void InterceptProceedsForNonPlaybackMode()
    {
        var interceptor = new OperationResultInterceptor(RecordedTestMode.Live);
        var invocation = CreateMockInvocation("WaitForCompletionAsync");

        interceptor.Intercept(invocation);

        Assert.That(invocation.Proceeded, Is.True);
    }

    [Test]
    public void InterceptProceedsForRecordMode()
    {
        var interceptor = new OperationResultInterceptor(RecordedTestMode.Record);
        var invocation = CreateMockInvocation("WaitForCompletionAsync");

        interceptor.Intercept(invocation);

        Assert.That(invocation.Proceeded, Is.True);
    }

    [Test]
    public void InterceptHandlesWaitForCompletionAsyncInPlaybackMode()
    {
        var interceptor = new OperationResultInterceptor(RecordedTestMode.Playback);
        var operation = new MockOperationResult(new MockPipelineResponse(200));
        operation.SetCompletesAfterUpdates(1); // Complete after 1 update to avoid infinite loop
        var invocation = CreateMockInvocationForWaitForCompletion(operation, CancellationToken.None);

        interceptor.Intercept(invocation);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(invocation.ReturnValue, Is.Not.Null);
            Assert.That(invocation.Proceeded, Is.False);
        }
    }

    [Test]
    public void InterceptProceedsForOtherMethodsInPlaybackMode()
    {
        var interceptor = new OperationResultInterceptor(RecordedTestMode.Playback);
        var invocation = CreateMockInvocation("SomeOtherMethod");

        interceptor.Intercept(invocation);

        Assert.That(invocation.Proceeded, Is.True);
    }

    [Test]
    public void InterceptHandlesNullMethodName()
    {
        var interceptor = new OperationResultInterceptor(RecordedTestMode.Playback);
        var invocation = CreateMockInvocation(null);

        interceptor.Intercept(invocation);

        Assert.That(invocation.Proceeded, Is.True);
    }

    #endregion

    #region InvokeWaitForCompletionAsync Method

    [Test]
    public async Task InvokeWaitForCompletionAsyncHandlesNullOperation()
    {
        await OperationResultInterceptor.InvokeWaitForCompletionAsync(null, CancellationToken.None);

        // Should complete without throwing
        Assert.Pass();
    }

    [Test]
    public async Task InvokeWaitForCompletionAsyncPollsUntilComplete()
    {
        var operation = new MockOperationResult(new MockPipelineResponse(200));
        operation.SetCompletesAfterUpdates(3); // Complete after 3 updates

        await OperationResultInterceptor.InvokeWaitForCompletionAsync(operation, CancellationToken.None);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(operation.UpdateStatusCallCount, Is.EqualTo(3));
            Assert.That(operation.HasCompleted, Is.True);
        }
    }

    [Test]
    public async Task InvokeWaitForCompletionAsyncRespectsCompletedOperation()
    {
        var operation = new MockOperationResult(new MockPipelineResponse(200));
        operation.SetCompleted(true);

        await OperationResultInterceptor.InvokeWaitForCompletionAsync(operation, CancellationToken.None);

        Assert.That(operation.UpdateStatusCallCount, Is.EqualTo(0));
    }

    [Test]
    public void InvokeWaitForCompletionAsyncRespectsCancellation()
    {
        var operation = new MockOperationResult(new MockPipelineResponse(200));
        operation.SetCompletesAfterUpdates(10); // Set to complete after many updates so cancellation can happen first
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        Assert.ThrowsAsync<OperationCanceledException>(
            () => OperationResultInterceptor.InvokeWaitForCompletionAsync(operation, cts.Token).AsTask());
    }

    [Test]
    public async Task InvokeWaitForCompletionAsyncHandlesNullCancellationToken()
    {
        var operation = new MockOperationResult(new MockPipelineResponse(200));
        operation.SetCompleted(true);

        await OperationResultInterceptor.InvokeWaitForCompletionAsync(operation, null);

        // Should complete without throwing
        Assert.Pass();
    }

    #endregion

    #region Helper Classes and Methods

    private MockInvocation CreateMockInvocation(string methodName)
    {
        return new MockInvocation(methodName, typeof(OperationResult), Array.Empty<object>());
    }

    private MockInvocation CreateMockInvocationForWaitForCompletion(OperationResult operation, CancellationToken token)
    {
        return new MockInvocation("WaitForCompletionAsync", typeof(OperationResult), new object[] { token })
        {
            InvocationTargetValue = operation
        };
    }

    private class MockInvocation : IInvocation
    {
        private readonly string _methodName;
        private readonly Type _targetType;

        public MockInvocation(string methodName, Type targetType, object[] arguments)
        {
            _methodName = methodName;
            _targetType = targetType;
            Arguments = arguments;
        }

        public object[] Arguments { get; set; }
        public Type[] GenericArguments => Array.Empty<Type>();
        public object InvocationTargetValue { get; set; }
        public object InvocationTarget => InvocationTargetValue;
        public System.Reflection.MethodInfo Method => new MockMethodInfo(_methodName);
        public System.Reflection.MethodInfo MethodInvocationTarget => Method;
        public object Proxy => throw new NotImplementedException();
        public object ReturnValue { get; set; }
        public Type TargetType => _targetType;
        public bool Proceeded { get; private set; }

        public IInvocation GetConcreteMethod() => throw new NotImplementedException();
        public IInvocationProceedInfo GetConcreteMethodInvocationTarget() => throw new NotImplementedException();

        public void Proceed()
        {
            Proceeded = true;
        }

        public void SetArgumentValue(int index, object value) => throw new NotImplementedException();

        IInvocationProceedInfo IInvocation.CaptureProceedInfo()
        {
            throw new NotImplementedException();
        }

        object IInvocation.GetArgumentValue(int index)
        {
            throw new NotImplementedException();
        }

        MethodInfo IInvocation.GetConcreteMethod()
        {
            throw new NotImplementedException();
        }

        MethodInfo IInvocation.GetConcreteMethodInvocationTarget()
        {
            throw new NotImplementedException();
        }
    }

    private class MockMethodInfo : System.Reflection.MethodInfo
    {
        private readonly string _name;

        public MockMethodInfo(string name)
        {
            _name = name;
        }

        public override string Name => _name;
        public override Type DeclaringType => typeof(OperationResult);
        public override Type ReflectedType => typeof(OperationResult);
        public override System.Reflection.MethodAttributes Attributes => throw new NotImplementedException();
        public override RuntimeMethodHandle MethodHandle => throw new NotImplementedException();

        public override System.Reflection.MethodInfo GetBaseDefinition() => throw new NotImplementedException();
        public override object[] GetCustomAttributes(bool inherit) => throw new NotImplementedException();
        public override object[] GetCustomAttributes(Type attributeType, bool inherit) => throw new NotImplementedException();
        public override System.Reflection.MethodImplAttributes GetMethodImplementationFlags() => throw new NotImplementedException();
        public override System.Reflection.ParameterInfo[] GetParameters() => Array.Empty<System.Reflection.ParameterInfo>();
        public override object Invoke(object obj, System.Reflection.BindingFlags invokeAttr, System.Reflection.Binder binder, object[] parameters, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
        public override bool IsDefined(Type attributeType, bool inherit) => throw new NotImplementedException();
        public override System.Reflection.ParameterInfo ReturnParameter => throw new NotImplementedException();
        public override Type ReturnType => typeof(ValueTask);

        public override ICustomAttributeProvider ReturnTypeCustomAttributes => throw new NotImplementedException();
    }

    private class MockOperationResult : OperationResult
    {
        private bool _shouldCompleteOnUpdate;
        private int _updatesUntilComplete = 1;

        public MockOperationResult(PipelineResponse response) : base(response)
        {
            HasCompleted = false; // Start as not completed
        }

        public int UpdateStatusCallCount { get; private set; }

        public override ContinuationToken RehydrationToken { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

        public void SetCompleted(bool completed)
        {
            HasCompleted = completed;
            _shouldCompleteOnUpdate = false; // Don't auto-complete on update if explicitly set
        }

        public void SetCompletesAfterUpdates(int updates)
        {
            _updatesUntilComplete = updates;
            _shouldCompleteOnUpdate = true;
            HasCompleted = false;
        }

        public override ClientResult UpdateStatus(System.ClientModel.Primitives.RequestOptions options = null)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<ClientResult> UpdateStatusAsync(System.ClientModel.Primitives.RequestOptions options = null)
        {
            UpdateStatusCallCount++;
            options?.CancellationToken.ThrowIfCancellationRequested();

            // Simulate completing after a certain number of updates
            if (_shouldCompleteOnUpdate && UpdateStatusCallCount >= _updatesUntilComplete)
            {
                HasCompleted = true;
            }

            return new ValueTask<ClientResult>(ClientResult.FromOptionalValue<object>(null, new MockPipelineResponse(200)));
        }
    }

    #endregion
}
