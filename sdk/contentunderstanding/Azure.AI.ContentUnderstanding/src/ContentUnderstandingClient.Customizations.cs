// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Partial class for ContentUnderstandingClient to customize generated methods.
    /// This makes the UpdateDefaults protocol methods internal, so only the convenience
    /// extension methods (UpdateDefaults/UpdateDefaultsAsync with IDictionary) are public.
    /// </summary>
    public partial class ContentUnderstandingClient
    {
        // TODO: Uncomment these methods when ready to regenerate the SDK.
        // These methods are currently commented out because the generated code has been manually
        // edited to make UpdateDefaults methods internal. Once the SDK is regenerated with the
        // proper configuration to generate them as internal, uncomment these to ensure they
        // remain internal even after regeneration.
        //
        // According to autorest.csharp customization pattern (https://github.com/Azure/autorest.csharp#replace-any-generated-member),
        // defining a partial class with the same method signature but different accessibility
        // replaces the generated public method with this internal version.

        /*
        /// <summary>
        /// [Protocol Method] Update default model deployment settings.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// This method is internal. Use the convenience extension methods <see cref="ContentUnderstandingClientExtensions.UpdateDefaults(ContentUnderstandingClient, System.Collections.Generic.IDictionary{string, string}, System.Threading.CancellationToken)"/> or
        /// <see cref="ContentUnderstandingClientExtensions.UpdateDefaultsAsync(ContentUnderstandingClient, System.Collections.Generic.IDictionary{string, string}, System.Threading.CancellationToken)"/> instead.
        /// </remarks>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual Response UpdateDefaults(RequestContent content, RequestContext? context = null)
        {
            // The generated implementation will be inserted here by autorest.csharp
            // This method signature replaces the public version from the generated code
            throw new NotImplementedException();
        }

        /// <summary>
        /// [Protocol Method] Update default model deployment settings asynchronously.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// This method is internal. Use the convenience extension methods <see cref="ContentUnderstandingClientExtensions.UpdateDefaults(ContentUnderstandingClient, System.Collections.Generic.IDictionary{string, string}, System.Threading.CancellationToken)"/> or
        /// <see cref="ContentUnderstandingClientExtensions.UpdateDefaultsAsync(ContentUnderstandingClient, System.Collections.Generic.IDictionary{string, string}, System.Threading.CancellationToken)"/> instead.
        /// </remarks>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<Response> UpdateDefaultsAsync(RequestContent content, RequestContext? context = null)
        {
            // The generated implementation will be inserted here by autorest.csharp
            // This method signature replaces the public version from the generated code
            throw new NotImplementedException();
        }
        */
    }
}
