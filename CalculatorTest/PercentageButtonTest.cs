using AngleSharp.Diffing.Extensions;
using AngleSharp.Dom;
using BlazorCalculator;
using BlazorCalculator.Pages;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest
{
    public class PercentageButtonTest
    {
        private TestContext ctx;
        private IRenderedComponent<Calculator> calculatorComponent;
        private IElement inputOne;
        private IElement inputTwo;
        private IElement resultInput;
        public PercentageButtonTest()
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
        [InlineData(1, 1)]
        [InlineData(1, -1)]
        [InlineData(1, 0)]
        public void TestPercentageButtonSuccess(int firstNumber, int secondNumber)
        {
            // Arrange
            var expectedResult = secondNumber / firstNumber * 100;

            inputOne.Change(firstNumber);
            inputTwo.Change(secondNumber);

            var btn = calculatorComponent.Find("#pct-btn");
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
            var btn = calculatorComponent.Find("#pct-btn");
            string expectedResult = "Input string was not in a correct format.";
            btn.Click();

            string output = "";
            resultInput.TryGetAttrValue("value", out output);

            // Assert
            Assert.Equal(expectedResult, output);
        }
    }
}

