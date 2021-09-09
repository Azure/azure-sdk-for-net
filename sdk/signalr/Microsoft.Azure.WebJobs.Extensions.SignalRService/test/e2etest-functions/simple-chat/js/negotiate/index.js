module.exports = async function (context, req, connectionInfo) {
    context.res.body = connectionInfo;
};