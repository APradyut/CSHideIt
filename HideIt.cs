using System;
using System.Text.RegularExpressions;

namespace EncryptorTester
{
    class HideIt
    {
        public HideIt() { }
        public string hide(string raw)
        {
            try
            {
                Console.WriteLine("Raw : " + raw);
                string encrypted = "";
                DateTime time = DateTime.Now;
                int Key = time.DayOfYear % 30;
                string key = Key.ToString();
                int temp;
                encrypted += key[0];
                foreach (char c in raw)
                {
                    temp = Convert.ToInt32(c);
                    temp *= Key;
                    encrypted += Convert.ToChar(temp);
                }
                encrypted += key[1];
                return encrypted;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string show(string pass, string encrypted)
        {
            try
            {
                string decrypted = "";
                if (pass == "/*Enter your Password*/")
                {
                    string key = "";
                    int Key;
                    int startFlag = 0;
                    int length = encrypted.Length;
                    for (int i = 0; i < length; i++)
                    {
                        if (Regex.IsMatch(encrypted[i].ToString(), @"\d"))
                        {
                            key += encrypted[i];
                            startFlag = i;
                        }
                    }
                    try
                    {
                        Key = int.Parse(key);
                        Console.WriteLine("Key: " + Key);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(key + " Not parsable!!");
                        return "";
                    }
                    int temp;
                    for (int i = 1; i < length; i++)
                    {
                        temp = Convert.ToInt32(encrypted[i]);
                        temp /= Key;
                        decrypted += Convert.ToChar(temp).ToString();
                    }
                    return decrypted;
                }
                else
                {
                    return "Password Wrong!!";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
