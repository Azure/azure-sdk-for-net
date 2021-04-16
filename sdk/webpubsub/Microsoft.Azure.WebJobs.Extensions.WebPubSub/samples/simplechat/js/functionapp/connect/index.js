// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

module.exports = async function (context, connectionContext) {
  if (connectionContext.userId == "attacker")
  {
    var connectResponse = {
      "code": "unauthorized",
      "errorMessage": "invalid user"
    }
  }
  else 
  {
    var connectResponse = {
      "userId": connectionContext.userId
    };
  }
  return connectResponse;
};

