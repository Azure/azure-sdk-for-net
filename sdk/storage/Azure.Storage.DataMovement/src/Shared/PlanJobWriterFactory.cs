// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    internal class PlanJobWriterFactory
    {
        private readonly string _transferId;
        private readonly string _planFolderPath;

        public PlanJobWriterFactory(string transferId, string planFolderPath)
        {
            _transferId = transferId;
            _planFolderPath = planFolderPath;
        }

        public PlanJobWriter BuildPlanJobWriterFactory()
        {
            return new PlanJobWriter(_transferId, _planFolderPath);
        }
    }
}
