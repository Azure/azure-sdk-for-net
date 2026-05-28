# Post-regeneration patch script.
# Apply after running `dotnet build /t:GenerateCode` to work around MPG generator bugs:
#  1) `IEnumerable<T>.ToRequestContent(arg)` (invalid C#) — replaced by BillingRequestContentHelper.ToRequestContent
#  2) `DateTimeOffset.ToRequestContent(arg)`              — replaced by BillingRequestContentHelper.ToRequestContent
#  3) `SubscriptionRenewalTermDetails.TermDuration` emits as `TimeSpan?` despite TSP `string` — re-typed to `string`
#
# Run with PowerShell from anywhere; resolves files relative to its own location.

$ErrorActionPreference = 'Stop'
$gen = Resolve-Path (Join-Path $PSScriptRoot '..\src\Generated')
$models = Join-Path $gen 'Models'

function PatchFile([string]$path, [scriptblock]$transform) {
    if (-not (Test-Path $path)) { Write-Warning "Missing $path"; return }
    $orig = Get-Content -Raw $path
    $new = & $transform $orig
    if ($new -ne $orig) {
        Set-Content -Path $path -Value $new -NoNewline
        Write-Host "Patched $path"
    }
}

# 1) Fix invalid IEnumerable<T>.ToRequestContent(...) and DateTimeOffset.ToRequestContent(...) call sites.
$broken = @(
    (Join-Path $gen 'BillingAccountResource.cs'),
    (Join-Path $gen 'Extensions\MockableBillingTenantResource.cs')
)
foreach ($f in $broken) {
    PatchFile $f {
        param($c)
        $c = [regex]::Replace($c, 'IEnumerable<[^>]+>\.ToRequestContent\(([^)]+)\)', 'BillingRequestContentHelper.ToRequestContent($1)')
        $c = [regex]::Replace($c, 'DateTimeOffset\.ToRequestContent\(([^)]+)\)', 'BillingRequestContentHelper.ToRequestContent($1)')
        return $c
    }
}

# 2) SubscriptionRenewalTermDetails.TermDuration should be string, not TimeSpan?
$srt = Join-Path $models 'SubscriptionRenewalTermDetails.cs'
PatchFile $srt {
    param($c)
    # PowerShell -replace is case-insensitive; use -creplace for case-sensitive substitution.
    $c = $c -creplace 'TimeSpan\? termDuration', 'string termDuration'
    $c = $c -creplace 'TimeSpan\? TermDuration', 'string TermDuration'
    return $c
}

# 3) SubscriptionRenewalTermDetails serialization — write string + read string
$srtSer = Join-Path $models 'SubscriptionRenewalTermDetails.Serialization.cs'
PatchFile $srtSer {
    param($c)
    # Replace WriteStringValue(TermDuration.Value) with WriteStringValue(TermDuration)
    $c = $c -creplace 'writer\.WriteStringValue\(TermDuration\.Value\);', 'writer.WriteStringValue(TermDuration);'
    # Replace local "TimeSpan? termDuration = default;" with "string termDuration = default;"
    $c = $c -creplace 'TimeSpan\? termDuration = default;', 'string termDuration = default;'
    # Replace termDuration prop reader: GetTimeSpan() → GetString()
    $c = $c -creplace 'termDuration = prop\.Value\.GetTimeSpan\(\);', 'termDuration = prop.Value.GetString();'
    return $c
}

# 4) ArmBillingModelFactory.cs — factory method TimeSpan? termDuration → string termDuration
$factory = Join-Path $gen 'ArmBillingModelFactory.cs'
PatchFile $factory {
    param($c)
    # Only patch the SubscriptionRenewalTermDetails factory method signature
    $c = [regex]::Replace($c,
        '(public static SubscriptionRenewalTermDetails SubscriptionRenewalTermDetails\([^)]*?)TimeSpan\? termDuration',
        '$1string termDuration')
    return $c
}

# 5) BillingExtensions.cs — fix broken XML doc cref with bare IEnumerable to IEnumerable{T}.
$ext = Join-Path $gen 'Extensions\BillingExtensions.cs'
PatchFile $ext {
    param($c)
    $c = $c -creplace 'DownloadDocumentsByBillingSubscriptionAsync\(WaitUntil, string, IEnumerable, CancellationToken\)', 'DownloadDocumentsByBillingSubscriptionAsync(WaitUntil, string, IEnumerable{BillingDocumentDownloadRequestContent}, CancellationToken)'
    $c = $c -creplace 'DownloadDocumentsByBillingSubscription\(WaitUntil, string, IEnumerable, CancellationToken\)', 'DownloadDocumentsByBillingSubscription(WaitUntil, string, IEnumerable{BillingDocumentDownloadRequestContent}, CancellationToken)'
    return $c
}

