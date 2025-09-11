using System;
using System.Threading.Tasks;
using System.IO;

namespace ComputerVisionQuickstart
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Histoview OCR Demo\n");

            var client = ComputerVisionService.Authenticate();

            string inputFile = "scans/with_the_colors_WWI_letter.jpg";
            string preprocessedFile = "scans/preprocessed_with_the_colors_WWI_letter.jpg";

            // Preprocess the image
            ImagePreprocessor.Preprocess(inputFile, preprocessedFile);

            Console.WriteLine($"Processing preprocessed file: {preprocessedFile}");

            string transcription = await ComputerVisionService.ReadHandwrittenTextFromFile(client, preprocessedFile);

            Console.WriteLine("\n--- Transcription Result ---");
            Console.WriteLine(transcription);

            // Optional: save to text file
            File.WriteAllText($"output_{Path.GetFileNameWithoutExtension(inputFile)}.txt", transcription);
        }
    }
}
