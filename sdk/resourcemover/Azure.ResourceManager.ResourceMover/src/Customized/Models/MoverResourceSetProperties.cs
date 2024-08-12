// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines the move collection properties. </summary>
    public partial class MoverResourceSetProperties
    {
        /// <summary> Initializes a new instance of MoverResourceSetProperties. </summary>
        /// <param name="sourceRegion"> Gets or sets the source region. </param>
        /// <param name="targetRegion"> Gets or sets the target region. </param>
        public MoverResourceSetProperties(AzureLocation sourceRegion, AzureLocation targetRegion) : this()
        {
            SourceLocation = sourceRegion;
            TargetLocation = targetRegion;
        }

        /// <summary> Gets or sets the source region. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureLocation SourceRegion
        {
            get { return SourceLocation ?? default; }

            set { SourceLocation = value; }
        }

        /// <summary> Gets or sets the target region. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureLocation TargetRegion
        {
            get { return TargetLocation ?? default; }

            set { TargetLocation = value; }
        }
    }
}
