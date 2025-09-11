using OpenCvSharp;
public static class ImagePreprocessor
{
    public static void Preprocess(string inputPath, string outputPath)
    {
        using var mat = Cv2.ImRead(inputPath, ImreadModes.Grayscale);

        // Optional: apply thresholding to improve OCR
        Cv2.Threshold(mat, mat, 0, 255, ThresholdTypes.Otsu);

        Cv2.ImWrite(outputPath, mat);
    }
}