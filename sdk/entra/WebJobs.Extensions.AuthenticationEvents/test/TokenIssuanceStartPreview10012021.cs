namespace WebJobs.Extensions.AuthenticationEvents.Tests
{
    /// <summary>Test data for the Token Issuance Start Request version: preview_10_10_2021</summary>
    public static class TokenIssuanceStartPreview10012021
    {
        /// <summary>Mocks the data expected from the function execution.</summary>
        /// <value>The function response.</value>
        public static string FunctionResponse
        {
            get
            {
                return @"{'actions': [
                        {
                            'type': 'ProvideClaimsForToken',
                            'claims': [
                                {
                                    'id': 'DateOfBirth',
                                    'value': '01/01/2000'
                                },
                                {
                                    'id': 'CustomRoles',
                                    'value': [
                                        'Writer',
                                        'Editor'
                                    ]
                                }
                            ]
                        }
                    ]}";
            }
        }

        /// <summary>Gets the invalid action response.</summary>
        /// <value>The invalid action response.</value>
        public static string InvalidActionResponse
        {
            get
            {
                return @"{'actions': [
                        {
                            'type': 'ProvideClaims',
                            'claims': [
                                {
                                    'id': 'DateOfBirth',
                                    'value': '01/01/2000'
                                },
                                {
                                    'id': 'CustomRoles',
                                    'value': [
                                        'Writer',
                                        'Editor'
                                    ]
                                }
                            ]
                        }
                    ]}";
            }
        }

        /// <summary>Gets the no action response.</summary>
        /// <value>The no action response.</value>
        public static string NoActionResponse
        {
            get
            {
                return @"{'actions': []}";
            }
        }

        /// <summary>Mocks the data expected from the function execution that will be converted by yhe EvenrResponseHandler to an IActionResult.</summary>
        /// <value>The function response.</value>
        public static string ConversionPayload
        {
            get
            {
                string body = "{\r\n  \"type\": \"onTokenIssuanceStartCustomExtension\",\r\n  \"apiSchemaVersion\": \"10-01-2021-preview\",\r\n  \"actions\": []\r\n}";
                string schema = "{\r\n  \"$schema\": \"http://json-schema.org/draft-04/schema\",\r\n  \"type\": \"object\",\r\n  \"properties\": {\r\n    \"type\": {\r\n      \"type\": \"string\",\r\n      \"enum\": [ \"onTokenIssuanceStartCustomExtension\" ]\r\n    },\r\n    \"apiSchemaVersion\": {\r\n      \"type\": \"string\",\r\n      \"enum\": [ \"10-01-2021-preview\" ]\r\n    },\r\n    \"actions\": {\r\n      \"type\": \"array\",\r\n      \"minItems\": 1,\r\n      \"maxItems\": 1,\r\n      \"items\": {\r\n        \"type\": \"object\",\r\n        \"properties\": {\r\n          \"type\": {\r\n            \"type\": \"string\",\r\n            \"enum\": [ \"ProvideClaimsForToken\" ]\r\n          }\r\n        },\r\n        \"allOf\": [\r\n          {\r\n            \"anyOf\": [\r\n              {\r\n                \"not\": {\r\n                  \"properties\": { \"type\": { \"enum\": [\"ProvideClaimsForToken\"] } }\r\n                }\r\n              },\r\n              { \r\n                \"properties\": { \"claims\": {\"$ref\": \"#/definitions/claimsForToken\"} },\r\n                \"required\": [\"claims\"]\r\n              }\r\n            ]\r\n          }\r\n        ],\r\n        \"required\": [\r\n          \"type\"\r\n        ]\r\n      }\r\n    }\r\n  },\r\n  \"required\": [\r\n    \"type\",\r\n    \"apiSchemaVersion\",\r\n    \"actions\"\r\n  ],\r\n\r\n  \"definitions\": {\r\n    \r\n    \"claimsForToken\": {\r\n      \"type\": \"array\",\r\n      \"items\": {\r\n        \"$ref\": \"#/definitions/claim\"\r\n      }\r\n    },\r\n\r\n    \"claim\": {\r\n      \"type\": \"object\",\r\n      \"properties\": {\r\n        \"id\": {\r\n          \"type\": \"string\"\r\n        },\r\n        \"value\": {\r\n          \"oneOf\": [\r\n            {\r\n              \"type\": \"string\"\r\n            },\r\n            {\r\n              \"type\": \"array\",\r\n              \"items\": {\r\n                \"type\": \"string\"\r\n              }\r\n            }\r\n          ]\r\n        }\r\n      },\r\n      \"required\": [\r\n        \"id\",\r\n        \"value\"\r\n      ]\r\n    }\r\n  }\r\n  \r\n}";
                return @"{
	                        'actions': [
		                        {
			                        'actionType': 'ProvideClaimsForToken',
			                        'claims': [
				                        {
					                        'id': 'DateOfBirth',
					                        'value': '01/01/2000'
				                        },
				                        {
					                        'id': 'CustomRoles',
					                        'value': [
						                        'Writer',
						                        'Editor'
					                        ]
				                        }
			                        ]
		                        }
	                        ],
	                        'schema': '" + schema + "','body': '" + body + "'}";
            }
        }

        /// <summary>The expected response payload.</summary>
        /// <value>The expected payload.</value>
        public static string ExpectedPayload
        {
            get
            {
                return @"{
                          'type': 'onTokenIssuanceStartCustomExtension',
                          'apiSchemaVersion': '10-01-2021-preview',
                          'actions': [
                            {
                              'type': 'ProvideClaimsForToken',
                              'claims': [
                                {
                                  'id': 'DateOfBirth',
                                  'value': '01/01/2000'
                                },
                                {
                                  'id': 'CustomRoles',
                                  'value': [
                                    'Writer',
                                    'Editor'
                                  ]
                                }
                              ]
                            }
                          ]
                        }";
            }
        }

        /// <summary>Gets the expected payload cloud events.</summary>
        /// <value>The expected payload cloud events.</value>
        public static string ExpectedPayloadCloudEvent
        {
            get
            {
                return @"{
                          'data': {
                                    '@odata.type': '',
                                    'actions'': []
                                     }
                         }";
            }
        }

        /// <summary>Gets the open API document body.</summary>
        /// <value>The open API document.</value>
        public static string OpenApiDocument
        {
            get
            {
                return @"{
                          'openapi': '3.1.0',
                          'info': {
                            'title': 'OnTokenIssuanceStart',
                            'version': '10-01-2021-preview',
                            'contact': {
                              'name': 'Microsoft'
                            },
                            'summary': 'OnTokenIssuanceStart 10-01-2021-preview',
                            'description': 'API outline for OnTokenIssuanceStart 10-01-2021-preview'
                          },
                          'servers': [
                            {
                              'url': ''
                            }
                          ],
                          'paths': {
                            '/onTokenIssuanceStart/10-01-2021-preview': {
                              'post': {
                                'tags': [
                                  'Authentication Events',
                                  'OnTokenIssuanceStart',
                                  '10-01-2021-preview'
                                ],
                                'summary': '',
                                'operationId': 'post-preview_10_01_2021',
                                'responses': {
                                  '200': {
                                    'description': 'OK',
                                    'content': {
                                      'application/json': {
                                        'schema': {
                                          '$ref': './responseSchema.json'
                                        }
                                      }
                                    }
                                  }
                                },
                                'requestBody': {
                                  'content': {
                                    'application/json': {
                                      'schema': {
                                        '$ref': './requestSchema.json'
                                      }
                                    }
                                  },
                                  'description': 'OnTokenIssuanceStart payload'
                                },
                                'description': 'When a new token is issued'
                              },
                              'parameters': []
                            }
                          },
                          'components': {
                            'schemas': {}
                          },
                          'tags': [
                            {
                              'name': '10-01-2021-preview'
                            },
                            {
                              'name': 'Authentication Events'
                            },
                            {
                              'name': 'OnTokenIssuanceStart'
                            }
                          ]
                        }";
            }
        }

        /// <summary>Gets the open API document merged sample payload.</summary>
        /// <value>The open API document merged.</value>
        public static string OpenApiDocumentMerge
        {
            get
            {
                return @"{
                          'openapi': '3.1.0',
                          'info': {
                            'title': 'OnTokenIssuanceStart',
                            'version': '10-01-2021-preview',
                            'contact': {
                              'name': 'Microsoft'
                            },
                            'summary': 'OnTokenIssuanceStart 10-01-2021-preview',
                            'description': 'API outline for OnTokenIssuanceStart 10-01-2021-preview'
                          },
                          'servers': [
                            {
                              'url': ''
                            }
                          ],
                          'paths': {
                            '/onTokenIssuanceStart/10-01-2021-preview': {
                              'post': {
                                'tags': [
                                  'Authentication Events',
                                  'OnTokenIssuanceStart',
                                  '10-01-2021-preview'
                                ],
                                'summary': '',
                                'operationId': 'post-preview_10_01_2021',
                                'responses': {
                                  '200': {
                                    'description': 'OK',
                                    'content': {
                                      'application/json': {
                                        'schema': {
                                          '$schema': 'http://json-schema.org/draft-04/schema',
                                          'type': 'object',
                                          'properties': {
                                            'type': {
                                              'type': 'string',
                                              'enum': [
                                                'onTokenIssuanceStartCustomExtension'
                                              ]
                                            },
                                            'apiSchemaVersion': {
                                              'type': 'string',
                                              'enum': [
                                                '10-01-2021-preview'
                                              ]
                                            },
                                            'actions': {
                                              'type': 'array',
                                              'minItems': 1,
                                              'maxItems': 1,
                                              'items': {
                                                'type': 'object',
                                                'properties': {
                                                  'type': {
                                                    'type': 'string',
                                                    'enum': [
                                                      'ProvideClaimsForToken'
                                                    ]
                                                  }
                                                },
                                                'allOf': [
                                                  {
                                                    'anyOf': [
                                                      {
                                                        'not': {
                                                          'properties': {
                                                            'type': {
                                                              'enum': [
                                                                'ProvideClaimsForToken'
                                                              ]
                                                            }
                                                          }
                                                        }
                                                      },
                                                      {
                                                        'properties': {
                                                          'claims': {
                                                            '$ref': '#/components/schemas/claimsForToken'
                                                          }
                                                        },
                                                        'required': [
                                                          'claims'
                                                        ]
                                                      }
                                                    ]
                                                  }
                                                ],
                                                'required': [
                                                  'type'
                                                ]
                                              }
                                            }
                                          },
                                          'required': [
                                            'type',
                                            'apiSchemaVersion',
                                            'actions'
                                          ]
                                        }
                                      }
                                    }
                                  }
                                },
                                'requestBody': {
                                  'content': {
                                    'application/json': {
                                      'schema': {
                                        '$schema': 'http://json-schema.org/draft-04/schema',
                                        'type': 'object',
                                        'properties': {
                                          'type': {
                                            'type': 'string',
                                            'enum': [
                                              'onTokenIssuanceStartCustomExtension'
                                            ],
                                            'description': 'OnTokenIssuanceStart Event'
                                          },
                                          'apiSchemaVersion': {
                                            'type': 'string',
                                            'enum': [
                                              '10-01-2021-preview'
                                            ]
                                          },
                                          'time': {
                                            'type': 'string'
                                          },
                                          'eventListenerId': {
                                            'type': 'string'
                                          },
                                          'customExtensionId': {
                                            'type': 'string'
                                          },
                                          'context': {
                                            '$ref': '#/components/schemas/context'
                                          }
                                        },
                                        'required': [
                                          'type',
                                          'apiSchemaVersion',
                                          'time',
                                          'eventListenerId',
                                          'customExtensionId',
                                          'context'
                                        ]
                                      }
                                    }
                                  },
                                  'description': 'OnTokenIssuanceStart payload'
                                },
                                'description': 'When a new token is issued'
                              },
                              'parameters': []
                            }
                          },
                          'components': {
                            'schemas': {
                              'context': {
                                'type': 'object',
                                'properties': {
                                  'correlationId': {
                                    'type': 'string'
                                  },
                                  'client': {
                                    '$ref': '#/components/schemas/clientContext'
                                  },
                                  'authProtocol': {
                                    '$ref': '#/components/schemas/authProtocolContext'
                                  },
                                  'clientServicePrincipal': {
                                    '$ref': '#/components/schemas/servicePrincipalContext'
                                  },
                                  'resourceServicePrincipal': {
                                    '$ref': '#/components/schemas/servicePrincipalContext'
                                  },
                                  'roles': {
                                    'type': [
                                      'array',
                                      'null'
                                    ],
                                    'items': {
                                      '$ref': '#/components/schemas/userAppRole'
                                    }
                                  },
                                  'user': {
                                    '$ref': '#/components/schemas/userPrincipalContext'
                                  }
                                },
                                'required': [
                                  'correlationId',
                                  'client',
                                  'authProtocol',
                                  'clientServicePrincipal',
                                  'resourceServicePrincipal',
                                  'user'
                                ]
                              },
                              'clientContext': {
                                'type': 'object',
                                'properties': {
                                  'ip': {
                                    'type': 'string'
                                  },
                                  'locale': {
                                    'type': 'string'
                                  },
                                  'market': {
                                    'type': 'string'
                                  }
                                },
                                'required': [
                                  'ip'
                                ]
                              },
                              'authProtocolContext': {
                                'type': 'object',
                                'properties': {
                                  'type': {
                                    'type': 'string'
                                  },
                                  'tenantId': {
                                    'type': 'string'
                                  }
                                },
                                'required': [
                                  'type',
                                  'tenantId'
                                ]
                              },
                              'servicePrincipalContext': {
                                'type': 'object',
                                'properties': {
                                  'id': {
                                    'type': 'string'
                                  },
                                  'appId': {
                                    'type': 'string'
                                  },
                                  'appDisplayName': {
                                    'type': 'string'
                                  },
                                  'displayName': {
                                    'type': 'string'
                                  },
                                  'servicePrincipalNames': {
                                    'type': 'array',
                                    'minItems': 1,
                                    'items': {
                                      'type': 'string'
                                    }
                                  }
                                },
                                'required': [
                                  'id',
                                  'appId',
                                  'appDisplayName',
                                  'displayName',
                                  'servicePrincipalNames'
                                ]
                              },
                              'userAppRole': {
                                'type': 'object',
                                'properties': {
                                  'id': {
                                    'type': 'string'
                                  },
                                  'value': {
                                    'type': 'string'
                                  }
                                },
                                'required': [
                                  'id',
                                  'value'
                                ]
                              },
                              'userPrincipalContext': {
                                'type': 'object',
                                'properties': {
                                  'ageGroup': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'companyName': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'country': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'createdDateTime': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'creationType': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'department': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'displayName': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'givenName': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'id': {
                                    'type': 'string'
                                  },
                                  'lastPasswordChangeDateTime': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'mail': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'onPremisesSamAccountName': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'onPremisesSecurityIdentifier': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'onPremiseUserPrincipalName': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'preferredDataLocation': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'preferredLanguage': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'surname': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  },
                                  'userPrincipalName': {
                                    'type': 'string'
                                  },
                                  'userType': {
                                    'type': [
                                      'string',
                                      'null'
                                    ]
                                  }
                                },
                                'required': [
                                  'id',
                                  'userPrincipalName'
                                ]
                              },
                              'claimsForToken': {
                                'type': 'array',
                                'items': {
                                  '$ref': '#/components/schemas/claim'
                                }
                              },
                              'claim': {
                                'type': 'object',
                                'properties': {
                                  'id': {
                                    'type': 'string'
                                  },
                                  'value': {
                                    'oneOf': [
                                      {
                                        'type': 'string'
                                      },
                                      {
                                        'type': 'array',
                                        'items': {
                                          'type': 'string'
                                        }
                                      }
                                    ]
                                  }
                                },
                                'required': [
                                  'id',
                                  'value'
                                ]
                              }
                            }
                          },
                          'tags': [
                            {
                              'name': '10-01-2021-preview'
                            },
                            {
                              'name': 'Authentication Events'
                            },
                            {
                              'name': 'OnTokenIssuanceStart'
                            }
                          ]
                        }";
            }
        }

        /// <summary>Gets the request schema body.</summary>
        /// <value>The request schema.</value>
        public static string RequestSchema
        {
            get
            {
                return @"{
                          '$schema': 'http://json-schema.org/draft-04/schema',
                          'type': 'object',
                          'properties': {
                            'type': {
                              'type': 'string',
                              'enum': [ 'onTokenIssuanceStartCustomExtension' ],
                              'description': 'OnTokenIssuanceStart Event'
                            },
                            'apiSchemaVersion': {
                              'type': 'string',
                              'enum': [ '10-01-2021-preview' ]
                            },
                            'time': {
                              'type': 'string'
                            },
                            'eventListenerId': {
                              'type': 'string'
                            },
                            'customExtensionId': {
                              'type': 'string'
                            },
                            'context': { '$ref': '#/definitions/context' }
                          },
                          'required': [
                            'type',
                            'apiSchemaVersion',
                            'time',
                            'eventListenerId',
                            'customExtensionId',
                            'context'
                          ],

                          'definitions': {
    
                            'context': {
                              'type': 'object',
                              'properties': {
                                'correlationId': {
                                  'type': 'string'
                                },
                                'client': { '$ref': '#/definitions/clientContext'},
                                'authProtocol': { '$ref': '#/definitions/authProtocolContext'},
                                'clientServicePrincipal': { '$ref': '#/definitions/servicePrincipalContext'},
                                'resourceServicePrincipal': { '$ref': '#/definitions/servicePrincipalContext'},
                                'roles': {
                                  'type': ['array', 'null'],
                                  'items': {
                                    '$ref': '#/definitions/userAppRole'
                                  }
                                },
                                'user': { '$ref': '#/definitions/userPrincipalContext'}
                              },
                              'required': [
                                'correlationId',
                                'client',
                                'authProtocol',
                                'clientServicePrincipal',
                                'resourceServicePrincipal',
                                'user'
                              ]
                            },

                            'clientContext': {
                              'type': 'object',
                              'properties': {
                                'ip': {
                                  'type': 'string'
                                },
                                'locale': {
                                  'type': 'string'
                                },
                                'market': {
                                  'type': 'string'
                                }
                              },
                              'required': [
                                'ip'
                              ]
                            },

                            'authProtocolContext': {
                              'type': 'object',
                              'properties': {
                                'type': {
                                  'type': 'string'
                                },
                                'tenantId': {
                                  'type': 'string'
                                }
                              },
                              'required': [
                                'type',
                                'tenantId'
                              ]
                            },

                            'servicePrincipalContext': {
                              'type': 'object',
                              'properties': {
                                'id': {
                                  'type': 'string'
                                },
                                'appId': {
                                  'type': 'string'
                                },
                                'appDisplayName': {
                                  'type': 'string'
                                },
                                'displayName': {
                                  'type': 'string'
                                },
                                'servicePrincipalNames': {
                                  'type': 'array',
                                  'minItems': 1,
                                  'items': {
                                    'type': 'string'
                                  }
                                }
                              },
                              'required': [
                                'id',
                                'appId',
                                'appDisplayName',
                                'displayName',
                                'servicePrincipalNames'
                              ]
                            },

                            'userAppRole': {
                              'type': 'object',
                              'properties': {
                                'id': {
                                  'type': 'string'
                                },
                                'value': {
                                  'type': 'string'
                                }
                              },
                              'required': [
                                'id',
                                'value'
                              ]
                            },

                            'userPrincipalContext': {
                              'type': 'object',
                              'properties': {
                                'ageGroup': {
                                  'type': [ 'string', 'null' ]
                                },
                                'companyName': {
                                  'type': [ 'string', 'null' ]
                                },
                                'country': {
                                  'type': [ 'string', 'null' ]
                                },
                                'createdDateTime': {
                                  'type': [ 'string', 'null' ]
                                },
                                'creationType': {
                                  'type': [ 'string', 'null' ]
                                },
                                'department': {
                                  'type': [ 'string', 'null' ]
                                },
                                'displayName': {
                                  'type': [ 'string', 'null' ]
                                },
                                'givenName': {
                                  'type': [ 'string', 'null' ]
                                },
                                'id': {
                                  'type': 'string'
                                },
                                'lastPasswordChangeDateTime': {
                                  'type': [ 'string', 'null' ]
                                },
                                'mail': {
                                  'type': [ 'string', 'null' ]
                                },
                                'onPremisesSamAccountName': {
                                  'type': [ 'string', 'null' ]
                                },
                                'onPremisesSecurityIdentifier': {
                                  'type': [ 'string', 'null' ]
                                },
                                'onPremiseUserPrincipalName': {
                                  'type': [ 'string', 'null' ]
                                },
                                'preferredDataLocation': {
                                  'type': [ 'string', 'null' ]
                                },
                                'preferredLanguage': {
                                  'type': [ 'string', 'null' ]
                                },
                                'surname': {
                                  'type': [ 'string', 'null' ]
                                },
                                'userPrincipalName': {
                                  'type': 'string'
                                },
                                'userType': {
                                  'type': [ 'string', 'null' ]
                                }
                              },
                              'required': [
                                'id',
                                'userPrincipalName'
                              ]
                            }
                          }
                        }";
            }
        }

        /// <summary>Gets the response schema body.</summary>
        /// <value>The response schema.</value>
        public static string ResponseSchema
        {
            get
            {
                return @"{
                        '$schema': 'http://json-schema.org/draft-04/schema',
                        'type': 'object',
                        'properties': {
                        'type': {
                            'type': 'string',
                            'enum': [ 'onTokenIssuanceStartCustomExtension' ]
                        },
                        'apiSchemaVersion': {
                            'type': 'string',
                            'enum': [ '10-01-2021-preview' ]
                        },
                        'actions': {
                            'type': 'array',
                            'minItems': 1,
                            'maxItems': 1,
                            'items': {
                            'type': 'object',
                            'properties': {
                                'type': {
                                'type': 'string',
                                'enum': [ 'ProvideClaimsForToken' ]
                                }
                            },
                            'allOf': [
                                {
                                'anyOf': [
                                    {
                                    'not': {
                                        'properties': { 'type': { 'enum': ['ProvideClaimsForToken'] } }
                                    }
                                    },
                                    { 
                                    'properties': { 'claims': {'$ref': '#/definitions/claimsForToken'} },
                                    'required': ['claims']
                                    }
                                ]
                                }
                            ],
                            'required': [
                                'type'
                            ]
                            }
                        }
                        },
                        'required': [
                        'type',
                        'apiSchemaVersion',
                        'actions'
                        ],

                        'definitions': {
    
                        'claimsForToken': {
                            'type': 'array',
                            'items': {
                            '$ref': '#/definitions/claim'
                            }
                        },

                        'claim': {
                            'type': 'object',
                            'properties': {
                            'id': {
                                'type': 'string'
                            },
                            'value': {
                                'oneOf': [
                                {
                                    'type': 'string'
                                },
                                {
                                    'type': 'array',
                                    'items': {
                                    'type': 'string'
                                    }
                                }
                                ]
                            }
                            },
                            'required': [
                            'id',
                            'value'
                            ]
                        }
                        }
  
                    }";
            }
        }

        /// <summary>Gets the version name space.</summary>
        /// <value>The version name space.</value>
        public static string VersionNameSpace
        {
            get { return "TokenIssuanceStart.preview.preview_10_01_2021"; }
        }

        /// <summary>Gets the token inssuance start query parameter expected payload</summary>
        /// <value>The token inssuance start query parameter.</value>
        public static string TokenInssuanceStartQueryParameter
        {
            get
            {
                return @"{'tokenClaims':null,'response':null,'payload':null,'requestStatus':'Failed','statusMessage':'','queryParameters':{'param1':'test1','param2':'test2'}}";
            }
        }
    }
}
