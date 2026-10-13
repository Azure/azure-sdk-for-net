public virtual global::Samples.LegacyClient GetLegacyClient(string tenant)
{
    global::Samples.Argument.AssertNotNull(tenant, nameof(tenant));
    return new global::Samples.LegacyClient(Pipeline, _endpoint, "2022-10-01", tenant);
}
