using HMM.DataModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM.Support
{
    class PrinterHelper
    {
        #region Variables & Properties
        private System.Drawing.Printing.PrintDocument printDocument1;
        int fontSize = 10;
        int bodyStartLine = 6;      //line number where starting printing body
        string separatorLine = ("------------------------------------------------------------");

        ReceiptPrint receiptPrint;
        #endregion

        #region Form Events
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font f1 = new Font("Arial", fontSize);
            Font f2 = new Font("FontA11", fontSize, FontStyle.Bold);

            //e.Graphics.DrawString("Xin cảm ơn, chúc một ngày tốt lành!", f1, Brushes.Black, new Point(10, 10));
            //Draw logo
            //Bitmap bmp = new Bitmap(TTM.Properties.Resources.logo_new,new Size(100,123));
            //e.Graphics.DrawImage(bmp, 0, 0);

            int lineNo = 0;
            int lineSpace = 10;
            //Draw header
            e.Graphics.DrawString("Ngày:", f1, Brushes.Black, new Point(120, 0 * (fontSize + lineSpace)));   //fontsize + 1 for space between lines
            e.Graphics.DrawString("Giờ:", f1, Brushes.Black, new Point(120, 1 * (fontSize + lineSpace)));   //fontsize + 1 for space between lines
            e.Graphics.DrawString("Quầy:", f1, Brushes.Black, new Point(120, 2 * (fontSize + lineSpace)));   //fontsize + 1 for space between lines
            e.Graphics.DrawString("Ca:", f1, Brushes.Black, new Point(120, 3 * (fontSize + lineSpace)));   //fontsize + 1 for space between lines
            e.Graphics.DrawString("Thu ngân:", f1, Brushes.Black, new Point(120, 4 * (fontSize + lineSpace)));   //fontsize + 1 for space between lines
            e.Graphics.DrawString("Số hóa đơn:", f1, Brushes.Black, new Point(120, 5 * (fontSize + lineSpace)));   //fontsize + 1 for space between lines

            //Draw header data            
            e.Graphics.DrawString(receiptPrint.Date, f1, Brushes.Black, new Point(200, (0) * (fontSize + lineSpace)));
            e.Graphics.DrawString(receiptPrint.Time, f1, Brushes.Black, new Point(200, (1) * (fontSize + lineSpace)));
            e.Graphics.DrawString(receiptPrint.Counter, f1, Brushes.Black, new Point(200, (2) * (fontSize + lineSpace)));
            e.Graphics.DrawString(receiptPrint.Shift, f1, Brushes.Black, new Point(200, (3) * (fontSize + lineSpace)));
            e.Graphics.DrawString(receiptPrint.Cashier, f1, Brushes.Black, new Point(200, (4) * (fontSize + lineSpace)));
            e.Graphics.DrawString(receiptPrint.RecieptNo, f1, Brushes.Black, new Point(200, (5) * (fontSize + lineSpace)));

            //Draw body header
            lineNo = 6;
            e.Graphics.DrawString(separatorLine, f1, Brushes.Black, new Point(0, lineNo++ * (fontSize + lineSpace)));   //body separator

            e.Graphics.DrawString("SL", f2, Brushes.Black, new Point(0, lineNo * (fontSize + lineSpace)));   //Qty
            e.Graphics.DrawString("Mô tả", f2, Brushes.Black, new Point(35, lineNo * (fontSize + lineSpace)));   //Qty
            e.Graphics.DrawString("Giá(VND)", f2, Brushes.Black, new Point(200, lineNo * (fontSize + lineSpace)));   //Qty
            lineNo++;
            //separator
            e.Graphics.DrawString(separatorLine, f1, Brushes.Black, new Point(0, lineNo++ * (fontSize + lineSpace)));   //body separator

            //bill items
            foreach (LinePrint line in receiptPrint.BodyLines)
            {
                foreach (ItemPrint item in line.Items)
                    e.Graphics.DrawString(item.Text, f1, Brushes.Black, new Point(item.XPos, (lineNo) * (fontSize + lineSpace)));
                lineNo++;
            }

            //separator
            e.Graphics.DrawString(separatorLine, f1, Brushes.Black, new Point(0, lineNo++ * (fontSize + lineSpace)));   //body separator

            //total and VAT
            e.Graphics.DrawString("Tổng cộng:", f2, Brushes.Black, new Point(0, lineNo++ * (fontSize + lineSpace)));   //fontsize + 1 for space between lines
            e.Graphics.DrawString("VAT 10%:", f2, Brushes.Black, new Point(0, lineNo++ * (fontSize + lineSpace)));   //fontsize + 1 for space between lines

            //separator
            e.Graphics.DrawString(separatorLine, f1, Brushes.Black, new Point(0, lineNo++ * (fontSize + lineSpace)));   //body separator

            e.Graphics.DrawString("Mã KH:", f2, Brushes.Black, new Point(0, lineNo++ * (fontSize + lineSpace)));   //body separator
            e.Graphics.DrawString("Tên KH:", f2, Brushes.Black, new Point(0, lineNo++ * (fontSize + lineSpace)));   //body separator

            //separator
            e.Graphics.DrawString(separatorLine, f1, Brushes.Black, new Point(0, lineNo++ * (fontSize + lineSpace)));   //body separator

            //Thanks
            e.Graphics.DrawString("Xin cảm ơn và chúc vui vẻ!", f2, Brushes.Black, new Point(0, lineNo++ * (fontSize + lineSpace)));   //body separator

        }
        #endregion

        #region Business Logic
        public PrinterHelper()
        {
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
        }


        public void Print(ReceiptPrint receipt)
        {
            receiptPrint = receipt;
            PaperSize pkCustomSize1 = new PaperSize("3.15x11.69", 80, 297);
            this.printDocument1.DefaultPageSettings.PaperSize = pkCustomSize1;
            printDocument1.Print();
        }
        private void printDocument1_EndPrint(object sender, PrintEventArgs e)
        {
        }
        #endregion
    }
}
