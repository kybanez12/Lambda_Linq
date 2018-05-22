﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FileParserNetStandard {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {
   
            for (int i = 0; i < data.Count; i++)
            {
                for (int c = 0; c < data[i].Count; c++)
                {
                    data[i][c] = data[i][c].Trim();
                }
            }

            return data;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {

            for (int i = 0; i < data.Count; i++)
            {
                for (int c = 0; c < data[i].Count; c++)
                {
                    data[i][c] = data[i][c].Trim('"', '\'');
                }
            }
            return data;
        }

    }
}