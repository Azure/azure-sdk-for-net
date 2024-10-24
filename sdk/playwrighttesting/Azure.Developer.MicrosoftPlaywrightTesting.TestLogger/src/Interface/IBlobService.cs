// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface
{
    internal interface IBlobService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="buffer"></param>
        /// <param name="fileRelativePath"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task UploadBufferAsync(string uri, string buffer, string fileRelativePath);
    }
}
