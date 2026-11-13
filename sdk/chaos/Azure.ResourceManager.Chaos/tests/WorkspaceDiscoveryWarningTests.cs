// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using Azure.ResourceManager.Chaos.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Chaos.Tests
{
    public class WorkspaceDiscoveryWarningTests
    {
        [TestCase("TargetNotFound")]
        [TestCase("FutureReason")]
        public void WarningReasonIsPublicAndPreservesWireValue(string reason)
        {
            BinaryData data = BinaryData.FromString($"{{\"scopeId\":\"/subscriptions/00000000-0000-0000-0000-000000000001\",\"scopeKind\":\"Subscription\",\"reason\":\"{reason}\",\"message\":\"Example warning\",\"resourceId\":\"/subscriptions/00000000-0000-0000-0000-000000000001\"}}");
            WorkspaceDiscoveryWarning warning = ModelReaderWriter.Read<WorkspaceDiscoveryWarning>(data);

            PropertyInfo reasonProperty = typeof(WorkspaceDiscoveryWarning).GetProperty("Reason", BindingFlags.Public | BindingFlags.Instance);
            Assert.That(reasonProperty, Is.Not.Null, "The warning reason must be accessible on the public model.");
            Assert.That(reasonProperty.GetValue(warning)?.ToString(), Is.EqualTo(reason));
        }

        [TestCase("RbacValidationFailed", typeof(WorkspaceDiscoveryPermissionWarning))]
        [TestCase("TargetNotFound", typeof(WorkspaceDiscoveryResourceWarning))]
        [TestCase("AccessIndeterminate", typeof(WorkspaceDiscoveryAccessWarning))]
        public void KnownReasonsPreserveSubtypeAndValue(string reason, Type expectedType)
        {
            BinaryData data = BinaryData.FromString($"{{\"scopeId\":\"/subscriptions/00000000-0000-0000-0000-000000000001\",\"scopeKind\":\"Subscription\",\"reason\":\"{reason}\",\"message\":\"Example warning\",\"resourceId\":\"/subscriptions/00000000-0000-0000-0000-000000000001\",\"permission\":{{}}}}");
            WorkspaceDiscoveryWarning warning = ModelReaderWriter.Read<WorkspaceDiscoveryWarning>(data);

            Assert.That(warning, Is.InstanceOf(expectedType));
            Assert.That(warning.Reason.ToString(), Is.EqualTo(reason));
        }

        [Test]
        public void UnknownReasonSurvivesPersistenceRoundTrip()
        {
            const string reason = "FutureReasonWithMixedCase";
            BinaryData data = BinaryData.FromString($"{{\"scopeId\":\"/subscriptions/00000000-0000-0000-0000-000000000001\",\"scopeKind\":\"Subscription\",\"reason\":\"{reason}\",\"message\":\"Example warning\"}}");
            WorkspaceDiscoveryWarning warning = ModelReaderWriter.Read<WorkspaceDiscoveryWarning>(data);
            BinaryData persisted = ModelReaderWriter.Write(warning, new ModelReaderWriterOptions("J"));
            using JsonDocument document = JsonDocument.Parse(persisted);
            WorkspaceDiscoveryWarning restored = ModelReaderWriter.Read<WorkspaceDiscoveryWarning>(persisted, new ModelReaderWriterOptions("J"));

            Assert.That(warning.Reason.ToString(), Is.EqualTo(reason));
            Assert.That(document.RootElement.GetProperty("reason").GetString(), Is.EqualTo(reason));
            Assert.That(restored.Reason.ToString(), Is.EqualTo(reason));
        }

        [TestCase("rbacvalidationfailed", "RbacValidationFailed")]
        [TestCase("targetnotfound", "TargetNotFound")]
        [TestCase("accessindeterminate", "AccessIndeterminate")]
        public void UnknownReasonDoesNotCompareEqualToKnownReasonWithDifferentCasing(string reason, string knownReason)
        {
            BinaryData data = BinaryData.FromString($"{{\"scopeId\":\"/subscriptions/00000000-0000-0000-0000-000000000001\",\"scopeKind\":\"Subscription\",\"reason\":\"{reason}\",\"message\":\"Example warning\"}}");
            WorkspaceDiscoveryWarning warning = ModelReaderWriter.Read<WorkspaceDiscoveryWarning>(data);
            var known = new WorkspaceDiscoveryWarningReason(knownReason);

            Assert.That(warning, Is.Not.InstanceOf<WorkspaceDiscoveryPermissionWarning>());
            Assert.That(warning, Is.Not.InstanceOf<WorkspaceDiscoveryResourceWarning>());
            Assert.That(warning, Is.Not.InstanceOf<WorkspaceDiscoveryAccessWarning>());
            Assert.That(warning.Reason.ToString(), Is.EqualTo(reason));
            Assert.That(warning.Reason.Equals(known), Is.False);
            Assert.That(warning.Reason == known, Is.False);
        }

        [Test]
        public void WarningReasonHashSetDistinguishesCase()
        {
            var known = WorkspaceDiscoveryWarningReason.RbacValidationFailed;
            var unknown = new WorkspaceDiscoveryWarningReason("rbacvalidationfailed");
            var reasons = new HashSet<WorkspaceDiscoveryWarningReason> { known, unknown };

            Assert.That(reasons, Has.Count.EqualTo(2));
            Assert.That(reasons.Contains(new WorkspaceDiscoveryWarningReason("RbacValidationFailed")), Is.True);
            Assert.That(unknown.Equals((object)known), Is.False);
            Assert.That(unknown != known, Is.True);
        }

        [Test]
        public void ModelFactoriesPreserveReasons()
        {
            Assert.That(ArmChaosModelFactory.WorkspaceDiscoveryPermissionWarning().Reason, Is.EqualTo(WorkspaceDiscoveryWarningReason.RbacValidationFailed));
            Assert.That(ArmChaosModelFactory.WorkspaceDiscoveryResourceWarning().Reason, Is.EqualTo(WorkspaceDiscoveryWarningReason.TargetNotFound));
            Assert.That(ArmChaosModelFactory.WorkspaceDiscoveryAccessWarning().Reason, Is.EqualTo(WorkspaceDiscoveryWarningReason.AccessIndeterminate));
            Assert.That(ArmChaosModelFactory.WorkspaceDiscoveryWarning(reason: "FutureReason").Reason.ToString(), Is.EqualTo("FutureReason"));
        }
    }
}
