// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Backward-compat Uri constructor overloads are grouped to keep related shims together.

using System;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore URI constructor overloads whose legacy parameter shapes differ from
    // the discriminator-first constructors emitted by TypeSpec.
    public partial class FixedInputData
    {
        /// <summary> Initializes a new instance of <see cref="FixedInputData"/>. </summary>
        public FixedInputData(JobInputType jobInputType, Uri uri) : base(MonitoringInputDataType.Fixed, jobInputType, uri)
        {
        }
    }

    public partial class MachineLearningBuildContext
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningBuildContext"/>. </summary>
        public MachineLearningBuildContext(Uri contextUri)
        {
            ContextUri = contextUri;
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningBuildContext"/>. </summary>
        public MachineLearningBuildContext(string contextUri) : this(contextUri is null ? null : new Uri(contextUri))
        {
        }
    }

    public partial class MachineLearningCustomModelJobInput
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningCustomModelJobInput"/>. </summary>
        public MachineLearningCustomModelJobInput(Uri uri) : base(JobInputType.CustomModel)
        {
            Uri = uri;
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningCustomModelJobInput"/>. </summary>
        public MachineLearningCustomModelJobInput(string uri) : this(uri is null ? null : new Uri(uri))
        {
        }
    }

    public partial class MachineLearningDataVersionProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningDataVersionProperties"/>. </summary>
        public MachineLearningDataVersionProperties(Uri dataUri) : this(default, dataUri)
        {
        }
    }

    public partial class MachineLearningFlowModelJobInput
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningFlowModelJobInput"/>. </summary>
        public MachineLearningFlowModelJobInput(Uri uri) : base(JobInputType.MlflowModel)
        {
            Uri = uri;
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningFlowModelJobInput"/>. </summary>
        public MachineLearningFlowModelJobInput(string uri) : this(uri is null ? null : new Uri(uri))
        {
        }
    }

    public partial class MachineLearningTable
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningTable"/>. </summary>
        public MachineLearningTable(Uri dataUri) : base(MachineLearningDataType.Mltable, dataUri)
        {
        }
    }

    public partial class MachineLearningTableJobInput
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningTableJobInput"/>. </summary>
        public MachineLearningTableJobInput(Uri uri) : base(JobInputType.Mltable)
        {
            Uri = uri;
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningTableJobInput"/>. </summary>
        public MachineLearningTableJobInput(string uri) : this(uri is null ? null : new Uri(uri))
        {
        }
    }

    public partial class MachineLearningTritonModelJobInput
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningTritonModelJobInput"/>. </summary>
        public MachineLearningTritonModelJobInput(Uri uri) : base(JobInputType.TritonModel)
        {
            Uri = uri;
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningTritonModelJobInput"/>. </summary>
        public MachineLearningTritonModelJobInput(string uri) : this(uri is null ? null : new Uri(uri))
        {
        }
    }

    public partial class MachineLearningUriFileDataVersion
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningUriFileDataVersion"/>. </summary>
        public MachineLearningUriFileDataVersion(Uri dataUri) : base(MachineLearningDataType.UriFile, dataUri)
        {
        }
    }

    public partial class MachineLearningUriFileJobInput
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningUriFileJobInput"/>. </summary>
        public MachineLearningUriFileJobInput(Uri uri) : base(JobInputType.UriFile)
        {
            Uri = uri;
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningUriFileJobInput"/>. </summary>
        public MachineLearningUriFileJobInput(string uri) : this(uri is null ? null : new Uri(uri))
        {
        }
    }

    public partial class MachineLearningUriFolderDataVersion
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningUriFolderDataVersion"/>. </summary>
        public MachineLearningUriFolderDataVersion(Uri dataUri) : base(MachineLearningDataType.UriFolder, dataUri)
        {
        }
    }

    public partial class MachineLearningUriFolderJobInput
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningUriFolderJobInput"/>. </summary>
        public MachineLearningUriFolderJobInput(Uri uri) : base(JobInputType.UriFolder)
        {
            Uri = uri;
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningUriFolderJobInput"/>. </summary>
        public MachineLearningUriFolderJobInput(string uri) : this(uri is null ? null : new Uri(uri))
        {
        }
    }

    public partial class RollingInputData
    {
        /// <summary> Initializes a new instance of <see cref="RollingInputData"/>. </summary>
        public RollingInputData(JobInputType jobInputType, Uri uri, TimeSpan windowOffset, TimeSpan windowSize) : base(MonitoringInputDataType.Rolling, jobInputType, uri)
        {
            WindowOffset = windowOffset;
            WindowSize = windowSize;
        }

        /// <summary> Initializes a new instance of <see cref="RollingInputData"/>. </summary>
        public RollingInputData(JobInputType jobInputType, string uri, TimeSpan windowOffset, TimeSpan windowSize) : this(jobInputType, uri is null ? null : new Uri(uri), windowOffset, windowSize)
        {
        }
    }

    public partial class StaticInputData
    {
        /// <summary> Initializes a new instance of <see cref="StaticInputData"/>. </summary>
        public StaticInputData(JobInputType jobInputType, Uri uri, DateTimeOffset windowEnd, DateTimeOffset windowStart) : base(MonitoringInputDataType.Static, jobInputType, uri)
        {
            WindowEnd = windowEnd;
            WindowStart = windowStart;
        }

        /// <summary> Initializes a new instance of <see cref="StaticInputData"/>. </summary>
        public StaticInputData(JobInputType jobInputType, string uri, DateTimeOffset windowEnd, DateTimeOffset windowStart) : this(jobInputType, uri is null ? null : new Uri(uri), windowEnd, windowStart)
        {
        }
    }
}

#pragma warning restore SA1402
