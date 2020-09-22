using System.IO;
using System.Windows.Forms;

namespace checkerboard
{
    class FrameReader
    {
        string filePath;
        
        private int width;
        private int height;
        private int frameYCounter = 0;
        private int frameUCounter = 0;
        private int frameVCounter = 0;
       // public BinaryReader yuvBitStream { get; set; }

        public FrameReader(string filepath, int Width, int Height)
        {
            filePath = filepath;
             
            width = Width;
            height = Height;
            //BinaryReader yuvBitStream = new BinaryReader(File.Open(filepath, FileMode.Open));
        }

        //////////////////////////////////////////Ystart = (Yindex * w * h * bps) * 1.5   Yend = Ystart + w * h * bps
        /// Ustart = w * h * bps * (1 + (Uindex * 1.5))
        /// 


        private void readBitsFromFile(long begin, long end, out byte[] bytes)
        {
            using (BinaryReader yuvBitstream = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                yuvBitstream.BaseStream.Position = begin;
                bytes = yuvBitstream.ReadBytes((int)(end - begin));
            }
        }

        public void getNextFrameY(out byte[] bytes)
        {
            long Ystart = ((frameYCounter * width * height)) * 3L / 2L; //begin
            long Yend = (long)(Ystart + width * height); ///end
            ++frameYCounter;
            readBitsFromFile(Ystart, Yend, out bytes);
        }

        public void getNextFrameU(out byte[] bytes)
        {
            long Ustart = width * height + (width * height + (width * height) / 2L) * frameUCounter;
            long Uend = (long)(Ustart + (width * height * 1L / 4L));
            ++frameUCounter;
            readBitsFromFile(Ustart, Uend, out bytes); 
        }

        public void getNextFrameV(out byte[] bytes)
        {
            long Vstart = width * height + (width * height / 4) + (width * height + (width * height) / 2L) * frameVCounter;
            long Vend = (long)(Vstart + (width * height * 1L / 4L));
            ++frameVCounter;
            readBitsFromFile(Vstart, Vend, out bytes); 
        }
        
        ////////////////////////////////////////// Michał się skichał  hyhyhyhyhyhyhyhyyhyhyhyhyhyhy
         
        public void GetFrameY(int index, out byte[] bytes)
        {
            long Ystart = (index * width * height) * 3L / 2L;
            long Yend = (long)(Ystart + width * height);
            readBitsFromFile(Ystart, Yend, out bytes);
        }

        public void GetFrameU(int index, out byte[] bytes)
        {
            long Ustart = width * height + (width * height + (width * height) / 2L) * index;
            long Uend = (long)(Ustart + (width * height * 1L / 4L));
            readBitsFromFile(Ustart, Uend, out bytes);
        }
        public void GetFrameV(int index, out byte[] bytes)
        {
            long Vstart = width * height + (width * height / 4L) + (width * height + (width * height) / 2L) * index;
            long Vend = (long)(Vstart + (width * height * 1L / 4L));
            readBitsFromFile(Vstart, Vend, out bytes);
        }
    }
}
