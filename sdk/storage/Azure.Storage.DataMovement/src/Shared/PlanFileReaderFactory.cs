// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    internal class PlanFileReaderFactory
    {
        private readonly string _planFolderPath;

        public PlanFileReaderFactory(string planFolderPath)
        {
            _planFolderPath = planFolderPath;
        }

        public PlanFileReader BuildPlanJobWriterFactory()
        {
            return new PlanFileReader(_planFolderPath);
        }
    }
}
