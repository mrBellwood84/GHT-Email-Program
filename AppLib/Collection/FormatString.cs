using System;
using System.Collections.Generic;
using System.Text;

namespace AppLib.Collection
{
    public class FormatString
    {
        /** Methods for formatting strings.
         * 'Text' method capitalize first char in a sentence.
         *  Also sent punctuation at end of string if not present.
         *  'Name' method capitalize each word/Name in string       */


        public static string Text(string input)
        {
            /** Simple formatting of text string. 
             *  Capitalize first character in sentences, defined by punctums.
             *  Also add puntum at end of string if not present.    */


            string result = "";     // create result string


            if ((input == "") || (input == null))   // if input is an empty string or have value null
            {
                return result;                      // return empty string
            }

            string[] arr = splitString(input);      // split string to arrat
            int arrLen = arr.Length;                // get array length

            if (arrLen > 0)                         // if array contain least one item
            {
                result += caplitalize(arr[0]);      // capitalize first item
            }
            
            if (arrLen > 1)                         // if array contain several items
            {
                for (int i = 1; i < arrLen; i++)    // itterate each item from index 1
                {
                    string item = arr[i];                       // get current item from array 
                    string previousItem = arr[i - 1];           // get previous item
                    int previousLen = previousItem.Length;      // get previous item length

                    if (previousItem[previousLen - 1] == '.')   // if last char in item is punctum
                    {
                        result += $" {caplitalize(item)}";      // caplitalize string, add prefixed space and apppend to result
                    }
                    else
                    {
                        if ((item == ".") || (item == ","))     // it item is punctuation mark
                        {   
                            result += item;                     // add to string with no prefix spacing
                        }
                        else
                        {
                            result += $" {item.ToLower()}";     // else, append item lowercase to result with prefixed spacing.
                        }
                    }

                }
            }

            int lastCharIndex = result.Length - 1;  // get index of last char in result string

            if (result[lastCharIndex] != '.')       // if last char in result not punctum
            {
                result += ".";                      // append punctum as last char
            }

            return result;          // return result

        }

        public static string Name(string input)
        {
            /** Capitalize name strings */

            string result = "";         // set result string

            if ((input == "") || (input == null))   // if input string is empty or have value null
            {
                return result;                      // return empty string
            }

            string[] arr = splitString(input);      // split string
            int len = arr.Length;

            result += caplitalize(arr[0]);          // append first name to result

            if(len > 1)                             // if array length larger than 1
            {
                for (int i = 1; i < len; i++)       // itterate array from index 1
                {
                    result += $" {caplitalize(arr[i])}";    // append name with a prefixed space
                }
            }

            return result;      // return result
        }

        private static string[] splitString(string input)
        {
            /** Split string in seperated words and return as array of strings
             *  Method also removes any empty spaces from string    */


            char[] splitChar = { ' ' };                 // set char to split string
            string[] arr = input.Split(splitChar);      // split string and set array

            List<string> list = new List<string>();     // list for strings to keep

            foreach(string item in arr)     // foreach string in array
            {
                if (item != "")             // if string not empty
                {
                    list.Add(item);         // append to list
                }
            }

            return list.ToArray();          // return list as array;
            
        }

        private static string caplitalize(string input)
        {
            /** caplitalize first character in string
             *  set remaining characters to lower   */

            int len             = input.Length;                             // get string length
            string firstChar    = input[0].ToString().ToUpper();            // get first char, set to string at format to upper
            string remains      = input.Substring(1, (len - 1)).ToLower();  // get remaining string at set to lower
                
            return (firstChar + remains);       // concat and return string
        }
    }
}
