using System;
using static System.Console;
using System.Globalization;
class GreenvilleRevenue
{
    static void Main()
    {
        //const int ENTRANCE_FEE = 25;
        //const int MIN_CONTESTANTS = 0;
        //const int MAX_CONTESTANTS = 30;
        //int numThisYear;
        //int numLastYear;
        //int revenue;
        //string[] names = new string[MAX_CONTESTANTS];
        //char[] talents = new char[MAX_CONTESTANTS];
        //char[] talentCodes = { 'S', 'D', 'M', 'O' };
        //string[] talentCodesStrings = { "Singing", "Dancing", "Musical instrument", "Other" };
        //int[] counts = { 0, 0, 0, 0 };
        //numLastYear = getContestantNumber("last", MIN_CONTESTANTS, MAX_CONTESTANTS);
        //numThisYear = getContestantNumber("this", MIN_CONTESTANTS, MAX_CONTESTANTS);
        //revenue = numThisYear * ENTRANCE_FEE;
        //WriteLine("Last year's competition had {0} contestants, and this year's has {1} contestants",
        //numLastYear, numThisYear);
        //WriteLine("Revenue expected this year is {0}", revenue.ToString("C"));
        //displayRelationship(numThisYear, numLastYear);
        //getContestantData(numThisYear, names, talents, talentCodes, talentCodesStrings, counts);
        //getLists(numThisYear, talentCodes, talentCodesStrings, names, talents, counts);
        const int ENTRANCE_FEE = 25;
        const int MIN_CONTESTANTS = 0;
        const int MAX_CONTESTANTS = 30;
        int contestantNumber = getContestantNumber(MIN_CONTESTANTS, MAX_CONTESTANTS);
        int revenue = contestantNumber * ENTRANCE_FEE;
        WriteLine("Revenue expected this year is {0}", revenue.ToString("C"));
        Contestant[] contestants = new Contestant[MAX_CONTESTANTS];
        getContestantData(contestantNumber, contestants);
        GetLists(contestantNumber, contestants);
    }
    public static int getContestantNumber(int min, int max)
    {
        string entryString;
        int number;
        min = 0;
        max = 30;
        WriteLine("Enter number of contestants >> ");
        entryString = ReadLine();
        number = Convert.ToInt32(entryString);
        while (number < min || number > max)
        {
            WriteLine("Please enter valid value!");
            entryString = ReadLine();
            number = Convert.ToInt32(entryString);
        }
        return number;
    }

    public static void getContestantData(int numThisYear, Contestant[] contestants)
    {
        int x = 0;
        bool isValid;
        char talent;
        string entryString;
        while (x < numThisYear)
        {
            Write("Enter contestant name >> ");
            entryString = ReadLine();
            Contestant aWorker = new Contestant { Name = entryString };
            WriteLine("Talent codes are:");
            for (int y = 0; y < aWorker.talentCodes.Length; ++y)
                WriteLine(" {0}  {1}", aWorker.talentCodes, aWorker.talentCodesStrings);
            Write("   Enter talent code >>");
            talent = Convert.ToChar(ReadLine());
            isValid = false;
            while(!isValid)
            {
                for(int z = 0; z < aWorker.talentCodes.Length; ++z)
                {
                    if(talent == aWorker.talentCodes[z])
                    {
                        isValid = true;
                        ++aWorker.counts[z];
                    }
                }
                if(!isValid)
                {
                    WriteLine("{0} is not a valid code", talent);
                    Write("  enter talent code >> ");
                    talent = Convert.ToChar(ReadLine());
                }
            }
            ++x;

        }
    }
        public static void GetLists(int numThisYear, Contestant[] contestants)
        {
            int x;
            char QUIT = 'Z';
            char option = 'A';
            Contestant aWorker = new Contestant { TalentCode = option };
            bool isValid;
            int pos = 0;
            bool found;
            WriteLine("\nThe types of talents are:");
        for (x = 0; x < aWorker.counts.Length; ++x)
            WriteLine("{0. -20}  {1, 5}", aWorker.talentCodesStrings[x], aWorker.counts[x]);
        Write("Enter a talent type or {0} to quit >> ", QUIT);
        option = Convert.ToChar(ReadLine());
        while(option != QUIT)
        {
            isValid = false;
            for (int z = 0; z < aWorker.talentCodes.Length; ++z) 
            {
                if (option == aWorker.talentCodes[z])
                {
                    isValid = true;
                    pos = z;
                }

            }
            if (!isValid)
                WriteLine("{0} is not a valid code", option);
            else
            {
                WriteLine("\nContestants with talent {0} are:", aWorker.talentCodesStrings[pos]);
                found = false;
                for(x = 0; x < numThisYear; ++x)
                {
                    if(aWorker.Talent[x] == option)
                    {
                        WriteLine(aWorker.Name);
                        found = true;
                    }
                }
                if (!found)
                    WriteLine("no contestants had talent {0}", aWorker.talentCodesStrings[pos]);
            }
            Write("\nEnter a talent type or {0} to quit >> ", QUIT);
            option = Convert.ToChar(ReadLine());
        }
    }
    }
class Contestant
    {
        public int[] counts = { 0, 0, 0, 0 };
        public char[] talentCodes { get; set; } = { 'S', 'D', 'M', 'O' };
        public string[] talentCodesStrings { get; set; } = { "Singing", "Dancing", "Musical instrument", "Other" };
        public string Name
        {
            get { return Name; }
            set { Name = value; }
        }
        private char talentCode;
        private string talent;
        public char TalentCode
        {
            get
            {
                return talentCode;
            }
            set
            {

            }
        }
        public string Talent
        {
            get
            {
                return talent;
            }
        }
    }



