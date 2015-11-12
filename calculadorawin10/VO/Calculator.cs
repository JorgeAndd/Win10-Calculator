using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Calculator
    {
        private float memory = 0;
        private bool isMemoryEmpty = true;
        public enum Op { PLUS, MINUS, TIMES, DIV, RESULT }
        private Op lastOp = Op.RESULT;
        private List<historyEntry> history = new List<historyEntry>();

        public float Operate(float number, string operation)
        {
            if(isMemoryEmpty)
            {
                memory = number;
                isMemoryEmpty = false;
                SetLastOp(operation);

                return memory;
            }

            float operand1 = memory;

            switch(lastOp)
            {
                case Op.PLUS:
                    memory += number;
                    break;
                case Op.MINUS:
                    memory -= number;
                    break;
                case Op.TIMES:
                    memory *= number;
                    break;
                case Op.DIV:
                    memory /= number;
                    break;
            }

            addToHistory(operand1, number, memory, lastOp);

            SetLastOp(operation);
            return memory;

        }

        public void SetLastOp(string operation)
        {
            switch(operation)
            {
                case "+":
                    lastOp = Op.PLUS;
                    return;
                case "-":
                    lastOp = Op.MINUS;
                    return;
                case "x":
                    lastOp = Op.TIMES;
                    return;
                case "/":
                    lastOp = Op.DIV;
                    return;
            }
        }

        public float Result(float number)
        {
            //if (isMemoryEmpty)
            //    return 0;

            float result = memory;

            float operand1, operand2;
            operand1 = result;
            operand2 = number;

            switch (lastOp)
            {
                case Op.PLUS:
                    result += number;
                    break;
                case Op.MINUS:
                    result -= number;
                    break;
                case Op.TIMES:
                    result *= number;
                    break;
                case Op.DIV:
                    result /= number;
                    break;
                case Op.RESULT:
                    return 0;
                default:
                    return 0;
            }

            addToHistory(operand1, operand2, result, lastOp);

            isMemoryEmpty = true;
            return result;
        }

        public void Clear()
        {
            memory = 0;
            isMemoryEmpty = true;
        }

        public void ClearHistory()
        {
            history.Clear();
        }
        
        public IEnumerable<string> GetHistory()
        {
            List<string> historyText = new List<string>();

            foreach(historyEntry entry in history)
            {
                historyText.Add(entry.ToString());
            }

            return historyText;            
        }
        

        private void addToHistory(float operand1, float operand2, float result, Op op)
        {
            history.Add(new historyEntry(operand1, operand2, result, op));

            return;
        }

        private struct historyEntry
        {
            private float operand1, operand2, result;
            private Op op;

            public historyEntry(float operand1, float operand2, float result, Op op)
            {
                this.operand1 = operand1;
                this.operand2 = operand2;
                this.result = result;
                this.op = op;
            }

            public override string ToString()
            {
                string historyText = "";

                historyText += operand1;

                switch(op)
                {
                    case Op.PLUS:
                        historyText += " + ";
                        break;
                    case Op.MINUS:
                        historyText += " - ";
                        break;
                    case Op.TIMES:
                        historyText += " * ";
                        break;
                    case Op.DIV:
                        historyText += " / ";
                        break;
                }

                historyText += operand2 + " = " + result;

                return historyText;
            }
        }
    }
}
