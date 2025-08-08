// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Microsoft.ClientModel.TestFramework.Tests.TestProxy;
[TestFixture]
public class TestEnvironmentTests
{
    [Test]
    public void DevCertPassword_HasExpectedValue()
    {
        Assert.AreEqual("password", TestEnvironment.DevCertPassword);
    }
    [Test]
    public void DevCertPassword_IsNotNull()
    {
        Assert.IsNotNull(TestEnvironment.DevCertPassword);
        Assert.IsNotEmpty(TestEnvironment.DevCertPassword);
    }
    [Test]
    public void RepositoryRoot_IsAccessible()
    {
        Assert.DoesNotThrow(() => _ = TestEnvironment.RepositoryRoot);
    }
    [Test]
    public void DevCertPath_IsAccessible()
    {
        Assert.DoesNotThrow(() => _ = TestEnvironment.DevCertPath);
    }
    [Test]
    public void EnableFiddler_IsAccessible()
    {
        Assert.DoesNotThrow(() => _ = TestEnvironment.EnableFiddler);
    }
    [Test]
    public void EnableFiddler_IsBooleanValue()
    {
        var enableFiddler = TestEnvironment.EnableFiddler;
        Assert.IsInstanceOf<bool>(enableFiddler);
    }
    [Test]
    public void TestEnvironment_IsAbstractClass()
    {
        var type = typeof(TestEnvironment);
        Assert.IsTrue(type.IsAbstract, "TestEnvironment should be an abstract class");
    }
    [Test]
    public void TestEnvironment_HasProtectedConstructor()
    {
        var type = typeof(TestEnvironment);
        var constructors = type.GetConstructors(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        Assert.IsTrue(constructors.Length > 0, "TestEnvironment should have a constructor");
        Assert.IsTrue(Array.Exists(constructors, c => c.IsFamily), "TestEnvironment should have a protected constructor");
    }
    // Create a concrete implementation for testing
    private class TestTestEnvironment : TestEnvironment
    {
        // Concrete implementation for testing purposes
        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            throw new NotImplementedException();
        }
        public override Task WaitForEnvironmentAsync()
        {
            throw new NotImplementedException();
        }
    }
    [Test]
    public void ConcreteTestEnvironment_CanBeCreated()
    {
        TestTestEnvironment testEnv = null;
        try
        {
            testEnv = new TestTestEnvironment();
            Assert.IsNotNull(testEnv);
            Assert.IsInstanceOf<TestEnvironment>(testEnv);
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("Repository root is not set"))
        {
            // This is expected if repository root is not properly configured in test environment
            Assert.Pass("Repository root validation is working correctly");
        }
    }
    [Test]
    public void TestEnvironment_StaticMembers_AreAccessible()
    {
        Assert.DoesNotThrow(() =>
        {
            _ = TestEnvironment.RepositoryRoot;
            _ = TestEnvironment.DevCertPath;
            _ = TestEnvironment.EnableFiddler;
            _ = TestEnvironment.DevCertPassword;
        });
    }
    [Test]
    public void DevCertPassword_IsConstant()
    {
        var field = typeof(TestEnvironment).GetField(nameof(TestEnvironment.DevCertPassword));
        Assert.IsNotNull(field);
        Assert.IsTrue(field.IsLiteral, "DevCertPassword should be a constant");
        Assert.IsTrue(field.IsStatic, "DevCertPassword should be static");
    }
    [Test]
    public void TestEnvironment_PropertiesAreConsistent()
    {
        var repositoryRoot1 = TestEnvironment.RepositoryRoot;
        var repositoryRoot2 = TestEnvironment.RepositoryRoot;
        var devCertPath1 = TestEnvironment.DevCertPath;
        var devCertPath2 = TestEnvironment.DevCertPath;
        var enableFiddler1 = TestEnvironment.EnableFiddler;
        var enableFiddler2 = TestEnvironment.EnableFiddler;
        Assert.AreEqual(repositoryRoot1, repositoryRoot2, "RepositoryRoot should be consistent");
        Assert.AreEqual(devCertPath1, devCertPath2, "DevCertPath should be consistent");
        Assert.AreEqual(enableFiddler1, enableFiddler2, "EnableFiddler should be consistent");
    }
}
