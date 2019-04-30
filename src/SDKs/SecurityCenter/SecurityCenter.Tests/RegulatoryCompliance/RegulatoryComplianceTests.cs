// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests.RegulatoryCompliance
{
	public class RegulatoryComplianceTests : TestBase
	{
		#region Test setup

		public static TestEnvironment TestEnvironment { get; private set; }

		private static SecurityCenterClient GetSecurityCenterClient(MockContext context)
		{
			if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
			{
				TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
			}

			var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

			var securityCenterClient = HttpMockServer.Mode == HttpRecorderMode.Record
				? context.GetServiceClient<SecurityCenterClient>(TestEnvironment, handlers: handler)
				: context.GetServiceClient<SecurityCenterClient>(handlers: handler);

			securityCenterClient.AscLocation = "centralus";

			return securityCenterClient;
		}

		#endregion

		#region RegulatoryComplianceStandards

		[Fact]
		public void RegulatoryComplianceStandard_List()
		{
			using (var context = MockContext.Start(GetType().FullName))
			{
				var securityCenterClient = GetSecurityCenterClient(context);
				var standards = securityCenterClient.RegulatoryComplianceStandards.List();
				ValidateStandards(standards);
			}
		}

		[Fact]
		public void RegulatoryComplianceStandard_Get()
		{
			using (var context = MockContext.Start(GetType().FullName))
			{
				var securityCenterClient = GetSecurityCenterClient(context);
				var standards = securityCenterClient.RegulatoryComplianceStandards.List();
				var standardName = standards.First().Name;

				var standard = securityCenterClient.RegulatoryComplianceStandards.Get(standardName);
				ValidateStandard(standard);
			}
		}

		#endregion


		#region RegulatoryComplianceControls

		[Fact]
		public void RegulatoryComplianceControl_List()
		{
			using (var context = MockContext.Start(GetType().FullName))
			{
				var securityCenterClient = GetSecurityCenterClient(context);
				var standards = securityCenterClient.RegulatoryComplianceStandards.List();
				var standardName = standards.First().Name;

				var controls = securityCenterClient.RegulatoryComplianceControls.List(standardName);
				ValidateControls(controls);
			}
		}

		[Fact]
		public void RegulatoryComplianceControl_Get()
		{
			using (var context = MockContext.Start(GetType().FullName))
			{
				var securityCenterClient = GetSecurityCenterClient(context);
				var standards = securityCenterClient.RegulatoryComplianceStandards.List();
				var standardName = standards.First().Name;

				var controls = securityCenterClient.RegulatoryComplianceControls.List(standardName);
				var controlName = controls.First().Name;

				var control = securityCenterClient.RegulatoryComplianceControls.Get(standardName, controlName);
				ValidateControl(control);
			}
		}

		#endregion

		#region RegulatoryComplianceAssessments

		[Fact]
		public void RegulatoryComplianceAssessment_List()
		{
			using (var context = MockContext.Start(GetType().FullName))
			{
				var securityCenterClient = GetSecurityCenterClient(context);
				var standards = securityCenterClient.RegulatoryComplianceStandards.List();
				var standardName = standards.First().Name;

				var controls = securityCenterClient.RegulatoryComplianceControls.List(standardName);
				var controlName = controls.First().Name;

				var assessments = securityCenterClient.RegulatoryComplianceAssessments.List(standardName, controlName);
				ValidateAssessments(assessments);
			}
		}

		[Fact]
		public void RegulatoryComplianceAssessment_Get()
		{
			using (var context = MockContext.Start(GetType().FullName))
			{
				var securityCenterClient = GetSecurityCenterClient(context);
				var standards = securityCenterClient.RegulatoryComplianceStandards.List();
				var standardName = standards.First().Name;

				var controls = securityCenterClient.RegulatoryComplianceControls.List(standardName);
				var controlName = controls.First().Name;

				var assessments = securityCenterClient.RegulatoryComplianceAssessments.List(standardName, controlName);
				var assessmentName = assessments.First().Name;

				var assessment = securityCenterClient.RegulatoryComplianceAssessments.Get(standardName, controlName, assessmentName);
				ValidateAssessment(assessment);
			}
		}

		#endregion

		#region Validations

		private void ValidateStandards(IPage<RegulatoryComplianceStandard> standards)
		{
			Assert.True(standards.IsAny());

			standards.ForEach(ValidateStandard);
		}

		private void ValidateStandard(RegulatoryComplianceStandard standard)
		{
			Assert.NotNull(standard);
		}

		private void ValidateControls(IPage<RegulatoryComplianceControl> controls)
		{
			Assert.True(controls.IsAny());

			controls.ForEach(ValidateControl);
		}

		private void ValidateControl(RegulatoryComplianceControl control)
		{
			Assert.NotNull(control);
		}

		private void ValidateAssessments(IPage<RegulatoryComplianceAssessment> assessments)
		{
			Assert.True(assessments.IsAny());

			assessments.ForEach(ValidateAssessment);
		}

		private void ValidateAssessment(RegulatoryComplianceAssessment assessment)
		{
			Assert.NotNull(assessment);
		}

		#endregion
	}
}
