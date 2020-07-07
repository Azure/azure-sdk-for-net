// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
using Newtonsoft.Json;
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents an Azure WebJobs SDK function.</summary>
#if PUBLICPROTOCOL
    public class FunctionDescriptor
#else
    public class FunctionDescriptor
#endif
    {
        /// <summary>Gets or sets the ID of the function.</summary>
        public string Id { get; set; }

        /// <summary>Gets or sets the fully qualified name of the function. This is 'Namespace.Class.Method' </summary>
        public string FullName { get; set; }

        /// <summary>Gets or sets the display name of the function. This is commonly 'Class.Method' </summary>
        public string ShortName { get; set; }

        /// <summary>Gets or sets the function's parameters.</summary>
        public IEnumerable<ParameterDescriptor> Parameters { get; set; }


#if PUBLICPROTOCOL
#else
        /// <summary>Gets or sets the name used for logging. This is 'Method' or the value overwritten by [FunctionName] </summary>
        [JsonIgnore]
        public string LogName { get; set; }

        /// <summary>Gets or sets whether this method is disabled. </summary>
        [JsonIgnore]
        internal bool IsDisabled { get; set; }

        /// <summary>Gets or sets whether this signature includes a cancellation token. 
        /// This indicates whether the method is requesting to be alerted of attempted cancellation. </summary>
        internal bool HasCancellationToken { get; set; }

        /// <summary>
        /// Gets the <see cref="Protocols.TriggerParameterDescriptor"/> for this function
        /// </summary>
        [JsonIgnore]
        internal TriggerParameterDescriptor TriggerParameterDescriptor { get; set; }

        /// <summary>
        /// Gets the <see cref="WebJobs.TimeoutAttribute"/> for this function
        /// </summary>
        [JsonIgnore]
        internal TimeoutAttribute TimeoutAttribute { get; set; }

        /// <summary>
        /// Gets any <see cref="SingletonAttribute"/>s for this function
        /// </summary>
        [JsonIgnore]
        internal IEnumerable<SingletonAttribute> SingletonAttributes { get; set; }

        /// <summary>
        /// Gets any <see cref="IFunctionFilter"/>s declared at the method level.
        /// </summary>
        [JsonIgnore]
        internal IEnumerable<IFunctionFilter> MethodLevelFilters { get; set; }

        /// <summary>
        /// Gets any <see cref="IFunctionFilter"/>s declared at the class level.
        /// </summary>
        [JsonIgnore]
        internal IEnumerable<IFunctionFilter> ClassLevelFilters { get; set; }
#endif
    }
}
