namespace bai5._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        double r = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            r = Double.TryParse(textBox1.Text, out r) ? r : 0;
            if (r == 0)
            {
                textBox2.Text = "Sai định dạng";
            }
            else
            {
                textBox2.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double C = 2 * Math.PI * r;
            textBox2.Text = "Chu vi hình tròn = " + C.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double S = Math.PI * r * r;
            textBox2.Text = "Diện tích hình tròn = " + S.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
