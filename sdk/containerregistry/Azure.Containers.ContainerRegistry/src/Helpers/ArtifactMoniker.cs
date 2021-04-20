// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// </summary>

    internal class ArtifactMoniker
    {
        /// <summary>
        /// </summary>
        /// <param name="moniker"></param>
#pragma warning disable CA1801 // Review unused parameters
        public ArtifactMoniker(string moniker)
#pragma warning restore CA1801 // Review unused parameters
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="moniker"></param>
        /// <returns></returns>
        public static ArtifactMoniker Parse(string moniker)
        {
            return new ArtifactMoniker(moniker);
        }

        /// <summary>
        /// </summary>
        public virtual string LoginServer { get; }

        /// <summary>
        /// </summary>
        public virtual string FullyQualifiedRegistryName => LoginServer;

        /// <summary>
        /// </summary>
        public virtual string RegistryName { get; }

        /// <summary>
        /// </summary>
        public virtual string RepositoryName { get; }

        /// <summary>
        /// </summary>
        public virtual string Digest { get; }

        /// <summary>
        /// </summary>
        public virtual string Tag { get; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
