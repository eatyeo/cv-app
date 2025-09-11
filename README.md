# Histoview OCR Demo
Histoview OCR Demo is a C#/.NET 9 console application that performs OCR (Optical Character Recognition) on historical handwritten documents. It uses a combination of OpenCvSharp for image preprocessing, Tesseract for local OCR, and Azure Cognitive Services Computer Vision for cloud-based handwritten text recognition.

https://cv-app44.cognitiveservices.azure.com/

## Features
- Preprocess images (grayscale conversion, thresholding) for improved OCR accuracy.
- Perform OCR on preprocessed images using Tesseract.
- Read handwritten text using Azure Computer Vision.
- Save transcription results to a text file.
- Designed for macOS ARM64 (Apple Silicon) with OpenCvSharp runtime support.

## Prerequisites
- .NET 9 SDK
- Homebrew (for Tesseract installation)
- Tesseract OCR installed via Homebrew:
`brew install tesseract`
- Azure Cognitive Services subscription with Computer Vision resource --> Set the environment variables:
`export VISION_KEY=<your-azure-key>`
`export VISION_ENDPOINT=<your-azure-endpoint>`

## Getting Started


## Dependencies
- OpenCvSharp4 – Image processing and deskewing.
- OpenCvSharp4.runtime.osx_arm64 – Runtime for Apple Silicon.
- System.Drawing.Common – Basic image manipulation.
- Tesseract - Local OCR engine.
- Microsoft.Azure.CognitiveServices.Vision.ComputerVision – Cloud OCR.

## Notes
- The preprocessing step uses grayscale conversion and Otsu thresholding to improve OCR performance.