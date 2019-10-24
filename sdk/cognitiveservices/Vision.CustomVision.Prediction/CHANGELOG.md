# 1.0.0
This is a public release of the Cognitive Services Custom Vision Prediction SDK.

Changes in this release:
1) PredictImage and PredictImageUrl have been replaced with project type specific calls.
        ClassifyImage and ClassifyImageUrl for image classification projects.
        DetectImage and DetectImageUrl for object detection projects .
2) Prediction methods now take a name to designate which published iteration to use. Iterations can be published using the Custom Vision Training SDK.