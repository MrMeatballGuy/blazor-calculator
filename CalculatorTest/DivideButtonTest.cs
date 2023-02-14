using BlazorCalculator.Pages;
using System.Diagnostics.Metrics;
using Bunit;
using AngleSharp.Diffing.Extensions;
using AngleSharp.Dom;
using BlazorCalculator;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorTest
{
    public class DivideButtonTest
    {
        private TestContext ctx;
        private IRenderedComponent<Calculator> calculatorComponent;
        private IElement inputOne;
        private IElement inputTwo;
        private IElement resultInput;
        public DivideButtonTest()
        {
            this.ctx = new TestContext();
            this.ctx.Services.AddScoped<ICustomMath, CustomMath>();
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
        public void TestDivideButtonSuccess(int firstNumber, int secondNumber)
        {
            // Arrange
            var expectedResult = firstNumber / secondNumber;

            inputOne.Change(firstNumber);
            inputTwo.Change(secondNumber);

            var btn = calculatorComponent.Find("#divide-btn");
            btn.Click();

            string output = "";
            resultInput.TryGetAttrValue("value", out output);

            // Assert
            Assert.Equal(expectedResult, Convert.ToDouble(output));
        }

        [Theory]
        [InlineData("a", "b")]
        public void TestDivideButtonFail(string firstNumber, string secondNumber)
        {
            string expectedResult = "Input string was not in a correct format.";

            inputOne.Change(firstNumber);
            inputTwo.Change(secondNumber);

            var btn = calculatorComponent.Find("#divide-btn");

            btn.Click();

            string output = "";
            resultInput.TryGetAttrValue("value", out output);

            // Assert
            Assert.Equal(expectedResult, output);
        }

        [Theory]
        [InlineData(1, 0)]
        public void TestDivideByZeroFail(int firstNumber, int secondNumber)
        {
            // Arrange
            string expectedResult = "Cannot Divide by Zero";

            inputOne.Change(firstNumber);
            inputTwo.Change(secondNumber);

            var btn = calculatorComponent.Find("#divide-btn");
            btn.Click();

            string output = "";
            resultInput.TryGetAttrValue("value", out output);

            // Assert
            Assert.Equal(expectedResult, output);
        }
    }
}
