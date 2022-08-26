// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using Azure.Core;
using Azure.Compute.Batch.Customizations;

namespace Azure.Compute.Batch
{
    public class BatchServiceClient
    {
        public virtual Uri BatchUrl { get; set; }

        internal virtual BatchRest batchRest { get; set; }
        /*
        private AccountRest accountRest;
        private ApplicationRest applicationRest;
        private CertificateRest certificateRest;
        private ComputeNodeRest computeNodeRest;
        private ComputeNodeExtensionRest computeNodeExtensionRest;
        private FileRest fileRest;
        private JobRest jobRest;
        private JobScheduleRest jobScheduleRest;
        private PoolRest poolRest;
        private TaskRest taskRest;

        #region Subclient Properties

        public AccountRestClient AccountClient
        {
            get
            {
                if (accountClient == null)
                {
                    accountClient = CreateAccountClient();
                }

                return accountClient;
            }
        }

        public ApplicationRest ApplicationClient
        {
            get
            {
                if (applicationClient == null)
                {
                    applicationClient = CreateApplicationClient();
                }

                return applicationClient;
            }
        }

        public CertificateClient CertificateClient
        {
            get
            {
                if (certificateClient == null)
                {
                    certificateClient = CreateCertificateClient();
                }

                return certificateClient;
            }
        }

        public ComputeNodeClient ComputeNodeClient
        {
            get
            {
                if (computeNodeClient == null)
                {
                    computeNodeClient = CreateComputeNodeClient();
                }

                return computeNodeClient;
            }
        }

        public ComputeNodeExtensionClient ComputeNodeExtensionClient
        {
            get
            {
                if (computeNodeExtensionClient == null)
                {
                    computeNodeExtensionClient = CreateComputeNodeExtensionClient();
                }

                return computeNodeExtensionClient;
            }
        }

        public FileClient FileClient
        {
            get
            {
                if (fileClient == null)
                {
                    fileClient = CreateFileClient();
                }

                return fileClient;
            }
        }

        public JobClient JobClient
        {
            get
            {
                if (jobClient == null)
                {
                    jobClient = CreateJobClient();
                }

                return jobClient;
            }
        }

        public JobScheduleClient JobScheduleClient
        {
            get
            {
                if (jobScheduleClient == null)
                {
                    jobScheduleClient = CreateJobScheduleClient();
                }

                return jobScheduleClient;
            }
        }

        public PoolClient PoolClient
        {
            get
            {
                if (poolClient == null)
                {
                    poolClient = CreatePoolClient();
                }

                return poolClient;
            }
        }

        public TaskClient TaskClient
        {
            get
            {
                if (taskClient == null)
                {
                    taskClient = CreateTaskClient();
                }

                return taskClient;
            }
        }

        #endregion Subclient Properties
        */

        protected BatchServiceClient() { }

        public BatchServiceClient(Uri batchUrl, TokenCredential credential, BatchClientOptions options = null)
        {
             BatchUrl = batchUrl;
             batchRest = new BatchRest(credential, options);
        }

        #region Subclient Factories

        public virtual AccountClient CreateAccountClient()
        {
            return new AccountClient(this);
        }

        public virtual ApplicationClient CreateApplicationClient()
        {
            return new ApplicationClient(this);
        }

        public virtual CertificateClient CreateCertificateClient()
        {
            return new CertificateClient(this);
        }

        public virtual ComputeNodeClient CreateComputeNodeClient()
        {
            return new ComputeNodeClient(this);
        }

        public virtual ComputeNodeExtensionClient CreateComputeNodeExtensionClient()
        {
            return new ComputeNodeExtensionClient(this);
        }

        public virtual FileClient CreateFileClient()
        {
            return new FileClient(this);
        }

        public virtual JobClient CreateJobClient()
        {
            return new JobClient(this);
        }

        public virtual JobScheduleClient CreateJobScheduleClient()
        {
            return new JobScheduleClient(this);
        }

        public virtual PoolClient CreatePoolClient()
        {
            return new PoolClient(this);
        }

        public virtual TaskClient CreateTaskClient()
        {
            return new TaskClient(this);
        }

        #endregion Subclient Factories
    }
}
