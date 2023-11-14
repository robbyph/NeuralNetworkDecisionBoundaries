using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace NeuralNetworkFromScratch
{
    public partial class Form1 : Form
    {
        const string X_AXIS_LABEL = "Spot Size";
        const string Y_AXIS_LABEL = "Spike Length";
        const int GRAPH_X_OFFSET = 50;
        const int GRAPH_Y_OFFSET = 20;
        const int GRAPH_X_LABEL_OFFSET = 30;
        const int GRAPH_Y_LABEL_OFFSET = 20;
        float GRAPH_X_SCALING_FACTOR;
        float GRAPH_Y_SCALING_FACTOR;
        Fruit[] graphData;
        int MouseMode = 0;
        Point startPoint = Point.Empty;
        Point endPoint = Point.Empty;
        Pen pen = new Pen(Color.Black, 3);
        bool drawingInProgress = false;

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void graphDisplay_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            Font myFont = new Font("Arial", 13);

            //change background color to white
            graphics.Clear(Color.White);

            //draw a border around the entire picture box
            graphics.DrawRectangle(Pens.Black, 0, 0, graphDisplay.Width - 1, graphDisplay.Height - 1);

            //Draw the label for the X axis
            graphics.DrawString(X_AXIS_LABEL, myFont, Brushes.Black, new PointF((graphDisplay.Width - GRAPH_X_OFFSET) / 2, graphDisplay.Height - GRAPH_X_LABEL_OFFSET));

            //Draw the label for the Y axis, rotated 90 degrees counter-clockwise (270 degrees clockwise)
            graphics.TranslateTransform(GRAPH_Y_LABEL_OFFSET, (graphDisplay.Height - GRAPH_X_OFFSET) / 2);
            graphics.RotateTransform(270);
            graphics.DrawString(Y_AXIS_LABEL, myFont, Brushes.Black, new PointF(0, 0));
            graphics.ResetTransform();

            //Draw the X axis, leaving room for the label
            graphics.DrawLine(Pens.Black, 0, graphDisplay.Height - GRAPH_X_OFFSET, graphDisplay.Width, graphDisplay.Height - GRAPH_X_OFFSET);

            //Draw the Y axis, leaving room for the label
            graphics.DrawLine(Pens.Black, GRAPH_X_OFFSET, graphDisplay.Height, GRAPH_X_OFFSET, 0);

            //set the origin to the bottom left of the graph
            graphics.TranslateTransform(GRAPH_X_OFFSET, graphDisplay.Height - GRAPH_X_OFFSET);

            //set the positive domain to the right of the origin and the positive range above the origin
            graphics.ScaleTransform(1, -1);

            //draw the X axis tick marks (0 - 100), scaled to the full width of the picture box, taking into account the offsets
            var XtickInterval = (graphDisplay.Width - GRAPH_X_OFFSET) / 10;

            for (int i = 0; i <= 10; i++)
            {
                graphics.DrawLine(Pens.Black, i * XtickInterval, 0, i * XtickInterval, 10);
            }

            //draw the Y axis tick marks (0 - 100), scaled to the full height of the picture box, taking into account the offsets
            var YtickInterval = (graphDisplay.Height - GRAPH_X_OFFSET - GRAPH_Y_OFFSET) / 10;

            for (int i = 0; i <= 10; i++)
            {
                graphics.DrawLine(Pens.Black, 0, i * YtickInterval, 10, i * YtickInterval);
            }

            int j = 1;

            //Draw the data points
            foreach (Fruit fruit in graphData)
            {
                //get the X and Y coordinates
                float x = (int)(fruit.SpotSize);
                float y = (int)(fruit.SpikeLength);

                //Scale the X and Y coordinates, which are 0 to 100, to the size of the picture box
                x *= GRAPH_X_SCALING_FACTOR;
                y *= GRAPH_Y_SCALING_FACTOR;

                //MessageBox.Show(Text = "Fruit coordinates: " + x + " " + y);

                //get the color
                Color color = (fruit.IsSafe == 0) ? Color.Red : Color.Green;

                //draw the point
                graphics.FillEllipse(new SolidBrush(color), x, y, 10, 10);

                j++;
            }

            if (MouseMode == 0 && startPoint != Point.Empty && endPoint != Point.Empty)
            {
                //Draw the line
                graphics.DrawLine(pen, startPoint, endPoint);
                drawingInProgress = true;
            }
        }

        private void graphDisplay_Click(object sender, EventArgs e)
        {
            if (MouseMode == 1)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coordinates = me.Location;

                //properly scale the coordinates to the graph, the same way we did when drawing the graph
                coordinates.X -= GRAPH_X_OFFSET;
                coordinates.Y = graphDisplay.Height - coordinates.Y - GRAPH_X_OFFSET;

                foreach (Fruit fruit in graphData)
                {
                    //get the X and Y coordinates
                    float x = (int)(fruit.SpotSize);
                    float y = (int)(fruit.SpikeLength);

                    //Scale the X and Y coordinates, which are 0 to 100, to the size of the picture box
                    x *= GRAPH_X_SCALING_FACTOR;
                    y *= GRAPH_Y_SCALING_FACTOR;

                    //MessageBox.Show("Fruit coordinates: " +  x + " " + y);
                    //MessageBox.Show(Text = "Clicked point: " + coordinates.X + " " + coordinates.Y);

                    //check if the point is clicked
                    if (coordinates.X + 6 >= x && coordinates.X - 6 <= x && coordinates.Y + 6 >= y && coordinates.Y - 6 <= y)
                    {
                        //toggle the safety parameter
                        fruit.IsSafe = (fruit.IsSafe == 0) ? 1 : 0;

                        //update the xml data
                        XmlDocument doc = new XmlDocument();
                        doc.Load("../../../AlienFruit.xml");

                        //get the root node
                        XmlNode rootNode = doc.DocumentElement;

                        //get the list of fruit nodes
                        XmlNodeList fruitNodes = rootNode.SelectNodes("fruit");

                        //loop through the fruit nodes
                        foreach (XmlNode fruitNode in fruitNodes)
                        {
                            //get the spot size and spike length
                            double spotSize = double.Parse(fruitNode.SelectSingleNode("spotSize").InnerText);
                            double spikeLength = double.Parse(fruitNode.SelectSingleNode("spikeLength").InnerText);

                            //check if the current fruit node matches the clicked point
                            if (spotSize == fruit.SpotSize && spikeLength == fruit.SpikeLength)
                            {
                                //update the safety parameter
                                fruitNode.SelectSingleNode("safety").InnerText = fruit.IsSafe.ToString();
                                break;
                            }
                        }

                        //save the xml file
                        doc.Save("../../../AlienFruit.xml");

                        //redraw the graph
                        graphDisplay.Invalidate();
                        break;
                    }
                }
            }
        }

        //gets the data from the XML file and returns an array of Fruit objects
        private Fruit[] getGraphData()
        {
            //create an array of Fruit objects
            Fruit[] graphData = new Fruit[108];

            //read the AlienFruit.xml file
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../AlienFruit.xml");

            //get the root node
            XmlNode rootNode = doc.DocumentElement;

            //get the list of fruit nodes
            XmlNodeList fruitNodes = rootNode.SelectNodes("fruit");

            //loop through the fruit nodes
            int i = 0;
            foreach (XmlNode fruitNode in fruitNodes)
            {
                //get the spot size and spike length
                double spotSize = double.Parse(fruitNode.SelectSingleNode("spotSize").InnerText);
                double spikeLength = double.Parse(fruitNode.SelectSingleNode("spikeLength").InnerText);

                //get the safety
                int safety = int.Parse(fruitNode.SelectSingleNode("safety").InnerText);

                //create a new Fruit object
                Fruit fruit = new Fruit(safety, spotSize, spikeLength);

                //add the fruit to the array
                graphData[i] = fruit;

                //increment the counter
                i++;
            }

            return graphData;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GRAPH_X_SCALING_FACTOR = (graphDisplay.Width - GRAPH_X_OFFSET) / 100;
            GRAPH_Y_SCALING_FACTOR = (graphDisplay.Height - GRAPH_Y_OFFSET) / 100;
            graphData = getGraphData();
        }

        private void graphDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && MouseMode == 1)
            {
                //get the coordinates of the click
                Point coordinates = e.Location;

                //properly scale the coordinates to the graph, the same way we did when drawing the graph
                coordinates.X -= GRAPH_X_OFFSET;
                coordinates.Y = graphDisplay.Height - coordinates.Y - GRAPH_X_OFFSET;

                //create a new fruit object with the clicked coordinates and a default safety value of 0
                Fruit newFruit = new Fruit(0, coordinates.X / GRAPH_X_SCALING_FACTOR, coordinates.Y / GRAPH_Y_SCALING_FACTOR);

                //add the new fruit to the xml file
                XmlDocument doc = new XmlDocument();
                doc.Load("../../../AlienFruit.xml");

                //get the root node
                XmlNode rootNode = doc.DocumentElement;

                //create a new fruit node
                XmlNode newFruitNode = doc.CreateElement("fruit");

                //create the spot size node
                XmlNode spotSizeNode = doc.CreateElement("spotSize");
                spotSizeNode.InnerText = newFruit.SpotSize.ToString();
                newFruitNode.AppendChild(spotSizeNode);

                //create the spike length node
                XmlNode spikeLengthNode = doc.CreateElement("spikeLength");
                spikeLengthNode.InnerText = newFruit.SpikeLength.ToString();
                newFruitNode.AppendChild(spikeLengthNode);

                //create the safety node
                XmlNode safetyNode = doc.CreateElement("safety");
                safetyNode.InnerText = newFruit.IsSafe.ToString();
                newFruitNode.AppendChild(safetyNode);

                //add the new fruit node to the root node
                rootNode.AppendChild(newFruitNode);

                //save the xml file
                doc.Save("../../../AlienFruit.xml");

                //add the new fruit to the graph data array and redraw the graph
                Array.Resize(ref graphData, graphData.Length + 1);
                graphData[graphData.Length - 1] = newFruit;
                graphDisplay.Invalidate();
            }
            else if (MouseMode == 0)
            {
                //Start drawing a line, with the starting point being appropriately scaled and taking into account the offsets
                startPoint = e.Location;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1 is Mouse Mode, 0 is Boundary Mode
            if (MouseMode == 0)
            {
                MouseMode = 1;
                button1.Text = "Mouse Mode";
            }
            else if (MouseMode == 1)
            {
                MouseMode = 0;
                button1.Text = "Boundary Mode";
            }
        }

        private void graphDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseMode == 0 && startPoint != Point.Empty)
            {
                //End drawing a line
                endPoint = e.Location;

                //Draw the line
                Graphics g = graphDisplay.CreateGraphics();
                g.DrawLine(pen, startPoint, endPoint);

                //Reset the start and end points
                startPoint = Point.Empty;
                endPoint = Point.Empty;
            }
        }

        private void graphDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingInProgress)
            {
                graphDisplay.CreateGraphics().Clear(Color.White);
                graphDisplay.Invalidate();

                //Redraw the line
                endPoint = e.Location;
            }
        }
    }
}