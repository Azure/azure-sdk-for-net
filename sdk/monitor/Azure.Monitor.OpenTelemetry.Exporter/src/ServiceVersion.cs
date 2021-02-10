namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// These values define the version of the Azure Monitor Ingestion Service.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
    public enum ServiceVersion
    {
        V2020_09_15_Preview = 1, // https://github.com/Azure/azure-rest-api-specs/blob/master/specification/applicationinsights/data-plane/Monitor.Exporters/preview/2020-09-15_Preview/swagger.json
    }
}
