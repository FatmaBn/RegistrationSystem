using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationSystem.Api.Services
{
    public class UniqueUsernameService
    {
        public List<string> getUniqueUsername(string text)
        {
            List<string> result = new List<string>();

            //Create a dictionary that contains names as key with its occurencies as value
            IDictionary<string, int> names = new Dictionary<string, int>();

            //Split Text to table names
            var lstnames = text.Split(",");
            for (int i = 0; i < lstnames.Length; i++)
            {
                if (string.IsNullOrEmpty(lstnames[i]))
                    continue;
                //If name first appears
                if (!names.ContainsKey(lstnames[i]))
                {
                    names.Add(lstnames[i], 0);
                    result.Add(lstnames[i]);
                }
                else
                {
                    //Increment occurency number
                    names[lstnames[i]] += 1;
                    result.Add(lstnames[i] + names[lstnames[i]]);
                }
            }
            return (result);
        }

    }

}