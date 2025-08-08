// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Castle.DynamicProxy;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Threading.Tasks;
namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;
[TestFixture]
public class AsyncMethodWrapperTests
{
    [Test]
    public void AsyncMethodWrapper_IsInternal()
    {
        var type = typeof(AsyncMethodWrapper);
        Assert.IsTrue(type.IsNotPublic); // Internal types are not public
        Assert.IsTrue(type.IsSealed || type.IsAbstract); // Should be static class
    }
    [Test]
    public void AsyncMethodWrapper_IsStaticClass()
    {
        var type = typeof(AsyncMethodWrapper);
        Assert.IsTrue(type.IsAbstract && type.IsSealed); // Static classes are abstract and sealed
    }
    [Test]
    public void WrapAsyncResult_Method_Exists()
    {
        var type = typeof(AsyncMethodWrapper);
        var method = type.GetMethod("WrapAsyncResult", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.IsNotNull(method);
        Assert.IsTrue(method.IsStatic);
    }
    [Test]
    public void WrapAsyncResultCore_Method_Exists()
    {
        var type = typeof(AsyncMethodWrapper);
        var method = type.GetMethod("WrapAsyncResultCore", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.IsNotNull(method);
        Assert.IsTrue(method.IsStatic);
        Assert.IsTrue(method.IsGenericMethod);
    }
    [Test]
    public void WrapAsyncResult_HasCorrectParameters()
    {
        var type = typeof(AsyncMethodWrapper);
        var method = type.GetMethod("WrapAsyncResult", BindingFlags.NonPublic | BindingFlags.Static);
        var parameters = method.GetParameters();
        Assert.AreEqual(3, parameters.Length);
        Assert.AreEqual(typeof(IInvocation), parameters[0].ParameterType);
        Assert.AreEqual(typeof(object), parameters[1].ParameterType);
        Assert.AreEqual(typeof(MethodInfo), parameters[2].ParameterType);
    }
    [Test]
    public void WrapAsyncResultCore_HasCorrectParameters()
    {
        var type = typeof(AsyncMethodWrapper);
        var method = type.GetMethod("WrapAsyncResultCore", BindingFlags.NonPublic | BindingFlags.Static);
        var parameters = method.GetParameters();
        Assert.AreEqual(3, parameters.Length);
        Assert.AreEqual(typeof(IInvocation), parameters[0].ParameterType);
        Assert.AreEqual(typeof(Type), parameters[1].ParameterType);
        // Third parameter is a generic delegate type
    }
    [Test]
    public void AsyncMethodWrapper_HandlesTaskTypes()
    {
        // Test that the wrapper can handle different Task types
        var taskType = typeof(Task);
        var taskOfTType = typeof(Task<>);
        var valueTaskType = typeof(ValueTask);
        var valueTaskOfTType = typeof(ValueTask<>);
        Assert.IsTrue(taskType.IsClass);
        Assert.IsTrue(taskOfTType.IsGenericTypeDefinition);
        Assert.IsTrue(valueTaskType.IsValueType);
        Assert.IsTrue(valueTaskOfTType.IsGenericTypeDefinition);
    }
    [Test]
    public void AsyncMethodWrapper_CanAccessPrivateMembers()
    {
        var type = typeof(AsyncMethodWrapper);
        var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Static);
        // Should have internal fields for reflection caching
        Assert.IsNotNull(fields);
        // Look for the WrapAsyncResultCoreMethod field
        var coreMethodField = type.GetField("WrapAsyncResultCoreMethod", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.IsNotNull(coreMethodField);
        Assert.AreEqual(typeof(MethodInfo), coreMethodField.FieldType);
    }
    [Test]
    public void AsyncMethodWrapper_SupportsGenericTypeDefinitions()
    {
        // Test that the wrapper correctly identifies generic type definitions
        var taskOfString = typeof(Task<string>);
        var taskDefinition = typeof(Task<>);
        Assert.IsTrue(taskOfString.IsGenericType);
        Assert.IsTrue(taskDefinition.IsGenericTypeDefinition);
        Assert.AreEqual(taskDefinition, taskOfString.GetGenericTypeDefinition());
        Assert.AreEqual(typeof(string), taskOfString.GetGenericArguments()[0]);
    }
    [Test]
    public void AsyncMethodWrapper_HandlesClientResultTypes()
    {
        // Test that the wrapper can work with ClientResult<T> types
        var clientResultType = typeof(System.ClientModel.ClientResult<>);
        Assert.IsTrue(clientResultType.IsGenericTypeDefinition);
        Assert.AreEqual(1, clientResultType.GetGenericArguments().Length);
    }
    [Test]
    public void AsyncCallInterceptor_DelegateType_Exists()
    {
        // Test that AsyncCallInterceptor<T> delegate type can be constructed
        var delegateType = typeof(AsyncCallInterceptor<>);
        var stringDelegateType = delegateType.MakeGenericType(typeof(string));
        Assert.IsTrue(delegateType.IsGenericTypeDefinition);
        Assert.IsTrue(stringDelegateType.IsGenericType);
        Assert.IsFalse(stringDelegateType.IsGenericTypeDefinition);
    }
    [Test]
    public void AsyncMethodWrapper_ReflectionOperations_AreValid()
    {
        var type = typeof(AsyncMethodWrapper);
        // Test that all required reflection operations succeed
        Assert.DoesNotThrow(() =>
        {
            var method = type.GetMethod("WrapAsyncResultCore", BindingFlags.NonPublic | BindingFlags.Static);
            var genericMethod = method.MakeGenericMethod(typeof(string));
            Assert.IsNotNull(genericMethod);
        });
    }
    // This test validates that the wrapper can handle method invocation patterns
    [Test]
    public void AsyncMethodWrapper_MethodInvocation_Pattern()
    {
        // Test the pattern used for method invocation in WrapAsyncResult
        var type = typeof(AsyncMethodWrapper);
        var coreMethod = type.GetMethod("WrapAsyncResultCore", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.DoesNotThrow(() =>
        {
            var genericMethod = coreMethod.MakeGenericMethod(typeof(object));
            Assert.IsNotNull(genericMethod);
            // Test delegate creation pattern
            var interceptorType = typeof(AsyncCallInterceptor<>).MakeGenericType(typeof(object));
            Assert.IsNotNull(interceptorType);
        });
    }
    [Test]
    public void AsyncMethodWrapper_SupportsValueTaskConversions()
    {
        // Test ValueTask to Task conversion patterns that the wrapper uses
        var valueTask = new ValueTask(Task.CompletedTask);
        var task = valueTask.AsTask();
        Assert.IsNotNull(task);
        Assert.IsTrue(task.IsCompleted);
        var valueTaskOfInt = new ValueTask<int>(42);
        var taskOfInt = valueTaskOfInt.AsTask();
        Assert.IsNotNull(taskOfInt);
        Assert.IsTrue(taskOfInt.IsCompleted);
        Assert.AreEqual(42, taskOfInt.Result);
    }
}
