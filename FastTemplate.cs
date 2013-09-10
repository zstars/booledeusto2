using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleDeustoTwo
{

    /// <summary>
    /// Small template engine intended to be extremely simplistic.
    /// </summary>
    public class FastTemplate
    {

        /// <summary>
        /// Renders the template using the provided variables.
        /// </summary>
        /// <param name="template"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        public string Replace(string template, Dictionary<string, string> variables)
        {
            foreach (KeyValuePair<string, string> entry in variables)
                template = template.Replace("{{" + entry.Key + "}}", entry.Value);
            return template;
        }
    }
}
