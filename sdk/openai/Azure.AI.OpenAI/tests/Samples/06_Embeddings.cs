// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Identity;
using OpenAI.Embeddings;

namespace Azure.AI.OpenAI.Samples;

public partial class AzureOpenAISamples
{
    public void BasicEmbeddings()
    {
        #region Snippet:BasicEmbeddings
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        EmbeddingClient embeddingClient = azureClient.GetEmbeddingClient("my-text-embedding-deployment");

        // Generate embeddings for a single text
        string text = "Azure OpenAI provides powerful AI capabilities for developers.";
        
        OpenAIEmbedding embedding = embeddingClient.GenerateEmbedding(text);
        
        var floats = embedding.ToFloats();
        Console.WriteLine($"Generated embedding with {floats.Length} dimensions");
        Console.WriteLine($"First few values: [{string.Join(", ", floats.Span.Slice(0, Math.Min(5, floats.Length)).ToArray().Select(v => v.ToString("F4")))}...]");
        #endregion
    }

    public void BatchEmbeddings()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        EmbeddingClient embeddingClient = azureClient.GetEmbeddingClient("my-text-embedding-deployment");

        #region Snippet:BatchEmbeddings
        // Generate embeddings for multiple texts in a single request
        string[] texts = {
            "Machine learning is a subset of artificial intelligence.",
            "Natural language processing helps computers understand human language.",
            "Computer vision enables machines to interpret visual information.",
            "Deep learning uses neural networks with multiple layers."
        };

        OpenAIEmbeddingCollection embeddings = embeddingClient.GenerateEmbeddings(texts);
        
