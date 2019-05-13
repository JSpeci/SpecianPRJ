using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Gui
{
    public class SchemeDrawHelper
    {
        public struct MyRectangle
        {
            public int x;
            public int y;
            public int sizeX;
            public int sizeY;
        }

        public struct MyLine
        {
            public int x1;
            public int y1;
            public int x2;
            public int y2;
            public int width;
        }

        public struct MyText
        {
            public int x;
            public int y;
            public string text;
            public int size;
        }

        public class RectanglesAndLines
        {
            public List<MyRectangle> Rectangles;
            public List<MyLine> Lines;
            public List<MyText> Texts;

            public RectanglesAndLines()
            {
                Lines = new List<MyLine>();
                Rectangles = new List<MyRectangle>();
                Texts = new List<MyText>();
            }
        }

        public RectanglesAndLines DrawImageByScheme(Scheme.SchemeHolder scheme, int xOffset = 0, int yOffset = 0)
        {
            RectanglesAndLines result = new RectanglesAndLines();
            int x = 0;
            int y = 0;
            int xSize = 70;
            int ySize = 40;
            int space = 40;
            int lineWidth = 2;

            //input line
            xOffset += 15;
            result.Lines.Add(new MyLine()
            {
                width = lineWidth,
                x1 = xOffset + 80,
                y1 = yOffset + ySize/2,
                x2 = xOffset + 100,
                y2 = yOffset + ySize/2,
            });

            result.Texts.Add(new MyText()
            {
                x = xOffset + 80,
                y = yOffset ,
                text = "In",
                size = 13,
            });

            foreach (var b in scheme.Blocks)
            {
                x++;
                y = 0;
                foreach (var i in b.ParalelItems)
                {
                    result.Rectangles.Add(new MyRectangle()
                    {
                        x = xOffset + ((x * xSize) + x * space),
                        y = yOffset + (y * ySize) + y * space,
                        sizeX = xSize,
                        sizeY = ySize
                    });
                    result.Texts.Add(new MyText()
                    {
                        x = xOffset + ((x * xSize) + x * space) +5,
                        y = yOffset + (y * ySize) + y * space +5,
                        text = i.NumberId.ToString() + ": " + i.Name,
                        size = 8,
                    });

                    result.Texts.Add(new MyText()
                    {
                        x = xOffset + ((x * xSize) + x * space) + 5,
                        y = yOffset + (y * ySize) + y * space + 22,
                        text = "Exp(" + i.Distribution.Lambda.ToString()+")",
                        size = 8,
                    });

                    y++;

                    result.Lines.Add(new MyLine()
                    {
                        width = lineWidth,
                        x1 = xOffset + ((x * xSize) + x * space),
                        y1 = yOffset + ((y-1) * ySize) + (y-1)* space + ySize/2,
                        x2 = xOffset + ((x * xSize) + x * space) - 10,
                        y2 = yOffset + ((y-1) * ySize) + (y-1) * space + ySize / 2,
                    });
                    result.Lines.Add(new MyLine()
                    {
                        width = lineWidth,
                        x1 = xOffset + ((x * xSize) + x * space) + xSize,
                        y1 = yOffset + ((y - 1) * ySize) + (y - 1) * space + ySize / 2,
                        x2 = xOffset + ((x * xSize) + x * space) + 10 + xSize,
                        y2 = yOffset + ((y - 1) * ySize) + (y - 1) * space + ySize / 2,
                    });
                }
            }

            x = 0;
            y = 0;
            foreach (var b in scheme.Blocks)
            {
                x++;
                y = b.ParalelItems.Count;
                if (b.ParalelItems.Count > 0)
                {
                    result.Texts.Add(new MyText()
                    {
                        x = xOffset + ((x * xSize) + x * space),
                        y = yOffset - 30,
                        text = b.Name,
                        size = 13,
                    });
                    result.Lines.Add(new MyLine()
                    {
                        width = lineWidth,
                        x1 = xOffset + ((x * xSize) + x*space) - 10,
                        y1 = yOffset + ySize / 2,
                        x2 = xOffset + ((x * xSize) + x*space) - 10,
                        y2 = yOffset + ((y - 1) * ySize) + (y - 1) * space + ySize - 5,
                    });

                    result.Lines.Add(new MyLine()
                    {
                        width = lineWidth,
                        x1 = xOffset + ((x * xSize) + x * space) + 10 + xSize,
                        y1 = yOffset + ySize / 2,
                        x2 = xOffset + ((x * xSize) + x * space) + 10 + xSize,
                        y2 = yOffset + ((y - 1) * ySize) + (y - 1) * space + ySize - 5,
                    });

                    result.Lines.Add(new MyLine()
                    {
                        width = lineWidth,
                        x1 = xOffset + ((x * xSize) + x * space) + xSize,
                        y1 = yOffset +  ySize / 2,
                        x2 = xOffset + ((x * xSize) + x * space) + space + xSize,
                        y2 = yOffset  + ySize / 2,
                    });
                }

            }
            return result;
        }
    }
}
