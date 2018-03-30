using System;
using System.Linq;
using System.Data.SqlTypes;
using System.Collections;
using OpenNLP.Tools.Chunker;
using OpenNLP.Tools.Coreference.Similarity;
using OpenNLP.Tools.Lang.English;
using OpenNLP.Tools.NameFind;
using OpenNLP.Tools.Parser;
using OpenNLP.Tools.PosTagger;
using OpenNLP.Tools.SentenceDetect;
using OpenNLP.Tools.Tokenize;
using System.Collections.Generic;

namespace CLRFunctions
{


    public class SQLfunctions
    {
        private MaximumEntropySentenceDetector _sentenceDetector;
        private AbstractTokenizer _tokenizer;
        private EnglishMaximumEntropyPosTagger _posTagger;
        private EnglishTreebankChunker _chunker;
        private EnglishTreebankParser _parser;
        private EnglishNameFinder _nameFinder;
        private TreebankLinker _coreferenceFinder;
        Random r = new Random();
        public Char CharacterGenerator(Char c)
        {
           
            Char result = ' ';
            if (c == '*')
            {
                Char[] arr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '!', '?', '-', '_', '@', '$', '#', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'A')
            {
                Char[] arr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'c')
            {
                Char[] arr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'C')
            {
                Char[] arr = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'd')
            {
                Char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'D')
            {
                Char[] arr = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'X')
            {
                Char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'b')
            {
                Char[] arr = { '0', '1' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else
            {
                result = c;
            }
            return result;
        }
        public String PatternGenerator(String p)
        {
            Random r = new Random();
            String final = "";
            String temp = "";
            String result = " ";
            List<String> L = new List<String>();
            List<String> L2 = new List<String>();
            String temp3 = "";
            int temp2 = 0;
            int iterator = 0;
            while (iterator < p.Length)
            {
                if (p[iterator] == '[')
                {

                    iterator = iterator + 1;
                    //Console.WriteLine(p[iterator]);
                    while (p[iterator] != ']')
                    {
                        while (p[iterator] != '|')
                        {
                            if (p[iterator] == '|' || p[iterator] == ']')
                            {
                                break;
                            }
                            temp = temp + p[iterator];

                            iterator = iterator + 1;
                        }

                        temp3 = temp.ToString();
                        L.Add(temp3);
                        if (p[iterator] == ']')
                        {
                            iterator = iterator + 1;
                            temp = "";
                            temp3 = "";
                            break;
                        }
                        iterator = iterator + 1;
                        temp = "";
                        temp3 = "";

                    }

                    int randomvalue = r.Next(L.Count);
                    result = L[randomvalue];
                    final = final + result;
                    L2.Add(result);
                    L.Clear();
                }
                //'*', 'A', 'c', 'C', 'd', 'D', 'X', 'b'
                else if (p[iterator] == '*')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('*')).ToString();
                            L2.Add((CharacterGenerator('*')).ToString());
                            final = final + c;
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('*')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'A')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('A')).ToString();
                            final = final + c;
                            L2.Add((CharacterGenerator('A')).ToString());
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('A')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'c')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('c')).ToString();
                            L2.Add((CharacterGenerator('c')).ToString());
                            final = final + c;
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('c')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'C')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('C')).ToString();
                            final = final + c;
                            L2.Add((CharacterGenerator('C')).ToString());
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('C')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'd')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('d')).ToString();
                            L2.Add((CharacterGenerator('d')).ToString());
                            final = final + c;
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('d')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'D')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('D')).ToString();
                            L2.Add((CharacterGenerator('D')).ToString());
                            final = final + c;
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('D')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'X')
                {

                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('X')).ToString();
                            L2.Add((CharacterGenerator('X')).ToString());
                            final = final + c;
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('X')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'b')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('b')).ToString();
                            L2.Add((CharacterGenerator('b')).ToString());
                            final = final + c;
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('b')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }

                }
                else {
                    if (p[iterator] == '}')
                    {
                        final = final + "";
                        iterator = iterator + 1;



                    }
                    else if (p[iterator] == ')')
                    {
                        final = final + "";
                        iterator = iterator + 1;

                    }
                    else
                    {
                        final = final + p[iterator];
                        iterator = iterator + 1;
                    }
                }
            }


            return final;

        }
        [Microsoft.SqlServer.Server.SqlFunction()]

        public static String ActualScrambling(String Data)
        {
            String Scrambled = "";
            foreach (var data in Data)
            {
                String str = data.ToString(); ;
                String rand = str;
                while (str == rand)
                {


                    // The random number sequence
                    Random num = new Random();

                    // Create new string from the reordered char array
                    rand = new string(str.ToCharArray().
                                   OrderBy(s => (num.Next(2) % 2) == 0).ToArray());
                }
                Scrambled = rand;

            }

            return Scrambled;

        }

        [Microsoft.SqlServer.Server.SqlFunction()]

        public static String ParagraphMasking(String Data)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            String Scrambled = "";
            var modelPath = @"C:\Users\win 10\Documents\Visual Studio 2015\Projects\SynergyProjects\SynergyProjects\Internal Projects\Scrambler\CLRFunctions\namefind\";
            var nameFinder = new EnglishNameFinder(modelPath);
            var sentence = Data;
            // specify which types of entities you want to detect
            var models = new[] { "date", "location", "money", "organization", "percentage", "person", "time" };

            var ner = nameFinder.GetNames(models, sentence);

            // ner = Mr. & Mrs. <person>Smith</person> is a <date>2005</date> American romantic comedy action film.
            foreach (var token in ner)
            {
                Console.Write(token.ToString());
            }
            EnglishRuleBasedTokenizer _tokenizer = new EnglishRuleBasedTokenizer(false);

            var tokens = _tokenizer.Tokenize(ner);


            Random random = new Random();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\FemaleNames.txt");





            int i = 0;
            foreach (var token in tokens)
            {
                var store = random.Next(lines.Count());
                var store2 = lines[store];
                if (token.Contains("<person>"))
                {


                    tokens[i] = store2;

                    //    Console.WriteLine(token);
                }
                if (token.Contains("/"))
                {
                    // Console.WriteLine(token);
                    if (i < tokens.Count())
                    {
                        tokens = tokens.Where((source, index) => index != i).ToArray();
                        tokens = tokens.Where((source, index) => index != i).ToArray();
                        if (i < tokens.Count())
                        {
                            //  Console.WriteLine(tokens[i]);
                        }
                        i = i - 2;
                    }

                }
                else if (token.Contains("<location>"))
                {
                    random = new Random();
                    lines = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\Countries.txt");
                    //for (int j=0; j<lines.Length; j++)
                    //{
                    //   // Console.WriteLine(lines[j]);
                    //}





                    store = random.Next(lines.Count());
                    var country = lines[store];
                    //  i++;

                    tokens[i] = country;
                    if (token.Contains("/"))
                    {
                        // Console.WriteLine(token);
                        if (i < tokens.Count())
                        {
                            tokens = tokens.Where((source, index) => index != i).ToArray();
                            tokens = tokens.Where((source, index) => index != i).ToArray();
                            if (i < tokens.Count())
                            {
                                //  Console.WriteLine(tokens[i]);
                            }
                            i = i - 2;
                        }

                    }
                    //    Console.WriteLine(token);
                }
                else if (token.Contains("<money>"))
                {
                    Random rnd = new Random();
                    var money = token;
                    money = money.Replace("<money>", "");
                    money = money.Replace("<", "");
                    money = money.Replace("$", "");


                    // String cash = Convert.ToString(money);
                    store = 0;
                    char[] array = money.ToString().ToCharArray();
                    //int store3;
                    //int store4;

                    for (int j = 0; j < array.Length; j++)
                    {

                        if (array[j] != '0')
                        {
                            // Console.WriteLine(array[i]);
                            do
                            {
                                // Console.WriteLine(array[i]);
                                store = rnd.Next(1, 10);
                                // Console.WriteLine("random: "+ store);
                                //store3 = Convert.ToInt32(array[i]);
                                //store4 = Convert.ToInt32(store);
                            } while (store == Convert.ToInt32(array[j]));

                            if (array[j] != '.')
                            {
                                store = store + 48;
                                array[j] = Convert.ToChar(store);
                            }

                        }
                    }

                    Console.Write("here comes the money: ");
                    String replaced = "$";

                    for (int j = 0; j < array.Length; j++)
                    {
                        replaced = replaced + array[j];
                    }
                    tokens[i] = replaced;
                    if (token.Contains("/"))
                    {
                        // Console.WriteLine(token);
                        if (i < tokens.Count())
                        {
                            tokens = tokens.Where((source, index) => index != i).ToArray();
                            tokens = tokens.Where((source, index) => index != i).ToArray();
                            if (i < tokens.Count())
                            {
                                //  Console.WriteLine(tokens[i]);
                            }
                            i = i - 2;
                        }

                    }
                }
                else if (token.Contains("<date>"))
                {

                    if (token == "<date>Monday<" || token == "<date>Tuesday<" || token == "<date>Wednesday<" || token == "<date>Thursday<" || token == "<date>Friday<" || token == "<date>Saturday<" || token == "<date>Sunday<")
                    {
                        store = random.Next(days.Count());
                        store2 = days[store];
                        tokens[i] = store2;
                        if (token.Contains("/"))
                        {
                            // Console.WriteLine(token);
                            if (i < tokens.Count())
                            {
                                tokens = tokens.Where((source, index) => index != i).ToArray();
                                tokens = tokens.Where((source, index) => index != i).ToArray();
                                if (i < tokens.Count())
                                {
                                    //  Console.WriteLine(tokens[i]);
                                }
                                i = i - 2;
                            }

                        }

                    }
                    else
                    {



                        // Console.WriteLine(currentYear);

                        //System.Console.WriteLine("Contents of WriteLines2.txt = ");



                       var year = 0;
                        var month = 0;
                        var day = 0;


                        random = new Random();
                        lines = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\HireDates.txt");

                        // Console.WriteLine(currentYear);

                        //System.Console.WriteLine("Contents of WriteLines2.txt = ");

                        store = random.Next(lines.Count());
                        store2 = lines[store];

                        var listSplit = store2.Split(',');
                        month = int.Parse(listSplit[0]);
                        day = int.Parse(listSplit[1]);
                        year = int.Parse(listSplit[2]);


                       var current = new DateTime(year, month, day);
                        Console.WriteLine("Scrambled date is: " + current.ToString("yyyy- mm- dd"));




                        tokens[i] = current.ToString("MMMM dd, yyyy") + ".";
                        if (token.Contains("/"))
                        {
                            // Console.WriteLine(token);
                            if (i < tokens.Count())
                            {
                                tokens = tokens.Where((source, index) => index != i).ToArray();
                                tokens = tokens.Where((source, index) => index != i).ToArray();
                                if (i < tokens.Count())
                                {
                                    //  Console.WriteLine(tokens[i]);
                                }
                                i = i - 2;
                            }

                        }




                        Console.WriteLine("Scrambled date is: " + current.ToString("MMMM dd, yyyy") + ".");


                    }
                   var date = tokens[i].ToString();
                }
                i++;
            }
            String Replaced = "";
            foreach (var token in tokens)
            {
                Replaced = Replaced + token + " ";
            }
            System.Console.WriteLine("Masked paragraph is ");

            Console.WriteLine(Replaced);


            foreach (var token in tokens)
            {
               var store = random.Next(lines.Count());
                var store2 = lines[store];
                if (token.Contains("<person>"))
                {


                    tokens[i] = store2;

                    //    Console.WriteLine(token);
                }
                if (token.Contains("/"))
                {
                    // Console.WriteLine(token);
                    if (i < tokens.Count())
                    {
                        tokens = tokens.Where((source, index) => index != i).ToArray();
                        tokens = tokens.Where((source, index) => index != i).ToArray();
                        if (i < tokens.Count())
                        {
                            //  Console.WriteLine(tokens[i]);
                        }
                        i = i - 2;
                    }

                }
                else if (token.Contains("<location>"))
                {
                    random = new Random();
                    lines = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\Countries.txt");
                    //for (int j=0; j<lines.Length; j++)
                    //{
                    //   // Console.WriteLine(lines[j]);
                    //}





                    store = random.Next(lines.Count());
                    var country = lines[store];
                    //  i++;

                    tokens[i] = store2;
                    if (token.Contains("/"))
                    {
                        // Console.WriteLine(token);
                        if (i < tokens.Count())
                        {
                            tokens = tokens.Where((source, index) => index != i).ToArray();
                            tokens = tokens.Where((source, index) => index != i).ToArray();
                            if (i < tokens.Count())
                            {
                                //  Console.WriteLine(tokens[i]);
                            }
                            i = i - 2;
                        }

                    }
                    //    Console.WriteLine(token);
                }
                else if (token.Contains("<money>"))
                {
                    Random rnd = new Random();
                    var money = token;
                    money = money.Replace("<money>", "");
                    money = money.Replace("<", "");
                    money = money.Replace("$", "");


                    // String cash = Convert.ToString(money);
                    store = 0;
                    char[] array = money.ToString().ToCharArray();
                    //int store3;
                    //int store4;

                    for (int j = 0; j < array.Length; j++)
                    {

                        if (array[j] != '0')
                        {
                            // Console.WriteLine(array[i]);
                            do
                            {
                                // Console.WriteLine(array[i]);
                                store = rnd.Next(1, 10);
                                // Console.WriteLine("random: "+ store);
                                //store3 = Convert.ToInt32(array[i]);
                                //store4 = Convert.ToInt32(store);
                            } while (store == Convert.ToInt32(array[j]));

                            if (array[j] != '.')
                            {
                                store = store + 48;
                                array[j] = Convert.ToChar(store);
                            }

                        }
                    }

                    Console.Write("here comes the money: ");
                    String replaced = "$";

                    for (int j = 0; j < array.Length; j++)
                    {
                        replaced = replaced + array[j];
                    }
                    tokens[i] = replaced;
                    if (token.Contains("/"))
                    {
                        // Console.WriteLine(token);
                        if (i < tokens.Count())
                        {
                            tokens = tokens.Where((source, index) => index != i).ToArray();
                            tokens = tokens.Where((source, index) => index != i).ToArray();
                            if (i < tokens.Count())
                            {
                                //  Console.WriteLine(tokens[i]);
                            }
                            i = i - 2;
                        }

                    }
                }
                else if (token.Contains("<date>"))
                {

                    if (token == "<date>Monday<" || token == "<date>Tuesday<" || token == "<date>Wednesday<" || token == "<date>Thursday<" || token == "<date>Friday<" || token == "<date>Saturday<" || token == "<date>Sunday<")
                    {
                        store = random.Next(days.Count());
                        store2 = days[store];
                        tokens[i] = store2;
                        if (token.Contains("/"))
                        {
                            // Console.WriteLine(token);
                            if (i < tokens.Count())
                            {
                                tokens = tokens.Where((source, index) => index != i).ToArray();
                                tokens = tokens.Where((source, index) => index != i).ToArray();
                                if (i < tokens.Count())
                                {
                                    //  Console.WriteLine(tokens[i]);
                                }
                                i = i - 2;
                            }

                        }

                    }
                    else
                    {



                        // Console.WriteLine(currentYear);

                        //System.Console.WriteLine("Contents of WriteLines2.txt = ");



                       var year = 0;
                        var month = 0;
                        var day = 0;


                        random = new Random();
                        lines = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\HireDates.txt");

                        // Console.WriteLine(currentYear);

                        //System.Console.WriteLine("Contents of WriteLines2.txt = ");

                        store = random.Next(lines.Count());
                        store2 = lines[store];

                        var listSplit = store2.Split(',');
                        month = int.Parse(listSplit[0]);
                        day = int.Parse(listSplit[1]);
                        year = int.Parse(listSplit[2]);


                      var  current = new DateTime(year, month, day);
                        Console.WriteLine("Scrambled date is: " + current.ToString("yyyy- mm- dd"));




                        tokens[i] = current.ToString("MMMM dd, yyyy") + ".";
                        if (token.Contains("/"))
                        {
                            // Console.WriteLine(token);
                            if (i < tokens.Count())
                            {
                                tokens = tokens.Where((source, index) => index != i).ToArray();
                                tokens = tokens.Where((source, index) => index != i).ToArray();
                                if (i < tokens.Count())
                                {
                                    //  Console.WriteLine(tokens[i]);
                                }
                                i = i - 2;
                            }

                        }




                        Console.WriteLine("Scrambled date is: " + current.ToString("MMMM dd, yyyy") + ".");


                    }
                  var  date = tokens[i].ToString();
                }
                i++;
            }
             Replaced = "";
            foreach (var token in tokens)
            {
                Replaced = Replaced + token + " ";
            }
            System.Console.WriteLine("Masked paragraph is ");

            Console.WriteLine(Replaced);
            return Replaced;
        }
        [Microsoft.SqlServer.Server.SqlFunction()]
        public static String GenderFemale(String Data)
        {
            SQLfunctions sf = new SQLfunctions();
            String Replaced = "";
            
                Random random = new Random();
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\FemaleNames.txt");
                var store = random.Next(lines.Count());
                var store2 = lines[store];
                Replaced = store2;


            
            return Replaced;
        }

        public static String GenderMale(String Data)
        {
            SQLfunctions sf = new SQLfunctions();
            String Replaced = "";

            Random random = new Random();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\MaleNames.txt");
            var store = random.Next(lines.Count());
            var store2 = lines[store];
            Replaced = store2;



            return Replaced;
        }

        public static String CountryCode(String Data)
        {
            SQLfunctions sf = new SQLfunctions();
            String Replaced = "";

            Random random = new Random();
            string[] Code = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\Codes.txt");
            string[] Country = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\Countries.txt");

            for (int i=0; i<Country.Count(); i++)
            {
                if (Country[i]==Data)
                {
                    Replaced = Code[i];
                    break;
                }
            }
            



            return Replaced;
        }

        public static String HireDate(String Data)
        {

            Random random = new Random();
            SQLfunctions sf = new SQLfunctions();
            String Replaced = "";
            string[] HDate = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\HireDates.txt");
            string[] BDate = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\BirthDates.txt");

            for (int i = 0; i < BDate.Count(); i++)
            {
                if (BDate[i] == Data)
                {
                    Replaced = HDate[i];
                    break;
                }
            }




            return Replaced;
        }
        public static String ReplaceDS(String Data,String Type)
        {
            SQLfunctions sf = new SQLfunctions();
            String Replaced = "";
            if (Type == "Name")
            {
                Random random = new Random();
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\FirstNames.txt");
                var store = random.Next(lines.Count());
                var store2 = lines[store];
                Replaced = store2;


            }
            else if (Type == "countries")
            {
                String currentCountry = Data;
                Random random = new Random();
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\Countries.txt");
                //for (int j=0; j<lines.Length; j++)
                //{
                //   // Console.WriteLine(lines[j]);
                //}

                Console.WriteLine("Current Country is: " + currentCountry);
                var country = "Pakistan";
                var i = 0;

                do
                {
                    var store = random.Next(lines.Count());
                    country = lines[store];
                    Replaced = country;
                    //  i++;
                } while (currentCountry == country);

            }
            else if (Type == "money")
            {
                Random rnd = new Random();
                var money = Data;

                // String cash = Convert.ToString(money);
                var store = 0;
                char[] array = money.ToString().ToCharArray();
                //int store3;
                //int store4;

                for (int i = 0; i < array.Length; i++)
                {

                    if (array[i] != '0')
                    {
                        // Console.WriteLine(array[i]);
                        do
                        {
                            // Console.WriteLine(array[i]);
                            store = rnd.Next(1, 10);
                            // Console.WriteLine("random: "+ store);
                            //store3 = Convert.ToInt32(array[i]);
                            //store4 = Convert.ToInt32(store);
                        } while (store == Convert.ToInt32(array[i]));

                        if (array[i] != '.')
                        {
                            store = store + 48;
                            array[i] = Convert.ToChar(store);
                        }

                    }
                }
               


                String replaced = "";

                for (int i = 0; i < array.Length; i++)
                {
                    replaced = replaced + array[i];
                }
                Replaced = replaced;
            }
            else if (Type == "date")
            {
                Random random = new Random();
                SQLfunctions sf2 = new SQLfunctions();
                String ReplacedDate = "";
                //string[] HDate = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\HireDates.txt");
                string[] BDate = System.IO.File.ReadAllLines(@"C:\Users\win 10\Desktop\BirthDates.txt");
                
                 var num =  random.Next(BDate.Count());
                ReplacedDate = BDate[num];
                Replaced = ReplacedDate;
                        
                





                Replaced = ReplacedDate;

            }
            else if (Type == "email")
            {

           
                String str2 = "c(9)A{5}[.|_]c(7)d{3}@[google|yahoo|live|mail].[com|org|pk]";
                String r =  sf.PatternGenerator(str2);
                Replaced = r;

            }

            return Replaced ;
        }
        [Microsoft.SqlServer.Server.SqlFunction()]

        public static int ReplacedInt(int Data,String Type)
        {
            String Replaced = "";
            if(Type == "phone")
            {
                
                    SQLfunctions sf = new SQLfunctions();
                    String str5 = "+1d{3}d{3}d{4}";
                    String r =  sf.PatternGenerator(str5);
                    Replaced = r;
                
            }
            var re= Convert.ToInt32(Replaced);
            return re;
        }

        [Microsoft.SqlServer.Server.SqlFunction()]

        public static SqlString Scrambling(String Data)
        {
            String Scrambled = "";

            String str = Data.ToString(); ;
            String rand = str;
            while (str == rand)
            {


                // The random number sequence
                Random num = new Random();

                // Create new string from the reordered char array
                rand = new string(str.ToCharArray().
                               OrderBy(s => (num.Next(2) % 2) == 0).ToArray());
            }
            Scrambled = rand;



            return Scrambled;

        }
        [Microsoft.SqlServer.Server.SqlFunction()]


        public static String Masking(String Actual, int length)
        {
            String Masked = "";

            String input = Actual;

            if (input.Length > length)
            {
                string FirstPart = input.Substring(0, length);


                //take last 4 characters
                int len = input.Length;
                int len1 = FirstPart.Length;
                int len2 = len - len1;
                string lastPart = input.Substring(len1, len2);

                //take the middle part (XXXXXXXXX)

                string middlePart = new String('X', length);

                String returnVal = middlePart + lastPart;
                return returnVal;

            }
            else
            {
                string middlePart = new String('X', input.Length);

                return middlePart;

            }



        }
               [Microsoft.SqlServer.Server.SqlFunction()]


        public static String Masking1(String Actual, int length, String  character)
        {
            String Masked = "";
            char c = character[0];
            String input = Actual;

            if (input.Length > length)
            {
                string FirstPart = input.Substring(0, length);


                //take last 4 characters
                int len = input.Length;
                int len1 = FirstPart.Length;
                int len2 = len - len1;
                string lastPart = input.Substring(len1, len2);

                //take the middle part (XXXXXXXXX)

                string middlePart = new String(c, length);

                String returnVal = middlePart + lastPart;
                return returnVal;

            }
            else
            {
                string middlePart = new String(c, input.Length);

                return middlePart;

            }


        }
    }
}
