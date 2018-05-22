using ObjectLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;



namespace FileParserNetStandard {
    
    
    
    public class PersonHandler {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people) {

            People = new List<Person>();

            foreach (List<string> line in people.Skip(1))
            {
                People.Add(new Person(Int32.Parse(line[0]), line[1], line[2], DateTime.Parse(line[3])));
            }

            //DateTime date = DateTime.ParseExact(rows[i][c], "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest() {

            DateTime old = People.Select(p => p.Dob).Min();

            return People.Where(p => p.Dob == old).ToList(); //-- return result here
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id) {

            return People.Find(p => p.Id == id).ToString();  //-- return result here
        }

        public List<Person> GetOrderBySurname() {

            return People.OrderBy(p => p.Surname).ToList();  //-- return result here
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive) {

            return People.Select(p => p.Surname)
                .Where(s => s.StartsWith(searchTerm, !caseSensitive, null))
                .Count();
        }
        
        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate() {
            List<string> result = new List<string>();

            People
                .OrderBy(o => o.Dob)
                .GroupBy(g => g.Dob).ToList()
                .ForEach(f => result.Add($"{f.Key}\t{f.Count()}"));

            return result;  //-- return result here
        }
    }
}