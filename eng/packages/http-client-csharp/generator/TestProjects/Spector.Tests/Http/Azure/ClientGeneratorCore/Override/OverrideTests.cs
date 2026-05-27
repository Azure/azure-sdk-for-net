// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Customization;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.Override;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.Override
{
    public class OverrideTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_Override_GroupParameters() => Test(async (host) =>
        {
            var client = new OverrideClient(host, null);
            var groupParameters = client.GetGroupParametersClient();

            // Test convenience method with flattened parameters
            var options = new GroupParametersOptions("param1", "param2");
            var response = await groupParameters.GroupAsync(options);
            Assert.AreEqual(204, response.Status);

            // Verify that the convenience method exists with GroupParametersOptions parameter
            Assert.IsNotNull(typeof(GroupParameters).GetMethod("GroupAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(GroupParametersOptions), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(GroupParameters).GetMethod("Group", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(GroupParametersOptions), typeof(CancellationToken) }));

            // Verify that the protocol method exists with individual parameters
            Assert.IsNotNull(typeof(GroupParameters).GetMethod("GroupAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(RequestContext) }));
            Assert.IsNotNull(typeof(GroupParameters).GetMethod("Group", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(RequestContext) }));
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_Override_RemoveOptionalParameter() => Test(async (host) =>
        {
            var client = new OverrideClient(host, null);
            var removeOptionalParameter = client.GetRemoveOptionalParameterClient();

            // Test convenience method using only the minimum required parameter, omitting optional parameters
            var response = await removeOptionalParameter.RemoveOptionalAsync("param1", "param2");
            Assert.AreEqual(204, response.Status);

            // Verify that the convenience method exists with required param1, optional param2, and without protocol-only parameters (param3, param4)
            Assert.IsNotNull(typeof(RemoveOptionalParameter).GetMethod("RemoveOptionalAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(RemoveOptionalParameter).GetMethod("RemoveOptional", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(CancellationToken) }));

            // Verify that the protocol method exists with all parameters
            Assert.IsNotNull(typeof(RemoveOptionalParameter).GetMethod("RemoveOptionalAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestContext) }));
            Assert.IsNotNull(typeof(RemoveOptionalParameter).GetMethod("RemoveOptional", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestContext) }));
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_Override_ReorderParameters() => Test(async (host) =>
        {
            var client = new OverrideClient(host, null);
            var reorderParameters = client.GetReorderParametersClient();

            // Test convenience method with reordered parameters
            var response = await reorderParameters.ReorderAsync("param1", "param2");
            Assert.AreEqual(204, response.Status);

            // Verify that the convenience method exists with reordered parameters (param1, param2)
            Assert.IsNotNull(typeof(ReorderParameters).GetMethod("ReorderAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(ReorderParameters).GetMethod("Reorder", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(CancellationToken) }));

            // Verify that the corresponding protocol methods exist with the expected parameter types
            Assert.IsNotNull(typeof(ReorderParameters).GetMethod("ReorderAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(RequestContext) }));
            Assert.IsNotNull(typeof(ReorderParameters).GetMethod("Reorder", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(RequestContext) }));
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_Override_RequireOptionalParameter() => Test(async (host) =>
        {
            var client = new OverrideClient(host, null);
            var requireOptionalParameter = client.GetRequireOptionalParameterClient();

            // Test convenience method with required parameter that was optional
            var response = await requireOptionalParameter.RequireOptionalAsync("param1", "param2", CancellationToken.None);
            Assert.AreEqual(204, response.Status);

            // Verify that the convenience method exists with both parameters required
            Assert.IsNotNull(typeof(RequireOptionalParameter).GetMethod("RequireOptionalAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(RequireOptionalParameter).GetMethod("RequireOptional", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(CancellationToken) }));

            // Verify that the protocol method exists with param2 as optional
            Assert.IsNotNull(typeof(RequireOptionalParameter).GetMethod("RequireOptionalAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(RequestContext) }));
            Assert.IsNotNull(typeof(RequireOptionalParameter).GetMethod("RequireOptional", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(string), typeof(RequestContext) }));
        });
    }
}
