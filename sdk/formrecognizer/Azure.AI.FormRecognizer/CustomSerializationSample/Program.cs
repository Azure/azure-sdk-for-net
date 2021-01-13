using System;
using System.IO;
using System.Threading.Tasks;
using Azure;
using Azure.AI.FormRecognizer;
using Azure.AI.FormRecognizer.Models;

namespace CustomSerializationSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            FormRecognizerClient client = new FormRecognizerClient(new Uri("formrecognizer.azure.com"), new AzureKeyCredential("MyCredential"));

            using var receiptForm = new FileStream("MyReceipt.pdf", FileMode.Open);
            RecognizeFormsOperation<Receipt> operation = client.StartRecognizeForms<Receipt>(PrebuiltFormModel.BasicUSReceipts, receiptForm);
            Response<RecognizedFormCollection<Receipt>> response = await operation.WaitForCompletionAsync();
            RecognizedFormCollection<Receipt> receipts = response.Value;


            // Insert forms as records into a DB
            using ReceiptContext db = new ReceiptContext();

            foreach (Receipt receipt in receipts)
            {
                Console.WriteLine($"Merchant Name: '{receipt.MerchantName}', with confidence {merchantNameField.Confidence}");

                db.Add(receipt);
            }

            db.SaveChanges();
        }
    }
}
