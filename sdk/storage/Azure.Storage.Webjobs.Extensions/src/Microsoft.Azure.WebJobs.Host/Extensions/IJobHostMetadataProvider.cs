// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Interface for providing <see cref="JobHost"/> function binding metadata.
    /// </summary>
    [Obsolete("Not ready for public consumption.")]
    public interface IJobHostMetadataProvider
    {
        /// <summary>
        /// Maps the specified name to a corresponding binding attribute type
        /// based on convention. E.g. "Blob" => typeof(BlobAttribute)
        /// </summary>
        /// <param name="name">The short name to get the type for.</param>
        /// <returns></returns>
        Type GetAttributeTypeFromName(string name);

        /// <summary>
        /// Creates a binding attribute instance from the specified metadata.
        /// </summary>
        /// <param name="attributeType">The binding attribute type to create an instance of.</param>
        /// <param name="metadata">The binding metadata to apply to the attribute instance.</param>
        /// <returns></returns>
        Attribute GetAttribute(Type attributeType, JObject metadata);

        /// <summary>
        /// Gets the default type used by the binding indicated by the specified
        /// attribute.
        /// </summary>
        /// <remarks>
        /// This is biased to returning JObject, Streams, and BCL types 
        /// which can be converted to a loosely typed object in scripting languages. 
        /// </remarks>
        /// <param name="attribute">The binding attribute instance to get the type for.</param>
        /// <param name="access">The <see cref="FileAccess"/> indicating the biding direction (e.g. in, out, in/out).</param>
        /// <param name="requestedType">The requested type.</param>
        /// <returns></returns>
        Type GetDefaultType(Attribute attribute, FileAccess access, Type requestedType);

        /// <summary>
        /// Attempts to resolve the specified reference assembly.
        /// </summary>
        /// <remarks>
        /// This allows an extension to support "built in" assemblies so user code can
        /// easily reference them.
        /// </remarks>
        /// <param name="assemblyName">The name of the assembly to resolve.</param>
        /// <param name="assembly">Assembly that the name is resolved to</param>
        /// <returns>True with a non-null assembly if we were able to resolve. Else false and null assembly</returns>
        bool TryResolveAssembly(string assemblyName, out Assembly assembly);
        
        /// <summary>
        /// Gets function metadata.
        /// </summary>
        /// <param name="functionName">Name of function to return metadata for.</param>
        /// <returns></returns>
        FunctionMetadata GetFunctionMetadata(string functionName);
    }
}
