using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeGenerator
{
    public class CustomBarCodeGenerator
    {
        private readonly string StartCode = "1011";
        private readonly string StopCode  = "1101";
        private readonly SolidBrush BlackBrush = new SolidBrush(Color.Black);
        private readonly SolidBrush WhiteBrush = new SolidBrush(Color.White);
        private string GetEncodedData(string data) 
        {
            string EncodedData = StartCode;
            var BynaryDataList = GetBynaryStr(int.Parse(data)).Reverse().ToList();

            foreach (var BynaryChar in BynaryDataList)
            {
                EncodedData += BynaryChar;
            }

            EncodedData += StopCode;

            return EncodedData;
        }

        private string GetBynaryStr(int data)
        {
            if (data == 0)
            { throw new ArgumentOutOfRangeException("Введенный код не может быть закодирован", new Exception()); }

            var result = "1";
            int digit = data;
            if (digit != 1)
            {
                var tempdigit = digit / 2;
                var tempMod = digit % 2;

                result = tempMod.ToString() + GetBynaryStr((int)tempdigit);
            }
            else 
            {
                return result;
            }

            return result;
        }

        public Bitmap Encode(string data,int LeftWidthSpace, int RightWidthSpace)
        {
            if (string.IsNullOrWhiteSpace(data))
            { throw new ArgumentNullException(); }

            var EncodedData = GetEncodedData(data);
            var EncodedDataLenght = EncodedData.Length;

            var bitmap = new Bitmap(LeftWidthSpace + EncodedDataLenght + RightWidthSpace, 50);
           

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    bitmap.SetPixel(x, y, Color.White);
                }
            }

            using (Graphics gfx = Graphics.FromImage(bitmap))
            {
                int xPos = LeftWidthSpace;

                for (int i = 0; i < EncodedDataLenght; i++)
                {
                    var ShtrihLenght = 44;
                    if (i <= 4)
                        ShtrihLenght = 50;
                    if (EncodedDataLenght - i <= 4)
                        ShtrihLenght = 50;

                    var CurrentBrush = BlackBrush;

                    if (EncodedData[i] == '1')
                        CurrentBrush = BlackBrush;
                    else
                        CurrentBrush = WhiteBrush;

                    gfx.FillRectangle(CurrentBrush, xPos, 0, 1, ShtrihLenght);
                    
                    xPos += 1;
                }

            }

            return bitmap;
        }

    
    }
}
