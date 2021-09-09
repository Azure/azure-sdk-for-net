module.exports = async function (context, req, negoCtx) {
    var id = req.query.endpointId;
    var endpointNum = negoCtx.endpoints.length;
    context.res.body = negoCtx.endpoints[id % endpointNum].connectionInfo;
}