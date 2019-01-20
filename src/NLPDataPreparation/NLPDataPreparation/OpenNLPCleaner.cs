using System;
using System.Windows.Input;

namespace NLPDataPreparation
{
    internal class OpenNLPCleaner 
    {

        public string Clean(string line)
        {
            string retval = line;
            retval = retval.Replace(" <END>", "");
            retval = retval.Replace("<START:company>", "");
            retval = retval.Replace("<START:country>", "");
            retval = retval.Replace("<START:person>", "");
            retval = retval.Replace("<START:region>", "");

            return retval;
        }
    }
}