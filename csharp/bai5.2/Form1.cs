namespace bai5._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double a = 0, b = 0, c = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (a == 0)
            {
                textBox4.Text = "Sai định dạng";
                return;
            }
            double delta = b * b - 4 * a * c;
            if (delta > 0)
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                textBox4.Text = "Phương trình có 2 nghiệm phân biệt: x1 = " + x1 + " và x2 = " + x2;
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                textBox4.Text = "Phương trình có nghiệm kép: x = " + x;
            }
            else
            {
                textBox4.Text = "Phương trình vô nghiệm";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(textBox1.Text, out a))
            {
                a = Convert.ToDouble(textBox1.Text);
                textBox4.Text = (a != 0) ? "" : "Sai định dạng";
            }
            else
            {
                textBox4.Text = "Sai định dạng";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(textBox2.Text, out b))
            {
                b = Convert.ToDouble(textBox2.Text);
                textBox4.Text = "";
            }
            else
            {
                textBox4.Text = "Sai định dạng";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(textBox3.Text, out c))
            {
                c = Convert.ToDouble(textBox3.Text);
                textBox4.Text = "";
            }
            else
            {
                textBox4.Text = "Sai định dạng";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
