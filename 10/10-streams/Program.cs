using System;
using System.IO;
using System.Xml;
using static System.Console;

namespace _10_streams
{
    class Program
    {
        static void Main(string[] args)
        {
            // define an array of strings
            string[] callsigns = new string[] { "Husker", "Starbuck",
            "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack" };
            // define a file to write to using a text writer helper
            string textFile = @"/Users/mick/Documents/dotnet/dotnetTut/10/10-streams/Ch10_Streams.txt";
            // string textFile = @"C:\Code\Ch10_Streams.txt"; // Windows
            StreamWriter text = File.CreateText(textFile);
            // enumerate the strings writing each one to the stream
            foreach (string item in callsigns)
            {
                text.WriteLine(item);
            }
            text.Dispose(); // close the stream
            // output all the contents of the file to the Console
            WriteLine($"{textFile} contains {new FileInfo(textFile).Length} bytes.");
            WriteLine(File.ReadAllText(textFile));
            // define a file to write to using the XML writer helper
            string xmlFile = @"/Users/mick/Documents/dotnet/dotnetTut/10/10-streams/Ch10_Streams.xml";
            // string xmlFile = @"C:\Code\Ch10_Streams.xml";
            FileStream xmlFileStream = File.Create(xmlFile);
            XmlWriter xml = XmlWriter.Create(xmlFileStream,
            new XmlWriterSettings { Indent = true });
            // write the XML declaration
            xml.WriteStartDocument();
            // write a root element
            xml.WriteStartElement("callsigns");
            // enumerate the strings writing each one to the stream
            foreach (string item in callsigns)
            {
                xml.WriteElementString("callsign", item);
            }
            // write the close root element
            xml.WriteEndElement();
            xml.Dispose();
            xmlFileStream.Dispose();
            // output all the contents of the file to the Console
            WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length} bytes.");
            WriteLine(File.ReadAllText(xmlFile));
        }
    }
}
