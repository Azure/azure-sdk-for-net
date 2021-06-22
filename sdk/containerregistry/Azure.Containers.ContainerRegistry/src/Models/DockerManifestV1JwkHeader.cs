// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.ResumableStorage
{
    [CodeGenModel("JWKHeader")]
    internal sealed partial class DockerManifestV1JwkHeader
    {
        /// <summary> Initializes a new instance of DockerManifestV1JwkHeader. </summary>
        internal DockerManifestV1JwkHeader()
        {
        }

        /// <summary> Initializes a new instance of DockerManifestV1JwkHeader. </summary>
        /// <param name="crv"> crv value. </param>
        /// <param name="kid"> kid value. </param>
        /// <param name="kty"> kty value. </param>
        /// <param name="x"> x value. </param>
        /// <param name="y"> y value. </param>
        internal DockerManifestV1JwkHeader(string crv, string kid, string kty, string x, string y)
        {
            Crv = crv;
            Kid = kid;
            Kty = kty;
            X = x;
            Y = y;
        }

        /// <summary> crv value. </summary>
        public string Crv { get;  }
        /// <summary> kid value. </summary>
        public string Kid { get;  }
        /// <summary> kty value. </summary>
        public string Kty { get;  }
        /// <summary> x value. </summary>
        public string X { get;  }
        /// <summary> y value. </summary>
        public string Y { get;  }
    }
}
