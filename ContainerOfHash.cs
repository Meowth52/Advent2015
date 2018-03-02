using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015
{
    class ContainerOfHash
    {
        public ContainerOfHash()
        {

        }
        //Lets get this hash bulshit out of the way
        public string GetHash(string s)
        {
            MD5 hashis = MD5.Create();
            StringBuilder sBuilder = new StringBuilder();
            byte[] byteData = hashis.ComputeHash(Encoding.UTF8.GetBytes(s));
            for (int i = 0; i < byteData.Length; i++)
            {
                sBuilder.Append(byteData[i].ToString("x2"));
            }
            string ReturnString = sBuilder.ToString();
            sBuilder.Clear();
            hashis.Clear();
            return ReturnString;
        }
    }
}
