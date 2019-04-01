{
    "schemaVersion": "2014-01.1.0-preview",
    "parameters": {
        "string": {
            "type": "string"
        },
        "securestring": {
            "type": "securestring"
        },
        "int": {
            "type": "int"
        },
        "bool": {
            "type": "bool"
        }
    },
    "variables": {
        "string": "string",
        "int": 42,
        "bool": true,
        "array": [
            1,
            2,
            3,
            4
        ],
        "object": {
            "string": "string",
            "int": 42,
            "bool": true,
            "array": [
                1,
                2,
                3,
                4
            ],
            "object": {
                "vmSize": "Large",
                "location": "West US"
            }
        }
    },    
    "resources": [
        {
            "name": "resource1",
            "type": "ResourceProviderTestHost/TestResourceType",
            "apiVersion": "1.0",
            "resources": [
                {
                    "name": "nestedresource1",
                    "type": "TestResourceTypeNestedOne",
                    "apiVersion": "1.0",
                    "properties": {
                        "disktype": "OS",
                        "mediaLink": "vhds/WebTierOs1.vhd",
                        "sourceMediaLink": "Windows-Server-2012-R2-201310.01-en.us-127GB.vhd"
                    },
                    "dependsOn": [
                        "ResourceProviderTestHost/TestResourceType/resource2"
                    ]                    
                }
            ]
        },
        {
            "name": "resource2",
            "type": "ResourceProviderTestHost/TestResourceType",
            "apiVersion": "1.0",
            "location": "DevFabric",
            "dependsOn": [
                "ResourceProviderTestHost/TestResourceType/resource1"
            ],
            "properties": {
                "availabilitySet": "WebAvailabilitySet",
                "hardwareProfile": {
                    "vmSize": "small"
                }
            },
            "tags": {
                "key1": "value1",
                "key2": "value2"
            }
        }
    ],
    "outputs": {
        "string": {
            "type": "string",
            "value": "myvalue"
        },
        "securestring": {
            "type": "securestring",
            "value": "myvalue"
        },
        "int": {
            "type": "int",
            "value": 42
        },
        "bool": {
            "type": "bool",
            "value": true
        }
    }
}
