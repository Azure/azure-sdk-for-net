//-----------------------------------------------------------------------
// <copyright file="AzureHttpClient.CertificateOperations.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the Certificate operations of AzureHttpClient class.
// </summary>
//-----------------------------------------------------------------------

using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    public partial class AzureHttpClient
    {
        #region Operations on Service Certificates
        /// <summary>
        /// Begins an asychronous operation to list the certificates in a cloud service.
        /// </summary>
        /// <param name="serviceName">The name of the cloud service containing the certificates to list. Required.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a <see cref="ServiceCertificateCollection"/></returns>
        public Task<ServiceCertificateCollection> ListServiceCertificatesAsync(string serviceName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(serviceName, "serviceName");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.ServiceCertificates, serviceName));

            return StartGetTask<ServiceCertificateCollection>(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to get a particular certificate from a cloud service.
        /// </summary>
        /// <param name="serviceName">The name of the cloud service containing the certificate to get. Required.</param>
        /// <param name="thumbprint">The thumbprint of the certificate to get. Required.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a <see cref="X509Certificate2"/></returns>
        public Task<X509Certificate2> GetServiceCertificateAsync(string serviceName, string thumbprint, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(serviceName, "serviceName");
            Validation.ValidateStringArg(thumbprint, "thumbprint");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.ServiceCertificatesAndCertificate, serviceName, _sha1thumbprintAlgorithm, thumbprint));

            return StartGetTask<ServiceCertificateData>(message, token)
                       .ContinueWith<X509Certificate2>((certDataTask) =>
                       {
                           return certDataTask.Result.Certificate;
                       }, token, options, TaskScheduler.Current);

        }

        /// <summary>
        /// Begins an asychronous operation to add a certificate to a cloud service.
        /// </summary>
        /// <param name="serviceName">The name of the cloud service to which to add the certificate. Required.</param>
        /// <param name="certificate">The certificate to add. Required.</param>
        /// <param name="password">The password for the certificate. It the certificate does not require a password, this may be null.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>When the Task representing AddServiceCertificateAsync is complete, and does not throw an exception, the operation is complete. 
        /// There is no need to track the operation Id using GetOperationStatus with this operation.
        /// </remarks>
        public Task<string> AddServiceCertificateAsync(string serviceName, X509Certificate2 certificate, string password, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(serviceName, "serviceName");

            //other params validated here
            AddServiceCertificateInfo info = AddServiceCertificateInfo.Create(certificate, password);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.ServiceCertificates, serviceName), info);

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to delete a certificate from a cloud service.
        /// </summary>
        /// <param name="serviceName">The name of the cloud service from which to delete the certificate. Required.</param>
        /// <param name="thumbprint">The thumbprint of the certificate to delete. Required.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>When the Task representing DeleteServiceCertificateAsync is complete, and does not throw an exception, the operation is complete. 
        /// There is no need to track the operation Id using GetOperationStatus with this operation.
        /// </remarks>
        public Task<string> DeleteServiceCertificateAsync(string serviceName, string thumbprint, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(serviceName, "serviceName");
            Validation.ValidateStringArg(thumbprint, "thumbprint");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Delete, CreateTargetUri(UriFormatStrings.ServiceCertificatesAndCertificate, serviceName, _sha1thumbprintAlgorithm, thumbprint));

            return StartSendTask(message, token);
        }
        #endregion

        #region ManagementCertificates
        /// <summary>
        /// Begins an asychronous operation to add a mangement certificate to a Windows Azure subscription.
        /// </summary>
        /// <param name="certificate">The certificate to add. Required.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>The maximun number of management certificates for any subscription is 10. An attempt to add a certificate that would
        /// exceed this limit will fail.
        /// When the Task representing AddManagementCertificateAsync is complete, and does not throw an exception, the operation is complete. 
        /// There is no need to track the operation Id using GetOperationStatus with this operation.
        /// </remarks>
        public Task<string> AddManagementCertificateAsync(X509Certificate2 certificate, CancellationToken token = default(CancellationToken))
        {
            ManagementCertificateInfo info = ManagementCertificateInfo.Create(certificate);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.ManagementCertificates), info);

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to get a management certificate from the subscription.
        /// </summary>
        /// <param name="thumbprint">The thumbprint of the certificate to get. Required.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a <see cref="ManagementCertificateInfo"/></returns>
        public Task<ManagementCertificateInfo> GetManagementCertificateAsync(string thumbprint, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(thumbprint, "thumbprint");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.ManagementCertificatesAndCertificate, thumbprint));

            return StartGetTask<ManagementCertificateInfo>(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to list the managment certificates in the subscription.
        /// </summary>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a <see cref="ManagementCertificateCollection"/></returns>
        public Task<ManagementCertificateCollection> ListManagementCertificatesAsync(CancellationToken token = default(CancellationToken))
        {
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.ManagementCertificates));

            return StartGetTask<ManagementCertificateCollection>(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to delete a managment certificate.
        /// </summary>
        /// <param name="thumbprint">The thumbprint of the certificate to delete. Required.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>When the Task representing DeleteManagementCertificateAsync is complete, and does not throw an exception, the operation is complete. 
        /// There is no need to track the operation Id using GetOperationStatus with this operation.
        /// </remarks>
        public Task<string> DeleteManagementCertificateAsync(string thumbprint, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(thumbprint, "thumbprint");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Delete, CreateTargetUri(UriFormatStrings.ManagementCertificatesAndCertificate, thumbprint));

            return StartSendTask(message, token);
        }
        #endregion

    }
}