namespace bai5._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double quangDuong = 0;
        private bool xe7Cho = true;
        bool giamGia = false;
        double giaTien = 17000;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(textBox1.Text, out quangDuong))
            {
                if (quangDuong < 0)
                {
                    textBox2.Text = "Quãng đường không hợp lệ";
                    return;
                }
                else if (0 <= quangDuong && quangDuong <= 1)
                {
                    giaTien = xe7Cho ? 17000 : 15000;
                }
                else if (2 <= quangDuong && quangDuong <= 5)
                {
                    giaTien = (xe7Cho ? 17000 : 15000) + (quangDuong - 1) * (xe7Cho ? 15000 : 13500);
                }
                else if (6 <= quangDuong && quangDuong <= 100)
                {
                    giaTien = (xe7Cho ? 17000 : 15000) + 4 * (xe7Cho ? 15000 : 13500) + (quangDuong - 5) * (xe7Cho ? 12000 : 11000);
                }
                else if (101 <= quangDuong)
                {
                    giaTien = (xe7Cho ? 17000 : 15000) + 4 * (xe7Cho ? 15000 : 13500) + 95 * (xe7Cho ? 12000 : 11000) + (quangDuong - 100) * (xe7Cho ? 11000 : 10000);
                }
                checkBox1_CheckedChanged(checkBox1, new EventArgs());
            }
            else
            {
                textBox2.Text = "Quãng đường không hợp lệ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void radioButton1_Click_1(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            xe7Cho = true;
            textBox1_TextChanged(textBox1, new EventArgs());
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            xe7Cho = false;
            textBox1_TextChanged(textBox1, new EventArgs());
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            giamGia = checkBox1.Checked;
            textBox2.Text = (giamGia) ? (giaTien * 0.95).ToString() : giaTien.ToString();
        }
    }
}
