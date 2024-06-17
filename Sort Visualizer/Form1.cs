using System.Drawing;
using System.Security.Policy;

namespace Sort_Visualizer
{
    public partial class Form1 : Form
    {
        int[] numbers = new int[512];
        Graphics g;
        int numberOfItems;
        int delay;

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
            numberOfItems = 64;
            delay = 50;
            Thread.Sleep(5);
            PrepareScene(64);
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

        int compareTwo(int index1, int index2) //\\ 1 - Index1 büyük //\\ 2 - Index2 büyük //\\ 0 - Diğer //\\
        {
            //Şartlar sağlanıyor mu
            if (numberOfItems <= index1 || numberOfItems <= index2)
                return 0;

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
            if (cbx_algs.Text == "Bubble Sort") bubbleSort();
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
    }
}