// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    internal class PlanJobWriterFactory
    {
        private readonly string _jobId;
        private readonly string _planFolderPath;

        public PlanJobWriterFactory(string jobId, string planFolderPath)
        {
            _jobId = jobId;
            _planFolderPath = planFolderPath;
        }

        public PlanJobWriter BuildPlanJobWriterFactory()
        {
            return new PlanJobWriter(_jobId, _planFolderPath);
        }
    }
}
