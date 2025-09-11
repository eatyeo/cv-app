using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Rest;

namespace ComputerVisionQuickstart
{
    public static class ComputerVisionService
    {
        // Environment variables for your Azure credentials
        private static readonly string key = Environment.GetEnvironmentVariable("VISION_KEY") 
            ?? throw new InvalidOperationException("VISION_KEY not set");
        private static readonly string endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT") 
            ?? throw new InvalidOperationException("VISION_ENDPOINT not set");

        // Authenticate to Azure Cognitive Services
        public static ComputerVisionClient Authenticate()
        {
            return new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
            { Endpoint = endpoint };
        }

        // Read handwritten text from a local file
        public static async Task<string> ReadHandwrittenTextFromFile(ComputerVisionClient client, string localFile)
        {
            using (FileStream stream = new FileStream(localFile, FileMode.Open))
            {
                var textHeaders = await client.ReadInStreamAsync(stream);
                string operationId = textHeaders.OperationLocation[^36..];

                ReadOperationResult results;
                do
                {
                    results = await client.GetReadResultAsync(Guid.Parse(operationId));
                    Thread.Sleep(1000);
                }
                while (results.Status == OperationStatusCodes.Running ||
                       results.Status == OperationStatusCodes.NotStarted);

                var lines = results.AnalyzeResult.ReadResults
                    .SelectMany(page => page.Lines)
                    .Select(line => line.Text);

                return string.Join(Environment.NewLine, lines);
            }
        }
    }
}
