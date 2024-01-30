// See https://aka.ms/new-console-template for more information
using MongoDB.Bson;
using MongoDB.Driver;

Console.WriteLine("Hello, World!");

var client = new MongoClient("mongodb://localhost:27017?replicaSet=rs0");

var database = client.GetDatabase("test");

var collection = database.GetCollection<object>("event");

using (var cursor = collection.Watch())
{
    foreach (var change in cursor.ToEnumerable())
    {
        Console.WriteLine(change.ToString());
        // process change event
    }
}


Console.WriteLine("İşlem tamam");