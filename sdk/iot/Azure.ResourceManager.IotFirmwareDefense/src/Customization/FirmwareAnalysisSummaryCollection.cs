// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.IotFirmwareDefense.Models;

namespace Azure.ResourceManager.IotFirmwareDefense
{
    public partial class FirmwareAnalysisSummaryCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<FirmwareAnalysisSummaryResource>> GetAsync(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default)
        {
            return await GetAsync(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken).ConfigureAwait(false);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<FirmwareAnalysisSummaryResource> Get(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default) =>
            Get(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default) =>
            Exists(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<FirmwareAnalysisSummaryResource>> GetIfExistsAsync(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<FirmwareAnalysisSummaryResource> GetIfExists(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default) =>
            GetIfExists(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken);
    }
}
