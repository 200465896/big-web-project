using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;


namespace website
{
    internal class GlobalFunctions
    {
        // Returns true if file is valid, flase otherwise
        public static bool readSetFile(string filePath, out int sizeOfWord, out int matchNumber, out float speedPerformance, out int memoryPerformance, out float percentageOfCovered)
        {
            //Initialize output parameters as Errors (-1)
            speedPerformance = -1;
            memoryPerformance = -1;
            percentageOfCovered = -1;
            sizeOfWord = -1;
            matchNumber = -1;

            // Read all lines from file into array of strings
            string[] lines = File.ReadAllLines(filePath);
            string[] firstLine = lines[0].Split(' ', '\t');

            int numberOfFilters, wordSize, MCS, amountOfMatch;

            if (firstLine.Length != 12) return false;

            // Check if the first tree parameters are as Requiered
            if (!firstLine[0].Equals("Nform1")) return false;
            if (!firstLine[1].Equals("=")) return false;
            // Check if the first tree values are numbers, and parse them
            if (!int.TryParse(firstLine[2].ToString(), out numberOfFilters)) return false;
            if (!firstLine[3].Equals("form1Size")) return false;
            if (!firstLine[4].Equals("=")) return false;
            // Check if the first tree values are numbers, and parse them
            if (!int.TryParse(firstLine[5].ToString(), out wordSize)) return false;
            if (!firstLine[6].Equals("Nsovp1")) return false;
            if (!firstLine[7].Equals("=")) return false;
            if (!int.TryParse(firstLine[8].ToString(), out MCS)) return false;
            if (!firstLine[9].Equals("N_2")) return false;
            if (!firstLine[10].Equals("=")) return false;
            // Check if the first tree values are numbers, and parse them
            if (!int.TryParse(firstLine[11].ToString(), out amountOfMatch)) return false;

            wordSize--;

            sizeOfWord = wordSize;
            matchNumber = amountOfMatch;

            //Other basic validations
            if (matchNumber / (double)wordSize < 0.6) return false;
            if (matchNumber > GlobalConsts.maxSizeOfMatch) return false;
            if (wordSize > GlobalConsts.maxSizeOfWord) return false;
            //check if the number of filters equals to the number of filters declarated above
            if (numberOfFilters != lines.Length - 1) return false;

            int countDistance = 0;
            // long coverageSum = 0;


            // Percentage Cover
            List<ArrayOfBits> allCombinations = new List<ArrayOfBits>();
            List<ArrayOfBits> onesList = new List<ArrayOfBits>();
            List<ArrayOfBits> allFilters = new List<ArrayOfBits>();

            for (int i = 0; i < sizeOfWord; i++)
            {
                ArrayOfBits ba = new ArrayOfBits((int)(Math.Pow(2, i)), sizeOfWord);
                onesList.Add(ba);
            }

            for (int i = 0; i < (int)(Math.Pow(2, sizeOfWord)); i++)
            {
                ArrayOfBits ba = new ArrayOfBits(i, sizeOfWord);
                int count = 0;

                foreach (ArrayOfBits b in onesList)
                {
                    if (!b.And(ba).Equals((new ArrayOfBits(0, sizeOfWord))))
                        count++;
                }

                if (count == matchNumber)
                    allCombinations.Add(ba);
            }



            for (int i = 1; i <= numberOfFilters; i++)
            {
                int requieredDistance;
                // split each line into array of strings
                string[] splittedLine = lines[i].Split(' ', '\t');

                // size of filter should be equal to the size of filter declarated above
                if (splittedLine.Length - 3 != wordSize) return false;

                // extract the last number in the line (try to parse it to check if its a number) and set it
                // as a required distance
                if (!int.TryParse(splittedLine[wordSize + 1], out requieredDistance)) return false;
                // check if each number in the line is either 1 or 0
                for (int j = 1; j < splittedLine.Length - 2; j++)
                {
                    if (!splittedLine[j].Equals("1") && !splittedLine[j].Equals("0")) return false;
                }


                // Initilize search
                int startIndex = -1;
                int endIndex = -1;
                int foundDistance = -1;

                // search for the first "1"
                for (int j = 1; j < splittedLine.Length - 2; j++)
                {
                    if (splittedLine[j].Equals("1"))
                    {
                        startIndex = j;
                        break;
                    }
                }
                // search for the last "1"
                for (int j = splittedLine.Length - 3; j >= 1; j--)
                {
                    if (splittedLine[j].Equals("1"))
                    {
                        endIndex = j;
                        break;
                    }
                }
                // If there are no "1"s - distance equals 0, otherwise calculate distance
                if (startIndex == -1 || endIndex == -1) foundDistance = 0;
                else foundDistance = endIndex - startIndex + 1;


                // check if the distance is as requiered
                if (foundDistance != requieredDistance) return false;

                countDistance += (wordSize + 1 - foundDistance);



                int rowValue = 0;
                for (int j = 1; j < splittedLine.Length - 2; j++)
                {
                    rowValue += int.Parse(splittedLine[j]) * ((int)(Math.Pow(2, (wordSize - j))));
                }
                allFilters.Add(new ArrayOfBits(rowValue, sizeOfWord));

                for (int j = 1; j < (wordSize + 1 - foundDistance); j++)
                {
                    rowValue /= 2;
                    allFilters.Add(new ArrayOfBits(rowValue, sizeOfWord));
                }
            }
            int howManyCovered = 0;
            // Compute percetage of covered
            foreach (ArrayOfBits a in allCombinations)
            {
                bool covered = false;
                foreach (ArrayOfBits b in allFilters)
                {
                    if (a.Match(b, MCS))
                        covered = true;
                }
                if (covered)
                    howManyCovered++;
            }


            // Compute result for output
            speedPerformance = 1 / (countDistance / (float)(Math.Pow(26, (float)MCS)));
            memoryPerformance = countDistance;
            percentageOfCovered = ((float)(howManyCovered) / allCombinations.Count) * 100;

            return true;


        }


