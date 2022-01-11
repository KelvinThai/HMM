using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMM.DataModels
{
    public class ItemInventory
    {
        #region Variables & Properties
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDefID { get; set; }
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string UnitID { get; set; }
        public int Quantity { get; set; }
        public string Desc { get; set; }
        #endregion

        #region Business Logic

        #endregion

    }
    public class ItemDefinition
    {
        #region Variables & Properties
        public string ID { get; set; }
        public string ItemName { get; set; }
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string UnitID { get; set; }
        public int Qty { get; set; }

        public string Desc { get; set; }

        public string ThumbnailImagePath { get; set; }

        public string LargeImagePath { get; set; }
        #endregion

        #region Business Logic

        #endregion

    }

    public class Store
    {
        #region Variables & Properties
        public string ID { get; set; }
        public string StoreName { get; set; }
        #endregion

        #region Business Logic

        #endregion

    }

    public class Category
    {
        #region Variables & Properties
        public string ID { get; set; }
        public string CategoryName { get; set; }
        #endregion

        #region Business Logic

        #endregion

    }
}
