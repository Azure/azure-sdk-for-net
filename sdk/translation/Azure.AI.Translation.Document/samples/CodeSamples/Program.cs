// <copyright file="SampleCheckDocumentStatuses.cs" company="Microsoft Corporation">
// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocumentTranslatorSamples
{
    public class SamplesMain
    {
        public async static Task Main(string[] args)
        {
            await SampleListAllSubmittedJobs.RunSampleAsync().ConfigureAwait(false);
        }
    }
}