        public static long combination(long n, long k)
        {
            double sum = 0;
            for (long i = 0; i < k; i++)
            {
                sum += Math.Log10(n - i);
                sum -= Math.Log10(i + 1);
            }
            return (long)Math.Pow(10, sum);
        }



        public static string createSpecialFileFormatForProcess(string path)
        {

            //bool res=true;
            string fullPath = path;
            if (!File.Exists(fullPath))
            {
                fullPath = HttpContext.Current.Server.MapPath(@"~" + fullPath);
                if (!File.Exists(fullPath))
                    return "";
            }
            //file exist
            string line_src;
            System.IO.StreamReader reader = new System.IO.StreamReader(@fullPath);
            string[] seperators = new string[] { " ", "\t" };
            //StringBuilder sb_results = new StringBuilder();
            string resultSTR = "";
            try
            {
                //Read and Convert source text file
                int rowIndex = 0;
                while ((line_src = reader.ReadLine()) != null)
                {
                    if (rowIndex > 0)
                    {
                        string lineFormated = "";
                        string[] resultArr = line_src.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                        if (resultArr != null && resultArr.Length > 0)
                        {
                            for (int i = 0; i < resultArr.Length; i++)
                            {
                                if (i > 0 && i < resultArr.Length - 1)
                                    lineFormated += resultArr[i];
                            }
                        }
                        int lastGoodPosition = lineFormated.LastIndexOf("1");
                        lineFormated = lineFormated.Substring(0, lastGoodPosition + 1);
                        resultSTR += lineFormated + "\n";
                    }
                    rowIndex++;
                }
                //Save the formated text into a seperate text file
                string destFileName;
                string timePart = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                string destPath = HttpContext.Current.Server.MapPath(@"/formattedFiles");
                int srcFileNameStartPos = fullPath.LastIndexOf("\\");
                if (srcFileNameStartPos > 0)
                    destFileName = fullPath.Substring(srcFileNameStartPos + 1, fullPath.Length - srcFileNameStartPos - 1) + "_";
                else
                    destFileName = "formattedFile_";    
                destFileName += timePart;
              destFileName = destFileName.ToLower().Replace(".txt", "");
                destFileName = "mcs4.txt";
                if (!Directory.Exists(destPath))
                    Directory.CreateDirectory(destPath);

                string[] allLinesRes = resultSTR.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                System.IO.File.WriteAllLines(destPath + "\\" + destFileName, allLinesRes);
                return destPath + "\\" + destFileName;
            }
            catch
            {
                return "";
            }
            finally
            {
                reader.Close();
            }
        }



    }




}



