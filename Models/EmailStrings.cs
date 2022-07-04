using System.IO;
using System.Text;

namespace Order66exe.Models
{
    public static class EmailStrings
    {
        public static string GetConfirm(string callback)
        {
            using (StreamReader reader = File.OpenText("../Views/Email/Confirm.cshtml"))
            {
                var text = new StringBuilder();


                string s = reader.ReadToEnd();
                string newString = s.Replace("PUT-CALLBACK-HERE", callback);

                return newString;
            }
        }
    }
}
