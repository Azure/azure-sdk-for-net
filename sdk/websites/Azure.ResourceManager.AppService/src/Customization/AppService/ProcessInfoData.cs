// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService
{
    public partial class ProcessInfoData : ResourceData
    {
        /// <summary> Thread list. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ProcessThreadInfo> Threads
        {
            get
            {
                List<ProcessThreadInfo> threads = new List<ProcessThreadInfo>();
                foreach (WebAppProcessThreadInfo thread in ProcessThreads)
                {
                    ProcessThreadInfo processThread = new ProcessThreadInfo(thread);
                    threads.Add(processThread);
                }
                return threads;
            }
        }
    }
}
