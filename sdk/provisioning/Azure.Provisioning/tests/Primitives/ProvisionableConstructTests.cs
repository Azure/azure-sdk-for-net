// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Primitives;

public class ProvisionableConstructTests
{
    // Compatibility properties can use different enum types while sharing a Bicep path, as with
    // ExecutionTrigger.TriggerType and TaskExecutionTriggerType in Azure.Provisioning.Storage.
    // Assigning either property alone must serialize its value without interference from the unset
    // property, whether registered before or after it. Assigning both is outside this test's contract.
    [TestCase(true, 0, "RunOnce")]
    [TestCase(true, 1, "OnSchedule")]
    [TestCase(false, 0, "RunOnce")]
    [TestCase(false, 1, "OnSchedule")]
    public void CompilePropertiesWithSharedBicepPathUsesOnlyAssignedProperty(
        bool assignLegacy, int value, string expectedType)
    {
        SharedBicepPathModel model = new();
        if (assignLegacy)
        {
            model.LegacyType = (LegacyTriggerType)value;
        }
        else
        {
            model.CurrentType = (CurrentTriggerType)value;
        }

        Assert.That(model.LegacyType, Is.Not.SameAs(model.CurrentType));
        Assert.That(model.LegacyType.IsEmpty, Is.EqualTo(!assignLegacy));
        Assert.That(model.CurrentType.IsEmpty, Is.EqualTo(assignLegacy));
        TestHelpers.AssertExpression(
            $$"""
            {
              type: '{{expectedType}}'
            }
            """,
            ((IBicepValue)model).Compile());
    }

    private sealed class SharedBicepPathModel : ProvisionableConstruct
    {
        public BicepValue<CurrentTriggerType> CurrentType
        {
            get { Initialize(); return _currentType!; }
            set { Initialize(); _currentType!.Assign(value); }
        }
        private BicepValue<CurrentTriggerType>? _currentType;

        public BicepValue<LegacyTriggerType> LegacyType
        {
            get { Initialize(); return _legacyType!; }
            set { Initialize(); _legacyType!.Assign(value); }
        }
        private BicepValue<LegacyTriggerType>? _legacyType;

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _currentType = DefineProperty<CurrentTriggerType>(nameof(CurrentType), ["type"]);
            _legacyType = DefineProperty<LegacyTriggerType>(nameof(LegacyType), ["type"]);
        }
    }

    private enum CurrentTriggerType
    {
        RunOnce,
        OnSchedule
    }

    private enum LegacyTriggerType
    {
        RunOnce,
        OnSchedule
    }
}
