using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using Newtonsoft.Json;

namespace Module2
{
  class Program
  {
    private static readonly Uri _endpointUri = new Uri("https://cosmosdbazurelab.documents.azure.com:443/");
    private static readonly string _primaryKey = "0IOvJkPHld1o4BaMoeJAye5CBzmMvKsZIjJ6m4p0cqSw6bRZPDuBb9waH0pZCSBwlZrNI1SzyeJxH2r89cBCyQ==";
    private static readonly string _databaseId = "UniversityDatabase";
    private static readonly string _collectionId = "StudentCollection";

    public static async Task Main(string[] args)
    {
      // Task 2
      //using (DocumentClient client = new DocumentClient(_endpointUri, _primaryKey))
      //{
      //  Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId);
      //  string sql = "SELECT TOP 5 VALUE s.studentAlias FROM coll s WHERE s.enrollmentYear = 2018 ORDER BY s.studentAlias";
      //  IQueryable<string> query = client.CreateDocumentQuery<string>(collectionLink, new SqlQuerySpec(sql));
      //  foreach (string alias in query)
      //  {
      //    await Console.Out.WriteLineAsync(alias);
      //  }

      //  Console.Read();
      //}

      // Task 3
      //using (DocumentClient client = new DocumentClient(_endpointUri, _primaryKey))
      //{
      //  Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId);
      //  //string sql = "SELECT s.clubs FROM students s WHERE s.enrollmentYear = 2018";
      //  string sql = "SELECT s.clubs FROM students s WHERE s.enrollmentYear = 2018";
      //  IQueryable<Student> query = client.CreateDocumentQuery<Student>(collectionLink, new SqlQuerySpec(sql));

      //  foreach (Student student in query)
      //    foreach (string club in student.Clubs)
      //    {
      //      await Console.Out.WriteLineAsync(club);
      //    }

      //  Console.Read();
      //}


      //// Point 27
      //using (DocumentClient client = new DocumentClient(_endpointUri, _primaryKey))
      //{
      //  Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId);
      //  //string sql = "SELECT s.clubs FROM students s WHERE s.enrollmentYear = 2018";
      //  string sql = "SELECT activity FROM students s JOIN activity IN s.clubs WHERE s.enrollmentYear = 2018";
      //  IQueryable<StudentActivity> query = client.CreateDocumentQuery<StudentActivity>(collectionLink, new SqlQuerySpec(sql));

      //  foreach (StudentActivity studentActivity in query)
      //  {
      //    await Console.Out.WriteLineAsync(studentActivity.Activity);
      //  }

      //  Console.Read();
      //}

      ////// Point 40
      //using (DocumentClient client = new DocumentClient(_endpointUri, _primaryKey))
      //{
      //  Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId);
      //  string sql = "SELECT VALUE activity FROM students s JOIN activity IN s.clubs WHERE s.enrollmentYear = 2018";
      //  IQueryable<string> query = client.CreateDocumentQuery<string>(collectionLink, new SqlQuerySpec(sql));

      //  foreach (string activity in query)
      //  {
      //    await Console.Out.WriteLineAsync(activity);
      //  }

      //  Console.Read();
      //}

      //// Task IV: Projecting Query Results
      //using (DocumentClient client = new DocumentClient(_endpointUri, _primaryKey))
      //{
      //  Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId);
      //  string sql =
      //    "SELECT VALUE { 'id': s.id, 'name': CONCAT(s.firstName, ' ', s.lastName), 'email': { 'home': s.homeEmailAddress, 'school': CONCAT(s.studentAlias, '@contoso.edu') } } FROM students s WHERE s.enrollmentYear = 2018";
      //  IQueryable<StudentProfile> query = client.CreateDocumentQuery<StudentProfile>(collectionLink, new SqlQuerySpec(sql));
      //  foreach (StudentProfile profile in query)
      //  {
      //    await Console.Out.WriteLineAsync($"[{profile.Id}]\t{profile.Name,-20}\t{profile.Email.School,-50}\t{profile.Email.Home}");
      //  }
      //}

      //// Exercise 4: Implement Pagination using the .NET SDK
      //  using (DocumentClient client = new DocumentClient(_endpointUri, _primaryKey))
      //  {
      //    Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId);
      //    string sql =
      //      "SELECT VALUE { 'id': s.id, 'name': CONCAT(s.firstName, ' ', s.lastName), 'email': { 'home': s.homeEmailAddress, 'school': CONCAT(s.studentAlias, '@contoso.edu') } } FROM students s WHERE s.enrollmentYear = 2018";
      //    IDocumentQuery<StudentProfile> query = client.CreateDocumentQuery<StudentProfile>(collectionLink, new SqlQuerySpec(sql), new FeedOptions { MaxItemCount = 100 }).AsDocumentQuery();

      //    int pageCount = 0;
      //    while (query.HasMoreResults)
      //    {
      //      await Console.Out.WriteLineAsync($"---Page #{++pageCount:0000}---");
      //      foreach (StudentProfile profile in await query.ExecuteNextAsync())
      //      {
      //        await Console.Out.WriteLineAsync($"\t[{profile.Id}]\t{profile.Name,-20}\t{profile.Email.School,-50}\t{profile.Email.Home}");
      //      }
      //    }

      //    Console.Read();
      //  }

      //Exercise 5: Implement Cross-Partition Queries
      //Task 1

      //using (DocumentClient client = new DocumentClient(_endpointUri, _primaryKey))
      //{
      //  await client.OpenAsync();
      //  Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId);
      //  IEnumerable<Student> query = client
      //    .CreateDocumentQuery<Student>(collectionLink, new FeedOptions { PartitionKey = new PartitionKey(2016) })
      //    .Where(student => student.projectedGraduationYear == 2020);

      //  foreach (Student student in query)
      //  {
      //    Console.Out.WriteLine($"Enrolled: {student.enrollmentYear}\tGraduation: {student.projectedGraduationYear}\t{student.studentAlias}");
      //  }
      //}

      //Task 2 Execute Cross-Partition Query
      //using (DocumentClient client = new DocumentClient(_endpointUri, _primaryKey))
      //{
      //  await client.OpenAsync();
      //  Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId);
      //  IEnumerable<Student> query = client
      //    .CreateDocumentQuery<Student>(collectionLink, new FeedOptions { EnableCrossPartitionQuery = true })
      //    .Where(student => student.projectedGraduationYear == 2020);

      //  foreach (Student student in query)
      //  {
      //    Console.Out.WriteLine($"Enrolled: {student.enrollmentYear}\tGraduation: {student.projectedGraduationYear}\t{student.studentAlias}");
      //  }

      //  Console.Read();
      //}

      //// Task 3 Implement Continuation Token
      //using (DocumentClient client = new DocumentClient(_endpointUri, _primaryKey))
      //{
      //  await client.OpenAsync();

      //  Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId);

      //  string continuationToken = String.Empty;
      //  do
      //  {
      //    FeedOptions options = new FeedOptions
      //    {
      //      EnableCrossPartitionQuery = true,
      //      RequestContinuation = continuationToken
      //    };
      //    IDocumentQuery<Student> query = client
      //      .CreateDocumentQuery<Student>(collectionLink, options)
      //      .Where(student => student.age < 18)
      //      .AsDocumentQuery();

      //    FeedResponse<Student> results = await query.ExecuteNextAsync<Student>();
      //    continuationToken = results.ResponseContinuation;

      //    await Console.Out.WriteLineAsync($"ContinuationToken:\t{continuationToken}");
      //    foreach (Student result in results)
      //    {
      //      await Console.Out.WriteLineAsync($"[Age: {result.age}]\t{result.studentAlias}@consoto.edu");
      //    }
      //    await Console.Out.WriteLineAsync();
      //  }
      //  while (!String.IsNullOrEmpty(continuationToken));

      //// Task IV Observe How Partitions Are Accessed in a Cross-Partition Query

      //using (DocumentClient client = new DocumentClient(_endpointUri, _primaryKey))
      //{
      //  await client.OpenAsync();

      //  Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId);

      //  FeedOptions options = new FeedOptions
      //  {
      //    EnableCrossPartitionQuery = true
      //  };

      //  string sql = "SELECT * FROM students s WHERE s.academicStatus.suspension = true";

      //  IDocumentQuery<Student> query = client
      //    .CreateDocumentQuery<Student>(collectionLink, sql, options)
      //    .AsDocumentQuery();

      //  int pageCount = 0;
      //  while (query.HasMoreResults)
      //  {
      //    await Console.Out.WriteLineAsync($"---Page #{++pageCount:0000}---");
      //    foreach (Student result in await query.ExecuteNextAsync())
      //    {
      //      await Console.Out.WriteLineAsync($"Enrollment: {result.enrollmentYear}\tBalance: {result.financialData.tuitionBalance}\t{result.studentAlias}@consoto.edu");
      //    }
      //  }
      //}

      //// Point 11

      using (DocumentClient client = new DocumentClient(_endpointUri, _primaryKey))
      {
        await client.OpenAsync();

        Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId);

        FeedOptions options = new FeedOptions
        {
          EnableCrossPartitionQuery = true
        };
        //Point 11
        //string sql = "SELECT * FROM students s WHERE s.financialData.tuitionBalance > 14000";

        //Point 17
        //string sql = "SELECT * FROM students s WHERE s.financialData.tuitionBalance > 14950";
        
        //Point 23
        //string sql = "SELECT * FROM students s WHERE s.financialData.tuitionBalance > 14996";

        //Point 29
        string sql = "SELECT * FROM students s WHERE s.financialData.tuitionBalance > 14998";

        IDocumentQuery<Student> query = client
          .CreateDocumentQuery<Student>(collectionLink, sql, options)
          .AsDocumentQuery();

        int pageCount = 0;
        while (query.HasMoreResults)
        {
          await Console.Out.WriteLineAsync($"---Page #{++pageCount:0000}---");
          foreach (Student result in await query.ExecuteNextAsync())
          {
            await Console.Out.WriteLineAsync($"Enrollment: {result.enrollmentYear}\tBalance: {result.financialData.tuitionBalance}\t{result.studentAlias}@consoto.edu");
          }
        }
      }

    }
  }
}
