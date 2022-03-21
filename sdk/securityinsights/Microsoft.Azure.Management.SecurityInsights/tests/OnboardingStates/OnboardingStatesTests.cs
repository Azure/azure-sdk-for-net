// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class OnboardingStatesTests : TestBase
    {
        #region Test setup

        #endregion

        #region OnboardingStates

        [Fact]
        public void OnboardingStates_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var OnboardingStates = SecurityInsightsClient.SentinelOnboardingStates.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateOnboardingStates(OnboardingStates);
            }
        }

        [Fact]
        public void OnboardingStates_CreateorUpdate()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var OnboardingStateId = "default";

                var OnboardingState = SecurityInsightsClient.SentinelOnboardingStates.Create(TestHelper.ResourceGroup, TestHelper.WorkspaceName, OnboardingStateId, null, false);
                ValidateOnboardingState(OnboardingState);
                //SecurityInsightsClient.SentinelOnboardingStates.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, OnboardingStateId);
            }
        }

        [Fact]
        public void OnboardingStates_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var OnboardingStateId = "default";

                SecurityInsightsClient.SentinelOnboardingStates.Create(TestHelper.ResourceGroup, TestHelper.WorkspaceName, OnboardingStateId, null, false);
                var OnboardingState = SecurityInsightsClient.SentinelOnboardingStates.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, OnboardingStateId);
                ValidateOnboardingState(OnboardingState);
                //SecurityInsightsClient.SentinelOnboardingStates.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, OnboardingStateId);

            }
        }

        #endregion

        #region Validations

        private void ValidateOnboardingStates(SentinelOnboardingStatesList OnboardingStateList)
        {
            Assert.True(OnboardingStateList.Value.IsAny());

            OnboardingStateList.Value.ForEach(ValidateOnboardingState);
        }

        private void ValidateOnboardingState(SentinelOnboardingState OnboardingState)
        {
            Assert.NotNull(OnboardingState);
        }

        #endregion
    }
}
