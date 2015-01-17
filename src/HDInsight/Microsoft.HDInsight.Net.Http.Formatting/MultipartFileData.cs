// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System.Net.Http.Headers;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    internal class MultipartFileData
    {
        public MultipartFileData(HttpContentHeaders headers, string localFileName)
        {
            if (headers == null)
            {
                throw Error.ArgumentNull("headers");
            }

            if (localFileName == null)
            {
                throw Error.ArgumentNull("localFileName");
            }

            this.Headers = headers;
            this.LocalFileName = localFileName;
        }

        public HttpContentHeaders Headers { get; private set; }

        public string LocalFileName { get; private set; }
    }
}