# 6) Dedupe MPG-generator duplicate Get<X>Resource(...) extension methods.
#    When multiple parent scopes (e.g., BillingAccount/BillingProfile/Invoice/Customer) own the
#    same resource type, the generator emits the same static GetXResource(ArmClient, ResourceIdentifier)
#    extension (and the corresponding MockableBillingArmClient.GetXResource(ResourceIdentifier)) once
#    per scope, causing CS0111. Keep only the first occurrence per method signature.
function Remove-DuplicateMethodBlocks([string]$path, [string]$blockPattern) {
    PatchFile $path {
        param($c)
        $rx = [regex]::new($blockPattern, 'Singleline')
        $matches = $rx.Matches($c)
        if ($matches.Count -eq 0) { return $c }
        $seen = @{}
        $toRemove = New-Object 'System.Collections.Generic.List[object]'
        foreach ($m in $matches) {
            $sig = $m.Groups['sig'].Value
            if ($seen.ContainsKey($sig)) { $toRemove.Add($m) } else { $seen[$sig] = $true }
        }
        if ($toRemove.Count -eq 0) { return $c }
        $sorted = $toRemove | Sort-Object { $_.Index } -Descending
        foreach ($m in $sorted) { $c = $c.Remove($m.Index, $m.Length) }
        return $c
    }
}

$ext = Join-Path $gen 'Extensions\BillingExtensions.cs'
$mock = Join-Path $gen 'Extensions\MockableBillingArmClient.cs'

# Match: leading blank line + XML doc block + method signature + body returning GetMockableBillingArmClient(...)
$extPattern = '\r?\n        /// <summary>.*?public static (?<sig>\w+Resource Get\w+Resource\(this ArmClient client, ResourceIdentifier id\))\s*\r?\n\s*\{\s*\r?\n            Argument\.AssertNotNull\(client, nameof\(client\)\);\s*\r?\n\s*\r?\n            return GetMockableBillingArmClient\(client\)\.Get\w+Resource\(id\);\s*\r?\n        \}'
Remove-DuplicateMethodBlocks $ext $extPattern

$mockPattern = '\r?\n        /// <summary>.*?public virtual (?<sig>\w+Resource Get\w+Resource\(ResourceIdentifier id\))\s*\r?\n\s*\{\s*\r?\n            \w+Resource\.ValidateResourceId\(id\);\s*\r?\n            return new \w+Resource\(Client, id\);\s*\r?\n        \}'
Remove-DuplicateMethodBlocks $mock $mockPattern

