using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using ObjectLibrary;

namespace FileParserNetStandard {
    public class FileHandler {
       
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath) {

            List<string> lines = File.ReadAllLines(filePath).ToList();

            return lines;
        }


        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows)
        {

            using (var sw = new StreamWriter(filePath))
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    for (int c = 0; c < rows[i].Count; c++)
                    {
                        if (c > 0 && (long.TryParse(rows[i][c], out long dateTime)) == true)
                        {
                            sw.Write(String.Format("{0:dd'/'MM'/'yyyy hh:mm:ss tt}", new DateTime(dateTime)));
                        }

                        else
                        {
                            sw.Write(rows[i][c]);
                        }
                            

                        if (c != (rows[i].Count - 1))
                        {
                            sw.Write(delimeter);
                        }
                            
                    }

                    sw.WriteLine();
                }
            }


            //bloody datetime
            //var results = rows.SelectMany(i => i).ToList();
            //int x = rows[0].Count();

            //using (var sw = new StreamWriter(filePath))
            //{

            //    for (int i = 0; i < results.Count; i++)
            //    {
            //        if ((i + 1) % x == 0)
            //        {
            //            sw.WriteLine(results[i]);
            //        }
            //        else
            //        {
            //            sw.Write(results[i] + delimeter);
            //        }

            //    }
            //}
        }

            

        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimeter) {

            var parseData = new List<List<string>>();

            for (int i = 0; i < data.Count; i++)
            {
                parseData.Add(data[i].Split(delimeter).ToList());
            }

            return parseData; //-- return result here
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data) {
            var parseData = new List<List<string>>();

            for (int i = 0; i < data.Count; i++)
            {
                parseData.Add(data[i].Split(',').ToList());
            }

            return parseData;
        }
    }
}