// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Host.Loggers
{
    /// <summary>    
    /// Represent a function invocation starting or finishing. 
    /// A host can register an IAsyncCollector on the JobHostConfiguration to receive these notifications to do their own logging. 
    /// </summary>
    [Obsolete("Not ready for public consumption.")]
    public class FunctionInstanceLogEntry
    {
        /// <summary>
        /// Maximum length of LogOutput that will be captured. 
        /// </summary>
        public const int MaxLogOutputLength = 2000;

        /// <summary>Gets or sets the function instance ID.</summary>
        public Guid FunctionInstanceId { get; set; }

        /// <summary>The parent instance that caused this function instance to run. this is used to establish causality between functions. </summary>
        public Guid? ParentId { get; set; }

        /// <summary>The name of the function, including the class name. This serves as an identifier.</summary>
        public string FunctionName { get; set; }

        /// <summary>The name of the function method, excluding the class name.</summary>
        public string LogName { get; set; }

        /// <summary>
        /// An optional hint about why this function was invoked. It may have been triggered, replayed, manually invoked, etc. 
        /// </summary>
        public string TriggerReason { get; set; }

        /// <summary>The time the function started executing.</summary>
        public DateTime StartTime { get; set; }

        /// <summary>An optional value for when the function finished executing. If not set, then the function hasn't completed yet. </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// The duration of the function execution.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Null on success.
        /// Else, set to some string with error details. 
        /// </summary>
        public string ErrorDetails { get; set; }

        /// <summary>
        /// Null on success. Else, set to the Exception thrown by the function invocation.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets the function's argument values and help strings.
        /// If this is null, then the event is before binding. 
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public IDictionary<string, string> Arguments { get; set; }

        /// <summary>Direct inline capture for output written to the per-function instance TextWriter log. 
        /// For large log outputs, this is truncated</summary>
        public string LogOutput { get; set; }

        /// <summary>
        /// in-memory Property bag that lives for the lifetime of the item. 
        /// This can be used to help the caller correlate data at various phases. 
        /// </summary>
        [JsonIgnore]
        public IDictionary<string, object> Properties { get; set; }

        /// <summary>
        /// An in-memory timer to measure the duration during execution. Use <see cref="Duration"/> for persisted cases.
        /// </summary>
        [JsonIgnore]
        public Stopwatch LiveTimer { get; set; }

        /// <summary>
        /// Function has just started. This is before arguments are bound. 
        /// </summary>
        public bool IsStart => !IsCompleted && this.Arguments == null;

        /// <summary>
        /// Function has bound the arguments but the the body is not yet invoked. 
        /// </summary>
        public bool IsPostBind => !IsCompleted && this.Arguments != null;

        /// <summary>
        /// Function has completed and run body. See <see cref="ErrorDetails"/> to determine if this was success of failure. 
        /// </summary>
        public bool IsCompleted => this.EndTime.HasValue;
    }
}
