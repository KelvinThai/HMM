using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM.DataModels
{
    class ReceiptPrint
    {
        #region Variables & Properties
        public string Date { get; set; }
        public string Time { get; set; }
        public string Counter { get; set; }
        public string Shift { get; set; }
        public string Cashier { get; set; }
        public string RecieptNo { get; set; }

        private ArrayList bodyLines;
        public ArrayList BodyLines
        {
            get
            {
                if (bodyLines == null) bodyLines = new ArrayList();
                return bodyLines;
            }
            set
            {
                bodyLines = value;
            }
        }
        #endregion

        #region Business Logic
        public void AddBodyLine(string qty, string desc, string amount)
        {
            LinePrint line = new LinePrint();
            line.Items.Add(new ItemPrint() { Text = qty, XPos = 0 });
            line.Items.Add(new ItemPrint() { Text = desc, XPos = 35 });
            line.Items.Add(new ItemPrint() { Text = amount, XPos = 200 });
            BodyLines.Add(line);
        }
        #endregion
    }
}
