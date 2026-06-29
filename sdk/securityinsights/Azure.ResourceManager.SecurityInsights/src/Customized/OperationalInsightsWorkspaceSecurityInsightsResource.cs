// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.SecurityInsights.Models;

namespace Azure.ResourceManager.SecurityInsights
{
    /// <summary>
    /// Obsolete legacy wrapper around the Microsoft.OperationalInsights/workspaces resource that previously exposed Security Insights operations as instance methods.
    /// Every public member now throws <see cref="NotSupportedException"/>; the exception message points to the equivalent extension method on <see cref="ArmClient"/> in <see cref="SecurityInsightsExtensions"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("OperationalInsightsWorkspaceSecurityInsightsResource is no longer supported. Use the equivalent extension methods on ArmClient in Azure.ResourceManager.SecurityInsights.SecurityInsightsExtensions instead.", false)]
    public partial class OperationalInsightsWorkspaceSecurityInsightsResource : ArmResource
    {
        private const string NotSupportedPrefix = "OperationalInsightsWorkspaceSecurityInsightsResource is no longer supported. ";

        /// <summary> Generate the resource identifier of a <see cref="OperationalInsightsWorkspaceSecurityInsightsResource"/> instance. </summary>
        internal static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Initializes a new instance of the <see cref="OperationalInsightsWorkspaceSecurityInsightsResource"/> class for mocking. </summary>
        protected OperationalInsightsWorkspaceSecurityInsightsResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="OperationalInsightsWorkspaceSecurityInsightsResource"/> class. </summary>
        internal OperationalInsightsWorkspaceSecurityInsightsResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.OperationalInsights/workspaces";

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsAlertRules(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsAlertRuleCollection GetSecurityInsightsAlertRules()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsAlertRules(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsAlertRuleAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsAlertRuleResource>> GetSecurityInsightsAlertRuleAsync(string ruleId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsAlertRuleAsync(workspaceResourceIdentifier, ruleId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsAlertRule(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsAlertRuleResource> GetSecurityInsightsAlertRule(string ruleId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsAlertRule(workspaceResourceIdentifier, ruleId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsAlertRuleTemplates(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsAlertRuleTemplateCollection GetSecurityInsightsAlertRuleTemplates()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsAlertRuleTemplates(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsAlertRuleTemplateAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsAlertRuleTemplateResource>> GetSecurityInsightsAlertRuleTemplateAsync(string alertRuleTemplateId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsAlertRuleTemplateAsync(workspaceResourceIdentifier, alertRuleTemplateId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsAlertRuleTemplate(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsAlertRuleTemplateResource> GetSecurityInsightsAlertRuleTemplate(string alertRuleTemplateId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsAlertRuleTemplate(workspaceResourceIdentifier, alertRuleTemplateId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsAutomationRules(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsAutomationRuleCollection GetSecurityInsightsAutomationRules()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsAutomationRules(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsAutomationRuleAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsAutomationRuleResource>> GetSecurityInsightsAutomationRuleAsync(string automationRuleId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsAutomationRuleAsync(workspaceResourceIdentifier, automationRuleId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsAutomationRule(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsAutomationRuleResource> GetSecurityInsightsAutomationRule(string automationRuleId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsAutomationRule(workspaceResourceIdentifier, automationRuleId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsEntities(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsEntityCollection GetSecurityInsightsEntities()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsEntities(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsEntityAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsEntityResource>> GetSecurityInsightsEntityAsync(string entityId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsEntityAsync(workspaceResourceIdentifier, entityId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsEntity(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsEntityResource> GetSecurityInsightsEntity(string entityId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsEntity(workspaceResourceIdentifier, entityId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsIncidents(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsIncidentCollection GetSecurityInsightsIncidents()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsIncidents(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsIncidentAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsIncidentResource>> GetSecurityInsightsIncidentAsync(string incidentId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsIncidentAsync(workspaceResourceIdentifier, incidentId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsIncident(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsIncidentResource> GetSecurityInsightsIncident(string incidentId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsIncident(workspaceResourceIdentifier, incidentId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsBillingStatistics(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsBillingStatisticCollection GetSecurityInsightsBillingStatistics()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsBillingStatistics(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsBillingStatisticAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsBillingStatisticResource>> GetSecurityInsightsBillingStatisticAsync(string billingStatisticName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsBillingStatisticAsync(workspaceResourceIdentifier, billingStatisticName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsBillingStatistic(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsBillingStatisticResource> GetSecurityInsightsBillingStatistic(string billingStatisticName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsBillingStatistic(workspaceResourceIdentifier, billingStatisticName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsBookmarks(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsBookmarkCollection GetSecurityInsightsBookmarks()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsBookmarks(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsBookmarkAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsBookmarkResource>> GetSecurityInsightsBookmarkAsync(string bookmarkId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsBookmarkAsync(workspaceResourceIdentifier, bookmarkId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsBookmark(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsBookmarkResource> GetSecurityInsightsBookmark(string bookmarkId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsBookmark(workspaceResourceIdentifier, bookmarkId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsPackages(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsPackageCollection GetSecurityInsightsPackages()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsPackages(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsPackageAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsPackageResource>> GetSecurityInsightsPackageAsync(string packageId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsPackageAsync(workspaceResourceIdentifier, packageId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsPackage(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsPackageResource> GetSecurityInsightsPackage(string packageId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsPackage(workspaceResourceIdentifier, packageId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsProductPackages(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsProductPackageCollection GetSecurityInsightsProductPackages()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsProductPackages(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsProductPackageAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsProductPackageResource>> GetSecurityInsightsProductPackageAsync(string packageId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsProductPackageAsync(workspaceResourceIdentifier, packageId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsProductPackage(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsProductPackageResource> GetSecurityInsightsProductPackage(string packageId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsProductPackage(workspaceResourceIdentifier, packageId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsProductTemplates(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsProductTemplateCollection GetSecurityInsightsProductTemplates()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsProductTemplates(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsProductTemplateAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsProductTemplateResource>> GetSecurityInsightsProductTemplateAsync(string templateId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsProductTemplateAsync(workspaceResourceIdentifier, templateId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsProductTemplate(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsProductTemplateResource> GetSecurityInsightsProductTemplate(string templateId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsProductTemplate(workspaceResourceIdentifier, templateId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsTemplates(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsTemplateCollection GetSecurityInsightsTemplates()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsTemplates(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsTemplateAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsTemplateResource>> GetSecurityInsightsTemplateAsync(string templateId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsTemplateAsync(workspaceResourceIdentifier, templateId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsTemplate(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsTemplateResource> GetSecurityInsightsTemplate(string templateId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsTemplate(workspaceResourceIdentifier, templateId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsEntityQueries(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsEntityQueryCollection GetSecurityInsightsEntityQueries()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsEntityQueries(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsEntityQueryAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsEntityQueryResource>> GetSecurityInsightsEntityQueryAsync(string entityQueryId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsEntityQueryAsync(workspaceResourceIdentifier, entityQueryId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsEntityQuery(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsEntityQueryResource> GetSecurityInsightsEntityQuery(string entityQueryId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsEntityQuery(workspaceResourceIdentifier, entityQueryId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsEntityQueryTemplates(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsEntityQueryTemplateCollection GetSecurityInsightsEntityQueryTemplates()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsEntityQueryTemplates(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsEntityQueryTemplateAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsEntityQueryTemplateResource>> GetSecurityInsightsEntityQueryTemplateAsync(string entityQueryTemplateId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsEntityQueryTemplateAsync(workspaceResourceIdentifier, entityQueryTemplateId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsEntityQueryTemplate(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsEntityQueryTemplateResource> GetSecurityInsightsEntityQueryTemplate(string entityQueryTemplateId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsEntityQueryTemplate(workspaceResourceIdentifier, entityQueryTemplateId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsFileImports(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsFileImportCollection GetSecurityInsightsFileImports()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsFileImports(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsFileImportAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsFileImportResource>> GetSecurityInsightsFileImportAsync(string fileImportId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsFileImportAsync(workspaceResourceIdentifier, fileImportId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsFileImport(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsFileImportResource> GetSecurityInsightsFileImport(string fileImportId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsFileImport(workspaceResourceIdentifier, fileImportId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsHunts(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsHuntCollection GetSecurityInsightsHunts()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsHunts(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsHuntAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsHuntResource>> GetSecurityInsightsHuntAsync(string huntId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsHuntAsync(workspaceResourceIdentifier, huntId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsHunt(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsHuntResource> GetSecurityInsightsHunt(string huntId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsHunt(workspaceResourceIdentifier, huntId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetAllSecurityInsightsMetadata(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsMetadataCollection GetAllSecurityInsightsMetadata()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetAllSecurityInsightsMetadata(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsMetadataAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsMetadataResource>> GetSecurityInsightsMetadataAsync(string metadataName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsMetadataAsync(workspaceResourceIdentifier, metadataName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsMetadata(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsMetadataResource> GetSecurityInsightsMetadata(string metadataName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsMetadata(workspaceResourceIdentifier, metadataName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsOfficeConsents(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsOfficeConsentCollection GetSecurityInsightsOfficeConsents()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsOfficeConsents(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsOfficeConsentAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsOfficeConsentResource>> GetSecurityInsightsOfficeConsentAsync(string consentId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsOfficeConsentAsync(workspaceResourceIdentifier, consentId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsOfficeConsent(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsOfficeConsentResource> GetSecurityInsightsOfficeConsent(string consentId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsOfficeConsent(workspaceResourceIdentifier, consentId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsSentinelOnboardingStates(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsSentinelOnboardingStateCollection GetSecurityInsightsSentinelOnboardingStates()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsSentinelOnboardingStates(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsSentinelOnboardingStateAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsSentinelOnboardingStateResource>> GetSecurityInsightsSentinelOnboardingStateAsync(string sentinelOnboardingStateName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsSentinelOnboardingStateAsync(workspaceResourceIdentifier, sentinelOnboardingStateName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsSentinelOnboardingState(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsSentinelOnboardingStateResource> GetSecurityInsightsSentinelOnboardingState(string sentinelOnboardingStateName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsSentinelOnboardingState(workspaceResourceIdentifier, sentinelOnboardingStateName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsRecommendations(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsRecommendationCollection GetSecurityInsightsRecommendations()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsRecommendations(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsRecommendationAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsRecommendationResource>> GetSecurityInsightsRecommendationAsync(Guid recommendationId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsRecommendationAsync(workspaceResourceIdentifier, recommendationId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsRecommendation(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsRecommendationResource> GetSecurityInsightsRecommendation(Guid recommendationId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsRecommendation(workspaceResourceIdentifier, recommendationId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityMLAnalyticsSettings(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityMLAnalyticsSettingCollection GetSecurityMLAnalyticsSettings()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityMLAnalyticsSettings(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityMLAnalyticsSettingAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityMLAnalyticsSettingResource>> GetSecurityMLAnalyticsSettingAsync(string settingsResourceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityMLAnalyticsSettingAsync(workspaceResourceIdentifier, settingsResourceName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityMLAnalyticsSetting(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityMLAnalyticsSettingResource> GetSecurityMLAnalyticsSetting(string settingsResourceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityMLAnalyticsSetting(workspaceResourceIdentifier, settingsResourceName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsSettings(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsSettingCollection GetSecurityInsightsSettings()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsSettings(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsSettingAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsSettingResource>> GetSecurityInsightsSettingAsync(string settingsName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsSettingAsync(workspaceResourceIdentifier, settingsName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsSetting(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsSettingResource> GetSecurityInsightsSetting(string settingsName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsSetting(workspaceResourceIdentifier, settingsName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsSourceControls(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsSourceControlCollection GetSecurityInsightsSourceControls()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsSourceControls(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsSourceControlAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsSourceControlResource>> GetSecurityInsightsSourceControlAsync(string sourceControlId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsSourceControlAsync(workspaceResourceIdentifier, sourceControlId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsSourceControl(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsSourceControlResource> GetSecurityInsightsSourceControl(string sourceControlId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsSourceControl(workspaceResourceIdentifier, sourceControlId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsThreatIntelligenceIndicators(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsThreatIntelligenceIndicatorCollection GetSecurityInsightsThreatIntelligenceIndicators()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsThreatIntelligenceIndicators(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsThreatIntelligenceIndicatorAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsThreatIntelligenceIndicatorResource>> GetSecurityInsightsThreatIntelligenceIndicatorAsync(string name, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsThreatIntelligenceIndicatorAsync(workspaceResourceIdentifier, name, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsThreatIntelligenceIndicator(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsThreatIntelligenceIndicatorResource> GetSecurityInsightsThreatIntelligenceIndicator(string name, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsThreatIntelligenceIndicator(workspaceResourceIdentifier, name, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetTriggeredAnalyticsRuleRuns(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual TriggeredAnalyticsRuleRunCollection GetTriggeredAnalyticsRuleRuns()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetTriggeredAnalyticsRuleRuns(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetTriggeredAnalyticsRuleRunAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<TriggeredAnalyticsRuleRunResource>> GetTriggeredAnalyticsRuleRunAsync(string ruleRunId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetTriggeredAnalyticsRuleRunAsync(workspaceResourceIdentifier, ruleRunId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetTriggeredAnalyticsRuleRun(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<TriggeredAnalyticsRuleRunResource> GetTriggeredAnalyticsRuleRun(string ruleRunId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetTriggeredAnalyticsRuleRun(workspaceResourceIdentifier, ruleRunId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsWatchlists(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsWatchlistCollection GetSecurityInsightsWatchlists()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsWatchlists(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsWatchlistAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsWatchlistResource>> GetSecurityInsightsWatchlistAsync(string watchlistAlias, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsWatchlistAsync(workspaceResourceIdentifier, watchlistAlias, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsWatchlist(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsWatchlistResource> GetSecurityInsightsWatchlist(string watchlistAlias, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsWatchlist(workspaceResourceIdentifier, watchlistAlias, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWorkspaceManagerAssignments(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual WorkspaceManagerAssignmentCollection GetWorkspaceManagerAssignments()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetWorkspaceManagerAssignments(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWorkspaceManagerAssignmentAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<WorkspaceManagerAssignmentResource>> GetWorkspaceManagerAssignmentAsync(string workspaceManagerAssignmentName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetWorkspaceManagerAssignmentAsync(workspaceResourceIdentifier, workspaceManagerAssignmentName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWorkspaceManagerAssignment(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<WorkspaceManagerAssignmentResource> GetWorkspaceManagerAssignment(string workspaceManagerAssignmentName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetWorkspaceManagerAssignment(workspaceResourceIdentifier, workspaceManagerAssignmentName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWorkspaceManagerConfigurations(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual WorkspaceManagerConfigurationCollection GetWorkspaceManagerConfigurations()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetWorkspaceManagerConfigurations(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWorkspaceManagerConfigurationAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<WorkspaceManagerConfigurationResource>> GetWorkspaceManagerConfigurationAsync(string workspaceManagerConfigurationName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetWorkspaceManagerConfigurationAsync(workspaceResourceIdentifier, workspaceManagerConfigurationName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWorkspaceManagerConfiguration(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<WorkspaceManagerConfigurationResource> GetWorkspaceManagerConfiguration(string workspaceManagerConfigurationName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetWorkspaceManagerConfiguration(workspaceResourceIdentifier, workspaceManagerConfigurationName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWorkspaceManagerGroups(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual WorkspaceManagerGroupCollection GetWorkspaceManagerGroups()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetWorkspaceManagerGroups(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWorkspaceManagerGroupAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<WorkspaceManagerGroupResource>> GetWorkspaceManagerGroupAsync(string workspaceManagerGroupName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetWorkspaceManagerGroupAsync(workspaceResourceIdentifier, workspaceManagerGroupName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWorkspaceManagerGroup(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<WorkspaceManagerGroupResource> GetWorkspaceManagerGroup(string workspaceManagerGroupName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetWorkspaceManagerGroup(workspaceResourceIdentifier, workspaceManagerGroupName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWorkspaceManagerMembers(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual WorkspaceManagerMemberCollection GetWorkspaceManagerMembers()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetWorkspaceManagerMembers(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWorkspaceManagerMemberAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<WorkspaceManagerMemberResource>> GetWorkspaceManagerMemberAsync(string workspaceManagerMemberName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetWorkspaceManagerMemberAsync(workspaceResourceIdentifier, workspaceManagerMemberName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWorkspaceManagerMember(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<WorkspaceManagerMemberResource> GetWorkspaceManagerMember(string workspaceManagerMemberName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetWorkspaceManagerMember(workspaceResourceIdentifier, workspaceManagerMemberName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsDataConnectorDefinitions(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsDataConnectorDefinitionCollection GetSecurityInsightsDataConnectorDefinitions()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsDataConnectorDefinitions(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsDataConnectorDefinitionAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsDataConnectorDefinitionResource>> GetSecurityInsightsDataConnectorDefinitionAsync(string dataConnectorDefinitionName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsDataConnectorDefinitionAsync(workspaceResourceIdentifier, dataConnectorDefinitionName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsDataConnectorDefinition(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsDataConnectorDefinitionResource> GetSecurityInsightsDataConnectorDefinition(string dataConnectorDefinitionName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsDataConnectorDefinition(workspaceResourceIdentifier, dataConnectorDefinitionName, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsDataConnectors(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual SecurityInsightsDataConnectorCollection GetSecurityInsightsDataConnectors()
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsDataConnectors(workspaceResourceIdentifier) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsDataConnectorAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SecurityInsightsDataConnectorResource>> GetSecurityInsightsDataConnectorAsync(string dataConnectorId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsDataConnectorAsync(workspaceResourceIdentifier, dataConnectorId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetSecurityInsightsDataConnector(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsDataConnectorResource> GetSecurityInsightsDataConnector(string dataConnectorId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetSecurityInsightsDataConnector(workspaceResourceIdentifier, dataConnectorId, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetGeodataByIPAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<EnrichmentIpGeodata>> GetGeodataByIPAsync(EnrichmentType enrichmentType, EnrichmentIPAddressContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetGeodataByIpAsync(workspaceResourceIdentifier, enrichmentType, content, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetGeodataByIP(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<EnrichmentIpGeodata> GetGeodataByIP(EnrichmentType enrichmentType, EnrichmentIPAddressContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetGeodataByIp(workspaceResourceIdentifier, enrichmentType, content, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWhoisByDomainAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<EnrichmentDomainWhois>> GetWhoisByDomainAsync(EnrichmentType enrichmentType, EnrichmentDomainContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetDomainWhoisInformationAsync(workspaceResourceIdentifier, enrichmentType, content, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetWhoisByDomain(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<EnrichmentDomainWhois> GetWhoisByDomain(EnrichmentType enrichmentType, EnrichmentDomainContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetDomainWhoisInformation(workspaceResourceIdentifier, enrichmentType, content, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetRepositoriesSourceControlsAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual AsyncPageable<SourceControlRepo> GetRepositoriesSourceControlsAsync(RepositoryAccessProperties repositoryAccess, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetRepositoriesAsync(workspaceResourceIdentifier, repositoryAccess, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetRepositoriesSourceControls(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Pageable<SourceControlRepo> GetRepositoriesSourceControls(RepositoryAccessProperties repositoryAccess, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetRepositories(workspaceResourceIdentifier, repositoryAccess, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.QueryThreatIntelligenceIndicatorsAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual AsyncPageable<SecurityInsightsThreatIntelligenceIndicatorResource> QueryThreatIntelligenceIndicatorsAsync(ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.QueryThreatIntelligenceIndicatorsAsync(workspaceResourceIdentifier, threatIntelligenceFilteringCriteria, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.QueryThreatIntelligenceIndicators(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Pageable<SecurityInsightsThreatIntelligenceIndicatorResource> QueryThreatIntelligenceIndicators(ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.QueryThreatIntelligenceIndicators(workspaceResourceIdentifier, threatIntelligenceFilteringCriteria, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetAllThreatIntelligenceIndicatorMetricsAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual AsyncPageable<ThreatIntelligenceMetrics> GetAllThreatIntelligenceIndicatorMetricsAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetAllThreatIntelligenceIndicatorMetricsAsync(workspaceResourceIdentifier, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.GetAllThreatIntelligenceIndicatorMetrics(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Pageable<ThreatIntelligenceMetrics> GetAllThreatIntelligenceIndicatorMetrics(CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.GetAllThreatIntelligenceIndicatorMetrics(workspaceResourceIdentifier, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.CountThreatIntelligenceAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<ThreatIntelligenceCount>> CountThreatIntelligenceAsync(ThreatIntelligenceType tiType, ThreatIntelligenceCountQuery query = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.CountAsync(workspaceResourceIdentifier, tiType, query, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.CountThreatIntelligence(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<ThreatIntelligenceCount> CountThreatIntelligence(ThreatIntelligenceType tiType, ThreatIntelligenceCountQuery query = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.Count(workspaceResourceIdentifier, tiType, query, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.QueryThreatIntelligencesAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual AsyncPageable<ThreatIntelligenceObject> QueryThreatIntelligencesAsync(ThreatIntelligenceType tiType, ThreatIntelligenceQuery query = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.QueryAsync(workspaceResourceIdentifier, tiType, query, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.QueryThreatIntelligences(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Pageable<ThreatIntelligenceObject> QueryThreatIntelligences(ThreatIntelligenceType tiType, ThreatIntelligenceQuery query = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.Query(workspaceResourceIdentifier, tiType, query, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.PostDataConnectorsCheckRequirementAsync(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<DataConnectorRequirementsState>> PostDataConnectorsCheckRequirementAsync(Models.DataConnectorsCheckRequirements dataConnectorsCheckRequirements, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.PostAsync(workspaceResourceIdentifier, dataConnectorsCheckRequirements, cancellationToken) instead.");

        /// <summary>
        /// Obsolete shim. Call ArmClient.PostDataConnectorsCheckRequirement(...) instead.
        /// </summary>
        [ForwardsClientCalls]
        public virtual Response<DataConnectorRequirementsState> PostDataConnectorsCheckRequirement(Models.DataConnectorsCheckRequirements dataConnectorsCheckRequirements, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedPrefix + "Call ArmClient.Post(workspaceResourceIdentifier, dataConnectorsCheckRequirements, cancellationToken) instead.");
    }
}
