using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;
using ObjectLibrary;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise {
 
    
    internal class Delegate_Exercise {
        public static void Main(string[] args)
        {
            var ch = new CsvHandler();
            var dp = new DataParser();
            string csvPath = "D:/Swinburne/Lambda_Linq/data.csv";
            string writeFile = "D:/Swinburne/Lambda_Linq/output.csv";

            Func<List<List<string>>, List<List<string>>> dataHandler = dp.StripQuotes;
            dataHandler += dp.StripWhiteSpace;
            dataHandler += StripHashTag;

            ch.ProcessCsv(csvPath, writeFile, dataHandler);

        }

        static List<List<string>> StripHashTag(List<List<string>> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                for (int c = 0; c < data[i].Count; c++)
                {
                    data[i][c] = data[i][c].Trim('#');
                }
            }
            return data;
        }

    }
}