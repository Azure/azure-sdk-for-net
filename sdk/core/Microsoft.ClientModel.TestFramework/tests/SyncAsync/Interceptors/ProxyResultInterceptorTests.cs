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
public class ProxyResultInterceptorTests
{
    #region Constructor

    [Test]
    public void ConstructorWithClientTestBase()
    {
        var testBase = new TestClientTestBase(true);
        var interceptor = new ProxyResultInterceptor(testBase);

        Assert.That(interceptor, Is.Not.Null);
    }

    [Test]
    public void ConstructorWithRecordedTestBase()
    {
        var recordedTestBase = new TestRecordedTestBase(RecordedTestMode.Playback);
        var interceptor = new ProxyResultInterceptor(recordedTestBase);

        Assert.That(interceptor, Is.Not.Null);
    }

    #endregion

    #region Intercept Method - Client Types

    [Test]
    public void InterceptHandlesClientReturnType()
    {
        var testBase = new TestClientTestBase(true);
        var interceptor = new ProxyResultInterceptor(testBase);
        var client = new TestClient();
        var invocation = CreateMockInvocation("GetClient", typeof(TestClient), client);

        interceptor.Intercept(invocation);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.CreateProxyFromClientCalled, Is.True);
            Assert.That(invocation.ReturnValue, Is.Not.Null);
        }
    }

    [Test]
    public void InterceptIgnoresRestClient()
    {
        var testBase = new TestClientTestBase(true);
        var interceptor = new ProxyResultInterceptor(testBase);
        var client = new TestRestClient();
        var invocation = CreateMockInvocation("GetRestClient", typeof(TestRestClient), client);

        interceptor.Intercept(invocation);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(invocation.Proceeded, Is.True);
            Assert.That(testBase.CreateProxyFromClientCalled, Is.False);
        }
    }

    [Test]
    public void InterceptIgnoresExtensionClient()
    {
        var testBase = new TestClientTestBase(true);
        var interceptor = new ProxyResultInterceptor(testBase);
        var client = new TestExtensionClient();
        var invocation = CreateMockInvocation("GetExtensionClient", typeof(TestExtensionClient), client);

        interceptor.Intercept(invocation);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(invocation.Proceeded, Is.True);
            Assert.That(testBase.CreateProxyFromClientCalled, Is.False);
        }
    }

    [Test]
    public void InterceptHandlesNullClientResult()
    {
        var testBase = new TestClientTestBase(true);
        var interceptor = new ProxyResultInterceptor(testBase);
        var invocation = CreateMockInvocation("GetClient", typeof(TestClient), null);
        invocation.ShouldReturnNull = true;

        interceptor.Intercept(invocation);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(invocation.Proceeded, Is.True);
            Assert.That(testBase.CreateProxyFromClientCalled, Is.False);
        }
    }

    #endregion

    #region Intercept Method - Other Types

    [Test]
    public void InterceptProceedsForNonClientTypes()
    {
        var testBase = new TestClientTestBase(true);
        var interceptor = new ProxyResultInterceptor(testBase);
        var invocation = CreateMockInvocation("GetString", typeof(string), "test");

        interceptor.Intercept(invocation);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(invocation.Proceeded, Is.True);
            Assert.That(testBase.CreateProxyFromClientCalled, Is.False);
        }
    }

    #endregion

    #region Helper Classes and Methods

    private MockInvocation CreateMockInvocation(string methodName, Type returnType, object returnValue)
    {
        return new MockInvocation(methodName, returnType, returnValue);
    }

    public class TestClient { }
    public class TestRestClient { }
    public class TestExtensionClient { }

    public class TestOperationResult : OperationResult
    {
        public TestOperationResult() : this(new MockPipelineResponse(200)) { }

        public TestOperationResult(PipelineResponse response) : base(response)
        {
            HasCompleted = true; // Use the protected setter to mark as completed to avoid infinite loops
        }

        public override ContinuationToken RehydrationToken { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

        public override ClientResult UpdateStatus(System.ClientModel.Primitives.RequestOptions options = null)
        {
            HasCompleted = true; // Use the protected setter
            return ClientResult.FromOptionalValue<object>(null, new MockPipelineResponse(200));
        }

        public override ValueTask<ClientResult> UpdateStatusAsync(System.ClientModel.Primitives.RequestOptions options = null)
        {
            HasCompleted = true; // Use the protected setter
            return new ValueTask<ClientResult>(ClientResult.FromOptionalValue<object>(null, new MockPipelineResponse(200)));
        }
    }

    private class TestClientTestBase : ClientTestBase
    {
        public bool CreateProxyFromClientCalled { get; private set; }
        public bool CreateProxyFromOperationResultCalled { get; private set; }

        public TestClientTestBase(bool isAsync) : base(isAsync) { }

        protected internal override object CreateProxyFromClient(Type clientType, object client, System.Collections.Generic.IEnumerable<IInterceptor> preInterceptors)
        {
            CreateProxyFromClientCalled = true;
            return client;
        }
    }

    private class TestRecordedTestBase : RecordedTestBase
    {
        public TestRecordedTestBase(RecordedTestMode mode) : base(true)
        {
            // Set mode through reflection since it's protected
            var modeField = typeof(RecordedTestBase).GetField("_mode", BindingFlags.NonPublic | BindingFlags.Instance);
            modeField?.SetValue(this, mode);
        }
    }

    private class MockInvocation : IInvocation
    {
        private readonly string _methodName;
        private readonly Type _returnType;
        private object _returnValue;

        public MockInvocation(string methodName, Type returnType, object returnValue)
        {
            _methodName = methodName;
            _returnType = returnType;
            _returnValue = returnValue;
            Arguments = Array.Empty<object>();
        }

        public object[] Arguments { get; set; }
        public Type[] GenericArguments => Array.Empty<Type>();
        public object InvocationTarget => throw new NotImplementedException();
        public MethodInfo Method => new MockMethodInfo(_methodName, _returnType);
        public MethodInfo MethodInvocationTarget => Method;
        public object Proxy => throw new NotImplementedException();
        public object ReturnValue { get; set; }
        public Type TargetType => throw new NotImplementedException();
        public bool Proceeded { get; private set; }
        public bool ShouldReturnNull { get; set; }
        public bool ShouldReturnNullAfterProceed { get; set; }

        public IInvocation GetConcreteMethod() => throw new NotImplementedException();
        public IInvocationProceedInfo GetConcreteMethodInvocationTarget() => throw new NotImplementedException();

        public void Proceed()
        {
            Proceeded = true;
            if (ShouldReturnNull || ShouldReturnNullAfterProceed)
            {
                ReturnValue = null;
            }
            else
            {
                ReturnValue = _returnValue;
            }
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

    private class MockMethodInfo : MethodInfo
    {
        private readonly string _name;
        private readonly Type _returnType;

        public MockMethodInfo(string name, Type returnType)
        {
            _name = name;
            _returnType = returnType;
        }

        public override string Name => _name;
        public override Type ReturnType => _returnType;
        public override Type DeclaringType => typeof(object);
        public override Type ReflectedType => typeof(object);
        public override MethodAttributes Attributes => MethodAttributes.Public;
        public override RuntimeMethodHandle MethodHandle => throw new NotImplementedException();

        public override MethodInfo GetBaseDefinition() => throw new NotImplementedException();
        public override object[] GetCustomAttributes(bool inherit) => Array.Empty<object>();
        public override object[] GetCustomAttributes(Type attributeType, bool inherit) => Array.Empty<object>();
        public override MethodImplAttributes GetMethodImplementationFlags() => throw new NotImplementedException();
        public override ParameterInfo[] GetParameters() => Array.Empty<ParameterInfo>();
        public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
        public override bool IsDefined(Type attributeType, bool inherit) => false;
        public override ParameterInfo ReturnParameter => throw new NotImplementedException();

        public override ICustomAttributeProvider ReturnTypeCustomAttributes => throw new NotImplementedException();
    }

    #endregion
}