# 7) BillingProfileResource: Products*CollectionResultOfT ctor expects (billingAccount, billingProfile, invoiceSection, ...).
#    BillingProfile scope has no invoiceSection so pass null.
$bp = Join-Path $gen 'BillingProfileResource.cs'
PatchFile $bp {
    param($c)
    $c = [regex]::Replace($c,
        '(new ProductsGetProductsAsyncCollectionResultOfT\(\s*\r?\n\s*_productsRestClient,\s*\r?\n\s*Id\.Parent\.Name,\s*\r?\n\s*Id\.Name,\s*\r?\n)(\s*filter,)',
        '$1                null,
$2')
    $c = [regex]::Replace($c,
        '(new ProductsGetProductsCollectionResultOfT\(\s*\r?\n\s*_productsRestClient,\s*\r?\n\s*Id\.Parent\.Name,\s*\r?\n\s*Id\.Name,\s*\r?\n)(\s*filter,)',
        '$1                null,
$2')
    return $c
}

# 8) MockableBillingTenantResource: drop generator-emitted InvoiceByBillingSubscription_GetByBillingSubscription helpers.
#    The generator emits GetInvoices(string subscriptionId)/GetInvoice(string subscriptionId,string)/GetInvoiceAsync(...)
#    which call `new InvoiceCollection(client, Id, subscriptionId)` — but the generated InvoiceCollection only has a
#    (client, ResourceIdentifier) ctor. These methods are not in the GA API so removing them is safe.
$mockTenant = Join-Path $gen 'Extensions\MockableBillingTenantResource.cs'
PatchFile $mockTenant {
    param($c)
    foreach ($block in @(
        '\r?\n        /// <summary> Gets a collection of Invoices in the <see cref="TenantResource"/>\. </summary>\s*\r?\n        /// <param name="subscriptionId">[^<]+</param>\s*\r?\n        /// <returns>[^<]+</returns>\s*\r?\n        public virtual InvoiceCollection GetInvoices\(string subscriptionId\)\s*\r?\n\s*\{\s*\r?\n            return GetCachedClient\(client => new InvoiceCollection\(client, Id, subscriptionId\)\);\s*\r?\n        \}',
        '\r?\n        /// <summary>\s*\r?\n        /// Gets an invoice by subscription ID and invoice ID\..*?\r?\n        public virtual async Task<Response<InvoiceResource>> GetInvoiceAsync\(string subscriptionId, string invoiceName, CancellationToken cancellationToken = default\)\s*\r?\n\s*\{\s*\r?\n            Argument\.AssertNotNullOrEmpty\(invoiceName, nameof\(invoiceName\)\);\s*\r?\n\s*\r?\n            return await GetInvoices\(subscriptionId\)\.GetAsync\(invoiceName, cancellationToken\)\.ConfigureAwait\(false\);\s*\r?\n        \}',
        '\r?\n        /// <summary>\s*\r?\n        /// Gets an invoice by subscription ID and invoice ID\..*?\r?\n        public virtual Response<InvoiceResource> GetInvoice\(string subscriptionId, string invoiceName, CancellationToken cancellationToken = default\)\s*\r?\n\s*\{\s*\r?\n            Argument\.AssertNotNullOrEmpty\(invoiceName, nameof\(invoiceName\)\);\s*\r?\n\s*\r?\n            return GetInvoices\(subscriptionId\)\.Get\(invoiceName, cancellationToken\);\s*\r?\n        \}'
    )) {
        $c = [regex]::Replace($c, $block, '', 'Singleline')
    }
    return $c
}

# 9) BillingExtensions.cs: drop the corresponding TenantResource static extensions that delegate to the removed methods.
PatchFile $ext {
    param($c)
    foreach ($block in @(
        '\r?\n        /// <summary>\s*\r?\n        /// Gets a collection of Invoices in the <see cref="TenantResource"/>\s*\r?\n        /// <item>.*?MockableBillingTenantResource\.GetInvoices\(string\).*?\r?\n        public static InvoiceCollection GetInvoices\(this TenantResource tenantResource, string subscriptionId\)\s*\r?\n\s*\{\s*\r?\n            Argument\.AssertNotNull\(tenantResource, nameof\(tenantResource\)\);\s*\r?\n\s*\r?\n            return GetMockableBillingTenantResource\(tenantResource\)\.GetInvoices\(subscriptionId\);\s*\r?\n        \}',
        '\r?\n        /// <summary>\s*\r?\n        /// Gets an invoice by subscription ID and invoice ID\..*?MockableBillingTenantResource\.GetInvoiceAsync\(string, string, CancellationToken\).*?\r?\n        public static async Task<Response<InvoiceResource>> GetInvoiceAsync\(this TenantResource tenantResource, string subscriptionId, string invoiceName, CancellationToken cancellationToken = default\)\s*\r?\n\s*\{\s*\r?\n            Argument\.AssertNotNull\(tenantResource, nameof\(tenantResource\)\);\s*\r?\n\s*\r?\n            return await GetMockableBillingTenantResource\(tenantResource\)\.GetInvoiceAsync\(subscriptionId, invoiceName, cancellationToken\)\.ConfigureAwait\(false\);\s*\r?\n        \}',
        '\r?\n        /// <summary>\s*\r?\n        /// Gets an invoice by subscription ID and invoice ID\..*?MockableBillingTenantResource\.GetInvoice\(string, string, CancellationToken\).*?\r?\n        public static Response<InvoiceResource> GetInvoice\(this TenantResource tenantResource, string subscriptionId, string invoiceName, CancellationToken cancellationToken = default\)\s*\r?\n\s*\{\s*\r?\n            Argument\.AssertNotNull\(tenantResource, nameof\(tenantResource\)\);\s*\r?\n\s*\r?\n            return GetMockableBillingTenantResource\(tenantResource\)\.GetInvoice\(subscriptionId, invoiceName, cancellationToken\);\s*\r?\n        \}'
    )) {
        $c = [regex]::Replace($c, $block, '', 'Singleline')
    }
    return $c
}

Write-Host "Post-regen patches applied successfully."