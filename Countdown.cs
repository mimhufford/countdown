using System;
using System.Diagnostics;
using System.Collections.Generic;

var digits = new List<List<string>>
{
    new List<string> { " .d8888b.  ","   d888    "," .d8888b.  "," .d8888b.  ","    d8888  ","888888888  "," .d8888b.  ","8888888888 "," .d8888b.  "," .d8888b.  ","      " },
    new List<string> { "d88P  Y88b ","  d8888    ","d88P  Y88b ","d88P  Y88b ","   d8P888  ","888        ","d88P  Y88b ","      d88P ","d88P  Y88b ","d88P  Y88b ","      " },
    new List<string> { "888    888 ","    888    ","       888 ","     .d88P ","  d8P 888  ","888        ","888        ","     d88P  ","Y88b. d88P ","888    888 "," .=.  " },
    new List<string> { "888    888 ","    888    ","     .d88P ","    8888'  "," d8P  888  ","8888888b.  ","888d888b.  ","    d88P   "," 'Y88888'  ","Y88b. d888 "," '='  " },
    new List<string> { "888    888 ","    888    "," .od888P'  ","     'Y8b. ","d88   888  ","     'Y88b ","888P 'Y88b "," 88888888  ",".d8P''Y8b. "," 'Y888P888 ","      " },
    new List<string> { "888    888 ","    888    ","d88P'      ","888    888 ","8888888888 ","       888 ","888    888 ","  d88P     ","888    888 ","       888 "," .=.  " },
    new List<string> { "Y88b  d88P ","    888    ","888'       ","Y88b  d88P ","      888  ","Y88b  d88P ","Y88b  d88P "," d88P      ","Y88b  d88P ","Y88b  d88P "," '='  " },
    new List<string> { " 'Y8888P'  ","  8888888  ","888888888  "," 'Y8888P'  ","      888  "," 'Y8888P'  "," 'Y8888P'  ","d88P       "," 'Y8888P'  "," 'Y8888P'  ","      " },
};

var timer = Stopwatch.StartNew();
int minutes = 3;
//ConsoleColor enum reference: https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor
ConsoleColor bgColor = ConsoleColor.Red;
ConsoleColor fgColor = ConsoleColor.DarkRed;
try { minutes = int.Parse(args[0]); }
catch (Exception) { }
try { bgColor = (ConsoleColor)int.Parse(args[1]); }
catch (Exception) { }
try { fgColor = (ConsoleColor)int.Parse(args[2]); }
catch (Exception) { }
TimeSpan total = new TimeSpan(0, minutes, 1);

Console.SetWindowSize(53, 10);
Console.SetBufferSize(53, 10);
Console.Title = "Starting Soon!";
Console.Clear();

while (true)
{
    while (!Console.KeyAvailable)
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 1);

        var remaining = total > timer.Elapsed ? total - timer.Elapsed : new TimeSpan();

        int m0 = remaining.Minutes / 10;
        int m1 = remaining.Minutes % 10;
        int s0 = remaining.Seconds / 10;
        int s1 = remaining.Seconds % 10;

        if(remaining.Minutes == 0 && remaining.Seconds <= 10){
            Console.BackgroundColor = (ConsoleColor)bgColor;
            Console.ForegroundColor = (ConsoleColor)fgColor;
        }else{
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        foreach (var digit in digits)
        {
            Console.Write("  ");
            Console.Write(digit[m0]);
            Console.Write(digit[m1]);
            Console.Write(digit[10]);
            Console.Write(digit[s0]);
            Console.Write(digit[s1]);
            Console.WriteLine();
        }

        System.Threading.Thread.Sleep(50);
    }

    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.Escape: Environment.Exit(0); break;
        case ConsoleKey.RightArrow: total += new TimeSpan(0, 0, 10); break;
        case ConsoleKey.LeftArrow: total -= new TimeSpan(0, 0, 10); break;
        case ConsoleKey.UpArrow: total += new TimeSpan(0, 1, 0); break;
        case ConsoleKey.DownArrow: total -= new TimeSpan(0, 1, 0); break;
        case ConsoleKey.Backspace: total=new TimeSpan(0, minutes, 1);timer.Reset();timer.Start();break;
        default: Console.Clear(); break;
    }
}