// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;

    public partial interface IDocumentsOperations
    {
        /// <summary>
        /// Retrieves a document from the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/>
        /// </summary>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will be missing from the
        /// returned document.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// Response containing the document.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Get, GetAsync, and GetWithHttpMessagesAsync methods make a best-effort
        /// attempt to map JSON types in the response payload to .NET types. This mapping does not have the benefit of
        /// precise type information from the index, so the mapping is not always correct. In particular, be aware of
        /// the following cases:
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Any numeric value without a decimal point will be deserialized to System.Int64 (long in C#).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Special double-precision floating point values such as NaN and Infinity will be deserialized as type
        /// System.String rather than System.Double.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Any string field with a value formatted like a DateTimeOffset will be deserialized incorrectly. We
        /// recommend storing such values in Edm.DateTimeOffset fields rather than Edm.String fields.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Any Edm.DateTimeOffset field will be deserialized as a System.DateTimeOffset, not System.DateTime.
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        Task<AzureOperationResponse<Document>> GetWithHttpMessagesAsync(
            string key, 
            IEnumerable<string> selectedFields,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null, 
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves a document from the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will have null or default as its
        /// corresponding property value in the returned object.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// Response containing the document.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Get, GetAsync, and GetWithHttpMessagesAsync methods support mapping of Azure
        /// Search field types to .NET types via the type parameter T. Note that all Azure Search field types except
        /// collections are nullable, so primitive types always map to nullable types. The type mapping is as follows:
        /// <list type="table">
        /// <listheader>
        /// <term>Azure Search field type</term>
        /// <description>.NET type</description>
        /// </listheader>
        /// <item>
        /// <term>Edm.String</term>
        /// <description>System.String (string in C#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.String)</term>
        /// <description>IEnumerable&lt;System.String&gt;</description>
        /// </item>
        /// <item>
        /// <term>Edm.Boolean</term>
        /// <description>System.Nullable&lt;System.Boolean&gt; (bool? in C#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Double</term>
        /// <description>System.Nullable&lt;System.Double&gt; (double? in C#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Int32</term>
        /// <description>System.Nullable&lt;System.Int32&gt; (int? in C#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Int64</term>
        /// <description>System.Nullable&lt;System.Int64&gt; (long? in C#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.DateTimeOffset</term>
        /// <description>
        /// System.Nullable&lt;System.DateTimeOffset&gt; (DateTimeOffset? in C#) or
        /// System.Nullable&lt;System.DateTime&gt; (DateTime? in C#). Both types work, although we recommend using
        /// DateTimeOffset. When retrieving documents, DateTime values will always be in UTC. When indexing documents,
        /// DateTime values are interpreted as follows:
        /// <list type="table">
        /// <item>
        /// <term>UTC DateTime</term>
        /// <description>Sent as-is to the index.</description>
        /// </item>
        /// <item>
        /// <term>Local DateTime</term>
        /// <description>Converted to UTC before being sent to the index.</description>
        /// </item>
        /// <item>
        /// <term>DateTime with unspecified time zone</term>
        /// <description>Assumed to be UTC and sent as-is to the index.</description>
        /// </item>
        /// </list>
        /// </description>
        /// </item>
        /// <item>
        /// <term>Edm.GeographyPoint</term>
        /// <description><c cref="Microsoft.Spatial.GeographyPoint">Microsoft.Spatial.GeographyPoint</c></description>
        /// </item>
        /// </list> 
        /// </remarks>
        Task<AzureOperationResponse<T>> GetWithHttpMessagesAsync<T>(
            string key,
            IEnumerable<string> selectedFields,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class;
    }
}
