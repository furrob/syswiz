using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace checkerboard
{
    class FrameReader
    {
        string filePath;
        int bitsPerSample;
        private int width;
        private int heigth;
        private int frameYCounter = 0;
        private int frameUCounter = 0;
        private int frameVCounter = 0;

        public FrameReader(string filepath, int bitsPerpixel, int Width, int Heigth)
        {
            filePath = filepath;
            bitsPerSample = bitsPerpixel;
            width = Width;
            heigth = Heigth;

        }
       
        //////////////////////////////////////////Ystart = (Yindex * w * h * bps) * 1.5   Yend = Ystart + w * h * bps
        /// Ustart = w * h * bps * (1 + (Uindex * 1.5))
        /// 

        
        public int[] getNextFrameY()
        {
            int Ystart = ((frameYCounter * width * heigth * bitsPerSample)) * 3 / 2;
            int Yend = Ystart + width * heigth * bitsPerSample - 1;
            ++frameYCounter;
            return null;
        }

        public int[] getNextFrameU()
        {
            int Ustart = width * heigth * bitsPerSample * (1 + (frameUCounter * 3 / 2));
            int Uend = Ustart + (width * heigth * bitsPerSample * 1/4) - 1;
            ++frameUCounter;
            return null;
        }

        public int[] getNextFrameV()
        {
            int Vstart = width * heigth * bitsPerSample * (1 + (frameVCounter * 3 / 2)) + (width * heigth * bitsPerSample * 1 / 4);
            int Vend = Vstart + (width * heigth * bitsPerSample * 1 / 4) - 1;
            ++frameVCounter;
            return null;
        }
        
        ////////////////////////////////////////// Michał się skichał  hyhyhyhyhyhyhyhyyhyhyhyhyhyhy
         
        public int[] GetFrameY(int index)
        {
            int Ystart = (index * width * heigth * bitsPerSample) * 3/2;
            int Yend = Ystart + width * heigth * bitsPerSample - 1;
            return null;
        }

        public int[] GetFrameU(int index)
        {
            int Ustart = width * heigth * bitsPerSample * (1 + (index * 3 / 2));
            int Uend = Ustart + (width * heigth * bitsPerSample * 1 / 4) - 1;
            return null;
        }

        public int[] GetFrameV(int index)
        {
            int Vstart = width * heigth * bitsPerSample * (1 + (index * 3 / 2)) + (width * heigth * bitsPerSample * 1 / 4);
            int Vend = Vstart + (width * heigth * bitsPerSample * 1 / 4) - 1;
            return null;
        }
    }
}
