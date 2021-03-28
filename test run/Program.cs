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
        getLists(contestantNumber, contestants);
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
            //ProfM2 - You are getting a null reference error here as the Contestant object is not instantiated (in memory)
            //Contestant.Names[x] = ReadLine();
            entryString = ReadLine();
            WriteLine("Talent codes are:");
            //ProfM2 - use the Contestant class static array
            for (int y = 0; y < Contestant.TalentCodesStrings.Length; ++y)
                WriteLine("  {0}   {1}", Contestant.TalentCodes[y], Contestant.TalentCodesStrings[y]);
            Write("   Enter talent code >>");
            //ProfM2 - you do not need this as you are getting the input in line 88 AND checking that it is a char datatype.
            //talent = Convert.ToChar(ReadLine());
            isValid = false;
            while (!isValid)
            {
                //ProfM2 - commented your code 79 thru 86
                //for (int z = 0; z < aWorker.talentCodes.Length; ++z)
                //{
                //    if(talent == aWorker.talentCodes[z])
                //    {
                //        isValid = true;
                //        ++aWorker.counts[z];
                //    }
                //}
                //ProfM2 - use a conditional to check the input and then instantiate a Contestant in the current array index [x]
                if (!char.TryParse(ReadLine(), out talent))
                {
                    WriteLine("Invalid format - entry must be a single character");
                }
                else
                {
                    contestants[x] = new Contestant();
                    for (int z = 0; z < Contestant.TalentCodes.Length; ++z)
                    {
                        if (talent == Contestant.TalentCodes[z])
                        {
                            isValid = true;
                            contestants[x].TalentCode = talent;
                            //ProfM2 - you set the contestant name on the next line

                        }
                    }
                }
                //ProfM2 - this if condition is good but not necessary for the assignment so I would remove the entire if
                //{
                //    WriteLine("{0} is not a valid code", talent);
                //    Write("  enter talent code >> ");
                //    talent = Convert.ToChar(ReadLine());
                //}
            }
            ++x;

        }
    }
    //ProfM2 - you need to match the method names that MindTap expects    
    public static void getLists(int numThisYear, Contestant[] contestants)
    {
        int x = 0;
        char QUIT = 'Z';
        char option = 'A';
        //ProfM2 - use the static talentCodesStrings and talentCodesStrings arrays below to remove the errors below in this method
        //contestants[x] = new Contestant();
        bool isValid;
        int pos = 0;
        bool found;
        WriteLine("\nThe types of talents are:");
        for (x = 0; x < Contestant.counts.Length; ++x)
            //ProfM2 - use the static talentCodesStrings
            WriteLine("{0, -20}  {1, 5}", Contestant.TalentCodes[x], Contestant.TalentCodesStrings[x]);
        Write("Enter a talent type or {0} to quit >> ", QUIT);
        isValid = false;
        //ProfM2 - I corrected this section with a while loop
        while (!isValid)
        {
            if (!char.TryParse(ReadLine(), out option))
            {
                isValid = false;
                //10 Appropriate messages are displayed if the entered code is not a character or a valid code.
                WriteLine("Invalid format - entry must be a single character");
                Write("\nEnter a talent type or {0} to quit >> ", QUIT);
            }
            else
            {
                if (option == QUIT)
                    isValid = true;
                else
                {
                    for (int z = 0; z < Contestant.TalentCodes.Length; ++z)
                    {
                        if (option == Contestant.TalentCodes[z])
                        {
                            isValid = true;
                            pos = z;
                        }
                    }
                    if (!isValid)
                    {
                        //10
                        WriteLine("{0} is not a valid code", option);
                        Write("\nEnter a talent type or {0} to quit >> ", QUIT);
                    }
                    else
                    {
                        WriteLine("\nContestants with talent {0} are:", Contestant.TalentCodesStrings[pos]);
                        found = false;
                        for (x = 0; x < numThisYear; ++x)
                        {
                            if (contestants[x].TalentCode == option)
                            {
                                WriteLine(contestants[x].Name);
                                found = true;
                            }
                        }
                        if (!found)
                            //10
                            WriteLine("\nContestants with talent {0} are:", Contestant.TalentCodesStrings[pos]);

                        Write("\nEnter a talent type or {0} to quit >> ", QUIT);
                    }
                }
            }
        }
    }
}
class Contestant
{
    public static int[] counts = { 0, 0, 0, 0 };
    //ProfM2 - this field needs to be static as per the start code
    public static char[] TalentCodes { get; set; } = { 'S', 'D', 'M', 'O' };
    //ProfM2 - this field needs to be static as per the start code
    public static string[] TalentCodesStrings { get; set; } = { "Singing", "Dancing", "Musical instrument", "Other" };

    //ProfM2 - Do not need this 
    //public static string[] Names;
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
            //ProfM2 - you will need to complete this set accessor so the code assigns a code only if it is valid
            //I have completed most of this for you
            bool isValidTalentCode = false;
            for (int x = 0; x < TalentCodes.Length; ++x)
            {
                if (TalentCodes[x] == value)
                {
                    talentCode = value;
                    isValidTalentCode = true;
                    //You set the talent here as per instruction #4
                }
            }

            if (!isValidTalentCode)
            {
                talentCode = 'I';
                talent = "Invalid";
            }
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
