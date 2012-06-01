// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Xml;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    ///   Represents a collection of Jobs
    /// </summary>
    public class JobCollection : BaseCloudCollection<IJob>
    {
        private const string JobSet = "Jobs";
        private readonly CloudMediaContext _cloudMediaContext;

        internal JobCollection(CloudMediaContext cloudMediaContext)
            : base(cloudMediaContext.DataContext, cloudMediaContext.DataContext.CreateQuery<JobData>(JobSet))
        {
            _cloudMediaContext = cloudMediaContext;
        }

        public IJob Create(string name)
        {
            JobData job = new JobData { Name = name };
            job.InitCloudMediaContext(_cloudMediaContext);
            return job;
        }
        public IJob Create(string name,int priority)
        {
            JobData job = new JobData { Name = name ,Priority = priority};
            job.InitCloudMediaContext(_cloudMediaContext);
            return job;
        }

    }
}
