using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            L_view.Visible = true;
            yl_view.Visible = true;
            L_view.Rows.Clear();
            yl_view.Rows.Clear();
            final12.Clear();
       

            int size = (data_table.Rows.Count);
           // Console.WriteLine("size = " + size);
            size = size - 1;
            Console.WriteLine(size);
            float[] array = new float[size];
            float[] array1 = new float[size];
            int a = 0;
            int b = 0;
            int c = 0;
            try
            {
                for (int rows = 0; rows < data_table.Rows.Count; rows++)
                {
                    for (int col = 0; col < data_table.Rows[rows].Cells.Count; col++)
                    {
                        string value = data_table.Rows[rows].Cells[col].Value.ToString();
                        float val = System.Convert.ToSingle(value);
                        if (c == 0)
                        {
                            array[a] = val;
                            c = 1;

                        }
                        else
                        {

                            array1[b] = val;
                        }

                    }
                    c = 0;
                    a++;
                    b++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message =" + ex.Message);
            }
            string abc = x_value.Text;
            string total = null;
            if (abc == null || abc=="NULL")
            {
                //start

                for (int as1 = 0; as1 < size; as1++)
                {
                    string final = null;
                    string final1 = array1[as1].ToString();
                    final1 = "+"+final1 + "*(";
                    Queue<string> fullq = new Queue<string>();
                    for (int a1 = 0; a1 < size; a1++)
                    {
                        if (a1 != as1)
                        {
                            fullq.Enqueue("(");
                            fullq.Enqueue("x");
                            fullq.Enqueue("-");
                            string abc1 = array[a1].ToString();
                            fullq.Enqueue(abc1);
                            fullq.Enqueue(")");

                        }


                    }
                    int loo = fullq.Count;
                    //       for (int a = 0; a < loo; a++)
                    //     {
                    //       Console.Write(fullq.Dequeue());
                    // }

                    Queue<string> q1 = new Queue<string>();
                    Queue<string> q2 = new Queue<string>();

                    string te = null;
                    while (te != ")")
                    {
                        te = fullq.Dequeue();
                        if (te != ")" && te != "(")
                        {
                            q1.Enqueue(te);
                        }
                    }
                    //  Labe:
                    for (int jj = 0; jj < size - 2; jj++)
                    {
                        te = null;
                        while (te != ")")
                        {
                            te = fullq.Dequeue();
                            if (te != ")" && te != "(")
                            {
                                q2.Enqueue(te);
                            }
                        }


                        int x = q1.Count;
                        int y = q2.Count;
                        string g = "+";
                        int h = 0;
                        string gg = "+";
                        for (int a1 = 0; a1 < x; a1++)
                        {
                           
                            string k1 = q1.Dequeue();
                            if (k1.Equals("-") || k1.Equals("+"))
                            {
                                g=k1;
                                h = 1;
                            }
                            if (h != 1)
                            {
                                h = 0;
                                for (int b1 = 0; b1 < y; b1++)
                                {
                                    string k2 = q2.Dequeue();
                                    q2.Enqueue(k2);
                                    if (k2 == "+" || k2 == "-")
                                    {
                                        gg = k2;
                                    }
                                    else
                                    {
                                        if (g.Equals("+") && gg.Equals("+"))
                                        {
                                            q1.Enqueue("+");
                                        }
                                        else if (g.Equals("+") && gg.Equals("-"))
                                        {
                                            q1.Enqueue("-");
                                        }
                                        else if (g.Equals("-") && gg.Equals("+"))
                                        {
                                            q1.Enqueue("-");
                                        }
                                        else if (g.Equals("-") && gg.Equals("-"))
                                        {
                                            q1.Enqueue("+");
                                        }

                                        if (k2 != "+" || k2 != "-")
                                        {
                                            //  if (k1 != "x" && k2 != "x")
                                            //  {
                                            //      int dd = Int32.Parse(k1);
                                            //      int dd1 = Int32.Parse(k2);
                                            //      int dd2 = dd * dd1;
                                            //      string ddd = dd2.ToString();
                                            //      q1.Enqueue(ddd);
                                            //    }
                                            //    else
                                            //    {
                                            q1.Enqueue(k1 + "*" + k2);
                                            //    }
                                        }
                                    }
                                }
                            }
                            h = 0;

                        }

                      
                        int fff1 = q2.Count;
                        for (int d = 0; d < fff1; d++)
                        {
                            q2.Dequeue();

                        }


                    }

                    // goto Labe;
                    // endd:

                    float sum = 1;

                    for (int as2 = 0; as2 < size; as2++)
                    {

                        if (as1 != as2)
                        {
                            sum = sum * (array[as1] - array[as2]);
                        }
                    }
                    int fff = q1.Count;

                    for (int d = 0; d < fff; d++)
                    {
                        string kkk = q1.Dequeue();
                        Console.Write(kkk);
                        final = final + kkk;
                        final1 = final1 + kkk;
                        q1.Enqueue(kkk);
                    }
                    Console.Write(")/" + sum + "\n");

                    final = final + "/" + sum;
                    final1 = final1 + ")/" + sum;
                    total = total + final1;
                    this.L_view.Rows.Add("L"+as1,final);
                    this.yl_view.Rows.Add("Y"+as1+"L" + as1, final1);
                }

                Queue<string> fq = new Queue<string>();
                int  co = total.Length;
                char fcheck = 'q';
                int ffa = 0;
                int gga=0;
                int count = 0;
                string ftotal = null;
                int prev = 1;
                for (int ddd = 0; ddd < size; ddd++)
                {

                    while (fcheck != ')')
                    {
                        fcheck = total[ffa];
                        if (fcheck == '(')
                        {
                            ftotal = ftotal + fcheck;
                            gga = 1;
                        }
                        if (gga == 1)
                        {

                            if (fcheck == '+' || fcheck == '-')
                            {

                                if (count != 0)
                                {
                                    if (prev == 1 && count == 1)
                                    {
                                        ftotal = ftotal + 'x' + fcheck;
                                    }

                                    else if (prev == 1)
                                    {
                                        ftotal = ftotal + 'x' + '^' + count + fcheck;
                                    }
                                    else if (count == 1)
                                    {
                                        ftotal = ftotal + prev + 'x'  + fcheck;
                                    }
                                    else
                                    {

                                        ftotal = ftotal + prev + 'x' + '^' + count + fcheck;
                                    }
                                }
                                else
                                {
                                    ftotal = ftotal + fcheck;
                                }

                                prev = 1;
                                count = 0;
                                // ftotal = ftotal + fcheck;
                            }

                            else if (fcheck == 'x')
                            {

                                count++;

                            }

                            else if (fcheck == '*')
                            {


                            }
                            else
                            {

                                int val = (int)char.GetNumericValue(fcheck);
                              //  Console.WriteLine(val);
                                prev = prev * (val);



                               //  ftotal = ftotal + prev;
                            }

                        }
                        else
                        {
                            ftotal = ftotal + fcheck;
                        }
                        ffa++;
                    }
                //    Console.WriteLine(prev);
                    prev = prev * -1;
                    ftotal = ftotal + prev;
                    ftotal = ftotal + ")";
                    fcheck = 'q';
                    gga = 0;
                }
                while(ffa!= co){
                    ftotal = ftotal + total[ffa];
                    ffa++;
                }
                //fq.Enqueue();
                final12.Text = ftotal.ToString();
                final12.Visible = true;
                label5.Visible = true;
                //end
            }

            else
            {
                float x_val = System.Convert.ToSingle(abc);
                Console.WriteLine(x_val);
                float[] l = new float[size];


                //calculating l
                float sum = 1;
                float sum1 = 1;
                for (int i = 0; i < size; i++)
                {

                    for (int j = 0; j < size; j++)
                    {
                        if (i != j)
                        {
                            // Console.WriteLine(array[i] +"   "+array[j]);
                            sum = sum * (x_val - array[j]);
                            sum1 = sum1 * (array[i] - array[j]);
                        }
                    }
                    //Console.WriteLine(sum + "   " + sum1);
                    l[i] = sum / sum1;
                    sum = 1;
                    sum1 = 1;
                }
                //printing of L
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine(l[i]);

                }

                for (int i = 0; i < size; i++)
                {
                    this.L_view.Rows.Add("L" + i, l[i]);
                }


                //calculating yl 
                float[] yl = new float[size];
                for (int i = 0; i < size; i++)
                {
                    yl[i] = l[i] * array1[i];

                }
                for (int i = 0; i < size; i++)
                {
                    this.yl_view.Rows.Add("YL" + i, yl[i]);
                }
                //calculating answer
                float ans = 0;
                for (int i = 0; i < size; i++)
                {
                    ans = ans + yl[i];

                }
                Console.WriteLine(ans);
                label1.Text = ans.ToString();
                answer.Visible = true;
                label1.Visible = true;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            answer.Parent = pictureBox1;
            answer.BackColor = Color.Transparent;
            label4.Parent = pictureBox1;
           // label4.Parent = pictureBox3;
            label4.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;
            //label4.Parent = pictureBox3;
            label3.BackColor = Color.Transparent;
            final12.Parent = pictureBox1;
           // final12.BackColor = Color.Transparent;
            pictureBox3.Parent = pictureBox1;
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            pictureBox3.BackColor = Color.Transparent;

            L_view.Visible = false;
            yl_view.Visible = false;

            answer.Visible = false;
            label1.Visible = false;
            label5.Visible = false;
            final12.Visible = false;

           // L_view.Parent = pictureBox1;
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void answer_Click(object sender, EventArgs e)
        {

        }

        private void L_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
