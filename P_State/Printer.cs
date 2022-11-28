using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_State
{
    public class Printer
    {
        public IPrinterState printerState { get; set; }
        public Printer(IPrinterState printerState)
        {
            this.printerState = printerState;
        }
        public string On()
        {
            return printerState.On(this);
        }
        public string Off()
        {
            return printerState.Off(this);
        }
        public string Print()
        {
            return printerState.Print(this);
        }
        public string InsertPaper()
        {
            return printerState.InsertPaper(this);
        }
    }
    public interface IPrinterState
    {
        string On(Printer printer);
        string Off(Printer printer);
        string Print(Printer printer);
        string InsertPaper(Printer printer);
    }
    class DisabledPrinterState : IPrinterState
    {
        public string InsertPaper(Printer printer)
        {
            return "Disabled";
        }

        public string Off(Printer printer)
        {
            return "Disabled";
        }

        public string On(Printer printer)
        {
            MessageBox.Show("Welcome!");
            printer.printerState = new NoPaperPrinterState();
            return "Out of paper!";
        }

        public string Print(Printer printer)
        {
            return "Disabled";
        }
    }
    class ExpectationPrinterState : IPrinterState
    {
        public string InsertPaper(Printer printer)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Paper replenished!");
            sb.AppendLine("Expectation...");
            return sb.ToString();
        }

        public string Off(Printer printer)
        {
            printer.printerState = new DisabledPrinterState();
            return "Disabled";
        }

        public string On(Printer printer)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The printer is already on!");
            sb.AppendLine("Expectation...");
            return sb.ToString();
        }

        public string Print(Printer printer)
        {
            printer.printerState = new PrintPrinterState();
            Task.Run(() =>
            {
                Thread.Sleep(3000);
                printer.printerState = new NoPaperPrinterState();
                Form1 form1 = new Form1();
                form1.textBox1.Text = "Out of paper!";
            });
            return "Print...";
        }
    }
    class PrintPrinterState : IPrinterState
    {
        public string InsertPaper(Printer printer)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Paper replenished!");
            sb.AppendLine("Expectation...");
            printer.printerState = new ExpectationPrinterState();
            return sb.ToString();
        }

        public string Off(Printer printer)
        {
            printer.printerState = new DisabledPrinterState();
            return "Disabled";
        }

        public string On(Printer printer)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The printer is already on!");
            sb.AppendLine("Print...");
            return sb.ToString();
        }

        public string Print(Printer printer)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The printer is already printing!");
            sb.AppendLine("Print...");
            return sb.ToString();
        }
    }
    class NoPaperPrinterState : IPrinterState
    {
        public string InsertPaper(Printer printer)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Paper replenished!");
            sb.AppendLine("Expectation...");
            printer.printerState = new ExpectationPrinterState();
            return sb.ToString();
        }

        public string Off(Printer printer)
        {
            printer.printerState = new DisabledPrinterState();
            return "Disabled";
        }

        public string On(Printer printer)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The printer is already on!");
            sb.AppendLine("Out of paper!");
            return sb.ToString();
        }

        public string Print(Printer printer)
        {
            return "Out of paper!";
        }
    }
}
