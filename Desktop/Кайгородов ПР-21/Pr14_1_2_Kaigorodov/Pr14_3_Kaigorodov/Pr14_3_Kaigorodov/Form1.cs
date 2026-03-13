using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pr14_3_Kaigorodov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBox1.Text);

                if (n <= 0)
                {
                    MessageBox.Show("Число должно быть больше 0");
                    return;
                }

                Stack<int> A = new Stack<int>(n);

                for (int i = 1; i <= n; i++)
                {
                    A.Push(i);
                }

                string result = "";
                result += $"n = {n}\n";
                result += $"Размерность стека {A.Count}\n";
                result += $"Верхний элемент стека = {A.Peek()}\n";

                string st = "";
                for (int i = 0; i < n; i++)
                {
                    st += $"{A.Pop()} ";
                }

                result += $"Содержимое стека = {st}\n";
                result += $"Новая размерность стека {A.Count}";

                MessageBox.Show(result, "Результат работы со стеком");

            }
            catch (System.FormatException)
            {
                MessageBox.Show("Ошибка неверный тип данных");
            }
        }
    }
}
