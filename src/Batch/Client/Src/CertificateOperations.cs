// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    /// <summary>
    /// Performs certificate-related operations on an Azure Batch account.
    /// </summary>
    public class CertificateOperations : IInheritedBehaviors
    {
        private readonly BatchClient _parentBatchClient;

        private const string KnownCertificateAlgorithm = "sha1";

#region constructors

        private CertificateOperations()
        {
        }

        internal CertificateOperations(BatchClient batchClient, IEnumerable<BatchClientBehavior> inheritedBehaviors)
        {
            _parentBatchClient = batchClient;

            // inherit from instantiating parent
            InheritUtil.InheritClientBehaviorsAndSetPublicProperty(this, inheritedBehaviors);
        }

#endregion constructors

#region IInheritedBehaviors

        private IList<BatchClientBehavior> _customBehaviors;

        /// <summary>
        /// Gets or sets a list of behaviors that modify or customize requests to the Batch service
        /// made via this <see cref="CertificateOperations"/>.
        /// </summary>
        /// <remarks>
        /// <para>These behaviors are inherited by child objects.</para>
        /// <para>Modifications are applied in the order of the collection. The last write wins.</para>
        /// </remarks>
        public IList<BatchClientBehavior> CustomBehaviors
        {
            get
            {
                return _customBehaviors;
            }
            set
            {
                _customBehaviors = value;
            }
        }

#endregion IInheritedBehaviors

#region CertificateOperations

        /// <summary>
        /// Gets the specified <see cref="Certificate"/>.
        /// </summary>
        /// <param name="thumbprintAlgorithm">The algorithm used to derive the <paramref name="thumbprint"/> parameter. This must be sha1.</param>
        /// <param name="thumbprint">The thumbprint of the certificate to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Certificate"/> containing information about the specified certificate in the Azure Batch account.</returns>
        /// <remarks>The get certificate operation runs asynchronously.</remarks>
        public async Task<Certificate> GetCertificateAsync(
            string thumbprintAlgorithm, 
            string thumbprint, 
            DetailLevel detailLevel = null, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors, detailLevel);

            // start operation
            Task<AzureOperationResponse<Models.Certificate, Models.CertificateGetHeaders>> asyncTask = _parentBatchClient.ProtocolLayer.GetCertificate(thumbprintAlgorithm, thumbprint, bhMgr, cancellationToken);

            // wait for operation to complete
            var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // extract results
            Models.Certificate protoCert = response.Body;

            // wrap protocol object
            Certificate omCert = new Certificate(this.ParentBatchClient, protoCert, this.CustomBehaviors);

            return omCert;
        }

        /// <summary>
        /// Gets the specified <see cref="Certificate"/>.
        /// </summary>
        /// <param name="thumbprintAlgorithm">The algorithm used to derive the <paramref name="thumbprint"/> parameter. This must be sha1.</param>
        /// <param name="thumbprint">The thumbprint of the certificate to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>A <see cref="Certificate"/> containing information about the specified certificate in the Azure Batch account.</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetCertificateAsync"/>.</remarks>
        public Certificate GetCertificate(string thumbprintAlgorithm, string thumbprint, DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task<Certificate> asyncTask = GetCertificateAsync(thumbprintAlgorithm, thumbprint, detailLevel, additionalBehaviors))
            {
                Certificate omCert = asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);

                return omCert;
            }
        }

        /// <summary>
        /// Creates a new <see cref="Certificate"/> from a .cer file.
        /// </summary>
        /// <param name="cerFileName">The path to the .cer file.</param>
        /// <returns>A <see cref="Certificate"/> representing a new certificate that has not been added to the Batch service.</returns>
        public Certificate CreateCertificate(string cerFileName)
        {
            if (string.IsNullOrWhiteSpace(cerFileName))
            {
                throw new ArgumentOutOfRangeException("cerFileName");
            }

            Models.CertificateAddParameter protoCert = GetCertificateInfo(cerFileName);
            Certificate omCert = new Certificate(
                this.ParentBatchClient,
                protoCert,
                this.CustomBehaviors);

            return omCert;
        }

        /// <summary>
        /// Creates a new <see cref="Certificate"/> from .cer format data in memory.
        /// </summary>
        /// <param name="cerRawData">The certificate data in .cer format.</param>
        /// <returns>A <see cref="Certificate"/> representing a new certificate that has not been added to the Batch service.</returns>
        public Certificate CreateCertificate(byte[] cerRawData)
        {
            Models.CertificateAddParameter protoCert = GetCertificateInfo(cerRawData);
            Certificate omCert = new Certificate(this.ParentBatchClient, protoCert, this.CustomBehaviors);

            return omCert;
        }

        /// <summary>
        /// Creates a new <see cref="Certificate"/> from a .pfx file.
        /// </summary>
        /// <param name="pfxFileName">The path to the .pfx file.</param>
        /// <param name="password">The password to access the certificate private key.</param>
        /// <returns>A <see cref="Certificate"/> representing a new certificate that has not been added to the Batch service.</returns>
        public Certificate CreateCertificate(string pfxFileName, string password)
        {
            if (string.IsNullOrWhiteSpace(pfxFileName))
            {
                throw new ArgumentOutOfRangeException("pfxFileName");
            }

            Models.CertificateAddParameter protoCert = GetCertificateInfo(pfxFileName, password);
            Certificate omCert = new Certificate(this.ParentBatchClient, protoCert, this.CustomBehaviors);

            return omCert;
        }

        /// <summary>
        /// Creates a new <see cref="Certificate"/> from .pfx format data in memory.
        /// </summary>
        /// <param name="pfxRawData">The certificate data in .pfx format.</param>
        /// <param name="password">The password to access the certificate private key.</param>
        /// <returns>A <see cref="Certificate"/> representing a new certificate that has not been added to the Batch service.</returns>
        public Certificate CreateCertificate(byte[] pfxRawData, string password)
        {
            Models.CertificateAddParameter protoCert = GetCertificateInfo(pfxRawData, password);
            Certificate omCert = new Certificate(this.ParentBatchClient, protoCert, this.CustomBehaviors);

            return omCert;
        }

        #region Private

        private Models.CertificateAddParameter GetCertificateInfo(string pfxFileName, string password)
        {
            byte[] rawData = System.IO.File.ReadAllBytes(pfxFileName);

            return GetCertificateInfo(rawData, password);
        }

        private Models.CertificateAddParameter GetCertificateInfo(byte[] rawData, string password)
        {
            var certificate = new X509Certificate2(rawData, password);

            Models.CertificateAddParameter cert = CreateAddCertificateEntity(rawData, certificate);

            cert.Password = password;
            cert.CertificateFormat = Models.CertificateFormat.Pfx;

            return cert;
        }

        private Models.CertificateAddParameter GetCertificateInfo(string cerFileName)
        {
            byte[] rawData = System.IO.File.ReadAllBytes(cerFileName);

            return GetCertificateInfo(rawData);
        }

        private Models.CertificateAddParameter GetCertificateInfo(byte[] rawData)
        {
            var certificate = new X509Certificate2();
            certificate.Import(rawData);

            Models.CertificateAddParameter cert = CreateAddCertificateEntity(rawData, certificate);

            cert.CertificateFormat = Models.CertificateFormat.Cer;
            return cert;
        }

        private static Models.CertificateAddParameter CreateAddCertificateEntity(byte[] rawData, X509Certificate2 certificate)
        {
            Models.CertificateAddParameter cert = new Models.CertificateAddParameter();
            cert.Thumbprint = certificate.Thumbprint.ToLower();

            if (certificate.SignatureAlgorithm.FriendlyName.Contains(KnownCertificateAlgorithm))
            {
                cert.ThumbprintAlgorithm = KnownCertificateAlgorithm;
            }
            else
            {
                cert.ThumbprintAlgorithm = certificate.SignatureAlgorithm.FriendlyName;
            }
            cert.Data = Convert.ToBase64String(rawData);
            
            return cert;
        }

        #endregion

        /// <summary>
        /// Enumerates the <see cref="Certificate">certificates</see> in the Batch account.
        /// </summary>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{Certificate}"/> that can be used to enumerate certificates asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the certificates are retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; certificates are retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<Certificate> ListCertificates(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            PagedEnumerable<Certificate> enumerable = new PagedEnumerable<Certificate>( // the lamda will be the enumerator factory
                () =>
                {
                    // here is the actual strongly typed enumerator
                    AsyncListCertificatesEnumerator typedEnumerator = new AsyncListCertificatesEnumerator(this, bhMgr, detailLevel);

                    // here is the base
                    PagedEnumeratorBase<Certificate> enumeratorBase = typedEnumerator;

                    return enumeratorBase;
                });

            return enumerable;
        }

        /// <summary>
        /// Deletes the certificate from the Batch account.
        /// </summary>
        /// <param name="thumbprintAlgorithm">The algorithm used to derive the <paramref name="thumbprint"/> parameter. This must be sha1.</param>
        /// <param name="thumbprint">The thumbprint of the certificate to delete.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The delete operation requests that the certificate be deleted.  The request puts the certificate in the <see cref="Common.CertificateState.Deleting"/> state.
        /// The Batch service will perform the actual certificate deletion without any further client action.</para>
        /// <para>You cannot delete a certificate if a resource (pool or compute node) is using it. Before you can delete a certificate, you must therefore make sure that:</para>
        /// <list type="bullet">
        /// <item><description>The certificate is not associated with any pools.</description></item>
        /// <item><description>The certificate is not installed on any compute nodes.  (Even if you remove a certificate from a pool, it is not removed from existing compute nodes in that pool until they restart.)</description></item>
        /// </list>
        /// <para>If you try to delete a certificate that is in use, the deletion fails. The certificate state changes to <see cref="Common.CertificateState.DeleteFailed"/>.
        /// You can use <see cref="CancelDeleteCertificateAsync"/> to set the status back to Active if you decide that you want to continue using the certificate.</para>
        /// <para>The delete operation runs asynchronously.</para>
        /// </remarks>
        public async Task DeleteCertificateAsync(
            string thumbprintAlgorithm, 
            string thumbprint, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = _parentBatchClient.ProtocolLayer.DeleteCertificate(thumbprintAlgorithm, thumbprint, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Deletes the certificate from the Batch account.
        /// </summary>
        /// <param name="thumbprintAlgorithm">The algorithm used to derive the <paramref name="thumbprint"/> parameter. This must be sha1.</param>
        /// <param name="thumbprint">The thumbprint of the certificate to delete.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>The delete operation requests that the certificate be deleted.  The request puts the certificate in the <see cref="Common.CertificateState.Deleting"/> state.
        /// The Batch service will perform the actual certificate deletion without any further client action.</para>
        /// <para>You cannot delete a certificate if a resource (pool or compute node) is using it. Before you can delete a certificate, you must therefore make sure that:</para>
        /// <list type="bullet">
        /// <item><description>The certificate is not associated with any pools.</description></item>
        /// <item><description>The certificate is not installed on any compute nodes.  (Even if you remove a certificate from a pool, it is not removed from existing compute nodes in that pool until they restart.)</description></item>
        /// </list>
        /// <para>If you try to delete a certificate that is in use, the deletion fails. The certificate state changes to <see cref="Common.CertificateState.DeleteFailed"/>.
        /// You can use <see cref="CancelDeleteCertificateAsync"/> to set the status back to Active if you decide that you want to continue using the certificate.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="DeleteCertificateAsync"/>.</para>
        /// </remarks>
        public void DeleteCertificate(string thumbprintAlgorithm, string thumbprint, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task asyncTask = DeleteCertificateAsync(thumbprintAlgorithm, thumbprint, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Cancels a failed deletion of the specified certificate.  This can be done only when
        /// the certificate is in the <see cref="Common.CertificateState.DeleteFailed"/> state, and restores the certificate to the <see cref="Common.CertificateState.Active"/> state.
        /// </summary>
        /// <param name="thumbprintAlgorithm">The algorithm used to derive the <paramref name="thumbprint"/> parameter. This must be sha1.</param>
        /// <param name="thumbprint">The thumbprint of the certificate that failed to delete.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>If you still wish to delete the certificate (instead of returning it to Active), you do not need to cancel
        /// the failed deletion. You must make sure that the certificate is not being used by any resources, and then you
        /// can try again to delete the certificate (see <see cref="DeleteCertificateAsync"/>.</para>
        /// <para>The cancel delete operation runs asynchronously.</para>
        /// </remarks>
        public async Task CancelDeleteCertificateAsync(
            string thumbprintAlgorithm, 
            string thumbprint, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // start operation
            Task asyncTask = _parentBatchClient.ProtocolLayer.CancelDeleteCertificate(thumbprintAlgorithm, thumbprint, bhMgr, cancellationToken);

            // wait for operation complete
            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Cancels a failed deletion of the specified certificate.  This can be done only when
        /// the certificate is in the <see cref="Common.CertificateState.DeleteFailed"/> state, and restores the certificate to the <see cref="Common.CertificateState.Active"/> state.
        /// </summary>
        /// <param name="thumbprintAlgorithm">The algorithm used to derive the <paramref name="thumbprint"/> parameter. This must be sha1.</param>
        /// <param name="thumbprint">The thumbprint of the certificate that failed to delete.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>If you still wish to delete the certificate (instead of returning it to Active), you do not need to cancel
        /// the failed deletion. You must make sure that the certificate is not being used by any resources, and then you
        /// can try again to delete the certificate (see <see cref="DeleteCertificateAsync"/>.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="CancelDeleteCertificateAsync"/>.</para>
        /// </remarks>
        public void CancelDeleteCertificate(string thumbprintAlgorithm, string thumbprint, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task asyncTask = CancelDeleteCertificateAsync(thumbprintAlgorithm, thumbprint, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

#endregion CertificateOperations

#region Internal/private stuff

        /// <summary>
        /// allows child objects to access the protocol wrapper and secrets to make verb calls
        /// </summary>
        internal BatchClient ParentBatchClient { get { return _parentBatchClient; }}

#endregion

    }
}
