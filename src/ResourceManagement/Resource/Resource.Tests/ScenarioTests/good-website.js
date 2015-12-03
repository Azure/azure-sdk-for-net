{
    "$schema": "http://schemas.management.azure.com/deploymentTemplate?api-version=2014-04-01-preview",
    "contentVersion": "1.0.0.0",
    "parameters": {
        "siteName": {
            "type": "string"
        },
        "hostingPlanName": {
            "type": "string"
        },
        "siteMode": {
            "type": "string"
        },
        "computeMode": {
            "type": "string"
        },
        "siteLocation": {
            "type": "string"
        },
        "sku": {
            "type": "string"
        },
        "workerSize": {
            "type": "string"
        }
    },
    "resources": [
        {
            "apiVersion": "01-01-2014",
            "name": "[parameters('siteName')]",
            "type": "Microsoft.Web/Sites",
            "location": "[parameters('siteLocation')]",
            "dependsOn": [
                "[concat('Microsoft.Web/serverFarms/', parameters('hostingPlanName'))]"
            ],
            "properties": {
                "name": "[parameters('siteName')]",
                "serverFarm": "[parameters('hostingPlanName')]",
                "computeMode": "[parameters('computeMode')]",
                "siteMode": "[parameters('siteMode')]"
            }
        },
        {
            "apiVersion": "01-01-2014",
            "name": "[parameters('hostingPlanName')]",
            "type": "Microsoft.Web/serverFarms",
            "location": "[parameters('siteLocation')]",
            "properties": {
                "name": "[parameters('hostingPlanName')]",
                "sku": "[parameters('sku')]",
                "workerSize": "[parameters('workerSize')]",
                "numberOfWorkers": "1"
            }
        }
    ]
}