// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Automation.Models;

namespace Microsoft.Azure.Management.Automation
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