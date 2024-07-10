using InventoryMgmt.Interface;
using InventoryMgmt.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMgmtQA.Service
{
    /*Part 2 of Inventory Manager Test*/
    //Remove
    //Modify
    //Get Total after modify quantity
    [TestClass]
    public class InventoryManagerTest_2
    {
        private IInventoryManager _inventoryManager = new InventoryManager();
        [TestMethod]
        public void TestRemoveProduct()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // create a new product with valid attribute values
                _inventoryManager.AddNewProduct(
                    "TestFlour",
                    24,
                    40
                );

                // console output should contain 'success'
                Assert.IsTrue(sw.ToString().Contains("success"));

                //Remove a item
                _inventoryManager.RemoveProduct(1);
                Assert.IsTrue(sw.ToString().Contains("success"));
            }
        }
        [TestMethod]
        public void TestValidateInputRemoveItem()
        {
            using (StringWriter sw = new StringWriter())
            {
                //Input -2 for Product ID
                _inventoryManager.RemoveProduct(-2);
                Assert.IsFalse(sw.ToString().Contains("success"));
            }

        }

        [TestMethod]
        public void TestModifyItem()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // create a new product with valid attribute values
                _inventoryManager.AddNewProduct(
                    "TestFlour",
                    12,
                    40
                );

                // console output should contain 'success' and success add product to modify
                Assert.IsTrue(sw.ToString().Contains("success"));

                //Modify quantity from 12 to 25
                _inventoryManager.UpdateProduct(1, 25);
                Assert.IsTrue(sw.ToString().Contains("success"));
            }
        }

        //Test get total value after modify
        [TestMethod]
        public void TestGetTotal_AfterModify()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // create a new product with valid attribute values
                _inventoryManager.AddNewProduct(
                    "TestFlour",
                    12,
                    40
                );

                // console output should contain 'success' and success add product to modify
                Assert.IsTrue(sw.ToString().Contains("success"));

                //Modify quantity from 12 to 25
                _inventoryManager.UpdateProduct(1, 25);
                Assert.IsTrue(sw.ToString().Contains("success"));

                /*
                 25 x Test Flour - 40.00
                  Expected total value: 1,000.00
                 */
                _inventoryManager.GetTotalValue();
                Assert.IsTrue(sw.ToString().Contains("1,000.00"));
            }
        }
        
        //Test get value after remove one item on product list
        [TestMethod]
        public void TestGetTotal_AfterRemove()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // create a new product with valid attribute values
                //item no.1
                _inventoryManager.AddNewProduct(
                    "TestFlour",
                    24,
                    40
                );

                // console output should contain 'success'
                Assert.IsTrue(sw.ToString().Contains("success"));

                //item no.2
                _inventoryManager.AddNewProduct(
                   "TestEgg",
                   12,
                   10
               );

                //item no.3
                _inventoryManager.AddNewProduct(
                   "TestSalt",
                   5,
                   10
               );

                //Total Value: 1,130.00

                //Remove a item no.2 
                _inventoryManager.RemoveProduct(2);
                Assert.IsTrue(sw.ToString().Contains("success"));

                //New expected value: 1,130.00 - 120.00
                _inventoryManager.GetTotalValue();
                Assert.IsTrue(sw.ToString().Contains("1,010.00"));
            }
        }
    }
}
