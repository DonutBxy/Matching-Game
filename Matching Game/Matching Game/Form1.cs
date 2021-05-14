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

        List<string> iconNames = new List<string>()
        {
            "Bell", "Bell", "Cookie", "Cookie",
            "Deer","Deer","Dog","Dog",
            "Flower","Flower","Night","Night",
            "Strawberry","Strawberry","Strawberry2","Strawberry2"
        };

        List<Image> icons = new List<Image>()
    {
        Properties.Resources.bell, Properties.Resources.bell,
        Properties.Resources.cookie, Properties.Resources.cookie,
        Properties.Resources.deer, Properties.Resources.deer,
        Properties.Resources.dog, Properties.Resources.dog,
        Properties.Resources.flower, Properties.Resources.flower,
        Properties.Resources.night, Properties.Resources.night,
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
                    iconPictureBox.Tag = iconNames[randomNumber];
                    icons.RemoveAt(randomNumber);
                    iconNames.RemoveAt(randomNumber);
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


                if (firstClicked.Tag == secondClicked.Tag)
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
