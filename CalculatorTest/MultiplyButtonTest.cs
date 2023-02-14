using BlazorCalculator.Pages;
using System.Diagnostics.Metrics;
using Bunit;
using AngleSharp.Diffing.Extensions;
using AngleSharp.Dom;

namespace CalculatorTests
{
    public class MultiplyButtonTest
    {
        private TestContext ctx;
        private IRenderedComponent<Calculator> calculatorComponent;
        private IElement inputOne;
        private IElement inputTwo;
        private IElement resultInput;
        public MultiplyButtonTest()
        {
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
        public void TestMultiplyButtonSuccess(int firstNumber, int secondNumber)
        {
            // Arrange
            var expectedResult = firstNumber * secondNumber;

            inputOne.Change(firstNumber);
            inputTwo.Change(secondNumber);

            var btn = calculatorComponent.Find("#multiply-btn");
            btn.Click();

            string output = "";
            resultInput.TryGetAttrValue("value", out output);

            // Assert
            Assert.Equal(expectedResult, Convert.ToInt32(output));
        }

        [Theory]
        [InlineData("a", "b")]
        public void TestDivideButtonFail(string firstNumber, string secondNumber)
        {
            inputOne.Change(firstNumber);
            inputTwo.Change(secondNumber);

            var btn = calculatorComponent.Find("#multiply-btn");

            // Assert
            Assert.Throws<FormatException>(() =>
            {
                btn.Click();
            });
        }
    }
}
