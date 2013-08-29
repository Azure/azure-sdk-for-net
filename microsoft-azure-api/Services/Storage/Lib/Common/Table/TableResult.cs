// -----------------------------------------------------------------------------------------
// <copyright file="TableResult.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the result of a table operation.
    /// </summary>
    /// <remarks>The <see cref="TableResult"/> class encapsulates the HTTP response and any table entity results returned by the Storage Service REST API operation called for a particular <see cref="TableOperation"/>.</remarks>
    public sealed class TableResult
    {
        /// <summary>
        /// Gets or sets the result returned by the <see cref="TableOperation"/> as an <see cref="object"/>.
        /// </summary>
        /// <value>The result of the table operation as an <see cref="object"/>.</value>
        public object Result { get; set; }

        /// <summary>
        /// Gets or sets the HTTP status code returned by a <see cref="TableOperation"/> request.
        /// </summary>
        /// <value>The HTTP status code returned by a <see cref="TableOperation"/> request.</value>
        public int HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the ETag returned with the <see cref="TableOperation"/> request results.
        /// </summary>
        /// <value>The ETag returned with the <see cref="TableOperation"/> request results.</value>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Etag", Justification = "Reviewed: Etag can be used for identifier names.")]
        public string Etag { get; set; }
    }
}
