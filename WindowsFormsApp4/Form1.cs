using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private float d1, d2, res;
        private int op;
        public Form1()
        {
            InitializeComponent();
            label1.Text = label2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            op = 0;
        }

        // Обработчик кнопки умножения
        private void button1_Click(object sender, EventArgs e)
        {
            if (is_number())
            {
                copy_number(1); // 1 - код операции умножения
            }
            else { textBox1.SelectAll(); textBox1.Focus(); }
        }

        // Обработчик кнопки деления
        private void button2_Click(object sender, EventArgs e)
        {
            if (is_number())
            {
                copy_number(2); // 2 - код операции деления
            }
            else { textBox1.SelectAll(); textBox1.Focus(); }
        }

        // Обработчик кнопки сложения
        private void button3_Click(object sender, EventArgs e)
        {
            if (is_number())
            {
                copy_number(3); // 3 - код операции сложения
            }
            else { textBox1.SelectAll(); textBox1.Focus(); }
        }

        // Обработчик кнопки вычитания
        private void button4_Click(object sender, EventArgs e)
        {
            if (is_number())
            {
                copy_number(4); // 4 - код операции вычитания
            }
            else { textBox1.SelectAll(); textBox1.Focus(); }
        }

        // Обработчик кнопки "="
        private void button5_Click(object sender, EventArgs e)
        {
            if (op != 0 && is_number())
            {
                switch (op)
                {
                    case 1: // Умножение
                        try
                        {
                            res = d1 * d2;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Переполнение");
                            return;
                        }
                        break;
                    case 2: // Деление
                        try
                        {
                            if (d2 == 0)
                            {
                                MessageBox.Show("Деление на ноль");
                                return;
                            }
                            res = d1 / d2;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка при делении");
                            return;
                        }
                        break;
                    case 3: // Сложение
                        res = d1 + d2;
                        break;
                    case 4: // Вычитание
                        res = d1 - d2;
                        break;
                    case 5: // Степень
                        res = (float)Math.Pow(d1, d2);
                        break;
                    case 6: // Радианы в градусы
                        res = d1 * (180f / (float)Math.PI);
                        break;
                }

                label1.Text += label2.Text + textBox1.Text + "=" + res;
                label2.Text = "";
                textBox1.Text = res.ToString();
                op = 0;
                textBox1.Focus();
            }
        }

        // Обработчик кнопки "C" (очистка)
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = label2.Text = "";
            op = 0;
            textBox1.Focus();
        }

        private void buttonPower_Click_Click(object sender, EventArgs e)
        {
            if (is_number())
            {
                copy_number(5); // 5 - код операции возведения в степень
            }
            else { textBox1.SelectAll(); textBox1.Focus(); }
        }

        private void buttonRadToDeg_Click_Click(object sender, EventArgs e)
        {
            if (is_number())
            {
                op = 6; // 6 - код операции преобразования
                d1 = float.Parse(textBox1.Text);
                res = d1 * (180f / (float)Math.PI);

                label1.Text = textBox1.Text + " радиан = ";
                label2.Text = "";
                textBox1.Text = res.ToString();
                op = 0;
                textBox1.Focus();
            }
            else { textBox1.SelectAll(); textBox1.Focus(); }
        }

        private bool is_number()
        {
            float d;
            bool Is_Num = float.TryParse(textBox1.Text, System.Globalization.NumberStyles.Number,
                System.Globalization.NumberFormatInfo.CurrentInfo, out d);
            textBox1.Focus();
            if (Is_Num)
            {
                if (op == 0) d1 = d; else d2 = d;
                return true;
            }
            return false;
        }

        private void copy_number(int op)
        {
            this.op = op;
            label1.Text = textBox1.Text;
            switch (op)
            {
                case 1: label2.Text = "*"; break;
                case 2: label2.Text = "/"; break;
                case 3: label2.Text = "+"; break;
                case 4: label2.Text = "-"; break;
                case 5: label2.Text = "^"; break;
            }
            textBox1.Clear();
        }
    }
}
