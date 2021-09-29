using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPracticeProb.InventoryManagementProgram
{
    class InventoryFactory
    {
        public List<InventoryModel> RiceList { get; set; }
        public List<InventoryModel> PulseList { get; set; }
        public List<InventoryModel> WheatList { get; set; }
    }
}
