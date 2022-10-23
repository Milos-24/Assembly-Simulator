using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Arh_Simulator
{
    public enum Operation
    {
        LOAD, ADD, SUB, AND, OR, NOT, CMP, JE, JNE, JGE, JL, LABEL, ERR
    }

    public class Registers
    {
        public long RAX { get; set; } = 0;
        public long RBX { get; set; } = 0;
        public long RCX { get; set; } = 0;
        public long RDX { get; set; } = 0;
    }

    public class Flags
    {
        public bool ZeroFlag { get; set; } = false;
        public bool SignFlag { get; set; } = false;
        public bool CarryFlag { get; set; } = false;
        public bool OverflowFlag { get; set; } = false;

        public void ResetFlags()
        {
            ZeroFlag = false;
            SignFlag = false;
            CarryFlag = false;
            OverflowFlag = false;
        }
    }

    //Cijeli tekst izdijelim na linije teksta
    //Linije parsiram u ovoj klasi i odredim o kojoj se operaciji radi i da li je operacija unijeta ispravno
    public class Instruction
    {
        public int maxNumOfAddress { get; }

        public Operation operation { get; set;}

        public readonly string[] parsedText;            //linija inputa
        
        public Instruction(string lineOfText, int numOfAddress)
        {
            this.maxNumOfAddress = numOfAddress;
            parsedText = lineOfText.Split(" ");
            this.operation = this.IsOperationValid(parsedText[0]);
        }
        public string GetLine()
        {
            string str = null;
            foreach (string s in parsedText)
                str += s + " ";
            return str.Trim() + "\n";
        }
        public string GetOperand1()
        {
            if (parsedText.Length >= 2)
                return this.parsedText[1];
            else
                return "";
        }

        public string GetOperand2()
        {
            if (parsedText.Length >= 3)
                return this.parsedText[2];
            else
                return "";
        }
        public string GetLABEL()
        {
            return parsedText[0].Remove(parsedText[0].Length-1);
        }
        public static bool IsAllLettersOrDigits(string s)
        {
            foreach (char c in s)
            {

                if (!Char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }
        public static bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private Operation IsOperationValid(string firstElement)
        {
            if (parsedText.Length > 3)
                return Operation.ERR;

            if (firstElement.EndsWith(":"))
            { 
                if(IsAllLettersOrDigits(firstElement.Remove(firstElement.Length - 1)))
                    return Operation.LABEL;
                else
                    return Operation.ERR;
            }
            foreach (Operation o in Enum.GetValues(typeof(Operation)))
            {
                string str = o.ToString();
                if (str.Equals(firstElement))
                    return CheckOperation(firstElement)? o:Operation.ERR;
            }
           

            return Operation.ERR;
        }

        //provjeri da li je dobra operacija
        public bool CheckOperation(string firstElement)
        {
            if ("LOAD".Equals(firstElement))
            {
                if (parsedText.Length != 3)
                    return false;
                else
                {
                    bool op1 = IsOperandValid(parsedText[1]);
                    bool op2 = IsOperandValid(parsedText[2]) || IsOperatndConstant(parsedText[2]);

                    return op1 && op2;
                }
            }
            else if ("ADD".Equals(firstElement))
            {
                if (parsedText.Length != 3)
                    return false;
                else
                {
                    bool op1 = IsOperandValid(parsedText[1]);
                    bool op2 = IsOperandValid(parsedText[2]) || IsOperatndConstant(parsedText[2]);

                    return op1 && op2;
                }
            }
            else if ("SUB".Equals(firstElement))
            {
                if (parsedText.Length != 3)
                    return false;
                else
                {
                    bool op1 = IsOperandValid(parsedText[1]);
                    bool op2 = IsOperandValid(parsedText[2]) || IsOperatndConstant(parsedText[2]);

                    return op1 && op2;
                }
            }
            else if ("AND".Equals(firstElement))
            {
                if (parsedText.Length != 3)
                    return false;
                else
                {
                    bool op1 = IsOperandValid(parsedText[1]);
                    bool op2 = IsOperandValid(parsedText[2]) || IsOperatndConstant(parsedText[2]);

                    return op1 && op2;
                }
            }
            else if ("OR".Equals(firstElement))
            {
                if (parsedText.Length != 3)
                    return false;
                else
                {
                    bool op1 = IsOperandValid(parsedText[1]);
                    bool op2 = IsOperandValid(parsedText[2]) || IsOperatndConstant(parsedText[2]);

                    return op1 && op2;
                }
            }
            else if ("NOT".Equals(firstElement))
            {
                if (parsedText.Length != 2)
                    return false;

                if (IsOperandValid(parsedText[1]))
                    return true;
                else
                    return false;
            }
            else if ("CMP".Equals(firstElement))
            {
                if (parsedText.Length != 3)
                    return false;
                else
                {
                    bool op1 = IsOperandValid(parsedText[1]) || IsOperatndConstant(parsedText[1]);
                    bool op2 = IsOperandValid(parsedText[2]) || IsOperatndConstant(parsedText[2]);

                    return op1 && op2;
                }
            }
            else if ("JNE".Equals(firstElement))
            {
                if (parsedText.Length != 2)
                    return false;
                else
                    return true;
            }
            else if ("JE".Equals(firstElement))
            {
                if (parsedText.Length != 2)
                    return false;
                else
                    return true;
            }
            else if ("JGE".Equals(firstElement))
            {
                if (parsedText.Length != 2)
                    return false;
                else
                    return true;
            }
            else if ("JL".Equals(firstElement))
            {
                if (parsedText.Length != 2)
                    return false;
                else
                    return true;
            }
            else return false;
        }

        //operand je validan ako je on registar ili adresa
        public bool IsOperandValid(string firstElement)
        {
            if ("RAX".Equals(firstElement))
                return true;
            else if ("RBX".Equals(firstElement))
                return true;
            else if ("RCX".Equals(firstElement))
                return true;
            else if ("RDX".Equals(firstElement))
                return true;
            else if (firstElement.StartsWith("ADDRESS"))
            {

                int found = firstElement.IndexOf("SS");
                string pomString = firstElement.Substring(found+2);

                if (!IsAllDigits(pomString) || firstElement.Length==7)
                    return false;    
                    
                long address = long.Parse(pomString);
                
                    
                
                if (address < 0 || address > this.maxNumOfAddress)
                     return false;
                else
                     return true;
             }
             else return false;
        }

        //operand je konsanta ako je to neka brojevna vrijednost
        public bool IsOperatndConstant(string firstElement)
        {
            try
            {
                long constant = long.Parse(firstElement);
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
    }


    public class Assembly
    {
        public readonly static int numOfAddresses=20;   //rucno unosimo broj adresa

        private readonly Flags flags;
        Dictionary<string, int> labels;
        public Instruction[] instructions;
        Dictionary<string, long> address;
        public Registers registers;
        public int currentlyExecutedLine { get; set; } = 0;
        public int numOfInstructions { get; set; }

        public Assembly(string input)
        {
            input = input.ToUpper();
            labels = new Dictionary<string, int>();
            Initialize(input);              //inicijalizuj instrukcije adrese i labele
            registers = new Registers();
            flags = new Flags();
            JumpValidity();             //provjerimo da li ispravno unesena operacija za prelazak na labelu
        }

        private void Initialize(string input)
        {
            //instrukcije
            string[] s=input.Split("\n");       //izdjeli uneseni tekst na linije
            numOfInstructions = s.Length;             //broj unesenih linija
            instructions = new Instruction[numOfInstructions];
          
            for(int i=0;i<s.Length;i++)
            {
                instructions[i] = new Instruction(s[i], numOfAddresses);
            }
            //adrese
            address = new Dictionary<string, long>();
            for (int i = 0; i < numOfAddresses; i++)
                address.Add("ADDRESS" + i.ToString(), 0);
            //labele
            foreach (Instruction i in instructions)
            {
                string str = i.operation.ToString();
                if ("LABEL".Equals(str))                        //ako je operacija label
                {
                    if (labels.ContainsKey(i.GetLABEL()))          //ako vec postojece labele sadrze vec tu labelu
                        i.operation = Operation.ERR;
                    else
                        labels.Add(i.GetLABEL(), Array.IndexOf(instructions, i));
                }
            }
        }
        private void JumpValidity()                 //unesena je ispravno ako 1)postoji labela, 2)ako se prije instrukcije za prelazak nalazi cmp
        {
            foreach(Instruction o in instructions)
            {
                if (o.operation == Operation.JE || o.operation == Operation.JGE || o.operation == Operation.JL || o.operation == Operation.JNE)
                {
                    if (!labels.ContainsKey(o.GetOperand1()))//o.getoperand1
                        o.operation = Operation.ERR;
                    int pom = Array.IndexOf(instructions, o) - 1;
                    if (pom >= 0)
                    {
                        if (instructions[pom].operation != Operation.CMP)
                            o.operation = Operation.ERR;
                    }
                    else continue;
                }
            }
        }

        public long GetAddress(string str)          //returns value stored in sent address
        {
            return this.address[str];
        }

        public void ExecuteNext()
        {
       
            
            foreach (Operation o in Enum.GetValues(typeof(Operation)))
            {
                if(instructions[currentlyExecutedLine].operation==o)
                {
                    ExecuteOperation(o.ToString());
                    break;
                }
            }
        }
        public void ExecuteOperation(string operation)
        {
            if (operation.Equals("LABEL"))
                return;
            else if (operation.Equals("ADD"))
                ExecuteADD();
            else if (operation.Equals("SUB"))
                ExecuteSUB();
            else if (operation.Equals("LOAD"))
                ExecuteLOAD();
            else if (operation.Equals("AND"))
                ExecuteAND();
            else if (operation.Equals("OR"))
                ExecuteOR();
            else if (operation.Equals("NOT"))
                ExecuteNOT();
            else if (operation.Equals("CMP"))
                ExecuteCMP();
            else if (operation.Equals("JE"))
                ExecuteJE();
            else if (operation.Equals("JNE"))
                ExecuteJNE();
            else if (operation.Equals("JGE"))
                ExecuteJGE();
            else if (operation.Equals("JL"))
                ExecuteJL();
        }

        public long GetOperandValue(string operand)
        {
            if (instructions[0].IsOperandValid(operand))
            {
                if ("RAX".Equals(operand))
                    return this.registers.RAX;
                else if ("RBX".Equals(operand))
                    return this.registers.RBX;
                else if ("RCX".Equals(operand))
                    return this.registers.RCX;
                else if ("RDX".Equals(operand))
                    return this.registers.RDX;
                else
                    return address[operand];
            }
            else if (instructions[0].IsOperatndConstant(operand))
            {
                return long.Parse(operand);
            }
            else
                return 0;
        }

        private void ExecuteADD() 
        {
            string operand1 = instructions[currentlyExecutedLine].GetOperand1();
            string operand2 = instructions[currentlyExecutedLine].GetOperand2();
            long operand1Value = GetOperandValue(operand1);
            long operand2Value = GetOperandValue(operand2);

            if ("RAX".Equals(operand1))
                registers.RAX += operand2Value;
            else if ("RBX".Equals(operand1))
                registers.RBX += operand2Value;
            else if ("RCX".Equals(operand1))
                registers.RCX += operand2Value;
            else if ("RDX".Equals(operand1))
                registers.RDX += operand2Value;
            else
                address[operand1] += operand2Value;

            this.SetOverflowAndCarryFlag(operand1Value + operand2Value);
            this.SetSignAndZeroFlag(operand1Value + operand2Value);

        }
        private void ExecuteSUB()
        {
            string operand1 = instructions[currentlyExecutedLine].GetOperand1();
            string operand2 = instructions[currentlyExecutedLine].GetOperand2();
            long operand1Value = GetOperandValue(operand1);
            long operand2Value = GetOperandValue(operand2);

            if ("RAX".Equals(operand1))
                registers.RAX -= operand2Value;
            else if ("RBX".Equals(operand1))
                registers.RBX -= operand2Value;
            else if ("RCX".Equals(operand1))
                registers.RCX -= operand2Value;
            else if ("RDX".Equals(operand1))
                registers.RDX -= operand2Value;
            else
                address[operand1] -= operand2Value;

            this.SetOverflowAndCarryFlag(operand1Value - operand2Value);
            this.SetSignAndZeroFlag(operand1Value - operand2Value);

        }
        private void ExecuteLOAD()
        {
            flags.ResetFlags();
            string operand1 = instructions[currentlyExecutedLine].GetOperand1();
            string operand2 = instructions[currentlyExecutedLine].GetOperand2();
            long operand2Value = GetOperandValue(operand2);

            if ("RAX".Equals(operand1))
                registers.RAX = operand2Value;
            else if ("RBX".Equals(operand1))
                registers.RBX = operand2Value;
            else if ("RCX".Equals(operand1))
                registers.RCX = operand2Value;
            else if ("RDX".Equals(operand1))
                registers.RDX = operand2Value;
            else
                address[operand1] = operand2Value;
        }

        private void ExecuteAND()
        {
            flags.ResetFlags();
            string operand1 = instructions[currentlyExecutedLine].GetOperand1();
            string operand2 = instructions[currentlyExecutedLine].GetOperand2();
            long operand2Value = GetOperandValue(operand2);

            if ("RAX".Equals(operand1))
                registers.RAX = registers.RAX & operand2Value;
            else if ("RBX".Equals(operand1))
                registers.RBX = registers.RBX & operand2Value;
            else if ("RCX".Equals(operand1))
                registers.RCX = registers.RCX & operand2Value;
            else if ("RDX".Equals(operand1))
                registers.RDX = registers.RDX & operand2Value;
            else
            {
                long helper = address[operand1];
                address[operand1] = helper & operand2Value;
            }
        }
        private void ExecuteOR()
        {
            flags.ResetFlags();
            string operand1 = instructions[currentlyExecutedLine].GetOperand1();
            string operand2 = instructions[currentlyExecutedLine].GetOperand2();
            long operand2Value = GetOperandValue(operand2);

            if ("RAX".Equals(operand1))
                registers.RAX = registers.RAX | operand2Value;
            else if ("RBX".Equals(operand1))
                registers.RBX = registers.RBX | operand2Value;
            else if ("RCX".Equals(operand1))
                registers.RCX = registers.RCX | operand2Value;
            else if ("RDX".Equals(operand1))
                registers.RDX = registers.RDX | operand2Value;
            else
            {
                long helper = address[operand1];
                address[operand1] = helper | operand2Value;
            }
        }
        private void ExecuteNOT()
        {
            flags.ResetFlags();
            string operand1 = instructions[currentlyExecutedLine].GetOperand1();

            if ("RAX".Equals(operand1))
                registers.RAX = ~registers.RAX;
            else if ("RBX".Equals(operand1))
                registers.RBX = ~registers.RBX;
            else if ("RCX".Equals(operand1))
                registers.RCX = ~registers.RCX;
            else if ("RDX".Equals(operand1))
                registers.RDX = ~registers.RDX;
            else
            {
                long helper = address[operand1];
                address[operand1] = helper != 0 ? 0 : 1;
            }
        }
        private void ExecuteCMP()
        {
            string operand1 = instructions[currentlyExecutedLine].GetOperand1();
            string operand2 = instructions[currentlyExecutedLine].GetOperand2();
            long operand1Value = GetOperandValue(operand1);
            long operand2Value = GetOperandValue(operand2);

            BigInteger number = operand1Value;
            number -= operand2Value;
            SetOverflowAndCarryFlag(number);
            SetSignAndZeroFlag(operand1Value - operand2Value);
        }
        private void SetOverflowAndCarryFlag(BigInteger number)
        {
            if (number > long.MaxValue || number < long.MinValue)
                this.flags.OverflowFlag = true;
            else
                this.flags.OverflowFlag = false;

            if (number > ulong.MaxValue || number < ulong.MinValue)
                this.flags.CarryFlag = true;
            else
                this.flags.CarryFlag = false;
        }
        private void SetSignAndZeroFlag(long number)
        {
            if (number >= 0)
                this.flags.SignFlag = false;
            else
                this.flags.SignFlag = true;

            if (number == 0)
                this.flags.ZeroFlag = true;
            else
                this.flags.ZeroFlag = false;
        }
        private void ExecuteJGE()
        {
            if (this.flags.SignFlag == this.flags.OverflowFlag)
                this.JumpToLabel(this.instructions[this.currentlyExecutedLine].GetOperand1());
            flags.ResetFlags();
        }

        private void ExecuteJE()
        {
            if (this.flags.ZeroFlag == true)
                this.JumpToLabel(this.instructions[this.currentlyExecutedLine].GetOperand1());
            flags.ResetFlags();
        }

        private void ExecuteJNE()
        {
            if (this.flags.ZeroFlag == false)
                this.JumpToLabel(this.instructions[this.currentlyExecutedLine].GetOperand1());
            flags.ResetFlags();
        }

        private void ExecuteJL()
        {
            if (this.flags.SignFlag != this.flags.OverflowFlag)
                this.JumpToLabel(this.instructions[this.currentlyExecutedLine].GetOperand1());
            flags.ResetFlags();
        }

        private void JumpToLabel(string label)
        {
            if (labels.ContainsKey(label))
                this.currentlyExecutedLine = this.labels[label]-1;
         
        }

        public string ReturnInvalidLines()
        {
            string str=null;
            int pom = 1;

            foreach(Instruction i in instructions)
            {
                if (i.operation == Operation.ERR)
                    str += "Line " + (pom).ToString() + " is invalid\n";

                pom++;
            }

            return str;
        }

        public bool InvalidLines()
        {
            foreach (Instruction i in instructions)
                if (i.operation == Operation.ERR)
                    return true;

            return false;
        }
    }

}
