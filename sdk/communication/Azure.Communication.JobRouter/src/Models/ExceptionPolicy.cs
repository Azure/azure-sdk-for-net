// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("ExceptionPolicy")]
    [CodeGenSuppress("ExceptionPolicy")]
    public partial class ExceptionPolicy
    {
        /// <summary> Initializes a new instance of ExceptionPolicy. </summary>
        internal ExceptionPolicy()
        {
            _exceptionRules = new ChangeTrackingDictionary<string, ExceptionRule>();
        }

        [CodeGenMember("ExceptionRules")]
        internal IDictionary<string, ExceptionRule> _exceptionRules
        {
            get
            {
                return ExceptionRules != null && ExceptionRules.Count != 0
                    ? ExceptionRules?.ToDictionary(x => x.Key, x => x.Value)
                    : new ChangeTrackingDictionary<string, ExceptionRule>();
            }
            set
            {
                if (value != null && value.Any())
                {
                    ExceptionRules.Append(value);
                }
            }
        }

        /// <summary> (Optional) A dictionary collection of exception rules on the exception policy. Key is the Id of each exception rule. </summary>
        public IDictionary<string, ExceptionRule> ExceptionRules { get; } = new Dictionary<string, ExceptionRule>();

        /// <summary> (Optional) The name of the exception policy. </summary>
        public string Name { get; internal set; }
    }
}
