// ------------------------------------------------------------------------------------------------
// <copyright file="RecordSetExtensions.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace PrivateDns.Tests.Extensions
{
    using System;
    using Microsoft.Azure.Management.PrivateDns.Models;
    using PrivateDns.Tests.Validation;

    internal static class RecordSetExtensions
    {
        public static RecordSetAssertions Should(this RecordSet recordSet)
        {
            if (recordSet == null)
            {
                throw new ArgumentNullException(nameof(recordSet));
            }

            return new RecordSetAssertions(recordSet);
        }
    }
}
