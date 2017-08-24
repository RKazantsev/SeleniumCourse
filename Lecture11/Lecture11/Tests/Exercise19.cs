using NUnit.Framework;

namespace Lecture11
{
    [TestFixture]
    public class Exercise19: TestBase
    {
        [Test]
        public void Test()  
        {
            for (int productCount = 1; productCount <= 3; productCount++)
            {
                manager.Store.SelectProduct();

                manager.Product
                    .WaitProductHeader()
                    .SelectProductSize()
                    .AddProductClick()
                    .CheckCartItemsCount(productCount);

                manager.Navigator
                    .NavigateBackToMainPage()
                    .WaitMainPageLoaded();
            }

            manager.Navigator
                .NavigateToCart()
                .WaitCartPageLoaded();

            manager.Cart
                .RemoveAllProducts()
                .CheckCartIsEmpty();
        }       
    }
}