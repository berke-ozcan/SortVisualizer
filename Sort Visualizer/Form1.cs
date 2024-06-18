using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace Sort_Visualizer
{
    public partial class Form1 : Form
    {
        int[] numbers = new int[512];
        Graphics g;
        int numberOfItems;
        int delay;
        int comparisons;
        int swaps;
        int rewrites;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            resetNumbers(numberOfItems);
            PrepareScene(numberOfItems);
        }

        void PrepareScene(int size)
        {
            //Arka Plan
            g = this.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, 1101, 1100));

            //Sayıları göster
            FillNumbers(size);
        }

        void resetNumbers(int size)
        {
            for (int i = 0; i < size; i++)
            {
                numbers[i] = i + 1;
            }
        }

        void FillNumbers(int size)
        {
            for (int n = 0; n < size; n++)
            {
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(39 + (n * 1024 / size) + 256 / size, 1100 - (numbers[n] * 1024 / size) - 38, 512 / size, numbers[n] * 1024 / size));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numberOfItems = 32;
            delay = 20;
            PrepareScene(64);
            comparisons = 0;
            swaps = 0;
            rewrites = 0;
        }

        private void btn_numberOfItems_Click(object sender, EventArgs e)
        {
            numberOfItems = Int32.Parse(cbx_noi.Text);
            resetNumbers(numberOfItems);
            PrepareScene(numberOfItems);
        }

        void swapTwo(int index1, int index2)
        {
            //Şartlar sağlanıyor mu
            if (numberOfItems <= index1 || numberOfItems <= index2)
                return;

            //Highlight (ve ses, eklenecek)
            g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(39 + (index1 * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[index1] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[index1] * 1024 / numberOfItems));
            g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(39 + (index2 * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[index2] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[index2] * 1024 / numberOfItems));

            //Delay
            Thread.Sleep(delay);
            swaps++;
            lb_swaps.Text = "Swaps: " + swaps.ToString();
            lb_swaps.Refresh();
            
            //Delete the highlights
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(39 + (index1 * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[index1] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[index1] * 1024 / numberOfItems));
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(39 + (index2 * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[index2] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[index2] * 1024 / numberOfItems));

            //Swap
            int temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;

            //Refill the rectangles
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(39 + (index1 * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[index1] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[index1] * 1024 / numberOfItems));
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(39 + (index2 * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[index2] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[index2] * 1024 / numberOfItems));
        }

        void rewriteTwo(int source, int dest)
        {   
            //Şartlar sağlanıyor mu
            if (numberOfItems <= source || numberOfItems <= dest)
                return;

            //Highlight (ve ses, eklenecek)
            g.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(39 + (source * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[source] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[source] * 1024 / numberOfItems));
            g.FillRectangle(new SolidBrush(Color.LightBlue), new Rectangle(39 + (dest * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[dest] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[dest] * 1024 / numberOfItems));

            //Delay
            Thread.Sleep(delay);
            rewrites++;
            lb_rewrite.Text = "Rewrites: " + rewrites.ToString();
            lb_rewrite.Refresh();

            //Delete the highlights
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(39 + (source * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[source] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[source] * 1024 / numberOfItems));
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(39 + (dest * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[dest] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[dest] * 1024 / numberOfItems));

            //Rewrite
            numbers[dest] = numbers[source];

            //Refill
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(39 + (source * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[source] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[source] * 1024 / numberOfItems));
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(39 + (dest * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[dest] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[dest] * 1024 / numberOfItems));
        }

        void rewriteOne(int index, int value)
        {
            //Şartlar sağlanıyor mu
            if (numberOfItems <= index)
                return;

            //Highlight (ve ses, eklenecek)
            g.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(39 + (index * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[index] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[index] * 1024 / numberOfItems));

            //Delay
            Thread.Sleep(delay);
            rewrites++;
            lb_rewrite.Text = "Rewrites: " + rewrites.ToString();
            lb_rewrite.Refresh();

            //Delete Highlights
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(39 + (index * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[index] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[index] * 1024 / numberOfItems));

            //Rewrite
            numbers[index] = value;

            //Refill
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(39 + (index * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[index] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[index] * 1024 / numberOfItems));

        }

        int compareTwo(int index1, int index2) //\\ 1 - Index1 büyük //\\ 2 - Index2 büyük //\\ 0 - Diğer //\\
        {
            //Şartlar sağlanıyor mu
            if (numberOfItems <= index1 || numberOfItems <= index2)
                return 0;
            
            comparisons++;
            lb_comps.Text = "Comparisons: " + comparisons.ToString();
            lb_comps.Refresh();

            //Highlight (ve ses, eklenecek)
            g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(39 + (index1 * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[index1] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[index1] * 1024 / numberOfItems));
            g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(39 + (index2 * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[index2] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[index2] * 1024 / numberOfItems));

            //Delay
            Thread.Sleep(delay);
            
            //Delete green highlights
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(39 + (index1 * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[index1] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[index1] * 1024 / numberOfItems));
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(39 + (index2 * 1024 / numberOfItems) + 256 / numberOfItems, 1100 - (numbers[index2] * 1024 / numberOfItems) - 38, 512 / numberOfItems, numbers[index2] * 1024 / numberOfItems));
            
            //Comparison
            if (numbers[index1] > numbers[index2]) return 1;
            return 2;
        }

        private void btn_delayChange_Click(object sender, EventArgs e)
        {
            delay = Int32.Parse(cbx_delay.Text);
        }

        private void btn_Sort_Click(object sender, EventArgs e)
        {
            comparisons = 0;
            swaps = 0;
            rewrites = 0;

            lb_comps.Text = "Comparisons: 0";
            lb_swaps.Text = "Swaps: 0";
            lb_rewrite.Text = "Rewrites: 0";
            lb_comps.Refresh();
            lb_swaps.Refresh();
            lb_rewrite.Refresh();

            if (cbx_algs.Text == "Bubble Sort") bubbleSort();
            else if (cbx_algs.Text == "Selection Sort") selectionSort();
            else if (cbx_algs.Text == "Insertion Sort") insertionSort();
        }

        void bubbleSort()
        {
            int i, j;
            bool swapped;
            for (i = 0; i < numberOfItems - 1; i++)
            {
                swapped = false;
                for (j = 0; j < numberOfItems - i - 1; j++)
                {
                    if (compareTwo(j, j + 1) == 1)
                    {
                        swapTwo(j, j + 1);
                        swapped = true;
                    }
                }

                if (swapped == false)
                    break;
            }
        }

        private void btn_rng_Click(object sender, EventArgs e)
        {
            comparisons = 0;
            swaps = 0;
            rewrites = 0;

            lb_comps.Text = "Comparisons: 0";
            lb_swaps.Text = "Swaps: 0";
            lb_rewrite.Text = "Rewrites: 0";
            lb_comps.Refresh();
            lb_swaps.Refresh();
            lb_rewrite.Refresh();

            Random random = new Random();
            int temp = delay;
            delay = 5;
            for (int i = 0; i <= numberOfItems*2; i++)
            {
                int r1 = random.Next(0,numberOfItems-1);
                int r2 = random.Next(0,numberOfItems-1);
                if (r1 != r2)
                {
                    swapTwo(r1, r2);
                }
            }
            delay = temp;
        }

        void selectionSort()
        {
            for (int i = 0; i < numberOfItems - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < numberOfItems; j++)
                    if (compareTwo(j, min_idx) == 2)
                        min_idx = j;

                swapTwo(min_idx, i);
            }
        }

        void insertionSort()
        {
            for (int i = 1; i < numberOfItems; ++i)
            {
                int key = numbers[i];
                int j = i - 1;

                while (j >= 0 && numbers[j] > key)
                {
                    rewriteTwo(j, j + 1);
                    j = j - 1;
                }
                rewriteOne(j + 1, key);
            }
        }

    }
}