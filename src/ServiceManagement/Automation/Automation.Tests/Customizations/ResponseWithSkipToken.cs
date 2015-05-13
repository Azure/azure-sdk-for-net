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

using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Management.Automation.Models;

namespace Microsoft.WindowsAzure.Management.Automation
{
    /// <summary>
    /// The response with skip token.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class ResponseWithSkipToken<T>
    {
        /// <summary>
        /// The operation response with skip token
        /// </summary>
        private readonly OperationResponseWithSkipToken operationResponseWithSkipToken;

        /// <summary>
        /// The automation management models.
        /// </summary>
        private readonly IEnumerable<T> automationManagementModels;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseWithSkipToken{T}"/> class.
        /// </summary>
        /// <param name="operationResponseWithSkipToken">
        /// The operation response with skip token.
        /// </param>
        /// <param name="automationManagementModels">
        /// The automation management models.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Argument Null Exception
        /// </exception>
        public ResponseWithSkipToken(OperationResponseWithSkipToken operationResponseWithSkipToken, IEnumerable<T> automationManagementModels)
        {
            if (operationResponseWithSkipToken == null)
            {
                throw new ArgumentNullException("operationResponseWithSkipToken");
            }
            if (automationManagementModels == null)
            {
                throw new ArgumentNullException("automationManagementModels");
            }

            this.operationResponseWithSkipToken = operationResponseWithSkipToken;
            this.automationManagementModels = automationManagementModels;
        }

        /// <summary>
        /// Gets the automation management models.
        /// </summary>
        public IEnumerable<T> AutomationManagementModels
        {
            get
            {
                return this.automationManagementModels;
            }
        }

        /// <summary>
        /// Gets the skip token.
        /// </summary>
        public string SkipToken
        {
            get
            {
                return this.operationResponseWithSkipToken.SkipToken;
            }
        }
    }
}