using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace Module4
{
  public class Program
  {
    private static readonly Uri _endpointUri = new Uri("https://cosmosdbazurelab.documents.azure.com:443/");
    private static readonly string _primaryKey = "0IOvJkPHld1o4BaMoeJAye5CBzmMvKsZIjJ6m4p0cqSw6bRZPDuBb9waH0pZCSBwlZrNI1SzyeJxH2r89cBCyQ==";
    private static readonly string _databaseId = "FinancialDatabase";
    private static readonly string _collectionId = "PeopleCollection";

    //public static async Task Main(string[] args)
    //{
    //  using (DocumentClient client = new DocumentClient(_endpointUri, _primaryKey))
    //  {
    //    Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId);
    //    object doc = new Bogus.Person();
    //    ResourceResponse<Document> response = await client.CreateDocumentAsync(collectionLink, doc);
    //    await Console.Out.WriteLineAsync($"{response.RequestCharge} RUs");
    //  }

    //  Console.Read();
    //}

    public static async Task Main(string[] args)
    {
      using (DocumentClient client = new DocumentClient(_endpointUri, _primaryKey))
      {
        Uri documentLink = UriFactory.CreateDocumentUri(_databaseId, _collectionId, "example.document");
        object doc = new
        {
          id = "example.document",
          FirstName = "Example",
          LastName = "Person"
        };
        ResourceResponse<Document> readResponse = await client.ReadDocumentAsync(documentLink);
        await Console.Out.WriteLineAsync($"{readResponse.StatusCode}");
      }
    }
  }

}
