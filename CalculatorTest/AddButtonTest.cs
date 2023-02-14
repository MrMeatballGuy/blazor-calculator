using BlazorCalculator.Pages;
using System.Diagnostics.Metrics;
using Bunit;
using AngleSharp.Diffing.Extensions;
using AngleSharp.Dom;

namespace CalculatorTests
{
    public class AddButtonTest
    {
        private TestContext ctx;
        private IRenderedComponent<Calculator> calculatorComponent;
        private IElement inputOne;
        private IElement inputTwo;
        private IElement resultInput;
        public AddButtonTest() {
            this.ctx = new TestContext();
            this.calculatorComponent = ctx.RenderComponent<Calculator>();
            this.inputOne = calculatorComponent.Find("#first-num");
            this.inputTwo = calculatorComponent.Find("#second-num");
            this.resultInput = calculatorComponent.Find("#result");
        }

        [Theory]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(1, -1)]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        public void TestAddButtonSuccess(int firstNumber, int secondNumber)
        {
            // Arrange
            var expectedResult = firstNumber + secondNumber;

            inputOne.Change(firstNumber);
            inputTwo.Change(secondNumber);

            var btn = calculatorComponent.Find("#add-btn");
            btn.Click();

            string output = "";
            resultInput.TryGetAttrValue("value", out output);

            // Assert
            Assert.Equal(expectedResult, Convert.ToInt32(output));
        }

        [Theory]
        [InlineData("a", "b")]
        public void TestAddButtonFail(string firstNumber, string secondNumber)
        {
            inputOne.Change(firstNumber);
            inputTwo.Change(secondNumber);
            var btn = calculatorComponent.Find("#add-btn");

            string expectedResult = "Input string was not in a correct format.";
            btn.Click();

            string output = "";
            resultInput.TryGetAttrValue("value", out output);

            // Assert
            Assert.Equal(expectedResult, output);
        }
    }
}