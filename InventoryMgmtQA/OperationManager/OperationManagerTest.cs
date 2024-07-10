using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryMgmt.Service;
using InventoryMgmt.Interface;

namespace InventoryMgmtQA.OperationManager
{
    [TestClass]
    public class OperationManagerTest
    {
        private IOperationManager ops = new InventoryMgmt.Service.OperationManager();

        [TestMethod]
        public void TestInvalidSelectOperation()
        {
            //Test for invalid operation
            Assert.ThrowsException<InvalidOperationException>(() => ops.StartOperation(7));
        }

    }
}
