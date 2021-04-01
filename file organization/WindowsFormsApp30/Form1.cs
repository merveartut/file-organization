using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp30
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] array1;
        int[] array2;
        int[] array6;
        int[] array4;                        //MERVE ARTUT  171180006
        int[] array5;
        int[] array7;
        string[] link;
        Random random;


        private void button1_Click(object sender, EventArgs e)
        {

            random = new Random();
            listBox1.Items.Clear();
            int x = Convert.ToInt32(textBox1.Text);
            int mod = ((10 * x) / 9) + 1;
            array2 = new int[((10 * x) / 9) + 1];
            link = new string[((10 * x) / 9) + 1];
            for (int a = 0; a < mod; a++)
            {
                array2[a] = -1;
                link[a] = "yok";
            }
            if (x > 900)
                MessageBox.Show("900 den küçük bir değer giriniz!");
            else
                array1 = new int[x];






            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = random.Next(900);

            }


            for (int j = 0; j < array1.Length; j++)
            {

                listBox1.Items.Add(j.ToString() + "-" + array1[j].ToString());



            }
           






        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }




        public void lich(int[] array, string[] link, int mod)
        {

            int x = Convert.ToInt32(textBox1.Text);
            int w = ((10 * x) / 9);


            for (int k = 0; k < x; k++)
            {
                if ((array[array1[k] % Convert.ToInt32(mod * 85 / 100)]) == -1)        //hashten çıkan adres boşsa oraya yerleştir
                {
                    array[array1[k] % Convert.ToInt32(mod * 85 / 100)] = array1[k];
                }
                else
                {                                                                   //ilk hesaplanan adres boş değilse dizinin 
                                                                                     //en altından başlayarak boş yer ara



                    if (array[w] == -1)                                     
                    {

                        array[w] = array1[k];
                        link[array1[k] % Convert.ToInt32(mod * 85 / 100)] = w.ToString();

                    }
                    else
                    {
                        while (array[w] != -1 && w >= 0)
                        {
                            w = w - 1;
                        }
                        array[w] = array1[k];
                        if (link[(array1[k] % Convert.ToInt32(mod * 85 / 100))] == "yok")
                        {
                            link[(array1[k] % Convert.ToInt32(mod * 85 / 100))] = w.ToString();
                        }
                        else if (link[(array1[k] % Convert.ToInt32(mod * 85 / 100))] != "yok" && link[Convert.ToInt32(link[(array1[k] % Convert.ToInt32(mod * 85 / 100))])] == "yok")

                            link[Convert.ToInt32(link[(array1[k] % Convert.ToInt32(mod * 85 / 100))])] = w.ToString();

                        else

                            link[Convert.ToInt32(link[Convert.ToInt32(link[(array1[k] % Convert.ToInt32(mod * 85 / 100))])])] = w.ToString();


                    }
                }







            }









        }




        private void button2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);

            int mod = ((10 * x) / 9) + 1;

            array4 = new int[mod];
            for (int a = 0; a < mod; a++)
            {
                array4[a] = -1;
                link[a] = "yok";
            }
            lich(array4, link, mod);
            for (int c = 0; c < array4.Length * 85 / 100; c++)  // %15 lik kısım overflow area için ayrıldı
                listBox3.Items.Add(c.ToString() + "- " + array4[c].ToString() + "   link:" + link[c]);

            listBox3.Items.Add("------------------------------------------");
            for (int d = (array4.Length * 85) / 100; d < array4.Length; d++)
            {
                listBox3.Items.Add(d.ToString() + "- " + array4[d].ToString());
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        public void eisch(int[] array, string[] link, int mod)
        {
            int x = Convert.ToInt32(textBox1.Text);



            for (int a = 0; a < mod; a++)
            {
                array[a] = -1;
                link[a] = "yok";
            }

            int w = mod - 1;

            for (int k = 0; k < x; k++)
            {
                if ((array[array1[k] % mod]) == -1)
                {
                    array[array1[k] % mod] = array1[k];
                }
                else
                {



                    if (array[w] == -1) //en sondaki yer boşsa
                    {
                        if (link[array1[k] % mod] == "yok")//ilk bulunan yer dolu ama linki boşsa
                        {
                            link[array1[k] % mod] = w.ToString();
                            array[w] = array1[k];
                        }

                    }
                    else  // en son boş değilse
                    {
                        while (array[w] != -1 && w >= 0)
                        {
                            w = w - 1;
                        }

                        array[w] = array1[k];
                        if (link[array1[k] % mod] == "yok")
                            link[array1[k] % mod] = w.ToString();
                        else if (link[array1[k] % mod] != "yok")
                        {
                            link[w] = link[array1[k] % mod];
                            link[array1[k] % mod] = w.ToString();
                        }








                    }
                }


             }

        }



        private void button3_Click(object sender, EventArgs e)
        {

            int x = Convert.ToInt32(textBox1.Text);
            int mod = ((10 * x) / 9) + 1;
            array5 = new int[((10 * x) / 9) + 1];
            link = new string[((10 * x) / 9) + 1];
            for (int a = 0; a < mod; a++)
            {
                array5[a] = -1;
                link[a] = "yok";
            }





            eisch(array5, link, mod);
            for (int c = 0; c < array5.Length; c++)
                listBox4.Items.Add(c.ToString() + "- " + array5[c].ToString() + "   link:" + link[c]);


        }


        public void reisch(int[] array, string[] link, int mod)
        {

            int x = Convert.ToInt32(textBox1.Text);


            int w = mod - 1;

            for (int k = 0; k < x; k++)
            {
                if ((array[array1[k] % mod]) == -1)
                {
                    array[array1[k] % mod] = array1[k];
                }
                else
                {

                    random = new Random();
                    w = random.Next(mod);
                    if (array[w] == -1)
                    {
                        if (link[array1[k] % mod] == "yok")//ilk bulunan yer dolu ama linki boşsa
                        {
                            link[array1[k] % mod] = w.ToString();
                            array[w] = array1[k];
                        }

                    }
                    else
                    {
                        while (array[w] != -1 && w >= 0)
                        {
                            w = random.Next(mod);
                        }

                        array[w] = array1[k];
                        link[(array1[k] % mod)] = w.ToString();

                    }
                }







            }


  }

        private void button5_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            int mod = ((10 * x) / 9) + 1;
            array6 = new int[((10 * x) / 9) + 1];
            link = new string[((10 * x) / 9) + 1];
            for (int a = 0; a < mod; a++)
            {
                array6[a] = -1;
                link[a] = "yok";
            }

            reisch(array6, link, mod);

            for (int c = 0; c < array6.Length; c++)
                listBox6.Items.Add(c.ToString() + "- " + array6[c].ToString() + "   link:" + link[c]);




        }


        public void blisch(int[] array, string[] link, int mod)
        {

            int x = Convert.ToInt32(textBox1.Text);

            int w = mod - 1;
            int z = 0;

            for (int k = 0; k < x; k++)
            {
                if ((array[array1[k] % mod]) == -1)
                {
                    array[array1[k] % mod] = array1[k];
                }
                else
                {



                    if (array[w] == -1 && link[array1[k] % mod] == "yok") //en sondaki yer boşsa
                    {

                        array[w] = array1[k];
                        link[array1[k] % mod] = w.ToString();
                    }
                    else if (array[z] == -1 && link[array1[k] % mod] == "yok") //en baştaki yer boşsa
                    {
                        array[z] = array1[k];
                        link[array1[k] % mod] = z.ToString();
                    }






                    else
                    {
                        while (array[w] != -1 && array[z] != -1)  //en son ve en baş boş değilse sırayla bir alta bir üste bak

                        {
                            if (array[w] != -1)
                            {
                                w = w - 1;
                            }
                            else if (array[z] != -1)
                            {
                                z = z + 1;
                            }


                        }

                        if (array[w] == -1)
                        {
                            array[w] = array1[k];
                            if (link[(array1[k] % mod)] == "yok")
                            {
                                link[(array1[k] % mod)] = w.ToString();
                            }

                            else if (link[(array1[k] % mod)] != "yok" && link[Convert.ToInt32(link[(array1[k] % mod)])] == "yok")

                                link[Convert.ToInt32(link[(array1[k] % mod)])] = w.ToString();

                            else

                                link[Convert.ToInt32(link[Convert.ToInt32(link[(array1[k] % mod)])])] = w.ToString();
                        }
                        else if (array[z] == -1)
                        {
                            array[z] = array1[k];
                            if (link[(array1[k] % mod)] == "yok")
                            {
                                link[(array1[k] % mod)] = z.ToString();
                            }
                            else if (link[(array1[k] % mod)] != "yok" && link[Convert.ToInt32(link[(array1[k] % mod)])] == "yok")

                                link[Convert.ToInt32(link[(array1[k] % mod)])] = z.ToString();

                            else

                                link[Convert.ToInt32(link[Convert.ToInt32(link[(array1[k] % mod)])])] = z.ToString();





                        }


                    }



                }







            }





        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            int mod = ((10 * x) / 9) + 1;
            array7 = new int[((10 * x) / 9) + 1];
            link = new string[((10 * x) / 9) + 1];
            for (int a = 0; a < mod; a++)
            {
                array7[a] = -1;
                link[a] = "yok";
            }



            blisch(array7, link, mod);

            for (int c = 0; c < array7.Length; c++)
                listBox5.Items.Add(c.ToString() + "- " + array7[c].ToString() + "   link:" + link[c]);
        }

        public void lich_ara(int[] array, string[] link, int aranan, int mod)
        {

            int m = aranan % Convert.ToInt32(mod * 85 / 100);
            if (array[aranan % Convert.ToInt32(mod * 85 / 100)] == aranan)
            {
                label14.Text = ("aranan sayı 1 \n  probe da bulundu");        //ilk bulunan adrese bak 
            }
            else if (array[aranan % Convert.ToInt32(mod * 85 / 100)] != aranan && link[aranan % Convert.ToInt32(mod * 85 / 100)] == "yok")
            {
                label14.Text = ("bulunamadı!");
            }

            else if (link[m] != "yok")
            {
                if (array[Convert.ToInt32(link[m])] == aranan)
                    label14.Text = ("aranan sayı 2 \n probe da bulundu"); //ilk bulunan adresin linkinin gösterdiği adrese bak

                else if (array[Convert.ToInt32(link[m])] != aranan && link[Convert.ToInt32(link[m])] == "yok")
                    label14.Text = ("bulunamadı!");

                else if (array[Convert.ToInt32(link[Convert.ToInt32(link[m])])] == aranan)
                                                                             //ilk bulunan adresin linkinin gösterdiği adresin linkinin gösterdiği adrese bak
                    label14.Text = ("aranan sayı 3 \n probe da bulundu");
                else if (array[Convert.ToInt32(link[Convert.ToInt32(link[m])])] != aranan && link[Convert.ToInt32(link[Convert.ToInt32(link[m])])] == "yok")
                    label14.Text = ("bulunamadı!");


                else if (array[Convert.ToInt32(link[Convert.ToInt32(link[Convert.ToInt32(link[m])])])] == aranan)

                    label14.Text = ("aranan sayı 4 \n probe da bulundu");

                else
                    label14.Text = ("bulunamadı!");



            }





        }





        public void blisch_ara(int[] array, string[] link, int aranan, int mod)
        {


            int m = aranan % mod;
            if (array[aranan % mod] == aranan)
            {
                label10.Text = ("aranan sayı 1 \n probe da bulundu");
            }
            else if (array[aranan % mod] != aranan && link[aranan % mod] == "yok")
            {
                label10.Text = ("bulunamadı!");
            }

            else if (link[aranan % mod] != "yok")
            {
                if (array[Convert.ToInt32(link[aranan % mod])] == aranan)
                    label10.Text = ("aranan sayı 2 \n probe da bulundu");

                else if (array[Convert.ToInt32(link[aranan % mod])] != aranan && link[Convert.ToInt32(link[aranan % mod])] == "yok")
                    label10.Text = ("bulunamadı!");

                else if (array[Convert.ToInt32(link[Convert.ToInt32(link[aranan % mod])])] == aranan)

                    label10.Text = ("aranan sayı 3 \n probe da bulundu");
                else if (array[Convert.ToInt32(link[Convert.ToInt32(link[aranan % mod])])] != aranan && link[Convert.ToInt32(link[Convert.ToInt32(link[m])])] == "yok")
                    label10.Text = ("bulunamadı!");


                else if (array[Convert.ToInt32(link[Convert.ToInt32(link[Convert.ToInt32(link[m])])])] == aranan)

                    label10.Text = ("aranan sayı 4 \n probe da bulundu");

                else
                    label10.Text = ("bulunamadı!");



            }





        }


        public void eisch_ara(int[] array, string[] link, int aranan, int mod)
        {


            int m = aranan % mod;
            if (array[aranan % mod] == aranan)
            {
                label7.Text = ("aranan sayı 1 \n probe da bulundu");
            }
            else if (array[aranan % mod] != aranan && link[aranan % mod] == "yok")
            {
                label7.Text = ("bulunamadı!");
            }

            else if (link[aranan % mod] != "yok")
            {
                if (array[Convert.ToInt32(link[aranan % mod])] == aranan)
                    label7.Text = ("aranan sayı 2 \n probe da bulundu");

                else if (array[Convert.ToInt32(link[aranan % mod])] != aranan && link[Convert.ToInt32(link[aranan % mod])] == "yok")
                    label7.Text = ("bulunamadı!");

                else if (array[Convert.ToInt32(link[Convert.ToInt32(link[aranan % mod])])] == aranan)

                    label7.Text = ("aranan sayı 3 \n probe da bulundu");
                else if (array[Convert.ToInt32(link[Convert.ToInt32(link[aranan % mod])])] != aranan && link[Convert.ToInt32(link[Convert.ToInt32(link[m])])] == "yok")
                    label7.Text = ("bulunamadı!");


                else if (array[Convert.ToInt32(link[Convert.ToInt32(link[Convert.ToInt32(link[m])])])] == aranan)

                    label7.Text = ("aranan sayı 4 \n probe da bulundu");

                else
                    label7.Text = ("bulunamadı!");



            }



        }

        public void reisch_ara(int[] array, string[] link, int aranan, int mod)
        {
            int m = aranan % mod;
            if (array[aranan % mod] == aranan)
            {
                label15.Text = ("aranan sayı 1 \n probe da bulundu");
            }
            else if (array[aranan % mod] != aranan && link[aranan % mod] == "yok")
            {
                label15.Text = ("bulunamadı!");
            }

            else if (link[aranan % mod] != "yok")
            {
                if (array[Convert.ToInt32(link[aranan % mod])] == aranan)
                    label15.Text = ("aranan sayı 2 \n probe da bulundu");

                else if (array[Convert.ToInt32(link[aranan % mod])] != aranan && link[Convert.ToInt32(link[aranan % mod])] == "yok")
                    label15.Text = ("bulunamadı!");

                else if (array[Convert.ToInt32(link[Convert.ToInt32(link[aranan % mod])])] == aranan)

                    label15.Text = ("aranan sayı 3 \n probe da bulundu");
                else if (array[Convert.ToInt32(link[Convert.ToInt32(link[aranan % mod])])] != aranan && link[Convert.ToInt32(link[Convert.ToInt32(link[m])])] == "yok")
                    label15.Text = ("bulunamadı!");


                else if (array[Convert.ToInt32(link[Convert.ToInt32(link[Convert.ToInt32(link[m])])])] == aranan)

                    label15.Text = ("aranan sayı 4 \n probe da bulundu");

                else
                    label15.Text = ("bulunamadı!");



            }
        }






        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            int mod = ((10 * x) / 9) + 1;
            array7 = new int[((10 * x) / 9) + 1];
            link = new string[((10 * x) / 9) + 1];
            for (int a = 0; a < mod; a++)
            {
                array7[a] = -1;
                link[a] = "yok";
            }
            blisch(array7, link, mod);
            array5 = new int[((10 * x) / 9) + 1];
            for (int a = 0; a < mod; a++)
            {
                array5[a] = -1;
            }

            eisch(array5, link, mod);

            array4 = new int[mod];
            for (int a = 0; a < mod; a++)
            {
                array4[a] = -1;
            }
                lich(array4, link, mod);


            array6 = new int[((10 * x) / 9) + 1];
          
            for (int a = 0; a < mod; a++)
            {
                array6[a] = -1;
                
            }

            reisch(array6, link, mod);

            int aranan = Convert.ToInt32(textBox2.Text);
            label14.Visible = true;
            label7.Visible = true;
            label10.Visible = true;
            label15.Visible = true;

                lich_ara(array4, link,aranan, mod);
                blisch_ara(array7, link, aranan, mod);
                eisch_ara(array5, link, aranan, mod);
            reisch_ara(array6, link, aranan, mod);

            
        }
    }
}


