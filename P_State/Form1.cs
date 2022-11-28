namespace P_State
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            printer = new Printer(new DisabledPrinterState());
            textBox1.Text = "Disabled!";
        }
        Printer printer;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = printer.On();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = printer.Off();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = printer.Print();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = printer.InsertPaper();

        }
    }
}