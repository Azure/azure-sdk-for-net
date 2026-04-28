// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A Class representing an AppServiceCertificateOrder along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct an <see cref="AppServiceCertificateOrderResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetAppServiceCertificateOrderResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetAppServiceCertificateOrder method.
    /// </summary>
    [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AppServiceCertificateOrderResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="AppServiceCertificateOrderResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="certificateOrderName"> The certificateOrderName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string certificateOrderName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly AppServiceCertificateOrderData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.CertificateRegistration/certificateOrders";

        /// <summary> Initializes a new instance of the <see cref="AppServiceCertificateOrderResource"/> class for mocking. </summary>
        protected AppServiceCertificateOrderResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AppServiceCertificateOrderResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal AppServiceCertificateOrderResource(ArmClient client, AppServiceCertificateOrderData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="AppServiceCertificateOrderResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal AppServiceCertificateOrderResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(ResourceType, out string appServiceCertificateOrderApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual AppServiceCertificateOrderData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets a collection of AppServiceCertificateResources in the AppServiceCertificateOrder. </summary>
        /// <returns> An object representing collection of AppServiceCertificateResources and their operations over a AppServiceCertificateResource. </returns>
        public virtual AppServiceCertificateCollection GetAppServiceCertificates()
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get the certificate associated with a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/certificates/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_GetCertificate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<AppServiceCertificateResource>> GetAppServiceCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get the certificate associated with a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/certificates/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_GetCertificate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<AppServiceCertificateResource> GetAppServiceCertificate(string name, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary> Gets a collection of CertificateOrderDetectorResources in the AppServiceCertificateOrder. </summary>
        /// <returns> An object representing collection of CertificateOrderDetectorResources and their operations over a CertificateOrderDetectorResource. </returns>
        public virtual CertificateOrderDetectorCollection GetCertificateOrderDetectors()
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Microsoft.CertificateRegistration call to get a detector response from App Lens.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CertificateOrderDetectorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="detectorName"> The detector name which needs to be run. </param>
        /// <param name="startTime"> The start time for detector response. </param>
        /// <param name="endTime"> The end time for the detector response. </param>
        /// <param name="timeGrain"> The time grain for the detector response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<CertificateOrderDetectorResource>> GetCertificateOrderDetectorAsync(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Microsoft.CertificateRegistration call to get a detector response from App Lens.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CertificateOrderDetectorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="detectorName"> The detector name which needs to be run. </param>
        /// <param name="startTime"> The start time for detector response. </param>
        /// <param name="endTime"> The end time for the detector response. </param>
        /// <param name="timeGrain"> The time grain for the detector response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<CertificateOrderDetectorResource> GetCertificateOrderDetector(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AppServiceCertificateOrderResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AppServiceCertificateOrderResource> Get(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Delete an existing certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Delete an existing certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Create or update a certificate purchase order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Distinguished name to use for the certificate order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<Response<AppServiceCertificateOrderResource>> UpdateAsync(AppServiceCertificateOrderPatch patch, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Create or update a certificate purchase order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Distinguished name to use for the certificate order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Response<AppServiceCertificateOrderResource> Update(AppServiceCertificateOrderPatch patch, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Reissue an existing certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/reissue</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_Reissue</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Parameters for the reissue. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response> ReissueAsync(ReissueCertificateOrderContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Reissue an existing certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/reissue</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_Reissue</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Parameters for the reissue. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response Reissue(ReissueCertificateOrderContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Renew an existing certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/renew</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_Renew</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Renew parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response> RenewAsync(RenewCertificateOrderContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Renew an existing certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/renew</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_Renew</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Renew parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response Renew(RenewCertificateOrderContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Resend certificate email.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/resendEmail</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_ResendEmail</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResendEmailAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Resend certificate email.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/resendEmail</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_ResendEmail</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResendEmail(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Resend domain verification ownership email containing steps on how to verify a domain for a given certificate order
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/resendRequestEmails</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_ResendRequestEmails</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="nameIdentifier"> Email address. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nameIdentifier"/> is null. </exception>
        public virtual async Task<Response> ResendRequestEmailsAsync(AppServiceDomainNameIdentifier nameIdentifier, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Resend domain verification ownership email containing steps on how to verify a domain for a given certificate order
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/resendRequestEmails</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_ResendRequestEmails</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="nameIdentifier"> Email address. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nameIdentifier"/> is null. </exception>
        public virtual Response ResendRequestEmails(AppServiceDomainNameIdentifier nameIdentifier, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// This method is used to obtain the site seal information for an issued certificate. A site seal is a graphic that the certificate purchaser can embed on their web site to show their visitors information about their SSL certificate. If a web site visitor clicks on the site seal image, a pop-up page is displayed that contains detailed information about the SSL certificate. The site seal token is used to link the site seal graphic image to the appropriate certificate details pop-up page display when a user clicks on the site seal. The site seal images are expected to be static images and hosted by the reseller, to minimize delays for customer page load times.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/retrieveSiteSeal</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_RetrieveSiteSeal</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Site seal request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<SiteSeal>> RetrieveSiteSealAsync(SiteSealContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// This method is used to obtain the site seal information for an issued certificate. A site seal is a graphic that the certificate purchaser can embed on their web site to show their visitors information about their SSL certificate. If a web site visitor clicks on the site seal image, a pop-up page is displayed that contains detailed information about the SSL certificate. The site seal token is used to link the site seal graphic image to the appropriate certificate details pop-up page display when a user clicks on the site seal. The site seal images are expected to be static images and hosted by the reseller, to minimize delays for customer page load times.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/retrieveSiteSeal</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_RetrieveSiteSeal</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Site seal request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<SiteSeal> RetrieveSiteSeal(SiteSealContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Verify domain ownership for this certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/verifyDomainOwnership</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_VerifyDomainOwnership</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> VerifyDomainOwnershipAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Verify domain ownership for this certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/verifyDomainOwnership</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_VerifyDomainOwnership</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response VerifyDomainOwnership(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Retrieve the list of certificate actions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{name}/retrieveCertificateActions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_RetrieveCertificateActions</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CertificateOrderAction"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CertificateOrderAction> RetrieveCertificateActionsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Retrieve the list of certificate actions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{name}/retrieveCertificateActions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_RetrieveCertificateActions</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CertificateOrderAction"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CertificateOrderAction> RetrieveCertificateActions(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Retrieve email history.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{name}/retrieveEmailHistory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_RetrieveCertificateEmailHistory</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AppServiceCertificateEmail"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AppServiceCertificateEmail> RetrieveCertificateEmailHistoryAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Retrieve email history.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{name}/retrieveEmailHistory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_RetrieveCertificateEmailHistory</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AppServiceCertificateEmail"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AppServiceCertificateEmail> RetrieveCertificateEmailHistory(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }
    }
}
