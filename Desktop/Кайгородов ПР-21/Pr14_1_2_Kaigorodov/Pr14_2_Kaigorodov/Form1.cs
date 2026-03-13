using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pr14_2_Kaigorodov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool Error = false;

        private void button1_Click(object sender, EventArgs e)
        {
            string vir = textBox1.Text;
            Null(vir);
            if (Error) return;
            File.WriteAllText("t.txt", vir);
            int ErrPos = -1;
            bool Balance = CheckBalance(vir, out ErrPos);
            
            if (Balance)
            {
                MessageBox.Show("Скобки сбалансированы");
            }
            else
            {
                if (ErrPos != -1)
                {
                    MessageBox.Show($"Возможно лишняя скобка в позиции: {ErrPos}");
                }
                else
                {
                    MessageBox.Show("Скобки не сбалансированы(не хватает закрывющих скобок)");
                }
            }
            
        }

        static bool CheckBalance (string text, out int ErrPos)
        {
            int balance = 0;
            ErrPos = -1;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '(')
                {
                    balance++;
                }
                else if (c == ')')
                {
                    balance--;
                    if (balance < 0)
                    {
                        ErrPos = i + 1;
                        return false;
                    }
                }
            }
            return balance == 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string vir = textBox1.Text;
            Null(vir);
            if (Error) return;
            string Fix = FixBalance(vir);
            File.WriteAllText("t1.txt", Fix);
            textBox1.Text = Fix;
        }
        
        public void  Null (string text)
        {
            if (text.Length == 0)
            {
                MessageBox.Show("Строка пуста!");
                Error = true;
                return;
            }
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if ((!Char.IsDigit(text[i])) && (text[i] != '+') && (text[i] != '-') && (text[i] != '*') && (text[i] != '/') && (text[i] != '=') && (text[i] != ' ') && (text[i] != '(') && (text[i] != ')'))
                {
                    MessageBox.Show("Недопустимые символы в выражении!");
                    Error = true;
                    return;
                }


                if (!Char.IsDigit(text[0]) && text[0] != '(' && text[0] != '-')
                {
                    MessageBox.Show("первый символ должен быть цифра, ( или -");
                    Error = true;
                    return;
                }
               
            }
        }

        static string FixBalance (string text)
        {
            int balance = 0;
            StringBuilder result = new StringBuilder();

            foreach (char c in text)
            {
                if (c == '(')
                {
                    balance++;
                    result.Append(c);
                }
                else 
                {
                    if (c == ')')
                    {
                        if (balance > 0)
                        {
                            balance--;
                            result.Append(c);
                        }
                    }
                    else
                    {
                        result.Append(c);
                    }
                }
            }

            for (int i = 0; i < balance; i++)
            {
                result.Append(')');
            }

            return result.ToString();
        }
    }
}
