// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

module.exports = async function (context, message) {
  context.bindings.webPubSubEvent = {
    "operation": "sendToAll",
    "message": message,
    "dataType": context.bindingData.dataType
  };
  var response = { 
    "message": JSON.stringify({
        from: '[System]',
        content: 'ack.'
      }),
    "dataType" : "json"
  };
  return response;
};