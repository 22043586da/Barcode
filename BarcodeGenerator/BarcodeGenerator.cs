using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeGenerator
{
    public class BarcodeGenerator
    {
        private class Code128A 
        { string Symbol; string Pattern; int Value; public Code128A(string _symbol, string _pattern, int _value) { Symbol = _symbol; Pattern = _pattern; Value = _value; } }

        private class Code128B
        { string Symbol; string Pattern; int Value; public Code128B(string _symbol, string _pattern, int _value) { Symbol = _symbol; Pattern = _pattern; Value = _value; } }

        private class Code128C
        { string Symbol; string Pattern; int Value; public Code128C(string _symbol, string _pattern, int _value) { Symbol = _symbol; Pattern = _pattern; Value = _value; } }

        private List<Code128A> Code128ACharList = new List<Code128A>() 
        {
            new Code128A(" ","11011001100",0),   new Code128A("!","11001101100",1),  new Code128A("\"","11001100110",2), new Code128A("#","10010011000",3),  new Code128A("$","10010001100",4),
            new Code128A("%","10001001100",5),   new Code128A("&","10011001000",6),  new Code128A("'","10011000100",7),  new Code128A("(","10001100100",8),  new Code128A(")","11001001000",9),
            new Code128A("*","11001000100",10),  new Code128A("+","11000100100",11), new Code128A(",","10110011100",12), new Code128A("-","10011011100",13), new Code128A(".","10011001110",14),
            new Code128A("/","10111001100",15),  new Code128A("0","10011101100",16), new Code128A("1","10011100110",17), new Code128A("2","11001110010",18), new Code128A("3","11001011100",19),
            new Code128A("4","11001001110",20),  new Code128A("5","11011100100",21), new Code128A("6","11001110100",22), new Code128A("7","11101101110",23), new Code128A("8","11101001100",24),
            new Code128A("9","11100101100",25),  new Code128A(":","11100100110",26), new Code128A(";","11101100100",27), new Code128A("<","11100110100",28), new Code128A("=","11100110010",29),
            new Code128A(">","11011011000",30),  new Code128A("?","11011000110",31), new Code128A("@","11000110110",32), new Code128A("A","10100011000",33), new Code128A("B","10001011000",34),
            new Code128A("C","10001000110",35),  new Code128A("D","10110001000",36), new Code128A("E","10001101000",37), new Code128A("F","10001100010",38), new Code128A("G","11010001000",39),
            new Code128A("H","11000101000",40),  new Code128A("I","11000100010",41), new Code128A("J","10110111000",42), new Code128A("K","10110001110",43), new Code128A("L","10001101110",44),
            new Code128A("M","10111011000",45),  new Code128A("N","10111000110",46), new Code128A("O","10001110110",47), new Code128A("P","11101110110",48), new Code128A("Q","11010001110",49),
            new Code128A("R","11000101110",50),  new Code128A("S","11011101000",51), new Code128A("T","11011100010",52), new Code128A("U","11011101110",53), new Code128A("V","11101011000",54),
            new Code128A("W","11101000110",55),  new Code128A("X","11100010110",56), new Code128A("Y","11101101000",57), new Code128A("Z","11101100010",58), new Code128A("[","11100011010",59),
            new Code128A("\\","11101111010",60), new Code128A("]","11001000010",61), new Code128A("^","11110001010",62), new Code128A("_","10100110000",63), new Code128A("Code C","10111011110",99),
            new Code128A("Code B","10111101110",100)
        };

        private List<Code128B> Code128BCharList = new List<Code128B>()
        {
            new Code128B(" ","11011001100",0),  new Code128B("!","11001101100",1),  new Code128B("\"","11001100110",2), new Code128B("#","10010011000",3),  new Code128B("$","10010001100",4),
            new Code128B("%","10001001100",5),  new Code128B("&","10011001000",6),  new Code128B("'","10011000100",7),  new Code128B("(","10001100100",8),  new Code128B(")","11001001000",9),
            new Code128B("*","11001000100",10), new Code128B("+","11000100100",11), new Code128B(",","10110011100",12), new Code128B("-","10011011100",13), new Code128B(".","10011001110",14),
            new Code128B("/","10111001100",15), new Code128B("0","10011101100",16), new Code128B("1","10011100110",17), new Code128B("2","11001110010",18), new Code128B("3","11001011100",19),
            new Code128B("4","11001001110",20), new Code128B("5","11011100100",21), new Code128B("6","11001110100",22), new Code128B("7","11101101110",23), new Code128B("8","11101001100",24),
            new Code128B("9","11100101100",25), new Code128B(":","11100100110",26), new Code128B(";","11101100100",27), new Code128B("<","11100110100",28), new Code128B("=","11100110010",29),
            new Code128B(">","11011011000",30), new Code128B("?","11011000110",31), new Code128B("@","11000110110",32), new Code128B("A","10100011000",33), new Code128B("B","10001011000",34),
            new Code128B("C","10001000110",35), new Code128B("D","10110001000",36), new Code128B("E","10001101000",37), new Code128B("F","10001100010",38), new Code128B("G","11010001000",39),
            new Code128B("H","11000101000",40), new Code128B("I","11000100010",41), new Code128B("J","10110111000",42), new Code128B("K","10110001110",43), new Code128B("L","10001101110",44),
            new Code128B("M","10111011000",45), new Code128B("N","10111000110",46), new Code128B("O","10001110110",47), new Code128B("P","11101110110",48), new Code128B("Q","11010001110",49),
            new Code128B("R","11000101110",50), new Code128B("S","11011101000",51), new Code128B("T","11011100010",52), new Code128B("U","11011101110",53), new Code128B("V","11101011000",54),
            new Code128B("W","11101000110",55), new Code128B("X","11100010110",56), new Code128B("Y","11101101000",57), new Code128B("Z","11101100010",58), new Code128B("[","11100011010",59),
            new Code128B("\\","11101111010",60),new Code128B("]","11001000010",61), new Code128B("^","11110001010",62), new Code128B("_","10100110000",63), new Code128B("`","10100001100",64),
            new Code128B("a","10010110000",65), new Code128B("b","10010000110",66), new Code128B("c","10000101100",67), new Code128B("d","10000100110",68), new Code128B("e","10110010000",69),
            new Code128B("f","10110000100",70), new Code128B("g","10011010000",71), new Code128B("h","10011000010",72), new Code128B("i","10000110100",73), new Code128B("j","10000110010",74),
            new Code128B("k","11000010010",75), new Code128B("l","11001010000",76), new Code128B("m","11110111010",77), new Code128B("n","11000010100",78), new Code128B("o","10001111010",79),
            new Code128B("p","10100111100",80), new Code128B("q","10010111100",81), new Code128B("r","10010011110",82), new Code128B("s","10111100100",83), new Code128B("t","10011110100",84),
            new Code128B("u","10011110010",85), new Code128B("v","11110100100",86), new Code128B("w","11110010100",87), new Code128B("x","11110010010",88), new Code128B("y","11011011110",89),
            new Code128B("z","11011110110",90), new Code128B("{","11110110110",91), new Code128B("|","10101111000",92), new Code128B("}","10100011110",93), new Code128B("~","10001011110",94),
            new Code128B("Code C","10111011110",95),    new Code128B("Code A","11101011110",96)
        };

        private List<Code128C> Code128CCharList = new List<Code128C>() 
        {

        };

       


    }
}
