// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
#if NETCORE
using Microsoft.Azure.Common.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Rest;

namespace Microsoft.Azure
{

    /// <summary>
    /// Credentials using a management certificate to authorize requests.
    /// </summary>
    public sealed class CertificateCloudCredentials
        : SubscriptionCloudCredentials
    {
        // The Microsoft Azure Subscription ID.
        private readonly string _subscriptionId = null;

        /// <summary>
        /// Gets subscription ID which uniquely identifies Microsoft Azure 
        /// subscription. The subscription ID forms part of the URI for 
        /// every call that you make to the Service Management API.
        /// </summary>
        public override string SubscriptionId
        {
            get { return _subscriptionId; }
        }

        /// <summary>
        /// The Microsoft Azure Service Management API use mutual authentication
        /// of management certificates over SSL to ensure that a request made
        /// to the service is secure. No anonymous requests are allowed.
        /// </summary>
        public X509Certificate2 ManagementCertificate { get; private set; }

        /// <summary>
        /// Initializes a new instance of the CertificateCloudCredentials
        /// class.
        /// </summary>
        /// <param name="subscriptionId">The Subscription ID.</param>
        /// <param name="managementCertificate">
        /// The management certificate.
        /// </param>
        public CertificateCloudCredentials(string subscriptionId, X509Certificate2 managementCertificate)
        {
            if (string.IsNullOrEmpty(subscriptionId))
            {
                throw new ArgumentNullException("subscriptionId");
            }
            else if (managementCertificate == null)
            {
                throw new ArgumentNullException("managementCertificate");
            }

            _subscriptionId = subscriptionId;
            ManagementCertificate = managementCertificate;
        }


        /// <summary>
        /// Attempt to create certificate credentials from a collection of
        /// settings.
        /// </summary>
        /// <param name="settings">The settings to use.</param>
        /// <returns>
        /// CertificateCloudCredentials is created, null otherwise.
        /// </returns>
        [Obsolete("Deprecated method. Use public constructor instead.")]
        public static CertificateCloudCredentials Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            X509Certificate2 certificate = GetCertificate(settings, "ManagementCertificate", false);
            if (settings.ContainsKey("SubscriptionId"))
            {
                return new CertificateCloudCredentials(settings["SubscriptionId"].ToString(), certificate);
            }

            return null;
        }

        private static X509Certificate2 GetCertificate(IDictionary<string, object> parameters, 
            string name, bool isRequired = true)
        {
            if (isRequired && !parameters.ContainsKey(name))
            {
                throw new ArgumentException(name);
            }

            object value = null;
            if (parameters.ContainsKey(name))
            {
                value = parameters[name];
            }

            X509Certificate2 certificate = value as X509Certificate2;
            if (certificate == null)
            {
                // Try to load the value as a serialized certificate
                byte[] bytes = value as byte[];
                string text = value as string;
                if (bytes == null && text != null)
                {
                    bytes = Convert.FromBase64String(text);
                }
                if (bytes != null)
                {
                    certificate = GetCertificate(bytes);
                }

                // Try to load the value as a thumbprint from the store
                if (certificate == null && !string.IsNullOrEmpty(text))
                {
                    certificate =
                        GetCertificateFromStore(text, StoreLocation.CurrentUser) ??
                        GetCertificateFromStore(text, StoreLocation.LocalMachine);
                }
            }

            if (isRequired && certificate == null)
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentNullException(name);
                }

                string message =
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.CouldNotConvertToCertificateType,
                        name,
                        value == null ? "(null)" : value.ToString(),
                        typeof(X509Certificate2).FullName);
                throw new FormatException(message);
            }

            return certificate;
        }

        private static X509Certificate2 GetCertificate(byte[] bytes)
        {
            try
            {
                return new X509Certificate2(bytes);
            }
            catch
            {
            }
            return null;
        }

        private static X509Certificate2 GetCertificateFromStore(string thumbprint, StoreLocation location)
        {
            if (thumbprint != null)
            {
                X509Store store = null;
                try
                {
                    store = new X509Store(StoreName.My, location);
                    store.Open(OpenFlags.ReadOnly);
                    X509Certificate2Collection certificates = store.Certificates.Find(X509FindType.FindByThumbprint, 
                        thumbprint, false);
                    if (certificates.Count > 0)
                    {
                        return certificates[0];
                    }
                }
                catch
                {
                }
                finally
                {
                    if (store != null)
                    {
                        store.Close();
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// Initialize a ServiceClient instance to process credentials.
        /// </summary>
        /// <typeparam name="T">Type of ServiceClient.</typeparam>
        /// <param name="client">The ServiceClient.</param>
        /// <remarks>
        /// This will add a certificate to the shared root WebRequestHandler in
        /// the ServiceClient's HttpClient handler pipeline.
        /// </remarks>
        public override void InitializeServiceClient<T>(ServiceClient<T> client)
        {
            WebRequestHandler handler = client.HttpPipelines.OfType<WebRequestHandler>().FirstOrDefault();
            if (handler == null)
            {
                throw new PlatformNotSupportedException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.CertificateCloudCredentials_InitializeServiceClient_NoWebRequestHandler,
                        client.GetType().Name,
                        typeof(WebRequestHandler).Name));
            }
            
            handler.ClientCertificates.Add(ManagementCertificate);
        }
    }
}

#endif

#if PORTABLE
namespace Microsoft.Azure
{

    /// <summary>
    /// Credentials using a management certificate to authorize requests.
    /// </summary>
    public sealed class CertificateCloudCredentials
        : SubscriptionCloudCredentials
    {
        // The Microsoft Azure Subscription ID.
        private readonly string _subscriptionId = null;

        /// <summary>
        /// Gets subscription ID which uniquely identifies Microsoft Azure 
        /// subscription. The subscription ID forms part of the URI for 
        /// every call that you make to the Service Management API.
        /// </summary>
        public override string SubscriptionId
        {
            get { return _subscriptionId; }
        }

        /// <summary>
        /// Create certificate credentials for the given subscription.
        /// To use certificate credentials on portable devices, you must use
        /// the CertificateEnrollmentManager to associate your certificate in pfx format with
        /// a service client
        /// </summary>
        /// <example>
        /// Import certificate and associate it with a service client
        /// <code>
        ///    CertificateEnrollmentManager.ImportPfxDataAsync(_certificateString, 
        ///        _certificatePassword, ExportOption.NotExportable, KeyProtectionLevel.NoConsent, 
        ///        InstallOptions.None,"friendly_name").AsTask().Wait();
        ///
        ///    var credentials = new CertificateCloudCredentials(_subscription);
        ///
        ///    using (ManagementClient client = CloudContext.Clients.CreateManagementClient(credentials))
        ///    { ... }
        ///  </code>
        /// </example>
        /// <param name="subscriptionId">The subscription ID.</param>
        public CertificateCloudCredentials(string subscriptionId)
        {
            this._subscriptionId = subscriptionId;
        }
    }
}

#endif