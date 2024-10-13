using System.Xml.Serialization;
using Demo03.DemoXmlSerializer02;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "people.xml";
        // Create an object graph
        var people = new List<Person>
        {
        new Person(30000M)
        {
            FirstName = "Alice",
            LastName = "Smith",
            DateOfBirth = new DateTime(1972, 3, 16)
        },
        new Person(20000M)
        {
            FirstName = "Charlie",
            LastName = "Cox",
            DateOfBirth = new DateTime(1984, 5, 4),
            Children = new HashSet<Person>
            {
                new Person(0M) {
                    FirstName = "Sally",
                    LastName = "Cox",
                    DateOfBirth = new DateTime (2000, 7, 12) } }
            }
        };
        // Create object that will format a List of Persons as XML
        var xs = new XmlSerializer(typeof(List<Person>));

        // create a file to write to
        using FileStream stream = File.Create(fileName);

        // serialize the object graph to the stream
        xs.Serialize(stream, people);
        Console.WriteLine("Written {0:N0} bytes of XML to {1}",
            new FileInfo(fileName).Length, fileName);
        stream.Close();
        Console.WriteLine(new string('*', 30));

        // Display the serialized object graph
        Console.WriteLine(File.ReadAllText(fileName));
        Console.WriteLine(new string('*', 30));

        // Deserializing with XML
        using FileStream xmlLoad = File.Open(fileName, FileMode.Open);
        // Deserialize and cast the object graph into a List of Person
        var loadedPeople = (List<Person>)xs.Deserialize(xmlLoad);
        foreach (var item in loadedPeople)
        {
            Console.WriteLine($"{item.LastName} has " +
            $"{item.Children?.Count ?? 0} children.");
        }
        xmlLoad.Close();
        Console.ReadLine();
    }
}

//Written 652 bytes of XML to people.xml
//******************************
//<?xml version="1.0" encoding="utf-8"?>
//<ArrayOfPerson xmlns:xsi = "http://www.w3.org/2001/XMLSchema-instance" xmlns: xsd = "http://www.w3.org/2001/XMLSchema" >
//  < Person >
//    < FirstName > Alice </ FirstName >
//    < LastName > Smith </ LastName >
//    < DateOfBirth > 1972 - 03 - 16T00: 00:00 </ DateOfBirth >
//  </ Person >
//  < Person >
//    < FirstName > Charlie </ FirstName >
//    < LastName > Cox </ LastName >
//    < DateOfBirth > 1984 - 05 - 04T00: 00:00 </ DateOfBirth >
//    < Children >
//      < Person >
//        < FirstName > Sally </ FirstName >
//        < LastName > Cox </ LastName >
//        < DateOfBirth > 2000 - 07 - 12T00: 00:00 </ DateOfBirth >
//      </ Person >
//    </ Children >
//  </ Person >
//</ ArrayOfPerson >
//******************************
//Smith has 0 children.
//Cox has 1 children.
