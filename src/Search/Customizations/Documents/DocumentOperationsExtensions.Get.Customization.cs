// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Search.Models;

namespace Microsoft.Azure.Search
{
    public static partial class DocumentOperationsExtensions
    {
        /// <summary>
        /// Retrieves a document from the Azure Search index.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/> for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See 
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will be missing from the
        /// returned document.
        /// </param>
        /// <returns>
        /// Response containing the document.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Get and GetAsync methods make a best-effort attempt to map JSON types in
        /// the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static DocumentGetResponse Get(
            this IDocumentOperations operations, 
            string key,
            IEnumerable<string> selectedFields)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IDocumentOperations)s).GetAsync(key, selectedFields);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a document from the Azure Search index.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/> for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See 
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will be missing from the
        /// returned document.
        /// </param>
        /// <returns>
        /// Response containing the document.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Get and GetAsync methods make a best-effort attempt to map JSON types in
        /// the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static Task<DocumentGetResponse> GetAsync(
            this IDocumentOperations operations,
            string key,
            IEnumerable<string> selectedFields)
        {
            return operations.GetAsync(key, selectedFields, CancellationToken.None);
        }

        /// <summary>
        /// Retrieves a document from the Azure Search index.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/> for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <returns>
        /// Response containing the document.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Get and GetAsync methods make a best-effort attempt to map JSON types in
        /// the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static DocumentGetResponse Get(this IDocumentOperations operations, string key)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IDocumentOperations)s).GetAsync(key);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a document from the Azure Search index.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/> for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <returns>
        /// Response containing the document.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Get and GetAsync methods make a best-effort attempt to map JSON types in
        /// the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static Task<DocumentGetResponse> GetAsync(this IDocumentOperations operations, string key)
        {
            return operations.GetAsync(key, DocumentOperations.SelectAll, CancellationToken.None);
        }

        /// <summary>
        /// Retrieves a document from the Azure Search index.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/> for more information)
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will have null or default as its
        /// corresponding property value in the returned object.
        /// </param>
        /// <returns>
        /// Response containing the document.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Get and GetAsync methods support mapping of Azure Search field types to .NET
        /// types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static DocumentGetResponse<T> Get<T>(
            this IDocumentOperations operations, 
            string key,
            IEnumerable<string> selectedFields)
            where T : class
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IDocumentOperations)s).GetAsync<T>(key, selectedFields);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a document from the Azure Search index.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/> for more information)
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will have null or default as its
        /// corresponding property value in the returned object.
        /// </param>
        /// <returns>
        /// Response containing the document.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Get and GetAsync methods support mapping of Azure Search field types to .NET
        /// types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static Task<DocumentGetResponse<T>> GetAsync<T>(
            this IDocumentOperations operations,
            string key,
            IEnumerable<string> selectedFields) where T : class
        {
            return operations.GetAsync<T>(key, selectedFields, CancellationToken.None);
        }

        /// <summary>
        /// Retrieves a document from the Azure Search index.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/> for more information)
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <returns>
        /// Response containing the document.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Get and GetAsync methods support mapping of Azure Search field types to .NET
        /// types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static DocumentGetResponse<T> Get<T>(this IDocumentOperations operations, string key)
            where T : class
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IDocumentOperations)s).GetAsync<T>(key);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a document from the Azure Search index.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/> for more information)
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <returns>
        /// Response containing the document.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Get and GetAsync methods support mapping of Azure Search field types to .NET
        /// types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static Task<DocumentGetResponse<T>> GetAsync<T>(this IDocumentOperations operations, string key)
            where T : class
        {
            return operations.GetAsync<T>(key, DocumentOperations.SelectAll, CancellationToken.None);
        }
    }
}