        Console.WriteLine($"Generated {embeddings.Count} embeddings:");
        for (int i = 0; i < embeddings.Count; i++)
        {
            var floats = embeddings[i].ToFloats();
            Console.WriteLine($"Text {i + 1}: \"{texts[i]}\"");
            Console.WriteLine($"  Embedding dimensions: {floats.Length}");
            Console.WriteLine($"  First few values: [{string.Join(", ", floats.Span.Slice(0, Math.Min(3, floats.Length)).ToArray().Select(v => v.ToString("F4")))}...]");
        }
        #endregion
    }

    public void SemanticSearch()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        EmbeddingClient embeddingClient = azureClient.GetEmbeddingClient("my-text-embedding-deployment");

        #region Snippet:SemanticSearch
        // Create a knowledge base of documents
        string[] documents = {
            "The Azure cloud platform provides scalable computing resources and services for businesses.",
            "Machine learning algorithms can analyze large datasets to identify patterns and make predictions.",
            "Cybersecurity measures protect digital systems from unauthorized access and data breaches.",
            "Sustainable energy solutions include solar panels, wind turbines, and battery storage systems.",
            "Quantum computing uses quantum mechanical phenomena to process information in novel ways.",
            "Blockchain technology creates immutable ledgers for secure and transparent transactions.",
            "Artificial intelligence enables machines to simulate human cognitive functions."
        };

        // Generate embeddings for all documents
        Console.WriteLine("Creating knowledge base embeddings...");
        OpenAIEmbeddingCollection documentEmbeddings = embeddingClient.GenerateEmbeddings(documents);

        // User query
        string query = "What are cloud computing services?";
        Console.WriteLine($"\nUser query: \"{query}\"");
        
        // Generate embedding for the query
        OpenAIEmbedding queryEmbedding = embeddingClient.GenerateEmbedding(query);

        // Calculate cosine similarity between query and each document
        var similarities = new List<(int Index, double Similarity, string Document)>();
        
        for (int i = 0; i < documentEmbeddings.Count; i++)
        {
            double similarity = CalculateCosineSimilarity(
                queryEmbedding.ToFloats().ToArray(), 
                documentEmbeddings[i].ToFloats().ToArray());
            
            similarities.Add((i, similarity, documents[i]));
        }

        // Sort by similarity (highest first)
        similarities.Sort((a, b) => b.Similarity.CompareTo(a.Similarity));

        Console.WriteLine("\nMost relevant documents:");
        for (int i = 0; i < Math.Min(3, similarities.Count); i++)
        {
            var result = similarities[i];
            Console.WriteLine($"{i + 1}. Similarity: {result.Similarity:F4}");
            Console.WriteLine($"   Document: {result.Document}");
            Console.WriteLine();
        }
        #endregion
    }

    public void TextClustering()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        EmbeddingClient embeddingClient = azureClient.GetEmbeddingClient("my-text-embedding-deployment");

        #region Snippet:TextClustering
        // Sample customer feedback texts for clustering
        string[] customerFeedback = {
            "The delivery was very fast and the product arrived in perfect condition.",
            "Customer service was unhelpful and took too long to respond to my inquiry.",
            "Great product quality but the price is a bit high for what you get.",
            "Shipping took forever and the package was damaged when it arrived.",
            "Excellent customer support team, they resolved my issue quickly.",
            "The product exceeded my expectations and works exactly as advertised.",
            "Website is difficult to navigate and the checkout process is confusing.",
            "Fast shipping and excellent packaging, will definitely order again.",
            "Product quality is poor and not worth the money spent.",
            "Outstanding service and quick delivery, highly recommend!"
        };

        Console.WriteLine("Generating embeddings for customer feedback analysis...");
        OpenAIEmbeddingCollection feedbackEmbeddings = embeddingClient.GenerateEmbeddings(customerFeedback);

        // Simple clustering: find feedback items that are similar to each other
        Console.WriteLine("\nFinding similar feedback clusters:");
        
        var processed = new bool[customerFeedback.Length];
        int clusterNumber = 1;

        for (int i = 0; i < customerFeedback.Length; i++)
        {
            if (processed[i]) continue;

            var cluster = new List<(int Index, string Text, double Similarity)>();
            cluster.Add((i, customerFeedback[i], 1.0));
            processed[i] = true;

            // Find similar items
            for (int j = i + 1; j < customerFeedback.Length; j++)
            {
                if (processed[j]) continue;

                double similarity = CalculateCosineSimilarity(
                    feedbackEmbeddings[i].ToFloats().ToArray(),
                    feedbackEmbeddings[j].ToFloats().ToArray());

                // Group items with similarity > 0.8 (adjust threshold as needed)
                if (similarity > 0.8)
                {
                    cluster.Add((j, customerFeedback[j], similarity));
                    processed[j] = true;
                }
            }

            // Only show clusters with multiple items
            if (cluster.Count > 1)
            {
                Console.WriteLine($"\nCluster {clusterNumber}:");
                foreach (var item in cluster.OrderByDescending(x => x.Similarity))
                {
                    Console.WriteLine($"  {item.Text} (similarity: {item.Similarity:F3})");
                }
                clusterNumber++;
            }
        }
        
        Console.WriteLine("\nClustering complete! This helps identify:");
        Console.WriteLine("- Common themes in customer feedback");
        Console.WriteLine("- Similar complaints or compliments");
        Console.WriteLine("- Areas for business improvement");
        #endregion
    }

    public void EmbeddingBasedRecommendations()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        EmbeddingClient embeddingClient = azureClient.GetEmbeddingClient("my-text-embedding-deployment");

        #region Snippet:EmbeddingBasedRecommendations
        // Product catalog with descriptions
        var products = new Dictionary<string, string>
        {
            ["laptop-gaming"] = "High-performance gaming laptop with RTX graphics card, 16GB RAM, and fast SSD storage for gaming enthusiasts.",
            ["laptop-business"] = "Professional business laptop with long battery life, lightweight design, and enterprise security features.",
            ["smartphone-camera"] = "Smartphone with advanced camera system, multiple lenses, and AI photography features for content creators.",
            ["smartphone-budget"] = "Affordable smartphone with essential features, good battery life, and reliable performance for everyday use.",
            ["headphones-noise"] = "Premium noise-canceling headphones with superior audio quality and comfort for long listening sessions.",
            ["headphones-sports"] = "Wireless sports earbuds with secure fit, sweat resistance, and motivating sound for workouts.",
            ["tablet-creative"] = "Professional tablet with stylus support, high-resolution display, and creative apps for digital artists.",
            ["tablet-reading"] = "Lightweight tablet perfect for reading e-books, browsing the web, and consuming media content."
        };

        // Generate embeddings for all product descriptions
        Console.WriteLine("Building product recommendation system...");
        var productNames = products.Keys.ToArray();
        var productDescriptions = products.Values.ToArray();
        
        OpenAIEmbeddingCollection productEmbeddings = embeddingClient.GenerateEmbeddings(productDescriptions);

        // Customer preference query
        string customerQuery = "I need a device for creating digital art and design work";
        Console.WriteLine($"\nCustomer query: \"{customerQuery}\"");
        
        OpenAIEmbedding queryEmbedding = embeddingClient.GenerateEmbedding(customerQuery);

        // Calculate relevance scores
        var recommendations = new List<(string Product, string Description, double Score)>();
        
        for (int i = 0; i < productEmbeddings.Count; i++)
        {
            double score = CalculateCosineSimilarity(
                queryEmbedding.ToFloats().ToArray(),
                productEmbeddings[i].ToFloats().ToArray());
            
            recommendations.Add((productNames[i], productDescriptions[i], score));
        }

        // Sort by relevance score
        recommendations.Sort((a, b) => b.Score.CompareTo(a.Score));

        Console.WriteLine("\nRecommended products:");
        for (int i = 0; i < Math.Min(3, recommendations.Count); i++)
        {
            var rec = recommendations[i];
            Console.WriteLine($"{i + 1}. {rec.Product} (relevance: {rec.Score:F3})");
            Console.WriteLine($"   {rec.Description}");
            Console.WriteLine();
        }
        
        Console.WriteLine("Recommendation system can be used for:");
        Console.WriteLine("- E-commerce product suggestions");
        Console.WriteLine("- Content recommendation engines");
        Console.WriteLine("- Personalized search results");
        #endregion
    }

    #region Helper Methods
    /// <summary>
    /// Calculates cosine similarity between two vectors
    /// </summary>
    private static double CalculateCosineSimilarity(float[] vectorA, float[] vectorB)
    {
        if (vectorA.Length != vectorB.Length)
            throw new ArgumentException("Vectors must have the same length");

        double dotProduct = 0;
        double magnitudeA = 0;
        double magnitudeB = 0;

        for (int i = 0; i < vectorA.Length; i++)
        {
            dotProduct += vectorA[i] * vectorB[i];
            magnitudeA += vectorA[i] * vectorA[i];
            magnitudeB += vectorB[i] * vectorB[i];
        }

        magnitudeA = Math.Sqrt(magnitudeA);
        magnitudeB = Math.Sqrt(magnitudeB);

        return dotProduct / (magnitudeA * magnitudeB);
    }
    #endregion
}