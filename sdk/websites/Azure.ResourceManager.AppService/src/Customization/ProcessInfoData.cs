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
    /// <summary>
    /// A class representing the ProcessInfo data model.
    /// Process Information.
    /// </summary>
    public partial class ProcessInfoData : ResourceData
    {
        /// <summary> Thread list. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ProcessThreadInfo> Threads
        {
            get
            {
                List<ProcessThreadInfo> threads = new List<ProcessThreadInfo>();
                foreach (WebAppProcessThreadProperties thread in ProcessThreads)
                {
                    ProcessThreadInfo processThread = new ProcessThreadInfo(default, default, default, default, thread.Id, thread.Href.AbsoluteUri, default, default, default, default, default, default, default, default, thread.State, default, default, new Dictionary<string, BinaryData>());
                    threads.Add(processThread);
                }
                return threads;
            }
        }
    }
}
