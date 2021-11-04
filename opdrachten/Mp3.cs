using System;
using System.Collections.Generic;

namespace opdrachten
{
    public class Mp3
    {
        public int id;
        public string make;
        public string model;
        public string mbsize;
        public double price;
        public int inventory;

        public Mp3(int aid, string amake,string amodel, string ambsize, double aprice, int ainventory)
        {
            this.id = aid;
            this.make = amake;
            this.model = amodel;
            this.mbsize = ambsize;
            this.price = aprice;
            this.inventory = ainventory;
        }
        
        public string formatMp3()
        {
            string formatoutputID = string.Format("ID: {0,4}  ", this.id);
            string formatoutputMake = string.Format("Make: {0,-20}  ", this.make);
            string formatoutputModel = string.Format("Model: {0,-10}  ", this.model);
            string formatoutputMBSize = string.Format("Size: {0,8} MB  ", this.mbsize);
            string formatoutputPrice = string.Format("Price: €{0,8:0.00}  ", this.price);
            string formatoutputMp3 = formatoutputID + formatoutputMake + formatoutputModel + formatoutputMBSize + formatoutputPrice;
            
            return formatoutputMp3;
        }
        public string formatinventory()
        {
            string formatoutputID = string.Format("ID: {0,4}  ", this.id);
            string formatoutputinventory = string.Format("Inventory: {0,8}  ", this.inventory);
            string formatoutput = formatoutputID + formatoutputinventory;
            
            return formatoutput;
        }

        /*public static Mp3[] Mp3init()
        {
            Mp3[] mp3s = new Mp3[5];
            mp3s[0] = new Mp3(1, "GET technologies.inc", "HF 410", "4096", 129.95);
            mp3s[1] = new Mp3(2, "Sony", "DN 6792", "5780", 199.95);
            mp3s[2] = new Mp3(3, "Philips", "OP 123", "9182", 299.99);
            mp3s[3] = new Mp3(4, "Medion", "4 HK", "16020", 1000.30);
            mp3s[4] = new Mp3(5, "Logitech", "TGY 905", "2048", 4.99);
            return mp3s;
        } */
        public static List<Mp3> InitializeUsingList()
        {
            List<Mp3> mp3s = new List<Mp3>();
            mp3s.Add ( new Mp3(1, "GET technologies.inc", "HF 410", "4096", 129.95, 500));
            mp3s.Add ( new Mp3(2, "Far & Loud", "XM 600", "8192", 224.95, 500));
            mp3s.Add ( new Mp3(3, "Innotivative", "Z3", "512", 79.95, 500));
            mp3s.Add ( new Mp3(4, "Resistance S.A.", "3001", "4096", 124.95, 500));
            mp3s.Add (new Mp3(5, "CBA", "NXT volume", "2048", 159.05, 500));
            return mp3s;
        }
    }
}