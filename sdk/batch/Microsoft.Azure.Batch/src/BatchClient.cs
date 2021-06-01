// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
﻿
namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Protocol;
    using Rest;

    /// <summary>
    /// The dispose pattern sets all references to null.
    /// Put all references into this box.
    ///
    /// ONLY ACCESS VIA GetStateThrowIfNotOpen() method!
    ///
    /// </summary>
    internal class BatchClientDisposableStateBox
    {
        private readonly BatchClient _parentBatchClient;
        private readonly Lazy<ApplicationOperations> _applicationOperations;
        private readonly Lazy<CertificateOperations> _certificateOperations;
        private readonly Lazy<JobOperations> _jobOperations;
        private readonly Lazy<JobScheduleOperations>  _jobScheduleOperations;
        private readonly Lazy<PoolOperations> _poolOperations;
        private readonly Lazy<Utilities> _utilities;

        public IList<BatchClientBehavior> CustomBehaviors;
        public IProtocolLayer ProtocolLayer;

        public BatchClientDisposableStateBox(BatchClient parentBatchClient)
        {
            this._parentBatchClient = parentBatchClient;
            this._applicationOperations = new Lazy<ApplicationOperations>(() => new ApplicationOperations(this._parentBatchClient, this.CustomBehaviors));
            this._certificateOperations = new Lazy<CertificateOperations>(() => new CertificateOperations(this._parentBatchClient, this.CustomBehaviors));
            this._jobOperations = new Lazy<JobOperations>(() => new JobOperations(this._parentBatchClient, this.CustomBehaviors));
            this._jobScheduleOperations = new Lazy<JobScheduleOperations>(() => new JobScheduleOperations(this._parentBatchClient, this.CustomBehaviors));
            this._poolOperations = new Lazy<PoolOperations>(() => new PoolOperations(this._parentBatchClient, this.CustomBehaviors));
            this._utilities = new Lazy<Utilities>(() => new Utilities(this._parentBatchClient, this.CustomBehaviors));

            this.CustomBehaviors = new List<BatchClientBehavior>();
        }

        public ApplicationOperations ApplicationOperations => this._applicationOperations.Value;
        public CertificateOperations CertificateOperations => this._certificateOperations.Value;
        public JobOperations JobOperations => this._jobOperations.Value;
        public JobScheduleOperations JobScheduleOperations => this._jobScheduleOperations.Value;
        public PoolOperations PoolOperations => this._poolOperations.Value;
        public Utilities Utilities => this._utilities.Value;
    }

    /// <summary>
    /// A client for an Azure Batch account, used to access the Batch service.
    /// </summary>
    public class BatchClient : IDisposable
    {
        private BatchClientDisposableStateBox _disposableStateBox;  // null state box signals that the instance is closed
        private bool _disposed;  // used for dispose pattern
        private readonly object _closeLocker = new object();

#region // constructors

        private BatchClient()
        {
            _disposableStateBox = new BatchClientDisposableStateBox(this);

            //
            // Add custom behaviors which are by default on every batch client
            //
            this.CustomBehaviors.Add(RetryPolicyProvider.ExponentialRetryProvider(TimeSpan.FromSeconds(1), 6));

            //Add default AddTaskResultHandler
            this.CustomBehaviors.Add(new AddTaskCollectionResultHandler(AddTaskCollectionResultHandler.DefaultAddTaskCollectionResultHandler));
        }

        private BatchClient(Auth.BatchSharedKeyCredentials credentials) : this()
        {
            ServiceClientCredentials proxyCredentials = new Protocol.BatchSharedKeyCredential(credentials.AccountName, credentials.KeyValue);
            this.ProtocolLayer = new ProtocolLayer(credentials.BaseUrl, proxyCredentials);
        }

        private BatchClient(Auth.BatchTokenCredentials credentials) : this()
        {
            ServiceClientCredentials proxyCredentials = new TokenCredentials(new BatchTokenProvider(credentials.TokenProvider));
            this.ProtocolLayer = new ProtocolLayer(credentials.BaseUrl, proxyCredentials);
        }

        private BatchClient(Protocol.BatchServiceClient customRestClient)
            : this()
        {
            this.ProtocolLayer = new ProtocolLayer(customRestClient);
        }

        /// <summary>
        /// Holds the protocol layer to be used for this client instance.
        /// This enables "mock"ing the protocol layer for testing.
        /// </summary>
        internal BatchClient(IProtocolLayer protocolLayer)
            : this()
        {
            this.ProtocolLayer = protocolLayer;
        }

#endregion  Constructors

#region IInheritedBehaviors

        /// <summary>
        /// Gets or sets a list of behaviors that modify or customize requests to the Batch service.
        /// </summary>
        /// <remarks>
        /// <para>These behaviors are inherited by child objects.</para>
        /// <para>Modifications are applied in the order of the collection. The last write wins.</para>
        /// </remarks>
        public IList<BatchClientBehavior> CustomBehaviors
        {
            get
            {
                return GetStateThrowIfNotOpen().CustomBehaviors;
            }
            set
            {
                GetStateThrowIfNotOpen().CustomBehaviors = value;
            }
        }

#endregion  IInheritedBehaviors

#region // BatchClient

        /// <summary>
        /// Gets an <see cref="ApplicationOperations"/> for performing application-related operations on the associated account.
        /// </summary>
        public ApplicationOperations ApplicationOperations => GetStateThrowIfNotOpen().ApplicationOperations;

        /// <summary>
        /// Gets a <see cref="CertificateOperations"/> for performing certificate-related operations on the associated account.
        /// </summary>
        public CertificateOperations CertificateOperations => GetStateThrowIfNotOpen().CertificateOperations;

        /// <summary>
        /// Gets a <see cref="JobOperations"/> for performing job-related operations on the associated account.
        /// </summary>
        public JobOperations JobOperations => GetStateThrowIfNotOpen().JobOperations;

        /// <summary>
        /// Gets a <see cref="JobScheduleOperations"/> for performing job schedule-related operations on the associated account.
        /// </summary>
        public JobScheduleOperations JobScheduleOperations => GetStateThrowIfNotOpen().JobScheduleOperations;

        /// <summary>
        /// Gets a <see cref="PoolOperations"/> for performing pool-related operations on the associated account.
        /// </summary>
        public PoolOperations PoolOperations => GetStateThrowIfNotOpen().PoolOperations;

        /// <summary>
        /// Gets a <see cref="Utilities"/> object containing utility methods for orchestrating multiple Batch operations.
        /// </summary>
        public Utilities Utilities => GetStateThrowIfNotOpen().Utilities;

        /// <summary>
        /// Creates an instance of <see cref="BatchClient" />.
        /// </summary>
        /// <param name="credentials">The Batch account credentials.</param>
        /// <returns>An instance of <see cref="Microsoft.Azure.Batch.Protocol.BatchServiceClient"/>.</returns>
        public static BatchClient Open(Auth.BatchSharedKeyCredentials credentials)
        {
            if (null == credentials)
            {
                throw new ArgumentNullException(nameof(credentials));
            }

            return new BatchClient(credentials);
        }

        /// <summary>
        /// Creates an instance of <see cref="BatchClient" />.
        /// </summary>
        /// <param name="credentials">The Azure Active Directory Batch account credentials.</param>
        /// <returns>An instance of <see cref="Microsoft.Azure.Batch.Protocol.BatchServiceClient"/>.</returns>
        public static BatchClient Open(Auth.BatchTokenCredentials credentials)
        {
            if (null == credentials)
            {
                throw new ArgumentNullException(nameof(credentials));
            }

            return new BatchClient(credentials);
        }

        /// <summary>
        /// Blocking call that creates an instance of <see cref="BatchClient"/> associated with the specified <see cref="Microsoft.Azure.Batch.Protocol.BatchServiceClient"/>.
        /// </summary>
        /// <param name="restClient">The instance of <see cref="Microsoft.Azure.Batch.Protocol.BatchServiceClient"/> to use for all calls made to the Batch Service. It will not be disposed when BatchClient is disposed.</param>
        /// <returns>An instance of <see cref="Microsoft.Azure.Batch.Protocol.BatchServiceClient"/>.</returns>
        public static BatchClient Open(Protocol.BatchServiceClient restClient)
        {
            if (null == restClient)
            {
                throw new ArgumentNullException(nameof(restClient));
            }

            return new BatchClient(restClient);
        }

#endregion // BatchClient

#region // IDisposable

        /// <summary>
        /// Releases the unmanaged resources and disposes of the managed resources used by the <see cref="Microsoft.Azure.Batch.BatchClient"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged resources used by the <see cref="BatchClient"/>, and optionally disposes of managed resources.
        /// </summary>
        /// <param name="disposing">Indicates whether the object is being disposed or finalized.  If true, the object is
        /// being disposed and can dispose managed resource.  If false, the object is being finalized and should only
        /// release unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // IDisposable only section

                lock (this._closeLocker)
                {
                    if (this._disposableStateBox != null)
                    {
                        IProtocolLayer localProto = this.ProtocolLayer;
                        localProto.Dispose();

                        this._disposableStateBox = null; // null state box signals that the instance is closed
                    }
                }
            }

            _disposed = true;
        }

#endregion // IDisposable

#region internal/private methods

        /// <summary>
        /// Enforces that current instance is not "close".
        /// All access to disposable state should go through this routine.
        /// </summary>
        /// <returns></returns>
        internal BatchClientDisposableStateBox GetStateThrowIfNotOpen()
        {
            BatchClientDisposableStateBox localState = _disposableStateBox;

            if (null != localState)
            {
                return localState;
            }

            // TODO: BatchException is not yet ready for this... do we need to create simpler BatchExceptions for stuff like this?
            throw new InvalidOperationException(BatchErrorMessages.BatchClientIsClosed);
        }

        /// <summary>
        /// Holds the protocol layer to be used for this client instance.
        /// This enables "mock"ing the protocol layer for testing.
        ///
        /// Since 100% of all calls indirect through this property, it
        /// provides a single place to immediately stop all (new) call attempts
        /// when the underlying BatchClient is closed.
        /// </summary>
        internal IProtocolLayer ProtocolLayer
        {
            get
            {
                IProtocolLayer localProto = GetStateThrowIfNotOpen().ProtocolLayer;

                return localProto;
            }

            private set
            {
                GetStateThrowIfNotOpen().ProtocolLayer = value;
            }
        }

#endregion internal/private methods
    }
}
