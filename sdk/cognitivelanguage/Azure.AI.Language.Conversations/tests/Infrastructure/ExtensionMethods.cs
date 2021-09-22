// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework.Constraints;

namespace Azure.AI.Language.Conversations.Tests
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Determines whether the asserted type contains a property named "ParamName" with the value of <paramref name="paramName"/>.
        /// </summary>
        /// <param name="constraint"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static EqualConstraint WithParamName(this ExactTypeConstraint constraint, string paramName)
        {
            return constraint.With.Property(nameof(ArgumentException.ParamName)).EqualTo(paramName);
        }
    }
}
