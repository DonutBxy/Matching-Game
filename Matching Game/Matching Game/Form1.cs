using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Game
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        PictureBox firstClicked = null;

        PictureBox secondClicked = null;

        List<Image> icons = new List<Image>()
    {
        Properties.Resources.bell, Properties.Resources.bell,
        Properties.Resources.cookie, Properties.Resources.cookie,
        Properties.Resources.deer, Properties.Resources.deer,
        Properties.Resources.dog, Properties.Resources.dog,
        Properties.Resources.flower, Properties.Resources.flower,
        Properties.Resources.fox, Properties.Resources.fox,
        Properties.Resources.strawberry, Properties.Resources.strawberry,
        Properties.Resources.strawberry2, Properties.Resources.strawberry2
    };

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                PictureBox iconPictureBox = control as PictureBox;
                if (iconPictureBox != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconPictureBox.BackgroundImage = icons[randomNumber];
                    iconPictureBox.Image = Properties.Resources.sky;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }

        private void label_click(object sender, EventArgs e)
        {

            if (timer1.Enabled == true)
                return;

            PictureBox clickedPictureBox = sender as PictureBox;

            if (clickedPictureBox != null)
            {
                if (clickedPictureBox.Image == clickedPictureBox.BackgroundImage)
                return;

                if (firstClicked == null)
                {
                    firstClicked = clickedPictureBox;
                    clickedPictureBox.Image = clickedPictureBox.BackgroundImage;

                    return;
                }

                secondClicked = clickedPictureBox;
                secondClicked.Image = clickedPictureBox.BackgroundImage;

                if (firstClicked.Image == secondClicked.Image)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.Image = Properties.Resources.sky;
            secondClicked.Image = Properties.Resources.sky;

            firstClicked = null;
            secondClicked = null;
        }
    }
}
