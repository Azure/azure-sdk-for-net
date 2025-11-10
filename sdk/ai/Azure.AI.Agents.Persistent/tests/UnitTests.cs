// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests
{
    /// <summary>
    /// Non recordable tests.
    /// </summary>
    public class UnitTests
    {
        [Test]
        [TestCase("always", true, false)]
        [TestCase("never", false, true)]
        public void MCPApproval(string trust, bool isAlways, bool isNever)
        {
            var approval = new MCPApproval(trust);
            Assert.AreEqual(approval.AlwaysRequireApproval, isAlways);
            Assert.AreEqual(approval.NeverRequireApproval, isNever);
            Assert.IsNull(approval.PerToolApproval);
        }

        [Test]
        public void MCPApprovalPerTool()
        {
            var approval = new MCPApproval(
                new MCPApprovalPerTool(
                    always: new MCPToolList(["foo", "bar"]),
                    never: new MCPToolList(["baz"]),
                    serializedAdditionalRawData: null
                )
            );
            Assert.False(approval.AlwaysRequireApproval);
            Assert.False(approval.NeverRequireApproval);
            AssertMcpListsEqual(["foo", "bar"], ["baz"], approval.PerToolApproval);
        }

        [Test]
        public void MCPApprovalRaisesString()
        {
            ArgumentException exc = Assert.Throws<ArgumentException>(() => new MCPApproval("test"));
            Assert.That(exc.Message.StartsWith("The parameter \"requireApproval\" may be only \"always\" or \"never\"."), $"Unexpected message {exc.Message}");
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void MCPApprovalPerToolNullEmpty(bool isPerToolNull)
        {
            MCPApprovalPerTool perTool = null;
            if (isPerToolNull)
            {
                perTool = new MCPApprovalPerTool();
            }
            var mcp = new MCPApproval(perToolApproval: perTool);
            Assert.True(mcp.AlwaysRequireApproval);
            Assert.False(mcp.NeverRequireApproval);
            Assert.IsNull(mcp.PerToolApproval);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void MCPApprovalEmptyString(bool isAlwaysEmpty)
        {
            var mcp = new MCPApproval(perToolApproval: new MCPApprovalPerTool(
                    always: isAlwaysEmpty ? new MCPToolList([]) : new MCPToolList(["foo", "bar"]),
                    never: isAlwaysEmpty ? new MCPToolList(["foo", "bar"]) : new MCPToolList([]),
                    serializedAdditionalRawData: null
                )
            );
            if (isAlwaysEmpty)
            {
                AssertListEqual(mcp.PerToolApproval.Never.ToolNames, ["foo", "bar"], "Expected Always request approvals on");
                Assert.IsNull(mcp.PerToolApproval.Always);
            }
            else
            {
                AssertListEqual(mcp.PerToolApproval.Always.ToolNames, ["foo", "bar"], "Expected Always request approvals on");
                Assert.IsNull(mcp.PerToolApproval.Never);
            }
        }

        [Test]
        [TestCase("always", true, false)]
        [TestCase("never", false, true)]
        public void MCPToolResourceApprovals(string trust, bool isAlways, bool isNever)
        {
            var mcpRes = new MCPToolResource()
            {
                RequireApproval = new MCPApproval(trust)
            };
            MCPApproval returned = mcpRes.RequireApproval;
            Assert.AreEqual(returned.AlwaysRequireApproval, isAlways);
            Assert.AreEqual(returned.NeverRequireApproval, isNever);
            Assert.IsNull(returned.PerToolApproval);
        }

        [Test]
        public void MCPToolResourceApprovalsNull()
        {
            var mcpRes = new MCPToolResource();
            Assert.IsNull(mcpRes.RequireApproval);
            mcpRes.RequireApproval = new("never");
            MCPApproval returned = mcpRes.RequireApproval;
            Assert.IsNotNull(returned);
            Assert.AreEqual(returned.AlwaysRequireApproval, false);
            Assert.AreEqual(returned.NeverRequireApproval, true);
            Assert.IsNull(returned.PerToolApproval);
            mcpRes.RequireApproval = null;
            returned = mcpRes.RequireApproval;
            Assert.IsNull(mcpRes.RequireApproval);
        }

        [Test]
        public void MCPToolResourceApprovalsPerTool()
        {
            var mcpRes = new MCPToolResource()
            {
                RequireApproval = new MCPApproval(new MCPApprovalPerTool(
                    always: new MCPToolList(["foo", "bar"]),
                    never: new MCPToolList(["baz"]),
                    serializedAdditionalRawData: null
                ))
            };
            MCPApproval returned = mcpRes.RequireApproval;
            Assert.False(returned.AlwaysRequireApproval);
            Assert.False(returned.NeverRequireApproval);
            AssertMcpListsEqual(["foo", "bar"], ["baz"], returned.PerToolApproval);
        }

        [Test]
        [TestCase("foo", "foo", "desc1", "desc2")]
        [TestCase("foo", "foo", "desc1", "desc1")]
        [TestCase("foo", "bar", "desc1", "desc2")]
        [TestCase("foo", "bar", "desc1", "desc1")]
        public void FunctionDefinitionEquality(string name1, string name2, string description1, string description2)
        {
            FunctionToolDefinition func1 = new(name: name1, description: description1);
            FunctionToolDefinition func2 = new(name: name2, description: description2);
            bool shouldBeEqual = string.Equals(name1, name2);
            Assert.AreEqual(shouldBeEqual, func1.Equals(func2));
            Assert.AreEqual(shouldBeEqual, func1.GetHashCode() == func2.GetHashCode());
        }

        #region helpers
        private static void AssertMcpListsEqual(IEnumerable<string> expectedAlways, IEnumerable<string> expectedNever, MCPApprovalPerTool observedApproval)
        {
            AssertListEqual(observedApproval.Always.ToolNames, expectedAlways, "Expected Always request approvals on");
            AssertListEqual(observedApproval.Never.ToolNames, expectedNever, "Expected Never request approvals on");
        }

        private static void AssertListEqual(IEnumerable<string> observedList, IEnumerable<string> expectedList, string message)
        {
            HashSet<string> expected = [.. expectedList];
            HashSet<string> observed = [.. observedList];
            Assert.That(observed.SetEquals(expected), $"{message} {SetToString(expected)}, but was {SetToString(observed)}");
        }

        private static string SetToString(HashSet<string> set)
        {
            List<string> lst = [.. set];
            lst.Sort();
            StringBuilder sbSet = new();
            foreach (string val in lst)
            {
                sbSet.Append(val);
                sbSet.Append(' ');
            }
            return sbSet.ToString().Trim();
        }
        #endregion
    }
}
