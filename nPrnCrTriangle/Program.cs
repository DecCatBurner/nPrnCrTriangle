using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Security.Principal;

class nPrNcrTriangle {

public static List<List<int>> pascalLines = new();


static void PascalPrint(int line) {
    while (line > pascalLines.Count()-1) {
        pascalLines.Add(new List<int>());
        pascalLines[pascalLines.Count-1].Add(1);
        for (int i = 0; i < pascalLines[pascalLines.Count - 2].Count - 1; i++) {
            pascalLines[pascalLines.Count-1].Add(pascalLines[pascalLines.Count - 2][i] + pascalLines[pascalLines.Count - 2][i+1]);
        }
        pascalLines[pascalLines.Count-1].Add(1);
    }

    string s = "";
    for (int i = 0; i < pascalLines[line].Count; i++) {
        s += pascalLines[line][i];
        s += " ";
    }
    Console.WriteLine(s);
}

static void PascalPrint(int line, int column) {
    int a = line;
    if (column > line) {
        a = column;
    }
    while (a > pascalLines.Count()-1) {
        pascalLines.Add(new List<int>());
        pascalLines[pascalLines.Count-1].Add(1);
        for (int i = 0; i < pascalLines[pascalLines.Count - 2].Count - 1; i++) {
            pascalLines[pascalLines.Count-1].Add(pascalLines[pascalLines.Count - 2][i] + pascalLines[pascalLines.Count - 2][i+1]);
        }
        pascalLines[pascalLines.Count-1].Add(1);
    }

    string s = "";
    for (int j = (column > line) ? line : column; j < a; j++) {
        for (int i = 0; i < pascalLines[j].Count; i++) {
            s += pascalLines[j][i];
            s += " ";
        }
        s += '\n';
    }
    Console.WriteLine(s);
}

static void nPrPrint(int line, int column) {
    int ans = 1;
    // line! / (line-column)!
    for (int i = line; i > line - column; i--) {
        ans *= i;
    }
    Console.WriteLine(ans);
}

static void nCrPrint(int line, int column) {
    int ans = 1;
    // line! / ((line-column)! * column!)
    for (int i = line; i > line - column; i--) {
        ans *= i;
    }
    for (int i = column; i > 0; i--) {
        ans /= i;
    }
    Console.WriteLine(ans);
}

static List<string> Split(string s) {
    List<string> strings = new();
    strings.Add("");
    foreach (char c in s) {
        if (c == ' '){
            strings.Add("");
            continue;
        }
        strings[strings.Count - 1] += c;
    }
    return strings;
}

static int Main(string[] args) {
    pascalLines.Add(new List<int>());
    pascalLines[0].Add(1);
    pascalLines.Add(new List<int>());
    pascalLines[1].Add(1);
    pascalLines[1].Add(1);
    Console.WriteLine("Welcome to nPrNcrTriangle\n\u00A9 DecCatBurner 2024\nHere the goal is to examine the relationship between Pascal's Triangle and statistics");
    while (true) {
        Console.WriteLine("T for Pascal's Triangle, C for nCr, and P for nPr");
        string input = Console.ReadLine();
        List<string> arg = Split(input);
        int row, column;
        switch (arg[0].ToUpper()) {
            case "EXIT":
                goto Exit;
            case "T":
                if (arg.Count >= 2) {
                    if (arg.Count >= 3) {
                        if (int.TryParse(arg[1], out row) && int.TryParse(arg[2], out column)) {
                            PascalPrint(row, column);
                        }
                    } else {
                        if (int.TryParse(arg[1], out row)) {
                            PascalPrint(row);
                        }
                    }
                }
                break;
            case "P":
                if (arg.Count >= 3) {
                    if (int.TryParse(arg[1], out row) && int.TryParse(arg[2], out column)) {
                        nPrPrint(row, column);
                    }
                }
                break;
            case "C":
                if (arg.Count >= 3) {
                    if (int.TryParse(arg[1], out row) && int.TryParse(arg[2], out column)) {
                        nCrPrint(row, column);
                    }
                }
                break;
            default:
                Console.WriteLine("Not an argument.");
                break;
        }
    }
    Exit:
    return 0;
}

}